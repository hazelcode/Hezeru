using System;
using System.Collections.Generic;

namespace Hezeru.World;

public class WorldComparer : IComparer<WorldItemInfo>
{
    public int Compare(WorldItemInfo a, WorldItemInfo b)
    {
        int result =
            b.CreationDate.CompareTo(a.CreationDate);
        
        if(result != 0) return result;

        result = b.LastAccessDate.CompareTo(a.LastAccessDate);

        if(result != 0) return result;

        return string.Compare(a.WorldName, b.WorldName, StringComparison.Ordinal);
    }
}