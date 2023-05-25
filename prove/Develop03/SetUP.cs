using System;
using System.Collections.Generic;
using System.IO;

// ### CLASS ################################################ //
// class to introduce and set up the resources for
// the scripture memorization program to work
public class SetUp
{
// ### VARIABLE ATTRIBUTES ################################## //
  // variable to run the while loop until the condition is met of
  // quit being entered or all words are hidden to end the program
  string _quit;
  // variable to count rotations of while/loop   
  int _rotations; 

// ### CONSTRUCTORS ######################################### //
  public SetUp()
  {
    // set _quit to "run loop" or not "quit" to run the loop 
    _quit = "Run loop";
    // started at -1 so the first while/loop isn't counted
    // because words aren't blanked out until the 2nd loop
    _rotations = -1;   
  }

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

  public void QuitLoop(List<Chalk> eachWord, string source, string scripture)
  {
    // create a loop to run until the user enters "quit"
    // or until all the words in the scripture are covered
    while (_quit != "quit" && _rotations != eachWord.Count)
    {      
      // count the rotations of the while loop, this is
      // used to avoid a change in the first rotation
      _rotations += 1;
      // clear the console screen
      Console.Clear();    
      // display the scritpure source
      Console.Write($"{source}  ");
      // create a Chalkboard object to run the methods with
      Chalkboard chalkboard = new Chalkboard(source, scripture);
      // check if all _hide boleans are true
      chalkboard.SetAllHidden(eachWord);      
      // when _allHidden = true
      if (chalkboard.GetAllHidden())
      { 
        // display all words hidden 
        chalkboard.EraseAllWords(eachWord);
        
        // TODO *** put in method to display the encouragement

        // stop the program
        break;
      } 
      // hide random words and display the results
      chalkboard.EraseRandomWords(eachWord);
      // add two empty lines after the scritpure
      Console.WriteLine("\n");
      // display instructions for the user
      Console.Write("Press enter to hide a word or enter 'quit' to exit: ");
      // gather and use the input from the user & end program if quit is entered
      // or replace a word if they press enter by starting while loop over again
      _quit = Console.ReadLine();      
    }
  } 
} 