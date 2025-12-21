using System;
using System.Collections.Generic;
using KeplerEngine.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KeplerEngine;

class Player2D : Sprite
{
    public readonly List<Sprite> CollisionGroup;
    float Speed = 200f;

    public Player2D(Texture2D texture, Vector2 position, List<Sprite> collisionGroup) : base(texture, position)
    {
        this.CollisionGroup = collisionGroup;
    }

    public override void Update()
    {
        base.Update();

        Vector2 movement = Vector2.Zero;

        #region X movement
        if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            movement.X -= 1;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            movement.X += 1;
        }
        if (movement.X != 0)
            movement.X *= 1f / MathF.Sqrt(movement.X * movement.X + movement.Y * movement.Y);

        Position.X += movement.X * Speed * (float)Globals.UpdateTime.ElapsedGameTime.TotalSeconds;

        foreach (var sprite in CollisionGroup)
        {
            if (sprite != this && sprite.Rect.Intersects(Rect))
            {
                Position.X -= movement.X * Speed * (float)Globals.UpdateTime.ElapsedGameTime.TotalSeconds;
            }
        }

        #endregion
        #region Y movement

        if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            movement.Y -= 1;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            movement.Y += 1;
        }
        if (movement.Y != 0)
            movement.Y *= 1f / MathF.Sqrt(movement.X * movement.X + movement.Y * movement.Y);

        Position.Y += movement.Y * Speed * (float)Globals.UpdateTime.ElapsedGameTime.TotalSeconds;

        foreach (var sprite in CollisionGroup)
        {
            if (sprite != this && sprite.Rect.Intersects(Rect))
            {
                Position.Y -= movement.Y * Speed * (float)Globals.UpdateTime.ElapsedGameTime.TotalSeconds;
            }
        }
        #endregion
    }
}
