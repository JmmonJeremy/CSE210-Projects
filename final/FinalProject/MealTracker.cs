using System;
using System.IO;
using System.Reflection;

// ### CLASS ################################################ //
// class for tracking meals and their calories and portions
public class MealTracker : Tracker
{
// ### VARIABLE ATTRIBUTES ################################## //   
  private string _mealSet; // variable to hold the set being tracked

// ### CONSTRUCTORS ######################################### //  
  public MealTracker()
  {
    // nothing needed in here 
  }

// ### METHODS ############################################## //
  // method to figure out the total for the tracked value
  public override void TotalTrackedValue()
  {

  }
}