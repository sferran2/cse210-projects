using System;
using System.Collections.Generic;


public class Video
{
    private string _title;
    private string _author;
    private int _lenght;
    private List<Comment> _comments; 

    public Video( string title, string author, int lenght )
    {
        _title = title;
        _author = author;
        _lenght = lenght;
        _comments = new List<Comment>();
    }
    
    public void AddComment (Comment comment)
    {
        _comments.Add (comment);
    }
    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public void Display()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_lenght} seconds.");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine($"Comments:");
        foreach (Comment comment in _comments)
        {
            comment.Display();
        }
    }
    
}