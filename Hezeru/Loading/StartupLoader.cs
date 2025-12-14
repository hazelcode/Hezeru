using System;
using System.Collections.Generic;
using Hezeru.Scenes;
using KeplerEngine;
using KeplerEngine.Graphics;
using KeplerEngine.GUI;
using KeplerEngine.MemoryCaching;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hezeru.Loading;

public class StartupLoader : ILoader
{
    public IEnumerable<(string ResourceName, IResource Resource)> Stages()
    {
        Texture2D logoTex = Globals.Content.Load<Texture2D>(TexturePaths.HEZERU_LOGO);
        yield return (
            TexturePaths.HEZERU_LOGO,
            new TextureResource { Texture = logoTex }
        );

        Texture2D playButtonTex = Globals.Content.Load<Texture2D>(TexturePaths.MAIN_MENU_PLAY_BUTTON);
        yield return (
            TexturePaths.MAIN_MENU_PLAY_BUTTON,
            new TextureResource { Texture = playButtonTex }
        );

        Texture2D mousePointerTex = Globals.Content.Load<Texture2D>(TexturePaths.MOUSE_POINTER);

        Globals.OnRender += (gt) =>
        {
            Point windowMousePos = Mouse.GetState().Position;
            
            // Convert window coordinates to native RenderTarget coordinates
            Point renderTargetMouse = new Point(
                (int)((windowMousePos.X - Globals.RenderTargetDisplayRect.X) / Globals.UIScale),
                (int)((windowMousePos.Y - Globals.RenderTargetDisplayRect.Y) / Globals.UIScale));
            
            bool mousePointerFiring =
                Keyboard.GetState().IsKeyDown(Keys.Z)
                || Keyboard.GetState().IsKeyDown(Keys.X)
                || Mouse.GetState().LeftButton == ButtonState.Pressed
                || Mouse.GetState().RightButton == ButtonState.Pressed;

            double mousePointerScale = mousePointerFiring ? 1.25 : 1;

            Point drawPoint = new Point(renderTargetMouse.X - (int)(24.0 * mousePointerScale), renderTargetMouse.Y - (int)(24.0 * mousePointerScale));

            Point drawSize = new Point((int)(48.0 * mousePointerScale), (int)(48.0 * mousePointerScale));

            Globals.SpriteBatch.Draw(
                mousePointerTex,
                new Rectangle(drawPoint, drawSize),
                Color.White);
        };
    }
}
