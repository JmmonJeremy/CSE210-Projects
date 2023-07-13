using System;
using System.IO;
using System.Reflection;

// ### CLASS ################################################ //
// class for tracking meals and their calories and portions
public class FoodComboTracker : Tracker
{
// ### VARIABLE ATTRIBUTES ################################## //   
  private string _foodComboSet; // variable to hold the set being tracked  
  private string _foodSelectionPrompt;  
  private List<Tracked> _group = new List<Tracked>();
 

// ### CONSTRUCTORS ######################################### //  
  public FoodComboTracker() : base()
  {
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

   // method to select the desired object in the list
    public int SelectObject(string foodSelectionPrompt, string subCategory)
  {
    // #1 USER SELECTS OJECT FROM LIST **************************************************
    int indexNumber = 0; // for returning the index of the object desired
    int selectionNumber = 0; // for numbering the selection options
    int needsAddedNumber = 0; // for identifying when a user selects the needs to be added option
    // put together a string of objects to select from in a menu prompt to pass into the Validator object 
    _foodSelectionPrompt = foodSelectionPrompt;     
    foreach (Tracked item in _items)
    {               
      if (item.GetCategory() == subCategory)
      {         
        ++ needsAddedNumber;
        ++ selectionNumber;        
        foodSelectionPrompt += $"{item.CreateDisplayString(selectionNumber, ")")}\n";
        _group.Add(item);
      }           
    }    
    ++ selectionNumber; // add one for the last added option
    string space = "  ";
    if (selectionNumber > 9)
    {
      space = " ";
    }
    foodSelectionPrompt += $"{selectionNumber}){space}The {subCategory} option needs to be added.\nSelection: ";       
    // pass the foodSelectionPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt  
    Validator validator = new Validator("Use prompt", foodSelectionPrompt);          
    indexNumber = int.Parse(validator.SelectionCheck(_group.Count +1, "Do Confirm")) -1; // get a valid entry & confirm as the user's choice      
    if (indexNumber == needsAddedNumber) 
    {
      indexNumber = -1; // if the item user wants isn't in the list return a -1 to indicate that
    }   
    return indexNumber;
  }

  // START OF GROUPING OF 1 METHOD THAT USES FOOD CONSTRUCTOR TO CONVERT TEXT STRING TO OBJECT USED IN MENU CLASS
  // method to create objects from text file strings
  public override void TextfileToOjects(string filename)
  {  
    int cycle = 0;  
    int count = 0;                                                                  
    List<string> objectStringsList = new List<string>();                            
    string objectString = ""; // to hold the object string                          
    string cappedObjectString = ""; // to hold the object string capped with splitter characters 
    string divider = "-|-";   
    _items.Clear(); // empties the _items object list to prevent duplicating      
    if (File.Exists(filename))                                                         
    {        
      string[] items = System.IO.File.ReadAllLines(filename);                       
      foreach (string item in items)                                                  
      {
        // string[] mealParts = item.Split(":|:", 2);
        // // string[] mealParts = item.Split("#|#");
        // if (mealParts[0] == "Meal")
        // {        
        // string mealClass = mealParts[0];
        // string mealAtts = mealParts[1];
        // Console.WriteLine($"mealParts[0] = {mealParts[0]} &&& mealParts[1] = {mealParts[1]}"); 
        // Tracked myMeal = (Tracked)Activator.CreateInstance(Type.GetType(mealParts[0]), mealParts[1]);               
        // _items.Add(myMeal);
        // }     
        bool split = false;                                                                                    
        cycle++;
        // Console.WriteLine($"THIS IS THE CYCLE '{cycle}' OF THE LOOP DONE FOR EACH LINE IN THE TEXTFILE!!!                         CYCLE '{cycle}'");
        // Console.WriteLine($"Tracking textfile cycle: '{cycle}'!!!");                                   
        count = 0;
        // Console.WriteLine($"mealParts[0] = {mealParts[0]} &&& mealParts[1] = {mealParts[1]}"); 
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
            Tracked recipe = new Recipe("Set up empty");
            Tracked meal = new Meal("Set up empty");
            string recipeType = recipe.GetType().ToString();
            string mealType = meal.GetType().ToString();
            if (cappedObjectString == mealType)
            {
              divider = "+|+";
            }
            else
            {
              divider = "-|-";
            }
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
              // Console.WriteLine($"The divider is: {divider}");           
              // Console.WriteLine("1st condition of being first loop inside 2ND CODE LOOP INSIDE TEXTFILE LOOP code = objectString += $'-|-{stringObject}'");  
            objectString += $"{divider}{stringObject}";
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
        if(!string.IsNullOrEmpty(cappedObjectString))
        { 
            // Console.WriteLine($"cappedObjectString = {cappedObjectString}"); 
            // Console.WriteLine($"objectSting = {objectString}");
            // Console.WriteLine($"count = {count} and the object is: {cappedObjectString} and the attributes are: {objectString}");
            Tracked food = (Tracked)Activator.CreateInstance(Type.GetType(cappedObjectString), objectString);               
            _items.Add(food); 
            foreach (Tracked thing in _items)
            {
              Console.WriteLine($"");
            }
        }
        else
        {
          // Console.WriteLine($"cappedObjectString = {cappedObjectString}"); 
        }   
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
  }

  // method to return the selected object from the list
  public Tracked ReturnObject(int indexNumber)
  {   
    Tracked selection = _group[indexNumber]; 
    // // debugging code for selection picking the wrong food item
    // Console.WriteLine($"The indexNumber is {indexNumber} and the selection is {selection.CreateDisplayString(indexNumber+1)}.");   
    return selection;  
  }

  public override void RemoveObject()
  {
    base.RemoveObject();
  }
}