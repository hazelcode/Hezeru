using System.Collections.Generic;

namespace Hezeru.World;

public class WorldComparer : IComparer<WorldItemInfo>
{
    public int Compare(WorldItemInfo a, WorldItemInfo b)
    {
        int result =
            a.CreationDate.CompareTo(b.CreationDate);
        
        if(result != 0) return result;

        result = a.LastAccessDate.CompareTo(b.LastAccessDate);

        if(result != 0) return result;

        return string.Compare(a.WorldName, b.WorldName);
    }
}