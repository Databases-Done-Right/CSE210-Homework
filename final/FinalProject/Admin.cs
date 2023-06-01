public class Admin : User {

    // constructor
    public Admin() {
    }
     public Admin(User user) : base(user.GetFirstName(), user.GetLastName(), user.GetUsername(), "Admin") {
    }
    public override void DisplayMainMenu(List<Division> divisions) {
        Console.Clear();
        Console.WriteLine($"What would you like to do today?");
        Console.WriteLine("");
        Console.WriteLine("Menu Options");
        Console.WriteLine(" 1. New Judge Account");
        Console.WriteLine(" 2. View Entry Report");
        Console.WriteLine(" 3. Logout");
        Console.WriteLine("");
        Console.Write("Selection: ");
        string userInput = Console.ReadLine();
        int userSelection = Int32.Parse(userInput);
        ProcessMenuOption(divisions, userSelection);
    }

    protected override void ProcessMenuOption(List<Division> divisions, int userSelection) {
        Console.Clear();
        switch(userSelection) {
            case 1: { // New Judge
                AddNewUser("Judge");
                break;
            }
            case 2: { // View Entries
                Entry entry = new Entry();
                entry.ListAllEntries();
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
    public override void ViewReport() {
        // Show a list of all entries
        // Entrant data can be shown
        // Identify which records won prizes
    }

}