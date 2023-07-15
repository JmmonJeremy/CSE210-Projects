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
  public virtual void TextfileToOjects(string filename)
  {  
    int cycle = 0;  
    int count = 0;                                                                  
    List<string> objectStringsList = new List<string>();                            
    string objectString = ""; // to hold the object string                          
    string cappedObjectString = ""; // to hold the object string capped with splitter characters    
    _items.Clear(); // empties the _items object list to prevent duplicating      
    if (File.Exists(filename))                                                         
    {        
      string[] items = System.IO.File.ReadAllLines(filename);                       
      foreach (string item in items)                                                  
      {    
        bool split = false;                                                                                    
        cycle++;                                      
        count = 0;
        // reference source: https://stackoverflow.com/questions/5340564/counting-how-many-times-a-certain-char-appears-in-a-string-before-any-other-char 
        count = item.Split("*~*").Count(); // count the number of splits                 
        string[] stringObjects = item.Split("*~*"); // seperate the string into strings of Food objects 
        for (int i = 0; i < count; i++)                                                
        {                                                                              
          string foodString = stringObjects[i];                                            
          objectStringsList.Add(foodString);                                                                       
        } 
        int loop = 0;                                                                             
        foreach (string stringObject in objectStringsList)  // !!!!!!!!! ForeachLoop for string list                   
        {  
          loop++;                                  
          if (count == 1)                                                              
          {                      
            // seperate the string into the object type and its attributes using the colon
            string[] segments = stringObject.Split(":|:");                            
            cappedObjectString = segments[0];                                      
            objectString = segments[1];                                             
            split = true;                                               
          }          
          if (count > 1)
          {                  
            // seperate the string into the object type and its attributes using the colon
            string[] segments = stringObject.Split(":|:");  
            cappedObjectString = segments[0];
            objectString = segments[1];               
            break;          
          }       
        }
        if (count > 1 || split == true)
        {        
          objectStringsList.RemoveAt(0);
        }

        if (count > 1)
        {       
          int insideCycle = 0;
          foreach (string stringObject in objectStringsList) // !!!!!!!!! ForeachLoop for string list
          {            
            insideCycle++;
            if (insideCycle == 1)
            {              
              objectString += $"-|-{stringObject}";             
            }
            else
            {            
              objectString += $"*~*{stringObject}";          
            }
          }          
        }         
        Tracked food = (Tracked)Activator.CreateInstance(Type.GetType(cappedObjectString), objectString);       
        _items.Add(food); 
         if (count > 1)
        {                        
          int index = count - 2;        ;          
          if (index >= 0)
          for (int i = index; i >= 0; i--)
          {         
          objectStringsList.RemoveAt(i);                
          }         
        }
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