using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning03 World!");
        Fraction test1 = new Fraction(1);
        Fraction test2 = new Fraction(5);
        Fraction test3 = new Fraction(3,4);
        Fraction test4 = new Fraction(1,3);

        Console.WriteLine(test1.GetFractionString());
        Console.WriteLine(test1.GetDecimalValue());

        Console.WriteLine(test2.GetFractionString());
        Console.WriteLine(test2.GetDecimalValue());

        Console.WriteLine(test3.GetFractionString());
        Console.WriteLine(test3.GetDecimalValue());
        
        Console.WriteLine(test4.GetFractionString());
        Console.WriteLine(test4.GetDecimalValue());
    }
}