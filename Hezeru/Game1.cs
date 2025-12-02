using System;
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
    private const int NATIVE_WIDTH = 800;
    private const int NATIVE_HEIGHT = 600;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        // Apply a 800x600 resolution
        _graphics.PreferredBackBufferWidth = 800;
        _graphics.PreferredBackBufferHeight = 600;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
#if DEBUG
        Window.Title = "Hezeru (Development Mode)";
        Window.AllowUserResizing = true;
        Window.ClientSizeChanged += OnWindowResize;
        _graphics.SynchronizeWithVerticalRetrace = false;
#endif
    }

    private void OnWindowResize(object sender, EventArgs e)
    {
        // The RenderTarget keeps him native size (800x600)
        // We only apply the window changes without recreating the RenderTarget
        _graphics.ApplyChanges();
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _renderTarget = new RenderTarget2D(GraphicsDevice, NATIVE_WIDTH, NATIVE_HEIGHT);

        Globals.SpriteBatch = _spriteBatch;
        Globals.RenderTarget = _renderTarget;
        Globals.Content = Content;

        Globals.SceneManager.AddScene(new LoadingScene());
    }

    protected override void Update(GameTime gameTime)
    {
        Globals.Update(gameTime);
        Globals.Keyboard.OnKeyPressedOnce(Keys.Escape, Exit);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.SetRenderTarget(Globals.RenderTarget);
        GraphicsDevice.Clear(Color.Black);
        Globals.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

        // Draw code
        Globals.Draw(gameTime);

        Globals.SpriteBatch.End();
        GraphicsDevice.SetRenderTarget(null);
        Globals.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
        
        // Scale the RenderTarget to the window size
        var targetRect = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
        Globals.SpriteBatch.Draw(
            Globals.RenderTarget,
            targetRect,
            Color.White);
        
        Globals.SpriteBatch.End();

        base.Draw(gameTime);
    }
}
