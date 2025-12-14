using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace KeplerEngine.GUI;

public class Overlay
{
    public Dictionary<string, IElement> Elements { get; set; }

    // TODO: Add position for overlays
    //public int X { get; set; }
    //public int Y { get; set; }

    public void Update(GameTime gameTime)
    {
        foreach(var element in Elements)
        {
            element.Value.Update(gameTime);
        }
    }

    public void Draw(GameTime gameTime)
    {
        foreach (var element in Elements)
        {
            element.Value.Draw(gameTime);
        }
    }
}