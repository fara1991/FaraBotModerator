using System.Configuration;
using System.Diagnostics;
using CoreTweet;
using Microsoft.VisualBasic;

namespace FaraBotModerator.Controller
{
    public class TwitterController
    {
        private Tokens _token;

        public void SessionStart()
        {
            string apiKey = ConfigurationManager.AppSettings.Get("TwitterApiKey");
            string apiSecret = ConfigurationManager.AppSettings.Get("TwitterApiSecret");
            var session = OAuth.Authorize(apiKey, apiSecret);
            Process.Start(session.AuthorizeUri.AbsoluteUri);

            var pinCode = Interaction.InputBox("PINコードを入力してください", "認証用PINコード入力");
            _token = session.GetTokens(pinCode);
        }

        public void PushTweet(string tweet)
        {
            // Tweetできる
            _token.Statuses.Update(status => tweet);
        }
    }
}