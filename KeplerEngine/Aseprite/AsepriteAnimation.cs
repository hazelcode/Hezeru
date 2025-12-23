using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KeplerEngine.Aseprite;

public class AsepriteAnimation
{
    private AnimationData _data;

    private Rectangle _sourceRect;

    public Rectangle DestRect = Rectangle.Empty;

    private List<Frame> _currentAnimation = [];

    private Texture2D _texture;

    private double _currentDuration = 0;

    public double Scale = 1;

    private int _currentFrameNumber = 0;

    public AsepriteAnimation(AnimationData data, Texture2D texture)
    {
        _data = data;
        _texture = texture;
    }

    public void PrepareAnimationTag(string tag)
    {
        _currentAnimation = _data.Frames
          .Where((f) => f.FileName.Contains(tag))
          .ToList();

        if (_currentAnimation.Count == 0)
        {
            throw new Exception($"The tag \"{tag}\" doesn't exist in the data of the animation");
        }
    }

    public void ChangeDestinationRectangleReference(ref Rectangle destRect)
    {
        DestRect = destRect;
    }

    public SourceSize GetCurrentFrameSize()
    {
        return _currentAnimation[_currentFrameNumber].SourceSize;
    }

    private Rectangle CalculateSourceRectangle()
    {
        int x = _currentAnimation[_currentFrameNumber].FrameBounds.X;
        int y = _currentAnimation[_currentFrameNumber].FrameBounds.Y;
        int width = _currentAnimation[_currentFrameNumber].FrameBounds.Width;
        int height = _currentAnimation[_currentFrameNumber].FrameBounds.Height;

        return new Rectangle(x, y, width, height);
    }

    public void Update()
    {
        _currentDuration += Globals.DrawTime.ElapsedGameTime.TotalMilliseconds;

        if (_currentDuration > _currentAnimation[_currentFrameNumber].Duration)
        {
            _currentFrameNumber++;
            if (_currentFrameNumber >= _currentAnimation.Count)
            {
                _currentFrameNumber = 0;
            }

            _currentDuration = 0;
        }

        _sourceRect = CalculateSourceRectangle();
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, DestRect, _sourceRect, Color.White);
    }
}
