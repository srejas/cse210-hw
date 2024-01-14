using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int randomNumber = randomGenerator.Next(1, 101);
        
        Console.WriteLine("Hi there, I'm programed to generate a random number between 1 and 100 for you to guess.");
        int guess = 0;

        while (guess != randomNumber)
            {
                Console.Write("What number have I generated? ");
                string stringGuess = Console.ReadLine();
                guess = int.Parse(stringGuess);

                if (guess < randomNumber)
                    {
                        Console.WriteLine("Higher. Try again.");
                    }
                else if (guess > randomNumber)
                    {
                        Console.WriteLine("Lower. Try again.");
                    }
                else
                    {
                        Console.WriteLine("You guessed it! Way to go!");
                    }
            }
    }
}