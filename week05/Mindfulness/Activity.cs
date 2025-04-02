using System;
using System.Threading;

public class Activity
{
    protected string _activityName;
    protected string _description;
    protected int _time;

    public Activity(string activityName, string description, int time)
    {
        _activityName = activityName;
        _description = description;
        _time = time;
    }

    public void DisplayWelcomeMsg()
    {
        Console.WriteLine("======>");
        Console.WriteLine ($"Welcome to the {_activityName}!");
        Console.WriteLine();
        Console.WriteLine (_description);
        Console.WriteLine();
        Console.Write($"How long (in seconds) would you like for your session? ");
        int.TryParse(Console.ReadLine(), out _time);
    }

    public void DisplayFinalMsg()
    {
        Console.WriteLine ();
        Console.WriteLine ($"Well Done 💪!");
        Console.WriteLine ();
        Console.WriteLine ($"You have completed {_time} seconds of mindfulness 🌿 {_activityName} 🌿.");
        Console.WriteLine ();
    }

    public void DisplayDownTime(int seconds)
    {
        Thread.Sleep(seconds * 1000);
    }

    public void DisplayCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            string countdown = i.ToString();
            Console.Write(countdown);
            Thread.Sleep(1000);

        
            Console.Write(new string('\b', countdown.Length));
            Console.Write(new string(' ', countdown.Length));
            Console.Write(new string('\b', countdown.Length));
        }

        Console.WriteLine();
    }

}