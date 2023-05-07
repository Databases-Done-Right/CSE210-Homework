public class Word
    {
        //public string _name = "";
        private List<string> _word = new List<string>();
        private int _wordsPerStep = 3;
        private List<string> _hiddenWord = new List<string>();

        public Word() {
        }

        public string GetDisplay() {
            string tbr = "";
            for(int a=0; a<_hiddenWord.Count; a++) {
                tbr += _hiddenWord[a] + " ";
            }
            return tbr;
        }

        public string GetDisplayHint() {
            string tbr = "";
            for(int a=0; a<_word.Count; a++) {
                tbr += _word[a] + " ";
            }
            return tbr;
        }

        private int GetHiddenWordTruePosition(int relativePosition) {
            int flagCount = 0;
            for(int a=0; a<_hiddenWord.Count; a++) {
                if(_hiddenWord[a][0] != '_') {
                    flagCount++;
                }
                if((flagCount-1) == relativePosition) {
                    return a;
                }
            }
            return 0;
        }
        private int GetNumberOfNonHiddenWords() {
            int tbr = 0;
            for(int a=0; a<_hiddenWord.Count; a++) {
                if(_hiddenWord[a][0] != '_') {
                    tbr++;
                }
            }
            return tbr;
        }

        private void HideSpecificWord(int position) {
            int truePosition = GetHiddenWordTruePosition(position);
            int numberOfLetters = _word[truePosition].Length;
            string blankedWord = "";
            for(int a=0; a<numberOfLetters; a++) {
                blankedWord += "_";
            }
            _hiddenWord[truePosition] = blankedWord;
        }

        public bool HideWords() {
            for(int a=0; a<_wordsPerStep; a++) {
                int visibleWords = GetNumberOfNonHiddenWords();
                if(visibleWords > 0) {
                    Random randomGenerator = new Random();
                    int randomNumber = randomGenerator.Next(0, (visibleWords-1));
                    HideSpecificWord(randomNumber);
                }
                else {
                    return true;
                }
            }
            return false;
        }

        public void SetWords(string sentence) {
            string[] parts = sentence.Split(" ");
            foreach (string part in parts) {
                _word.Add(part);
                _hiddenWord.Add(part);
            }
        }
    }