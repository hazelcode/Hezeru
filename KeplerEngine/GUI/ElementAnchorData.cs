using Microsoft.Xna.Framework;

namespace KeplerEngine.GUI;

public struct ElementAnchorData
{
    public ElementAnchor Anchor;
    public int XOffset;
    public int YOffset;

    public ElementAnchorData(ElementAnchor anchor = ElementAnchor.TopLeftCorner, int xOffset = 0, int yOffset = 0)
    {
        Anchor = anchor;
        XOffset = xOffset;
        YOffset = yOffset;
    }

    public void AdjustToContainer(Rectangle screen, ref Rectangle obj)
    {
        switch(Anchor)
        {
            case ElementAnchor.TopLeftCorner:
                obj.X = XOffset;
                obj.Y = YOffset;
                break;
            case ElementAnchor.TopCenter:
                obj.X = (screen.Width / 2) - (obj.Width / 2) + XOffset;
                obj.Y = YOffset;
                break;
            case ElementAnchor.TopRightCorner:
                obj.X = screen.Width - obj.Width + XOffset;
                obj.Y = YOffset;
                break;
            case ElementAnchor.LeftCenter:
                obj.X = XOffset;
                obj.Y = (screen.Height / 2) - (obj.Height / 2) + YOffset;
                break;
            case ElementAnchor.Center:
                obj.X = (screen.Width / 2) - (obj.Width / 2) + XOffset;
                obj.Y = (screen.Height / 2) - (obj.Height / 2) + YOffset;
                break;
            case ElementAnchor.RightCenter:
                obj.X = screen.Width - obj.Width + XOffset;
                obj.Y = (screen.Height / 2) - (obj.Height / 2) + YOffset;
                break;
            case ElementAnchor.BottomLeftCorner:
                obj.X = XOffset;
                obj.Y = screen.Height - obj.Height + YOffset;
                break;
            case ElementAnchor.BottomCenter:
                obj.X = (screen.Width / 2) - (obj.Width / 2) + XOffset;
                obj.Y = screen.Height - obj.Height + YOffset;
                break;
            case ElementAnchor.BottomRightCorner:
                obj.X = screen.Width - obj.Width + XOffset;
                obj.Y = screen.Height - obj.Height + YOffset;
                break;
        }
    }
}

