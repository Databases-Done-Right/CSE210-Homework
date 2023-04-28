public class Entry
    {
        public string _date = "";
        public string _prompt = "";
        public string _currentEntry = "";
        public Impression _impression = new Impression();

        public Entry()
        {
            DateTime theCurrentTime = DateTime.Now;
            _date = theCurrentTime.ToShortDateString();
        }

        public void Display()
        {
            Console.WriteLine($"Date: {_date}");
            Console.WriteLine($"Prompt: {_prompt}");
            Console.WriteLine($"Entry: {_currentEntry}");
            if(_impression != null && _impression._currentEntry != null) {
                Console.WriteLine($"Impression: {_impression._currentEntry}");
            }
            Console.WriteLine("");
        }
        public void GetNewEntry()
        {
            Prompt thePrompt = new Prompt();
            thePrompt.GetRandomPrompt();
            _prompt = thePrompt._currentPrompt;
            Console.WriteLine("");
            _currentEntry = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Would you like to add an spiritual impresison to this journal entry? (Y)es or (N)o");
            string userInput = Console.ReadLine();
            if(userInput.ToLower() == "y") {
                Impression theImpression = new Impression();
                theImpression.GetNewEntry();
                _impression = theImpression;
            }
        }

    }