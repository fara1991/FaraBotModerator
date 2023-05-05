﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FaraBotModerator.models
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
        /// <param name="key"></param>
        /// <param name="value"></param>
        public BeatSaberChatModel(string key, string value)
        {
            Key = key;
            Value = value;
        }

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
