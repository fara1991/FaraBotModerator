using System.IO;
using System.Text.Json;

namespace FaraBotModerator
{
    /// <summary>
    /// 
    /// </summary>
    public static class SecretKeyController
    {
        private const string SecretFile = "secrets.json";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static SecretKeyModel LoadKeys()
        {
            SecretKeyModel? secretKeys;
            if (!File.Exists(SecretFile)) CreateKeys();

            try
            {
                using (var file = File.OpenText(SecretFile))
                {
                    var jsonData = file.ReadToEnd();
                    secretKeys = JsonSerializer.Deserialize<SecretKeyModel>(jsonData);
                }
                if (secretKeys is null)
                {
                    var message = "Secret Keys don't initialize.";
                    LogController.OutputLog(message);
                    throw new FileFormatException(message);
                }
            }
            catch
            {
                throw;
            }

            return secretKeys;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="secretKeys"></param>
        public static void SaveKeys(SecretKeyModel secretKeys)
        {
            using (var writer = new StreamWriter(SecretFile))
            {
                var option = new JsonSerializerOptions { WriteIndented = true };
                var jsonData = JsonSerializer.Serialize(secretKeys, option);
                writer.WriteLine(jsonData);
            }
        }

        /// <summary>
        /// 
        /// </summary>
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
                    },
                    Api = new TwitchApiKeyModel
                    {
                        ClientId = "",
                        Secret = ""
                    }
                },
                DeepL = new DeepLKeyModel
                {
                    ApiKey = "",
                },
                BouyomiChan = new BouyomiChanModel
                {
                    Checked = true
                },
                Event = new ReactionEventModel
                {
                    Follow = new ReactionFollowEvent
                    {
                        Checked = true,
                        Message = "{followerName}, thanks follow gamefa16Hi. Follower Channel URL: {followerChannelUrl}"
                    },
                    Raid = new ReactionRaidEvent
                    {
                        Checked = true,
                        Message = "Welcome raiders, thanks raid {raiderName} gamefa16Hi. Channel URL: {raiderChannelUrl}"
                    },
                    Subscription = new ReactionSubscriptionEvent
                    {
                        Checked = true,
                        Message = "{subscriberName}, thanks subscription {totalSubscriptionMonth} time gamefa16Hi"
                    },
                    Bits = new ReactionBitsEvent
                    {
                        Checked = true,
                        Message = "{bitsSendUserName}, thanks {bitsAmount} bits (total {totalBitsAmount}) gamefa16Hi"
                    },
                    Gift = new ReactionGiftEvent
                    {
                        Checked = true,
                        Message = "{giftedUserName}, thanks gift present gamefa16Hi"
                    },
                    ChannelPoint = new ReactionChannelPointEvent
                    {
                        Checked = true,
                        Message = "{channelPointUserName} use channelPoint of {channelPointTitle} gamefa16Hi"
                    }
                }
            };

            using (var writer = new StreamWriter(SecretFile))
            {
                var option = new JsonSerializerOptions { WriteIndented = true };
                var jsonData = JsonSerializer.Serialize(secretKeys, option);
                writer.WriteLine(jsonData);
            }
        }
    }
}