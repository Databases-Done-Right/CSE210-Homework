public class Judge : User {
    private List<Division> _divisions = new List<Division>();
    // constructor
    public Judge() {
    }
    public Judge(User user) : base(user.GetFirstName(), user.GetLastName(), user.GetUsername(), "Judge") {
    }

    public override void DisplayMainMenu(List<Division> divisions) {
        Console.Clear();
        Console.WriteLine($"What would you like to do today?");
        Console.WriteLine("");
        Console.WriteLine("Menu Options");
        Console.WriteLine(" 1. Judge Entries");
        Console.WriteLine(" 2. View Report");
        Console.WriteLine(" 3. Logout");
        Console.WriteLine("");
        Console.Write("Selection: ");
        string userInput = Console.ReadLine();
        int userSelection = Int32.Parse(userInput);
        ProcessMenuOption(divisions, userSelection);
    }
    private void JudgeEntry(int entryNumber) {
        // asks what place the specified entry is to recieve.
        // responsible for storing the data in a flat file.
        // will probably be calling Entry.SaveChanges() to do so.
    }

    protected override void ProcessMenuOption(List<Division> divisions, int userSelection) {
        Console.Clear();
        switch(userSelection) {
            case 1: { // Judge Entries
                Entry entry = new Entry();
                entry.ListAllEntries();
                Console.Write("Which entry you you like to award first to? ");
                string userInput = Console.ReadLine();
                break;
            }
            case 2: { // View Report
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
        // Shows a report of which entries they are responsible for judging
        // Without any identifying information which might bias them.
        // Perhaps a way to quick link to the entry and specify winners from here
        // In that instance, this function would be the one calling Judge.judgeEntry()
    }

}