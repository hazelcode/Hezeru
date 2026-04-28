namespace KeplerEngine;

public static class KeplerServices
{
    public static void SetPreferredResourceManager(ref ResourceManager resourceManager)
    {
        ResourceManager = resourceManager;
    }
    internal static ResourceManager ResourceManager = new ResourceManager();
}