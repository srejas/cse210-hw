public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public void DisplayEntry()
    {
        Console.WriteLine($"{_date} - Prompt: {_promptText}\n>>{_entryText}");
    }
}