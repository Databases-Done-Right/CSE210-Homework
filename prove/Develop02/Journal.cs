public class Journal
    {
        //public string _name = "";
        public List<Entry> _entry = new List<Entry>();

        public Journal()
        {
        }

        private void Display() {
            Console.WriteLine("Contents of current jorunal:");
            Console.WriteLine("");
            for(int a=0; a<_entry.Count; a++) {
                _entry[a].Display();
            }
        }

        private void LoadJournalFromFile() {
            Console.WriteLine($"What is the name of the file that you want to load journal entries from?");
            string userInput = Console.ReadLine();
            //if (!File.Exists(userInput)) {
            _entry.Clear();
            string[] lines = System.IO.File.ReadAllLines(userInput);
            foreach (string line in lines) {
                string[] parts = line.Split("|");
                Entry theEntry = new Entry();
                theEntry._date = parts[0];
                theEntry._prompt = parts[1];
                theEntry._currentEntry = parts[2];
                theEntry._impression._currentEntry = parts[3];
                _entry.Add(theEntry);
            }
        }
        public bool MainMenu()
        {
            Console.WriteLine("What would you like to do today?");
            Console.WriteLine("");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            string userInput = Console.ReadLine();
            int userSelection = Int32.Parse(userInput);
            Console.WriteLine("");
            return ProcessMenuOption(userSelection);
        }

        private bool ProcessMenuOption(int userSelection) {
            switch(userSelection) {
                case 1: { // Write
                    Entry theEntry = new Entry();
                    theEntry.GetNewEntry();
                    _entry.Add(theEntry);
                    break;
                }
                case 2: { // Display
                    this.Display();
                    break;
                }
                case 3: { // Load
                    LoadJournalFromFile();
                    break;
                }
                case 4: { // Save
                    SaveJournalToFile();
                    break;
                }
                case 5: { // Quit
                    return true;
                }
            }
            return false;
        }

        private void SaveJournalToFile() {
            Console.WriteLine($"What is the name of the file that you want to save your journal entries to?");
            string userInput = Console.ReadLine();
            using (StreamWriter outputFile = new StreamWriter(userInput)) {
                for(int a=0; a<_entry.Count; a++) {
                    outputFile.WriteLine($"{_entry[a]._date} | {_entry[a]._prompt} | {_entry[a]._currentEntry} | {_entry[a]._impression._currentEntry}");
                }
            }
        }

    }