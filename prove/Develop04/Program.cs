using System;
using static Activity;
using static BreathingActivity;
using static ReflectionActivity;
using static ListingActivity;

class Program
{
    static void Main(string[] args)
    {
        Activity activity = new Activity();
        int userSelection = 0;
        while(userSelection != 5) {
            userSelection = activity.DisplayMainMenu();
            activity.ProcessMenuOption(userSelection);
        }
    }
}