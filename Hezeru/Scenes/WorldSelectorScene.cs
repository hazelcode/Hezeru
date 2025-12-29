using KeplerEngine;
using KeplerEngine.GUI;
using KeplerEngine.MemoryCaching;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hezeru.Scenes;

public class WorldSelectorScene : IScene
{
    private Texture2D _background;
    private SpriteFont _consolas18Font;
    private ElementAnchorData _selectWorldTextAnchor;
    private string selectWorldText = "Select World";
    private Rectangle _selectWorldTextRect;

    public void Load()
    {
        _background = (LoadingScene.LoadedResources[TexturePaths.MAIN_MENU_BACKGROUND] as TextureResource).Texture;
        _consolas18Font = (LoadingScene.LoadedResources["Fonts/Consolas-18"] as SpriteFontResource).Font;
        _selectWorldTextAnchor = new ElementAnchorData(ElementAnchor.TopCenter, 0, 30);
        _selectWorldTextRect = new Rectangle(Point.Zero, _consolas18Font.MeasureString(selectWorldText).ToPoint());
    }

    public void Update()
    {
        _selectWorldTextAnchor.AdjustToContainer(
            Globals.GetVisibleRenderTargetBounds(),
            ref _selectWorldTextRect);
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_background,
            Globals.GetVisibleRenderTargetBounds(),
            Color.White);

        Globals.SpriteBatch.DrawString(_consolas18Font,
            selectWorldText,
            _selectWorldTextRect.Location.ToVector2(),
            Color.DarkGreen);
    }
}
