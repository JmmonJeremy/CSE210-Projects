using System;
using System.IO;

// ### CLASS ################################################ //
// class for one-off goals
public class OneOffGoal : Goal
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // variable 
  

// ### CONSTRUCTORS ######################################### //
  // constructor used to return goals saved to a textfile by
  // creating an OneOffGoal object in the GetGoalType method  
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
  // method to get the class name
  public override string GetGoalType()
  {
    // create an object of the class
    OneOffGoal oneOff = new OneOffGoal();
    // return type as a string
    return oneOff.GetType().ToString();
  }

  // method to break up retrieved attribute into the different variables
  public override void DivideAttributes()
  {   
    // reference source: https://www.c-sharpcorner.com/UploadFile/mahesh/split-string-in-C-Sharp/#
    // split the attribute string by its "~|~" separator characters
    // ~|~goal title~|~description~|~point value~|~goal completed: true or false
    string[] attributes = GetAttributes().Split("~|~");
    // fill the _completedBox variable with the 1st string value in the list
    SetCompletedBox(attributes[0]);
    // fill the _goalTitle variable with the next string from the split
    SetGoalTitle(attributes[1]);
    // fill the _description variable with the next string from the split
    SetDescription(attributes[2]);
    // fill the _points variable with the next string from the split converted to an int
    SetPoints(int.Parse(attributes[3]));
    // reference source: https://stackoverflow.com/questions/49590754/convert-a-string-to-a-boolean-in-c-sharp
    // fill the _goalCompleted boolean with the next string from the split converted to a bool
    SetGoalCompleted(bool.Parse(attributes[4])); 
    // fill the _filename with the last string from the split
    SetFilename(attributes[5]);       
  }
}