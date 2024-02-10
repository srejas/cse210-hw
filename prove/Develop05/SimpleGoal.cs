using System.Runtime.CompilerServices;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        _isComplete = true;
        return _points;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        Type goalType = typeof(SimpleGoal);
        return $"{goalType}:{_shortName}|{_description}|{_points}|{_isComplete}";
    }
}