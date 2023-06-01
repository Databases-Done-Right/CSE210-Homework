public class Division {
    List<Entry> _entries = new List<Entry>();
    private int _id = 0;
    private string _name = "";
    private string _description = "";
    private int _firstPrize = 0;
    private int _secondPrize = 0;
    private int _thirdPrize = 0;
    private bool _isPeoplesChoice = false;

    // constructor
    public Division() {
    }
    public Division(int id, string name, string description, int firstPrize, int secondPrize, int thirdPrize, bool isPeoplesChoice) {
        _id = id;
        _name = name;
        _description = description;
        _firstPrize = firstPrize;
        _secondPrize = secondPrize;
        _thirdPrize = thirdPrize;
        _isPeoplesChoice = isPeoplesChoice;
    }

    public string DisplayDivision() {
        return _id + ". " + _name + " - " + _description;
    }

    public string GetName() {
        return _name;
    }
    public Division GetNewDivision() {
        Division division = new Division();
        Console.Clear();
        Console.WriteLine("Adding a New Division");
        Console.WriteLine(""); 
        Console.Write("Name: ");
        division._name = Console.ReadLine();
        Console.Write("Description: ");
        division._description = Console.ReadLine();
        Console.Write("First Prize ($): ");
        string userInput = Console.ReadLine();
        division._firstPrize = Int32.Parse(userInput);
        Console.Write("Second Prize ($): ");
        userInput = Console.ReadLine();
        division._secondPrize = Int32.Parse(userInput);
        Console.Write("Third Prize ($): ");
        userInput = Console.ReadLine();
        division._thirdPrize = Int32.Parse(userInput);
        return division;
    }

    public List<Division> LoadDivisions() {
        List<Division> divisions = new List<Division>();
        Division division = new Division(1,"Adult","Entrants 18 years and older.", 100, 50, 20, false);
        divisions.Add(division);
        division = new Division(2,"Youth","Entrants 12-17 years old.", 100, 50, 20, false);
        divisions.Add(division);
        division = new Division(3,"Child","Entrants 11 years and younger.", 50, 30, 10, false);
        divisions.Add(division);
        return divisions;
    }

}