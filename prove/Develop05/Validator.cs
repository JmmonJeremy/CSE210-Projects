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
  // variable to set the value to be checked if _inputDirection is not being displayed
  private string _entry;
  // variable to hold the direction for input statement
  private string _inputDirection;
  // variable to run the ConfirmAnswer method's while loop
  private string _confirm;

// ### CONSTRUCTORS ######################################### //
  // constructor set up for the using the methods
  public Validator(string entry, string inputDirection)
  {
    // set the boolean to false to run the StringNumberCheck while loop
    _isNumber = false;
    // set the value to 0 to run the StringNumberCheck while loop
    _number = 0;
    // set the _entry to equal to the entry passed in
    _entry = entry;
    // set the _inputDirection equal to the inputDirection passed in
    _inputDirection = inputDirection;
    // set the _confirm variable to "no" run the while loop
    _confirm = "no";
  }

// ### METHODS ############################################## // 
  // method to verfity a specified number range was entered

  // method to confirm the user entered what they wanted to
  public string ConfirmEntry(string usePrompt)
  {  
    // create a variable to show if the while loop has cycled
    int cycle = 0; 
    // create a variable to hold and return the user's entry
    string entry = "none"; 
    // run a while loop until the user is confirms their entry with "yes"
    while (_confirm != "yes") 
    {
      // add 1 to the cycle variable for every cycle
        cycle++; 
      // determine wether to use the question promptor not
      if (usePrompt != "No prompt" || cycle > 1)
      {  
        // add an empty line before the prompt
        Console.WriteLine();        
        // gives user direction on what to enter
        Console.Write(_inputDirection);      
        // change the color of the text to green so the answer is typed in green
        Console.ForegroundColor = ConsoleColor.Green;
        // store the entry to the direction for input
        entry = Console.ReadLine();
        // reset the text color to the original settings
        Console.ResetColor();
      }
      // if no prompt is being used
      else
      {
        // set answer equal to the value _answer was passed in the constructor
        entry = _entry;
      }
      // add an empty line before the statement
      Console.WriteLine();
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
  public int StringNumberCheck(string usePrompt, string confirm)
  {
    // create a variable to show if the while loop has cycled
    int cycle = 0;
    // create a variable to hold and return the user's entry
    string answer = "none";
    // run this until they enter a number
    while (!_isNumber || _number < 1)
    { 
      // add 1 to the cycle variable for every cycle
      cycle++;      
      // determine wether to use the question promptor not
      if (usePrompt != "No prompt" || cycle > 1)
      {
        // add an empty line before the prompt
        Console.WriteLine();
        // gives user direction on what to enter
        Console.Write(_inputDirection);        
        // change the color of the text to green so the answer is typed in green
        Console.ForegroundColor = ConsoleColor.Green;
        // store the answer to the direction for input
        answer = Console.ReadLine();
        // reset the text color to the original settings
        Console.ResetColor();
      }
      // if no prompt is being used
      else
      {
        // set answer equal to the value _entry was passed in the constructor
        answer = _entry;
      }
      // ensure the user is entering a number by testing it
      // convert the string to an int if it is a number
      // and change number variable to user's answer to the direction for input
      // and sets checker boolean to true or false
      _isNumber = int.TryParse(answer, out _number);
      // if it is not a number or is less than 1 have them enter again
      if (!_isNumber || _number < 1)
      {
        // add an empty line before the statement
        Console.WriteLine();
        // change the color of the text to green so the user's input is typed in green
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(answer); 
        // change the color of the text to red to warn the user
        Console.ForegroundColor = ConsoleColor.Red;
        // let the user know waht they entered isn't valid and what is
        Console.Write(" is not a valid number");
        // reset the text color to the original settings
        Console.ResetColor();
        Console.Write(", ");
        // change the color of the text to yellow to have it stand out
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("you must enter a whole number of 1 or greater.");
        // reset the text color to the original settings
        Console.ResetColor();
        // ask user to try again
        Console.WriteLine("Please try again by entering a valid number.");
      }
      // if the user entered a valid number
      else if (confirm == "Do ConfirmEntry")
      {
        // CONFIRM THIS IS WHAT THE USER WANTS TO DO      
        // create a validator object to run its method with and 
        // pass the prompt question into the object and 
        // the user's selection to be confirmed correct by the user 
        Validator validator1 = new Validator(_number.ToString(), _inputDirection);    
        // set the stringSelection equal to the string the ConfirmEntry method returns and
        // set the method to not use the prompt the first time the method is used
        // set a boolean with int.TryParse to catch user entering no and then entering an invalid response
        _isNumber = int.TryParse(validator1.ConfirmEntry("No prompt"), out _number);             
      }      
    }
    // returns user's answer to direction variable
    // checker turns answer from user stored in answer variable
    // into the value being stored in the int number variable 
    return _number;
  }

  // method to validate a number entered to 
  // select an option from a list of choices
  public string SelectionCheck(int upperLimit)
  {    // create a variable to hold the user's option selection as a string
    string stringSelection = "";   
    // set numberSelection to run the while loop
    int numberSelection = upperLimit + 1; 
    // while user has not entered a number that corresponds to an available option
    while(numberSelection < 1 || numberSelection > upperLimit)
    {       
      // display the prompt to the user
      Console.Write(_inputDirection);      
      // change the color of the text to green
      Console.ForegroundColor = ConsoleColor.Green;
      // store the entry in the numberSelection variable
      stringSelection = Console.ReadLine();    
      // reset the background color to original settings
      Console.ResetColor();      
      // VERIFY THE ENTRY IS A NUMBER ABOVE 0
      // create a validator object to run its method with and
      // pass the prompt question into the object and
      // the user's selection to be verified as a number     
      Validator validator = new Validator(stringSelection, _inputDirection);    
      // using the StringNumberCheck method convert the string 
      // to an int to be used to run or end the while loop 
      // and stop a prompt question from being displayed the 1st time
      numberSelection = validator.StringNumberCheck("No prompt", "Don't ConfirmEntry");
      // VERITY THE ENTRY IS A NUMBER LISTED NEXT TO AN OPTIONS
      // if the response is not one of the numbers listed to choose from
      if (numberSelection > upperLimit)
      {        
        // inform the user their entry was invalid, tell them what is valid, and to try again.
        Console.Write($"\nYou entered '");
        // change the color of the text to green to indicate the user's entry
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(numberSelection);
        // reset the text color to the original settings
        Console.ResetColor();
        Console.Write("', ");
        // change the color of the text to red to alert the user
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("which is not recognized as a valid choice.");
        // reset the text color to the original settings
        Console.ResetColor();
        Console.Write("Your entry must be ");
        // change the color of the text to yellow to have it stand out
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write($"a number from '1 to {upperLimit}' ");
        // reset the text color to the original settings
        Console.ResetColor();
        Console.WriteLine("to be a valid choice."); 
        Console.Write("Try again by entering ");
        // change the color of the text to yellow to have it stand out
        Console.ForegroundColor = ConsoleColor.DarkYellow;      
        Console.WriteLine("one of the numbers next to a selection.\n");
        // reset the text color to the original settings
        Console.ResetColor();
      }
      // if the user entered a valid and available option
      else
      {
        // CONFIRM THIS IS WHAT THE USER WANTS TO DO      
        // create a validator object to run its method with and 
        // pass the prompt question into the object and 
        // the user's selection to be confirmed correct by the user 
        Validator validator1 = new Validator(stringSelection, _inputDirection);    
        // set the stringSelection equal to the string the ConfirmEntry method returns and
        // set the method to not use the prompt the first time the method is used
        // set a boolean with int.TryParse to catch user entering no and then entering an invalid response
        bool usable = int.TryParse(validator1.ConfirmEntry("No prompt"), out numberSelection);
        // if the user entered an invalid response
        if (!usable || numberSelection < 1 || numberSelection > upperLimit)
        {
          // set the numberSelection to run the while loop
          numberSelection = upperLimit + 1;
          // enter an empty line before showing the prompt to the user again
          Console.WriteLine();
        }        
      }      
    }    
    return numberSelection.ToString();
  }
}