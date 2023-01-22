using System.Text.Json.Serialization;

namespace FaraBotModerator.Model
{
    public class SecretKeyModel
    {
        [JsonPropertyName("twitch")] public TwitchSecretKeyModel Twitch { get; set; }
        [JsonPropertyName("deepL")] public DeepLKeyModel DeepL { get; set; }
        [JsonPropertyName("twitter")] public TwitterKeyModel Twitter { get; set; }
        [JsonPropertyName("bouyomiChan")] public BouyomiChanKeyModel BouyomiChan { get; set; }
        [JsonPropertyName("event")] public ReactionEventModel Event { get; set; }
    }

    public class TwitchSecretKeyModel
    {
        [JsonPropertyName("client")] public TwitchClientKeyModel Client { get; set; }
        [JsonPropertyName("api")] public TwitchApiKeyModel Api { get; set; }
    }

    public class TwitchClientKeyModel
    {
        [JsonPropertyName("userName")] public string UserName { get; set; }
        [JsonPropertyName("accessToken")] public string AccessToken { get; set; }
    }

    public class TwitchApiKeyModel
    {
        [JsonPropertyName("clientId")] public string ClientId { get; set; }
        [JsonPropertyName("secret")] public string Secret { get; set; }
    }

    public class DeepLKeyModel
    {
        [JsonPropertyName("freeAuthKey")] public string FreeAuthKey { get; set; }
        [JsonPropertyName("proAuthKey")] public string ProAuthKey { get; set; }
    }

    public class TwitterKeyModel
    {
        [JsonPropertyName("apiKey")] public string ApiKey { get; set; }
        [JsonPropertyName("apiSecret")] public string ApiSecret { get; set; }
    }

    public class BouyomiChanKeyModel
    {
        [JsonPropertyName("isActive")] public bool Checked { get; set; } = true;
    }
    
    public class ReactionEventModel
    {
        [JsonPropertyName("follow")] public ReactionFollowEvent Follow { get; set; }
        [JsonPropertyName("raid")] public ReactionRaidEvent Raid { get; set; }
        [JsonPropertyName("subscription")] public ReactionSubscriptionEvent Subscription { get; set; }
        [JsonPropertyName("bits")] public ReactionBitsEvent Bits { get; set; }
        [JsonPropertyName("gift")] public ReactionGiftEvent Gift { get; set; }
        [JsonPropertyName("channelPoint")] public ReactionChannelPointEvent ChannelPoint { get; set; }
    }

    public class ReactionFollowEvent
    {
        [JsonPropertyName("checked")] public bool Checked { get; set; } = true;
        [JsonPropertyName("message")] public string Message { get; set; }
    }
    public class ReactionRaidEvent
    {
        [JsonPropertyName("checked")] public bool Checked { get; set; } = true;
        [JsonPropertyName("message")] public string Message { get; set; }
    }
    public class ReactionSubscriptionEvent
    {
        [JsonPropertyName("checked")] public bool Checked { get; set; } = true;
        [JsonPropertyName("message")] public string Message { get; set; }
    }
    public class ReactionBitsEvent
    {
        [JsonPropertyName("checked")] public bool Checked { get; set; } = true;
        [JsonPropertyName("message")] public string Message { get; set; }
    }
    public class ReactionGiftEvent
    {
        [JsonPropertyName("checked")] public bool Checked { get; set; } = true;
        [JsonPropertyName("message")] public string Message { get; set; }
    }
    public class ReactionChannelPointEvent
    {
        [JsonPropertyName("checked")] public bool Checked { get; set; } = true;
        [JsonPropertyName("message")] public string Message { get; set; }
    }
}