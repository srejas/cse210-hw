using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();

    public ReflectingActivity(string name, string description) : base(name, description)
    {
        return;
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.Clear();

        Console.WriteLine("Get ready...");
        ShowSpinner(5);

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();

        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();

        Console.Write("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        Console.Clear();

        while (DateTime.Now < endTime)
        {
            Console.Write($"> {GetRandomPrompt()} ");
            ShowSpinner(7);
        }

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        _prompts.Add("Think of a time when you did something that you initially thought was impossible.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you knew you were being guided by the Spirit.");
        _prompts.Add("Think of a time when you stepped outside your comfort zone.");
        _prompts.Add("Think of a time when you felt stuck but then had a major breakthrough.");
        _prompts.Add("Think of a time when you changed your view on something.");

        Random randomGenerator = new Random();
        int randomPromptIndex = randomGenerator.Next(_prompts.Count());
        string randomPrompt = _prompts[randomPromptIndex];
        
        return randomPrompt;
    }

    public string GetRandomQuestion()
    {
        _questions.Add("Why was this the experience that stuck out to you?");
        _questions.Add("What did you learn from this experience that could apply to other situations?");
        _questions.Add("What have you changed as a result of this experience?");
        _questions.Add("How did you feel after this experience?");
        _questions.Add("Had you done anything like this prior to, or since, your experience?");
        _questions.Add("What was your favorite thing about this experince?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("What made this time different from others?");

        Random randomGenerator = new Random();
        int randomQuestionIndex = randomGenerator.Next(_questions.Count());
        string randomQuestion = _questions[randomQuestionIndex];
        
        return randomQuestion;
    }
}