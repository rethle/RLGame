using FastConsole;
namespace RLTools;

public class Div : UIElement
{
    public readonly int Breadth;
    private int width_;
    private int height_;
    
    private List<UIElement> elements_;
    private Directions split_;

    public Div(Directions split, int width, int height)
    {
        split_ = split;
        width_ = width;
        height_ = height;
        if (split == Directions.Horizontal)
            Breadth = width;
        else if (split == Directions.Vertical)
            Breadth = height;
        else
            throw new ArgumentException("Split is an invalid value");
        elements_ = new List<UIElement>();
    }

    public CharInfo[,] GetImage()
    {
        if (elements_.Count == 0)
            return new CharInfo[width_, height_];
        
        List<CharInfo[,]> images = new List<CharInfo[,]>();
        foreach (var element in elements_)
        {
            images.Add(element.GetImage());
        }

        return DisplayAssembler.Assemble(images, split_);
    }
}