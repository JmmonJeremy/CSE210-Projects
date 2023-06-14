using System;
using System.IO;

// ### CLASS ################################################ //
// class to hold and display the menu for the user
// and to return the user's choice
public class Menu
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // variable 
  string _choice = "run program";

// ### CONSTRUCTORS ######################################### //
  // no constructors needed
// ### METHODS ############################################## //
  // method to present the menu to the user 
  // and to return the user's choice
  public string PresentMenu()
  {     
    // create a string to hold the user's selection 
    // and to keep the while loop running until there's a valid entry
    string selection = "No selection made.";   
    // create a loop to run until a valid choice is entered
    while (selection != "1" && selection != "2" && selection != "3" && selection != "4" && selection != "5" && selection != "6")
    {
    // display the menu and directions
    Console.WriteLine("Select an option by entering its number:");
    Console.WriteLine(" 1 - Create a new goal");
    Console.WriteLine(" 2 - List your goals");
    Console.WriteLine(" 3 - Save your goals");
    Console.WriteLine(" 4 - Load your goals");
    Console.WriteLine(" 5 - Record goal completion");
    Console.WriteLine(" 6 - Quit");
    // show the user where to make their entry
    Console.Write("Selection: ");
    // store the entry in the selection variable
    selection = Console.ReadLine();
    // add a space after the menu
    Console.WriteLine();
    // if the user didn't enter a valid choice
    if (selection != "1" && selection != "2" && selection != "3" && selection != "4" && selection != "5" && selection != "6")
    {
      // inform the user their entry was invalid, tell them what is valid, and to try again.
      Console.WriteLine($"You entered '{selection}', which is not recognized as a valid choice.");
      Console.WriteLine("Your entry must be a 1, 2, 3, 4, 5 or 6 to be a valid choice.");
      Console.WriteLine("Please try again.\n");
    }   
    }
    // return the user's selection
    return selection;
  }

  // method to run the choice the user selects
  public void RunChoices()
  {
    while (_choice != "6")
    {
      // use the PresentMenu method to display menu options and return
      // the user's choice - then store it in the while loop variable
      _choice = PresentMenu();
      // run the options the user chose
      // if they chose a to create a new goal
      if (_choice == "1")
      {
        
      }
       // if they chose to list their goals
      if (_choice == "2")
      {
        
      }
      // if they chose to save their goals
      if (_choice == "3")
      {
        
      }
      // if they chose to load their goals
      if (_choice == "4")
      {
        
      } 
      // if they chose to record their completion of a goal
      if (_choice == "5")
      {
        
      }     
    }
  }
} 