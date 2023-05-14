using System;
using System.Collections.Generic;

// ### CLASS ################################################ //
// class to run the program menu
public class Menu
{
// ### VARIABLE ATTRIBUTES ################################## //  
  // variable to hold the user's option choice
  string _choice;
  // variable to hold the prompt message
  string _prompt;
  // list of menu options
  List<string> _options = new List<string>()
  {
    " 1 - Use current prompt for an entry",
    " 2 - Create a new journal prompt to use",
    " 3 - Auto-generate a different prompt",
    " 4 - Hand pick a new prompt for an entry",
    " 5 - Select and read an old journal entry",
    " 6 - Put off entry & start prompt timer",
  };

// ### METHODS ############################################## //
  // method to diplay the menu for the user
  public void DisplayMenu()
  {
    Prompt prompt = new Prompt();
    Console.WriteLine(_prompt = prompt.RandomPrompt());
    // tell user how to make a selection
    Console.WriteLine("\nSelect an option by entering its number:");
    // display the menu to select from
    foreach (string option in _options)
    {
      Console.WriteLine($"{option}");
    }     
  }

  // method to hold the users choice
  public void Transition()
  {
    // show them the options
    DisplayMenu();
    // run a loop until a valid choice is made
    do
    {  
      Console.Write("\nSelection: ");   
      _choice = Console.ReadLine();
      // determine which choice the user selected
      if (_choice == "1")
      {
        // give a transition statement
        Console.Write("Please");
        // add color to emphasize this text
        // reference source: https://stackoverflow.com/questions/2743260/is-it-possible-to-write-to-the-console-in-colour-in-net
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(" make your entry");
         // reset color to the original settings
        Console.ResetColor();
        Console.Write(" and then ");
        // add color to emphasize this text      
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("press Enter to store it");
        // reset color to the original settings
        Console.ResetColor();
        Console.WriteLine(" in response to:");
        // store the current date and time in a variable
        DateTime entryTime = DateTime.Now;       
        // create variable to hold date & time as a string
        string dateTime = entryTime.ToString("D") + " " + entryTime.ToString("t");       
        // display the current date and time
        Console.WriteLine(dateTime);
        // display the journal prompt in color
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(_prompt);
        Console.ResetColor();
        // create instand of Pen
        Pen pen = new Pen();
        // use Pen method to add an entry
        pen.Add(entryTime, dateTime, _prompt);
        // add a space before the transition statement
        Console.WriteLine();
        // change type color of the smiley face to draw the user's attention
        Console.ForegroundColor = ConsoleColor.Yellow;
        // add a smiley face to help encourage the user
        Console.Write($"{Convert.ToChar(2)} {Convert.ToChar(45)}{Convert.ToChar(16)} ");
        // change type color of ending statement to red to draw user's attention
        Console.ForegroundColor = ConsoleColor.Red;
        // tell the user what happened with a transition statement
        Console.Write ("You have entered a journal response to the given prompt ");
        // change type color of the smiley face to draw the user's attention
        Console.ForegroundColor = ConsoleColor.Yellow;
        // add a smiley face to help encourage the user
        Console.WriteLine ($"{Convert.ToChar(17)}{Convert.ToChar(45)} {Convert.ToChar(2)}\n");
        // reset the console writing color
        Console.ResetColor();
        // give them the choice to do something else or start autoprompter
        // have the user make a closing choice
        Console.WriteLine("\nPlease enter a selection, would you now like to:");
        Console.WriteLine(" 1 - Commit your entries to your Journal"); 
        Console.WriteLine(" 2 - Wait to commit entries and see other options");      
        Console.WriteLine(" 3 - Wait to commit entries and start auto-prompter");     
        // run a loop until a valid choice is made
        do
        {  
          Console.Write("\nSelection: ");   
          _choice = Console.ReadLine();
          // determine which choice the user selected
          if (_choice == "1")
          {
            // access the dictionary list in the Pen class for the entries
            var entries = pen._pendingEntries;
            // create Journal object to use method to add entries
            Journal journal = new Journal();
            journal.AddToJournal(entries);
            // empty the entries list
            pen.EmptyList();
            // change type color of ending statement to red to draw user's attention
            Console.ForegroundColor = ConsoleColor.Red;
            // give a transition statement
            Console.WriteLine("Your entries have been permanently saved to your Journal by date.\n");
            // reset the console writing color
            Console.ResetColor();
            // give them the choice to do something else or start autoprompter
            Transition();
          } 
          else if (_choice == "2")
          {
            // change type color of ending statement to red to draw user's attention
            Console.ForegroundColor = ConsoleColor.Red;
            // let the user know what has happened
            Console.WriteLine("You chose to wait to commit your entry to your journal and look at more journal options.");
            // reset the console writing color
            Console.ResetColor(); 
            // place a space before the auto-prompter starting statement
            Console.WriteLine();
            // give them the choice to do something else or start autoprompter
            Transition();
          }         
          else if (_choice == "3")
          {
            // change type color of ending statement to red to draw user's attention
            Console.ForegroundColor = ConsoleColor.Red;
            // let the user know what has happened
            Console.WriteLine("Your entries have been temporarily saved in an entry list by their entry time.");
            // reset the console writing color
            Console.ResetColor(); 
            // place a space before the auto-prompter starting statement
            Console.WriteLine();
            // create and instance of the Initiator class to access its method
            Initiator autoprompter = new Initiator();
            // use the instance to access TurnOn Initiator method
            autoprompter.TurnOn();
          }
          else 
          {    
            _choice = "invalid";  
            Console.WriteLine("You must enter a valid choice of 1 or 2");
          }
        }
        while (_choice == "invalid");
      }     
      else if (_choice == "2")
      {
        // give a transition statement
        Console.WriteLine("Please enter your new journal prompt:");
      }
      else if (_choice == "3")
      {
        // give a transition statement
        Console.WriteLine("Here is your new prompt:");
        // regenerate a new prompt with options 
        DisplayMenu();
      }
      else if (_choice == "4")
      {
        // give a transition statement
        Console.WriteLine("Choose your prompt from this list by entering its number:");
        // show the list of prompts to the user to choose from
        Prompt prompt = new Prompt();
        prompt.ListPrompts();
        // display the prompt the user selected
        Console.WriteLine(prompt.SelectPrompt());             
      }
      else if (_choice == "5")
      {
        // give a transition statement
        Console.WriteLine("You chose to select and read an old journal entry.");
        Console.WriteLine("\n Select an option by entering its number:");
        Console.WriteLine(" 1 - Display all uncommitted journal entries");  
        Console.WriteLine(" 2 - Select a recent uncommitted journal entry");        
        Console.WriteLine(" 3 - Display all entries from a journal volume");
        Console.WriteLine(" 4 - Display a date range of journal entries");
        // run a loop until a valid choice is made
        do
        {  
          Console.Write("\nSelection: ");   
          _choice = Console.ReadLine();
          // determine which choice the user selected
          if (_choice == "1")
          {
            // 
            
          }          
          else if (_choice == "2")
          {
            // tell user what they need to enter
           
          }
          else if (_choice == "3")
          {
            // create journal instance to use the journal methods         
            Journal journal = new Journal();
            // display all the journal entries to the console
            journal.ConsoleDisplay(journal.FileToList());
            // change type color of ending statement to red to draw user's attention
            Console.ForegroundColor = ConsoleColor.Red;
            // let the user know what has happened with a space before it
            // plus add in an arrow pointing up
            // reference source: https://www.codeproject.com/Questions/254514/Displaying-a-symbol-in-csharp & https://en.wikipedia.org/wiki/Code_page_437 & https://www.ascii-codes.com/cp855.html & https://yorktown.cbe.wwu.edu/sandvig/shared/asciicodes.aspx
            Console.WriteLine($"\n|{Convert.ToChar(24)} {Convert.ToChar(30)} {Convert.ToChar(24)}| Your specified journal volume is now displayed in the terminal space above here |{Convert.ToChar(24)} {Convert.ToChar(30)} {Convert.ToChar(24)}|"); 
            // reset the console writing color
            Console.ResetColor();            
            // give them the choice to do something else or start autoprompter
            Transition();          
          }
           // determine which choice the user selected
          else if (_choice == "4")
          {
            // prompt user for starting date + show the user the format to use
            Console.WriteLine("Please enter the start date for your desired range in this format: 6/9/2023");
            // show user they are entering the starting date
            Console.Write("Starting date: ");
            // store answer in a variable for use
            string startDate = Console.ReadLine();
            // prompt user for ending date + show the user the format to use
            Console.WriteLine("Please enter the end date for your desired range in this format: 6/9/2023");
            // show user they are entering the ending date
            Console.Write("Ending date: ");
            // store answer in a variable for use
            string endDate = Console.ReadLine();
            // add a space before transition statement
            Console.WriteLine();
            // change type color of ending statement to red to draw user's attention
            Console.ForegroundColor = ConsoleColor.Red;
            // tell the user where the date is
            Console.WriteLine("Below are the requested journal entries within the specified date range:\n");
             // reset the console writing color
            Console.ResetColor(); 
            // make an instance of the Journal class to call methods with
            Journal journal = new Journal();
            // call the methods to get the selection and store it in a variable
            var selection = (journal.GetSelection(journal.FileToList(), startDate, endDate));
            // add a space before displaying the specified journal entries
            Console.WriteLine();
            // call the display method to display the requested date range 
            journal.ConsoleDisplay(selection);             
            // change type color of ending statement to red to draw user's attention
            Console.ForegroundColor = ConsoleColor.Red;
            // let the user know what has happened with a space before it
            // plus add in an arrow pointing up            
            Console.WriteLine($"\n|{Convert.ToChar(24)} {Convert.ToChar(30)} {Convert.ToChar(24)}| Your journal entries within the date range can now be found above in this terminal |{Convert.ToChar(24)} {Convert.ToChar(30)} {Convert.ToChar(24)}|"); 
            // reset the console writing color
            Console.ResetColor();            
            // give them the choice to do something else or start autoprompter
            Transition();    
          }      
          else 
          {    
            _choice = "invalid";  
            Console.WriteLine("You must enter a valid choice of 1, 2, 3 or 2");
          }
        }
        while (_choice == "invalid");
      }
       else if (_choice == "6")
      {
        // change type color of ending statement to red to draw user's attention
        Console.ForegroundColor = ConsoleColor.Red;
        // give a transition statement
        Console.WriteLine("Your journal entry has been postponed until the next auto-prompt and program restart.");
        // reset the console writing color
        Console.ResetColor(); 
        // place a space before the auto-prompter starting statement
        Console.WriteLine();
        // create and instance of the Initiator class to access its method
        Initiator autoprompter = new Initiator();        
        // use the instance to access TurnOn Initiator method
        autoprompter.TurnOn();
      }
      else 
      {    
        _choice = "invalid";  
        Console.WriteLine("You must enter a valid choice of 1, 2, 3, 4, 5 or 6");
      }
    }
    while (_choice == "invalid");    
  }
}

