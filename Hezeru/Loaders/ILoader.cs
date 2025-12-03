using System;
using System.Collections.Generic;

namespace Hezeru.Loaders;

public interface ILoader
{
    public Dictionary<int, (string Description, Action Action)> Stages { get; }
}