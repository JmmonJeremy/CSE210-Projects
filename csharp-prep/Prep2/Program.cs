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
        string grade;

        // Determine grade from the percentage
        if (gradePercentage >= 90)
        {
            grade = "A";
            Console.WriteLine($"Your letter grade is an {grade}");
        }
        else if (gradePercentage >= 80)
        {
            grade = "B";
            Console.WriteLine($"Your letter grade is an {grade}");
        }
        else if (gradePercentage >= 70)
        {
            grade = "C";
            Console.WriteLine($"Your letter grade is an {grade}");
        }
        else if (gradePercentage >= 60)
        {
            grade = "D";
            Console.WriteLine($"Your letter grade is an {grade}");
        }
        else
        {
            grade = "F";
            Console.WriteLine($"Your letter grade is an {grade}");
        }
        
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