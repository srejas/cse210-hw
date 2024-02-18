public class Cone : Shape
{
    private string _radius;
    private string _height;
    private string _pi;

    public Cone() : base()
    {
        _radius = "r";
        _height = "h";
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
            return $"{_volume}={_pi}{_radius}^2{_height}/3";
        }
    }
}