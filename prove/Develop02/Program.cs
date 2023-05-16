using System;
using System.Runtime.InteropServices;

// class to run the Journal application
class Program
{
    // main method to run the Journal application
    static void Main(string[] args)
    {
        // testing methods
        Menu menu = new Menu();            
        menu.Transition("menu");
        // running auto-prompter
        // Initiator autoprompter = new Initiator();
        // autoprompter.TurnOn();
       

       
    
        // CODE TO CONSTANTLY RUN THE PROGRAM FOR THE AUTOPROMPTS THROUGHOUT THE DAY //
    // // ############################################################################################# //
    //     // create variables of underlined start & end NOTE
    //     string noteStart = "*NOTE->";
    //     // string noteEnd = "<-NOTE*\n";
    //     // display a message on how to stop the autoprompter
    //     Console.WriteLine("\n***STARTING THE JOURNAL AUTOPROMPTER***");
    //     WriteUnderline(noteStart);
    //     Console.WriteLine(" To turn the autoprompter off, press Enter with the curser active in the program's terminal. ");        
    //     // display a message on when the autoprompter was started
    //     // reference source: https://www.softwaretestinghelp.com/c-sharp/charp-date-time-format/
    //     DateTime startTime = DateTime.Now;
    //     Console.Write($"The autoprompter feature was activated on {startTime.ToString("D")} ");
    //     Console.WriteLine($"({startTime.ToString("t")})\n");
    //     // start the autoprompter application from the Initiator class
    //     Initiator start = new Initiator();
    //     start.StartTimer();
    //     // code that stops the autoprompter application by pressing Enter   
    //     Console.ReadLine();
    //     start._countdown.Stop();
    //     start._countdown.Dispose(); 
    //     // display message stating that the autoprompter is shut down 
    //     Console.WriteLine("Deactivating the autoprompter application...");
    // // ############################################################################################# //
    }

    // got this from https://stackoverflow.com/questions/3381952/how-to-remove-all-white-space-from-the-beginning-or-end-of-a-string
    public static void WriteUnderline(string s)
    {        
        const int STD_OUTPUT_HANDLE = -11;
        const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 4;

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll")]
        static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

        [DllImport("kernel32.dll")]
        static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

        var handle = GetStdHandle(STD_OUTPUT_HANDLE);
        uint mode;
        GetConsoleMode(handle, out mode);
        mode |= ENABLE_VIRTUAL_TERMINAL_PROCESSING;
        SetConsoleMode(handle, mode);
        Console.Write($"\x1B[4m{s}\x1B[24m");
    }
}