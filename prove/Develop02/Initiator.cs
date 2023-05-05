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
      if (compare < 103000 || compare > 203000)
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
        TimeSpan setTime = new TimeSpan(10,30,00);
        return setTime;
      }
    }

    // method that starts the countdown to the Journal autoprompt
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
      // keep milliseconds positive to avoid error
      if (milliseconds < 0)
      {
        milliseconds = 20000;
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
    private static void AutoPrompt(Object source, ElapsedEventArgs e)
    { 
      // display the current date and time
      DateTime entryTime = DateTime.Now;
      Console.Write($"{entryTime.ToString("D")} ");
      Console.WriteLine($"({entryTime.ToString("t")})");
      // display the Journal prompt question
      Prompt prompter = new Prompt();
      Console.WriteLine(prompter.SelectPrompt());      
      Console.WriteLine();
      // reset the countdown to the next prompt
      Initiator start = new Initiator();
      start.StartTimer();
      // stop the last countdown thread
      start._countdown.Stop();     
    }

}