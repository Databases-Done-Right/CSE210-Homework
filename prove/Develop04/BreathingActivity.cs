public class BreathingActivity : Activity {
    private int _breathIn = 4;
    private int _breathOut = 6;
    private string _instructions = "This activity will help you relay by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing.";

    // constructor
    public BreathingActivity() {
    }

    public void BreathInAndOut(int duration) {
        DateTime futureTime = DateTime.Now.AddSeconds(duration);
        while(DateTime.Now < futureTime) {
            Console.WriteLine($"");
            Console.Write($"Breath in ... ");
            for(int b=_breathIn; b>0; b--) {
                Console.Write($"{b}");
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine($"");
            Console.Write($"Breath out ... ");
            for(int b=_breathOut; b>0; b--) {
                Console.Write($"{b}");
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
    }

    public void DoActivity() {
        int duration = BeginActivity("Breathing", _instructions);
        BreathInAndOut(duration);
        FinishActivity("Breathing");
    }

}