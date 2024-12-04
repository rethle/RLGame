namespace RLTools;

public struct CharInfo
{
    public char Character;
    public ConsoleColor Foreground;
    public ConsoleColor Background;

    public CharInfo()
    {
        Character = ' ';
        Foreground = ConsoleColor.White;
        Background = ConsoleColor.Black;
    }

    public CharInfo(char character, ConsoleColor foreground, ConsoleColor background)
    {
        Character = character;
        Foreground = foreground;
        Background = background;
    }
}