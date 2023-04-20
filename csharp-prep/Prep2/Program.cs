using System;

class Program
{
    static void Main(string[] args)
    {
        // Greet the user, who is hopefully here to learn
        Console.WriteLine("Welcome to the Prep2 demonstration C# learners!");
        Console.WriteLine("");
        
        // Get the users grade % for input & store it
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
         // Convert the string into a float
        float gradePercentage = float.Parse(answer);
        // Create a variable for the Letter Grade
        string letter;

        // Determine grade from the percentage
        if (gradePercentage >= 90)
        {
            letter = "A";
            // Console.WriteLine($"Your letter grade is an {letter}");
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
            // Console.WriteLine($"Your letter grade is a {letter}");
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
            // Console.WriteLine($"Your letter grade is a {letter}");
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
            // Console.WriteLine($"Your letter grade is a {letter}");
        }
        else
        {
            letter = "F";
            // Console.WriteLine($"Your letter grade is an {letter}");
        }

        // Create variable to hold grade sign
        string sign;
        // Determine if the letter grade is a + or a -
        float lastNumber = gradePercentage % 10;
        if (lastNumber >= 7)
        {
            sign = "+";
        }else{
            sign = "-";
        }
        // Determine if symbol should be added and add it if so
        if (gradePercentage < 97 && gradePercentage >= 60)
        {
            letter = letter + sign;
        }

        // Do one print statement outside if else statements
        Console.WriteLine($"{letter} is the letter grade you have earned.");
        
        // Determine if the user passed
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else
        {
            Console.WriteLine("I am sorry you didn't pass, but I know you can do it if you try again!");
        }
    }    
}