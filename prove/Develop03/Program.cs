using System;
using static Reference;
using static Scripture;
using static Word;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture("scriptures.txt");
        string input = "";
        Boolean oneLastTime = false;
        while(input != "quit") {
            scripture.Display();
            Console.WriteLine("");
            Console.Write("Press 'enter' to continue or type 'quit' to exit.");
            Console.Write(" (Type 'hint' for a hint.): ");
            input = Console.ReadLine();
            if(input == "hint") {
                scripture.DisplayHint();
            }
            else {
                if(oneLastTime) { input = "quit"; }
                oneLastTime = scripture.HideWords();
            }
        }
    }
}