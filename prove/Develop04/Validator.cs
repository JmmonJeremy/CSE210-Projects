using System;
using System.IO;

// ### CLASS ################################################ //
// class to with methods to validate inputs
public class Validator
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // boolean to run the StringNumberCheck
  private bool _isNumber;
  // variable to start the validation loop in the StringNumberCheck
  // and is then used to hold the string number entered by the user converted to an int
  private int _number;
  // variable to hold the direction for input statement
  private string _inputDirection;

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
  }

// ### METHODS ############################################## //
  // method to present the menu to the user 
  // and to return the user's choice
  // method to insure the input was a number
  public int StringNumberCheck()
  {
     // run this until they enter a number
      while (!_isNumber || _number < 1)
      {  
        // gives user direction on what to enter
        Console.Write(_inputDirection);
        // store the answer to the direction for input
        string answer = Console.ReadLine();
        // ensure the user is entering a number by testing it
        // convert the string to an int if it is a number
        // and change number variable to user's answer to the direction for input
        // and sets checker boolean to true or false
        _isNumber = int.TryParse(answer, out _number);
        // if it is not a number or is less than 1 have them enter again
        if (!_isNumber || _number < 1)
        {
          Console.WriteLine("\nYour entry was not a valid number, you must enter a number of 1 or greater.");
          Console.WriteLine("Please try again by entering a valid number.\n");
        }
      }
      // returns user's answer to direction variable
      // checker turns answer from user stored in answer variable
      // into the value being stored in the int number variable 
      return _number;
  }
}