using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KeplerEngine.Graphics;

public struct Particle
{
    public Texture2D Texture { get; set; }

    public uint Duration { get; set; }

    public Color Color { get; set; }

    public Vector2 Position { get; set; }

    public float Rotation { get; set; }

    public float Gravity { get; set; }
}