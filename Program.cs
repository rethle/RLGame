using FastConsole;
namespace RLTools;

class Program
{
    static void Main(string[] args)
    {
        FConsole.Initialize("Test");
        Random rand = new Random(1281333);
        while (true)
        {
            FConsole.SetChar((short)rand.Next(0, 256), (short)rand.Next(0, 256),
                new PixelValue((ConsoleColor)rand.Next(0, 15),
                    (ConsoleColor)rand.Next(0, 15), (char)rand.Next(50, 100)));
            FConsole.DrawBuffer();
        }
    }
}