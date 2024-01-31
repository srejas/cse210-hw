using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment testAssingment1 = new MathAssignment("Tom Smith", "Fractions", "Section 7.9", "Problems 8-19");
        Console.WriteLine(testAssingment1.GetSummary());
        Console.WriteLine(testAssingment1.GetHomeworkList());
        
        WritingAssignment testAssignment2 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(testAssignment2.GetSummary());
        Console.WriteLine(testAssignment2.GetWritingAssingment());
    }
}