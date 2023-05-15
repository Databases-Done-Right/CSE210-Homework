public class Activity {
    protected string _activityName = "";
    protected string _description = "";
    protected int _duration = 0;

    // constructor
    public Activity() {
    }

    protected int BeginActivity(string activityName, string instructions) {
        DisplayInstructions(activityName, instructions);
        SetDuration();
        GetReady();
        return _duration;
    }

    protected void CountDown(int seconds) {
        for(int b=seconds; b>0; b--) {
            Console.Write($"{b}");
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected void DisplayAnimation(int seconds) {
        for (int i = 0; i < seconds; i++)  {
            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }
    private void DisplayInstructions(string activityName, string instructions) {
        Console.Clear();
        Console.WriteLine($"Welcome to the {activityName}");
        Console.WriteLine("");
        Console.WriteLine($"{instructions}");
    }
    public int DisplayMainMenu() {
        Console.Clear();
        Console.WriteLine("Menu Options");
        Console.WriteLine(" 1. Start Breathing Activity");
        Console.WriteLine(" 2. Start Reflection Activity");
        Console.WriteLine(" 3. Start Listing Activity");
        Console.WriteLine(" 4. Random Activity");
        Console.WriteLine(" 5. Quit");
        string userInput = Console.ReadLine();
        int userSelection = Int32.Parse(userInput);
        return userSelection;
    }

    public void DisplayRandomPrompt(List<string> prompt) {
        Random randomGenerator = new Random();
        int randomNumber = randomGenerator.Next(0, prompt.Count);
        string currentPrompt = prompt[randomNumber];
        Console.Write($"{currentPrompt}");
    }

    protected void EndActivity(string activityName) {
        Console.WriteLine("");
        Console.WriteLine($"Well done!");
        Console.WriteLine("");
        Console.WriteLine($"You have successfully completed the {activityName}. Now don't you feel better?");
        Thread.Sleep(3500);
    }
    protected void GetReady() {
        Console.Clear();
        Console.WriteLine($"Get ready ...");
        DisplayAnimation(5);
    }
    public void ProcessMenuOption(int userSelection) {
        switch(userSelection) {
            case 1: { // Breathing
                BreathingActivity theActivity = new BreathingActivity();
                theActivity.DoActivity();
                break;
            }
            case 2: { // Reflection
                ReflectionActivity theActivity = new ReflectionActivity();
                theActivity.DoActivity();
                break;
            }
            case 3: { // Listing
                ListingActivity theActivity = new ListingActivity();
                theActivity.DoActivity();
                break;
            }
            case 4: { // Random
                Random randomGenerator = new Random();
                int randomNumber = randomGenerator.Next(1, 3);
                ProcessMenuOption(randomNumber);
                break;
            }
        }
    }

    protected void SetDuration() {
        Console.WriteLine($"");
        Console.Write($"How long, in seconds, would you like your session to last? ");
        string userInput = Console.ReadLine();
        _duration = Int32.Parse(userInput);
    }
}