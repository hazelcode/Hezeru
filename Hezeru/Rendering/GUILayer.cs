using KeplerEngine.Rendering;
using MonoGameGum;
using Microsoft.Xna.Framework;
using KeplerEngine;

namespace Hezeru.Rendering;

public class GUILayer : RenderLayer
{

    // Gum uses its own pipeline
    public override LayerRenderMode RenderMode => LayerRenderMode.Manual;

    public GUILayer() : base(LayerHints.GUI_LAYER) {}

    public override void Render(GameTime gameTime)
    {
        Globals.GumUI.Draw();
    }
}