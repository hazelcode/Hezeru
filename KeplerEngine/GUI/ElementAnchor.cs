namespace KeplerEngine.GUI;

public enum ElementAnchor
{
    TopLeftCorner,
    TopCenter,
    TopRightCorner,
    LeftCenter,
    Center,
    RightCenter,
    BottomLeftCorner,
    BottomCenter,
    BottomRightCorner,
    /// <summary>
    /// Please avoid from using this anchor!!
    /// This may lead to element not adjusting to screen
    /// </summary>
    Free
}