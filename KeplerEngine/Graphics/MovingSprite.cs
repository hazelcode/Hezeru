using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KeplerEngine.Graphics;

public class MovingSprite : Sprite
{
    private float speed;
    public MovingSprite(Texture2D texture, Vector2 position, float speed) : base(texture, position)
    {
        this.speed = speed;
    }

    public override void Update()
    {
        base.Update();
        Position.X += speed * (float)Globals.UpdateTime.ElapsedGameTime.TotalSeconds;
    }
}