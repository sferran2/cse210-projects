using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

// Shows creativity and exceeds core requirements

// Writing Feels Like a Chore:
// Implementing a way to track how many days a user writes and celebrating milestones at 5 and 10 days. 
// When the user reaches 20 days, acknowledge that journaling has become a habit.

public class Journal
{
    public List<Entry> _userEntries;
    public int streakCount;
    public string lastEntryDate;

    public Journal()
    {
        _userEntries = new List<Entry>();
        streakCount = 0;
        lastEntryDate = "";
    }

    public void AddEntry (Entry newEntry)
    {
        _userEntries.Add(newEntry);
        TrackStreak();
    }

    public void TrackStreak()
    {
        string todayDate = DateTime.Now.ToString("yyyy-MM-dd");
        
        if (lastEntryDate == todayDate)
        {
            Console.WriteLine("You already wrote today! Keep up the habit!");
            return;
        }
        
        if (lastEntryDate == "" || DateTime.Parse(lastEntryDate).AddDays(1).ToString("yyyy-MM-dd") == todayDate)
        {
            streakCount++;
        }
        else
        {
            streakCount = 1; 
        }

        lastEntryDate = todayDate;
        DisplayStreak();
    }

    private void DisplayStreak()
    {
        Console.WriteLine($"Streak: {streakCount} days!");
        if (streakCount == 5)
        {
            Console.WriteLine("5-Day Streak! Keep going!");
        }
        else if (streakCount == 10)
        {
            Console.WriteLine("10-Day Streak! Amazing dedication!");
        }
        else if (streakCount == 20)
        {
            Console.WriteLine("Congratulations! You've reached 20 entries—it's now a habit! Keep the momentum going!");
        }
    }

    public void DisplayALL()
    {
        if(_userEntries.Count == 0)
        {
            Console.WriteLine("Your journal is currently empty.");
            return;
        }
            Console.WriteLine(); 
        for (int i = 0; i < _userEntries.Count; i++)
        {
            _userEntries[i].DisplayEntry();
            if (i < _userEntries.Count - 1)
            {
                Console.WriteLine();
            }
        }
        Console.WriteLine();
    }
    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (var entry in _userEntries)
            {
                writer.WriteLine($"{entry._entryDate} | {entry._promptInput} | {entry._userEntry}");
            }
        }
        Console.WriteLine("Your journal has been saved to " + file);
    }

    public void LoadingFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("Unable to locate the file.");
            return;
        }

        _userEntries.Clear();
        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|'); 

            if (parts.Length == 3)
            {
                string date = parts[0].Trim();
                string prompt = parts[1].Trim();
                string response = parts[2].Trim();

                _userEntries.Add(new Entry(prompt, response));              
            }
        }

        Console.WriteLine("Journal loaded successfully from " + file);
    }
}