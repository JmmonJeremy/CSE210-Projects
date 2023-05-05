using System;

// class to run the Journal application
class Program
{
    // main method to run the Journal application
    static void Main(string[] args)
    {
        // display a message on how to stop the autoprompter
        Console.WriteLine("\nPress Enter to deactivate the autoprompter...");
        // display a message on when the autoprompter was started
        DateTime startTime = DateTime.Now;
        Console.Write($"The autoprompter feature was activated on {startTime.ToString("D")} ");
        Console.WriteLine($"({startTime.ToString("t")})\n");
        // start the autoprompter application from the Initiator class
        Initiator start = new Initiator();
        start.StartTimer();
        // code that stops the autoprompter application by pressing Enter   
        Console.ReadLine();
        start._countdown.Stop();
        start._countdown.Dispose(); 
        // display message stating that the autoprompter is shut down 
        Console.WriteLine("Deactivating the autoprompter application...");
    }
}