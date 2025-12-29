using System;
using Hezeru.UI;
using KeplerEngine;
using KeplerEngine.GUI;
using KeplerEngine.MemoryCaching;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hezeru.Scenes;

public class MainMenuScene : IScene, IDisposable
{
    private Texture2D _hezeruLogo;
    private Texture2D _playButtonTexture;
    private ElementAnchorData _logoAnchor;
    private Rectangle _logoRect;
    private MainMenuPlayButton _playButton;
    private Texture2D _background;

    public void Load()
    {
        _hezeruLogo = (LoadingScene.LoadedResources[ResourcePaths.Textures.MainMenu.LOGO] as TextureResource).Texture;
        _playButtonTexture = (LoadingScene.LoadedResources[ResourcePaths.Atlases.MainMenu.PLAY_BUTTON] as TextureResource).Texture;
        _playButton = new MainMenuPlayButton(_playButtonTexture);
        _logoAnchor = new ElementAnchorData(ElementAnchor.TopCenter, yOffset: 25);
        _background = (LoadingScene.LoadedResources[ResourcePaths.Textures.MainMenu.BACKGROUND] as TextureResource).Texture;

        _logoRect = new Rectangle(0, 0, _hezeruLogo.Width * 6, _hezeruLogo.Height * 6);

        // Conserve cached resources, we don't want to re-load resources
        // in case the player gets back to this screen.
        // ONLY clear this instances when Dispose() is triggered.
        // Instances will re-generate when getting back to this scene.
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
        Globals.SpriteBatch.Draw(_background, Globals.GetVisibleRenderTargetBounds(), Color.White);

        // Draw with logo rect position, because we don't have any camera in this scene
        Globals.SpriteBatch.Draw(_hezeruLogo, _logoRect, Color.White);

        _playButton.Draw(Globals.DrawTime);
    }

    public void Dispose()
    {
        // Clear class instances.
        // The Garbage Collector should do their work.
        _hezeruLogo = null;
        _playButtonTexture = null;
        _playButton = null;
        _logoAnchor = new ElementAnchorData();
        _background = null;
        _logoRect = new Rectangle();
    }
}
