using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FaraBotModerator.Model
{
    public class DeepLTranslationModel
    {
        [JsonPropertyName("translations")]
        public List<DeepLTranslationChildModel> Translations { get; set; }
    }

    public abstract class DeepLTranslationChildModel
    {
        protected DeepLTranslationChildModel(string language, string text)
        {
            Language = language;
            Text = text;
        }

        [JsonPropertyName("detected_source_language")]
        public string Language { get; }
        [JsonPropertyName("text")]
        public string Text { get; }
    }
}