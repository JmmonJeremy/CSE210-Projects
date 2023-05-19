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
        // run the setVolume method with the sourceMethods object
        // to have the user set the string value of the volume
        sourceMethods.SetVolume();
        // run the setBook method with the sourceMethods object
        // to have the user set the string value of the book
        sourceMethods.SetBook();
        // run the setChapter method with the sourceMethods object
        // to have the user set the string value of the chapter
        sourceMethods.SetChapter();
        // run the setVerse method with the sourceMethods object
        // to have the user set the string value of the verse
        sourceMethods.SetVerse();
        // ask the user how many verses are in the scripture
        Console.Write("How many verses does your scripture have? ");
        // convert the string to an int and store in a variable
        int verses = int.Parse(Console.ReadLine());
        // set the endVerse if there is more than one verse
        if (verses > 1)
        {
            // run the setEndVerse method with the sourceMethods object
            // to have the user set the string value of the end verse
            sourceMethods.SetEndVerse();
        }

        // put the reference source together in a string
        Console.WriteLine();
        string source = $"({sourceMethods.GetVolume()})\n\n{sourceMethods.GetBook()} {sourceMethods.GetChapter()}:{sourceMethods.GetVerse()}";
        // get the scripture into a variable
        string scripture = "Jesus said unto her, I am the resurrection, and the life: he that believeth in me, though he were dead, yet shall he live:";

        // load the source and the scripture into the 
        // chalkboard constructor to create an object
        Chalkboard chalkboard = new Chalkboard(source, scripture);
        // load the scripture word list into a variable
        List<string> scriptureWords = chalkboard.GetVerse();

        // create a variable to represent quit being entered
        string quit = "Run loop";

        // create a loop to run until the user enters "quit"
        // or until all the words in the scripture are covered
        while (quit != "quit")
        {
            // clear the console screen
            Console.Clear();
            // display the scritpure source
            Console.Write($"{source}  ");
            // display the scripture to the screen
            foreach (string word in scriptureWords)
            {
                Console.Write($"{word} ");
            }
            // add two empty lines after the scritpure
            Console.WriteLine("\n");
            // display instructions for the user
            Console.Write("Press enter to hide a word or enter 'quit' to exit: ");
            // gather and use the input from the user
            Console.ReadLine();
            // replace a word if they press enter
        }         
    }
}