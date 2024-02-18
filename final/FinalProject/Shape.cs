public abstract class Shape
{
    protected string _volume;
    private bool _isUsed;

    public Shape()
    {
        _volume = "V";
        _isUsed = false;
    }

    public void MarkUsed()
    {
        _isUsed = true;
    }

    public bool IsUsed()
    {
        return _isUsed;
    }

    public abstract string DisplayFormula();
}