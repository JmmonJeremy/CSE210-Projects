using System;
using System.IO;

// ### CLASS ################################################ //
// class for one-off goals
public class OneOffGoal : Goal
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // variable boolean to indicate if the goal has been accomplished
  private bool _goalCompleted;
  

// ### CONSTRUCTORS ######################################### //
  // constructor to be able to use the OneOffGoal methods
  // and to return used goals saved to a textfile
  public OneOffGoal()
  {
    // nothing needed in here 
  }

  // constructor to pass in the goal title and description from the user
  public OneOffGoal(string goalTitle, string description) : base(goalTitle, description)
  {
    // set the goal completed to start off as false
    _goalCompleted = false;
    // this is all done in the base class
  }
// ### METHODS ############################################## //
  // method to get the class name
  public override string GetGoalType()
  {
    // create an object of the class
    OneOffGoal oneOff = new OneOffGoal();
    // return type as a string
    return oneOff.GetType().ToString();
  }

  // method to create & return an one off goal string
  public override string CreateGoalText()
  {           
    // list the goal for the user to see
    string goalText = $"{GetGoalType()}:{GetGoalTitle()}~|~{GetDescription()}~|~{GetPoints()}~|~{_goalCompleted}";
    // return the listed goal string
    return goalText; 
  }

}