using System;

class Program
{
    // Function to display a welcome for the program
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Functions to ask the user for their name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // Function to ask the user for their favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string answer = Console.ReadLine();
        int favNum = int.Parse(answer);
        return favNum;
    }

    // Function to square the user's favorite number
    static int SquareNumber(int num)
    {
        int squared = num * num;
        return squared;
    }

    // Function to display user's name and their favorite number squared
    static void DisplayResult(string userName, int number)
    {
        Console.WriteLine($"{userName}, the square of your number is {number}");
    }

    // Main function to run all of the functions
    static void Main(string[] args)
    {
        // Greet the user that is here to learn
        Console.WriteLine("Welcome to the Prep3 demonstration C# learners!");
        Console.WriteLine("");

        // Call the functions to run the program
        DisplayWelcome();
        string name = PromptUserName();
        int favNum = PromptUserNumber();
        int squared = SquareNumber(favNum);
        DisplayResult(name, squared);
    }
}