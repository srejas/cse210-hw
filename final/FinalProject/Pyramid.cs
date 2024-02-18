public class Pyramid : Shape
{
    private string _length;
    private string _width;
    private string _height;

    public Pyramid() : base()
    {
        _length = "l";
        _width = "w";
        _height = "h";
    }

    public override string DisplayFormula()
    {
        if (IsUsed())
        {
            return "X";
        }
        else
        {
            return $"{_volume}=({_length}{_width}{_height})/3";
        }
    }
}