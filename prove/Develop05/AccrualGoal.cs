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
  // method to communicate goal creation to the user
  public override void CommunicateGoalCreation()
  {
    // COMMUNICATE IN COLOR TO THE USER THE CREATION OF A GOAL
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    // let the user know their goal has been created
    Console.Write("\nThe ");
    // change the color of the text to purple so the word goal stands out
    Console.ForegroundColor = ConsoleColor.Magenta;
    // reference source: https://www.techiedelight.com/remove-n-characters-from-end-string-csharp/
    // save goal type into a string variable
    string goalType = GetGoalType().Substring(0, GetGoalType().Length - 4).ToLower();
    // let the user know their goal has been created
    Console.Write($"{goalType} goal ");
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    // let the user know their goal has been created
    Console.Write("entitled ");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // change the color of the text to purple so the goal title stands out
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write(GetGoalTitle());
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write(" has been ");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // change the color of the text to purple so created stands out
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write("created");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'"); 
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write(" for you with the continuing point value of ");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // change the color of the text to purple so the point total stands out
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write($"{GetPoints()} points");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write(" until accomplished ");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // change the color of the text to purple so the accrual number stands out
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write($"{_accrualNumber} times");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write(", after which it gains an additional value of ");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // change the color of the text to purple so the bonus points stands out
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write($"{_bonusPoints} bonus points");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($".");
    // reset the text color to the original settings
    Console.ResetColor();   
  } 

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
    string goalText = $"{GetGoalType()}:{GetCompletedBox()}~|~{GetGoalTitle()}~|~{GetDescription()}~|~{GetPoints()}~|~{GetBonusPoints()}~|~{GetAccrualNumber()}~|~{GetCompletedCount()}~|~{GetGoalCompleted()}~|~{GetFilename()}";
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
    // fill the _completedCount with the next string from the split converted to an int by the method
    _completedCount = int.Parse(attributes[6]);
    // reference source: https://stackoverflow.com/questions/49590754/convert-a-string-to-a-boolean-in-c-sharp
    // fill the _goalCompleted boolean with the next string from the split converted to a bool by the method
    SetGoalCompleted(bool.Parse(attributes[7]));
    // fill the _filename with the last string from the split
    SetFilename(attributes[8]);
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

  // method to communicate completion recording to user
  public override void CommunicateCompletionRecording()
  {
    // COMMUNICATE IN COLOR TO THE USER THE COMPLETION OF A GOAL
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    // let the user know their goal has been created
    Console.Write("\nFor the ");
    // change the color of the text to purple so the word goal stands out
    Console.ForegroundColor = ConsoleColor.Magenta;
    // reference source: https://www.techiedelight.com/remove-n-characters-from-end-string-csharp/
    // save goal type into a string variable
    string goalType = GetGoalType().Substring(0, GetGoalType().Length - 4).ToLower();    
    // let the user know their goal has been created
    Console.Write($"{goalType} goal ");
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    // let the user know their goal has been created
    Console.Write("entitled: ");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // change the color of the text to purple so the goal title stands out
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write(GetGoalTitle());
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // create a string variable to hold the suffix for inserted number
    string suffix = "";
    // determine what to insert for number: 1st, 2nd, 3rd, etc
    if (_completedCount == 1)
    {
      suffix = "st";
    }
    else if (_completedCount == 2)
    {
      suffix = "nd";
    }
    else if (_completedCount == 3)
    {
      suffix = "rd";
    }
    else
    {
      suffix = "th";
    }    
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;    
    Console.Write($", {Convert.ToChar(22)}{Convert.ToChar(16)}{Convert.ToChar(26)} your ");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // change the color of the text to purple so the recording number stands out
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write($"{_completedCount}{suffix} recording");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write(" of completion of the ");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // change the color of the text to purple so the accrual number stands out
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write($"{_accrualNumber} needed");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write(" to finish the goal, has been noted, ");
    // create a variables for displaying the goals points earned, etc    
    string pointsStatement1 = "";
    string singleQuote = "";
    string completionMark = "";    
    string pointsStatement2 = "";    
    string pointsStatement3 = "";
    string pointsStatement4 = "";
    string pointsStatement5 = "";
    string pointsStatement6 = "";    
    // determine how may points to display by if it is the last goal completetion
    if (GetGoalCompleted())
    { 
      // create variable for what points was originally before bonus was added to it 
      int originalPoints = GetPoints() - _bonusPoints;
      // store statements in different variables about points earned, etc, so colors can be changed 
      pointsStatement1 = "resulting in your goal being marked complete ";
      singleQuote = "'";
      completionMark = "[X]";      
      pointsStatement2 = " and earning you ";
      pointsStatement3 = $"{originalPoints} points";
      pointsStatement4 = " plus ";
      pointsStatement5 = $"{_bonusPoints} bonus points";
      pointsStatement6 = ", giving you ";      
    } 
    // if the last goal completion is not done 
    else 
    {
      pointsStatement2 = "giving you ";
    } 
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write($"{pointsStatement1}");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write($"{singleQuote}");
    // change the color of the text to purple so the completion mark stands out
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write($"{completionMark}");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write($"{singleQuote}");
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write($"{pointsStatement2}");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write($"{singleQuote}");
    // change the color of the text to purple so the points earned stand out
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write($"{pointsStatement3}");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write($"{singleQuote}");
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write($"{pointsStatement4}");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write($"{singleQuote}");
    // change the color of the text to purple so the points earned stand out
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write($"{pointsStatement5}");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write($"{singleQuote}");
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write($"{pointsStatement6}");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write($"'");
    // change the color of the text to purple so the points earned stand out
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write($"{GetPoints()} points total");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write($"'");
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("!");
    // reset the text color to the original settings
    Console.ResetColor();  
  }

    // method to create listing for unfinished goals
  public override void CreateGoalTitleListing(int count)
  {
    // use this variable to space listings 1-9 different from 10 or greater
    string space = "  ";
    if (count > 9)
    {
      space = " ";
    } 
    // reference source: https://www.techiedelight.com/remove-n-characters-from-end-string-csharp/
    // save goal type into a string variable
    string goalType = GetGoalType().Substring(0, GetGoalType().Length - 4).ToLower(); 
    // change the color of the text to blue so the goal type stands out
    Console.ForegroundColor = ConsoleColor.Yellow;  
    // list the goal with the _unfinishedNumber next to it
    Console.Write($"{count}){space}"); 
    // change the color of the text to purple so the goal type stands out
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write($"({goalType} goal) ");
    // change the color of the text to yellow so the goal title stands out
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"{GetGoalTitle()}");
    // reset the text color to original settings
    Console.ResetColor();
  } 
}