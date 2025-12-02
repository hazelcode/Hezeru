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

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        // Apply a 800x600 resolution
        _graphics.PreferredBackBufferWidth = 800;
        _graphics.PreferredBackBufferWidth = 600;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _renderTarget = new RenderTarget2D(GraphicsDevice, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

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
        Globals.SpriteBatch.Draw(
            Globals.RenderTarget,
            new Rectangle(0, 0, Globals.RenderTarget.Width, Globals.RenderTarget.Height),
            Color.White);
        Globals.SpriteBatch.End();

        base.Draw(gameTime);
    }
}
