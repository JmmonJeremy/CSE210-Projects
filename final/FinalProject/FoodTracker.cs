using System;
using System.IO;
using System.Reflection;

// ### CLASS ################################################ //
// class for tracking the different categories of foods & their calories and portions
public class FoodTracker : Tracker
{
// ### VARIABLE ATTRIBUTES ################################## //  
  
// ### CONSTRUCTORS ######################################### //  
  public FoodTracker() : base()
  {
    // nothing needed in here 
  }
// ### METHODS ############################################## //
  // method to display the desirec item objects in the _items list
  public override void DisplayObjects()
  { 
     foreach (Food item in _items)
    {
      Console.WriteLine(item.CreateTrackedString(item)); // cast item object as a Food to use its method
    }    
  }

  // method to return the selected object from the list
  public override Food ReturnObject(int indexNumber)
  {
    Food selection = (Food)_items[indexNumber];    
    return selection;  
  }

  // method to figure out the total for the tracked value
  public override void TotalTrackedValue()
  {
    
  }
}