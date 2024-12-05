using System.Runtime.CompilerServices;

namespace RLTools;

public class ColoredString
{
    CharInfo[] text_;

    public ColoredString()
    {
        text_ = new CharInfo[0];
    }

    public ColoredString(ColoredString coloredString)
    {
        coloredString.text_.CopyTo(text_, 0);
    }
    
    public ColoredString(string text, ConsoleColor foreground, ConsoleColor background)
    {
        text_ = new CharInfo[text.Length];
        for (int i = 0; i < text.Length; i++)
        {
            text_[i] = new CharInfo(text[i], foreground, background);
        }
    }

    private ColoredString(int length)
    {
        text_ = new CharInfo[length];
    }

    private List<ColoredString> Split(ColoredString colStr, char delimiter)
    {
        var colStrings = new List<ColoredString>();
        ColoredString currentColStr = new ColoredString();
        for (int i = 0; i < colStr.text_.Length; i++)
        {
            if (colStr.text_[i].Character == delimiter && !currentColStr.IsEmpty())
            {
                colStrings.Append(currentColStr);
                currentColStr = new ColoredString();
                continue;
            }
            if(colStr.text_[i].Character == delimiter)
                continue;
            currentColStr += colStr.text_[i];
        }

        return colStrings;
    }

    public bool IsEmpty()
    {
        return text_.Length == 0;
    }
    
    public static ColoredString operator +(ColoredString colStr1, ColoredString colStr2)
    {
        ColoredString sum = new ColoredString(colStr1.text_.Length + colStr2.text_.Length);
        Array.Copy(colStr1.text_, sum.text_, colStr1.text_.Length);
        Array.Copy(colStr2.text_, 0, sum.text_, colStr1.text_.Length, colStr2.text_.Length);
        return sum;
    }

    public static ColoredString operator +(ColoredString colStr, CharInfo colChar)
    {
        ColoredString sum = new ColoredString(colStr);
        sum.text_.Append(colChar);
        return sum;
    }
}