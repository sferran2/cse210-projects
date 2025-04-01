using System;

public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        
        string topic = GetTopic();

        return $"{_studentName} - {topic}\n{_title} by {_studentName}";
        
    }
}