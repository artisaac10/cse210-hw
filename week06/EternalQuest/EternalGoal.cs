using System;

public class EternalGoal : Goal
{
    public EternalGoal(
        string name,
        string description,
        string points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        // Eternal goals never become complete.
        // Recording the event simply gives the player points.
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[∞] {GetName()} - {GetDescription()}";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{GetName()}|{GetDescription()}|{GetPoints()}";
    }
}