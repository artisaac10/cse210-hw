using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(
        string name,
        string description,
        string points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        string checkbox;

        if (_isComplete)
        {
            checkbox = "[X]";
        }
        else
        {
            checkbox = "[ ]";
        }

        return $"{checkbox} {GetName()} - {GetDescription()}";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{_isComplete}";
    }
}