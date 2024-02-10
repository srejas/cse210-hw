using System.Configuration.Assemblies;
using System.Globalization;
using System.Runtime.ExceptionServices;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public GoalManager()
    {
        _score = 0;
    }

    public void Start()
    {
        List<string> choiceOptions = new List<string>();

        choiceOptions.Add("Blank");
        choiceOptions.Add("Creat New Goal");
        choiceOptions.Add("List Goals");
        choiceOptions.Add("Save Goals");
        choiceOptions.Add("Load Goals");
        choiceOptions.Add("Record Event");
        choiceOptions.Add("Quit");

        int menuChoice = 0;
        Console.Clear();

        Console.WriteLine("Welcome!");
        Console.WriteLine();

        while (menuChoice != 6)
        {
            DisplayPlayerInfo();

            Console.WriteLine("Menu:");
            
            for (int i = 1; i < choiceOptions.Count; i++)
            {
                Console.WriteLine($"    {i}. {choiceOptions[i]}");
            }

            Console.Write("Please select an option: ");

            string userChoice = Console.ReadLine();
            int userNumberChoice = int.Parse(userChoice);

            menuChoice = userNumberChoice;

            if (menuChoice == 1)
            {
                Console.Clear();
                List<string> goalTypes = new List<string>();

                goalTypes.Add("1. Simple Goal");
                goalTypes.Add("2. Eternal Goal");
                goalTypes.Add("3. Checklist Goal");

                Console.WriteLine("The type of goals are:");

                for (int i = 0; i < goalTypes.Count(); i++)
                {
                    Console.WriteLine($"    {goalTypes[i]}");
                }

                CreateGoal();
                Console.Clear();
            }

            else if (menuChoice == 2)
            {
                Console.Clear();
                Console.WriteLine("The goals are:");

                ListGoalDetails();

                Console.Write("Press enter to continue ");
                Console.ReadLine();

                Console.Clear();
            }

            else if (menuChoice == 3)
            {
                Console.Clear();
                SaveGoals();

                Console.Clear();
            }

            else if (menuChoice == 4)
            {
                Console.Clear();
                LoadGoals();

                Console.Clear();
            }

            else if (menuChoice == 5)
            {
                Console.Clear();

                Console.WriteLine("The goals are:");
                ListGoalNames();

                RecordEvent();
                Console.WriteLine();

                Console.Write("Press enter to continue ");
                Console.ReadLine();

                Console.Clear();
            }
            
            else if (menuChoice == 6)
            {
                Console.WriteLine("Great Job! See you next time.");
            }
        }
    }
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine();
    }

    public void ListGoalNames()
    {
        int i = 1;
        
        foreach (Goal goal in _goals)
        {
            string [] parts = goal.GetStringRepresentation().Split(":");

            string goalType = parts[0];
            string goalDetails = parts[1];

            string [] goalParts = goalDetails.Split("|");

            string goalName = goalParts[0];
            
            Console.WriteLine($"    {i}. {goalName}");

            i += 1;
        }
    }

    public void ListGoalDetails()
    {
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"    {goal.GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.Write("What type of goal would you like to create? ");

        string userElection = Console.ReadLine();
        int intElection = int.Parse(userElection);

        Console.Write("What is the name of your goal? ");
        string goalName = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string goalDescription = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        string stringPoints = Console.ReadLine();

        int goalPoints = int.Parse(stringPoints);

        if (intElection == 1)
        {
            SimpleGoal newGoal = new SimpleGoal(goalName, goalDescription, goalPoints);
            _goals.Add(newGoal);
        }

        else if (intElection == 2)
        {
            EternalGoal newGoal = new EternalGoal(goalName, goalDescription, goalPoints);
            _goals.Add(newGoal);
        }

        else if (intElection == 3)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            string stringTarget = Console.ReadLine();
            int goalTarget = int.Parse(stringTarget);

            Console.Write("What is the bonus for accomplishing it that many times? ");
            string stringBonus = Console.ReadLine();
            int goalBonus = int.Parse(stringBonus);

            ChecklistGoal newGoal = new ChecklistGoal(goalName, goalDescription, goalPoints, goalTarget, goalBonus, 0);
            _goals.Add(newGoal);
        }
    }

    public void SaveGoals()
    {
        Console.Write("Please enter the file name for where the goals will be saved: ");
        string fileName = Console.ReadLine();
        
        using (StreamWriter fileToSave = new StreamWriter(fileName))
        {
            fileToSave.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                fileToSave.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals ()
    {
        Console.Write("Please enter the file name: ");
        string fileName = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(fileName);

        string stringScore = lines[0];
        _score = int.Parse(stringScore);

        for (int i = 1; i < lines.Count(); i++)
        {
            string[] parts = lines[i].Split(":");

            string goalType = parts[0];
            string goalDetails = parts[1];

            if (goalType == "SimpleGoal")
            {
                string[] goalParts = goalDetails.Split("|");

                string goalName = goalParts[0];
                string goalDescription = goalParts[1];
                string stringPoints = goalParts[2];

                int goalPoints = int.Parse(stringPoints);

                SimpleGoal loadedGoal = new SimpleGoal(goalName, goalDescription, goalPoints);

                string stringBool = goalParts[3];
                
                if (stringBool == "True")
                {
                    loadedGoal.RecordEvent();
                }

                _goals.Add(loadedGoal);
            }

            else if (goalType == "EternalGoal")
            {
                string[] goalParts = goalDetails.Split("|");

                string goalName = goalParts[0];
                string goalDescription = goalParts[1];
                string stringPoints = goalParts[2];

                int goalPoints = int.Parse(stringPoints);

                EternalGoal loadedGoal = new EternalGoal(goalName, goalDescription, goalPoints);
                _goals.Add(loadedGoal);
            }

            else if (goalType == "ChecklistGoal")
            {
                string[] goalParts = goalDetails.Split("|");

                string goalName = goalParts[0];
                string goalDescription = goalParts[1];
                string stringPoints = goalParts[2];

                int goalPoints = int.Parse(stringPoints);

                string stringBonus = goalParts[3];
                string stringTarget = goalParts[4];
                string stringAmountCompleted = goalParts[5];

                int goalBonus = int.Parse(stringBonus);
                int goalTarget = int.Parse(stringTarget);
                int goalAmountCompleted = int.Parse(stringAmountCompleted);

                ChecklistGoal loadedGoal = new ChecklistGoal(goalName, goalDescription, goalPoints,
                goalBonus, goalTarget, goalAmountCompleted);

                _goals.Add(loadedGoal);
            }
        }
    }

    public void RecordEvent()
    {
        Console.Write("Which goal did you accomplish? ");
        string stringChoice = Console.ReadLine();

        int pseudoChoice = int.Parse(stringChoice);
        int userChoice = pseudoChoice - 1;

        int pointsEarned = _goals[userChoice].RecordEvent();

        Console.WriteLine();
        Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");

        _score += pointsEarned;

        Console.WriteLine($"You now have now have {_score} points.");
    }
}