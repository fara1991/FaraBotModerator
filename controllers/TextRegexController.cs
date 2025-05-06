﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text.Unicode;
using FaraBotModerator.models;

namespace FaraBotModerator.controllers;

internal static class TextRegexController
{
    private const string BeatSaberDirectory = "ChatSetting/BeatSaber";
    private const string BeatSaberFile = BeatSaberDirectory + "/bsr.json";

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public static string LoadBsrChat(string bsrText)
    {
        // BeatSaber
        if (!Directory.Exists(BeatSaberDirectory)) Directory.CreateDirectory(BeatSaberDirectory);
        if (!File.Exists(BeatSaberFile)) CreateBsrChatFile();
        try
        {
            TextRegexModel? textRegex;
            using (var file = File.OpenText(BeatSaberFile))
            {
                var jsonData = file.ReadToEnd();
                textRegex = JsonSerializer.Deserialize<TextRegexModel>(jsonData);
            }

            if (textRegex is null)
            {
                var message = "<Error> Text conversion not possible.";
                LogController.OutputLog(message);
                throw new FileFormatException(message);
            }

            foreach (var textKeyValues in textRegex.BeatSaberChat)
                if (Regex.IsMatch(bsrText, textKeyValues.Key))
                {
                    // !bsr xxxx
                    // Request Dope /Krouton_06 68.1% (xxxx) added to queue.
                    // ↑をチャット表示用にデータ取得でもいい
                    // https://api.beatsaver.com/maps/id/xxxx
                    var matches = Regex.Matches(bsrText, textKeyValues.Key);
                    for (var i = 0; i < matches.Count; i++)
                        textKeyValues.Value = textKeyValues.Value.Replace("{" + i + "}", matches[i].Value);

                    return textKeyValues.Value;
                }
        }
        catch (Exception e)
        {
            LogController.OutputLog($"<Error> {e.Message}");
            var fileInfo = new FileInfo(BeatSaberFile);
            fileInfo.Delete();
            CreateBsrChatFile();
        }

        return bsrText;
    }

    /// <summary>
    /// </summary>
    /// <param name="textRegex"></param>
    private static void SaveBsrChatFile(TextRegexModel textRegex)
    {
        using var writer = new StreamWriter(BeatSaberFile, false, Encoding.UTF8);
        var options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        };
        var jsonData = JsonSerializer.Serialize(textRegex, options);

        // 変換したい特殊文字は先に変換
        jsonData = jsonData
            .Replace("\\u002B", "+")
            .Replace("\\u003C", "<");
        writer.WriteLine(jsonData);
    }

    /// <summary>
    /// </summary>
    private static void CreateBsrChatFile()
    {
        var textRegex = new TextRegexModel
        {
            BeatSaberChat = new List<BeatSaberChatModel>
            {
                new("(?<=!bsr ).*", "から、ソングリクエスト{0}を頂きました。"),
                new("(?<=Request ).*?(?= /)", "リクエスト曲 {0} が登録されました。"),
                new("^[^/]+(?= */)|(?<=requested by )[^ ]+(?= +is next)",
                    "次の曲は、{1}さんがリクエストした{0}です。"),
                new("(?=Queue is closed).*", "ソングリクエストを終了します。皆さんありがとう！"),
                new("(?=Queue is open).*", "ソングリクエストを開始しました。リクエストお待ちしてます。"),
                new("(?<=No results found for request ).*", "{0}はリクエストにないよ。"),
                new("(?<=Request for).*(?=produces)|(?<=produces).*(?=results)",
                    "{0} で検索したら {1}曲あったよ。絞り込んでみてね。")
            }
        };
        SaveBsrChatFile(textRegex);
    }
}