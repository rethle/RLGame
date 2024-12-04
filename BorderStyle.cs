namespace RLTools;

public struct BorderStyle
{
        public readonly char Horizontal, Vertical;
        public readonly char TopLeft, TopRight, BottomLeft, BottomRight;

        public BorderStyle(char horizontal, char vertical, char corner)
        {
            Horizontal = horizontal;
            Vertical = vertical;
            TopLeft = TopRight = BottomLeft = BottomRight = corner;
        }

        public BorderStyle(char horizontal, char vertical, char topLeft, char topRight, char bottomLeft, char bottomRight)
        {
            Horizontal = horizontal;
            Vertical = vertical;
            TopLeft = topLeft;
            TopRight = topRight;
            BottomLeft = bottomLeft;
            BottomRight = bottomRight;
        }
}