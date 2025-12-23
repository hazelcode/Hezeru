using System.Text.Json.Serialization;

namespace KeplerEngine.Aseprite;

public class Frame
{
    [JsonPropertyName("filename")]
    public string FileName { get; set; }

    [JsonPropertyName("frame")]
    public FrameBounds FrameBounds { get; set; }

    [JsonPropertyName("rotated")]
    public bool Rotated { get; set; }

    [JsonPropertyName("trimmed")]
    public bool Trimmed { get; set; }

    [JsonPropertyName("spriteSourceSize")]
    public SpriteSourceSize SpriteSourceSize { get; set; }

    [JsonPropertyName("sourceSize")]
    public SourceSize SourceSize { get; set; }

    [JsonPropertyName("duration")]
    public int Duration { get; set; }
}
