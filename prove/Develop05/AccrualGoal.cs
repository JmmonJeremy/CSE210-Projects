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
  // constructor used to return goals saved to a textfile by
  // creating an AccrualGoal object in the GetGoalType method
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
    // create a validator object to run its method with and
    // pass the prompt question into the object  & for the user's 
    // entry value put 'Use prompt' since user will change value after the prompt
    Validator validator = new Validator("Use prompt", accrualNumberPrompt);    
    // set the _accrualNumber equal to the int number the StringNumberCheck method returns and    
    // and set the method to use the prompt the first time the method is used with "Use Prompt"
    // also set to use the ConfirmEntry method after validating number with "Do ConfirmEntry"
    _accrualNumber = validator.StringNumberCheck("Use prompt", "Do ConfirmEntry");   
  }

  // method to get the _accrualNumber
  public int GetAccrualNumber()
  {
    return _accrualNumber;
  }

  // method to set the _bonusPoints variable
  public void SetBonusPoints()
  {       
    // create user prompt for setting the bonus points associated with this goal & save it in a variable
    string bonusPointsPrompt = "What is the bonus point amount for reaching the goal: ";
    // create a validator object to run its method with and
    // pass the prompt question into the object  & for the user's 
    // entry value put 'Use prompt' since user will change value after the prompt
    Validator validator = new Validator("Use prompt", bonusPointsPrompt);    
    // set the _bonusPoints equal to the int number the StringNumberCheck method returns and
    // and set the method to use the prompt the first time the method is used with "Use Prompt"
    // also set to use the ConfirmEntry method after validating number with "Do ConfirmEntry"
    _bonusPoints = validator.StringNumberCheck("Use prompt", "Do ConfirmEntry");       
  }

  // method to get the _bonusPoints
  public int GetBonusPoints()
  {
    return _bonusPoints;
  }

  // method to get the _completedCount
  public int GetCompletedCount()
  {
    return _completedCount;
  }

  // method to list out a goal
  public override string CreateListedGoal(int count)
  { 
    // use this variable to space listings 1-9 different from 10 or greater
    string space = "  ";
    if (count > 9)
    {
      space = " ";
    }           
    // list the goal for the user to see
    string listedGoal = $"{count}.{space}{GetCompletedBox()} {GetGoalTitle()} ({GetDescription()}) {Convert.ToChar(22)}{Convert.ToChar(16)}{Convert.ToChar(26)}  {Convert.ToChar(183)}:{Convert.ToChar(183)}  Have done: {_completedCount}/{_accrualNumber}  {Convert.ToChar(183)}:{Convert.ToChar(183)}  <{Convert.ToChar(171)}{Convert.ToChar(127)}{Convert.ToChar(187)}>";
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
    string goalText = $"{GetGoalType()}:{GetCompletedBox()}~|~{GetGoalTitle()}~|~{GetDescription()}~|~{GetPoints()}~|~{GetBonusPoints()}~|~{GetAccrualNumber()}~|~{GetCompletedCount()}~|~{GetGoalCompleted()}";
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
    // fill the _completedBox variable with the 1st string value in the list
    SetCompletedBox(attributes[0]);
    // fill the _goalTitle variable with the next string from the split
    SetGoalTitle(attributes[1]);
    // fill the _description variable with the next string from the split
    SetDescription(attributes[2]);
    // fill the _points variable with the next string from the split converted to an int
    SetPoints(int.Parse(attributes[3]));
    // reference source: https://www.shekhali.com/understanding-the-difference-between-int-int16-int32-and-int64-in-c-sharp/# & https://www.freecodecamp.org/news/how-to-convert-a-string-to-an-integer-in-c-sharp/#
    // fill the _bonusPoints with the next string from the split converted to an int by the method     
    _bonusPoints = Convert.ToInt32(attributes[4]);        
    // fill the _accrualNumber with the next string from the split converted to an int by the method
    _accrualNumber = int.Parse(attributes[5]); 
    // fill the _completedCount with the last string from the split converted to an int 
    _completedCount = int.Parse(attributes[6]);
    // reference source: https://stackoverflow.com/questions/49590754/convert-a-string-to-a-boolean-in-c-sharp
    // fill the _goalCompleted boolean with the last string from the split converted to a bool
    SetGoalCompleted(bool.Parse(attributes[7]));  
  }

  // method to make changes when recording goal completion
  public override void MarkComplete()
  {
    // when the _completedCount is less than one under the _accrualNumber 
    if (_completedCount < _accrualNumber -1)
    {
      // set the completedCount value to one greater
      _completedCount += 1;
      // don't mark the goal as completed in the _completedBox variable
      SetCompletedBox("[ ]");
      // keep the _goalCompleted bool to false
      SetGoalCompleted(false); 
    }
    // otherwise 
    else
    {
      // set the completedCount value to one greater
      _completedCount += 1;
      // mark the goal as completed in the _completedBox variable
      SetCompletedBox("[X]");
      // change the _goalCompleted bool to true
      SetGoalCompleted(true);
      // add the _bonusPoint value to the _point value, so it will be added to the _earnedPoints
      SetPoints(GetPoints() + _bonusPoints);
    }  
  }
}