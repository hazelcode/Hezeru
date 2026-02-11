using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace KeplerEngine.Graphics;

public static class ParticleManager
{
    public static List<Particle> Particles { get; set; } = [];

    public readonly static List<int> RemoveQuery = [];

    private static uint _nextId = 0;

    public static Random RNG { get; set; } = new Random();

    public static void AddParticle(Particle particle)
    {
        Particles.Add(particle);
        particle.Data.ID = _nextId++;

        /*
        There is no particle emission service yet,
        so they will be emitted directly
        */
        particle.Emit();
    }

    public static void Update(GameTime gameTime)
    {
        for (int i = 0; i < Particles.Count; i++)
        {
            if (Particles[i].IsDestroyed)
            {
                RemoveQuery.Add(i);
                /*
                The following instructions are omitted, so if this particle is destroyed,
                no further logic will be processed for this single particle,
                and then it will be taken out of scope and forgotten.
                */
                continue;
            }

            Particles[i].Update(gameTime);

            Particles[i].Data.ElapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            if(Particles[i].Data.ElapsedTime >= Particles[i].Data.Duration)
            {
                RemoveQuery.Add(i);
                continue;
            }

            if (Particles[i].DestroyWhenNotVisible
                && !Particles[i].IsDestroyed
                && !Globals.GetVisibleRenderTargetBounds().Contains(Particles[i].Data.Position))
            {
                RemoveQuery.Add(i);
            }
        }

        if (RemoveQuery.Count == 0) return;

        RemoveQuery.Sort();
        RemoveQuery.Reverse();

        foreach (int i in RemoveQuery)
        {
            if (!Particles[i].IsDestroyed)
                Particles[i].Destroy();

            Particles.RemoveAt(i);
        }

        RemoveQuery.Clear();
    }

    public static void Draw()
    {
        foreach (var particle in Particles)
        {
            if(particle.IsDestroyed)
                continue;
            
            if(particle.Data.Texture == null)
                continue;
            
            Globals.SpriteBatch.Draw(
                particle.Data.Texture,
                particle.Data.Position,
                null, // Use full texture
                particle.Data.Color,
                particle.Data.Rotation,
                new Vector2(particle.Data.Texture.Width / 2f, particle.Data.Texture.Height / 2f),
                particle.Data.Scale,
                particle.Data.Effects,
                particle.Data.LayerDepth
            );
        }
    }
}