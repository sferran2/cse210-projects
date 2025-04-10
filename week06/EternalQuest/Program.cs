using System;
using System.Collections.Generic;
using System.IO;
using GoalGetter;
using System.Threading;

namespace GoalGetter
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager goalManager = new GoalManager();

            Console.WriteLine();
            Console.WriteLine("Are you a returning user or starting fresh?");
            Console.WriteLine("1. I'm new!");
            Console.WriteLine("2. I'm coming back (load my goals)");
            Console.Write("Enter your choice (1 or 2): ");
            string userType = Console.ReadLine();

            if (userType == "1")
            {
                goalManager.DisplayWelcome();
                goalManager.DisplayPrize();
            }
            else if (userType == "2")
            {
                Console.Write("Enter the filename to load your goals: ");
                string file = Console.ReadLine().Trim();
                goalManager.LoadGoals(file);
            }


            string userInput;
            do
            {
                goalManager.DisplayPlayerInfo();
                goalManager.DisplayMenu();
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        goalManager.NewGoal();
                        break;
                    case "2":
                        goalManager.ListGoalNames();
                        break;
                    case "3":
                        Console.Write("Enter the filename to save your goals: ");
                        string saveFile = Console.ReadLine();
                        goalManager.SaveToFile(saveFile);
                        break;
                    case "4":
                        Console.Write("Enter the filename to load your goals: ");
                        string loadFile = Console.ReadLine();
                        goalManager.LoadGoals(loadFile);
                        break;
                    case "5":
                        goalManager.RecordEvent(); 
                        break;
                    case "6":
                        goalManager.ShowPrize();
                        break;
                    case "7":
                        Console.WriteLine("Thank you for using GoalGetter!");
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
                        break;
                }
            }
            while (userInput != "7");
        }
    }
}
