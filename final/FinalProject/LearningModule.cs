using System.Configuration.Assemblies;
using System.Formats.Asn1;

public class LearningModule
{
    private List<Shape> _shapes = new List<Shape>();
    private int _guesses;

    public LearningModule()
    {
        _guesses = 0;
    }

    public void Run()
    {
        Cone newCone = new Cone();
        Pyramid newPyramid = new Pyramid();
        Sphere newSphere = new Sphere();

        Cylinder newCylinder = new Cylinder();
        Cube newCube = new Cube();
        RectangularPrism newPrism = new RectangularPrism();

        _shapes.Add(newPrism);
        _shapes.Add(newCube);
        _shapes.Add(newCylinder);

        _shapes.Add(newSphere);
        _shapes.Add(newCone);
        _shapes.Add(newPyramid);


        Console.Clear();
        DisplayStartingPrompt();

        Console.Clear();
        AskQuestions();

        Console.WriteLine();
        DisplayEndingMessage();
    }

    public void DisplayStartingPrompt()
    {
        Console.WriteLine("Welcome!");

        Console.WriteLine();
        Console.WriteLine("This module is designed to solidfy your knowledge of formulas " +
        "for geometric shapes by asking you to match the displayed shape to the " +
        "corresponding formula.");

        Console.WriteLine();
        Console.Write("Press enter when you are ready to begin -> ");
        Console.ReadLine();
    }
    
    public void DisplayFormulas()
    {
        int i = 1;

        foreach (Shape shape in _shapes)
        {
            Console.WriteLine($"{i}. {shape.DisplayFormula()}");
            i ++;
        }
    }

    public void AskQuestions()
    {
        Random randomGenerator = new Random();
        int startingQuestion = randomGenerator.Next(1, _shapes.Count());

        List<int> questionsToAsk = new List<int>(){1,2,3,4,5,6};

        List<int> questionsAsked = new List<int>();
        
        for (int i = startingQuestion; i <= _shapes.Count(); i = randomGenerator.Next(1,_shapes.Count()))
        {
            while (questionsAsked.Contains(i))
            {
                List<int> unusedQuestions = questionsToAsk.Except(questionsAsked).ToList();
                i = unusedQuestions[0];
            }

            Console.Clear();
            DisplayFormulas();

            int correctAnswer = i - 1;

            Type shapeType = _shapes[correctAnswer].GetType();
            Console.Write($"What number option is the formula for a {shapeType}? ");

            CheckAnswer(correctAnswer, shapeType);
            _shapes[correctAnswer].MarkUsed();

            if (AllShapesUsed() == true)
            {
                return;
            }
            
            questionsAsked.Add(i);
        }
    }

    public void CheckAnswer(int answer, Type shapeType)
    {
        int userAnswer = -1;

            while (userAnswer != answer)
            {
                string enteredAnswer = Console.ReadLine();
                int intAnswer = int.Parse(enteredAnswer);
                userAnswer = intAnswer - 1;

                if (userAnswer == answer)
                {
                    return;
                }
                else
                {
                    _guesses += 1;

                    Console.WriteLine("Sorry, that is not correct.");
                    Console.Write($"What number option is the formula for a {shapeType}? ");
                }
            }
    }

    public bool AllShapesUsed()
    {
        bool shapesAllUsed = false;

        int shapesUsed = 0;

        foreach (Shape shape in _shapes)
        {
            if (shape.IsUsed())
            {
                shapesUsed += 1;
            }
            if (shapesUsed == _shapes.Count())
            {
                shapesAllUsed = true;
            }
        }

        return shapesAllUsed;
    }

    public void DisplayEndingMessage()
    {
        if (_guesses >= 2)
        {
            Console.WriteLine("You made it!");
            Console.WriteLine();
            Console.WriteLine("You got to the end but it seems like there were a few you " +
            "didn't know. You might wanna review your formulas and try again.");
        }
        else
        {
            Console.WriteLine("Congradulations! You did it!");
            Console.WriteLine();
            Console.WriteLine("You really know your formulas!");
        }
    }
}