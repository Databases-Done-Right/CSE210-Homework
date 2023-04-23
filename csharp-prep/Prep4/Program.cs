using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        string enteredNumber = null;
        do {
            Console.Write("Enter number: ");
            enteredNumber = Console.ReadLine();
            if(enteredNumber != "0") {
                numbers.Add(Int32.Parse(enteredNumber));
            }
        } while (enteredNumber != "0");

        int theSum = 0;
        int theLargest = -1;
        for(int a=0; a<numbers.Count; a++) {
            theSum += numbers[a];
            if(numbers[a] > theLargest) {
                theLargest = numbers[a];
            }
        }
        float theAverage = (float)theSum / numbers.Count;
        Console.WriteLine($"The sum is: {theSum}");
        Console.WriteLine($"The average is: {theAverage}");
        Console.WriteLine($"The largest is: {theLargest}");
    }
}