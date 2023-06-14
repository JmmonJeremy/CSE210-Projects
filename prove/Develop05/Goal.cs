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
    // have the user set the points associated with this goal
    Console.Write("How many points would you like this goal to be worth? ");
    // change the color of the text to green
    Console.ForegroundColor = ConsoleColor.Green;
    // save the string response in a variable
    string points = Console.ReadLine();
    // reset the text color to the original settings
    Console.ResetColor();
    // convert string to int and record the point value in the _point variable
    _points = int.Parse(points); 
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
    // prompt the user to enter the goal title
    Console.Write("What is the title for your goal? ");
    // change the color of the text to green
    Console.ForegroundColor = ConsoleColor.Green;
    // store the answer in the _goalTitle variable
    _goalTitle = Console.ReadLine();
    // reset the text color to the original settings
    Console.ResetColor();
  }

  // method to get the goal title
  public string GetGoalTitle()
  {
    return _goalTitle;
  }

  // method to se the goal description
  public void SetDescription()
  {
    // prompt the user to enter the goal description
    Console.Write("Please enter a short description of your goal: ");
    // change the color of the text to green
    Console.ForegroundColor = ConsoleColor.Green;
    // store the description in the _descriptoin variable
    _description = Console.ReadLine();
    // reset the text color to the original settings
    Console.ResetColor();
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

  // method to list all goals
  public void ListGoals()
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
      // change the color of the text to yellow
      Console.ForegroundColor = ConsoleColor.Cyan;
      // list goals for the user to see
      foreach (Goal goal in _goalList)
      {
        // increment the count by 1 for each loop
        count ++;
        // list the goal for the user to see
        Console.WriteLine($"{count}) [ ] {_goalTitle} ({_description})");
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