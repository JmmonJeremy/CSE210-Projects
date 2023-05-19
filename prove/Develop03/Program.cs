using System;

// class to run the program
class Program
{
    // method that runs the program
    static void Main(string[] args)
    { 
        // test code
        Eraser eraser = new Eraser("fantastic");
        Console.WriteLine(eraser.GetPlaceHolder());
        // ### PROGRAM DESCRIPTION ##################################
        // color the text to make sure the user sees the instructions
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        // explain how the program works with 2 empty lines afterwards
        Console.WriteLine("This program is designed to help you memorize any scripure of your choice.");
        // color the text to make sure the user sees the instructions
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("It does so by replacing one word with a placeholder each time you press enter.");
         // return the text color to yellow to make sure the user sees the instructions
        Console.ForegroundColor = ConsoleColor.DarkYellow; 
        Console.WriteLine("The program ends when all of the words are replaced or when 'quit' is entered.\n\n");
        // reset the text color to previous settings
        Console.ResetColor();

        // ### GETTING SCRIPTURE SOURCE
        // get the name of the volume the scripture comes from
        // create a Source object to acces its methods
        Source sourceMethods = new Source();
        // run the selectVolume method with the sourceMethods object
        string volume = (sourceMethods.SelectVolume());
        
        // ask the user for the book that the scripture comes from
        Console.Write("Please enter the name of the book that the scripture comes from: ");
        // capture book in a variable to use
        string book = Console.ReadLine();
        // ask the user for the chapter that the scripture comes from
        Console.Write("Please enter the name of the book that the scripture comes from: ");
        // capture scripture in a variable to use
        string scripture = Console.ReadLine();
          
    }

}