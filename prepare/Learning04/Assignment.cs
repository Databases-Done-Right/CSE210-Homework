public class Assignment
    {
        protected string _studentName = "";
        private string _topic = "";

        // constructor, loads from file
        public Assignment(string studentName, string topic) {
            _topic = topic;
            _studentName = studentName;
        }

        public string GetSummary() {
            return $"{_studentName} - {_topic}";
        }
    }