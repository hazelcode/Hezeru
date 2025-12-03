using KeplerEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hezeru;

public class DebugOverlay
{
    private SpriteFont _font;
    private bool _showDebug = true;

    public DebugOverlay(SpriteFont font = null)
    {
        _font = font;
    }

    public void Update()
    {
        // Toggle debug overlay with F2
        Globals.Keyboard.OnKeyPressedOnce(Keys.F2, () => {
            _showDebug = !_showDebug;
        });
        

        // Cycle scaling modes with F3
        Globals.Keyboard.OnKeyPressedOnce(Keys.F3, () => {
            var modes = System.Enum.GetValues(typeof(Globals.ScalingMode));
            int currentIndex = (int)Globals.CurrentScalingMode;
            currentIndex = (currentIndex + 1) % modes.Length;
            Globals.CurrentScalingMode = (Globals.ScalingMode)modes.GetValue(currentIndex);
        });
    }

    public void Draw()
    {
        if (!_showDebug || _font == null)
            return;

        string modeText = Globals.CurrentScalingMode.ToString();
        string scaleText = $"Scale: {Globals.UIScale:F2}x";
        string resText = $"Window: {Globals.RenderTargetDisplayRect.Width}x{Globals.RenderTargetDisplayRect.Height}";
        string visibleText = $"Visible: {Globals.VisibleRenderTargetBounds.X},{Globals.VisibleRenderTargetBounds.Y} " +
                             $"{Globals.VisibleRenderTargetBounds.Width}x{Globals.VisibleRenderTargetBounds.Height}";
        string helpText = "F2: Toggle | F3: Change Mode";

        Vector2 pos = new Vector2(10, 10);
        Globals.SpriteBatch.DrawString(_font, $"Mode: {modeText}", pos, Color.LimeGreen);
        pos.Y += 20;
        Globals.SpriteBatch.DrawString(_font, scaleText, pos, Color.LimeGreen);
        pos.Y += 20;
        Globals.SpriteBatch.DrawString(_font, resText, pos, Color.LimeGreen);
        pos.Y += 20;
        Globals.SpriteBatch.DrawString(_font, visibleText, pos, Color.LimeGreen);
        pos.Y += 20;
        Globals.SpriteBatch.DrawString(_font, helpText, pos, Color.Yellow);
    }
}
