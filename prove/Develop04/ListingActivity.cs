public class ListingActivity : Activity {
    private string _instructions = "This activity will help you reflect on good things in your life by having you list as many things as you can in a certain area.";
    private List<string> _prompt = new List<string>();

    // constructor
    public ListingActivity() {
        _prompt.Add("Who are people that you appreciate?");
        _prompt.Add("What are personal strengths of yours?");
        _prompt.Add("Who are people that you have helped this week?");
        _prompt.Add("When have you felt the Holy Ghost this month?");
        _prompt.Add("Who are some of your personal heroes?");
    }

    public void DoActivity() {
        int duration = BeginActivity("Listing", _instructions);
        DoList(duration);
        FinishActivity("Listing");
    }

    public void DoList(int duration) {
        Console.WriteLine($"List as many responses as you can to the following prompt:");
        Console.WriteLine($"");
        DisplayRandomPrompt(_prompt);
        Console.WriteLine($"");
        Console.WriteLine($"");
        Console.Write($"You may begin in: ");
        for(int b=5; b>0; b--) {
           Console.Write($"{b}");
           Thread.Sleep(1000);
           Console.Write("\b \b");
        }
        Console.WriteLine($"");

        int flagCount = 0;
        DateTime futureTime = DateTime.Now.AddSeconds(duration);
        while(DateTime.Now < futureTime) {
            Console.Write(">");
            string userInput = Console.ReadLine();
            flagCount++;
        }
        Console.WriteLine("");
        Console.Write($"You listed {flagCount} item(s)!");
    }
}