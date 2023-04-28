public class Prompt
    {
        public string _currentPrompt = "";
        public List<string> _prompt = new List<string>();

        public Prompt()
        {
            _prompt.Add("Who did you interact with today?");
            _prompt.Add("Write about what you are thankful for today?");
            _prompt.Add("What is one thing that happened to you today?");
            _prompt.Add("What was different about today?");
            _prompt.Add("What is something new that you learned today?");
            _prompt.Add("Did you go anywhere special today?");
            _prompt.Add("What was the best part about today?");
        }

        public void GetRandomPrompt()
        {
            Random randomGenerator = new Random();
            int randomNumber = randomGenerator.Next(0, _prompt.Count);
            _currentPrompt = _prompt[randomNumber];
            Console.WriteLine($"{_currentPrompt}");
        }

    }