using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What % grade did you receive on this assignment?");
        
        string gradeAsString = Console.ReadLine();
        int gradePercentage = Int32.Parse(gradeAsString);
        string gradeLetter = "";
        if(gradePercentage >= 90) {
            gradeLetter = "A";
            //Console.WriteLine("Your letter grade was: A");
        }
        else {
            if (gradePercentage >= 80) {
                gradeLetter = "B";
                //Console.WriteLine("Your letter grade was: B");
            }
            else {
                if (gradePercentage >= 70) {
                    gradeLetter = "C";
                    //Console.WriteLine("Your letter grade was: C");
                }
                else {
                    if (gradePercentage >= 60) {
                        gradeLetter = "D";
                        //Console.WriteLine("Your letter grade was: D");
                    }
                    else {
                        gradeLetter = "F";
                        //Console.WriteLine("Your letter grade was: F");
                    }
                }
            }
        }
        Console.WriteLine($"Your letter grade was: {gradeLetter}");
        if(gradePercentage >= 70) {
            Console.WriteLine("Congratulations, you passed!");
        }
        else {
            Console.WriteLine("Ouch ... better luck next time.");
        }
    }
}