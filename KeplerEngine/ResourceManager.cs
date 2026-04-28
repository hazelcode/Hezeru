using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

namespace KeplerEngine;

public class ResourceManager
{
    public Dictionary<string, object> Data { get; set; } = [];

    public void LoadResource<T>(ref ContentManager contentManager, string resourceName)
    {
        T loadedResource = contentManager.Load<T>(resourceName);
        if(!Data.TryAdd(resourceName, loadedResource))
        {
            throw new Exception($"Resource {resourceName} could not be registered.");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="contentManager"></param>
    /// <param name="resourceName"></param>
    /// <param name="key">Where the resource will be stored in Data (ResourceManager.Data[key])</param>
    /// <exception cref="Exception"></exception>

    public void LoadResource<T>(ref ContentManager contentManager, string resourceName, string key)
    {
        T loadedResource = contentManager.Load<T>(resourceName);
        if (!Data!.TryAdd(key, loadedResource))
        {
            throw new Exception($"Resource {resourceName} (alias \"{key}\") could not be registered.");
        }
    }

    public void RegisterResoure<T>(T data, string resourceName)
    {
        if (!Data!.TryAdd(resourceName, data))
        {
            throw new Exception($"Resource {resourceName} could not be registered.");
        }
    }

    public void UpdateResource<T>(T data, string resourceName)
    {
        Data![resourceName] = data;
    }

    public void UnbindResource(string resourceName)
    {
        Data!.Remove(resourceName);
    }

    public T GetResource<T>(string name) where T : class
    {
        return Data!.TryGetValue(name, out var resource)
            ? resource as T
            : throw new Exception($"Resource \"{name}\" not found");
    }

    public T GetStructResource<T>(string name) where T : struct
    {
        return Data!.TryGetValue(name, out var resource)
            ? (T)resource
            : throw new Exception($"Resource \"{name}\" not found");
    }
}