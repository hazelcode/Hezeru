using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace KeplerEngine.GUI;

public class Button : IElement
{
    public int X { get => _rectangle.X; }

    public int Y { get => _rectangle.Y; }
    
    private float _scale;

    private Rectangle _rectangle;

    private Texture2D _texture;

    private SpriteFont _spriteFont;

    private bool IsHovered, IsClicked, Hidden = false;
    public string Text { get; set; }

    public Color DefaultColor { get; set; } = Color.White;

    public Color HoverColor { get; set; } = Color.Gray;

    public Color ClickColor { get; set; } = Color.DarkGray;

    public Color TextColor { get; set; } = Color.Black;

    public Action OnClick { get; set; } = () => { };
    
    public Action OnRelease { get; set; } = () => { };

    public ElementAnchorData AnchorData { get; set; }
    
    public Button(Texture2D texture, ElementAnchorData anchorData, string text, SpriteFont font, float scale = 1)
    {
        _rectangle = new Rectangle(0, 0, (int)(texture.Width * scale), (int)(texture.Height * scale));
        _texture = texture;
        _spriteFont = font;
        AnchorData = anchorData;
        Text = text;
        _scale = scale;

        Globals.Touch.OnTap += (e) =>
        {
            if (_rectangle.Contains(e.Pos))
            {
                IsClicked = true;
                OnClick();
                IsClicked = false;
            }
        };
    }

    public Button(
        Texture2D texture, ElementAnchorData anchorData, string text, SpriteFont font,
        Color defaultColor, Color hoverColor, Color clickColor, Color textColor, int scale = 1)
    {
        _rectangle = new Rectangle(0, 0, texture.Width * scale, texture.Height * scale);
        _texture = texture;
        _spriteFont = font;
        AnchorData = anchorData;
        Text = text;

        DefaultColor = defaultColor;
        HoverColor = hoverColor;
        ClickColor = clickColor;
        TextColor = textColor;
        
        
        Globals.Touch.OnMove += (e) =>
        {
            if(Globals.Touch.TouchedOver(_rectangle) && Globals.Touch.FingerTravelFinished) 
            {
                // IsHovered = true;
            }
        };

        Globals.Touch.OnTap += (e) =>
        {
            if(Globals.Touch.TouchedOver(_rectangle))
            {
                IsClicked = true;
                OnClick();
            }
        };
        
        Globals.Touch.OnTapRelease += (e) =>
        {
            if(Globals.Touch.TouchedOver(_rectangle)) 
            {
                IsClicked = false;
                OnRelease();
            }
        };
    }

    public void Draw()
    {
        if (Hidden)
            return;

        #region Draw Button
        if (IsHovered && !IsClicked) {
            Globals.SpriteBatch.Draw(_texture, _rectangle, HoverColor);
        }
        else if(IsClicked)
        {
            Globals.SpriteBatch.Draw(_texture, _rectangle, ClickColor);
        }
        else
        {
            Globals.SpriteBatch.Draw(_texture, _rectangle, DefaultColor);
        }
        #endregion
        #region Draw button text
        Vector2 textSize = _spriteFont.MeasureString(Text); // the size of the text with this font
        float scaledTextX = textSize.X * _scale;
        float scaledTextY = textSize.Y * _scale;
        textSize.X = scaledTextX;
        textSize.Y = scaledTextY;

        float drawX = _rectangle.X + (_rectangle.Width / 2) - (textSize.X / 2);
        float drawY = _rectangle.Y + (textSize.Y / 2);
        Globals.SpriteBatch.End();
        Globals.SpriteBatch.Begin(samplerState: SamplerState.PointWrap);
        Globals.SpriteBatch.DrawString(_spriteFont, Text, new Vector2(drawX, drawY), Color.White, 0f, Vector2.Zero, _scale, SpriteEffects.None, 0f);
        Globals.SpriteBatch.End();
        Globals.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
        #endregion

    }

    public void Update()
    {
        AnchorData.AdjustToContainer(Globals.RenderTarget.Bounds, ref _rectangle);

        IsHovered = Globals.Mouse.IsOver(_rectangle);
        
        if(!IsHovered)
        {
            IsClicked = false;
            return;
        }

        if(Globals.Mouse.LeftButtonPressed)
        {
            IsClicked = true;
            OnClick();
        }
        
        if(IsClicked && !Globals.Mouse.LeftButtonPressed && !Globals.Mouse.RightButtonPressed) 
        {
            IsClicked = false;
            OnRelease();
        }
    }
}