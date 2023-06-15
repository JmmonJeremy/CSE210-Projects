using System;
using System.IO;

// ### CLASS ################################################ //
// base class for goals
public class Goal
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // variable to hold the goal type
  private string _goalTitle;
  // variable to hold the goal's decription
  private string _description;
  // variable to hold the value in points if the goal is completed
  private int _points;
  // variable to hold the value in earned points for the user
  private int _earnedPoints;
  // variable to hold a list of goals
  private List<Goal> _goalList = new List<Goal>();

// ### CONSTRUCTORS ######################################### //
// constructor to be able to use the Goal methods
  public Goal()
  {
    // nothing needed in here 
  }

  // constructor that sets the _goalTitle and goal _description on initiation
  public Goal(string goalTitle, string description)
  {    
    // set the _goalTitle to what is passed in
    _goalTitle = goalTitle;
    // set the _description to what is passed in
    _description = description;    
    // create user prompt for setting the points associated with this goal & save it in a variable
    string pointsPrompt = "How many points would you like this goal to be worth? ";
    // create a validator object to run its method with
    // and pass the prompt question into the object
    Validator validator = new Validator(pointsPrompt);    
    // set the _points equal to the int number the StringNumberCheck method returns
    _points = validator.StringNumberCheck();   
    // set _earnedPoints as 0
    _earnedPoints = 0;
  }

// ### METHODS ############################################## //
  // method to create new goals
  public void DisplayPoints()
  { 
    // change the color of the text to yellow
    Console.ForegroundColor = ConsoleColor.Yellow;
    // give the user a lead in statement for how many points they have with empty line before
    Console.Write("\nYour earned points score is: ");
    // change the text color back to the original settings
    Console.ResetColor();
    // change the background color for the space showing the amount of points
    Console.BackgroundColor = ConsoleColor.DarkBlue;
    // display points
    Console.WriteLine($" {_earnedPoints} "); 
    // reset the background color to original settings
    Console.ResetColor();
    // add an empty space after the statement
    Console.WriteLine(); 
  }

  // method to set the goal title
  public void SetGoalTitle()
  {      
    // create user prompt for setting the goal title associated with this goal & save it in a variable
    string goalTitlePrompt = "What is the title for your goal? ";
    // create a validator object to run its method with
    // and pass the prompt question into the object
    Validator validator = new Validator(goalTitlePrompt);    
    // set the _goalTitle equal to the string the ConfirmEntry method returns
    _goalTitle = validator.ConfirmEntry(); 
  }

  // method to get the goal title
  public string GetGoalTitle()
  {
    return _goalTitle;
  }

  // method to se the goal description
  public void SetDescription()
  {   
    // create user prompt for setting the goal description associated with this goal & save it in a variable
    string descriptionPrompt = "Please enter a short description of your goal: ";
    // create a validator object to run its method with
    // and pass the prompt question into the object
    Validator validator = new Validator(descriptionPrompt);    
    // set the _description equal to the string the ConfirmEntry method returns
    _description = validator.ConfirmEntry(); 
  }

  // method to get the goal description
  public string GetDescription()
  {
    return _description;
  }

  // method to add a goal to the list
  public void SetGoalList(Goal goal)
  {
    // add the goal to the list
    _goalList.Add(goal);
    // // debuggin code - found that the object creation had to be outside the while loop
    // Console.WriteLine($"The list count after adding the object is: {_goalList.Count}");
  }

  // method to return the _goalList
  public List<Goal> GetGoalList()
  {
    return _goalList;
  }

  // method to list out a goal
  public virtual string CreateListedGoal(int count)
  {           
    // list the goal for the user to see
    string listedGoal = $"{count}) [ ] {GetGoalTitle()} ({GetDescription()})";
    // return the listed goal string
    return listedGoal; 
  }

  // method to list all goals
  public virtual void ListGoals()
  {    
    // change the color of the text to yellow
    Console.ForegroundColor = ConsoleColor.Yellow;
    // give an introductory statement
    Console.WriteLine("The goals you have set for yourself are:");    
    // create a variable to number the goals that are set 
    int count = 0;
    // // debuggin code - found that the object creation had to be outside the while loop
    // Console.WriteLine($"The list count after starting the ListGoals method is: {_goalList.Count}");
    // check to make sure the list isn't empty
    if (_goalList.Count > 0)
    {
      // change the color of the text to blue
      Console.ForegroundColor = ConsoleColor.Cyan;
      // list goals for the user to see
      foreach (Goal goal in _goalList)
      {
        // increment the count by 1 for each loop
        count ++;
        // list the goal for the user to see
        Console.WriteLine($"{goal.CreateListedGoal(count)}");
      }
      // reset the text color to the original settings
      Console.ResetColor();
    }
    // if it is empty 
    else
    {
      // change the color of the text to red
      Console.ForegroundColor = ConsoleColor.Red;
      // let the user know they have no goals set
      Console.WriteLine("You currently have no goals set at this time.");
      // reset the text color to original settings
      Console.ResetColor();
    }
  }
}