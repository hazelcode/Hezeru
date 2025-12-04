using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KeplerEngine.Graphics;

public class Sprite
{
    public Texture2D Texture { get; private set; }
    public Vector2 Position;
    public Vector2 Origin;
    public float Rotation;
    public float Scale;
    public Color Color;
    public float LayerDepth;
    public Effect Shader;
    public Rectangle Rect { get => GetBounds(); set {} }

    public Sprite(Texture2D texture, Vector2? position = null, Effect shader = null)
    {
        Texture = texture;
        Position = position ?? Vector2.Zero;
        Rotation = 0f;
        Scale = 4f;
        Color = Color.White;
        LayerDepth = 0f;

        if (Texture != null)
            Origin = new Vector2(Texture.Width / 2f, Texture.Height / 2f);
    }

    public virtual void Update() { }

    public virtual void Draw(Vector2 cameraPosition)
    {
        if (Texture == null) return;

        Vector2 drawPosition = Position + cameraPosition;

        if(Shader != null)
        {
            Globals.SpriteBatch.End();
            Globals.SpriteBatch.Begin(samplerState: SamplerState.PointClamp, effect: Shader);
            Globals.SpriteBatch.Draw(Texture, drawPosition, null, Color, Rotation, Origin, Scale, SpriteEffects.None, LayerDepth);
            Globals.SpriteBatch.End();
            Globals.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
        } else
        {
            Globals.SpriteBatch.Draw(Texture, drawPosition, null, Color, Rotation, Origin, Scale, SpriteEffects.None, LayerDepth);
        }
        
    }

    public Rectangle GetBounds()
    {
        return new Rectangle(
            (int)(Position.X - Origin.X * Scale),
            (int)(Position.Y - Origin.Y * Scale),
            (int)(Texture.Width * Scale),
            (int)(Texture.Height * Scale)
        );
    }
}
