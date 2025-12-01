using System.Collections.Generic;

namespace KeplerEngine.GUI;

public class Overlay
{
    public Dictionary<string, IElement> Elements { get; set; }

    // TODO: Add position for overlays
    //public int X { get; set; }
    //public int Y { get; set; }

    public void Update()
    {
        foreach(var element in Elements)
        {
            element.Value.Update();
        }
    }

    public void Draw()
    {
        foreach (var element in Elements)
        {
            element.Value.Draw();
        }
    }
}