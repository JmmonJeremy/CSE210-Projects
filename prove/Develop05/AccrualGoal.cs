using System;
using System.IO;

// ### CLASS ################################################ //
// class for accrual goals
public class AccrualGoal : Goal
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // variable to track how many times a goal needs to be completed
  private int _accrualNumber;
  // variable to keep track of how many times the goal has been completed
  private int _completedCount;
  // variable to keep the amount of bonus points for completing the accrualNumber
  private int _bonusPoints;

// ### CONSTRUCTORS ######################################### //
  // constructor to be able to use the AccrualGoal methods
  public AccrualGoal()
  {
    // set the _completedCount to 0
    _completedCount = 0;
    // nothing needed in here 
  }

  // constructor to pass in the goal title and description from the user
  public AccrualGoal(string goalTitle, string description) : base(goalTitle, description)
  {
    // this is all done in the base class
  }
// ### METHODS ############################################## //
  // method to set the _accrualNumber variable
  public void SetAccrualNumber()
  {    
    // prompt the user to enter the accrual number
    Console.Write("Please enter the number of times the goal needs to be done to reach the goal: ");
    // change the color of the text to green
    Console.ForegroundColor = ConsoleColor.Green;    
    // save the string response in a variable
    string accrualNumber = Console.ReadLine();    
    // convert string to int and record the accrual number value in the _accrualNumber variable
    _accrualNumber = int.Parse(accrualNumber);    
    // reset the text color to the original settings
    Console.ResetColor();
  }

  // method to set the _bonusPoints variable
  public void SetBonusPoints()
  {    
    // prompt the user to enter the bonus points
    Console.Write("What is the bonus point amount for reaching the goal: ");
    // change the color of the text to green
    Console.ForegroundColor = ConsoleColor.Green;    
    // save the string response in a variable
    string bonusPoints = Console.ReadLine();    
    // convert string to int and record the bonus points value in the _bonusPoints variable
    _bonusPoints = int.Parse(bonusPoints);    
    // reset the text color to the original settings
    Console.ResetColor();
  }

  // method to list out a goal
  public override string CreateListedGoal(int count)
  {           
    // list the goal for the user to see
    string listedGoal = $"{count}) [ ] {GetGoalTitle()} ({GetDescription()}) {Convert.ToChar(22)}{Convert.ToChar(16)}{Convert.ToChar(26)}  {Convert.ToChar(183)}:{Convert.ToChar(183)}  Have done: {_completedCount}/{_accrualNumber}  {Convert.ToChar(183)}:{Convert.ToChar(183)}  <{Convert.ToChar(171)}{Convert.ToChar(127)}{Convert.ToChar(187)}>";
    // return the listed goal string
    return listedGoal; 
  }  
}