using System;
using System.IO;
using System.Reflection;

// ### CLASS ################################################ //
// class for tracking all health categories
public class HealthStatusTracker : Tracker
{
// ### VARIABLE ATTRIBUTES ################################## //   
  private string _itemName; // variable to hold the name of item being tracked
// ### CONSTRUCTORS ######################################### //  
  public HealthStatusTracker()
  {
    // 1st use method to load the values into the variable attritutes
    // nothing needed in here 
  }
// ### METHODS ############################################## //
  // method to figure out the total for the tracked value
  public override void TotalTrackedValue()
  {

  }
}