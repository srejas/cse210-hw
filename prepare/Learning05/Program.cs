using System;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        Square newSquare = new Square("black", 20);

        Rectangle newRectangle = new Rectangle("White", 10, 5);

        Circle newCircle = new Circle("Red", 15);

        List<Shape> testList = new List<Shape>();

        testList.Add(newCircle);
        testList.Add(newRectangle);
        testList.Add(newSquare);

        Console.WriteLine();
        
        foreach (Shape shape in testList)
        {
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
        }
    }
}