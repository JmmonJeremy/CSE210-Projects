using System;
using System.IO;

// ### CLASS ################################################ //
// class to run the breathing activity
public class BreathingActivity : Activity
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // variable to hold a generic activity name
  private string _breathingName;
  // variable to hold the generic activity description
  private string _breathingDescription;
  // variable to hold the in breath time in seconds
  int _inhaleTime;
  // variable to hold the out breath time in seconds
  int _exhaleTime; 

// ### CONSTRUCTORS ######################################### //
  // constructor to be able to use set breathing variables
  //  and to use the get methods to get the variables values
  public BreathingActivity()
  {
    // set the value of the _genericName
    _breathingName = "Breathing Activity";
    // set the value of the _genericDescription
    _breathingDescription = "relax by guiding you through sets of timed in breaths and out breaths";    
  }
  // constructor to set up for the Breathing Activity
  public BreathingActivity(string activityName, string description) : base (activityName, description)
    {
      // base variables are all done in the Activity base class      
    }

// ### METHODS ############################################## //
  // getter method to get the _breathingName
  public string GetBreathingName()
  { 
    return _breathingName;
  }

  // getter method to get the _breathingDescription
  public string GetBreathingDescription()
  { 
    return _breathingDescription;
  }  

  // method to guide the user when breathing in
  public void SetInhaleTime()
  {
    // add an empty line before doing this
    Console.WriteLine();
    // store the question asking the user how long they would 
    // like the in breath to last in a variable to pass in
    string promptQuestion = "For this exercise, how long in seconds would you like your inhalation to last? ";
    // create a validator object to run its method with
    // and pass the prompt question into the object
    Validator validator = new Validator(promptQuestion);
    // set the _inhaleTime equal to the result of the StringNumberCheck method
    _inhaleTime = validator.StringNumberCheck();    
  }

  // method to guide the user when breathing out
  public void SetExhaleTime()
  {
    // add an empty line before doing this
    Console.WriteLine();
    // store the question asking the user how long they would 
    // like the out breath to last in a variable to pass in
    string promptQuestion = "For this exercise, how long in seconds would you like your exhalation to last? ";
    // create a validator object to run its method with
    // and pass the prompt question into the object
    Validator validator = new Validator(promptQuestion);
    // set the _exhaleTime equal to the result of the StringNumberCheck method
    _exhaleTime = validator.StringNumberCheck();    
  } 

  // method to direct the breathing exercises
  public void BreathingExercises()
  { 
    // save the original contents of the _spinnerSymbols list
    List<string> clonedList = new List<string>(GetSpinnerSymbols());
    // change the contents of the _spinnerSymbols for the 
    // Breathing exercise inhale and exhale timed counts
    // fill a new list with the contents for the Breathing exercises
    List<string> breathingSymbols = new List<string>()
    {
      (Convert.ToChar(3)).ToString(),
    };
    // set the _spinnerSymbols list to a new value    
    SetSpinnerSymbols(true, breathingSymbols);
    // display a message for the user to breath in
    Console.WriteLine("Inhale . . deeply and slowly. . .");
    // display a count and clock spinner for the inhalation time
    Spinner(ConsoleColor.Magenta, ConsoleColor.DarkMagenta, _inhaleTime);
    // display a message for the user to breath out
    Console.WriteLine("Exhale . . slowly and completely. . .");
    // display a count and clock spinner for the exhalation time
    Spinner(ConsoleColor.Magenta, ConsoleColor.DarkMagenta, _exhaleTime); 
    // add an empty line after the methods have run
    Console.WriteLine();    
    // set the _spinnerSymbols list to the original contents    
    SetSpinnerSymbols(true, clonedList);
  }
}