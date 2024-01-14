using System;
using System.Globalization;
using System.Xml.Schema;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> numbers = new List<int>();
        int response = -1;

        while (response != 0)
            {
                Console.Write("Enter a number: ");
                string numberEntered = Console.ReadLine();
                response = int.Parse(numberEntered);
                if (response != 0)
                {
                    numbers.Add(response);
                }
            }
        
        int numberSum = numbers.Sum();
        Console.WriteLine($"The sum of the numbers is {numberSum}");

        double numberAverage = numbers.Average();
        Console.WriteLine($"The average of the numbers is {numberAverage}");

        int largestNumber = 0;
        foreach (int number in numbers)
            {
                if (number > largestNumber)
                    {
                        largestNumber = number;
                    }
            }
        Console.WriteLine($"The largest number is {largestNumber}");
    }
}