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
    
    // UIScale: scale factor used to map native render target pixels to window pixels
    public static float UIScale { get; set; } = 1f;

    // VisibleRenderTargetBounds: the rectangle (in native render-target coordinates)
    // that is currently visible on screen after scaling (useful for anchoring)
    public static Rectangle VisibleRenderTargetBounds { get; set; } = Rectangle.Empty;
    
    // Rectangle (in window coordinates) where the RenderTarget is drawn
    public static Rectangle RenderTargetDisplayRect { get; set; } = Rectangle.Empty;

    // Scaling modes
    public enum ScalingMode
    {
        Contain, // keep aspect ratio, whole canvas visible (letterbox)
        Cover,   // fill window, may crop
        Integer  // integer pixel-perfect scale (1x,2x,3x...)
    }

    public static ScalingMode CurrentScalingMode { get; set; } = ScalingMode.Contain;

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