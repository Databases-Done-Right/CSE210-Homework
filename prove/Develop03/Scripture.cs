public class Scripture
    {
        private Word _words = new Word();
        private Reference _reference = new Reference();

        // constructor, loads from file
        public Scripture(string filename) {
            string[] lines = System.IO.File.ReadAllLines(filename);
            foreach (string line in lines) {
                string[] parts = line.Split("|");
                _reference.SetReference(parts[0], Convert.ToInt32(parts[1]), parts[2]);
                _words.SetWords(parts[3]);
            }
        }
        public Scripture(string word, string book, int chapter, string verse) {
            _reference.SetReference(book, chapter, verse);
        }

        public void Display() {
            Console.Clear();
            Console.WriteLine($"{_words.GetDisplay()} - {_reference.GetDisplay()}");
        }

        public void DisplayHint() {
            Console.Clear();
            Console.WriteLine($"{_words.GetDisplayHint()} - {_reference.GetDisplay()}");
            System.Threading.Thread.Sleep(1000);
        }

        public bool HideWords() {
            return _words.HideWords();
        }

    }