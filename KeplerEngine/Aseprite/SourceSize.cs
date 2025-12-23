using System.Text.Json.Serialization;

namespace KeplerEngine.Aseprite;

public class SourceSize
{
    [JsonPropertyName("w")]
    public int Width { get; set; }

    [JsonPropertyName("h")]
    public int Height { get; set; }
}
