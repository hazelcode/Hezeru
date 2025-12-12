using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KeplerEngine.Graphics;

public class TextureAtlas
{
    public Texture2D Texture { get; }
    private List<Point> _tilesCoords { get; }
    private int _tileWidth, _tileHeight, _columns, _rows;

    public TextureAtlas(Texture2D texture, int tileWidth, int tileHeight, int columns, int rows)
    {
        Texture = texture;
        _tileWidth = tileWidth;
        _tileHeight = tileHeight;
        _tilesCoords = [];
        _columns = columns;
        _rows = rows;

        for (int i = 0; i < _rows; i++)
        {
            for(int j = 0; j < _columns; j++) 
            {
                _tilesCoords.Add(new Point(j * _tileWidth, i * _tileHeight));
            }
        }
    }

    public Rectangle GetTileBounds(int tileNumber)
    {
        return new Rectangle(_tilesCoords[tileNumber], new Point(_tileWidth, _tileHeight));
    }
}