using System;
using System.Collections.Generic;
using System.Threading;

public class Reflection: Activity
{
    private List<string> _experiences = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?",
        "How did this experience challenge you?",
        "What strengths did you discover in yourself?",
        "Would you respond the same way if it happened again?",
        "Who influenced you during this experience, and how?",
        "What would you say to someone going through something similar?",
        "What did you overcome that you didn't think you could?",
        "What surprised you most about this experience?",
        "How has this experience changed the way you think?",
        "What would you do differently if you faced the same situation again?",
        "What part of this experience do you cherish the most?"
    };

    public Reflection()
        : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience.\nThis will help you recognize the power you have and how you can use it in other aspects of your life.",
            0
        )
    {
    }

    public void Run()
    {
        DisplayWelcomeMsg();
        Console.WriteLine ();
        Console.WriteLine("Get ready to reflect...");
        DisplayDownTime(3);

        Random rand = new Random();


        string experience = _experiences[rand.Next(_experiences.Count)];
        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine ();
        Console.WriteLine($"--- {experience} ---");
        Console.WriteLine ();
        Console.Write("When you have something in mind, press Enter to continue...");
        Console.WriteLine ();
        Console.ReadLine();

        Console.WriteLine ();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.WriteLine ();
        DisplayDownTime(3);

        int secondsElapsed = 0;
        int pausePerQuestion = 5;

        while (secondsElapsed + pausePerQuestion <= _time)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.Write($"> {question} ");
            DisplaySpinner(pausePerQuestion); 
            Console.WriteLine(); 

            secondsElapsed += pausePerQuestion;
        }

        DisplayFinalMsg();
    }

    private void DisplaySpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        int spinIndex = 0;

        for (int i = 0; i < seconds * 2; i++) 
        {
            Console.Write(spinner[spinIndex]);
            Thread.Sleep(500);
            Console.Write("\b");
            spinIndex = (spinIndex + 1) % spinner.Length;
        }
    }
}
