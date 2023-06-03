using System;
using System.IO;

// ### CLASS ################################################ //
// class to hold and display the menu for the user
// and to return the user's choice
public class Menu
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // variable 

// ### CONSTRUCTORS ######################################### //
  // constructor 

// ### METHODS ############################################## //
  // method to present the menu to the user 
  // and to return the user's choice
  public string PresentMenu()
  { 
    // create a string to hold the user's selection 
    // and to keep the while loop running until there's a valid entry
    string selection = "No selection made.";   
    // create a loop to run until a valid choice is entered
    while (selection != "1" && selection != "2" && selection != "3" && selection != "4")
    {
    // display the menu and directions
    Console.WriteLine("Select an option by entering its number:");
    Console.WriteLine(" 1 - Start a breathing activity");
    Console.WriteLine(" 2 - Start a reflecting activity");
    Console.WriteLine(" 3 - Start a listing activity");
    Console.WriteLine(" 4 - Quit");
    // show the user where to make their entry
    Console.Write("Selection: ");
    // store the entry in the selection variable
    selection = Console.ReadLine();
    // add a space after the menu
    Console.WriteLine();
    // if the user didn't enter a valid choice
    if (selection != "1" && selection != "2" && selection != "3" && selection != "4")
    {
      // inform the user their entry was invalid, tell them what is valid, and to try again.
      Console.WriteLine($"You entered '{selection}', which is not recognized as a valid choice.");
      Console.WriteLine("Your entry must be a 1, 2, 3, or 4 to be a valid choice.");
      Console.WriteLine("Please try again.\n");
    }   
    }
    // return the user's selection
    return selection;
  }
} 