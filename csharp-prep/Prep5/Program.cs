using System;
using System.Configuration.Assemblies;
using System.Reflection.Metadata.Ecma335;
using System.Xml.XPath;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }
        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();
            return userName;
        }
        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            string favoriteNumber = Console.ReadLine();
            int userNumber = int.Parse(favoriteNumber);
            return userNumber;
        }
        static int SquareNumber(int number)
        {
            int result = number * number;
            return result;
        }
        static void DisplayResult (string name, int squaredNumber)
        {
            Console.WriteLine($"{name}, your favorite number squared is {squaredNumber}.");
        }

        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);
        DisplayResult(userName, squaredNumber);
    }
}