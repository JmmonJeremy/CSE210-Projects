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
  public void SetAccrualNumber(string accrualNumber)
  {   
    // if the user is setting the _accrualNumber
    if (accrualNumber == "userSets")
    { 
      // create user prompt for setting the accrual number associated with this goal & save it in a variable
      string accrualNumberPrompt = "Please enter the number of times the goal needs to be done to reach the goal: ";
      // create a validator object to run its method with
      // and pass the prompt question into the object
      Validator validator = new Validator(accrualNumberPrompt);    
      // set the _accrualNumber equal to the int number the StringNumberCheck method returns
      _accrualNumber = validator.StringNumberCheck(); 
    } 
    // otherwise 
    else
    {
      // set the _accrualNumber to the string passed in converted to an int
      _accrualNumber = int.Parse(accrualNumber);
    }  
  }

  // method to set the _bonusPoints variable
  public void SetBonusPoints(string bonusPoints)
  {   
    // if the user is setting the _bonurPoints
    if (bonusPoints == "userSets")
    {    
      // create user prompt for setting the bonus points associated with this goal & save it in a variable
      string bonusPointsPrompt = "What is the bonus point amount for reaching the goal: ";
      // create a validator object to run its method with
      // and pass the prompt question into the object
      Validator validator = new Validator(bonusPointsPrompt);    
      // set the _bonusPoints equal to the int number the StringNumberCheck method returns
      _bonusPoints = validator.StringNumberCheck();
    } 
    // otherwise 
    else
    {
      // set the _bonusPoints to the string passed in converted to an int
      _bonusPoints = Convert.ToInt32(bonusPoints);
    }     
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
    string goalText = $"{GetGoalType()}:~|~{GetGoalTitle()}~|~{GetDescription()}~|~{GetPoints()}~|~{_bonusPoints}~|~{_accrualNumber}~|~{_completedCount}";
    // return the listed goal string
    return goalText; 
  }

  // method to break up retrieved attribute into the different variables
  public override void DivideAttributes()
  {    
    // reference source: https://www.c-sharpcorner.com/UploadFile/mahesh/split-string-in-C-Sharp/#
    // split the attribute string by its "~|~" separator characters
    // ~|~goal title~|~description~|~point value~|~bonus point value~|~accrual number~|~completed count
    string[] attributes = GetAttributes().Split("~|~");
    // fill the _goalTitle variable with the right hand side of the 1st split
    SetGoalTitle(attributes[1]);
    // fill the _description variable with the next string from the split
    SetDescription(attributes[2]);
    // fill the _points variable with the next string from the split converted to an int
    SetPoints(int.Parse(attributes[3]));
    // reference source: https://www.shekhali.com/understanding-the-difference-between-int-int16-int32-and-int64-in-c-sharp/# & https://www.freecodecamp.org/news/how-to-convert-a-string-to-an-integer-in-c-sharp/#
    // fill the _bonusPoints with the next string from the split converted to an int by the method     
    SetBonusPoints(attributes[4]);        
    // fill the _accrualNumber with the next string from the split converted to an int by the method
    SetAccrualNumber(attributes[5]); 
    // fill the _completedCount with the last string from the split converted to an int 
    _completedCount = int.Parse(attributes[6]); 
  }
}