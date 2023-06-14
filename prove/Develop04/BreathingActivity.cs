using System;
using System.IO;

// ### CLASS ################################################ //
// class to run the breathing activity
public class BreathingActivity : Activity
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // variable to hold the activity name
  private string _breathingName = "Breathing Activity";
  // variable to hold the activity description
  private string _breathingDescription = "relax by guiding you through sets of timed in breaths and out breaths.";
  // variable to hold the in breath time in seconds
  private int _inhaleTime;
  // variable to hold the out breath time in seconds
  private int _exhaleTime; 

// ### CONSTRUCTORS ######################################### //
  // constructor to be able to use the RunAllBreathing method
  public BreathingActivity()
  {
    // nothing needed in here    
  }
  // constructor to set up for the Breathing Activity
  public BreathingActivity(string activityName, string description) : base (activityName, description)
    {
      // base variables are all done in the Activity base class      
    }

// ### METHODS ############################################## //
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

  // method to run everyting for the Breathing Activity
  public string RunAllBreathing()
  {    
    // create breathing object so the correct activity name and description are passed in
    // as well as all of the other things for the intro and the boolean
    BreathingActivity breathing = new BreathingActivity(_breathingName, _breathingDescription);
    // run the opening with the correct activity name & descriptiorn from using
    // the object while running this inherited method from the Activity class
    breathing.Opening();
    // run the class specific set inhale time method
    SetInhaleTime();
    // run the class specific set exhale time method
    SetExhaleTime();
    // run prepare with the correct activity name from using the object 
    // while running this inherited method from the Activity class
    breathing.PrepareActivity();    
    // run the central part of the Breathing Activity with the object while running this inherited method 
    // from the Activity class so it works properly by including the boolean and _sessionLength values   
    breathing.RunActivity(BreathingExercises);   
    // run end activity message in this inherited method from the Activity class
    EndActivity();
    // run the closing with the correct activity name with the object while running this inherited
    // method from the Activity class then save the choice of the user in the choice variable  
    string choice = breathing.Closing();
    // return the user's choice
    return choice;
  }
}