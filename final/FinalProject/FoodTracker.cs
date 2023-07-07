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
  // method to display the desired item objects in the _items list
  public override void DisplayObjects(string category)
  { 
    Console.WriteLine($"\nBelow is a list of all the {category} options available to add to your meal.");
    Console.WriteLine($"Make your selection by entering its number:");   
    int selectionNumber = 0;
    foreach (Food item in _items)
    {              
      if (item.GetCategory() == category)
      { 
        ++ selectionNumber;        
        Console.WriteLine($"  {selectionNumber} - {item.CreateSelectionString(item)}");
      }           
    }
    ++ selectionNumber;
    Console.WriteLine($"  {selectionNumber} - The {category} option needs to be added."); 
    
  }

  // method to figure out the total for the tracked value
  public override void TotalTrackedValue()
  {
    
  }
}