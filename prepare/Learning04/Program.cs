using System;
using static Assignment;
using static MathAssignment;
using static WritingAssignment;


class Program
{
    static void Main(string[] args)
    {
        MathAssignment test = new MathAssignment("Bob", "My Topic", "3.4", "2-20 evens");
        WritingAssignment writing = new WritingAssignment("John", "History", "WWII in Depth");
        string summary = test.GetSummary();
        string homework = test.GetHomeworkList();
        string writingSummary = writing.GetSummary();
        string writingInformation = writing.GetWritingInformation();
        Console.WriteLine($"{summary}");
        Console.WriteLine($"{homework}");
        Console.WriteLine("");
        Console.WriteLine($"{writingSummary}");
        Console.WriteLine($"{writingInformation}");
    }
}