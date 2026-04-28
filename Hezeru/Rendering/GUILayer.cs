using KeplerEngine.Rendering;
using Microsoft.Xna.Framework;
using KeplerEngine;
using Microsoft.Xna.Framework.Graphics;

namespace Hezeru.Rendering;

public class GUILayer : RenderLayer
{

    // Gum uses its own pipeline
    public override LayerRenderMode RenderMode => LayerRenderMode.Manual;

    public GUILayer() : base(LayerHints.GUI_LAYER) {}

    public override void Draw(SpriteBatch spriteBatch)
    {
        Globals.GumUI.Draw();
    }
}