using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FaraBotModerator.Model;

namespace FaraBotModerator.Controller
{
    public static class SecretKeyController
    {
        private const string SecretFile = "secrets.json";
        public static SecretKeyModel LoadKeys()
        {
            SecretKeyModel secretKeys;
            if (!File.Exists(SecretFile))
            {
                SaveKeys();
            }

            using (var file = File.OpenText(SecretFile))
            {
                var jsonData = file.ReadToEnd();
                secretKeys = JsonSerializer.Deserialize<SecretKeyModel>(jsonData);
            }
            return secretKeys;
        }

        public static void SaveKeys(
            string twitchClientUserName = "", 
            string twitchClientAccessToken = "",
            string twitchClientChannelName = "",
            string twitchApiClientId = "",
            string twitchApiSecret = "",
            string twitchPubSubAccessToken = "",
            string twitchPubSubRefreshToken = "",
            string twitterApiKey = "",
            string twitterApiSecret = "",
            string deepLFreeAuthKey = "",
            string deepLProAuthKey = "")
        {
            var secretKeys = new SecretKeyModel
            {
                Twitch = new TwitchSecretKeyModel
                {
                    Client = new TwitchClientKeyModel
                    {
                        UserName = twitchClientUserName, 
                        AccessToken = twitchClientAccessToken,
                        ChannelName = twitchClientChannelName
                    },
                    Api = new TwitchApiKeyModel
                    {
                        ClientId = twitchApiClientId,
                        Secret = twitchApiSecret
                    },
                    PubSub = new TwitchPubSubKeyModel
                    {
                        AccessToken = twitchPubSubAccessToken,
                        RefreshToken = twitchPubSubRefreshToken
                    }
                },
                Twitter = new TwitterKeyModel
                {
                    ApiKey = twitterApiKey,
                    ApiSecret = twitterApiSecret
                },
                DeepL = new DeepLKeyModel
                {
                    FreeAuthKey = deepLFreeAuthKey,
                    ProAuthKey = deepLProAuthKey
                }
            };

            using (var writer = new StreamWriter(SecretFile))
            {
                var option = new JsonSerializerOptions {WriteIndented = true};
                var jsonData = JsonSerializer.Serialize(secretKeys, option);
                writer.WriteLine(jsonData);
            }
        }
    }
}