using Microsoft.Xna.Framework;

namespace KeplerEngine.GUI;

public interface IElement
{
    public int X { get; }

    public int Y { get; }

    ElementAnchorData AnchorData { get; set; }

    public void Update(GameTime gameTime);

    public void Draw(GameTime gameTime);
}