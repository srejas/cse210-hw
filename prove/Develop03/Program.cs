using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        Reference scriptureReference = new Reference("Proverbs", 3, 5, 6);

        Scripture scriptureText = new Scripture(
            scriptureReference, "Trust in the Lord with all thine heart; " +
            "and lean not unto thine own dunderstanding. In all thy ways acknowledge " +
            "him, and he shall direct thy paths.");

        Console.WriteLine(scriptureText.GetScriptureDisplay());

        Console.WriteLine();
        Console.WriteLine("Press enter to continue or type 'quit' to finish:");

        string quitOrContinue = Console.ReadLine();

        while (quitOrContinue != "quit")
        {
            Console.Clear();
            scriptureText.HideRandomWords(5);

            Console.WriteLine(scriptureText.GetScriptureDisplay());

            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");

            if (scriptureText.IsCompletelyHidden())
            {
                quitOrContinue = "quit";
            }
            else
            {
                quitOrContinue = Console.ReadLine();
            }
        }    
        if (quitOrContinue == "quit")
        {
            return;
        }
    }
}