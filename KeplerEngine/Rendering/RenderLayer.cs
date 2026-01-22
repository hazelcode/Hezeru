using Microsoft.Xna.Framework;

namespace KeplerEngine.Rendering;

/// <summary>
/// The intention of this class is to separate render layers
/// such as GUI, HUD, Debug texts, Gameplay, Background or related.
/// </summary>
public abstract class RenderLayer
{
    public enum LayerRenderMode
    {
        /// <summary>
        /// Uses the Kepler Engine SpriteBatch, located in the Globals class.
        /// </summary>
        SpriteBatch,

        /// <summary>
        /// Kepler Engine will not call SpriteBatch.Begin/End automatically.
        /// The layer is rensposible for its own render pipeline.
        /// </summary>
        Manual
    }
    public byte Order { get; protected set; }
    
    public bool Enabled { get; set; } = true;

    public virtual LayerRenderMode RenderMode => LayerRenderMode.SpriteBatch;

    /// <summary>
    /// Constructs the render layer.
    /// </summary>
    /// <param name="order">The order in which the layer will be rendered. 0 is the first,
    /// increasing the order renders the layer upper.</param>
    public RenderLayer(byte order)
    {
        Order = order;
    }

    public abstract void Render(GameTime gameTime);
}