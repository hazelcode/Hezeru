using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using KeplerEngine;
using KeplerEngine.Aseprite;
using KeplerEngine.MemoryCaching;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hezeru.Loading;

public class StartupLoader : ILoader
{
    public IEnumerable<(string ResourceName, IResource Resource)> Stages()
    {
        Texture2D logoTex = Globals.Content.Load<Texture2D>(ResourcePaths.Textures.MainMenu.LOGO);
        yield return (
            ResourcePaths.Textures.MainMenu.LOGO,
            new Resource<Texture2D> { Data = logoTex }
        );

        Texture2D playButtonTex = Globals.Content.Load<Texture2D>(ResourcePaths.Atlases.MainMenu.PLAY_BUTTON);
        yield return (
            ResourcePaths.Atlases.MainMenu.PLAY_BUTTON,
            new Resource<Texture2D> { Data = playButtonTex }
        );

        Texture2D mousePointerTex = Globals.Content.Load<Texture2D>(ResourcePaths.Textures.UI.MOUSE_POINTER);

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

        Texture2D playerAnimationTexture = Globals.Content.Load<Texture2D>(ResourcePaths.Animations.PLAYER);
        string playerAnimationJson = File.ReadAllText(ResourcePaths.Animations.Json.PLAYER);
        AnimationData playerAnimationData = JsonSerializer.Deserialize<AnimationData>(playerAnimationJson);
        AsepriteAnimation playerAnimation = new AsepriteAnimation(playerAnimationData, playerAnimationTexture);

        yield return (
            ResourcePaths.Animations.PLAYER,
            new Resource<AsepriteAnimation> { Data = playerAnimation }
        );

        Texture2D worldTerrainAtlas = Globals.Content.Load<Texture2D>(ResourcePaths.Atlases.World.TERRAIN_TILES);

        yield return (
            ResourcePaths.Atlases.World.TERRAIN_TILES,
            new Resource<Texture2D> { Data = worldTerrainAtlas }
        );

        Texture2D mainMenuBackgroundTexture = Globals.Content.Load<Texture2D>(ResourcePaths.Textures.MainMenu.BACKGROUND);

        yield return (
            ResourcePaths.Textures.MainMenu.BACKGROUND,
            new Resource<Texture2D> { Data = mainMenuBackgroundTexture }
        );

        SpriteFont consolasFont = Globals.Content.Load<SpriteFont>(ResourcePaths.Fonts.CONSOLAS);

        yield return (
            ResourcePaths.Fonts.CONSOLAS,
            new Resource<SpriteFont> { Data = consolasFont }
            );

        SpriteFont consolas18Font = Globals.Content.Load<SpriteFont>(ResourcePaths.Fonts.CONSOLAS_18);

        yield return (
            ResourcePaths.Fonts.CONSOLAS_18,
            new Resource<SpriteFont> { Data = consolas18Font }
            );
    }
}
