using KeplerEngine;
using KeplerEngine.Rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hezeru.Rendering;

public class DebugLayer : RenderLayer
{
    public SpriteFont DebugFont { get; set; }
    
    public DebugLayer() : base(LayerHints.DEBUG_LAYER)
    {
        Enabled = false;
    }

    public override void Render(GameTime gameTime)
    {
#if !DEBUG
        return;
#else

        string modeText = Globals.CurrentScalingMode.ToString();
        string scaleText = $"Scale: {Globals.UIScale:F2}x";
        string resText = $"Window: {Globals.RenderTargetDisplayRect.Width}x{Globals.RenderTargetDisplayRect.Height}";
        string visibleText = $"Visible: {Globals.VisibleRenderTargetBounds.X},{Globals.VisibleRenderTargetBounds.Y} " +
                             $"{Globals.VisibleRenderTargetBounds.Width}x{Globals.VisibleRenderTargetBounds.Height}";
        string helpText = "F2: Toggle | F3: Change Mode";

        Vector2 pos = new Vector2(10, 10);
        Globals.SpriteBatch.DrawString(DebugFont, $"Mode: {modeText}", pos, Color.LimeGreen);
        pos.Y += 20;
        Globals.SpriteBatch.DrawString(DebugFont, scaleText, pos, Color.LimeGreen);
        pos.Y += 20;
        Globals.SpriteBatch.DrawString(DebugFont, resText, pos, Color.LimeGreen);
        pos.Y += 20;
        Globals.SpriteBatch.DrawString(DebugFont, visibleText, pos, Color.LimeGreen);
        pos.Y += 20;
        Globals.SpriteBatch.DrawString(DebugFont, helpText, pos, Color.Yellow);
#endif
    }
}