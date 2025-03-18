public class Entry
{
    public string _entryDate;
    public string _promptInput;
    public string _userEntry;

    public Entry(string prompt, string response)
    {
        _entryDate = DateTime.Now.ToString("yyyy-MM-dd");
        _promptInput = prompt;
        _userEntry = response;
    }    
    public void DisplayEntry()
    {
        Console.WriteLine("Date: " + _entryDate + " - Prompt: " + _promptInput + ".\n" + _userEntry);
    }
}