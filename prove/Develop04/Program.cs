using System;

class Program
{
    static void Main(string[] args)
    {
         List<string> choiceOptions = new List<string>();

        choiceOptions.Add("Blank");
        choiceOptions.Add("Start breathing activity");
        choiceOptions.Add("Start reflecting activity");
        choiceOptions.Add("Start listing activity");
        choiceOptions.Add("Quit");

        int menuChoice = 0;

        while (menuChoice != 4)
        {
            Console.Clear();
            
            Console.WriteLine("Welcome to your mindfullness app.");
            Console.WriteLine("Which exercise would you like to do?:");
            
            for (int i = 1; i < choiceOptions.Count; i++)
            {
                Console.WriteLine($"    {i}. {choiceOptions[i]}");
            }

            Console.Write(">>");

            string userChoice = Console.ReadLine();
            int userNumberChoice = int.Parse(userChoice);

            menuChoice = userNumberChoice;

            if (menuChoice == 1)
            {
                Console.Clear();

                BreathingActivity newBreathing = new BreathingActivity("Breathing", 
                "This activity will help you relax by taking you through counted breathing. " +
                "Clear your mind and focus on your breathing.");

                newBreathing.Run();
            }

            else if (menuChoice == 2)
            {
                Console.Clear();
                
                ReflectingActivity newReflecting = new ReflectingActivity("Reflecting", 
                "This activity will help you reflect on times in your life when you have shown strength " +
                "and resilience. This will help you recognize the power you have and how you can use it " +
                "in other aspects of your life.");

                newReflecting.Run();
            }

            else if (menuChoice == 3)
            {
                Console.Clear();

                ListingActivity newListing = new ListingActivity("Listing", 
                "This activity will help you reflect on the good things in your life by having you list " +
                "as many as you can during the given timeframe.");

                newListing.Run();
            }

            else if (menuChoice == 4)
            {
                Console.WriteLine("Have a blessed day.");
                return;
            }
        }
    }
}