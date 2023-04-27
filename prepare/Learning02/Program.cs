using System;
using static Job;
using static Resume;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "ACME";
        job1._jobTitle = "Manager";
        job1._startYear = 2022;
        job1._endYear = 2023;
        Job job2 = new Job();
        job2._company = "Microsoft";
        job2._jobTitle = "Software Engineer";
        job2._startYear = 2016;
        job2._endYear = 2021;
        Resume resume1 = new Resume();
        resume1._name = "Bob Smith";
        resume1._job.Add(job1);
        resume1._job.Add(job2);
        resume1.Display();
    }
}