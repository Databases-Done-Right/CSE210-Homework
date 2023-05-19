using System;
using static Circle;
using static Rectangle;
using static Shape;
using static Square;
class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        Circle circle = new Circle("red", 2);
        shapes.Add(circle);
        Console.WriteLine($"{circle.GetArea()}");

        shapes.Add(new Square("blue", 6));
        shapes.Add(new Rectangle("orange", 1, 6));

        foreach(Shape shape in shapes) {
            //double area = shape.GetArea();
            string color = shape.GetColor();
            Console.WriteLine($"{color} -! {shape.GetArea()}");
        }
    }
}