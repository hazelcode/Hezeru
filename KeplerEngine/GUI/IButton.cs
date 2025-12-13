using System;
using Microsoft.Xna.Framework;

namespace KeplerEngine.GUI;

public interface IButton : IElement
{
    public bool Hidden { get; set; }
    public bool IsHovered { get; set; }
    public bool IsClicked { get; set; }
    public string Text { get; set; }
    public Action OnClick { get; set; }
    public Action OnRelease { get; set; }

    public void SetBounds(Rectangle bounds);
}