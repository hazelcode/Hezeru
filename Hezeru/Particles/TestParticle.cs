using KeplerEngine;
using KeplerEngine.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hezeru.Particles;

public class TestParticle : Particle
{
    public Texture2D CurrentTexture;
    private static readonly ParticleData DefaultData = new()
    {
        Color = Color.White,
        Duration = 5000, // 5s
        Gravity = new Vector2(0.0f, 3.0f),
        LayerDepth = 1.0f,
        Position = new Vector2(0.0f, 0.0f),
        Rotation = 0.0f,
        Scale = new Vector2(4.0f, 4.0f)
    };
    public TestParticle(string particleName) : base(particleName, DefaultData)
    {
    }

    public override void Update(GameTime gameTime)
    {
        Data.Texture = CurrentTexture;

        Data.Position = new()
        {
            X = (float)(Data.Position.X + (Data.Gravity.X * gameTime.ElapsedGameTime.TotalMilliseconds)),
            Y = (float)(Data.Position.Y + (Data.Gravity.Y * gameTime.ElapsedGameTime.TotalMilliseconds))
        };
        Data.Rotation += 1 * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }
}