using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep1 Student Participant!");
        Console.WriteLine("");
        Console.Write("What is your first name? ");
        string f_name;
        f_name = Console.ReadLine();
        Console.Write("What is your last name? ");
        string l_name = Console.ReadLine();
        Console.WriteLine("");
        Console.WriteLine($"Your name is {l_name}, {f_name} {l_name}.");
    }
}