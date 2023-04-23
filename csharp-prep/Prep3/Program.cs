using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("What is the magic number?");
        //string themagicNumber = Console.ReadLine();
        //int magicNumber = Int32.Parse(themagicNumber);
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1,100);
        int guessedNumber = -1;
        string theGuess = null;
        do {
            Console.WriteLine("What is your guess?");
            theGuess = Console.ReadLine();
            guessedNumber = Int32.Parse(theGuess);
            if(magicNumber == guessedNumber) {
                Console.WriteLine("You guessed it!");
            }
            else {
                if(magicNumber > guessedNumber) {
                    Console.WriteLine("Higher");
                }
                else {
                    Console.WriteLine("Lower");
                }
            }
        } while (magicNumber != guessedNumber);
    }
}