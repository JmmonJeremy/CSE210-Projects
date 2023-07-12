using System;
using System.IO;
using System.Reflection;

// ### CLASS ################################################ //
// class for tracking all health categories
public class HealthStatusTracker : Tracker
{
// ### VARIABLE ATTRIBUTES ################################## //   
  private string _statSet; // variable to hold the set being tracked

// ### CONSTRUCTORS ######################################### //  
  public HealthStatusTracker() : base()
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

  public override void DisplayObjects()
  {
    base.DisplayObjects();
  }

  public override void RemoveObject()
  {
    base.RemoveObject();
  }
}