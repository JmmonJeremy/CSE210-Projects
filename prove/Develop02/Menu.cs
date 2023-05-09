using System;
using System.Collections.Generic;

// class to run the program menu
public class Menu
{
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
    do
    {  
      Console.Write($"\nSelection: ");   
      _choice = Console.ReadLine();
      // determine which choice the user selected
      if (_choice == "1")
      {
        Console.WriteLine($"Please make your entry in response to:");
        // display the current date and time
        DateTime entryTime = DateTime.Now;      
        Console.Write($"{entryTime.ToString("D")} ");
        Console.WriteLine($"({entryTime.ToString("t")})");
        // display the journal prompt
        Console.WriteLine(_prompt);
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
        Console.WriteLine($"Your journal entry has been postponed until the next auto-prompt or program restart.");
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

