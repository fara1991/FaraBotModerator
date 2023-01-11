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
                CreateKeys();
            }

            using (var file = File.OpenText(SecretFile))
            {
                var jsonData = file.ReadToEnd();
                secretKeys = JsonSerializer.Deserialize<SecretKeyModel>(jsonData);
            }

            return secretKeys;
        }

        public static void SaveKeys(SecretKeyModel secretKeys)
        {
            using (var writer = new StreamWriter(SecretFile))
            {
                var option = new JsonSerializerOptions {WriteIndented = true};
                var jsonData = JsonSerializer.Serialize(secretKeys, option);
                writer.WriteLine(jsonData);
            }
        }

        private static void CreateKeys()
        {
            var secretKeys = new SecretKeyModel
            {
                Twitch = new TwitchSecretKeyModel
                {
                    Client = new TwitchClientKeyModel
                    {
                        UserName = "",
                        AccessToken = "",
                        ChannelName = ""
                    },
                    Api = new TwitchApiKeyModel
                    {
                        ClientId = "",
                        Secret = ""
                    }
                },
                Twitter = new TwitterKeyModel
                {
                    ApiKey = "",
                    ApiSecret = ""
                },
                DeepL = new DeepLKeyModel
                {
                    FreeAuthKey = "",
                    ProAuthKey = ""
                },
                Event = new ReactionEventModel
                {
                    Follow = "",
                    Raid = "",
                    Subscription = "",
                    Bits = "",
                    Gift = ""
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