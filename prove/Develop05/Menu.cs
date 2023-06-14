using System;
using System.IO;

// ### CLASS ################################################ //
// class to hold and display the menu for the user
// and to return the user's choice
public class Menu
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // variable to hold the user's choice and to run the while loop
  private string _choice = "run program";

// ### CONSTRUCTORS ######################################### //
  // no constructors needed
// ### METHODS ############################################## //
  // method to present the menu to the user 
  // and to return the user's choice
  public string PresentMenu(Goal goal)
  {     
    // create a string to hold the user's selection 
    // and to keep the while loop running until there's a valid entry
    string selection = "No selection made.";   
    // create a loop to run until a valid choice is entered
    while (selection != "1" && selection != "2" && selection != "3" && selection != "4" && selection != "5" && selection != "6")
    {
      // show the user how many points they have
      goal.DisplayPoints();
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
      // change the color of the text to green
      Console.ForegroundColor = ConsoleColor.Green;
      // store the entry in the selection variable
      selection = Console.ReadLine();
      // reset the background color to original settings
      Console.ResetColor();
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

  // menu for the user to select the type of goal
  public string GoalTypeMenu()
  {
    Console.WriteLine("There are three types of goals you may create.");
    Console.WriteLine("Please select the type of goal you are creating from the list below.\n");
    // create a string to hold the user's selection 
    // and to keep the while loop running until there's a valid entry
    string selection = "No selection made.";   
    // create a loop to run until a valid choice is entered
    while (selection != "1" && selection != "2" && selection != "3")
    { 
      Console.WriteLine("Select your goal type by entering its number:");
      Console.WriteLine(" 1 - One-off goal");
      Console.WriteLine(" 2 - Habit goal");
      Console.WriteLine(" 3 - Accrual goal");
      // show the user where to make their entry
      Console.Write("Selection: ");
      // change the color of the text to green
      Console.ForegroundColor = ConsoleColor.Green;
      // store the entry in the selection variable
      selection = Console.ReadLine();
      // reset the background color to original settings
      Console.ResetColor();
      // add a space after the menu
      Console.WriteLine();
      // if the user didn't enter a valid choice
      if (selection != "1" && selection != "2" && selection != "3")
      {
        // inform the user their entry was invalid, tell them what is valid, and to try again.
        Console.WriteLine($"You entered '{selection}', which is not recognized as a valid choice.");
        Console.WriteLine("Your entry must be a 1, 2 or 3 to be a valid choice.");
        Console.WriteLine("Please try again.\n");
      }
    }
    // return the user's selection
    return selection; 
  }

  // method to run the choice the user selects
  public void RunChoices()
  {
    // create a Goal object to be used throughout running of this menu
    Goal goal = new Goal();
    while (_choice != "6")
    {      
      // use the PresentMenu method to display menu options and return
      // the user's choice - then store it in the while loop variable
      _choice = PresentMenu(goal);
      // run the options the user chose
      // if they chose a to create a new goal
      if (_choice == "1")
      {
        // determine the type of goal to create
        string goalType = GoalTypeMenu();
        if (goalType == "1")
        {
          // set the values for the _goalTitle & _description
          goal.SetGoalTitle();
          goal.SetDescription();
          // create a OneOffGoal
          OneOffGoal oneOff = new OneOffGoal(goal.GetGoalTitle(), goal.GetDescription());
          // load the goal into the list
          goal.SetGoalList(oneOff);                    
        }       
      }
       // if they chose to list their goals
      if (_choice == "2")
      {        
        // display the user's list of goals to them
        goal.ListGoals();        
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