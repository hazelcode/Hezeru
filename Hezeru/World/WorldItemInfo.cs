namespace Hezeru.World;

public class WorldItemInfo
{
    public string WorldName { get; set; }

    public WorldItemInfo(string worldName)
    {
        WorldName = worldName;
    }

    public override string ToString()
    {
        return WorldName;
    }
}