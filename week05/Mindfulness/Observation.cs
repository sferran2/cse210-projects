//Showing Creativity and Exceeding Requirements
//Adding another kind of activity.
//Adding more meaningful animations for the breathing

using System;
using System.Threading;

public class Observation : Activity
{
    private string _explanation;
    private List<string> _observationPrompts = new List<string> 
    {
        "Look around and find something you have never noticed before.",
        "Focus on one sound you can hear right now.",
        "Observe the light or shadows around you.",
        "Notice the texture of something nearby.",
        "Observe your posture and how your body feels.",
        "Watch how something moves—like leaves, your breath, or even a clocks second hand.",
        "Notice the colors around you—how many different shades can you spot?",
        "Look closely at a familiar object as if seeing it for the first time.",
        "Observe the space between objects—notice the stillness in the room.",
    };
    
    public Observation()
        : base(
            "Observation Activity",
            "This activity will guide you to become more aware of your surroundings and grounded in the present moment.",
            0 
        )
    {
        _explanation = "Prepare to observe. Try not to judge, just notice.";
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
        DisplayDownTime(3);

        Random rand = new Random();
        int randomIndex = rand.Next(_observationPrompts.Count);
        string prompt = _observationPrompts[randomIndex];

        Console.WriteLine(prompt);

        int secondsElapsed = 0;
        while (secondsElapsed < _time)
        {
            ShowObservationDots(5);
            secondsElapsed += 5;
        }

        Console.WriteLine();
        Console.WriteLine("What did you observe or feel during this time?");
        string reflection = Console.ReadLine();
        
        DisplayFinalMsg();
    }

    private void ShowObservationDots(int seconds)
    {
        ConsoleColor[] fadeColors = {
        ConsoleColor.DarkRed,
        ConsoleColor.DarkGreen,
        ConsoleColor.DarkYellow
    };

        for (int i = 0; i < seconds; i++)
        {
            Console.ForegroundColor = fadeColors[i % fadeColors.Length];
            Console.Write("• ");
            Thread.Sleep(1000);
        }

        Console.ResetColor();
        Console.WriteLine();      
    }
}
