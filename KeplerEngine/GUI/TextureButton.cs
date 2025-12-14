using System.Drawing;
using KeplerEngine.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace KeplerEngine.GUI;

public class TextureButton : BaseButton
{
    private TextureAtlas _textureAtlas;
    private byte _state;

    public TextureButton(Texture2D texture, Size buttonTextureSize, Size buttonSize) : base("")
    {
        _textureAtlas = new TextureAtlas(texture, buttonTextureSize.Width, buttonTextureSize.Height, 1, 3);
        Bounds = new Rectangle(0, 0, buttonSize.Width, buttonSize.Height);
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        if (IsClicked)
            _state = 2;
        else if (IsHovered)
            _state = 1;
        else
            _state = 0;
    }

    public override void Draw(GameTime gameTime)
    {
        Globals.SpriteBatch.Draw(
            _textureAtlas.Texture,
            Bounds,
            _textureAtlas.GetTileBounds(_state),
            Color.White
        );
    }
}