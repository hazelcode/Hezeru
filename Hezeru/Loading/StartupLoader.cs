using System.Collections.Generic;
using Hezeru.Scenes;
using KeplerEngine;
using KeplerEngine.Graphics;
using KeplerEngine.MemoryCaching;
using Microsoft.Xna.Framework.Graphics;

namespace Hezeru.Loading;

public class StartupLoader : ILoader
{
    public IEnumerable<(string ResourceName, IResource Resource)> Stages()
    {
        Texture2D logoTex = Globals.Content.Load<Texture2D>("Sprites/HezeruLogo");
        Sprite logoSprite = new Sprite(logoTex);
        yield return (
            "Sprites/HezeruLogo",
            new SpriteResource { Sprite = logoSprite }
        );
        // Add more loading stages as needed
    }

    public StartupLoader()
    {
        // Stages = new()
        // {
        //     {0, ("Preparing resources...", () => {})},
        //     {1, ("Loading mods...", () => {})}
        // };
    }
}