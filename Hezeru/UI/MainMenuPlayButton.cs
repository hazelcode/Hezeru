using System.Drawing;
using KeplerEngine.GUI;
using Microsoft.Xna.Framework.Graphics;

namespace Hezeru.UI;

public class MainMenuPlayButton : TextureButton
{
    public MainMenuPlayButton(Texture2D texture) : base(texture, new Size(48, 16), new Size(48 * 8, 16 * 8))
    {
        AnchorData = new ElementAnchorData(ElementAnchor.TopCenter, 0, 126);
        OnClick = () => { };
        OnRelease = () => { };
    }
}