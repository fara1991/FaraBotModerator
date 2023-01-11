using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FaraBotModerator.Model
{
    public class TwitchRefreshTokenModel
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
        [JsonPropertyName("scope")]
        public List<string> Scope { get; set; }
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }
    }
}