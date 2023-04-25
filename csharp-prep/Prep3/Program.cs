using System;

class Program
{
    static void Main(string[] args)
    {
        // Greet the user that is here to learn
        Console.WriteLine("Welcome to the Prep3 demonstration C# learners!");
        Console.WriteLine("");

        // Create variable to hold the number to guess
        int magicNumber;

        // // Ask the user to input a number for the magic number & store it in a variable
        // Console.Write("What is the magic number? ");        
        // string givenNumber = Console.ReadLine();
        // // Convert string answer to int type        
        // magicNumber = int.Parse(givenNumber);

        // Have number to guess be created randomly
        Random randomGenerator = new Random();
        magicNumber = randomGenerator.Next(1, 101);
        
        // Create variable to hold the string guess given converted into an int type
        int guess;

        // Create variable to hold the number of guesses
        int count = 0;

        // Loop through asking and results until number is guessed
        do
        {
            // Ask a user to guess what the magic number is & store guess in a variable
            Console.Write("What is your guess? ");
            string givenGuess = Console.ReadLine();
            // Convert string answer to int type
            guess = int.Parse(givenGuess);

            // track the count of the number of guesses
            count += 1;

            // Tell the user if their guess is too low, high, or correct      
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine($"You guessed it in {count} guesses!");
            }            
        } while (guess != magicNumber);

    }
}