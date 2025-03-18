using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;


public class Journal
{
    public List<Entry> _userEntries;
    public Journal()
    {
        _userEntries = new List<Entry>();
    }

    public void AddEntry (Entry newEntry)
    {
        _userEntries.Add(newEntry);
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