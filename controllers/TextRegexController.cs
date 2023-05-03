using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace FaraBotModerator.controllers
{
    internal class TextRegexController
    {
        private const string RegexFile = "bsr.json";
        private string ResultText;

        public TextRegexController(string resultText) { 
            ResultText = resultText;

            // BeatSaber
            var directoryName = $@"{Directory.GetCurrentDirectory()}/ChatSetting/BeatSaber";
            var filePath = $"{directoryName}/{RegexFile}";

            if (!Directory.Exists(directoryName)) Directory.CreateDirectory(directoryName);
            if (!File.Exists(filePath)) CreateBsrChat();
        }


        public string BeatSaberRegex()
        {
            // 実装は後で

            return ResultText;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<BeatSaberChatModel> LoadBsrChat()
        {
            List<BeatSaberChatModel>? bsrChats;
            try
            {
                using (var file = File.OpenText(RegexFile))
                {
                    var jsonData = file.ReadToEnd();
                    bsrChats = JsonSerializer.Deserialize<List<BeatSaberChatModel>>(jsonData);
                }
                if (bsrChats is null)
                {
                    var message = "bsr chats don't initialize.";
                    LogController.OutputLog(message);
                    throw new FileFormatException(message);
                }
            }
            catch
            {
                throw;
            }

            return bsrChats;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bsrChats"></param>
        public static void SaveBsrChat(TextRegexModel bsrChats)
        {
            using (var writer = new StreamWriter(RegexFile))
            {
                var option = new JsonSerializerOptions { WriteIndented = true };
                var jsonData = JsonSerializer.Serialize(bsrChats, option);
                writer.WriteLine(jsonData);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void CreateBsrChat()
        {
            var bsrChats = new TextRegexModel
            {
                BeatSaberChat = new List<BeatSaberChatModel>() {
                    new BeatSaberChatModel { Key = "(?<=\\!bsr ).*", Value = "から、ソングリクエスト{0}を頂きました。" },
                    new BeatSaberChatModel { Key = "(?<=Request).*(?=\\()", Value = "リクエスト曲 {0} が登録されました。" },
                    new BeatSaberChatModel { Key = "[A-z].*(?=requested by)|(?<=by ).*(?=is next)", Value = "次の曲は、{1}さんがリクエストした{0}です。" },
                    new BeatSaberChatModel { Key = "(?<=Thank you for following).*(?=\\!)", Value = "{0}さん、フォローありがとうございます。" },
                    new BeatSaberChatModel { Key = "(?=Queue is closed).*", Value = "ソングリクエストを終了します。皆さんありがとう！" },
                    new BeatSaberChatModel { Key = "(?=Queue is open).*", Value = "ソングリクエストを開始しました。リクエストお待ちしてます。" },
                    new BeatSaberChatModel { Key = "[0-9].*(?=raiders from)|(?<=from ).*(?=have joined)", Value = "{1}さんが、{0}名の仲間と見に来てくれました。" },
                    new BeatSaberChatModel { Key = "[A-z0-9].*(?=just raided the channel with)|(?<=with ).*(?=viewers!)", Value = "{0}さんが、{1}名の仲間と見に来てくれました。" },
                    new BeatSaberChatModel { Key = "(?<=No results found for request ).*", Value = "{0}はリクエストにないよ。" },
                    new BeatSaberChatModel { Key = "(?<=Request for).*(?=produces)|(?<=produces).*(?=results)", Value = "{0} で検索したら {1}曲あったよ。絞り込んでみてね。" },
                }
            };
            using (var writer = new StreamWriter(RegexFile))
            {
                var option = new JsonSerializerOptions { WriteIndented = true };
                var jsonData = JsonSerializer.Serialize(bsrChats, option);
                writer.WriteLine(jsonData);
            }
        }
    }
}
