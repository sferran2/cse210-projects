using System;
using System.Collections.Generic;
using System.IO;
using GoalGetter;
using System.Threading;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private Prize _prize; 

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void DisplayWelcome()
    {
        Console.WriteLine();
        Console.WriteLine("Welcome to GoalGetter!");
        Console.WriteLine();
        Console.WriteLine("Let me show you how it works:");
        Console.WriteLine();
        Console.WriteLine("1. Set your prize! Sometimes getting things done is difficult,\nbut if you think about the reward, it’s easier to stay motivated.\nAnd who better to decide what that prize should be than you?\nMaybe it's dinner at that restaurant you've always wanted to try\nbut never found a good reason to splurge on,\nor that piece of clothing you've been wishing for\nthe perfect gift to reward yourself.");
        Console.WriteLine();
        Console.WriteLine("2. Choose your goals! They can be simple ones, long-term (eternal) goals, \nor tasks you want to accomplish a certain number of times");
        Console.WriteLine();
        Console.WriteLine("3. Get to work! Take action, track your progress, and earn those points!");
        Console.WriteLine();
        Console.Write("Are you ready to make it happen? Press Enter when you're ready");
        Console.Write(" ");
        int dotCount = 0;
        while (true)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }

            Console.Write(".");
            dotCount++;

            if (dotCount == 5)
            {
                Thread.Sleep(500);
                Console.Write("\b\b\b\b\b     \b\b\b\b\b"); 
                dotCount = 0;
            }

            Thread.Sleep(500);
        }

        Console.WriteLine("Let’s go crush those goals!");
        Console.WriteLine();
    }

    public void DisplayPrize()
    {
        Console.WriteLine();
        Console.Write("What’s your ultimate motivation prize? ");
        string userPrize = Console.ReadLine();

        Console.WriteLine();
        Console.Write("How many points do you need to unlock it? ");
        int targetPoints = int.Parse(Console.ReadLine());

        _prize = new Prize(userPrize, targetPoints); 

        Console.WriteLine();
        Console.WriteLine($"----- Awesome! Your reward \"{_prize.GetPrize()}\" awaits at {targetPoints} points!------");  
    }

    public void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Menu Options: ");
        Console.WriteLine("1. Create a new Goal");
        Console.WriteLine("2. List of my Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. Review my prize");
        Console.WriteLine("7. Quit");
        Console.Write("Select a choice from the menu (1-6): ");
    }

    public void DisplayPlayerInfo()
    {
        
        Console.WriteLine();
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine();
    }

    public void ListGoalNames()
    {
        Console.WriteLine();
        Console.WriteLine("Your goals are:");
        Console.WriteLine();
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetInfo()}");
        }
    }

    public void NewGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string input = Console.ReadLine();

        Console.Write("Enter a name for your goal: ");
        string name = Console.ReadLine();
        Console.Write("Enter a short description for your goal: ");
        string description = Console.ReadLine();
        Console.Write("How many points do you want to earn from this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (input == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (input == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (input == "3")
        {
            Console.Write("How many times should this goal be achieved to qualify for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What bonus do you earn for reaching that number of completions? ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, 0, target, bonus));
        }
        else
        {
            Console.WriteLine("Invalid goal type selected.");
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Which goal did you complete?");
        ListGoalNames();
        Console.Write("Enter the number of the goal: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            Goal goal = _goals[index];
            goal.RecordEvent();
            _score += goal.GetPoints();

            if (goal is ChecklistGoal checklist && checklist.IsComplete())
            {
                _score += checklist.GetBonus();
            }

            if (_prize != null && _prize.IsAchieved(_score))
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("AWESOME!!! You've earned enough points to unlock your prize!");
                Console.WriteLine();
                _prize.ShowPrize();
                Console.ResetColor();
            }
            else if (_prize != null)
            {
                int remaining = _prize.GetThreshold() - _score;
                if (remaining > 0)
                {
                    Console.WriteLine($"Only {remaining} points to unlock your prize: {_prize.GetPrize()}!");
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.WriteLine(_score); 

            if (_prize != null)
            {
                writer.WriteLine($"Prize|{_prize.GetPrize()}|{_prize.GetThreshold()}");
            }
            else
            {
                writer.WriteLine();
            }

            foreach (var goal in _goals)
            {
                if (goal is SimpleGoal)
                {
                    writer.WriteLine($"SimpleGoal|{goal.GetShortName()}|{goal.GetDescription()}|{goal.GetPoints()}|{goal.IsComplete()}");
                }
                else if (goal is EternalGoal)
                {
                    writer.WriteLine($"EternalGoal|{goal.GetShortName()}|{goal.GetDescription()}|{goal.GetPoints()}");
                }
                else if (goal is ChecklistGoal checklist)
                {
                    writer.WriteLine($"ChecklistGoal|{checklist.GetShortName()}|{checklist.GetDescription()}|{checklist.GetPoints()}|{checklist.GetAmountComplete()}|{checklist.GetTarget()}|{checklist.GetBonus()}");
                }
            }
        }

        Console.WriteLine("Your goals have been saved to " + file);
    }
    public void LoadGoals(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("Unable to locate the file.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(file);

        _score = int.Parse(lines[0]);
        int goalStartIndex = 1;

        if (lines.Length > 1 && lines[1].StartsWith("Prize"))
        {
            string[] prizeParts = lines[1].Split("|");
            if (prizeParts.Length == 3)
            {
                string prizeName = prizeParts[1].Trim();
                int prizePoints = int.Parse(prizeParts[2].Trim());
                _prize = new Prize(prizeName, prizePoints);
            }
            goalStartIndex = 2; 
        }

        for (int i = goalStartIndex; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");
            string type = parts[0].Trim();

            if (type == "SimpleGoal")
            {
                string name = parts[1].Trim();
                string desc = parts[2].Trim();
                int points = int.Parse(parts[3].Trim());
                bool isComplete = bool.Parse(parts[4].Trim());
                var goal = new SimpleGoal(name, desc, points);
                if (isComplete)
                {
                    goal.MarkComplete(); 
                }
                _goals.Add(goal);
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(parts[1].Trim(), parts[2].Trim(), int.Parse(parts[3].Trim())));
            }
            else if (type == "ChecklistGoal")
            {
                string name = parts[1].Trim();
                string desc = parts[2].Trim();
                int points = int.Parse(parts[3].Trim());
                int amountComplete = int.Parse(parts[4].Trim());
                int target = int.Parse(parts[5].Trim());
                int bonus = int.Parse(parts[6].Trim());

                _goals.Add(new ChecklistGoal(name, desc, points, amountComplete, target, bonus));
            }
        }

        Console.WriteLine();
        Console.WriteLine("Goals loaded successfully from " + file);
        Console.WriteLine();

        if (_prize != null)
        {
            Console.WriteLine($"Your prize is \"{_prize.GetPrize()}\" — unlock it by reaching {_prize.GetThreshold()} points!");
        }
    }
    public void ShowPrize()
    {
        if (_prize != null)
        {
            Console.WriteLine($"Your prize is \"{_prize.GetPrize()}\" — unlock it by reaching {_prize.GetThreshold()} points!");
        }
        else
        {
            Console.WriteLine("You haven't set a prize yet.");
        }
    }
} 


