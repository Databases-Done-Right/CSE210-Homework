public class User {
    protected string _firstName = "";
    protected string _lastName = "";
    protected string _username = "";
    protected string _password = "";
    protected string _filename = "";
    protected string _accountType = "";
    //private string _emailAddress = "";
    //private bool _isEmailVerified = false; // no need to verify email addresses for admin created users

    // constructor
    public User() {
    }
    public User(string firstName, string lastName, string accountType) {
        _firstName = firstName;
        _lastName = lastName;
        _accountType = accountType;
    }
    public User(string firstName, string lastName, string username, string accountType) {
        _firstName = firstName;
        _lastName = lastName;
        _username = username;
        _accountType = accountType;
    }

    private void AddNewPatronAccount(string username, string password) {
        User newUser = new User();
        Console.Write("What is your first name? ");
        newUser._firstName = Console.ReadLine();
        Console.Write("What is your last name? ");
        newUser._lastName = Console.ReadLine();
        Console.Write("In what city do you live? ");
        string city = Console.ReadLine();
        Console.Write("In what state do you live? ");
        string state = Console.ReadLine();
        Console.Write("What is a good phone number to reach you at? ");
        string phoneNumber = Console.ReadLine();
        Patron patron = new Patron(newUser, city, state, phoneNumber);
        patron._username = username;
        patron._password = password;
        patron.DetermineUserFilename();
//Console.WriteLine();
        SaveChanges(patron);
    }

    protected void AddNewUser(string accountType) {
        User newUser = new User();
        newUser._accountType = accountType;
        Console.Write("First name: ");
        newUser._firstName = Console.ReadLine();
        Console.Write("Last name: ");
        newUser._lastName = Console.ReadLine();
        Console.Write("Username: ");
        newUser._username = Console.ReadLine();
        Console.Write("Password: ");
        newUser._password = Console.ReadLine();
        newUser.DetermineUserFilename();
        switch(accountType) {
            case "Admin": {
                SaveChanges(newUser);
                break;
            }
            case "Judge": {
                SaveChanges(newUser);
                break;
            }
            case "Patron": {
                //Patron user = new Patron();
                Console.Write("City: ");
                string city = Console.ReadLine();
                Console.Write("State: ");
                string state = Console.ReadLine();
                Console.Write("Phone Number: ");
                string phoneNumber = Console.ReadLine();
                SaveChanges(newUser, city, state, phoneNumber);
                break;
            }
            case "SuperAdmin": {
                SaveChanges(newUser);
                break;
            }
        }
    }

    private void DetermineUserFilename() {
        if(_username != "" && _password != "") {
            string encryptedPassword = UserPasswordToMD5(_password);
            _filename = "users/" + _username + "_" + encryptedPassword + ".txt";
        }
    }

    public  virtual void DisplayMainMenu(List<Division> divisions) {
        // over-ridden at child level, polymorphism
    }
    protected void DisplayManageDivisionsMenu() {
    }
    protected void EditUser() {
        // calls this.listUsers() and prompts user to specify which to operate on
        // calls this.SaveChanges();        
    }

    public virtual string FormatDataForSavingToFile() {
        return _firstName + " | " + _lastName + " | " + _username + " | " + _accountType;
    }

    public string GetAccountType() {
        return _accountType;
    }
    public string GetFirstName() {
        return _firstName;
    }
    public string GetLastName() {
        return _lastName;
    }

    private string GetFilename() {
        return _filename;
    }
    public string GetUsername() {
        return _username;
    }

    public bool isLoggedIn() {
        if(_accountType != "") {
            return true;
        }
        return false;
    }
    private void ListUsers() {
        // lists all of the users that the currently logged in user
        // has sufficient permissions to see and/or operate on
    }
    public User Login() {
        // prompt for username & password and check against file
        // files to take the format of users/username.txt
        // returns true on sucess
        int userSelection = LoginMainMenu();
        Console.Clear();
        switch(userSelection) {
            case 1: { // Existing Account Login
                Console.Write("Please enter your username: ");
                _username = Console.ReadLine();
                Console.Write("Please enter your password: ");
                _password = Console.ReadLine();
                DetermineUserFilename();
                if(File.Exists(_filename)) {
                    User newUser = LoadUserData();
                    Console.Clear();
                    Console.WriteLine($"Welcome back {newUser.GetFirstName()}!");
                    Console.WriteLine("Press enter to continue.");
                    string userInput = Console.ReadLine();
                    return newUser;
                }
                else {
                    Console.Clear();
                    Console.WriteLine("Invalid username or password. Please try again.");
                    Console.WriteLine("Press enter to continue.");
                    string userInput = Console.ReadLine();
                }
                break;
            }
            case 2: { // New Account Signup
                Console.Write("Please choose a username: ");
                _username = Console.ReadLine();
                Console.Write("Please enter a password: ");
                _password = Console.ReadLine();
                DetermineUserFilename();
                if(File.Exists(_filename)) {
                    Console.WriteLine("");
                    Console.WriteLine("That user already exists, please login or try again with a different username.");
                    Console.WriteLine("Press enter to continue.");
                    string userInput = Console.ReadLine();
                }
                else {
                    AddNewPatronAccount(_username, _password);
                    Console.WriteLine("");
                    Console.WriteLine($"Your account has been successfully created.");
                    Console.WriteLine("You will need to login with your new account credentials.");
                    Console.WriteLine("Press enter to continue.");
                    string userInput = Console.ReadLine();
                    return this;
                }
                break;
            }
            case 3: { // Quit
                Environment.Exit(0);
                break;
            }
        }
        return default;
    }

    private int LoginMainMenu() {
        Console.Clear();
        Console.WriteLine("Login");
        Console.WriteLine("");
        Console.WriteLine("Menu Options");
        Console.WriteLine(" 1. Login to an Existing Account");
        Console.WriteLine(" 2. Signup for a New Account");
        Console.WriteLine(" 3. Quit");
        Console.WriteLine("");
        Console.Write("Selection: ");
        string userInput = Console.ReadLine();
        int userSelection = Int32.Parse(userInput);
        return userSelection;
    }

    private User LoadUserData() {
        if(File.Exists(_filename)) {
            string[] lines = System.IO.File.ReadAllLines(_filename);
            foreach (string line in lines) {
                string[] parts = line.Split(" | ");
                _firstName = parts[0];
                _lastName = parts[1];
                _username = parts[2];
                _accountType = parts[3];
                switch(_accountType) {
                    case "Admin": {
                        Admin newUser = new Admin(this);
                        return newUser;
                    }
                    case "Judge": {
                        Judge newUser = new Judge(this);
                        return newUser;
                    }
                    case "Patron": {
                        string city = parts[4];
                        string state = parts[5];
                        string phoneNumber = parts[6];
                        Patron newUser = new Patron(this, city, state, phoneNumber);
                        return newUser;
                    }
                    case "Super Admin": {
                        SuperAdmin newUser = new SuperAdmin(this);
                        return newUser;
                    }
                }
            }
        }
        User user = new User();
        return user;
    }

    public bool LogOut() {
        return true;
    }

    protected virtual void ProcessMenuOption(List<Division> divisions, int userSelection) {
        // over-ridden at child level, polymorphism
    }

    private void SetName(string firstName, string lastName) {
        _firstName = firstName;
        _lastName = lastName;
    }

    private void SaveChanges(User user, string city="", string state="", string phoneNumber="") {
        // saves any new or changed user data automatically to file
        user.DetermineUserFilename();
        if(File.Exists(user._filename)) {
            File.Delete(user._filename);
        }
        using (StreamWriter outputFile = new StreamWriter(user._filename)) {
            outputFile.Write($"{user.FormatDataForSavingToFile()}");
            /*outputFile.Write($"{user._firstName} | {user._lastName} | {user._username} | {user._accountType}");
            switch(user._accountType) {
                case "Patron": {
                    outputFile.Write($" | {city} | {state} | {phoneNumber}");
                    break;
                }
            } */
        }
    }
     private static string UserPasswordToMD5(string input) {
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create()) {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return Convert.ToHexString(hashBytes);
        }
    }

   public virtual void ViewReport() {
        // over-ridden at child level, polymorphism
    }
}