using KeplerEngine;
using KeplerEngine.GUI;
using KeplerEngine.MemoryCaching;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hezeru.Scenes;

public class MainMenuScene : IScene
{
    private Texture2D _hezeruLogo;
    private ElementAnchorData _logoAnchor;
    private Rectangle _logoRect;
    public void Load()
    {
        _hezeruLogo = (LoadingScene.LoadedResources["Sprites/HezeruLogo"] as TextureResource).Texture;
        _logoAnchor = new ElementAnchorData(ElementAnchor.TopCenter, yOffset: 25);

        _logoRect = new Rectangle(0, 0, _hezeruLogo.Width * 6, _hezeruLogo.Height * 6);
        
        // Free cached resources
        LoadingScene.LoadedResources.Clear();
    }

    public void Update()
    {
        // Use the visible portion of the render target so anchors follow the visible area
        var visible = Globals.VisibleRenderTargetBounds;
        if (visible == Rectangle.Empty)
            visible = Globals.RenderTarget.Bounds;

        _logoAnchor.AdjustToContainer(visible, ref _logoRect);
    }

    public void Draw()
    {
        // Draw with logo rect position, because we don't have any camera in this scene
        Globals.SpriteBatch.Draw(_hezeruLogo, _logoRect, Color.White);
    }
}