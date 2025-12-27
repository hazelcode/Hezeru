using System;

namespace KeplerEngine.CSV;

public class CSVParser
{
    public static TEnum[,] Parse<TEnum>(string[] csvLines, bool returnEmptyIfFail = false) where TEnum : unmanaged, Enum
    {
        if (csvLines.Length == 0 || csvLines[0].Length == 0)
        {
            if (returnEmptyIfFail)
                return new TEnum[0, 0];

            throw new Exception("CSV has no rows or columns to parse.");
        }

        string[] firstRow = csvLines[0].Split(',');
        int width = firstRow.Length;
        int height = csvLines.Length;

        var map = new TEnum[width, height];

        for (int y = 0; y < height; y++)
        {
            string[] cells = csvLines[y].Split(',');
            if (cells.Length != width)
            {
                throw new Exception($"CSV row {y} has inconsistent column count.");
            }

            for (int x = 0; x < width; x++)
            {
                int tileId = int.Parse(cells[x].Trim());

                map[x, y] = (TEnum)Enum.ToObject(typeof(TEnum), tileId);
            }
        }

        return map;
    }
}
