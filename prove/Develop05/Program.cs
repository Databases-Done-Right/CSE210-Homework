using System;
using static ChecklistGoal;
using static EternalGoal;
using static Goal;
using static User;

class Program
{
    static void Main(string[] args)
    {
        User user = new User();
        user.GetInitialUser();
        int userSelection = 0;
        while(userSelection != 5) {
            userSelection = user.DisplayMainMenu();
        }
    }

    
}