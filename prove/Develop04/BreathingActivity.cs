public class BreathingActivity : Activity {
    private int _breathIn = 4;
    private int _breathOut = 6;

    // constructor
    public BreathingActivity() {
        _activityName = "Breathing Activity";
        _description = "This activity will help you relay by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void BreathInAndOut(int duration) {
        DateTime futureTime = DateTime.Now.AddSeconds(duration);
        while(DateTime.Now < futureTime) {
            Console.WriteLine($"");
            Console.Write($"Breath in ... ");
            CountDown(_breathIn);
            Console.WriteLine($"");
            Console.Write($"Breath out ... ");
            CountDown(_breathOut);
        }
        Console.WriteLine("");
    }

    public void DoActivity() {
        int duration = BeginActivity(_activityName, _description);
        BreathInAndOut(duration);
        EndActivity(_activityName);
    }

}