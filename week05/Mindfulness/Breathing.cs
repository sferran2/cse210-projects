using System;
using System.Threading;

public class Breathing : Activity
{
    private string _explanation;

    public Breathing()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.",
            0
        )
    {
        _explanation = "Follow the prompts to breathe slowly, and deeply.\nBreath in, Hold and Breath Out";
    }

    private void DisplayExplanation()
    {
        Console.WriteLine(_explanation);
    }

    public void Run()
    {
        DisplayWelcomeMsg();
        Console.WriteLine();
        DisplayExplanation();

        Console.WriteLine();
        Console.WriteLine("Get ready to begin...");
        Console.WriteLine();
        DisplayDownTime(5);

        int breathTime = _time;
        int stepTime = 4;

        if (breathTime > 0)
        {
            ShowPromptWithCountdown("Breathe in...", Math.Min(stepTime, breathTime));
            breathTime -= stepTime;
        }

        if (breathTime > 0)
        {
            ShowPromptWithCountdown("Hold", Math.Min(stepTime, breathTime));
            breathTime -= stepTime;
        }

        if (breathTime > 0)
        {
            ShowPromptWithCountdown("Breathe out...", Math.Min(stepTime, breathTime));
            breathTime -= stepTime;
        }

        Console.WriteLine();
        DisplayFinalMsg();
    }

    private void ShowPromptWithCountdown(string message, int seconds)
    {
        for (int i = 1; i <= seconds; i++)
        {
            string fullLine = $"{message} {i}";
            Console.Write(fullLine);
            Thread.Sleep(1000);

            Console.Write(new string('\b', fullLine.Length));
            Console.Write(new string(' ', fullLine.Length));
            Console.Write(new string('\b', fullLine.Length));
        }
    }
    private void ClearCurrentConsoleLine()
    {
        int currentPositionCursor = Console.CursorTop;
        Console.SetCursorPosition(0, currentPositionCursor);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentPositionCursor);
    }
}

