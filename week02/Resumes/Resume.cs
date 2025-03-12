using System;
using System.Collections.Generic;

public class Resume
{
    public string Name;
    public List<Job> Jobs =new List<Job>();

    public void DisplayResume()
    {
        Console.WriteLine($"Name: {Name}.");
        Console.WriteLine($"Jobs:");

        foreach (Job job in Jobs)
        {
            job.DisplayJob();
        }
    }
}