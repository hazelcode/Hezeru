using System;
using Microsoft.Xna.Framework;

namespace KeplerEngine.GUI;

public abstract class BaseButton : IButton
{
    public Rectangle Bounds = new Rectangle(0, 0, 0, 0);
    public bool Hidden { get; set; }
    public bool IsHovered { get; set; }
    public bool IsClicked { get; set; }
    public string Text { get; set; }
    public Action OnClick { get; set; }
    public Action OnRelease { get; set; }

    public int X  { get; }

    public int Y { get; }

    public ElementAnchorData AnchorData { get; set; } = new ElementAnchorData(ElementAnchor.TopLeftCorner);

    public BaseButton(string text)
    {
        Text = text;
    }

    public void SetBounds(Rectangle bounds)
    {
        Bounds = bounds;
    }

    // Implementing basic PC mouse periferial interaction logic.
    // You can inherit from BaseButton, and override Update to implement custom interaction logic.
    // Like touch screen support, gamepad support, etc.
    // Otherwise, this basic logic will work for most cases.
    public virtual void Update(GameTime gameTime)
    {
        var visible = Globals.VisibleRenderTargetBounds;
        if (visible == Rectangle.Empty)
            visible = Globals.RenderTarget.Bounds;
        AnchorData.AdjustToContainer(visible, ref Bounds);

        IsHovered = Globals.Mouse.IsOver(Bounds);
        
        if(!IsHovered)
        {
            IsClicked = false;
            return;
        }

        if(Globals.Mouse.LeftButtonPressed)
        {
            IsClicked = true;
            OnClick();
        }
        
        if(IsClicked && !Globals.Mouse.LeftButtonPressed && !Globals.Mouse.RightButtonPressed) 
        {
            IsClicked = false;
            OnRelease();
        }
    }

    // You can inherit from BaseButton, and override Draw to implement custom drawing logic.
    // By default, it does nothing, because BaseButton is just a logic container, and not a visual element.
    // So, if you want to inherit your button from BaseButton, you need to implement your own drawing logic.
    public abstract void Draw(GameTime gameTime);
}