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

    private static List<ColoredString> Split(ColoredString coloredString, char delimiter)
    {
        var coloredStrings = new List<ColoredString>();
        ColoredString currentColStr = new ColoredString();
        foreach(var element in coloredString.text_)
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

        return coloredStrings;
    }

    public static CharInfo[,] ToCharInfoArray(ColoredString coloredString, char delimiter, int width)
    {
        List<ColoredString> words = Split(coloredString, delimiter);
        
    }

    public bool IsEmpty()
    {
        return text_.Count == 0;
    }
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