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

  // method to put the item objects into a list
  public override void LoadItem(Object item)
  {
    _items.Add((Meal)item); // cast item object as a Meal
  }

// START OF GROUPING OF 1 METHOD USING A MEAL METHOD THAT CONVERTS OBJECT TO A STRING USED IN MENU CLASS
  // method to save list objects to a text file
  public override void ObjectsToTextFile(string filename) 
  {      
    using (StreamWriter outputFile = new StreamWriter(filename, true))
    {        
      foreach (Object item in _items)
      {
        Meal meal = (Meal)item; // cast item object as a Meal to use its method
        outputFile.WriteLine($"{meal.CreateTrackedString(meal)}");
      }
    }
  }
// END OF GROUPING OF 1 METHOD USING A MEAL METHOD THAT CONVERTS OBJECT TO A STRING USED IN MENU CLASS

// START OF GROUPING OF 1 METHOD THAT USES MEAL CONSTRUCTOR TO CONVERT TEXT STRING TO OBJECT USED IN MENU CLASS
  // method to create objects from text file strings
  public override void TextfileToOjects(string filename)
  {  
    _items.Clear(); // empties the _items object list to prevent duplicating    
    if (File.Exists(filename))
    {        
      string[] items = System.IO.File.ReadAllLines(filename);      
      foreach (string item in items)
      {
        // seperate the string into the object and its attributes using the colon
        string[] segments = item.Split(":");  
        // reference source: https://learn.microsoft.com/en-us/dotnet/api/system.activator.createinstance?view=net-7.0#system-activator-createinstance(system-type-system-object())
        // create a Goal object or instance from the string of the Goal base class or Goal derived classes
        Meal meal = (Meal)Activator.CreateInstance(Type.GetType(segments[0]), segments[1]);   
        _items.Add(meal);            
      }     
    }
// NOT SURE IF THIS CODE IS NEEDED !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 
    else // if filename doesn't exist
    {       
      Console.ForegroundColor = ConsoleColor.Red;  
      // let the user know that this file doesn't exist
      Console.Write("\nThe ");
      // change the color of the text to green so the text stands out
      Console.ForegroundColor = ConsoleColor.Green;
      Console.Write("filename ");
      // change the color of the text to yellow for the single quote mark
      Console.ForegroundColor = ConsoleColor.Yellow;       
      Console.Write("'");
      // change the color of the text to green so the text stands out
      Console.ForegroundColor = ConsoleColor.Green;
      // reference source: https://reactgo.com/csharp-remove-last-n-characters-string/
      // show the user what they entered
      Console.Write(filename.Remove(filename.Length-4)); 
      // change the color of the text to yellow for the single quote mark
      Console.ForegroundColor = ConsoleColor.Yellow;       
      Console.Write("'");
      // change the color of the text to red so the text stands out as a warning
      Console.ForegroundColor = ConsoleColor.Red;      
      // let the user know that this file doesn't exist & to check their spelling
      Console.WriteLine(" does not exist.");
      // reset the text color to the original settings
      Console.ResetColor();
      Console.WriteLine("Please check the spelling of your filename and try again."); 
    }
  }
// END OF GROUPING OF 1 METHOD THAT USES MEAL CONSTRUCTOR TO CONVERT TEXT STRING TO OBJECT USED IN MENU CLASS

  // method to display the item objects in the _items list
  public override void DisplayObjects(string category)
  {
    foreach (Object item in _items)
    {
      Meal meal = (Meal)item; // cast item object as a Meal to use its method
      Console.WriteLine(meal.CreateTrackedString(meal));
    }
  }
}