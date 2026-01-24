using System;

namespace Hezeru.World;

public class WorldItemInfo
{
    public string WorldName { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime LastAccessDate { get; set; }

    public override string ToString()
    {
        return WorldName;
    }
}