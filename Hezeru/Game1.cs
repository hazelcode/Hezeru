using System;
using Hezeru.Loading;
using Hezeru.Scenes;
using KeplerEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hezeru;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private RenderTarget2D _renderTarget;
    private const int NATIVE_WIDTH = 1280;
    private const int NATIVE_HEIGHT = 720;
    private DebugOverlay _debugOverlay;
    private SpriteFont _consolasFont;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        // Apply a 960x540 resolution
        _graphics.PreferredBackBufferWidth = 960;
        _graphics.PreferredBackBufferHeight = 540;
        Content.RootDirectory = "Content";
        IsMouseVisible = false;
#if DEBUG
        Window.Title = "Hezeru (Development Mode)";
        Window.AllowUserResizing = true;
        Window.ClientSizeChanged += OnWindowResize;
        _graphics.SynchronizeWithVerticalRetrace = false;
        IsMouseVisible = true;
#endif
    }

    private void OnWindowResize(object sender, EventArgs e)
    {
        // The RenderTarget keeps him native size (800x600)
        // We only apply the window changes without recreating the RenderTarget
        _graphics.ApplyChanges();
        UpdateUIScaling();
    }

    protected override void Initialize()
    {
        // Initialize Kepler Engine's Gum UI service.
        Globals.InitService(this);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _renderTarget = new RenderTarget2D(GraphicsDevice, NATIVE_WIDTH, NATIVE_HEIGHT);

        Globals.SpriteBatch = _spriteBatch;
        Globals.RenderTarget = _renderTarget;
        Globals.Content = Content;

        _consolasFont = Globals.Content.Load<SpriteFont>("Fonts/Consolas");

        // Initialize UI scaling/visible rect
        UpdateUIScaling();

        // Initialize debug overlay (null font is ok, just won't display text)
        _debugOverlay = new DebugOverlay(_consolasFont);

        Globals.SceneManager.AddScene(new LoadingScene(new StartupLoader(), new MainMenuScene()));
    }

    protected override void Update(GameTime gameTime)
    {
#if DEBUG
        Globals.Keyboard.OnKeyPressedOnce(Keys.F11, _graphics.ToggleFullScreen);
#endif
        // Recalculate UI scaling each frame (in case window size changed)
        UpdateUIScaling();

        // Update debug overlay
        _debugOverlay.Update();

        Globals.Update(gameTime);
        Globals.Keyboard.OnKeyPressedOnce(Keys.Escape, Exit);

        base.Update(gameTime);
    }

    private void UpdateUIScaling()
    {
        int winW = GraphicsDevice.Viewport.Width;
        int winH = GraphicsDevice.Viewport.Height;

        // Choose scaling mode
        float scale;
        switch (KeplerEngine.Globals.CurrentScalingMode)
        {
            case KeplerEngine.Globals.ScalingMode.Contain:
                // keep whole canvas visible
                scale = Math.Min((float)winW / NATIVE_WIDTH, (float)winH / NATIVE_HEIGHT);
                break;
            case KeplerEngine.Globals.ScalingMode.Cover:
                // fill window, may crop
                scale = Math.Max((float)winW / NATIVE_WIDTH, (float)winH / NATIVE_HEIGHT);
                break;
            case KeplerEngine.Globals.ScalingMode.Integer:
                // integer pixel-perfect scale (1x,2x,3x...)
                var raw = Math.Min((float)winW / NATIVE_WIDTH, (float)winH / NATIVE_HEIGHT);
                var intval = (int)Math.Floor(raw);
                if (intval < 1) intval = 1;
                scale = intval;
                break;
            default:
                scale = Math.Min((float)winW / NATIVE_WIDTH, (float)winH / NATIVE_HEIGHT);
                break;
        }

        // Compute how the render target will be drawn onto the window
        int drawW = (int)(NATIVE_WIDTH * scale);
        int drawH = (int)(NATIVE_HEIGHT * scale);
        int offsetX = (winW - drawW) / 2;
        int offsetY = (winH - drawH) / 2;

        // Visible region of the native render target (in native pixels)
        float invScale = 1f / scale;
        float visXf = Math.Max(0f, -offsetX * invScale);
        float visYf = Math.Max(0f, -offsetY * invScale);
        float visWf = Math.Min(NATIVE_WIDTH - visXf, winW * invScale);
        float visHf = Math.Min(NATIVE_HEIGHT - visYf, winH * invScale);

        Globals.UIScale = scale;
        Globals.VisibleRenderTargetBounds = new Rectangle(
            (int)Math.Round(visXf),
            (int)Math.Round(visYf),
            (int)Math.Round(visWf),
            (int)Math.Round(visHf));
        // Store where the render target is drawn on the screen (window coordinates)
        Globals.RenderTargetDisplayRect = new Rectangle(offsetX, offsetY, drawW, drawH);
    }

    protected override void Draw(GameTime gameTime)
    {
        // Render everything at native resolution (no internal SpriteBatch transform)
        GraphicsDevice.SetRenderTarget(Globals.RenderTarget);
        GraphicsDevice.Clear(Color.Black);
        Globals.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

#region Game renderization
        // Draw code at native coordinates
        Globals.Draw(gameTime);


        Globals.SpriteBatch.End();
        // Draw Gum UI into the active render target now that our SpriteBatch has ended
        Globals.GumUI.Draw();
#endregion

        GraphicsDevice.SetRenderTarget(null);

        // Final pass: draw the RenderTarget scaled to fill the window (cover)
        float scale = Globals.UIScale;
        int drawW = (int)(NATIVE_WIDTH * scale);
        int drawH = (int)(NATIVE_HEIGHT * scale);
        int offsetX = (GraphicsDevice.Viewport.Width - drawW) / 2;
        int offsetY = (GraphicsDevice.Viewport.Height - drawH) / 2;
        var targetRect = new Rectangle(offsetX, offsetY, drawW, drawH);

        GraphicsDevice.Clear(Color.Black);
        Globals.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
        Globals.SpriteBatch.Draw(Globals.RenderTarget, targetRect, Color.White);

        // Draw debug overlay on top
        _debugOverlay.Draw();

        Globals.SpriteBatch.End();

        base.Draw(gameTime);
    }
}
