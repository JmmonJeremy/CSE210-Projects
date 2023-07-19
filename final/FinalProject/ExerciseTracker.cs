using System;
using System.IO;
using System.Reflection;

// ### CLASS ################################################ //
// class for tracking the different categories of exercises/workouts & the calories they burn and minutes done
public class ExerciseTracker : Tracker
{
// ### VARIABLE ATTRIBUTES ################################## //   
  private string _exerciseSet; // variable to hold the set being tracked
  
// ### CONSTRUCTORS ######################################### //  
  public ExerciseTracker() : base()
  {
    // 1st use method to load the values into the variable attritutes
    // nothing needed in here 
  }

// ### METHODS ############################################## //

  
  // method to figure out the total for the tracked value
  public override float TotalTrackedValue()
  {
    return base.TotalTrackedValue();
  }

  public override void RemoveObject()
  {
    base.DisplayObjects();
  }
}