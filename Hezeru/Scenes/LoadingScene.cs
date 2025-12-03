using KeplerEngine;
using KeplerEngine.GUI;
using KeplerEngine.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Hezeru.Scenes;

public class LoadingScene : IScene, IDisposable
{
    private Texture2D _loadingWheelTex;
    private Animation _loadingWheelAnim;
    private ElementAnchorData _wheelAnchorData;
    private Rectangle _wheelPositionRect;

    public void Load()
    {
        _loadingWheelTex = Globals.Content.Load<Texture2D>("Animations/LoadingWheel");
        _loadingWheelAnim = new Animation(4, 4, new Vector2(16, 16), 10);
        _wheelAnchorData = new ElementAnchorData(ElementAnchor.Center);
        _wheelPositionRect = new(0, 0, 64, 64);
    }

    public void Update()
    {
        _loadingWheelAnim.Update();
        // Use the visible portion of the render target so anchors follow the visible area
        var visible = Globals.VisibleRenderTargetBounds;
        if (visible == Rectangle.Empty)
            visible = Globals.RenderTarget.Bounds;
        _wheelAnchorData.AdjustToContainer(visible, ref _wheelPositionRect);
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(
            _loadingWheelTex,
            _wheelPositionRect,
            _loadingWheelAnim.GetFrame(),
            Color.White);
    }

    public void Dispose()
    {
        // Free heap
        _loadingWheelTex = null;
        _loadingWheelAnim = null;
    }
}