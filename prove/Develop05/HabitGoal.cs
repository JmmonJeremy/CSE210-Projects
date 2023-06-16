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
  // and to return used goals saved to a textfile
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
  // method to get the class name
  public override string GetGoalType()
  {
    // create an object of the class
    HabitGoal habit = new HabitGoal();
    // return type as a string
    return habit.GetType().ToString();
  }

  // method to break up retrieved attribute into the different variables
  public override void DivideAttributes()
  {   
    // reference source: https://www.c-sharpcorner.com/UploadFile/mahesh/split-string-in-C-Sharp/#
    // split the attribute string by its "~|~" separator characters
    // ~|~goal title~|~description~|~point value
    string[] attributes = GetAttributes().Split("~|~");
    // fill the _goalTitle variable with the right hand side of the 1st split
    SetGoalTitle(attributes[1]);
    // fill the _description variable with the next string from the split
    SetDescription(attributes[2]);
    // fill the _points variable with the next string from the split converted to an int
    SetPoints(int.Parse(attributes[3]));
  }
}