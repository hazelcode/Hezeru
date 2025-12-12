using System;
using Microsoft.Xna.Framework;

namespace KeplerEngine.GUI;

public interface IButton
{
    public int X { get; }
    public int Y { get; }
    public Rectangle Bounds { get; }
    public bool Hidden { get; set; }
    public bool IsHovered { get; set; }
    public bool IsClicked { get; set; }
    public string Text { get; set; }
    public Action OnClick { get; set; }
    public Action OnRelease { get; set; }
    public ElementAnchorData AnchorData { get; set; }
    public void Update(GameTime gameTime);
    public void Draw(GameTime gameTime);
}