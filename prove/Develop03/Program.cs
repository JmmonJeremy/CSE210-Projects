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

        // print the reference source to the console
        Console.WriteLine();
        Console.WriteLine($"{sourceMethods.GetVolume()}    {sourceMethods.GetBook()} {sourceMethods.GetChapter()}:{sourceMethods.GetVerse()}");

       
          
    }

}