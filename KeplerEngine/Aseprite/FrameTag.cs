using System.Text.Json.Serialization;

namespace KeplerEngine.Aseprite;

public class FrameTag
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("from")]
    public int From { get; set; }

    [JsonPropertyName("to")]
    public int To { get; set; }

    [JsonPropertyName("direction")]
    public string Direction { get; set; }
}
