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
            new TextureResource { Texture = logoTex }
        );

        Texture2D playButtonTex = Globals.Content.Load<Texture2D>(ResourcePaths.Atlases.MainMenu.PLAY_BUTTON);
        yield return (
            ResourcePaths.Atlases.MainMenu.PLAY_BUTTON,
            new TextureResource { Texture = playButtonTex }
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
            new AsepriteAnimationResource { Animation = playerAnimation }
        );

        Texture2D WorldTerrainAtlas = Globals.Content.Load<Texture2D>(ResourcePaths.Atlases.World.TERRAIN_TILES);

        yield return (
            ResourcePaths.Atlases.World.TERRAIN_TILES,
            new TextureResource { Texture = WorldTerrainAtlas }
        );

        Texture2D MainMenuBackgroundTexture = Globals.Content.Load<Texture2D>(ResourcePaths.Textures.MainMenu.BACKGROUND);

        yield return (
            ResourcePaths.Textures.MainMenu.BACKGROUND,
            new TextureResource { Texture = MainMenuBackgroundTexture }
        );

        SpriteFont consolasFont = Globals.Content.Load<SpriteFont>(ResourcePaths.Fonts.CONSOLAS);

        yield return (
            ResourcePaths.Fonts.CONSOLAS,
            new SpriteFontResource { Font = consolasFont }
            );

        SpriteFont consolas18Font = Globals.Content.Load<SpriteFont>(ResourcePaths.Fonts.CONSOLAS_18);

        yield return (
            ResourcePaths.Fonts.CONSOLAS_18,
            new SpriteFontResource { Font = consolas18Font }
            );
    }
}
