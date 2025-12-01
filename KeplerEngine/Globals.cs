using KeplerEngine.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace KeplerEngine;

public class Globals
{
    public static SpriteBatch SpriteBatch { get; set; }

    public static RenderTarget2D RenderTarget { get; set; }

    public static KeyboardInputHandler Keyboard { get; set; } = new KeyboardInputHandler();

    public static MouseInputHandler Mouse { get; set; } = new MouseInputHandler();

    public static TouchInputHandler Touch { get; set; } = new TouchInputHandler();

    public static SceneManager SceneManager { get; set; } = new SceneManager();
    
    public static GameTime UpdateTime { get; set; }

    public static GameTime DrawTime { get; set; }

    public static float DeltaTime { get; set; }

    public static ContentManager Content { get; set; }

    public static void InitTouch()
    {
        TouchPanel.EnabledGestures = GestureType.Tap;
    }

    public static void Update(GameTime gameTime)
    {
        UpdateTime = gameTime;
        Keyboard.Update();
        Mouse.Update();
        Touch.Update();

        SceneManager.GetCurrentScene().Update();
    }

    public static void Draw(GameTime gameTime)
    {
        DrawTime = gameTime;
        DeltaTime = (float)DrawTime.ElapsedGameTime.TotalSeconds;
        SceneManager.GetCurrentScene().Draw();
    }
}