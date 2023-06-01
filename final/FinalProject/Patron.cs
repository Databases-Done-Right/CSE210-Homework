public class Patron : User {
    List<Entry> _entries = new List<Entry>();
    private string _city = "";
    private string _state = "";
    private string _phoneNumber = "";

    // constructor
    public Patron() {
    }
    public Patron(User user, string city, string state, string phoneNumber) : base(user.GetFirstName(), user.GetLastName(), user.GetUsername(), "Patron") {
        _city = city;
        _state = state;
        _phoneNumber = phoneNumber;
        Entry entry = new Entry();
        _entries = entry.LoadEntriesByUser(user.GetUsername());
    }

    public override void DisplayMainMenu(List<Division> divisions) {
        Console.Clear();
        Console.WriteLine($"What would you like to do today?");
        Console.WriteLine("");
        Console.WriteLine("Menu Options");
        Console.WriteLine(" 1. New Entry");
        Console.WriteLine(" 2. View Results");
        Console.WriteLine(" 3. Logout");
        Console.WriteLine("");
        Console.Write("Selection: ");
        string userInput = Console.ReadLine();
        int userSelection = Int32.Parse(userInput);
        ProcessMenuOption(divisions, userSelection);
    }

    public override string FormatDataForSavingToFile() {
        return _firstName + " | " + _lastName + " | " + _username + " | " + _accountType + " | " + _city + " | " + _state + " | " + _phoneNumber;
    }

    protected override void ProcessMenuOption(List<Division> divisions, int userSelection) {
        Console.Clear();
        switch(userSelection) {
            case 1: { // New Entry
                Entry entry = new Entry();
                entry = entry.AddNewEntry(divisions);
                _entries.Add(entry);
                entry.SaveEntriesToFile(_entries, GetUsername());
                break;
            }
            case 2: { // View Results
                Console.WriteLine($"Your Fair Entries");
                Console.WriteLine("");
                for(int a=0; a<_entries.Count(); a++) {
                    Console.WriteLine(_entries[a].GetEntryInfo());
                }
                Console.WriteLine("");
                Console.WriteLine("Press enter to continue.");
                string userInput = Console.ReadLine();
                break;
            }
            case 3: { // Logout
                Environment.Exit(0);
                break;
            }
        }
    }

    public bool signUp() {
        // goes through the new user info gathering process
        // once gathered, it creates the new user
        // Probably calling User.addUser()
        return true;
    }
    public void VerifyEmailAddress() {
        // is invoked when the emailed to link is clicked out.
        // sets User._isEmailVerified() to true
    }
    public override void ViewReport() {
        // list entries they have made. No need to specify
        // entrant contact info as they know who they are
    }

}