using System;
using System.Collections.Generic;
using System.Threading;

public class Listing : Activity
{
    private List<string> _situations = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
        "What are moments this week that made you smile?",
        "What are blessings in your life you may sometimes overlook?",
        "What talents or skills are you grateful to have?",
        "Who has shown you kindness recently?",
        "What are things in nature that bring you peace?",
    };

    private List<string> _userItems = new List<string>();

    public Listing()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
            0
        )
    {
    }

    public void Run()
    {
        DisplayWelcomeMsg();
        Console.WriteLine();

        Random rand = new Random();
        int index = rand.Next(_situations.Count);
        string situation = _situations[index];

        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {situation} ---");
        Console.WriteLine();

        Console.WriteLine("You will have a moment to prepare...");
        DisplayCountdown(10);

        Console.WriteLine();
        Console.WriteLine("Now, start listing items. Press Enter after each one:");
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(_time);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                _userItems.Add(item);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {_userItems.Count} item(s).");

        DisplayFinalMsg();
    }
}
