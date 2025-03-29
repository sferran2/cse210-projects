using System;
using System.Collections.Generic;

public class Comment
{
    private string _commenteName;
    private string _commentText;

    public Comment (string name, string text)
    {
        _commenteName = name;
        _commentText = text;
    }

    public void Display()
    {
        Console.WriteLine($"* {_commenteName}: {_commentText}.");
    }
}