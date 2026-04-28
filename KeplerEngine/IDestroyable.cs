using System;

namespace KeplerEngine;

public interface IDestroyable : IDisposable
{
    /// <summary>
    /// <strong>Notice: </strong>This method may be called before Dispose(). Ensure your content is unloaded before the C# Garbage Collector collects this object
    /// </summary>
    /// <param name="resourceManager"></param>
    void Destroy(ref ResourceManager resourceManager);
}