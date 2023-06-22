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
  // variable to hold the filename prompt
  private string _filenamePrompt; 
  // variable to hold a Goal object to be used throughout all Menu methods
  private Goal _goal = new Goal(); 

// ### CONSTRUCTORS ######################################### //
  // no constructors needed
// ### METHODS ############################################## //
  // method to present the menu to the user and to return the user's choice
  // passing in an object to the object is not recreated after running a menu option
  // this also allow the method to present the user's earned points with the object
  public string PresentMainMenu()
  {     
    // create a string to hold the user's selection     
    string selection = "No selection made.";
    // show the user how many points they have
    _goal.DisplayPoints();       
    // save the menu and directions to be passed into the method for use    
    string mainMenuPrompt = "Select your goal type by entering its number:\n 1 - Create a new goal\n 2 - List your goals\n 3 - Save your goals\n 4 - Load your goals\n 5 - Record goal completion\n 6 - Delete goal file\n 7 - Quit\nSelection: ";      
    // create a validator object to run its method with and 
    // pass the prompt question into the object  & for the user's 
    // entry value put 'Use prompt' since user will change value after the prompt
    Validator validator = new Validator("Use prompt", mainMenuPrompt);    
    // using the SelectionCheck method get an entry that is confirmed and valid      
    selection = validator.SelectionCheck(7);    
    // return the user's selection
    return selection;
  }

  // menu for the user to select the type of goal
  public string PresentGoalTypeMenu()
  {
    // change the color of the text to blue to have it stand out
    Console.ForegroundColor = ConsoleColor.Cyan;
    // inform the user with an empty space before and after
    Console.WriteLine("\nThere are three types of goals you may create.\n");
    // reset the text color to the original settings
    Console.ResetColor();
    // create a string to hold the user's selection 
    // and to keep the while loop running until there's a valid entry
    string selection = "No selection made.";    
    // goal type menu prompt
    string goalMenuPrompt = "Select your goal type by entering its number:\n 1 - One-off goal\n 2 - Habit goal\n 3 - Accrual goal\nSelection: ";
    // create a validator object to run its method with and 
    // pass the prompt question into the object  & for the user's 
    // entry value put 'Use prompt' since user will change value after the prompt
    Validator validator = new Validator("Use prompt", goalMenuPrompt);    
    // using the SelectionCheck method get an entry that is confirmed and valid      
    selection = validator.SelectionCheck(3);      
    // return the user's selection
    return selection; 
  }

  // method to run the user's choice for the goal type 
  public void RunGoalTypeChoices()
  {  
    // determine the type of goal to create
    string goalType = PresentGoalTypeMenu();
    // if the goal type is a one-off
    if (goalType == "1")
    {
      // set the values for the _goalTitle & _description
      _goal.SetGoalTitle("userSets");
      _goal.SetDescription("userSets");
      // create a OneOffGoal object
      OneOffGoal oneOff = new OneOffGoal(_goal.GetGoalTitle(), _goal.GetDescription());
      // load the goal into the list
      _goal.SetGoalList(oneOff);                    
    } 
    // if the goal type is a habit
    if (goalType == "2")
    {
      // set the values for the _goalTitle & _description
      _goal.SetGoalTitle("userSets");
      _goal.SetDescription("userSets");
      // create a HabitGoal object
      HabitGoal habit = new HabitGoal(_goal.GetGoalTitle(), _goal.GetDescription());
      // load the goal into the list
      _goal.SetGoalList(habit); 
    }
    // if the goal type is a accrual
    if (goalType == "3")
    {
      // set the values for the _goalTitle & _description
      _goal.SetGoalTitle("userSets");
      _goal.SetDescription("userSets");
      // create an AccrualGoal object
      AccrualGoal accrual = new AccrualGoal(_goal.GetGoalTitle(), _goal.GetDescription());
      // set the values for the _accrualNumber & _bonusPoints
      accrual.SetAccrualNumber();
      accrual.SetBonusPoints();
      // load the goal into the list
      _goal.SetGoalList(accrual); 
    }    
  }

  // method to run the user's choice from the main menu
  public void RunMainChoices()
  {
    // run this until the user chooses to quit
    while (_choice != "7")
    {      
      // use the PresentMainMenu method to display menu options and return
      // the user's choice - then store it in the while loop variable
      _choice = PresentMainMenu();
      // run the options the user chose
      // if they chose a to create a new goal
      if (_choice == "1")
      {  
        // present the user with the goal type choices
        RunGoalTypeChoices();
      }   
      
       // if they chose to list their goals
      if (_choice == "2")
      {        
        // display the user's list of goals to them
        _goal.ListGoals();        
      }
      // if they chose to save their goals
      if (_choice == "3")
      {
        // set the _filenamePrompt to pass into the SetFileName method
        _filenamePrompt = "Please enter a filename to save the goals under: ";
        // set the _filename from the Goal class
        _goal.SetFilename(_filenamePrompt);
        // after the _filename is set load any previous Goal objects saved under this filename
        _goal.LoadGoalList(); 
        // attach filename to each goal object to avoid combining different files together
        foreach (Goal goal in _goal.GetGoalList())
        {
          goal.SetFilename(_goal.GetFilename());
        }
        // save the _earnedPoints and _goalList to a textfile if the user completed any goals
        // also save the _completedBox string and _completedGoal bool values to a textfile
        _goal.SaveGoals();
      }
      // if they chose to load their goals
      if (_choice == "4")
      {        
        // set the _filenamePrompt to pass into the SetFileName method
        _filenamePrompt = "What is the filename for the goals you would like to load? ";       
        // set the _filename from the Goal class
        _goal.SetFilename(_filenamePrompt);        
        // load the specified textfile as Goal objects into the _goalList
        _goal.LoadGoalList();            
      } 
      // if they chose to record their completion of a goal
      if (_choice == "5")
      {
        int availableGoals = _goal.ListUnfinishedGoals();
        if (availableGoals > 0)
        {
          _goal.NoteAccomplishment(availableGoals);
          // save the _completedBox string and _completedGoal bool values to a textfile
          _goal.SaveGoals();
        }
      } 
       // if they chose to delete a goal file
      if (_choice == "6")
      {
        // give the user the option to delete a file
        _goal.DeleteFile();           
      }         
    }
  }
} 