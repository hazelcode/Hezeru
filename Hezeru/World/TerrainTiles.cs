namespace Hezeru.World;

public enum TerrainTiles : sbyte
{
    None = -1,
    #region Grassy and dirty tiles
    Grass = 0,
    GrassWithFlowers = 1,
    DirtDownSide = 2,
    DirtTopRightCorner = 3,
    DirtUpSide = 4,
    DirtTopLeftCorner = 5,
    DirtLeftSide = 6,
    DirtRightSide = 7,
    DirtBottomLeftCorner = 8,
    DirtBottomRightCorner = 9,
    Dirt = 10,
    DirtPoint = 11,
    #endregion
    #region Paths
    DirtPathTraceTopLeftCorner = 12,
    DirtPathTraceHorizontal = 13,
    DirtPathTraceTopRightCorner = 14,
    DirtPathTraceVertical = 15,
    DirtPathTraceBottomLeftCorner = 16,
    DirtPathTraceBottomRightCorner = 17,
    DirtPathTraceCenter = 18,
    DirtPathTraceLeftUnion = 19,
    DirtPathTraceUpperUnion = 20,
    DirtPathTraceRightUnion = 21,
    DirtPathTraceLowerUnion = 22
    #endregion
}
