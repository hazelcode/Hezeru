using System.Collections.Generic;

namespace Hezeru.World;

public class WorldListManager
{
    public static List<WorldItemInfo> WorldsList { get; private set; } = [];

    public static void AddWorld(WorldItemInfo worldInfo)
    {
        WorldsList.Add(worldInfo);
        WorldsList.Sort(new WorldComparer());
    }
}