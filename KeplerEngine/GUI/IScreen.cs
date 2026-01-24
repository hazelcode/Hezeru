using Microsoft.Xna.Framework;

namespace KeplerEngine;

public interface IScreen
{
    public void Open();

    public void Close();
    
    public void Update(GameTime gameTime);

    public void Draw(GameTime gameTime);
}