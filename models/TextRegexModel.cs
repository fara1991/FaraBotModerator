using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading;

namespace FaraBotModerator
{
    /// <summary>
    /// 
    /// </summary>
    public class TextRegexModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("bsrChat")] public List<BeatSaberChatModel> BeatSaberChat { get; set; } = new List<BeatSaberChatModel>();

    }

    /// <summary>
    /// 
    /// </summary>
    public class BeatSaberChatModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("key")] public string Key { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("value")] public string Value { get; set; } = "";
    }
}
