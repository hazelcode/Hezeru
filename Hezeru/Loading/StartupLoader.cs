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
        Texture2D logoTex = Globals.Content.Load<Texture2D>("Sprites/HezeruLogo");
        yield return (
            "Sprites/HezeruLogo",
            new TextureResource { Texture = logoTex }
        );

        Texture2D mousePointerTex = Globals.Content.Load<Texture2D>("Sprites/MousePointer");

        Globals.OnRender += (gt) =>
        {
            Point mousePosition = Mouse.GetState().Position;
            bool mousePointerFiring = Keyboard.GetState().IsKeyDown(Keys.Z) || Keyboard.GetState().IsKeyDown(Keys.X);

            double mousePointerScale = mousePointerFiring ? 1.5 : 1;

            Point drawPoint = new Point(mousePosition.X - (int)(16.0 * mousePointerScale), mousePosition.Y - (int)(16.0 * mousePointerScale));

            Point drawSize = new Point((int)(32.0 * mousePointerScale), (int)(32.0 * mousePointerScale));

            Globals.SpriteBatch.Draw(
                mousePointerTex,
                new Rectangle(drawPoint, drawSize),
                Color.White);
        };
    }
}
