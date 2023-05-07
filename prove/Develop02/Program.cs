using System;

// class to run the Journal application
class Program
{
    // main method to run the Journal application
    static void Main(string[] args)
    {
        // testing methods
        Prompt prompt = new Prompt();
        prompt.ListPrompts();
        prompt.UpdateLog(prompt._inUsePromptList);
        List<string> list = prompt.UpdateList(prompt._usedPromptList, prompt._inUsePromptFile);
        foreach (string prompting in list)
        {
            Console.WriteLine($"Made it!!! - {prompting}");
        }
       
        
    
        // CODE TO CONSTANTLY RUN THE PROGRAM FOR THE AUTOPROMPTS THROUGHOUT THE DAY //
    // ############################################################################################# //
        // display a message on how to stop the autoprompter
        Console.WriteLine("\nNOTE!!! To turn the autoprompter off, press Enter with the curser active in the program's terminal. !!!NOTE");
        // display a message on when the autoprompter was started
        // reference source: https://www.softwaretestinghelp.com/c-sharp/charp-date-time-format/
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
    // ############################################################################################# //
    }
}