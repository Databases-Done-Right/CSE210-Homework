public class Impression
    {
        public string _currentEntry = "";

        public Impression()
        {
        }

        public void GetNewEntry()
        {
            Console.WriteLine($"What was your impression?");
            _currentEntry = Console.ReadLine();            
        }

    }