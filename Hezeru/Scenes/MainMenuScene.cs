using Hezeru.UI;
using KeplerEngine;
using KeplerEngine.GUI;
using KeplerEngine.MemoryCaching;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hezeru.Scenes;

public class MainMenuScene : IScene
{
    private Texture2D _hezeruLogo;
    private Texture2D _playButtonTexture;
    private ElementAnchorData _logoAnchor;
    private Rectangle _logoRect;
    private MainMenuPlayButton _playButton;

    public void Load()
    {
        _hezeruLogo = (LoadingScene.LoadedResources["Sprites/HezeruLogo"] as TextureResource).Texture;
        _playButtonTexture = (LoadingScene.LoadedResources[TexturePaths.MAIN_MENU_PLAY_BUTTON] as TextureResource).Texture;
        _playButton = new MainMenuPlayButton(_playButtonTexture);
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
        _playButton.Update(Globals.UpdateTime);
    }

    public void Draw()
    {
        // Draw with logo rect position, because we don't have any camera in this scene
        Globals.SpriteBatch.Draw(_hezeruLogo, _logoRect, Color.White);
        
        _playButton.Draw(Globals.DrawTime);
    }
}