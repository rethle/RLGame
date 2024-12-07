using FastConsole;
namespace RLTools;

class Program
{
    static void Main(string[] args)
    {
        var a = new ColoredString(
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud",
            ConsoleColor.Red, ConsoleColor.Yellow);
        var b = new ColoredString(
            " exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            ConsoleColor.Magenta, ConsoleColor.DarkGray);
        ColoredString c = new ColoredString();
        c.Append(a).Append(b);
        Console.WriteLine(c.ToString());
        var d = c.To2DArray(' ', GFG.LongestWordLength(c.ToString()) * 5);
        for (int y = 0; y < d.GetLength(1); y++)
        {
            for (int x = 0; x < d.GetLength(0); x++)
            {
                Console.ForegroundColor = d[x, y].Foreground;
                Console.BackgroundColor = d[x, y].Background;
                Console.Write(d[x, y].Character);
            }

            Console.Write('\n');
        }

        Console.ReadKey();
    }
}

static class GFG
{

    public static int LongestWordLength(string str)
    {
        int n = str.Length;
        int res = 0, curr_len = 0;
        for (int i = 0; i < n; i++)
        {

            // If current character is not
            // end of current word.
            if (str[i] != ' ')
                curr_len++;

            // If end of word is found
            else
            {
                res = Math.Max(res, curr_len);
                curr_len = 0;
            }
        }

        // We do max one more time to consider
        // last word as there won't be any space
        // after last word.
        return Math.Max(res, curr_len);
    }
}