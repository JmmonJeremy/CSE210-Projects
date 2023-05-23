using System;

// ### CLASS ################################################ //
// class to introduce and set up the resources for
// the scripture memorization program to work
public class SetUp
{
// ### VARIABLE ATTRIBUTES ################################## //
// to hold responde from user and 
// to run the while loop until the condition is met
string answer = "Run loop";
// used to run while loops and the ConfirmAnswer method
string confirmed = "Run loop";

// ### CONSTRUCTORS ######################################### //

// ### METHODS ############################################## //
// method to display the programs introduction & explanation
public void ProgramDescription()
{
  // put a line above the explanation
  Console.WriteLine("______________________________________________________________________________");
  // color the text to make sure the user sees the instructions
  Console.ForegroundColor = ConsoleColor.DarkYellow;
  // explain how the program works with 2 empty lines afterwards
  Console.WriteLine("This program is designed to help you memorize any scripure of your choice.");
  // color the text to make sure the user sees the instructions
  Console.ForegroundColor = ConsoleColor.Red;
  Console.WriteLine("It does so by replacing one word with a placeholder each time you press enter.");
    // return the text color to yellow to make sure the user sees the instructions
  Console.ForegroundColor = ConsoleColor.DarkYellow; 
  Console.WriteLine("The program ends when all of the words are replaced or when 'quit' is entered.\n");
  // reset the text color to previous settings
  Console.ResetColor();
}
} 