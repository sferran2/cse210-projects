using System; 

namespace GoalGetter
{
    public class EternalGoal : Goal
    {

        public EternalGoal (string shortName, string description, int points)
        {
            _shortName = shortName;
            _description = description;
            _points = points;
        }
        public override void RecordEvent()
        {
            Console.WriteLine($"Congratulations! You earned {_points} points.");
        }


        public override bool IsComplete()
        {
            return false;
        }

        public override string GetInfo()
        {
            return $"[∞]{_shortName} ({_description})"; 
        }

        public override string GetDescription()
        {
            return _description;
        }

    }
}