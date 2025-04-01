using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new ("Samuel Bennett", "Multiplication");
        Assignment assignment2 = new ("Roberto Rodriguez", "Fractions");
        MathAssignment mathAssignment = new("Section 7.3", "Problem 8-19");
        WritingAssignment writingAssignment = new("Mary Waters", "European History","The Causes of World War II");
        Console.WriteLine(assignment1.GetSummary());
        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());
        Console.WriteLine(writingAssignment.GetWritingInformation());

    }
}