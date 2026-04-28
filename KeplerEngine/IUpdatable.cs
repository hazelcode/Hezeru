using Microsoft.Xna.Framework;

namespace KeplerEngine;

public interface IUpdatable
{
    /// <summary>
    /// The engine will ignore this updatable,
    /// will not be processed if set to true
    /// </summary>
    bool BlockUpdate { get; set; }

    void Update(GameTime gameTime);
}