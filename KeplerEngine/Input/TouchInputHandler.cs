using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using System;

namespace KeplerEngine.Input;

public class TouchEventArgs : EventArgs
{
    public Vector2 Pos;

    public TouchEventArgs(Vector2 pos)
    {
        Pos = pos;
    }
}

public class TouchInputHandler
{
    private TouchCollection _touchCollection;
    public Vector2 LastTouchPosition { get; set; }

    public bool FingerTravelFinished;

    public TouchInputHandler()
    {
        TouchPanel.EnabledGestures = GestureType.Tap;
    }

    public Action<TouchEventArgs> OnTap { get; set; } = (e) => { };
    public Action<TouchEventArgs> OnMove { get; set; } = (e) => { };
    public Action<TouchEventArgs> OnTapRelease { get; set; } = (e) => { };
    
    public bool TouchedOver(Rectangle obj)
    {
        return obj.X <= LastTouchPosition.X
               && obj.Y <= LastTouchPosition.Y
               && obj.Width + obj.X >= LastTouchPosition.X
               && obj.Height + obj.Y >= LastTouchPosition.Y;
    }
    
    public void Update()
    {
        _touchCollection = TouchPanel.GetState();
        foreach(TouchLocation touch in _touchCollection)
        {
            switch(touch.State)
            {
                case TouchLocationState.Pressed:
                    LastTouchPosition = touch.Position;
                    OnTap(new TouchEventArgs(touch.Position));
                    break;

                case TouchLocationState.Moved:
                    FingerTravelFinished = false;
                    LastTouchPosition = touch.Position;
                    OnMove(new TouchEventArgs(touch.Position));
                    break;

                case TouchLocationState.Released:
                    FingerTravelFinished = true;
                    OnTapRelease(new TouchEventArgs(touch.Position));
                    break;
            }
        }
    }
}