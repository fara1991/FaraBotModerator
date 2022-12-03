using System.Text.Json.Serialization;

namespace FaraBotModerator.Model
{
    public class TwitchApiAuthorizeModel
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("scope")]
        public string Scope { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
        [JsonPropertyName("error")]
        public string Error { get; set; }
        [JsonPropertyName("error_description")]
        public string ErrorDescription { get; set; }
    }
}