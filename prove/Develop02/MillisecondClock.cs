using System;

// class to transfomr time into milliseconds
public class MillisecondClock
{
  // method to set times for the Initiator start times
  public double SetTimes()
  {
    // set times for Initiator to start a program
      TimeSpan setTime = new TimeSpan(21,01,00);
      // variable to hold current time
      TimeSpan nowTime = DateTime.Now.TimeOfDay;
      // convert times into milliseconds
      double milliSetTime = (setTime).TotalMilliseconds;
      double milliNowTime = Math.Round((nowTime).TotalMilliseconds);
      // display times in milliseconds
      Console.WriteLine($"{milliSetTime} - {milliNowTime}");
      // figure time for countdown
      double milliseconds = milliSetTime - milliNowTime;
      // keep milliseconds positive
      if (milliseconds < 0)
      {
        milliseconds = 2000;
      }
      return milliseconds;
  }
}

