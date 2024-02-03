public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description)
    {
        return;
    }
    
    public void Run()
    {
        
        DisplayStartingMessage();
        Console.Clear();

        Console.WriteLine("Get ready...");
        ShowSpinner(5);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            ShowCountDown(4);

            Console.Write("Now breathe out...");
            ShowCountDown(6);

            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}