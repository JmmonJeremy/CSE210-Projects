using System;
using System.IO;
using System.Reflection;

// ### CLASS ################################################ //
// class for tracking meals and their calories and portions
public class MealTracker : Tracker
{
// ### VARIABLE ATTRIBUTES ################################## //   
  
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

  // method to display the desired item objects in the _items list
  public override void DisplayObjects()
  {    
    foreach (Meal item in _items)
    {       
      Console.WriteLine(item.CreateScreenString(item));
    }    
  }

// START OF GROUPING OF 1 METHOD THAT USES FOOD CONSTRUCTOR TO CONVERT TEXT STRING TO OBJECT USED IN MENU CLASS
  // method to create objects from text file strings
  public void StringObjectToOject(List<string[]> stringObjectList)
  {            
    foreach (string[] stringObject in stringObjectList)   
    foreach (string item in stringObject)
    {
      // seperate the string into the object and its attributes using the colon
      string[] segments = item.Split(":");  
      // reference source: https://learn.microsoft.com/en-us/dotnet/api/system.activator.createinstance?view=net-7.0#system-activator-createinstance(system-type-system-object())
      // create a Tracked object or instance from the string of the Tracked base class or Tracked derived classes
      Tracked food = (Tracked)Activator.CreateInstance(Type.GetType(segments[0]), segments[1]);       
      _items.Add(food);            
    }
  }
// END OF GROUPING OF 1 METHOD THAT USES FOOD CONSTRUCTOR TO CONVERT TEXT STRING TO OBJECT USED IN MENU CLASS
}