using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace DotnetGeminiSDK.Model.Request
{
    public class Content
    {
        [JsonProperty("role", NullValueHandling = NullValueHandling.Ignore)]
        public string? Role { get; set; }

        [JsonProperty("parts")] public List<Part> Parts { get; set; }

        public override string ToString()
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            if (Parts == null)
            {
                return $"{Role}: ";
            }
            
            return $"{Role}: {string.Join("", Parts.Select(x => x.Text))}";
        }
    }

    public class Part
    {
        [JsonProperty("text")] public string Text { get; set; }

        [JsonProperty("inlineData", NullValueHandling = NullValueHandling.Ignore)]
        public InlineData? InlineData { get; set; }
    }

    public class GeminiMessageRequest
    {
        [JsonProperty("contents")] public List<Content> Contents { get; set; }

        [JsonProperty("generationConfig", NullValueHandling = NullValueHandling.Ignore)]
        public GenerationConfig? GenerationConfig { get; set; }

        [JsonProperty("safetySetting", NullValueHandling = NullValueHandling.Ignore)]
        public SafetySetting? SafetySetting { get; set; }

        [JsonProperty("systemInstruction", NullValueHandling = NullValueHandling.Ignore)]
        public Content? SystemInstruction { get; set; }
    }

    public class GenerationConfig
    {
        [JsonProperty("stopSequences")] public List<string> StopSequences { get; set; }

        [JsonProperty("temperature")] public double Temperature { get; set; }

        [JsonProperty("maxOutputTokens")] public int MaxOutputTokens { get; set; }

        [JsonProperty("topP")] public double TopP { get; set; }

        [JsonProperty("topK", NullValueHandling = NullValueHandling.Ignore )] public int? TopK { get; set; }
    }

    public class SafetySetting
    {
        [JsonProperty("category")] public string Category { get; set; }

        [JsonProperty("threshold")] public string Threshold { get; set; }
    }

    public class InlineData
    {
        [JsonProperty("mime_type")] public string MimeType { get; set; }

        [JsonProperty("data")] public string Data { get; set; }
    }
}
