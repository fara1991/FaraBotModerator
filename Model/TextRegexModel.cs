using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace FaraBotModerator.Model
{
    public class TextRegexModel
    {
        private string _resultText;

        public TextRegexModel(string resultText)
        {
            // 実装中
            _resultText = resultText;
        }

        public string BeatSaberRegex()
        {
            var filePath = "Setting/BeatSaber/bsr.txt";
            var regexText = "";
            foreach (var reader in File.ReadLines(filePath, Encoding.UTF8))
            {
                var pattern = reader.Split('＝');
                var regexPattern = pattern[0];
                regexText = pattern[1];
                var results = Regex.Matches(regexText, regexPattern);
                if (results.Count <= 0) continue;

                for (int i = 0; i < results.Count; i++)
                {
                    _resultText = _resultText.Replace($"{{{i}}}", results[i].ToString());
                }
                break;
            }

            return _resultText;
        }
    }
}
