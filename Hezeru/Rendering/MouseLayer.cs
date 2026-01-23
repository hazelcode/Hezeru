using System;
using KeplerEngine;
using KeplerEngine.Rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hezeru.Rendering;

public class MouseLayer : RenderLayer
{
    public Texture2D MouseTex { get; set; }

    public Point DrawPoint { get; set; }

    public Point DrawSize { get; set; }

    public MouseLayer() : base(LayerHints.MOUSE_LAYER)
    {
        // Disabled by default,
        // Enabled on load
        Enabled = false;
    }

    public override void Render(GameTime gameTime)
    {
        if(DrawSize.X <= 0 || DrawSize.Y <= 0)
            return;
        
        Globals.SpriteBatch.Draw(
                MouseTex,
                new Rectangle(DrawPoint, DrawSize),
                Color.White);
    }
}