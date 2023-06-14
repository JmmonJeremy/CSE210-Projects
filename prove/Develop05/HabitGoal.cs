using System;
using System.IO;

// ### CLASS ################################################ //
// class for habit goals
public class HabitGoal : Goal
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // variable
  

// ### CONSTRUCTORS ######################################### //
  // constructor to be able to use the HabitGoal methods
  public HabitGoal()
  {
    // nothing needed in here 
  }

  // constructor to pass in the goal title and description from the user
  public HabitGoal(string goalTitle, string description) : base(goalTitle, description)
  {
    // this is all done in the base class
  }
// ### METHODS ############################################## //
  // method
  public void CreateGoal()
  {     

  }

}