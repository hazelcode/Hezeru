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
        MousePosition = MouseState.Position;

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