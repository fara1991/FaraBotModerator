using System.Collections.Generic;
using System.Net.Http;

namespace FaraBotModerator.controllers;

/// <summary>
/// </summary>
public class BouyomiChanController
{
    /// <summary>
    ///     棒読みちゃんに音声合成タスクを追加します。
    /// </summary>
    /// <param name="talkName">喋らせたい名前</param>
    /// <param name="talkText">喋らせたい文章</param>
    public void AddTalkTask(string talkName, string talkText, bool bouyomiChanCall)
    {
        if (bouyomiChanCall) CreateTalk($"{talkName}さん {talkText}");
    }

    /// <summary>
    /// </summary>
    /// <param name="talkText"></param>
    /// <param name="bouyomiChanCall"></param>
    public void AddEventTalkTask(string talkText, bool bouyomiChanCall)
    {
        if (bouyomiChanCall) CreateTalk(talkText);
    }

    private void CreateTalk(string talkText)
    {
        var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("text", talkText),
            new KeyValuePair<string, string>("speed", "-1"),
            new KeyValuePair<string, string>("tone", "-1"),
            new KeyValuePair<string, string>("volume", "-1"),
            new KeyValuePair<string, string>("voice", "0")
        });

        using (var client = new HttpClient())
        {
            _ = client.PostAsync("http://localhost:5008/Talk", content).Result;
        }
    }
}