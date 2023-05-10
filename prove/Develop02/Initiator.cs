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
    if (compare < 103000 || compare >= 203000)
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
    else if (compare < 154400)
    {
      TimeSpan setTime = new TimeSpan(15,44,00);
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
  public void StartTimer()
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
    // display message showing the current time and the next time the program should inititiate
      Console.WriteLine($"It is now {startTime.ToString("D")} at {startTime.ToString("t")} and the next Journal prompt is scheduled for {clockTime} in {hours} hours and {minutes} minutes.\n");
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
    // display a prompt to run the journal program underlined & capitalized for more emphasis       
    Program.WriteUnderline("!!! REMINDER TO RUN A JOURNAL PROMPT AND MAKE AN ENTRY !!!\n");
    // reset color to original settings
    Console.ResetColor();

    // // TODO ########## figure out how to take readline info and not stop autoprompt timer
    // // give a random prompt and start the menu with its options
    // Menu menu = new Menu();
    // menu.DisplayMenu();       
    // menu.Transition();
        
    // reset the countdown to the next prompt
    Initiator start = new Initiator();
    start.StartTimer();         
  }

  // method to turn on the auto-prompt initiator
  public void TurnOn()
  {
    // create variables of underlined start & end NOTE
    string noteStart = "*NOTE->";
    // string noteEnd = "<-NOTE*\n";
    // display a message on how to stop the autoprompter
    Console.WriteLine("\n***STARTING THE JOURNAL AUTOPROMPTER***");
    // underline text in terminal
    // reference source: https://www.tutorialsteacher.com/csharp/csharp-static
    Program.WriteUnderline(noteStart);
    Console.WriteLine(" To turn the autoprompter off, press Enter with the curser active in the program's terminal. ");        
    // display a message on when the autoprompter was started
    // reference source: https://www.softwaretestinghelp.com/c-sharp/charp-date-time-format/
    DateTime startTime = DateTime.Now;
    Console.Write($"The autoprompter feature was activated on {startTime.ToString("D")} ");
    Console.WriteLine($"({startTime.ToString("t")})\n");              
    // start the autoprompter application 
    StartTimer();     
    // code that stops the autoprompter application by pressing Enter
    Console.ReadLine();
    // // reference sources for possible solutions: (2 threads for read & write to console) https://stackoverflow.com/questions/11628432/c-sharp-allow-simultaneous-console-input-and-output (paralleltasks) https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-use-parallel-invoke-to-execute-parallel-operations
    // // IDEA keep this running until quite is entered
    // string quit = "anything"; 
    // while (quit != "quite")
    // {
    //   quit = Console.ReadLine();
    // }     
    _countdown.Stop();
    _countdown.Dispose(); 
    // display message stating that the autoprompter is shut down 
    Console.WriteLine("Deactivating the autoprompter application...");
  }
}