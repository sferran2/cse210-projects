//Showing Creativity and Exceeding Requirements: Add the option for the user to set their own prize.

using System;

public class Prize
{
    private string _prize;
    private int _winPrize;

    public Prize(string prize, int winPrize)
    {
        _prize = prize;
        _winPrize = winPrize;
    }

    public string GetPrize()
    {
        return _prize;
    }

    public int GetThreshold()
    {
        return _winPrize;
    }

    public bool IsAchieved(int score)
    {
        return score >= _winPrize;
    }

    public void ShowPrize()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($" Your prize: {_prize} (Unlocked at {_winPrize} points!)");
        Console.ResetColor();
    }
}
