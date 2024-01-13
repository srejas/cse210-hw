using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter your grade percentage: ");
        string stringGrade = Console.ReadLine();
        int gradePercentage = int.Parse(stringGrade);

        string letterGrade = "";

        Console.WriteLine();
        if (gradePercentage >= 90)
            {
                letterGrade = "A";
            }
        else if (gradePercentage >= 80 && gradePercentage <90)
            {
                letterGrade = "B";
            }
        else if (gradePercentage >= 70 && gradePercentage <80)
            {
                letterGrade = "C";
            }
        else if (gradePercentage >= 60 && gradePercentage <70)
            {
                letterGrade = "D";
            }
        else
            {
                letterGrade = "F";
            }
        Console.WriteLine($"Your grade is {letterGrade}");

        if (gradePercentage >= 70)
            {
                Console.WriteLine("Congratulations on passing the class!");
            }
        else
            {
                Console.WriteLine("Don't give up, you'll do better next time.");
            }
    }
}