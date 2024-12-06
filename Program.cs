using FastConsole;
namespace RLTools;

class Program
{
    static void Main(string[] args)
    {
        var a = new ColoredString("Albicla ", ConsoleColor.Red, ConsoleColor.Yellow);
        var b = new ColoredString("is excellent!", ConsoleColor.Blue, ConsoleColor.Magenta);
        ColoredString c = new ColoredString();
        a.Append(b).Append(c);
        Console.WriteLine(c.ToString());
        Console.ReadKey();
    }
}