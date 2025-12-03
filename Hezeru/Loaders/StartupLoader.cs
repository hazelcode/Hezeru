using System;
using System.Collections.Generic;

namespace Hezeru.Loaders;

public class StartupLoader : ILoader
{
    public Dictionary<int, (string Description, Action Action)> Stages { get; }

    public StartupLoader()
    {
        Stages = new()
        {
            {0, ("Preparing resources...", () => {})},
            {1, ("Loading mods...", () => {})}
        };
    }
}