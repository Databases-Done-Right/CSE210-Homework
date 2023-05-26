public class Division {
    List<Entry> _entries = new List<Entry>();
    private string _name = "";
    private string _description = "";
    private int _id = 0;
    private float _firstPrize = 0;
    private float _secondPrize = 0;
    private float _thirdPrize = 0;
    private bool _isPeoplesChoice = false;

    // constructor
    public Division() {
    }
    public Division(string name, string description) {
        _name = name;
        _description = description;
    }

    public void ListEntries() {
        // lists all entries in this prticular division.
        // Calls Entry.GetName()
    }

    private void SaveChanges() {
        // saves any new or changed division data automatically to file
    }
}