using System;
using System.IO;
using System.Reflection;

// ### CLASS ################################################ //
// base class for tracking things
public class Tracker
{
// ### VARIABLE ATTRIBUTES ################################## //   
  private string _itemCategory; // variable to hold the category heading of item being tracked
  private int _amount;
  private int _streak; 
  
  protected List<Tracked> _items = new List<Tracked>();

// ### CONSTRUCTORS ######################################### //  
  public Tracker()
  {    
    // nothing needed in here 
  }

// ### METHODS ############################################## //
  public int TotalCalories()
  {
    return 10;
  }

  // method to figure out the total for the tracked value
  public virtual float TotalTrackedValue()
  {
    float number = 0;
    return number;
  }

  // method to put the item objects into a list
  public void LoadItem(Tracked item)
  {
    _items.Add(item);
  }

// START OF GROUPING OF 1 METHOD USING A FOOD METHOD THAT CONVERTS OBJECT TO A STRING USED IN MENU CLASS
  // method to save list objects to a text file
  public void ObjectsToTextFile(string filename) 
  {      
    using (StreamWriter outputFile = new StreamWriter(filename, true))
    {        
      foreach (Tracked item in _items)
      {
        // Food food = (Food)item; // cast item object as a Food to use its method
        outputFile.WriteLine($"{item.CreateObjectString("normal")}");
      }
    }
  }
// END OF GROUPING OF 1 METHOD USING A FOOD METHOD THAT CONVERTS OBJECT TO A STRING USED IN MENU CLASS

// START OF GROUPING OF 1 METHOD THAT USES FOOD CONSTRUCTOR TO CONVERT TEXT STRING TO OBJECT USED IN MENU CLASS
  // method to create objects from text file strings
  public void TextfileToOjects(string filename)
  { 
    _items.Clear(); // empties the _items object list to prevent duplicating    
    if (File.Exists(filename))
    {        
      string[] items = System.IO.File.ReadAllLines(filename);      
      foreach (string item in items)
      {
        // reference source: https://stackoverflow.com/questions/21519548/split-string-based-on-the-first-occurrence-of-the-character &
        // https://www.baeldung.com/java-split-string-first-delimiter
        // seperate the string into the object and its attributes using the colon
        string[] segments = item.Split(":|:", 2);  
        // reference source: https://learn.microsoft.com/en-us/dotnet/api/system.activator.createinstance?view=net-7.0#system-activator-createinstance(system-type-system-object())
        // create a Goal object or instance from the string of the Goal base class or Goal derived classes
        Tracked food = (Tracked)Activator.CreateInstance(Type.GetType(segments[0]), segments[1]);       
        _items.Add(food);            
      } 
    }
  }
// END OF GROUPING OF 1 METHOD THAT USES FOOD CONSTRUCTOR TO CONVERT TEXT STRING TO OBJECT USED IN MENU CLASS

  // method to display the desired item objects in the _items list
  public virtual void DisplayObjects()
  {   
    Console.WriteLine(); 
    int count = 0;  
    foreach (Tracked item in _items)
    {  
      count ++;     
      Console.WriteLine(item.CreateDisplayString(count, ")", "normal"));
    }    
  }

  public virtual void RemoveObject()
  {

  }
}