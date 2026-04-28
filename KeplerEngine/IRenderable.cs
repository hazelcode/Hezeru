using Microsoft.Xna.Framework.Graphics;

namespace KeplerEngine;

public interface IRenderable
{
    /// <summary>
    /// The engine will ignore this renderable,
    /// will not be displayed if set to true
    /// </summary>
    bool BlockRendering { get; set; }

    void Draw(SpriteBatch spriteBatch);
}