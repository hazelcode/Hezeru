using System;
using KeplerEngine.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using MonoGameGum;
using Gum.Forms;
using Gum.Forms.Controls;


namespace KeplerEngine;

public class Globals
{
    public static SpriteBatch SpriteBatch { get; set; }
    public static RenderTarget2D RenderTarget { get; set; }
    
    /// <summary>
    /// UIScale: scale factor used to map native render target pixels to window pixels
    /// </summary>
    public static float UIScale { get; set; } = 1f;

    /// <summary>
    /// VisibleRenderTargetBounds: the rectangle (in native render-target coordinates)
    ///  that is currently visible on screen after scaling (useful for anchoring)
// </summary>
    public static Rectangle VisibleRenderTargetBounds { get; set; } = Rectangle.Empty;
    
    /// <summary>
    /// Rectangle (in window coordinates) where the RenderTarget is drawn
    /// </summary>
    public static Rectangle RenderTargetDisplayRect { get; set; } = Rectangle.Empty;

    /// <summary>
    /// The default Kepler Engine's Gum service
    /// </summary>
    public static GumService GumUI { get; } = GumService.Default;
    

    /// <summary>
    /// Returns the visible render target bounds if they're not empty.
    /// Otherwise, returns the bounds of the original render target.
    public static Rectangle GetVisibleRenderTargetBounds()
    {
        var visible = Globals.VisibleRenderTargetBounds;
        if (visible == Rectangle.Empty)
            visible = Globals.RenderTarget.Bounds;
        
        return VisibleRenderTargetBounds == Rectangle.Empty
            ? RenderTarget.Bounds
            : VisibleRenderTargetBounds;
    }

    /// <summary>
    /// Scaling modes
    /// </summary>
    public enum ScalingMode
    {
        /// <summary>
        /// Keep aspect ratio, whole canvas visible (letterbox)
        /// </summary>
        Contain,

        /// <summary>
        /// Fi
// </summary>
        Cover,
        
        /// <summary>
        /// Integer pixel-perfect scale (1x,2x,3x...)
        /// </summary>
        Integer
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

    public static void InitService(Game game)
    {
        GumUI.Initialize(game, DefaultVisualsVersion.V3);
    }

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
        GumUI.Update(gameTime);
        
        OnUpdate(gameTime);
    }

    public static void Draw(GameTime gameTime)
    {
        DrawTime = gameTime;
        DeltaTime = (float)DrawTime.ElapsedGameTime.TotalSeconds;
        SceneManager.GetCurrentScene().Draw();
        GumUI.Draw();
        
        OnRender(gameTime);
    } 
 
    public static Action<GameTime> OnUpdate = (gt) => {};
    public static Action<GameTime> OnRender = (gt) => {};
}
