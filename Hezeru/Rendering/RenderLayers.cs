namespace Hezeru.Rendering;

public static class RenderLayers
{
    public static GUILayer GUILayer { get; } = new GUILayer();

    public static MouseLayer MouseLayer { get; } = new MouseLayer();
}