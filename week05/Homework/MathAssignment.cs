using System;

public class MathAssignment
{
    private string _textBookSection;
    private string _problems;

    public MathAssignment(string textBookSection, string problems)
    {
        _textBookSection = textBookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"{_textBookSection} {_problems}";
    }
}