using System;
using System.IO;

// ### CLASS ################################################ //
// class with methods to validate user inputs
public class Validator
{
// ### VARIABLE ATTRIBUTES ################################## // 
  
  private bool _isNumber; // for 1 of 3 conditions of StringNumberCheck method's while loop 
  private int _number; // for 2 of 3 conditions StringNumberCheck method's while loop & user's entry converted  
  private string _entry; // holds value to be checked if user doesn't set value  
  private string _inputDirection; // holds the directions for user's input  
  private string _confirm; // condition for the ConfirmAnswer method's while loop & 3 of 3 for StringNumberCheck's 

// ### CONSTRUCTORS ######################################### //  
  public Validator(string entry, string inputDirection)
  {    
    _isNumber = false; // set to run the StringNumberCheck while loop    
    _number = 0; // set to run the StringNumberCheck while loop    
    _entry = entry; // used if "No prompt" is passed into method   
    _inputDirection = inputDirection; // used if "No prompt" is not passed into method    
    _confirm = "no"; // set to run the ConfirmEntry and StringNumberCheck while loops
  }

// ### METHODS ############################################## // 
  // method to confirm the user entered what they wanted to
  public string ConfirmEntry(string usePrompt)
  {      
    int cycle = 0; // shows if the while loop has cycled    
    string entry = "none"; // holds and returns the user's entry   
    while (_confirm == "no") 
    {      
      cycle++;       
      if (usePrompt != "No prompt" || cycle > 1) // determine wether to prompt the user for input
      {                  
        Console.Write($"\n{_inputDirection}");      
        Console.ForegroundColor = ConsoleColor.Green; entry = Console.ReadLine();        
        Console.ResetColor();
      }      
      else
      {        
        entry = _entry; // set to the value passed into the constructor
      }      
                                                    Console.Write("\nYou entered: ");      
      Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"{entry}");      
      Console.ResetColor();                         Console.Write("Enter ");
      Console.ForegroundColor = ConsoleColor.Red;   Console.Write("'no' "); 
      Console.ForegroundColor = ConsoleColor.Yellow;Console.Write("to go back ");
      Console.ResetColor();                         Console.Write("or ");
      Console.ForegroundColor = ConsoleColor.Yellow;Console.Write("to continue "); 
      Console.ForegroundColor = ConsoleColor.Green; Console.Write("press 'Enter': ");
      Console.ResetColor();      
      _confirm = Console.ReadLine(); // stops or continues running the while loop      
    }
    return entry; // returns answer user wants
  }

  // method to insure the input was a number
  public int StringNumberCheck(string usePrompt, string confirm)
  {    
    int cycle = 0; // shows if the while loop has cycled   
    string entry = "none";  // holds and returns the user's entry     
    _confirm = ""; // set so it won't restart the while loop if confirm != "Do ConfirmEntry"   
    while (!_isNumber || _number < 1 || _confirm == "no")
    {       
      cycle++;      
      // DETERMINE WETHER TO PROMPT USER FOR INPUT
      if (usePrompt != "No prompt" || cycle > 1) // prompt the user for input
      {        
        Console.Write($"\n{_inputDirection}");        
        Console.ForegroundColor = ConsoleColor.Green; entry = Console.ReadLine();        
        Console.ResetColor();
      }      
      else
      {        
        entry = _entry; // set to the value passed into the constructor
      }
      // ENSURE THE USER'S "entry" IS A NUMBER           
      // sets _isNumber boolean to true if entry is a number or false if it isn't
      // if it is a number it converts the string entry to an int _number 
      _isNumber = int.TryParse(entry, out _number);     
      if (!_isNumber || _number < 1) // if entry is not a number or is below 1
      {        
        Console.WriteLine();        
        Console.ForegroundColor = ConsoleColor.Green;      Console.Write(entry);        
        Console.ForegroundColor = ConsoleColor.Red;        Console.Write(" is not a valid number");        
        Console.ResetColor();                              Console.Write(", ");        
        Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("you must enter a whole number of 1 or greater.");        
        Console.ResetColor();                              Console.WriteLine("Please try again by entering a valid number.");
      }   
      // CONFIRM THIS IS WHAT THE USER WANTS TO DO   
      else if (confirm == "Do ConfirmEntry") // if the user entered a valid number above 0
      {         
        _entry = _number.ToString();         
        Console.Write("\nYou entered: ");        
        Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"{_entry}");
        Console.ResetColor();                         Console.Write("Enter ");
        Console.ForegroundColor = ConsoleColor.Red;   Console.Write("'no' "); 
        Console.ForegroundColor = ConsoleColor.Yellow;Console.Write("to go back ");
        Console.ResetColor();                         Console.Write("or ");
        Console.ForegroundColor = ConsoleColor.Yellow;Console.Write("to continue "); 
        Console.ForegroundColor = ConsoleColor.Green; Console.Write("press 'Enter': ");
        Console.ResetColor(); 
        _confirm = Console.ReadLine();                      
      }      
    }
    // returns user's entry to _inputDirection variable
    // checker turns entry from user into the value being stored in the int _number variable    
    return _number;
  }

  // method to validate a number entered to select an option from a list of choices
  public string SelectionCheck(int upperLimit, string runConfirm)
  {  
    // string runConfirm = "Do ConfirmEntry";      
    string stringSelection = "";  // holds the user's option selection as a string    
    int numberSelection = upperLimit + 1; // set to run the while loop
    // while user has not entered a number that corresponds to an available option
    while(numberSelection > upperLimit || _confirm == "no")
    {        
      Console.Write(_inputDirection); // displays menu options       
      Console.ForegroundColor = ConsoleColor.Green; stringSelection = Console.ReadLine();     
      Console.ResetColor();      
      // VERIFY THE ENTRY IS A NUMBER ABOVE 0      
      // pass the prompt question into the object and
      // the user's selection to be verified as a number     
      Validator validator = new Validator(stringSelection, _inputDirection);    
      // using the StringNumberCheck method convert the string 
      // to an int to be used to run or end the while loop 
      // and stop a prompt question from being displayed the 1st time
      numberSelection = validator.StringNumberCheck("No prompt", "Don't ConfirmEntry");
      // VERITY THE ENTRY IS A NUMBER LISTED NEXT TO AN OPTIONS      
      if (numberSelection > upperLimit) // if the response is not one of the numbers listed to choose from
      {         
                                                           Console.Write($"\nYou entered '");        
        Console.ForegroundColor = ConsoleColor.Green;      Console.Write(numberSelection);        
        Console.ResetColor();                              Console.Write("', ");        
        Console.ForegroundColor = ConsoleColor.Red;        Console.WriteLine("which is not recognized as a valid choice.");   
        Console.ResetColor();                              Console.Write("Your entry must be ");        
        Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write($"a number from '1 to {upperLimit}' ");        
        Console.ResetColor();                              Console.WriteLine("to be a valid choice."); 
                                                           Console.Write("Try again by entering ");       
        Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine("one of the numbers next to a selection.\n");        
        Console.ResetColor();
      }      
      else // if the user entered a valid and available option 
      { 
        if (runConfirm == "Do Confirm") // you want to confirm
        {       
          // CONFIRM THIS IS WHAT THE USER WANTS TO DO        
          _entry = numberSelection.ToString();        
                                                        Console.Write("\nYou entered: ");    
          Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"{_entry}");
          Console.ResetColor();                         Console.Write("Enter ");
          Console.ForegroundColor = ConsoleColor.Red;   Console.Write("'no' "); 
          Console.ForegroundColor = ConsoleColor.Yellow;Console.Write("to go back ");
          Console.ResetColor();                         Console.Write("or ");
          Console.ForegroundColor = ConsoleColor.Yellow;Console.Write("to continue "); 
          Console.ForegroundColor = ConsoleColor.Green; Console.Write("press 'Enter': ");                    
          Console.ResetColor(); 
          _confirm = Console.ReadLine(); 
          if (_confirm == "no") // if this is not what the user wants
          {          
            Console.WriteLine(); // enter an empty line before showing the prompt to the user again
          } 
        }
        else
        {
          _confirm = "";
        }            
      }      
    }    
    return numberSelection.ToString(); // return the users menu option selection
  }
}