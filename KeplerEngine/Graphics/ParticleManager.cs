using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace KeplerEngine.Graphics;

public static class ParticleManager
{
    public static List<Particle> Particles { get; set; } = [];

    public static List<int> RemoveQuery = [];

    public static Random RNG { get; set; } = new Random();

    public static Func<GameTime, Vector2, float, (Vector2 Position, float Rotation)> ParticleMovementPattern { get; set; }

    public static void Update(GameTime gameTime)
    {
        
        (Vector2 Position, float Rotation) NewMovement;

        for(int i = 0; i < Particles.Count; i++)
        {
            var p = Particles[i];
            NewMovement = ParticleMovementPattern(gameTime, Particles[i].Position, Particles[i].Rotation);

            p.Position = NewMovement.Position;
            p.Rotation = NewMovement.Rotation;

            Particles[i] = p;

            if(!Globals.GetVisibleRenderTargetBounds().Contains(p.Position))
            {
                RemoveQuery.Add(i);
            }
        }

        if(RemoveQuery.Count == 0) return;

        RemoveQuery.Sort();
        RemoveQuery.Reverse();
        
        foreach(int i in RemoveQuery)
        {
            Particles.RemoveAt(i);
        }
    }

    public static void Draw()
    {
        foreach(var particle in Particles)
        {
            Globals.SpriteBatch.Draw(
                particle.Texture,
                particle.Position,
                null, // Use full texture
                particle.Color,
                particle.Rotation,
                new Vector2(particle.Texture.Width / 2f, particle.Texture.Height / 2f),
                particle.Scale,
                particle.Effects,
                particle.LayerDepth
            );
        }
    }
}