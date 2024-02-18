public class Cube : Shape
{
    private string _edge;

    public Cube() : base()
    {
        _edge = "a";
    }
    
    public override string DisplayFormula()
    {
        if (IsUsed())
        {
            return "X";
        }
        else
        {
            return $"{_volume}={_edge}^3";
        }
    }
}