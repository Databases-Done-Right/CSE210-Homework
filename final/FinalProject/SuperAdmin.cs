public class SuperAdmin : User {

    // constructor
    public SuperAdmin() {
    }
    public SuperAdmin(User user) : base(user.GetFirstName(), user.GetLastName(), user.GetUsername(), "SuperAdmin") {
    }


    public override void DisplayMainMenu(List<Division> divisions) {
        Console.Clear();
        Console.WriteLine($"What would you like to do today?");
        Console.WriteLine("");
        Console.WriteLine("Menu Options");
        Console.WriteLine(" 1. New Admin Account");
        Console.WriteLine(" 2. New Judge Account");
        Console.WriteLine(" 3. View Users");
        //Console.WriteLine(" 4. Delete User");
        Console.WriteLine(" 4. View Entry Report");
        Console.WriteLine(" 5. Logout");
        Console.WriteLine("");
        Console.Write("Selection: ");
        string userInput = Console.ReadLine();
        int userSelection = Int32.Parse(userInput);
        ProcessMenuOption(divisions, userSelection);
    }

    private void ListUsers() {
        Console.Clear();
        Console.WriteLine("Current Site Users");
        Console.WriteLine("");
        string[] files = Directory.GetFiles("users/", "*.txt", SearchOption.TopDirectoryOnly);
        for(int a=0; a<files.Count(); a++) {
            //Console.WriteLine(files[a]);
            string[] lines = System.IO.File.ReadAllLines(files[a]);
            foreach (string line in lines) {
                string[] parts = line.Split(" | ");
                if(parts.Count() >= 4) {
                    Console.WriteLine($"Username: {parts[2]} ({parts[3]}) - {parts[0]} {parts[1]}");
                }
            }
        }
        Console.WriteLine("");
    }

    protected override void ProcessMenuOption(List<Division> divisions, int userSelection) {
        Console.Clear();
        switch(userSelection) {
            case 1: { // New Admin
                AddNewUser("Admin");
                break;
            }
            case 2: { // New Judge
                AddNewUser("Judge");
                break;
            }
            case 3: { // View Users
                ListUsers();
                Console.WriteLine("Press enter to continue");
                string userInput = Console.ReadLine();
                break;
            }
            case 4: { // View Entries
                Entry entry = new Entry();
                entry.ListAllEntries();
                Console.WriteLine("Press enter to continue.");
                string userInput = Console.ReadLine();
                break;
            }
            case 5: { // Logout
                Environment.Exit(0);
                break;
            }
        }
    }
    public override void ViewReport() {
        // this might be identical to the Admin.ViewReport function
    }

}