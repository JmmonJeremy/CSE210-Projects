using System;
using System.Timers;

// ### CLASS ################################################ //
// class that initiates prompts on a set timed schedule
public class Initiator
{
// ### VARIABLE ATTRIBUTES ################################## //
  // TODO variable for set different times for the prompts
  public TimeSpan _newTime; 
  // vairable holding the time for timed prompts
  public System.Timers.Timer _countdown; 
  
// ### METHODS ############################################## //
  // method to determine the appropriate prompt time
  public TimeSpan SetTime()
  {           
    // variable to hold current time
    TimeSpan nowTime = DateTime.Now.TimeOfDay;
    // set number string to compare to determine the setTime value
    string nowHour = nowTime.Hours.ToString();   
    string nowMinutes = nowTime.Minutes.ToString();
    int minutesDigits = nowMinutes.Length;
    if (minutesDigits < 2)
    {
      nowMinutes = "0" + nowMinutes;
    }
      string nowSeconds = nowTime.Seconds.ToString();
    int secondsDigits = nowSeconds.Length;
    if (secondsDigits < 2)
    {
      nowSeconds = "0" + nowSeconds;
    }      
    string combine = nowHour+nowMinutes+nowSeconds;
    // convert string to int for comparison
    int compare = int.Parse(combine);
    // determine the start time by what time it is usig military times
    // the compared time is greater than 203000 between 8:30pm & midnight
    // so it will return a negative & inaccurate millisecond countdown
    // unless you add 24 hours to this time until midnight - not here
    // but in the StartTimer code that uses this time for setting countdown     
    if (compare < 103000 || compare >= 223000)
    {
      TimeSpan setTime = new TimeSpan(10,30,00);
      return setTime;
    }
    else if (compare < 123000)
    {
      TimeSpan setTime = new TimeSpan(12,30,00);
      return setTime;
    }
    else if (compare < 143000)
    {
      TimeSpan setTime = new TimeSpan(14,30,00);
      return setTime;
    }
    else if (compare < 153000)
    {
      TimeSpan setTime = new TimeSpan(15,30,00);
      return setTime;
    }
    else if (compare < 183000)
    {
      TimeSpan setTime = new TimeSpan(18,30,00);
      return setTime;
    }
    else if (compare < 203000)
    {
      TimeSpan setTime = new TimeSpan(20,30,00);
      return setTime;
    }
    else 
    {
      // here to detect failings by setting it to zero so milliseconds will go negative
      Console.WriteLine($"There is an error within the SetTime class. Here is the time that somehow caused the error: {nowTime}");
      TimeSpan setTime = new TimeSpan(00,0,00);
      return setTime;
    }
  }

  // method that starts the countdown to the Journal autoprompt
  // reference source: https://learn.microsoft.com/en-us/dotnet/api/system.timers.timer?view=net-8.0
  public void StartTimer(string showNextStart)
  {    
    // variable to hold the time for the next prompt
    TimeSpan setTime = SetTime();                  
    // variable to hold current time
    TimeSpan nowTime = DateTime.Now.TimeOfDay;
    // convert times into milliseconds
    double milliSetTime = (setTime).TotalMilliseconds;     
    double milliNowTime = Math.Round((nowTime).TotalMilliseconds);     
    // figure time for countdown
    double milliseconds = milliSetTime - milliNowTime;      
    // keep milliseconds positive from 8:30 PM to Midnight to avoid error
    if (milliseconds < 0)
    {        
      // if it is after 8pm in military time format
      if (DateTime.Now.Hour >= 20)
      {  
        // by adding 24 hours in milliseconds
        milliseconds = (milliSetTime + 86400000) - milliNowTime; 
      }
      // to cover any exception I have missed  
      else
      {
        Console.WriteLine($"There is an error within the StartTimer class. Here is the milliseconds of the countdown when it happened: {milliseconds}");
        // resets the milliseconds to a positive number 
        // so the program will keep running every 30 seconds
        milliseconds = 30000;
      } 

    }
    // convert milliseconds into hour and minutes for countdown display
    int hours = ((Convert.ToInt32(milliseconds/1000))/60)/60;
    double minutes = Math.Ceiling((milliseconds/1000)/60)%60;     
    // convert setTime into AM or PM for display     
    DateTime conversion = DateTime.Today.Add(setTime);
    string clockTime = conversion.ToString("hh:mm tt");
    // set varialbe to hold the date and time
    DateTime startTime = DateTime.Now;
    // set a condition for when to show this so at times the timer can 
    // stop, pass the entry into the journal menu, perform actions and
    // then restart seemlessly at the end and tell the user it is started
    if (showNextStart == "yes")
    {
      // display message showing the current time and the next time the TextStyles should inititiate
      Console.Write($"It is now {startTime.ToString("D")} at {startTime.ToString("t")} and ");
      // color these words to draw the user's attention to them
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.Write("the next Journal prompt is scheduled for ");
      // emphasize the next auto-prompt time by underlining & changing its color
      Console.ForegroundColor = ConsoleColor.Cyan;
      TextStyles.WriteUnderline(clockTime);
      // go back to the same color to catch the user's attenton to the end of the sentence
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine($" in {hours} hours and {minutes} minutes.\n");
      // reset the text color to what it was
      Console.ResetColor();
    }
    // variable to hold the countdown for the timer in milliseconds
    _countdown = new System.Timers.Timer(milliseconds);
    // runs the AutoPrompter when the timer ends and triggers the Elasped event
      _countdown.Elapsed += AutoPrompter;
    // stops the Elasped event for a timer from being raised more than once
      _countdown.AutoReset = false;   
    // sets the Elasped event to be raised 
      _countdown.Enabled = true;
                
  }

  // method to run the journal prompt and user choices
  // reference source: https://social.technet.microsoft.com/wiki/contents/articles/37252.c-timer-schedule-a-task.aspx
  private static void AutoPrompter(Object source, ElapsedEventArgs e)
  { 
    // color text to emphasize it
    Console.ForegroundColor = ConsoleColor.Red;
    // display a prompt to run the journal TextStyles underlined & capitalized for more emphasis       
    TextStyles.WriteUnderline("!!! REMINDER TO RUN A JOURNAL PROMPT AND MAKE AN ENTRY !!!\n");
    // reset color to original settings
    Console.ResetColor();   
    // give a random prompt and start the menu with its options
    // create a menu object from the Menu class
    Menu menu = new Menu();
    // use the DisplayMenu method to only display the menu thus
    // allowing the entry to pass into the Transition method 
    // from the Menu class in the TurnOn method found below 
    menu.DisplayMenu();
    // show them where to enter their selection
    Console.Write("\nSelection: ");        
    // reset the countdown to the next prompt
    Initiator start = new Initiator();
    // set variable to "no" to tell the StartTimer method found above not to
    // display the user messages when it starts the next auto-prompt timer
    string showNextStart = "no";
    // start the time without showing when the next autoprompt starts
    start.StartTimer(showNextStart);         
  }

  // method to turn on the auto-prompt initiator
  public void TurnOn()
  {    
    // create variables of underlined start & end NOTE
    string noteStart = "*NOTE->";   
    // Highlight the opening statement's background color in red to catch the user's attention     
    Console.BackgroundColor = ConsoleColor.DarkRed;     
    // display a message on how to stop the autoprompter
    Console.WriteLine("\n***STARTING THE JOURNAL AUTOPROMPTER***");
    // reset the color output for the console
    Console.ResetColor();
    // underline text in terminal
    // reference source: https://www.tutorialsteacher.com/csharp/csharp-static
    TextStyles.WriteUnderline(noteStart);
    Console.WriteLine(" To turn the autoprompter off, press Enter with the curser active in the program's terminal. ");        
    // display a message on when the autoprompter was started
    // reference source: https://www.softwaretestinghelp.com/c-sharp/charp-date-time-format/
    DateTime startTime = DateTime.Now;
    Console.Write($"The autoprompter feature was activated on {startTime.ToString("D")} ");
    Console.WriteLine($"({startTime.ToString("t")})\n"); 
    // make variable and set to "yes" to pass into the StartTimer method 
    // to trigger the method to display when the next autoprompt starts
    string showNextStart = "yes";             
    // start the autoprompter application with the StartTimer method 
    // method having it show when the next autoprompt will start 
    StartTimer(showNextStart);     
    // code that stops the autoprompter application by pressing Enter
    // create a variable and store the value of this entry   
    string stop = Console.ReadLine();   
    // determine if the entry was a blank line or not
    // reference source: https://www.educative.io/answers/how-to-check-if-a-string-has-only-whitespace-or-is-empty-in-c-sharp
    bool endProgram = string.IsNullOrEmpty(stop);
    // stop raising the Elapsed event
    // reference source: https://learn.microsoft.com/en-us/dotnet/api/system.timers.timer.stop?view=net-7.0 
    _countdown.Stop();
    // release all resources used by the timer
    // reference source: https://learn.microsoft.com/en-us/dotnet/api/system.timers.timer.dispose?view=net-7.0
    _countdown.Dispose();    
    // if user is ending the auto-prompt program from running 
    // by entering a "Null or Empty" line do this  
    if (endProgram)
    {    
      // display message stating that the autoprompter is shut down 
      Console.WriteLine("Deactivating the autoprompter application...");
      // do nothing else to let the program end
    }
    // or if the entry was for a menu option to be run in the 
    // main menu displayed from the Menu class and started by 
    // the Autoprompter method found above in this class     
    else if (stop == "1" || stop == "2" || stop == "3" || stop == "4" || stop == "5" || stop == "6")
    {
      // run the transition method to continue the program for the user
      // instead of just letting the program shut off by
      // creating a Menu object to use its methods
      Menu menu = new Menu();
      // and using the Menu object to start the Transition method
      menu.Transition(stop);            
    }
    // limit accidental entries of string characters to try and shut down the autopromter
    // not including 1 through 6 - the menu options listed in the Autoprompter method
    // and using "menu" as an entry command to go back to the journal main menu 
    else
    {
      // if a user does accidentally enter any string characters restart the autoprompter
      // change type color of the text to red to draw user's attention
      Console.ForegroundColor = ConsoleColor.Red;
      // tell the user that they have restarted the autoprompter 
      // with an empty line before and after the statement
      Console.Write ("\nYou have restarted the auto-prompter.");
      // change type color of the text to draw user's attention
      Console.ForegroundColor = ConsoleColor.Yellow;
      // give them an option to get back to the menu or leave the auto-promter on
      //  with an empty line after it
      Console.Write(" If this was a mistake ");
      // change the color back to the red
      Console.ForegroundColor = ConsoleColor.Red;
      Console.Write("and you would like to get back to the journal menu options ");      
      // change type color of the text to draw user's attention again 
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.Write("type in and enter the word '");
      // underline the word & change its color again to emphasize the word to enter
      Console.ForegroundColor = ConsoleColor.Green;
      TextStyles.WriteUnderline("menu");
      // change the color back to the previous color
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("' below.\n");
      // reset the console writing color
      Console.ResetColor();
      // call the TurnOn method to restart the autopropmter
      // prevent the auto-prompter from restarting if menu was entered
      // do this if it es everything except menu and an empty string
      if (stop != "menu" && endProgram != true)
      {
        // restart this method again 
        TurnOn();
      }     
      // if they enter menu    
      if (stop == "menu")
      {
        // create a Menu object to use its methods
        Menu menu = new Menu();        
        // use the Menu object to start the Transition method
        menu.Transition(stop);              
      }      
    }
  }
}