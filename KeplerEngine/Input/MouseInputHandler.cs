using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace KeplerEngine.Input;

public class MouseInputHandler
{
    public MouseState MouseState { get; private set; }
    public Point MousePosition { get; private set; }
    public bool LeftButtonPressed { get; private set; }
    public bool RightButtonPressed { get; private set; }
    public bool WheelPressed { get; private set; }

    public void Update()
    {
        MouseState = Mouse.GetState();
        // Map window mouse position to native render-target coordinates if possible
        var pos = MouseState.Position;
        if (KeplerEngine.Globals.RenderTargetDisplayRect != Rectangle.Empty && KeplerEngine.Globals.UIScale > 0f)
        {
            var rt = KeplerEngine.Globals.RenderTargetDisplayRect;
            float sx = KeplerEngine.Globals.UIScale;
            int nx = (int)Math.Round((pos.X - rt.X) / sx);
            int ny = (int)Math.Round((pos.Y - rt.Y) / sx);
            MousePosition = new Point(nx, ny);
        }
        else
        {
            MousePosition = MouseState.Position;
        }

        LeftButtonPressed = MouseState.LeftButton.HasFlag(ButtonState.Pressed);
        RightButtonPressed = MouseState.RightButton.HasFlag(ButtonState.Pressed);
        WheelPressed = MouseState.MiddleButton.HasFlag(ButtonState.Pressed);
    }

    public bool IsOver(Rectangle obj)
    {
        return obj.X <= MousePosition.X
            && obj.Y <= MousePosition.Y
            && obj.Width + obj.X >= MousePosition.X
            && obj.Height + obj.Y >= MousePosition.Y;
    }
}