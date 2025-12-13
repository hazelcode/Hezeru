using System.Drawing;
using KeplerEngine.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KeplerEngine.GUI;

public class TextureButton : BaseButton
{
    private TextureAtlas _textureAtlas;
    private SpriteFont _textFont;

    public TextureButton(string text, Texture2D texture, Size buttonSize, SpriteFont textFont) : base(text)
    {
        _textureAtlas = new TextureAtlas(texture, buttonSize.Width, buttonSize.Height, 1, 3);
        _textFont = textFont;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        throw new System.NotImplementedException();
    }
}