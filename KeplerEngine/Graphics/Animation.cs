using Microsoft.Xna.Framework;

namespace KeplerEngine.Graphics;

public class Animation
{
    int numFrames, numColumns, counter, activeFrame, interval, rowPos, colPos;
    public int OffsetX { get; set; } = 0;
    public int OffsetY { get; set; } = 0;
    readonly Vector2 size;

    public bool IsPaused { get; set; } = false;

    public Animation(int numFrames, int numColumns, Vector2 size, int interval = 30)
    {
        this.numFrames = numFrames;
        this.numColumns = numColumns;
        this.size = size;
        this.interval = interval;

        counter = 0;
        activeFrame = 0;

        rowPos = 0;
        colPos = 0;
    }

    public void Pause()
    {
        IsPaused = true;
    }

    public void Resume()
    {
        IsPaused = false;
    }

    public void TogglePause()
    {
        IsPaused = !IsPaused;
    }

    public void Update()
    {
        if (IsPaused)
            return;

        counter++;
        if (counter > interval)
        {
            counter = 0;
            NextFrame();
        }
    }

    private void NextFrame()
    {
        activeFrame++;
        colPos++;

        if (activeFrame >= numFrames)
        {
            ResetAnimation();
        }

        if (colPos >= numColumns)
        {
            colPos = 0;
            rowPos++;
        }
    }

    public void ResetAnimation()
    {
        activeFrame = 0;
        colPos = 0;
        rowPos = 0;
    }

    public Rectangle GetFrame()
    {
        return new Rectangle(
            (colPos * (int)size.X) + OffsetX,
            (rowPos * (int)size.Y) + OffsetY,
            (int)size.X,
            (int)size.Y
        );
    }
}