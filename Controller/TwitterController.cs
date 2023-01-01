using System;
using CoreTweet;
using System.Diagnostics;
using System.Configuration;

namespace FaraBotModerator.Controller
{
    public class TwitterController
    {
        private Tokens _token;

        public void SessionStart()
        {
            string apiKey = ConfigurationManager.AppSettings.Get("TwitterAPIKey");
            string apiSecret = ConfigurationManager.AppSettings.Get("TwitterAPISecret");
            var session = OAuth.Authorize(apiKey, apiSecret);
            Process.Start(session.AuthorizeUri.AbsoluteUri);

            var pinCode = Microsoft.VisualBasic.Interaction.InputBox("PINコードを入力してください", "認証用PINコード入力", "", -1, -1);
            _token = session.GetTokens(pinCode);
        }

        public void PushTweet(string tweet)
        {
            // Tweetできる
            _token.Statuses.Update(status => tweet);
        }
    }
}