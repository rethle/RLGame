using FastConsole;
namespace RLTools;

public class Div : UIElement
{
    private List<UIElement> elements_;
    private Directions split_;

    public Div(Directions split, IntVector2 origin, IntVector2 dimensions) : base(origin, dimensions)
    {
        split_ = split;
        elements_ = new List<UIElement>();
    }

    public override CharInfo[,] GetImage()
    {
        if (elements_.Count == 0)
            return new CharInfo[dimensions_.X, dimensions_.Y];
        
        List<CharInfo[,]> images = new List<CharInfo[,]>();
        foreach (var element in elements_)
        {
            images.Add(element.GetImage());
        }

        return ImageAssembler.Assemble(images, split_);
    }
}