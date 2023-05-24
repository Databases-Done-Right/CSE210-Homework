
public class User {
    private string _firstName = "";
    private string _lastName = "";
    List<Goal> _goals = new List<Goal>();

    // constructor
    public User() {
    }
    public User(string firstName, string lastName) {
        _firstName = firstName;
        _lastName = lastName;
    }

    private void BeginNewGoal(int userSelection) {
        Console.Clear();
        Console.WriteLine("What would you like to name this goal? ");
        string name = Console.ReadLine();
        Console.WriteLine("Please tell me a ltitle about your goal. Describe it. ");
        string descripiton = Console.ReadLine();
        switch(userSelection) {
            case 1: { // Simple
                Console.WriteLine("How many points is this goal worth once you have reached it? ");
                string userInput = Console.ReadLine();
                int points = Int32.Parse(userInput);
                Goal theGoal = new Goal(name, descripiton, points);
                _goals.Add(theGoal);
                break;
            }
            case 2: { // Eternal
                Console.WriteLine("How many points is this goal worth each time you return and report? ");
                string userInput = Console.ReadLine();
                int points = Int32.Parse(userInput);
                EternalGoal theGoal = new EternalGoal(name, descripiton, points);
                _goals.Add(theGoal);
                break;
            }
            case 3: { // Checklist
                Console.WriteLine("How many times would you like to accomplish this goal? ");
                string userInput = Console.ReadLine();
                int targetNumberOfTimes = Int32.Parse(userInput);
                Console.WriteLine("How many points is this goal worth each time you accomplish it? ");
                userInput = Console.ReadLine();
                int points = Int32.Parse(userInput);
                Console.WriteLine("How many bonus points is this goal worth once you have completed it? ");
                userInput = Console.ReadLine();
                int bonusPoints = Int32.Parse(userInput);
                ChecklistGoal theGoal = new ChecklistGoal(name, descripiton, points, targetNumberOfTimes, bonusPoints);
                _goals.Add(theGoal);
                break;
            }
        }
    }
    public int DisplayMainMenu() {
        Console.Clear();
        Console.Write($"Hello {_firstName}, you ");
        if(_goals.Count == 0) {
              Console.Write($"don't currently have any goals set.");
        }
        else {
            Console.Write($"have {_goals.Count} goal(s) currently set");
            Console.Write($" and have earned a total of {GetUserScore()} points so far!");
        }
        Console.WriteLine($" What would you like to do today?");
        Console.WriteLine("");
        Console.WriteLine("Menu Options");
        Console.WriteLine(" 1. View my Current Goals");
        Console.WriteLine(" 2. Set a New Goal");
        Console.WriteLine(" 3. Report on my Progress");
        Console.WriteLine(" 4. Switch User");
        //Console.WriteLine(" 5. Save my Goals to File");
        Console.WriteLine(" 5. Quit");
        string userInput = Console.ReadLine();
        int userSelection = Int32.Parse(userInput);
        ProcessMenuOption(userSelection);
        return userSelection;
    }

    private int GetUserScore() {
        int userScore = 0;
        for(int a=0; a<_goals.Count; a++) {
            userScore += _goals[a].CalculateScore();
        }
        return userScore;
    }

    public void GetInitialUser() {
        Console.Clear();
        Console.WriteLine("Hello, and welcome! Today is a great day to set a new goal!");
        Console.WriteLine("");
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();
        string filename = firstName + lastName + ".txt";
        _goals.Clear();
        LoadUserData(filename);
        this.SetName(firstName, lastName);
    }

    private bool LoadUserData(string filename) {
        if(File.Exists(filename)) {
            string[] lines = System.IO.File.ReadAllLines(filename);
            foreach (string line in lines) {
                string[] parts = line.Split(" | ");
                switch(parts[0]) {
                    case "Basic": {
                        Goal theGoal = new Goal(parts[1], parts[2], Int32.Parse(parts[3]), Convert.ToBoolean(parts[4]));
                        _goals.Add(theGoal);
                        break;
                    }
                    case "Checklist": {
                        Goal theGoal = new ChecklistGoal(parts[1], parts[2], Int32.Parse(parts[3]), Int32.Parse(parts[5]), Int32.Parse(parts[6]), Int32.Parse(parts[7]), Convert.ToBoolean(parts[4]));
                        _goals.Add(theGoal);
                        break;
                    }
                    case "Eternal": {
                        Goal theGoal = new EternalGoal(parts[1], parts[2], Int32.Parse(parts[3]), Convert.ToBoolean(parts[4]), Int32.Parse(parts[5]));
                        _goals.Add(theGoal);
                        break;
                    }
                }
    //            _reference.SetReference(parts[0], Convert.ToInt32(parts[1]), parts[2]);
                //_words.SetWords(parts[3]);
            }
            return true;
        }
        return false;
    }

    private void ProcessMenuOption(int userSelection) {
        Console.Clear();
        switch(userSelection) {
            case 1: { // View Current Goals
                if(_goals.Count == 0) {
                    Console.WriteLine("You haven't set any goals yet.");
                }
                else {
                    Console.WriteLine($"You currently have set a total of {_goals.Count} goal(s).");
                }
                Console.WriteLine("");
                foreach(Goal goal in _goals) {
                    Console.WriteLine($"{goal.GetCurrentStatus()}");
                }
                string userInput = Console.ReadLine();
                break;
            }
            case 2: { // Set New Goal
                Console.WriteLine("What kind of goal would you like to set?");
                Console.WriteLine(" 1. Setup a simple. one time goal");
                Console.WriteLine(" 2. Setup an eternal, ongoing goal");
                Console.WriteLine(" 3. Setup a checklist, qty based goal");
                string userInput = Console.ReadLine();
                int userSelection2 = Int32.Parse(userInput);
                BeginNewGoal(userSelection2);
                break;
            }
            case 3: { // Report Progress
                Console.WriteLine("Which goal would you like to report progress for?");
                int flagCurrentElementNumber = 0;
                for(int a=0; a<_goals.Count; a++) {
                    if(!_goals[a].GetGoalStatus()) {
                        flagCurrentElementNumber++;
                        Console.WriteLine($"{flagCurrentElementNumber}. {_goals[a].GetGoalNameAndDescription()}");
                    }
                }
                string userInput = Console.ReadLine();
                int userSelection2 = Int32.Parse(userInput);
                flagCurrentElementNumber = 0;
                int pointsEarned = 0;
                for(int a=0; a<_goals.Count; a++) {
                    if(!_goals[a].GetGoalStatus()) {
                        flagCurrentElementNumber++;
                        if(flagCurrentElementNumber == userSelection2) {
                            pointsEarned += _goals[a].LogProgress();
                        }
                    }
                }
                Console.WriteLine("");
                Console.WriteLine($"Great job! You earned {pointsEarned} points! Keep working on your goals.");
                userInput = Console.ReadLine();
                break;
            }
            case 4: { // Switch User
                SaveUserDataToFile();
                GetInitialUser();
                break;
            }
            case 5: { // Quit
                SaveUserDataToFile();
                break;
            }
        }
    }
    private void SaveUserDataToFile() {
        string filename = _firstName + _lastName + ".txt";
        if(File.Exists(filename)) {
            File.Delete(filename);
        }
        using (StreamWriter outputFile = new StreamWriter(filename)) {
            for(int a=0; a<_goals.Count; a++) {
                outputFile.WriteLine($"{_goals[a].GetGoalData()}");
            }
        }
        //Console.WriteLine($"{_goals.Count} goals have been successfully saved. Press any key to contine.");
        //string _ = Console.ReadLine();
    }

    private void SetName(string firstName, string lastName) {
        _firstName = firstName;
        _lastName = lastName;
    }

}