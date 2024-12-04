namespace RLTools;

public static class DisplayAssembler
{
    public static CharInfo[,] Assemble(List<CharInfo[,]> displays, Directions split)
    {
        if (split == Directions.Horizontal)
            return AssembleHorizontally(displays);
        if (split == Directions.Vertical)
            return AssembleVertically(displays);

        throw new ArgumentException($"Provided split is illegal ({split.ToString()})");
    }

    private static CharInfo[,] AssembleHorizontally(List<CharInfo[,]> displays)
    {
        int totalWidth = 0;
        int totalHeight = displays[0].GetLength(1); //Since the height is the same for all of them
        foreach (var display in displays)
        {
            totalWidth += display.GetLength(0);
        }

        CharInfo[,] assembledDisplay = new CharInfo[totalWidth, totalHeight];
        int displacement = 0;
        foreach (var display in displays)
        {
            for (int y = 0; y < totalHeight; y++)
            {
                for (int x = 0; x < display.GetLength(0); x++)
                {
                    assembledDisplay[x + displacement, y] = display[x, y];
                }
            }

            displacement += display.GetLength(0);
        }

        return assembledDisplay;
    }
    private static CharInfo[,] AssembleVertically(List<CharInfo[,]> displays)
    {
        int totalWidth = displays[0].GetLength(0);
        int totalHeight = 0;
        foreach (var display in displays)
        {
            totalHeight += display.GetLength(0);
        }

        CharInfo[,] assembledDisplay = new CharInfo[totalWidth, totalHeight];
        int displacement = 0;
        foreach (var display in displays)
        {
            for (int y = 0; y < display.GetLength(1); y++)
            {
                for (int x = 0; x < totalWidth; x++)
                {
                    assembledDisplay[x, y + displacement] = display[x, y];
                }
            }

            displacement += display.GetLength(1);
        }

        return assembledDisplay;
    }
}