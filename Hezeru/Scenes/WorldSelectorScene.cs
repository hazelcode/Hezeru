using KeplerEngine;
using KGUI = KeplerEngine.GUI;
using KeplerEngine.MemoryCaching;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Gum.Forms.Controls;
using MonoGameGum;

namespace Hezeru.Scenes;

public class WorldSelectorScene : IScene
{
    private Texture2D _background;
    private SpriteFont _consolas18Font;
    private KGUI.ElementAnchorData _selectWorldTextAnchor;
    private string selectWorldText = "Select World";
    private Rectangle _selectWorldTextRect;
    private StackPanel _worldsPanel;
    private KGUI.ElementAnchorData _backButtonAnchor;
    private Rectangle _backButtonSpace = new Rectangle(0, 0, 150, 20);
    private Button _backButton;

    public void Load()
    {
        _background = (LoadingScene.LoadedResources[ResourcePaths.Textures.MainMenu.BACKGROUND] as Resource<Texture2D>).Data;
        _consolas18Font = (LoadingScene.LoadedResources[ResourcePaths.Fonts.CONSOLAS_18] as Resource<SpriteFont>).Data;
        _selectWorldTextAnchor = new KGUI.ElementAnchorData(KGUI.ElementAnchor.TopCenter, 0, 30);
        _selectWorldTextRect = new Rectangle(Point.Zero, _consolas18Font.MeasureString(selectWorldText).ToPoint());
        _backButtonAnchor = new KGUI.ElementAnchorData(KGUI.ElementAnchor.BottomLeftCorner, 5, -30);

        _worldsPanel = new StackPanel();
        _worldsPanel.AddToRoot();

        var textBox = new TextBox();
        textBox.Placeholder = "New world name...";
        textBox.Y = 25;
        textBox.Width = 250;
        
        _worldsPanel.AddChild(textBox);

        var scrollViewer = new ScrollViewer();
        scrollViewer.Width = 250;
        scrollViewer.Height = 500;

        var createBtn = new Button();
        createBtn.Text = "Create";
        createBtn.Width = 100;
        createBtn.IsEnabled = false;
        createBtn.Click += (_, _) => {
            scrollViewer.AddChild(new Button()
            {
                Text = textBox.Text,
                Width = 250,
                Height = 40,
            });
        };

        textBox.TextChanged += (_, _) =>
        {
            // Limit to 25 characters
            if (textBox.Text.Length > 25)
                textBox.Text = textBox.Text.Substring(0, 25);

            // Empty safety
            if (textBox.Text.Length == 0)
                createBtn.IsEnabled = false;
            else
                createBtn.IsEnabled = true;
        };

        _worldsPanel.AddChild(createBtn);
        _worldsPanel.AddChild(scrollViewer);

        _backButton = new Button();
        _backButton.Text = "Back";
        _backButton.Width = _backButtonSpace.Width;
        _backButton.Height = _backButtonSpace.Height;
        _backButton.Click += (_, _) =>
        {
            textBox.RemoveFromRoot();
            scrollViewer.RemoveFromRoot();
            createBtn.RemoveFromRoot();
            _worldsPanel.RemoveFromRoot();
            _backButton.RemoveFromRoot();

            Globals.SceneManager.AddScene(new MainMenuScene());
        };
        _backButton.AddToRoot();
    }

    public void Update()
    {
        _selectWorldTextAnchor.AdjustToContainer(
            Globals.GetVisibleRenderTargetBounds(),
            ref _selectWorldTextRect);

        _backButtonAnchor.AdjustToContainer(
            Globals.GetVisibleRenderTargetBounds(),
            ref _backButtonSpace
        );
        _backButton.X = _backButtonSpace.X;
        _backButton.Y = _backButtonSpace.Y;
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
