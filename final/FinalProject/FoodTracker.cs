using System;
using System.IO;
using System.Reflection;

// ### CLASS ################################################ //
// class for tracking the different categories of foods & their calories and portions
public class FoodTracker : Tracker
{
// ### VARIABLE ATTRIBUTES ################################## //  
  private string _foodSet; // variable to hold the set being tracked

// ### CONSTRUCTORS ######################################### //  
  public FoodTracker() : base()
  {
    // nothing needed in here 
  }

// ### METHODS ############################################## //
  // method to figure out the total for the tracked value
  public override float TotalTrackedValue()
  {
    float number = 0;
    return number;
  }

  // method to remove a food from the list
  public void RemoveFood()
  {

  }
}