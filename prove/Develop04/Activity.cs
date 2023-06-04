using System;
using System.IO;
using System.Threading;
using System.Diagnostics;

// ### CLASS ################################################ //
// class to hold opening and closing messages for activities
public class Activity
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // variable to hold a generic activity name
  private string _genericName;
  // variable to hold the generic activity description
  private string _genericDescription;
  // variable to hold the activity's name  
  private string _activityName;
  // variable to hold the activity's description
  private string _description;
  // variable to hold the session length in seconds  
  private int _sessionLength;
  // varialbe to hold the session length prompt
  private string _sessionLengthPrompt;
  // boolean to run an acitivity loop
  private bool _doActivity; 
  // list to hold the spinner animaton symbols
  private List<string> _spinnerSymbols= new List<string>()
  {
    (Convert.ToChar(14)).ToString(),
    (Convert.ToChar(30)).ToString(),
    (Convert.ToChar(16)).ToString(),
    (Convert.ToChar(31)).ToString(),    
    (Convert.ToChar(17)).ToString(),
    (Convert.ToChar(14)).ToString(),    
    "|",         
    "/",
    "-",
    "\\",
    (Convert.ToChar(14)).ToString(),
    "|",
     "/",
     "-",
    "\\",
    (Convert.ToChar(14)).ToString(),
    (Convert.ToChar(18)).ToString(),
    (Convert.ToChar(29)).ToString(),        
    (Convert.ToChar(18)).ToString(),  
    (Convert.ToChar(29)).ToString(),
    
  };

// ### CONSTRUCTORS ######################################### //
  // constructor to be able to use set generic variables
  //  and to use the get methods to get the variables values
  public Activity()
  {
    // set the value of the _genericName
    _genericName = "activity";
    // set the value of the _genericDescription
    _genericDescription = "because being active and doing something is good for your health and well being.";    
  }
  // constructor to set up the activity
  public Activity(string activityName, string description) 
  {
    _activityName = activityName;
    _description = description;
    _sessionLengthPrompt = "How long, in seconds, would you like for your activity session? ";
    _doActivity = true;
  }

// ### METHODS ############################################## //
  // getter method to get the _genericName
  public string GetGenericName()
  { 
    return _genericName;
  }  

  // setter method for the _spinnerSymbols list
  public void SetSpinnerSymbols(bool clear, List<string> spinnerSymbols)
  {
    if (clear) 
    {
      // reference source: https://www.tutorialspoint.com/how-to-empty-a-chash-list
      // empty the list of any content
      _spinnerSymbols.Clear();
    }
    // reference source: https://www.tutorialspoint.com/How-to-append-a-second-list-to-an-existing-list-in-Chash
    // add the items to the list
    _spinnerSymbols.AddRange(spinnerSymbols);        
  }

  // method to get the _spinnerSymbols list
  public List<string> GetSpinnerSymbols()
  {
    return _spinnerSymbols;
  }

  // // setter method to set the _doActivity boolean
  // public void SetDoActivity(bool doActivity)
  // { 
  //   _doActivity = doActivity;
  // } 

  // // getter method to get the _doActivity boolean
  // public bool GetDoActivity()
  // { 
  //   return _doActivity;
  // } 

  // method to display the opening message
  public int Opening() 
  {
    // clear the console screen
    Console.Clear();
    // welcome the user and explain what will happen
    Console.WriteLine($"Welcome to the {_activityName}.\n");
    Console.WriteLine($"This activity will help you {_description}.\n");   
    // create a validator object to run its method with
    // and pass the prompt question into the object
    Validator validator = new Validator(_sessionLengthPrompt);
    // set the _sessionLength equal to the result of the StringNumberCheck method
    _sessionLength = validator.StringNumberCheck();
    return _sessionLength;
  }
  
  // method to prepare to start an activity
  public void PrepareActivity()
  {
    // clear the console screen
    Console.Clear();
    // display a message on the console telling the 
    // user to prepare to begin the activity
    Console.WriteLine($"Prepare to begin your {_activityName}. . .");
    // pause for 6 seconds and display a spinner while doing so
    Spinner(ConsoleColor.Cyan, ConsoleColor.DarkBlue, 6);
    // add an empty line after preparing the user to start
    Console.WriteLine();
  }

  // method to congratualate the user on completing the activity
  public void EndActivity()
  {
    // congratualat the user on completing the activity
    Console.WriteLine("Excellent job!!!");
    // pause for 6 seconds and display a spinner while doing so
    Spinner(ConsoleColor.Cyan, ConsoleColor.DarkBlue, 6);
  }

  // method to display the closing message
  public string Closing()
  {
    // let the user know they have completed the session and
    // how long they did it for with an empty line before it
    Console.WriteLine($"\nYou have completed another {_sessionLength} seconds of the {_activityName}.");
    // tell the user to press enter to continue with an empty line before it
    Console.Write("\nPress enter to go back to the main menu or 'quit' to end the program: ");
    // create a variable to return "4" if they enter quit or anything else to continue
    string choice = Console.ReadLine();
    // clear the console screen
    Console.Clear();    
    // set return "4" to end the program if the enter quit
    if (choice == "quit")
    {
      choice = "4";
    }
    return choice;
  }

  // method to run a generic activity
  public void ActivityExercises()
  {
    // direct the user to do their activity
    Console.WriteLine("Commence with your decided activity now!");
  }


  // method to run the activity for the designated amount of time
  public void RunActivity(int seconds, Action method)
  {
    // set the beginning time for the activity
    DateTime beginTime = DateTime.Now;
    // set the finishing time for the activity by adding the seconds the user 
    // decides on for the length of the activity to the beginning time here
    DateTime finishTime = beginTime.AddSeconds(seconds);  
    // run a while/loop until time has elapsed
    while (_doActivity)
    {
      // put the current time in a variable
      DateTime currentTime = DateTime.Now;
      // when the current time has not yet reached the finish time
      if (currentTime < finishTime)
      {
        // reference source: https://forum.unity.com/threads/how-do-you-pass-a-void-method-into-another-method-as-a-parameter.362005/
        // run the activity method
        method.Invoke();        
      }
      // when the current time reaches the finish time
      else
      {
        // set _doActivity to false to end the activity while/loop
        _doActivity = false;
      }
    }
  }

  // Reference sources: http://programmingisfun.com/consolecolor_parameter/
  // method to display the time spinner animation
  public void Spinner(ConsoleColor countColor, ConsoleColor symbolColor, int seconds)
  {
    // ### SET UP VARIABLE TO USE IN WHILE LOOP
    // boolean created to run the loop until time is complete so it doesn't crash
    // due to the DateTime seconds and the Thread.Sleep seconds not matching
    // up because of the added time running the program takes with every loop
    bool run = true;
    // variables to adjust the Thread.Sleep number for
    // the amount of time to run the program
    int adjustment = 0;
    int threadNumber = 0;
    // create a starting time for the spinner
    DateTime start = DateTime.Now;
    // // use the starting time to help troubleshoot the timing of the timer
    // Console.WriteLine(start);
    // create an ending time for the spinner
    DateTime end = start.AddSeconds(seconds);
    // // use the ending time to help troubleshoot the timing of the timer    
    //  Console.WriteLine(end);
    // create a variable to hold the index number starting at 0    
    int i = 0;
    // create a variable to hold the while loop rotations 
    int rotation = 0;
    // create a variable to hold the "." or "#" for the time countDown
    string countDown = "";
    // ### TIMER WHILE LOOP
    // create a while loop to run the spinner until time expires
    // // 2 while loop settings I started with that were out of sinc with # countDown
    // // while (DateTime.Now <= end.Subtract(TimeSpan.FromMilliseconds(end.Millisecond)).AddMilliseconds(DateTime.Now.Millisecond + 500))
    // // while (DateTime.Now <= end.AddSeconds(2))
    // use the run boolean to run it, so it doesn't crash due to 
    // variations between the DateTime & the Thread.Sleep time
     while (run == true)
    {
      // ### LOAD VARIABLE VALUES
      // create a variable to help capture the time of running the loop
      DateTime beginning = DateTime.Now;
      // add one to start the count of the first rotation of the while loop      
      rotation += 1;
      // create a variable to hold the symbol to be displayed
      // from the list during this rotation of the while loop
      string symbol = _spinnerSymbols[i];
      //  ### DISPLAY COUNTDOWN TO THE CONSOLE
      // if it's been 1 second or 4 rotations
      if (rotation % 4 == 0)
      {
        // assignt the rotation number divided by four in other 
        // words the seconds value to the countDown variable
        countDown = $"{(rotation/4).ToString()}";
        // color the number light blue
        Console.ForegroundColor = countColor;
      }
      // if it is not the second count rotation
      else
      {
        // assign a dot to the countDown variable
        countDown = ".";
        // color the dot and bracket for the clock spinner yellow
        Console.ForegroundColor = ConsoleColor.Yellow;        
      }
      // display a dot or number every while/loop rotation
      Console.Write($"{countDown}(");
      // color the background of the spinner clock dark blue
      Console.BackgroundColor = symbolColor;
      // display the symbols mimicking clock hands within the spinner clock
      Console.Write($" {symbol} ");      
      // reset color to the original settings
      Console.ResetColor(); 
      // color the right outside bracket of the clock yellow
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.Write($") ");
      // reset color to the original settings
      Console.ResetColor();
      // ### PAUSE THE PROGRAM SO 1 ROTATION IS 1/4 SECOND
      // if the adjustment is less than 250 
      if (adjustment < 250)
      {
        // then subtract the adjustment from 250 and set the  
        // variable that sets the sleep time to that result          
        threadNumber = 250 - adjustment;       
      }
      // if the adjustment is equal to or greater than 250
      if (adjustment >= 250)
      {
        // then set the variable for the seep time to 0 so
        // the program doesn't crash from an - number error
        threadNumber = 0;        
      }
      // set and run the program pause time
      Thread.Sleep(threadNumber);
      // ### SET TO DISPLAY A NEW CLOCK ROTATION
      // back up to right in front of the countDown dot or #
      // erase the space in front of it and back up again      
      Console.Write("\b\b\b\b\b\b \b");
      // if the rotation number has no left over number when divided by 4 & then by
      // 10 or in other words when 10 seconds has been displayed by the countDown
      // ### START COUNT OF 10 OVER ON THE SAME LINE
      if ((Convert.ToDouble(rotation) / 4) % 10 == 0)
      {
        // erase the spinner clock
        Console.WriteLine($"\b      ");
        // put the cursor at the beginning of the line
        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
        // erase the line
        Console.WriteLine("                                                                      ");
        // put the cursor at the beginning of the line again to start the next count of 10
        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);       
      }
      // ### END THE WHILE LOOP AND TIMER
      // if the rotation divided by four is equal to the timer length in seconds
      // in other words when the time for the timer equals the timer end time
      if (rotation / 4 == seconds)
      {
        // change the boolean to false for running the while loop 
        run = false;
        // erase the spinner clock & move to a new line
        Console.Write($"      \n");
        // // use the time this ends to match the cycle through this method
        // // to the passing of 1 second with DateTime - used for debugging
        // Console.WriteLine(DateTime.Now);
        // end while loop right now
        return;
      } 
      // ### IF TIME IS NOT EXPIRED - SET UP FOR NEXT WHILE LOOP ROTATION
      // increae the number for the index number variable
      // by 1 to move to the next symbol in the list
      i++;
      // when the index # variable reached the end of the list
      // on this while/loop rotation & the increase above set it
      // past the last index number or equal to the list length
      if (i == _spinnerSymbols.Count)
      {
        // set the idex to start at the beginning of the list again
        i = 0;
      }
      // save the ending time it took to run through this code in a variable
      DateTime ending = DateTime.Now;
      // subtract the beginning time for running this while/loop rotation code from 
      // the ending time for running this rotation of method's while/loop code to get 
      // the time it takes to run this rotation and save it in a variable to be 
      // subtracted from the sleep time on the next rotation of the while/loop
      TimeSpan ts = (ending - beginning);
      // convert the time it takes to run this rotation's while/loop code into milliseconds,
      // adjust amount to subtract for the prior rotation - reached through trial & error,
      // remove the time the thread sleep was orginally set to for 1/4 of a second,
      // & store the number converted to an int so it can be subtracted from the sleep time setting      
      adjustment = Convert.ToInt32(ts.TotalMilliseconds + 8 - 250);      
    }
    // // used for trouble shooting to see if the elapsed time matched the setting for the timer
    // Console.WriteLine($"Time Outside while loop: {DateTime.Now}");     
  }
}