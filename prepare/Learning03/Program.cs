using System;
using static Fraction;

class Program
{
    static void Main(string[] args)
    {
        Fraction theFraction = new Fraction();
        Console.WriteLine($"Top: {theFraction.GetTop()}");
        Console.WriteLine($"Bottom: {theFraction.GetBottom()}");
        Console.WriteLine($"Fraction: {theFraction.GetFraction()}");
        Console.WriteLine($"Decimal: {theFraction.GetDecimalValue()}");

        Fraction theFraction2 = new Fraction(1);
        Console.WriteLine($"Top: {theFraction2.GetTop()}");
        Console.WriteLine($"Bottom: {theFraction2.GetBottom()}");
        Console.WriteLine($"Fraction: {theFraction2.GetFraction()}");
        Console.WriteLine($"Decimal: {theFraction2.GetDecimalValue()}");

        Fraction theFraction3 = new Fraction(5);
        Console.WriteLine($"Top: {theFraction3.GetTop()}");
        Console.WriteLine($"Bottom: {theFraction3.GetBottom()}");
        Console.WriteLine($"Fraction: {theFraction3.GetFraction()}");
        Console.WriteLine($"Decimal: {theFraction3.GetDecimalValue()}");

        Fraction theFraction4 = new Fraction(3, 4);
        Console.WriteLine($"Top: {theFraction4.GetTop()}");
        Console.WriteLine($"Bottom: {theFraction4.GetBottom()}");
        Console.WriteLine($"Fraction: {theFraction4.GetFraction()}");
        Console.WriteLine($"Decimal: {theFraction4.GetDecimalValue()}");

        Fraction theFraction5 = new Fraction(1, 3);
        Console.WriteLine($"Top: {theFraction5.GetTop()}");
        Console.WriteLine($"Bottom: {theFraction5.GetBottom()}");
        Console.WriteLine($"Fraction: {theFraction5.GetFraction()}");
        Console.WriteLine($"Decimal: {theFraction5.GetDecimalValue()}");


    }
}