public class Reference
    {
        private string _book;
        private int _chapter;
        private string _verse ;
        //public List<string> _word = new List<string>();

        public Reference() {
        }

       public string GetDisplay() {
            string tbr = _book + " " + _chapter + ":" + _verse;
            return tbr;
        }
        public void SetReference(string book, int chapter, string verse) {
            _book = book;
            _chapter = chapter;
            _verse = verse;
        }

    }