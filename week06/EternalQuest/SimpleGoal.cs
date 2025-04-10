using System; 

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal (string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
        _isComplete = false;
    }
    public override void RecordEvent()
    {
        if (! _isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"Congratulations! You earned {_points} points.");
        }
        else
        {
            Console.WriteLine($"This goal has already beel complete. Work on a new goal!");
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetInfo()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {_shortName} ({_description})"; 
    }

    public void MarkComplete()
    {
        _isComplete = true;
    }

}