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
  // method to figure out the total for the tracked value
  public virtual void TotalTrackedValue()
  {

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
        outputFile.WriteLine($"{item.CreateTrackedString(item)}");
      }
    }
  }
// END OF GROUPING OF 1 METHOD USING A FOOD METHOD THAT CONVERTS OBJECT TO A STRING USED IN MENU CLASS

// START OF GROUPING OF 1 METHOD THAT USES FOOD CONSTRUCTOR TO CONVERT TEXT STRING TO OBJECT USED IN MENU CLASS
  // method to create objects from text file strings
  public void TextfileToOjects(string filename, string divider)
  {  
    _items.Clear(); // empties the _items object list to prevent duplicating    
    if (File.Exists(filename))
    {        
      string[] items = System.IO.File.ReadAllLines(filename);      
      foreach (string item in items)
      {
        // seperate the string into the object and its attributes using the colon
        string[] segments = item.Split(divider);  
        // reference source: https://learn.microsoft.com/en-us/dotnet/api/system.activator.createinstance?view=net-7.0#system-activator-createinstance(system-type-system-object())
        // create a Tracked object or instance from the string of the Tracked base class or Tracked derived classes
        Tracked food = (Tracked)Activator.CreateInstance(Type.GetType(segments[0]), segments[1]);       
        _items.Add(food);            
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
// END OF GROUPING OF 1 METHOD THAT USES FOOD CONSTRUCTOR TO CONVERT TEXT STRING TO OBJECT USED IN MENU CLASS

  // method to display the desired item objects in the _items list
  public virtual void DisplayObjects()
  {    
    foreach (Tracked item in _items)
    {       
      Console.WriteLine(item.CreateTrackedString(item));
    }    
  }

  // method to select the desired object in the list
    public int SelectObject(string date, string subCategory, string category)
  {
    // #1 USER SELECTS OJECT FROM LIST **************************************************
    int indexNumber = 0; // for returning the index of the object desired
    int selectionNumber = 0; // for numbering the selection options
    int needsAddedNumber = 0; // for identifying when a user selects the needs to be added option
    // put together a string of objects to select from in a menu prompt to pass into the Validator object 
    string objectSelectionPrompt = $"\nBelow is a list of all the {subCategory} options available to add to your {category} for today, {date}.\nMake your selection by entering its number:\n";     
    foreach (Tracked item in _items)
    {              
      if (item.GetCategory() == subCategory)
      { 
        ++ needsAddedNumber;
        ++ selectionNumber;        
        objectSelectionPrompt += $"  {selectionNumber} - {item.CreateSelectionString(item)}\n";
      }           
    }    
    ++ selectionNumber; // add one for the last added option
    objectSelectionPrompt += $"  {selectionNumber} - The {subCategory} option needs to be added.\nSelection: ";       
    // pass the objectSelectionPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator1 = new Validator("Use prompt", objectSelectionPrompt);    
    // set the method to use the prompt the first time the method is used with "Use Prompt"
    // also set to use the ConfirmEntry method after validating number with "Do ConfirmEntry"    
    indexNumber = validator1.StringNumberCheck("Use prompt", "Do ConfirmEntry") -1;       
    if (indexNumber == needsAddedNumber) 
    {
      indexNumber = -1; // if the item user wants isn't in the list return a -1 to indicate that
    }   
    return indexNumber;
  }

  // method to return the selected object from the list
  public Tracked ReturnObject(int indexNumber)
  {
    Tracked selection = (Tracked)_items[indexNumber];    
    return selection;  
  }
}