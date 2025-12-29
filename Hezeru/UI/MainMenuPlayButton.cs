using System.Drawing;
using Hezeru.Scenes;
using KeplerEngine;
using KeplerEngine.GUI;
using Microsoft.Xna.Framework.Graphics;

namespace Hezeru.UI;

public class MainMenuPlayButton : TextureButton
{
    public MainMenuPlayButton(Texture2D texture) : base(texture, new Size(48, 16), new Size(48 * 4, 16 * 4))
    {
        AnchorData = new ElementAnchorData(ElementAnchor.TopCenter, 0, 126);
        OnClick = () => { };
        OnRelease = () =>
        {
            Globals.SceneManager.AddScene(new WorldSelectorScene(), true);
        };
    }
}
