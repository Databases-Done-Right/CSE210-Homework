public class ReflectionActivity : Activity {
    private string _instructions = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you to recognie the power you have over your live and how you can apply it in other aspects of your life.";
    private List<string> _prompt = new List<string>();
    private List<string> _question = new List<string>();

    // constructor
    public void DoActivity() {
        int duration = BeginActivity("Reflection", _instructions);
        ShowInitialPrompt();
        ShowQuestions(duration);
        FinishActivity("Reflecting");
    }
    
    public ReflectionActivity() {
        _prompt.Add("Think of a time when you stood up for someone else.");
        _prompt.Add("Think of a time when you did something really difficult.");
        _prompt.Add("Think of a time when you helped someone in need.");
        _prompt.Add("Think of a time when you did something truly selfless.");

        _question.Add("Why was this experience meaningful to you?");
        _question.Add("Have you ever done anything like this before?");
        _question.Add("How did you get started?");
        _question.Add("How did you feel when it was complete?");
        _question.Add("What made this time different than other times when you were not as successful?");
        _question.Add("What is your favorite thing about this experience?");
        _question.Add("What could you learn from this experience that applied to other situations?");
        _question.Add("What did you learn about yourself through this experience?");
        _question.Add("How can you keep this experience in mind in the future?");
    }

    public void ShowInitialPrompt() {
        Console.WriteLine($"Consider the following prompt:");
        Console.WriteLine($"");
        DisplayRandomPrompt(_prompt);
        Console.WriteLine($"");
        Console.WriteLine($"");
        Console.WriteLine($"When you have something in mind, press enter to continue.");
        string userInput = Console.ReadLine();
        Console.Clear();
    }

    public void ShowQuestions(int duration) {
        DateTime futureTime = DateTime.Now.AddSeconds(duration);
        while(DateTime.Now < futureTime) {
            Console.WriteLine($"");
            DisplayRandomPrompt(_question);
            Console.Write(" ");
            DisplayAnimation(6);
        }
        Console.WriteLine($"");
    }
}