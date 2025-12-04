using KeplerEngine;
using KeplerEngine.Graphics;
using KeplerEngine.GUI;
using KeplerEngine.MemoryCaching;
using Microsoft.Xna.Framework;

namespace Hezeru.Scenes;

public class MainMenuScene : IScene
{
    private Sprite _hezeruLogo;
    private ElementAnchorData _logoAnchor;
    public void Load()
    {
        _hezeruLogo = (LoadingScene.LoadedResources["Sprites/HezeruLogo"] as SpriteResource).Sprite;
        _logoAnchor = new ElementAnchorData(ElementAnchor.TopCenter, yOffset: 25);
        
        // Free cached resources
        LoadingScene.LoadedResources.Clear();
    }

    public void Update()
    {
        // Use the visible portion of the render target so anchors follow the visible area
        var visible = Globals.VisibleRenderTargetBounds;
        if (visible == Rectangle.Empty)
            visible = Globals.RenderTarget.Bounds;
        
        var hezeruLogoRect = _hezeruLogo.Rect;
        _logoAnchor.AdjustToContainer(visible, ref hezeruLogoRect);
        _hezeruLogo.Rect = hezeruLogoRect;
    }

    public void Draw()
    {
        // Draw at sprite rect position, because we don't have any camera in this scene
        _hezeruLogo.Draw(new Vector2(_hezeruLogo.Rect.X, _hezeruLogo.Rect.Y));
    }
}