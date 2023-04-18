using System;

class Program
{
    static void Main(string[] args)
    {
        // Greet the student user
        Console.WriteLine("Welcome to the Prep1 demonstration C# learner!");
        Console.WriteLine("");

        // Ask the user for their first and last name
        Console.Write("What is your first name? ");
        string f_name;        
        f_name = Console.ReadLine();

        Console.Write("What is your last name? ");
        string l_name = Console.ReadLine();
        Console.WriteLine("");

        // Repeat the user's name to them
        Console.WriteLine($"Your name is {l_name}, {f_name} {l_name}.");
    }
}