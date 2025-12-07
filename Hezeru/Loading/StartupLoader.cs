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
        Texture2D logoTex = Globals.Content.Load<Texture2D>("Sprites/HezeruLogo");
        yield return (
            "Sprites/HezeruLogo",
            new TextureResource { Texture = logoTex }
        );

        Texture2D mousePointerTex = Globals.Content.Load<Texture2D>("Sprites/MousePun");

        Globals.OnRender += (gt) =>
        {
            Point mousePosition = Mouse.GetState().Position;
            bool mousePointerFiring = Keyboard.GetState().IsKeyDown(Keys.Z) || Keyboard.GetState().IsKeyDown(Keys.X);

            Point drawPoint = mousePointerFiring
                ? new Point(mousePosition.X - 32, mousePosition.Y - 32)
                : new Point(mousePosition.X - 16, mousePosition.Y - 16);

            Point drawSize = mousePointerFiring
                ? new Point(64, 64)
                : new Point(32, 32);

            Globals.SpriteBatch.Draw(
                mousePointerTex,
                new Rectangle(drawPoint, drawSize),
                Color.White);
        };
    }
}