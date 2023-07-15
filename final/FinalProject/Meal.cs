using System;
using System.IO;
using System.Reflection;

// ### CLASS ################################################ //
// base class for tracking a meal
public class Meal : Recipe
{
// ### VARIABLE ATTRIBUTES ################################## //
  // reference source: https://www.stevejgordon.co.uk/using-dateonly-and-timeonly-in-dotnet-6
  private DateOnly _date = DateOnly.FromDateTime(DateTime.Now); 
  private string _recipeCategoryMenuPrompt;
  
// ### CONSTRUCTORS ######################################### //
  // main constructor to set up a Meal object with the user's inputs used in Menu class
  public Meal(string category, string unit) :base (category, unit)
  {   
    // #1 Base assigns parameters passed in as values for _category and _unit
    // #2 Base uses FillValues which is overridden to have user assign values to _name & _portion
    // #3 Base uses FillFoodObjectsList which is overridden to use the date to identify the meal as well as have user fill _foodObjectsList     
    // #4 Base figures out and assign _calories
    // #5 Figure out and assign _portion
    int neededCalories = 2000;      
    _portion = (float)_calories/neededCalories *100;       
  }  

  // constructor for converting textfile to Meal object in Tracker Class
  public Meal(string stringAttributes) : base (stringAttributes)
  {
    // #1 base does textfile to Meal object uses DivideAttributes(stringAttributes) method, which
    // divides single string of attributes from a textfile into assigned individual attributes 
    // #2 takes in the last attribute of _combinedFoodStrings and creates & loads Food objects into _foodObjectsList    
    StringObjectToObject(DivideStringOfObjects());   
  }

// ### METHODS ############################################## //
  // method to create a string of the meal and its attributes for display
  public override string CreateDisplayString(int count, string numberMarker, string alternate)
  {    
    string space = "  ";
    if (count > 9)
    {
      space = " ";
    }        
    string mealString = $"{count}{numberMarker}{space}{_category} ({GetType()}) on {_date.ToLongDateString()} totaled {_calories} calories, using {_portion}{_unit} of your daily needed calories.";
    int subcount = 0;
    foreach (Tracked food in _foodObjectsList)
    {           
      subcount++;
      mealString += ($"\n    {food.CreateDisplayString(subcount, ".", "alter")}");
    }   
    return mealString; 
  }

// START OF GROUPING OF 1 METHOD THAT HELPS CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES
  // method to create & return a meal text string
  public override string CreateObjectString(string alternate)
  {   
    string alter1 = "";
    string alter2 = ""; 
    if (alternate == "alter")  
    {
      alter1 = "#|start|#";
      alter2 = "#|end|#";
      
    } 
    string combinedFoodStrings = ""; 
    string divider = "";
    int cycle = 0;
    foreach (Tracked food in _foodObjectsList)
    {
      ++cycle;
      if (cycle > 1)
      {
        divider = "*~*";
      }
      combinedFoodStrings += $"{divider}{food.CreateObjectString("alter")}";
    } 
    string mealString = $"{alter1}{GetType()}:|:{_date.Year}+|+{_date.Month}+|+{_date.Day}+|+{_category}+|+{_portion}+|+{_unit}+|+{_calories}*~*{combinedFoodStrings}{alter2}";           
    return mealString; 
  }
// END OF GROUPING OF 1 METHOD THAT HELPS CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES

// START OF GROUPING OF 1 OVERRIDEN METHOD THAT CONVERTS TEXT STRINGS TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR
  // method to divide the string attributes stirng into their object's variable attributes  
  protected override void DivideAttributes(string stringAttributes)
  {  
    string[] attributes = stringAttributes.Split("+|+"); // "-|-" need to change to differ from Recipe 
    if (attributes.Count() > 1)
    {
    _date = new DateOnly(int.Parse(attributes[0]), int.Parse(attributes[1]), int.Parse(attributes[2]));
    _category = attributes[3];
    _portion = float.Parse(attributes[4]);
    _unit = attributes[5];
    _calories = int.Parse(attributes[6]);
    _combinedFoodStrings = attributes[7];
    }
    else
    {
      // Console.WriteLine($"Meal's DivideAttributes attributes[0] = {attributes[0]}");
      _combinedFoodStrings = attributes[0];
    }
  }

   // method to divide _attributes into strings of Food objects
  protected override List<string> DivideStringOfObjects()
  {   
    _foodStringsList.Clear(); // empties the _foodStringsList of strings to prevent duplicating   
    int count = _combinedFoodStrings.Split("#|#").Count(); // count the number of splits 
    Console.WriteLine($"\nSTART A NEW MEAL ITEM The count is {count}"); 
    // seperate the string into strings of Recipe & Food objects
    string[] seperateObjects = _combinedFoodStrings.Split("#|#"); 
    for (int i = 0; i < count; i++) // use split count to add the right # of items
    { 
      Console.WriteLine($"seperateObjects[{i}] -> {seperateObjects[i]}"); 
      // don't add @|@ or an empty string to list if Recipe is last item in meal list
      if (seperateObjects[i] != "@|@" && !string.IsNullOrEmpty(seperateObjects[i])) 
      { 
        Console.WriteLine($"seperateObjects[{i}] -> {seperateObjects[i]} added to the _foodStringsList");
        _foodStringsList.Add(seperateObjects[i]); // load strings of Food & Recipe objects into list        
      }
    }    
    List<string> tempHolder = new List<string>(); 
    tempHolder.Clear(); // empty the tempHolder list of strings to prevent any duplication  
    Console.WriteLine($"The starting tempList count is {tempHolder.Count()}");
    foreach (string seperated in _foodStringsList)
    {    
      Console.WriteLine($"\nThe list item is {seperated}");     
      string[] checkString = seperated.Split(":", 2); // split off 1st class name (@|@*~*Food sometimes)      
      if (checkString[0] == "Recipe") // this indicates a Recipe string
      {
      Console.WriteLine($"recipe[0] -> {seperated}");
      tempHolder.Add(seperated); // add Recipe string to temp list to preserve order of strings
      }
      if (checkString[0] == "Food" || checkString[0] == "@|@*~*Food") // this indicates it is 1 or more Food strings
      {
      int countedSplits = seperated.Split("*~*").Count(); // count the number of splits 
      string[] divideUPFood = seperated.Split("*~*"); // split "@|@" & Food from Food
      for (int i = 0; i < countedSplits; i++) // use split count to add the right # of items
      {
        Console.WriteLine($"food[{i}] -> {divideUPFood[i]}"); // clearPostRecipeDivider[1]
        if (divideUPFood[i] != "@|@") // clear divider left in front of combined string of 1 or more Food objects
        {
          Console.WriteLine($"food[{i}] -> {divideUPFood[i]} added to tempHolder list");
          tempHolder.Add(divideUPFood[i]); // only add the Food strings to the temp list
        } 
      }  
      }
      int numberct = 0;
      foreach (string items in tempHolder)
      {
        numberct++;
        Console.WriteLine($"Item #{numberct} in tempList is {items}");
      }
      Console.WriteLine($"The endingtempList count is {tempHolder.Count()}");
    }
     Console.WriteLine($"The list count is {_foodStringsList.Count()}");
     foreach(string thing in tempHolder)
     {
      Console.WriteLine(thing);
     } 
    _foodStringsList.Clear(); // empty the _foodStringsList to reload different values 
    // reference source: https://www.c-sharpcorner.com/article/copy-items-from-one-list-to-another-list-in-c-sharp/
    _foodStringsList.AddRange(tempHolder); // put the contents of tempHolder list into _foodStringsList 
    int foodCt = 0;
    foreach (string fodder in _foodStringsList)
    {
      foodCt++;
      Console.WriteLine($"Food #{foodCt} in _foodStringsList is {fodder}");
    }
    return _foodStringsList; 
  } 
// END OF GROUPING OF 2 METHODS THAT CONVERTS TEXT STRINGS TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR 

// START OF GROUPING OF 1 METHOD USING A FOOD METHOD THAT CONVERTS OBJECT TO A STRING USED IN CONSTRUCTOR
  // method to create Tracked objects from text file strings
  protected override List<Tracked> StringObjectToObject(List<string> stringObjectList)
  {   
    int count = 0;
    string stringedObject= "";                                      
    string stringedAttributes = ""; 
    _foodObjectsList.Clear(); // empties the _foodStringsList of strings to prevent duplicating          
    foreach (string stringObject in stringObjectList)
    {     
      count = stringObject.Split("*~*").Count(); // count the number of splits 
      Console.WriteLine($"count for Split '*~* -> {count}");
      if (count == 1)                                                              
      {      
        string[] food = stringObject.Split(":|:"); // split the Food object lines that have no *~* seperators                           
        stringedObject= food[0]; // assign Food
        Console.WriteLine($"food[0] -> {food[0]}"); 
        if (stringObject.Split(":|:").Count() > 1)   
        {                                   
        stringedAttributes = food[1]; // assign Food's attributes as 1 string
        Console.WriteLine($"food[1] -> {food[1]}");
        }                                                    
      } 
      if (count > 1)                                                              
      { 
        // reference source: https://stackoverflow.com/questions/21519548/split-string-based-on-the-first-occurrence-of-the-character &
        // https://www.baeldung.com/java-split-string-first-delimiter
        string[] flawedRecipe = stringObject.Split("*~*", 2); // split Recipe where the 1st Food is attached & stop       
        string goodRecipeString = $"{flawedRecipe[0]}-|-{flawedRecipe[1]}"; // replace the *~* with -|- to add the foods as the last attribute string
        string[] recipe = goodRecipeString.Split(":|:", 2); // split the Recipe from its attributes
        stringedObject= recipe[0]; // assign Recipe
        stringedAttributes = recipe[1];
      }       
      if (!string.IsNullOrEmpty(stringedObject)) // to avoid throwing an error by sending an empty string
      {
      // reference source: https://learn.microsoft.com/en-us/dotnet/api/system.activator.createinstance?view=net-7.0#system-activator-createinstance(system-type-system-object())      
      // create a Tracked object or instance from the string of the Tracked base class or Tracked derived classes
      Tracked food = (Tracked)Activator.CreateInstance(Type.GetType(stringedObject), stringedAttributes);       
      _foodObjectsList.Add(food);
      }               
    }    
    return _foodObjectsList;
  }  
// END OF GROUPING OF 1 METHOD USING A FOOD METHOD THAT CONVERTS OBJECT TO A STRING USED IN CONSTRUCTOR
// END OF GROUPING OF 1 OVERRIDDEN METHOD THAT CONVERTS TEXT STRINGS TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR 

  // method to set prompts to pass into metods so repeated code doesn't need to be reentered
  protected override void SetPrompts()
  {    
    _menuLength = 7;
    // reference source: https://zetcode.com/csharp/dateonly/
    string date = _date.ToLongDateString(); 
    _foodCategoryMenuPrompt = $"\nWhich category of food are you adding to your {_category} for today, {date}?\nMake your selection by entering a number:\n   1)  Fruit\n   2)  Vegetable\n   3)  Grain Food\n   4)  Dairy Food\n   5)  Protein Food\n   6)  Liquid or Drink\n   7)  Recipe\nSelection: ";
    _recipeCategoryMenuPrompt = $"\nWhich category of recipe are you adding to your {_category} for today, {date}?\nMake your selection by entering a number:\n   1)  Dish Recipe\n   2)  Soup or Stew Recipe\n   3)  Salad Recipe\n   4)  Bread or Muffin Recipe\n   5)  Sandwich, Wrap, or Taco Recipe\n   6)  Meat Recipe\n   7)  Seafood Recipe\n   8)  Vegetarian Recipe\n   9)  Dessert Recipe\nSelection: ";
    _foodSelectionPrompt = $"\nBelow is a list of all the {_menuChoice} options available to add to your {_category} for today, {date}.\nMake your selection by entering its number:\n";
    _addFoodPrompt = "\nTo add the needed food item select '4 or 5' when you return to the Main Menu.";
    _fillListPrompt = $"\nDo you have another {_category} food to add to your {_category} for today, {date}? ";     
  } 

  // method to translate menu number selection into the food category
  protected override void NumberToCategory(string menuChoice)
  {
    string choice = menuChoice;
      switch (choice)
    {
      // RUN OPTION USER CHOSE
      case "1": // if they chose "Fruit"
        choice = "fruit";
        break;
      case "2": // if they chose "Vegetable"
        choice = "vegetable";
        break;
      case "3": // if they chose "Grain Food"
        choice = "grain food";
        break;
      case "4": // if they chose "Dairy Food"
        choice = "dairy food";
        break;
      case "5": // if they chose "Protein Food"
        choice = "protein food";
        break;    
      case "6": // if they chose "Liquid or Drink"
        choice = "liquid or drink";
        break;
      case "7": // if they chose "Recipe"
        choice = RecipeNumberToCategory(PresentRecipeCategoriesMenu());
        break;     
    } 
    _menuChoice = choice;
  }

  // method overriden to set the value for the _name
  protected override void FillValues()
  {
    // #1 ASSIGN _date & _category AS THE MEAL _name *************************************************** 
    _name = $"{_date} {_category}";
  }

  // method to show recip categories to add to the menu & return the choice
  private string PresentRecipeCategoriesMenu()
  {
    string selection = "No selection made.";
    // pass the PresentCategoryMenuPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator = new Validator("Use prompt", _recipeCategoryMenuPrompt);          
    selection = validator.SelectionCheck(9, "Don't Confirm"); // get an entry that is valid   
    return selection; // return the user's selection
  }

   // method to translate menu number selection into the recipe category
  private string RecipeNumberToCategory(string menuOption)
  {
    string choice = menuOption;
      switch (choice)
    {
      // RUN OPTION USER CHOSE
      case "1": // if they chose "Dish Recipe"
        choice = "dish";
        break;
      case "2": // if they chose "Soup or Stew Recipe"
        choice = "soup or stew";
        break;
      case "3": // if they chose "Salad Recipe"
        choice = "salad";
        break;
      case "4": // if they chose "Bread or Muffin Recipe"
        choice = "bread or muffin";
        break;
      case "5": // if they chose "Sandwich, Wrap, or Taco Recipe"
        choice = "sandwich, wrap, or taco";
        break;
      case "6": // if they chose "Meat Recipe"
        choice = "meat";
        break;  
      case "7": // if they chose "Seafood Recipe"
        choice = "seafood";
        break;   
      case "8": // if they chose "Vegetarian Recipe"
        choice = "vegetarian";
        break; 
      case "9": // if they chose "Dessert Recipe"
        choice = "dessert";
        break;    
    } 
    return choice;
  }
}