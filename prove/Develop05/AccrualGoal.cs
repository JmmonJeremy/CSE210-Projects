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
  // and to return used goals saved to a textfile
  public AccrualGoal()
  {    
    // nothing needed in here 
  }

  // constructor to pass in the goal title and description from the user
  public AccrualGoal(string goalTitle, string description) : base(goalTitle, description)
  {
    // set the completed count to 0 to start with
    _completedCount = 0;
    // this is all done in the base class
  }
// ### METHODS ############################################## //
  // method to set the _accrualNumber variable
  public void SetAccrualNumber()
  {    
    // create user prompt for setting the accrual number associated with this goal & save it in a variable
    string accrualNumberPrompt = "Please enter the number of times the goal needs to be done to reach the goal: ";
    // create a validator object to run its method with
    // and pass the prompt question into the object
    Validator validator = new Validator(accrualNumberPrompt);    
    // set the _accrualNumber equal to the int number the StringNumberCheck method returns
    _accrualNumber = validator.StringNumberCheck();     
  }

  // method to set the _bonusPoints variable
  public void SetBonusPoints()
  {      
    // create user prompt for setting the bonus points associated with this goal & save it in a variable
    string bonusPointsPrompt = "What is the bonus point amount for reaching the goal: ";
    // create a validator object to run its method with
    // and pass the prompt question into the object
    Validator validator = new Validator(bonusPointsPrompt);    
    // set the _bonusPoints equal to the int number the StringNumberCheck method returns
    _bonusPoints = validator.StringNumberCheck();    
  }

  // method to list out a goal
  public override string CreateListedGoal(int count)
  {           
    // list the goal for the user to see
    string listedGoal = $"{count}) [ ] {GetGoalTitle()} ({GetDescription()}) {Convert.ToChar(22)}{Convert.ToChar(16)}{Convert.ToChar(26)}  {Convert.ToChar(183)}:{Convert.ToChar(183)}  Have done: {_completedCount}/{_accrualNumber}  {Convert.ToChar(183)}:{Convert.ToChar(183)}  <{Convert.ToChar(171)}{Convert.ToChar(127)}{Convert.ToChar(187)}>";
    // return the listed goal string
    return listedGoal; 
  } 

  // method to get the class name
  public override string GetGoalType()
  {
    // create an object of the class
    AccrualGoal accrual = new AccrualGoal();
    // return type as a string
    return accrual.GetType().ToString();
  } 

  // method to create & return an accrual goal string
  public override string CreateGoalText()
  {           
    // list the goal for the user to see
    string goalText = $"{GetGoalType()}:{GetGoalTitle()}~|~{GetDescription()}~|~{GetPoints()}~|~{_bonusPoints}~|~{_accrualNumber}~|~{_completedCount}";
    // return the listed goal string
    return goalText; 
  }
}