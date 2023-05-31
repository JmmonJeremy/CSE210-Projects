using System;

// ### CLASS ################################################ //
// class to run the program
class Program
{
// ### METHODS ############################################## //
    // main method to run the program
    static void Main(string[] args)
    {
        // welcomes C# learners with an empty line afterwards
        Console.WriteLine("Hello Learning04 World!\n");

        // testing the Assignment base class
        Assignment assignment = new Assignment("Samuel Bennett", "Multiplication");
        // display results to the console
        Console.WriteLine(assignment.GetSummary());

        // testing the MathAssignment class
        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        // display the summary & homework list results to the console with an empty line before it
        Console.WriteLine($"\n{mathAssignment.GetSummary()}\n{mathAssignment.GetHomeworkList()}");

        // testing the WritingAssignment class
        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        // display the summary & writing information results to the console with an empty line before & after it
        Console.WriteLine($"\n{writingAssignment.GetSummary()}\n{writingAssignment.GetWritingInformation()}\n");
    }
}