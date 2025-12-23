using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KeplerEngine.Aseprite;

public class Meta
{
    [JsonPropertyName("app")]
    public string App { get; set; }

    [JsonPropertyName("version")]
    public string Version { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("format")]
    public string Format { get; set; }

    [JsonPropertyName("size")]
    public Size Size { get; set; }

    [JsonPropertyName("scale")]
    public string Scale { get; set; }

    [JsonPropertyName("frameTags")]
    public List<FrameTag> FrameTags { get; set; }
}
