using System;

class Program
{
    static void Main(string[] args)
    {
        // Greet the user that is here to learn
        Console.WriteLine("Welcome to the Prep3 demonstration C# learners!");
        Console.WriteLine("");

        // Create variable to convert string answer into int
        int number = 1;
        // Create a list to hold the numbers
        List<int> numbers = new List<int>();
        // Create variable to hold the sum
        int sum = 0;
       
        // // Ask user for a list of numbers
        // Console.WriteLine("Enter a list of numbers, type 0 when finished."); 
        // Ask user for a list of positive & negative numbers   
        Console.WriteLine("Enter a list of both positive and negative numbers, type 0 when finished.");  
        // Continue asking until 0 is entered
        while (number !=0)
        {
            Console.Write("Enter number: ");
            string answer = Console.ReadLine();
            // Convert string answer into int number
            number = int.Parse(answer);               
            // Put given numbers into a storage list
            if (number != 0)
            {
                numbers.Add(number);
            }
        
        }

        // Give the total of the numbers added together
        foreach (int num in numbers)
        {
            sum += num;        
        }
        Console.WriteLine($"The sum is: {sum}");

        // Give the average of the numbers in the list
        double total = numbers.Count;
        double ave = sum/total;
        Console.WriteLine($"The average is: {ave}");

        // Create varialbe to hold the largest number
        int max = numbers[0]; 
        // Give the largest number
        for (int i = 0; i < total; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }
        Console.WriteLine($"The largest number is: {max}");

        // Create varialbe to hold the smallest positive number
        int posMin = max; 
        // Give the smallest positive number
        for (int i = 0; i < total; i++)
        {
            if (numbers[i] < max && numbers[i] > 0)
            {
                posMin = numbers[i];
            }
        }
        Console.WriteLine($"The smallest positive number is: {posMin}");
        // Sort the list from smallest to largest & display them
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int digit in numbers)
        {
            Console.WriteLine(digit);
        }
    }
}