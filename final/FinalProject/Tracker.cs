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
        outputFile.WriteLine($"{item.CreateObjectString()}");
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
        // Console.WriteLine($"THIS IS THE CYCLE '{cycle}' OF THE LOOP DONE FOR EACH LINE IN THE TEXTFILE!!!                         CYCLE '{cycle}'");
        // Console.WriteLine($"Tracking textfile cycle: '{cycle}'!!!");                                   
        count = 0;
        // reference source: https://stackoverflow.com/questions/5340564/counting-how-many-times-a-certain-char-appears-in-a-string-before-any-other-char 
        count = item.Split("*~*").Count(); // count the number of splits                 
        string[] stringObjects = item.Split("*~*"); // seperate the string into strings of Food objects 
        for (int i = 0; i < count; i++)                                                
        {                                                                              
          string foodString = stringObjects[i];                                      
          // Console.WriteLine(foodString);                                            
          objectStringsList.Add(foodString);                                                                       
        } 
        int loop = 0;                                                                             
        foreach (string stringObject in objectStringsList)  // !!!!!!!!! ForeachLoop for string list                   
        {  
          loop++; 
          // Console.WriteLine($"#1 count = {count}");  
          // Console.WriteLine($"1ST CODE LOOP (pass #{loop}) THROUGH ALL TEXT LINES ADDED TO THE STRING FROM SPLITTIN *~* INSIDE TEXTFILE LOOP");                                                                     
          // Console.WriteLine($"Tracking textfile cycle: '{cycle}'!!!");                           
          if (count == 1)                                                              
          {                                                                          
            // Console.WriteLine($"I am doing the 1st conidition code of count ==1! (count = {count})");               
            // seperate the string into the object type and its attributes using the colon
            string[] segments = stringObject.Split(":|:");                            
            cappedObjectString = segments[0];                                      
            objectString = segments[1];                                             
            split = true;                                               
          }          
          if (count > 1)
          {
            // Console.WriteLine($"I am doing the 2nd conidition PART 1 code of count > 1! (count = {count})");          
            // seperate the string into the object type and its attributes using the colon
            string[] segments = stringObject.Split(":|:");  
            cappedObjectString = segments[0];
            objectString = segments[1];
            // Console.WriteLine($"Code does: stringObject.Split(':|:') => cappedObjectString: {cappedObjectString} & objectString: {objectString}");  
            // Console.WriteLine($"Code does a 'break' now which should STOP: 1ST CODE LOOP INSIDE TEXTFILE LOOP");     
            break;          
          }       
        }
        if (count > 1 || split == true)
        {
          // Console.WriteLine($"I am doing the 2nd conidition PART 2 'OR' split == true  code of count > 1! (count = {count}), but OUTSIDE: 1ST CODE LOOP INSIDE TEXTFILE LOOP");
          // Console.WriteLine($"!!!!!!!!!!!THIS REMOVED THE STRING IN objectStringsList[0]: {objectStringsList[0]}");
          objectStringsList.RemoveAt(0);
        }

        if (count > 1)
        {
          // Console.WriteLine($"I am doing the 2nd conidition PART 3 code of count > 1! (count = {count}), but OUTSIDE: 1ST CODE LOOP INSIDE TEXTFILE LOOP");
          int insideCycle = 0;
          foreach (string stringObject in objectStringsList) // !!!!!!!!! ForeachLoop for string list
          {
            // Console.WriteLine($"#2 count = {count}"); 
            // Console.WriteLine($"2ND CODE LOOP THROUGH ALL TEXT LINES ADDED TO THE STRING FROM SPLITTIN *~* INSIDE TEXTFILE LOOP");  
            insideCycle++;
            if (insideCycle == 1)
            {
              // Console.WriteLine("1st condition of being first loop inside 2ND CODE LOOP INSIDE TEXTFILE LOOP code = objectString += $'-|-{stringObject}'");  
              objectString += $"-|-{stringObject}";
              // Console.WriteLine($"count = {count} and ~|~objectString = {objectString}");
            }
            else
            {
              // Console.WriteLine("2nd condition of not being first loop inside 2ND CODE LOOP INSIDE TEXTFILE LOOP code = objectString += $'*~*{stringObject}'");
              objectString += $"*~*{stringObject}";
              // Console.WriteLine($"count = {count} and *~*objectString = {objectString}");
            }
          }          
        } 
        // Console.WriteLine($"count = {count} and the object is: {cappedObjectString} and the attributes are: {objectString}");
        Tracked food = (Tracked)Activator.CreateInstance(Type.GetType(cappedObjectString), objectString);       
        _items.Add(food); 
         if (count > 1)
        {
          // Console.WriteLine($"THIS IS AFTER ADDING OBJECT TO LIST (count = {count}), but OUTSIDE: 1ST CODE LOOP INSIDE TEXTFILE LOOP");                  
          int index = count - 2;
          // Console.WriteLine($"!!!!!!!!!!!THIS REMOVED THE STRING IN objectStringsList[0 - {index}]:");          
          if (index >= 0)
          for (int i = index; i >= 0; i--)
          {
          // Console.WriteLine($"Deleting index # {i}: {objectStringsList[i]}");
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
      Console.WriteLine(item.CreateDisplayString(count, ")"));
    }    
  }

  // // method to select the desired object in the list
  //   public int SelectObject(string date, string subCategory, string category)
  // {
  //   // #1 USER SELECTS OJECT FROM LIST **************************************************
  //   int indexNumber = 0; // for returning the index of the object desired
  //   int selectionNumber = 0; // for numbering the selection options
  //   int needsAddedNumber = 0; // for identifying when a user selects the needs to be added option
  //   // put together a string of objects to select from in a menu prompt to pass into the Validator object 
  //   string objectSelectionPrompt = $"\nBelow is a list of all the {subCategory} options available to add to your {category} for today, {date}.\nMake your selection by entering its number:\n";     
  //   foreach (Tracked item in _items)
  //   {              
  //     if (item.GetCategory() == subCategory)
  //     { 
  //       ++ needsAddedNumber;
  //       ++ selectionNumber;        
  //       objectSelectionPrompt += $"{item.CreateDisplayString(selectionNumber)}\n";
  //       _group.Add(item);
  //     }           
  //   }    
  //   ++ selectionNumber; // add one for the last added option
  //   string space = "  ";
  //   if (selectionNumber > 9)
  //   {
  //     space = " ";
  //   }
  //   objectSelectionPrompt += $"   {selectionNumber}.{space}The {subCategory} option needs to be added.\nSelection: ";       
  //   // pass the objectSelectionPrompt into the object & for the user's 
  //   // entry value put "Use prompt" since user will change value after the prompt
  //   Validator validator1 = new Validator("Use prompt", objectSelectionPrompt);    
  //   // set the method to use the prompt the first time the method is used with "Use Prompt"
  //   // also set to use the ConfirmEntry method after validating number with "Do ConfirmEntry"    
  //   indexNumber = validator1.StringNumberCheck("Use prompt", "Do ConfirmEntry") -1;       
  //   if (indexNumber == needsAddedNumber) 
  //   {
  //     indexNumber = -1; // if the item user wants isn't in the list return a -1 to indicate that
  //   }   
  //   return indexNumber;
  // }

  // // method to return the selected object from the list
  // public Tracked ReturnObject(int indexNumber)
  // {   
  //   Tracked selection = _group[indexNumber]; 
  //   // // debugging code for selection picking the wrong food item
  //   // Console.WriteLine($"The indexNumber is {indexNumber} and the selection is {selection.CreateDisplayString(indexNumber+1)}.");   
  //   return selection;  
  // }

  public virtual void RemoveObject()
  {

  }
}