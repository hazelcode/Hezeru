using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KeplerEngine.Graphics;

public class ColoredSprite : Sprite
{
    public Color color;
    public ColoredSprite(Texture2D texture, Vector2 position, Color color) : base(texture, position)
    {
        this.color = color;
    }
}