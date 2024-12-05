using FastConsole;
namespace RLTools;

class Program
{
    static void Main(string[] args)
    {
        var a = new ColoredString("Albicla ", ConsoleColor.Red, ConsoleColor.Yellow);
        var b = new ColoredString("is excellent!", ConsoleColor.Blue, ConsoleColor.Magenta);
        ColoredString c = a + b;
        Console.ReadKey();
    }
}