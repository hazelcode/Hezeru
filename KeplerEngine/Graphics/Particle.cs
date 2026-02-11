using Microsoft.Xna.Framework;

namespace KeplerEngine.Graphics;

public class Particle
{
    public string Name { get; set; }

    public ParticleData Data { get; set; }

    public bool IsDestroyed { get; internal set; } = false;

    public bool DestroyWhenNotVisible { get; set; } = true;

    public Particle(string particleName, ParticleData particleData)
    {
        Name = particleName;
        Data = particleData;
    }

    public virtual void Emit()
    {
        Data.ElapsedTime = 0.0;
    }

    public virtual void Update(GameTime gameTime) {}

    public virtual void Destroy()
    {
        IsDestroyed = true;
    }
}