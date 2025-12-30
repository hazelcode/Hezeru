using System.Collections.Generic;
using KeplerEngine.MemoryCaching;

namespace Hezeru.Loading;

public interface ILoader
{
    public IEnumerable<(string ResourceName, IResource Resource)> Stages();
}
