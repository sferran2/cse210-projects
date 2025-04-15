using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Running run = new Running(new DateTime(2025, 04, 10), 30, 3.0);         // 3 miles in 30 mins
        Cycling ride = new Cycling(new DateTime(2025, 04, 7), 45, 15.0);       // 15 mph for 45 mins
        Swimming swim = new Swimming(new DateTime(2025, 04, 6), 40, 20);       // 20 laps

        List<Activity> activities = new List<Activity>
        {
            run,
            ride,
            swim
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        } 
    }
}