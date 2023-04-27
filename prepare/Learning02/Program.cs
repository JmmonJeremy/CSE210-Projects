using System;

class Program
{
    static void Main(string[] args)
    {  
        // Greet the user that is here to learn
        Console.WriteLine("Welcome to the Learning02 demonstration C# learners!");
        Console.WriteLine("");

        // Create a new instance of job1
        Job job1 = new Job();

        //  Set the value of the variables for job1 instance
        job1._company = "Programming Clinic";
        job1._jobTitle = "Debugger";
        job1._startYear = 2021;
        job1._endYear = 2023;
        // // Ensure it displays correctly
        // job1.Display();

        // Create a new instance of job2
        Job job2 = new Job();

        // Set the value of the variables for job2 instance
        job2._company = "Code Center";
        job2._jobTitle = "Programmer";
        job2._startYear = 2019;
        job2._endYear = 2021;
        // // Ensure it displays correctly
        // job2.Display();

        // Create a new instance of a resume
        Resume resume = new Resume();

        // Add a name & 2 job instances to the resume instance
        resume._name = "Jeremy The Programmer";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);
        // // Verify the data given is correct & available
        // Console.WriteLine(resume._name);
        // Console.WriteLine(resume._jobs[0]._jobTitle);
        // Console.WriteLine(resume._jobs[1]._jobTitle);

        // Display the resume with the resume's display method
        resume.Display();
    }
}