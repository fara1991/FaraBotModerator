using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FaraBotModerator.Model
{
    public class DeepLTranslationModel
    {
        [JsonPropertyName("translations")]
        public List<DeepLTranslationChildModel> Translations { get; set; }
    }

    public class DeepLTranslationChildModel
    {
        [JsonPropertyName("detected_source_language")]
        public string Language { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}