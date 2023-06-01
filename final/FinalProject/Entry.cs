public class Entry {
    //private Division _divisions = new Division;
    private string _name = "";
    private string _description = "";
    private string _division = "";
    private string _place = ""; // what place it ended up receiving


    // constructor
    public Entry() {
    }
    public Entry(string name, string description, string division) {
        _name = name;
        _description = description;
        _division = division;
    }
    public Entry(string name, string description, string division="", string place="") {
        _name = name;
        _description = description;
        _division = division;
        _place = place;
    }
    
    public Entry AddNewEntry(List<Division> divisions) {
        Entry entry = new Entry();
        Console.Clear();
        Console.WriteLine("Adding a New Entry");
        Console.WriteLine(""); 
        Console.Write("Entry Name: ");
        entry._name = Console.ReadLine();
        Console.Write("Entry Description: ");
        entry._description = Console.ReadLine();
        Console.WriteLine(""); 
        for(int a=0; a<divisions.Count(); a++) {
            Console.WriteLine(divisions[a].DisplayDivision()); 
        }
        Console.Write("Division: ");
        string userInput = Console.ReadLine();
        for(int a=0; a<divisions.Count(); a++) {
            if((Int32.Parse(userInput)-1) == a) {
                entry._division = divisions[a].GetName();
            }
        }
        Console.WriteLine("");
        Console.WriteLine("1. Photos");
        Console.WriteLine("2. Graphic Arts");
        Console.WriteLine("3. Other");
        Console.Write("Category: ");
        userInput = Console.ReadLine();
        switch(Int32.Parse(userInput)) {
            case 1: {
                Console.Write("Subject: ");
                string subject = Console.ReadLine();
                Photo photo = new Photo(entry, subject);
                return photo;
            }
            case 2: {
                Console.Write("Medium: ");
                string medium = Console.ReadLine();
                GraphicArt graphicArt = new GraphicArt(entry, medium);
                return graphicArt;
            }
            case 3: {
                Console.Write("Material: ");
                string material = Console.ReadLine();
                Other other = new Other(entry, material);
                return other;
            }
        }
        return entry;
    }

    public void DeleteEntry() {
    }
    public void EditEntry() {
        // calls this.SaveChanges();        
    }

    public string GetDescription() {
        return _description;
    }
    public string GetDivision() {
        return _division;
    }
    public virtual string GetEntryInfo() {
        string tbr = _division;
        if(_place != null && _place != "") {
            tbr += " (" + _place + ")";
        }
        tbr += " " + _name + " - " + _description;
        return tbr;
    }

    protected virtual string GetDetails() {
        return _name + " | " + _description + " | " + _division + " | " + _place;
    }
    public string GetName() {
        return _name;
    }
    public string GetPlace() {
        return _place;
    }
    public void ListAllEntries() {
        List<Entry> entries = LoadAllEntries();
        Console.WriteLine($"All Fair Entries");
        Console.WriteLine("");
        for(int a=0; a<entries.Count(); a++) {
            Console.WriteLine((a+1) + ". " + entries[a].GetEntryInfo());
        }
        Console.WriteLine("");
    }
    public List<Entry> LoadAllEntries() {
        List<Entry> entries = new List<Entry>();
        string[] files = Directory.GetFiles("entries/", "*.txt", SearchOption.TopDirectoryOnly);
        for(int a=0; a<files.Count(); a++) {
            string[] lines = System.IO.File.ReadAllLines(files[a]);
            foreach (string line in lines) {
                string[] parts = line.Split(" | ");
                switch(parts[0]) {
                    case "GraphicArt": {
                        GraphicArt entry = new GraphicArt(parts[1], parts[2], parts[3], parts[4], parts[5]);
                        entries.Add(entry);
                        break;
                    }
                    case "Photo": {
                        Photo entry = new Photo(parts[1], parts[2], parts[3], parts[4], parts[5]);
                        entries.Add(entry);
                        break;
                    }
                    case "Other": {
                        Other entry = new Other(parts[1], parts[2], parts[3], parts[4], parts[5]);
                        entries.Add(entry);
                        break;
                    }
                }
            }
        }
        return entries;
    }


    public List<Entry> LoadEntriesByUser(string username) {
        List<Entry> entries = new List<Entry>();
        string filename = "entries/" + username + ".txt";
        if(File.Exists(filename)) {
            string[] lines = System.IO.File.ReadAllLines(filename);
            foreach (string line in lines) {
                string[] parts = line.Split(" | ");
                switch(parts[0]) {
                    case "GraphicArt": {
                        GraphicArt entry = new GraphicArt(parts[1], parts[2], parts[3], parts[4], parts[5]);
                        entries.Add(entry);
                        break;
                    }
                    case "Photo": {
                        Photo entry = new Photo(parts[1], parts[2], parts[3], parts[4], parts[5]);
                        entries.Add(entry);
                        break;
                    }
                    case "Other": {
                        Other entry = new Other(parts[1], parts[2], parts[3], parts[4], parts[5]);
                        entries.Add(entry);
                        break;
                    }
                }
            }
        }
        return entries;
    }

    public void SaveEntriesToFile(List<Entry> entries, string username) {
        string filename = "entries/" + username + ".txt";
        if(File.Exists(filename)) {
            File.Delete(filename);
        }
        using (StreamWriter outputFile = new StreamWriter(filename)) {
            for(int a=0; a<entries.Count; a++) {
                outputFile.WriteLine($"{entries[a].GetDetails()}");
            }
        }
    }
}