using System;
using System.Timers;

// class that initiates prompts on a set timed schedule
public class Initiator
{
    // TODO variable for set different times for the prompts
    public TimeSpan _newTime; 
    // vairable holding the time for timed prompts
    public System.Timers.Timer _countdown; 
   
    // method to determine the appropriate prompt time
    public TimeSpan SetTime()
    {       
      // variable to hold current time
      TimeSpan nowTime = DateTime.Now.TimeOfDay;
      // set number string to compare to determine the setTime value
      string combine = nowTime.Hours.ToString()+nowTime.Minutes.ToString()+nowTime.Seconds.ToString();
      // convert string to int for comparison
      int compare = int.Parse(combine);
      // determine the start time by what time it is usig military time
      if (compare < 103000)
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
      else if (compare < 163000)
      {
        TimeSpan setTime = new TimeSpan(16,30,00);
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
        // the compared time is greater than 203000 in this case
        // so it will return a negative & inaccurate millisecond countdown
        // unless you add 24 hours to this time until midnight - not here
        // but in the StartTimer code that uses this time for setting countdown
        TimeSpan setTime = new TimeSpan(10,30,00);
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
        if (DateTime.Now.Hour > 20)
        {  
          // by adding 24 hours in milliseconds
          milliseconds = (milliSetTime + 86400000) - milliNowTime; 
        }
        // to cover any exception I have missed  
        else
        {
          milliseconds = 20000;
        } 

      }
      // convert setTime into AM or PM for display     
      DateTime conversion = DateTime.Today.Add(setTime);
      string clockTime = conversion.ToString("hh:mm tt");
      // display message showing the next time the program should inititiate
       Console.WriteLine($"The next Journal prompt is scheduled for {clockTime} or {setTime} in {milliseconds} milliseconds.");
       _countdown = new System.Timers.Timer(milliseconds);
       _countdown.Elapsed += AutoPrompt; 
       _countdown.AutoReset = true;    
       _countdown.Enabled = true;              
    }

    // method to run the journal prompt and user choices
    // reference source: https://social.technet.microsoft.com/wiki/contents/articles/37252.c-timer-schedule-a-task.aspx
    private static void AutoPrompt(Object source, ElapsedEventArgs e)
    { 
      // display the current date and time
      // reference source: https://stackoverflow.com/questions/13044603/convert-time-span-value-to-format-hhmm-am-pm-using-c-sharp 
      DateTime entryTime = DateTime.Now;
      Console.Write($"{entryTime.ToString("D")} ");
      Console.WriteLine($"({entryTime.ToString("t")})");
      // display the Journal prompt question
      Prompt prompter = new Prompt();
      Console.WriteLine(prompter.AutoPrompt());      
      Console.WriteLine();
      // reset the countdown to the next prompt
      Initiator start = new Initiator();
      start.StartTimer();
      // stop the last countdown thread
      start._countdown.Stop();     
    }

}