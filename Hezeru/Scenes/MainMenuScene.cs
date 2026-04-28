using System;
using System.IO;
using System.Text.Json;
using Hezeru.Particles;
using Hezeru.UI;
using KeplerEngine;
using KeplerEngine.Aseprite;
using KeplerEngine.Graphics;
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
    private Texture2D _background;
    private AsepriteAnimation _testAnimation;
    private Particle _testParticle;
    private Rectangle _testAnimationDestRect = new Rectangle(150, 100, 64, 64);

    public bool BlockUpdate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool BlockRendering { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void Load(ref ResourceManager resourceManager)
    {
        _hezeruLogo = (LoadingScene.LoadedResources[ResourcePaths.Textures.MainMenu.LOGO] as Resource<Texture2D>).Data;
        _playButtonTexture = (LoadingScene.LoadedResources[ResourcePaths.Atlases.MainMenu.PLAY_BUTTON] as Resource<Texture2D>).Data;
        _playButton = new MainMenuPlayButton(_playButtonTexture);
        _logoAnchor = new ElementAnchorData(ElementAnchor.TopCenter, yOffset: 25);
        _background = (LoadingScene.LoadedResources[ResourcePaths.Textures.MainMenu.BACKGROUND] as Resource<Texture2D>).Data;

        _logoRect = new Rectangle(0, 0, _hezeruLogo.Width * 6, _hezeruLogo.Height * 6);

        Texture2D testAnimTex = Globals.Content.Load<Texture2D>("Animations/Particles/ParticleTest");
        string jsonAnim = File.ReadAllText("Content/Animations/Particles/ParticleTest.json");
        AnimationData animData = JsonSerializer.Deserialize<AnimationData>(jsonAnim);
        _testAnimation = new AsepriteAnimation(animData, testAnimTex);

        _testAnimation.PrepareAnimationTag("animation");
        _testAnimation.ChangeDestinationRectangleReference(ref _testAnimationDestRect);

        _testParticle = new TestParticle("Particle1");
        _testParticle.Data.Position = new Vector2(300, 140);

        ParticleManager.AddParticle(_testParticle);

        // Conserve cached resources, we don't want to re-load resources
        // in case the player gets back to this screen.
        // ONLY clear this instances when Dispose() is triggered.
        // Instances will re-generate when getting back to this scene.
    }

    public void Update(GameTime gameTime)
    {
        // Use the visible portion of the render target so anchors follow the visible area
        var visible = Globals.VisibleRenderTargetBounds;
        if (visible == Rectangle.Empty)
            visible = Globals.RenderTarget.Bounds;

        _logoAnchor.AdjustToContainer(visible, ref _logoRect);
        _playButton.Update(Globals.UpdateTime);
        _testAnimation.Update(Globals.UpdateTime);
        _testParticle.Data.Texture = _testAnimation.Texture;
        _testParticle.Data.SourceRectangle = _testAnimation.SourceRect;
        ParticleManager.Update(Globals.UpdateTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_background, Globals.GetVisibleRenderTargetBounds(), Color.White);

        // Draw with logo rect position, because we don't have any camera in this scene
        spriteBatch.Draw(_hezeruLogo, _logoRect, Color.White);

        _playButton.Draw(Globals.DrawTime);
        ParticleManager.Draw();
    }

    public void Destroy(ref ResourceManager resourceManager) {}

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
