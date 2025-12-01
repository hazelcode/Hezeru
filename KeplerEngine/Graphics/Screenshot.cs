using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace KeplerEngine.Graphics;

public static class Screenshot
{
    public static void Take(RenderTarget2D screen, string filePath)
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            screen.SaveAsPng(sw.BaseStream, screen.Width, screen.Height);
        }
    }
}