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
                    // Map window touch position to native render-target coordinates if possible
                    var pos = touch.Position;
                    if (KeplerEngine.Globals.RenderTargetDisplayRect != Rectangle.Empty && KeplerEngine.Globals.UIScale > 0f)
                    {
                        var rt = KeplerEngine.Globals.RenderTargetDisplayRect;
                        float sx = KeplerEngine.Globals.UIScale;
                        LastTouchPosition = new Vector2((pos.X - rt.X) / sx, (pos.Y - rt.Y) / sx);
                        OnTap(new TouchEventArgs(LastTouchPosition));
                    }
                    else
                    {
                        LastTouchPosition = pos;
                        OnTap(new TouchEventArgs(pos));
                    }
                    break;

                case TouchLocationState.Moved:
                    FingerTravelFinished = false;
                    pos = touch.Position;
                    if (KeplerEngine.Globals.RenderTargetDisplayRect != Rectangle.Empty && KeplerEngine.Globals.UIScale > 0f)
                    {
                        var rt2 = KeplerEngine.Globals.RenderTargetDisplayRect;
                        float sx2 = KeplerEngine.Globals.UIScale;
                        LastTouchPosition = new Vector2((pos.X - rt2.X) / sx2, (pos.Y - rt2.Y) / sx2);
                        OnMove(new TouchEventArgs(LastTouchPosition));
                    }
                    else
                    {
                        LastTouchPosition = pos;
                        OnMove(new TouchEventArgs(pos));
                    }
                    break;

                case TouchLocationState.Released:
                    FingerTravelFinished = true;
                    pos = touch.Position;
                    if (KeplerEngine.Globals.RenderTargetDisplayRect != Rectangle.Empty && KeplerEngine.Globals.UIScale > 0f)
                    {
                        var rt3 = KeplerEngine.Globals.RenderTargetDisplayRect;
                        float sx3 = KeplerEngine.Globals.UIScale;
                        LastTouchPosition = new Vector2((pos.X - rt3.X) / sx3, (pos.Y - rt3.Y) / sx3);
                        OnTapRelease(new TouchEventArgs(LastTouchPosition));
                    }
                    else
                    {
                        LastTouchPosition = pos;
                        OnTapRelease(new TouchEventArgs(pos));
                    }
                    break;
            }
        }
    }
}