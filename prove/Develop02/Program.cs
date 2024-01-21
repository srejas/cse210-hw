using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        List<string> choiceOptions = new List<string>();

        choiceOptions.Add("Blank");
        choiceOptions.Add("Write");
        choiceOptions.Add("Display");
        choiceOptions.Add("Load");
        choiceOptions.Add("Save");
        choiceOptions.Add("Quit");

        DateTime theCurrentTime = DateTime.Now;
        string currentDate = theCurrentTime.ToShortDateString();
        
        Journal userJournal = new Journal();

        Console.WriteLine("Welcome to your journal!");
        int journalChoice = 0;

        while (journalChoice != 5)
        {
            Console.WriteLine("What would you like to do?");

            for (int i = 1; i < choiceOptions.Count; i++)
            {
                Console.WriteLine($"{i}. {choiceOptions[i]}");
            }

            Console.Write(">>");

            string userChoice = Console.ReadLine();
            int userNumberChoice = int.Parse(userChoice);

            journalChoice = userNumberChoice;

            if (journalChoice == 1)
            {
                Entry newEntry = new Entry();
                newEntry._date = currentDate;

                PromptGenerator newPrompt = new PromptGenerator();
                newEntry._promptText = newPrompt.GetRandomPrompt();

                Console.WriteLine(newEntry._promptText);
                Console.Write(">>");

                newEntry._entryText = Console.ReadLine();
                userJournal.AddEntry(newEntry);
            }
            else if (journalChoice == 2)
            {
                userJournal.DisplayAll();
            }
            else if (journalChoice == 3)
            {
                Console.WriteLine("Load");
                Console.Write("Please enter the file name: ");
                    
                string fileName = Console.ReadLine();
                userJournal.LoadFromFile(fileName);
            }
            else if (journalChoice == 4)
            {
                Console.Write("Please enter the file name: ");
                string fileName = Console.ReadLine();
                
                userJournal.SaveToFile(fileName);
            }
            else if (journalChoice == 5)
            {}
            else
            {
                Console.WriteLine("Sorry that isn't an available option.");
            }

        if (journalChoice == 5)
        {
            Console.WriteLine("See ya next time!");
        }
        }
    }
}