using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
   {
        Journal journal = new Journal();
        Prompts prompts = new Prompts();
        bool running = true;

        Console.WriteLine("Welcome to the Journal Program!");
        
        while (running)
        {
            Console.WriteLine("Please select one of the following choices: ");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    string prompt = prompts.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write(">");
                    string response = Console.ReadLine();
                    journal.AddEntry(new Entry(prompt, response));
                    break;
                case "2":
                    journal.DisplayALL();
                    break;
                case "3":
                    Console.Write("What is the file name: (.txt) ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;
                case "4":
                    Console.Write("Enter filename to load: (.txt) ");
                    string loadFile = Console.ReadLine();
                    journal.LoadingFromFile(loadFile);
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Journal saved and closed. Until next time—keep writing your story!!");
                    break;
                default:
                    Console.WriteLine("Invalid option, try again!.");
                    break;
            }
        }
    }
}