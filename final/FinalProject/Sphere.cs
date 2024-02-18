public class Sphere : Shape
{
    private string _radius;
    private string _pi;

    public Sphere() : base()
    {
        _radius = "r";
        _pi = "π";
    }

    public override string DisplayFormula()
    {
        if (IsUsed())
        {
            return "X";
        }
        else
        {
            return $"{_volume}=4/3{_pi}{_radius}^3";
        }
    }
}