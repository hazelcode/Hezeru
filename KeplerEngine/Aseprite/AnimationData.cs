using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace KeplerEngine.Aseprite;

public class AnimationData
{
    [JsonPropertyName("frames")]
    public List<Frame> Frames { get; set; }

    [JsonPropertyName("meta")]
    public Meta Meta { get; set; }
}
