using System.Collections.Generic;
using System.Linq;
using KeplerEngine.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KeplerEngine;

public class YSortCamera
{
    public Vector2 position;

    public YSortCamera(Vector2 position)
    {
        this.position = position;
    }

    public void Follow(Rectangle target, Vector2 screenSize)
    {
        position = new Vector2(
            -target.X + (screenSize.X / 2 - target.Width / 2),
            -target.Y + (screenSize.Y / 2 - target.Height / 2)
        );
    }

    public void Draw(SpriteBatch spriteBatch, List<Sprite> sprites)
    {
        List<Sprite> sortedSprites = sprites.OrderBy((obj) => obj.Rect.Bottom).ToList();

        foreach (Sprite sprite in sortedSprites)
        {
            sprite.Draw(position);
        }
    }
}