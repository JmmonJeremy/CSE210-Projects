using System;
using System.IO;

// ### CLASS ################################################ //
// class to with methods to validate inputs
public class Validator
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // boolean to run the StringNumberCheck method's while loop
  private bool _isNumber;
  // variable to start the validation while loop in the StringNumberCheck
  // and is then used to hold the string number entered by the user converted to an int
  private int _number;
  // variable to hold the direction for input statement
  private string _inputDirection;
  // variable to run the ConfirmAnswer method's while loop
  private string _confirm;

// ### CONSTRUCTORS ######################################### //
  // constructor set up for the StringNumberCheck
  public Validator(string inputDirection)
  {
    // set the boolean to false to run the StringNumberCheck while loop
    _isNumber = false;
    // set the value to 0 to run the StringNumberCheck while loop
    _number = 0;
    // set the _inputDirection equal to the inputDirection passed in
    _inputDirection = inputDirection;
    // set the _confirm variable to "no" run the while loop
    _confirm = "no";
  }

// ### METHODS ############################################## // 
  // method to verfity a specified number range was entered

  // method to confirm the user entered what they wanted to
  public string ConfirmEntry()
  {   
    // create a variable to hold and return the user's entry
    string entry = "none"; 
    // run a while loop until the user is confirms their entry with "yes"
    while (_confirm != "yes") 
    {
      // gives user direction on what to enter
      Console.Write(_inputDirection);
      // change the color of the text to green so the answer is typed in green
      Console.ForegroundColor = ConsoleColor.Green;
      // store the entry to the direction for input
      entry = Console.ReadLine();
      // reset the text color to the original settings
      Console.ResetColor();
      // tell the user what they entered
      Console.Write("You entered: ");
      // change the color of the text to green
      Console.ForegroundColor = ConsoleColor.Green;
      // show the user's entry
      Console.WriteLine($"{entry}");
      // reset the text color to the original settings
      Console.ResetColor();
      // tell the user how to confirm or reject their entry
      Console.Write("Is this what you want to enter (yes or no)? ");
      // record their answer to stop or continue running the while loop
      _confirm = Console.ReadLine();
    }
    return entry;
  }

  // method to insure the input was a number
  public int StringNumberCheck()
  {
     // run this until they enter a number
      while (!_isNumber || _number < 1)
      {  
        // gives user direction on what to enter
        Console.Write(_inputDirection);
        // change the color of the text to green so the answer is typed in green
        Console.ForegroundColor = ConsoleColor.Green;
        // store the answer to the direction for input
        string answer = Console.ReadLine();
        // reset the text color to the original settings
        Console.ResetColor();
        // ensure the user is entering a number by testing it
        // convert the string to an int if it is a number
        // and change number variable to user's answer to the direction for input
        // and sets checker boolean to true or false
        _isNumber = int.TryParse(answer, out _number);
        // if it is not a number or is less than 1 have them enter again
        if (!_isNumber || _number < 1)
        {
          // change the color of the text to green so the answer is typed in green
          Console.ForegroundColor = ConsoleColor.Green;
          Console.Write(answer); 
          // reset the text color to the original settings
          Console.ResetColor();
          // let the user know waht they entered isn't valid and what is
          Console.WriteLine(" is not a valid number, you must enter a number of 1 or greater.");
          // ask user to try again
          Console.WriteLine("Please try again by entering a valid number.");
        }
      }
      // returns user's answer to direction variable
      // checker turns answer from user stored in answer variable
      // into the value being stored in the int number variable 
      return _number;
  }
}