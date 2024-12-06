namespace RLTools;

public class TextBox : UIElement
{
    public required ColoredString Text { get; set; }

    public TextBox(ColoredString text, IntVector2 origin, IntVector2 dimensions) : base(origin, dimensions)
    {
        Text = text;
    }

    public override CharInfo[,] GetImage()
    {
        throw new NotImplementedException();
    }
}