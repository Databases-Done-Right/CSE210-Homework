using static Entry;
using static Impression;
using static Journal;
using static Prompt;
using System;
using System.IO; 

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        bool exitProgram = false;
        while(!exitProgram) {
            exitProgram = theJournal.MainMenu();
        }
    }
}