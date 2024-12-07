using System.Text;

namespace RLTools;

public class ColoredString
{
    private const ConsoleColor DefaultForeground = ConsoleColor.White;
    private const ConsoleColor DefaultBackground = ConsoleColor.Black;
    public int Length => text_.Count;
    
    private List<CharInfo> text_ = new List<CharInfo>();

    public ColoredString(){}
    public ColoredString(ColoredString coloredString)
    {
        
    }
    public ColoredString(string text, ConsoleColor foreground, ConsoleColor background)
    {
        foreach (var ch in text)
        {
            text_.Add(new CharInfo(ch, foreground, background));
        }
    }

    //For purely debug reasons
    public override string ToString()
    {
        StringBuilder strBuilder = new StringBuilder(text_.Count);
        foreach (var charInfo in text_)
        {
            strBuilder.Append(charInfo.Character);
        }
        return strBuilder.ToString();
    }

    private List<ColoredString> Split(char delimiter)
    {
        var coloredStrings = new List<ColoredString>();
        ColoredString currentColStr = new ColoredString();
        foreach(var element in text_)
        {
            if (element.Character == delimiter && !currentColStr.IsEmpty())
            {
                coloredStrings.Add(currentColStr);
                currentColStr = new ColoredString();
                continue;
            }
            if(element.Character == delimiter)
                continue;
            currentColStr.Append(element);
        }
        coloredStrings.Add(currentColStr);
        
        return coloredStrings;
    }

    public CharInfo[] ToArray() => text_.ToArray();

    public CharInfo[,] To2DArray(char delimiter, int width)
    {
        List<ColoredString> words = Split(delimiter);
        var page = new Dictionary<int, List<ColoredString>>();
        page[0] = [];
        int charsLeftOnLine = width;
        int currentPage = 0;
        foreach (var word in words)
        {
            if(word.Length > width)
                //Need to implement word splitting
                continue;
            if (word.Length > charsLeftOnLine)
            {
                currentPage++;
                page[currentPage] = [];
                charsLeftOnLine = width;
            }
            page[currentPage].Add(word);
            charsLeftOnLine -= word.Length;
            charsLeftOnLine -= charsLeftOnLine <= 0 ? 0 : 1;
        }

        var textBlock = new CharInfo[width, page.Count];
        var cursorPosition = new IntVector2(0, 0);
        var lastCharInfo = new CharInfo(' ', ConsoleColor.White, ConsoleColor.Black);
        foreach (var line in page.Values)
        {
            foreach (var word in line)
            {
                foreach (var charInfo in word.ToArray())
                {
                    textBlock[cursorPosition.X, cursorPosition.Y] = charInfo;
                    cursorPosition.X++;
                    lastCharInfo = charInfo;
                }

                if(word == line.Last())
                {
                    while (width - cursorPosition.X > 0)
                    {
                        textBlock[cursorPosition.X, cursorPosition.Y] = new CharInfo(' ',
                            lastCharInfo.Foreground, lastCharInfo.Background);
                        cursorPosition.X++;
                    }
                    continue;
                }
            
                textBlock[cursorPosition.X, cursorPosition.Y] = new CharInfo(delimiter,
                    lastCharInfo.Foreground, lastCharInfo.Background);
                cursorPosition.X++;
            }
            cursorPosition.X = 0;
            cursorPosition.Y++;
        }

        return textBlock;
    }

    public bool IsEmpty() => text_.Count == 0;
    public ColoredString Append(ColoredString coloredString)
    {
        text_.AddRange(coloredString.text_);
        return this;
    }
    public ColoredString Append(CharInfo charInfo)
    {
        text_.Add(charInfo);
        return this;
    }
    public ColoredString Append(string text, ConsoleColor foreground, ConsoleColor background)
    {
        var coloredText = new List<CharInfo>(text.Length);
        foreach (var ch in text)
        {
            coloredText.Add(new CharInfo(ch, foreground, background));
        }
        text_.AddRange(coloredText);
        return this;
    }

    public ColoredString Append(string text)
    {
        var foreground = IsEmpty() ? DefaultForeground : text_.Last().Foreground;
        var background = IsEmpty() ? DefaultBackground : text_.Last().Background;
        return Append(text, foreground, background);
    }
}