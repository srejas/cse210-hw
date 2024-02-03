public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>();

    public ListingActivity(string name, string description) : base(name, description)
    {
        return;
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.Clear();

        Console.WriteLine("Get ready...");
        ShowSpinner(5);

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();

        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();

        Console.Write("You may begin in: ");
        ShowCountDown(7);

        Console.WriteLine();
        GetListFromUser();

        Console.WriteLine("Time's up!");
        ShowSpinner(3);

        Console.WriteLine($"You listed {_count} items.");
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        _prompts.Add("Who are people in your life that you look up to?");
        _prompts.Add("Where have you seen God's hand this week?");
        _prompts.Add("What are you personal strengths?");
        _prompts.Add("When have you felt the Holy Ghost recently?");
        _prompts.Add("What kind things has someone done for you this month?");
        _prompts.Add("What things are you grateful for right now?");

        Random randomGenerator = new Random();
        int randomPromptIndex = randomGenerator.Next(_prompts.Count());
        string randomPrompt = _prompts[randomPromptIndex];
        
        return randomPrompt;
    }

    public List<string> GetListFromUser()
    {
        List<string> userResponses = new List<string>();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write(">>");
            userResponses.Add(Console.ReadLine());
        }

        _count = userResponses.Count();

        return userResponses;
    }
}