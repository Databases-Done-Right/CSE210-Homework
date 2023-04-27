

public class Resume
    {
        public string _name = "";
        public List<Job> _job = new List<Job>();

        public Resume()
        {
        }

        public void Display()
        {
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine($"Job(s): ");
            for(int a=0; a<_job.Count; a++) {
                _job[a].Display();
            }
        }

    }
    