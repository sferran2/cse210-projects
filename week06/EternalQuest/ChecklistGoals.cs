using System;

public class ChecklistGoal : Goal
{
    private int _amountComplete;
    private int _target;
    private int _bonus;
    
    public int GetAmountComplete()
    {
        return _amountComplete;
    }

    public int GetTarget()
    {
        return _target;
    }

    public int GetBonus()
    {
        return _bonus;
    }

    public ChecklistGoal(string shortName, string description, int points, int amountComplete, int target, int bonus)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
        _amountComplete = amountComplete; // allow loading with current progress
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (!IsComplete())
        {
            _amountComplete++;
            Console.WriteLine($"Good job! You've earned {_points} points.");

            if (IsComplete())
            {
                Console.WriteLine($"🎉 Bonus! You've completed the checklist and earned {_bonus} bonus points!");
            }
            Console.WriteLine($"{_shortName} — Currently completed: {_amountComplete}/{_target}");
        }
        else
        {
            Console.WriteLine("This goal is already complete!");
        }
    }

    public override bool IsComplete()
    {
        return _amountComplete >= _target;
    }

    public override string GetInfo()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_shortName} ({_description}) -- Currently completed: {_amountComplete}/{_target}";
    }

    public override string GetDescription()
    {
        return $"{_shortName} {_description} (Completed: {_amountComplete}/{_target})";
    }
}
