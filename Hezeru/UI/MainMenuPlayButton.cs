using System.Drawing;
using KeplerEngine.GUI;
using Microsoft.Xna.Framework.Graphics;

namespace Hezeru.UI;

public class MainMenuPlayButton : TextureButton
{
    public MainMenuPlayButton(Texture2D texture) : base(texture, new Size(48, 16), new Size(96, 32))
    {
        AnchorData = new ElementAnchorData(ElementAnchor.TopCenter, 0, 106);
        OnClick = () => { };
        OnRelease = () => { };
    }
}