using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        Console.WriteLine();
        Console.WriteLine("Welcome to the Mindfulness Program!");
        
        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Menu Options: ");
            Console.WriteLine();
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Observation Activity");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu: (1-5) ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Breathing breathing = new Breathing();
                    breathing.Run();
                    break;
                case "2":
                    Reflection reflection = new Reflection();
                    reflection.Run();
                    break;
                case "3":
                    Listing listing = new Listing();
                    listing.Run();
                    break;
                case "4":
                    Observation observation = new Observation();
                    observation.Run();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine ();
                    Console.WriteLine("🌼 Thank you for joining this session 🌼!\nTake this peace with you into the rest of your day. ");
                    Console.WriteLine ();
                    break;
                default:
                    Console.WriteLine("Invalid option, try again!.");
                    break;
            }
        }
    }
}