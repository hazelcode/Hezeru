using System;
using KeplerEngine;
using KeplerEngine.Rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hezeru.Rendering;

public class MouseLayer : RenderLayer
{
    private readonly Texture2D _mouseTex;

    public Point DrawPoint { get; set; }

    public Point DrawSize { get; set; }

    public MouseLayer(Texture2D mouseTex) : base(LayerHints.MOUSE_LAYER)
    {
        _mouseTex = mouseTex ?? throw new ArgumentNullException(nameof(mouseTex));
    }

    public override void Render(GameTime gameTime)
    {
        if(!Enabled || DrawSize.X <= 0 || DrawSize.Y <= 0)
            return;
        
        Globals.SpriteBatch.Draw(
                _mouseTex,
                new Rectangle(DrawPoint, DrawSize),
                Color.White);
    }
}