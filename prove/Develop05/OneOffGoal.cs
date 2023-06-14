using System;
using System.IO;

// ### CLASS ################################################ //
// class for one-off goals
public class OneOffGoal : Goal
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // variable
  

// ### CONSTRUCTORS ######################################### //
  // constructor to be able to use the OneOffGoal methods
  public OneOffGoal()
  {
    // nothing needed in here 
  }

  // constructor to pass in the goal title and description from the user
  public OneOffGoal(string goalTitle, string description) : base(goalTitle, description)
  {
    // this is all done in the base class
  }
// ### METHODS ############################################## //
  // method
  public void CreateGoal()
  {     

  }

}