using FastConsole;
namespace RLTools;

public class Div : TuiElement
{
    public readonly int Breadth;
    private List<TuiElement> elements_;
    private Directions split_;

    public Div(Directions split, int breadth, TuiElement? parent = null)
    {
        if (parent == null)
        {
            display_ = new char[FConsole.WindowWidth, FConsole.WindowHeight];
        }

        split_ = split;
        Breadth = breadth;
        //TBI
    }

    public override char[,] GetImage()
    {
        if (elements_.Count == 0)
            return display_;
        
        List<char[,]> images = new List<char[,]>();
        foreach (var element in elements_)
        {
            images.Add(element.GetImage());
        }

        return DisplayAssembler.Assemble(images, split_);
    }
}