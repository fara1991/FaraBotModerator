using System.Text.Json.Serialization;

namespace FaraBotModerator.Model
{
    public class SecretKeyModel
    {
        [JsonPropertyName("twitch")] 
        public TwitchSecretKeyModel Twitch { get; set; }
        [JsonPropertyName("deepL")]
        public DeepLKeyModel DeepL { get; set; }
        [JsonPropertyName("twitter")]
        public TwitterKeyModel Twitter { get; set; }
    }

    public class TwitchSecretKeyModel
    {
        [JsonPropertyName("client")]
        public TwitchClientKeyModel Client { get; set; }
        [JsonPropertyName("api")]
        public TwitchApiKeyModel Api { get; set; }
        [JsonPropertyName("pubsub")]
        public TwitchPubSubKeyModel PubSub { get; set; }
    }

    public class TwitchClientKeyModel
    {
        [JsonPropertyName("userName")]
        public string UserName { get; set; }
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }
        [JsonPropertyName("channelName")]
        public string ChannelName { get; set; }
    }

    public class TwitchApiKeyModel
    {
        [JsonPropertyName("clientId")]
        public string ClientId { get; set; }
        [JsonPropertyName("secret")]
        public string Secret { get; set; }
    }

    public class TwitchPubSubKeyModel
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }

    public class DeepLKeyModel
    {
        [JsonPropertyName("freeAuthKey")]
        public string FreeAuthKey { get; set; }
        [JsonPropertyName("proAuthKey")]
        public string ProAuthKey { get; set; }
    }

    public class TwitterKeyModel
    {
        [JsonPropertyName("apiKey")]
        public string ApiKey { get; set; }
        [JsonPropertyName("apiSecret")]
        public string ApiSecret { get; set; }
    }
}