namespace RLTools;

public abstract class UIElement
{
    protected readonly IntVector2 origin_;
    protected readonly IntVector2 dimensions_;

    protected UIElement(IntVector2 origin, IntVector2 dimensions)
    {
        origin_ = origin;
        dimensions_ = dimensions;
    }
    public abstract CharInfo[,] GetImage();
}