using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Microsoft";
        job1._jobTitle = "Data Center Technician";
        job1._startYear = 2000;
        job1._endYear = 2005;

        Job job2 = new Job();
        job2._company = "Apple";
        job2._jobTitle = "Formal Verification Engineer";
        job2._startYear = 2006;
        job2._endYear = 2010;

        //Console.WriteLine($"Company: {job1._company}.");
        //Console.WriteLine($"Company: {job2._company}.");

        //job1.DisplayJob();
        //job2.DisplayJob();

        Resume myResume = new Resume();
        myResume.Name = " Pedro Perez";

        myResume.Jobs.Add(job1);
        myResume.Jobs.Add(job2);

        //Console.WriteLine($" First Job Title: {myResume.Jobs[0]._jobTitle}.");

        myResume.DisplayResume();

    } 
}