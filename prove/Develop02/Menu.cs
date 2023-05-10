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
    " 2 - Edit the wording for this prompt",
    " 3 - Auto-generate a different prompt",
    " 4 - Hand pick a new prompt for an entry",
    " 5 - Create a new journal prompt to use",
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
    // run a loop until a valid choice is made
    do
    {  
      Console.Write($"\nSelection: ");   
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
        // have the user make a closing choice
        Console.WriteLine("\nPlease enter a selection, would you now like to:");
        Console.WriteLine(" 1 - Commit your entries to your Journal");
        Console.WriteLine(" 2 - Edit this or another uncommited entry");
        Console.WriteLine(" 3 - Wait to commit entries and start auto-prompter");     
        // run a loop until a valid choice is made
        do
        {  
          Console.Write($"\nSelection: ");   
          _choice = Console.ReadLine();
          // determine which choice the user selected
          if (_choice == "1")
          {
            // give a transition statement
            Console.WriteLine("Your entries have been permanently saved to your Journal by date.");
          }
          else if (_choice == "2")
          {
            // give a transition statement
            Console.WriteLine("Choose the entry you would like to edit by its listed time:");
          }
          else if (_choice == "3")
          {
            // enter a blank line before the autoprompt starts
            Console.WriteLine("Your entries have been temporarily saved in an entry list by entry time.");
            Initiator autoprompter = new Initiator();
            autoprompter.TurnOn();
          }
          else 
          {    
            _choice = "invalid";  
            Console.WriteLine("You must enter a valid choice of 1, 2 or 3");
          }
        }
        while (_choice == "invalid");
        }     
      else if (_choice == "2")
      {
        // give a transition statement
        Console.WriteLine($"Please edit and reword this prompt to your liking:\n''{_prompt}''");
      }
      else if (_choice == "3")
      {
        // give a transition statement
        Console.WriteLine($"Here is your new prompt:");
        // regenerate a new prompt with options 
        DisplayMenu();
      }
      else if (_choice == "4")
      {
        // give a transition statement
        Console.WriteLine($"Choose your prompt from this list by entering its number:");
        // show the list of prompts to the user to choose from
        Prompt prompt = new Prompt();
        prompt.ListPrompts();
        // display the prompt the user selected
        Console.WriteLine(prompt.SelectPrompt());             
      }
      else if (_choice == "5")
      {
        // give a transition statement
        Console.WriteLine($"Please enter your new journal prompt:");
      }
       else if (_choice == "6")
      {
        // give a transition statement
        Console.WriteLine($"Your journal entry has been postponed until the next auto-prompt and program restart.");
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

