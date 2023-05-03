using System.Text.Json.Serialization;

namespace FaraBotModerator
{
    /// <summary>
    /// 
    /// </summary>
    public class TwitchApiAuthorizeModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("code")] public string Code { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("scope")] public string Scope { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("state")] public string State { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("error")] public string Error { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("error_description")] public string ErrorDescription { get; set; } = "";
    }
}