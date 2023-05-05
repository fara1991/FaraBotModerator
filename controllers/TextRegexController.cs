using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text.Unicode;
using FaraBotModerator.models;

namespace FaraBotModerator.controllers
{
    // Interfaceでもいい？
    internal static class TextRegexController
    {
        private const string BeatSaberDirectory = "ChatSetting/BeatSaber";
        private const string BeatSaberFile = BeatSaberDirectory + "/bsr.json";
        
        /// <summary>
        /// 
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
                    var message = "Text conversion not possible.";
                    LogController.OutputLog(message);
                    throw new FileFormatException(message);
                }

                foreach (var textKeyValues in textRegex.BeatSaberChat)
                {
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
            }
            catch (Exception e)
            {
                LogController.OutputLog(e.Message, true);
                var fileInfo = new FileInfo(BeatSaberFile);
                fileInfo.Delete();
                CreateBsrChatFile();
            }

            return bsrText;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bsrChats"></param>
        private static void SaveBsrChatFile(TextRegexModel bsrChats)
        {
            using var writer = new StreamWriter(BeatSaberFile, false, Encoding.UTF8);
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };
            var jsonData = JsonSerializer.Serialize(bsrChats, options);

            // \003Cだけ変換できないので手動で変換
            writer.WriteLine(jsonData.Replace("\\u003C", "<"));
        }

        /// <summary>
        /// 
        /// </summary>
        private static void CreateBsrChatFile()
        {
            var bsrChats = new TextRegexModel
            {
                BeatSaberChat = new List<BeatSaberChatModel>
                {
                    new(key: "(?<=!bsr ).*", value: "から、ソングリクエスト{0}を頂きました。"),
                    new(key: "(?<=Request).*(?=)", value: "リクエスト曲 {0} が登録されました。"),
                    new(key: "[A-z].*(?=requested by)|(?<=by ).*(?=is next)",
                        value: "次の曲は、{1}さんがリクエストした{0}です。"),
                    new(key: "(?<=Thank you for following).*(?=!)",
                        value: "{0}さん、フォローありがとうございます。"),
                    new(key: "(?=Queue is closed).*", value: "ソングリクエストを終了します。皆さんありがとう！"),
                    new(key: "(?=Queue is open).*", value: "ソングリクエストを開始しました。リクエストお待ちしてます。"),
                    new(key: "[0-9].*(?=raiders from)|(?<=from ).*(?=have joined)",
                        value: "{1}さんが、{0}名の仲間と見に来てくれました。"),
                    new(key: "[A-z0-9].*(?=just raided the channel with)|(?<=with ).*(?=viewers!)",
                        value: "{0}さんが、{1}名の仲間と見に来てくれました。"),
                    new(key: "(?<=No results found for request ).*", value: "{0}はリクエストにないよ。"),
                    new(key: "(?<=Request for).*(?=produces)|(?<=produces).*(?=results)",
                        value: "{0} で検索したら {1}曲あったよ。絞り込んでみてね。"),
                }
            };
            SaveBsrChatFile(bsrChats);
        }
    }
}