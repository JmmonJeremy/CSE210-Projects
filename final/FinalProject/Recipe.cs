using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

// ### CLASS ################################################ //
// base class for tracking a recipe
public class Recipe : Food
{
// ### VARIABLE ATTRIBUTES ################################## // 
  protected string _foodCategoryMenuPrompt;
  protected string _foodSelectionPrompt;
  protected string _addFoodPrompt;
  protected string _fillListPrompt;
  protected string _menuChoice;
  protected int _menuLength;  
  protected string _combinedFoodStrings = "";
  protected List<string> _foodStringsList = new List<string>(); // holds a list of the foods in a recipe as strings
  protected List<Tracked> _foodObjectsList = new List<Tracked>(); // holds a saved list of Food objects for a recipe
  
// ### CONSTRUCTORS ######################################### //
  // main constructor to set up a Recipe object with the user's inputs used in Menu class
  public Recipe(string category, string unit) :base (category, unit)
  {   

    // #1 Base assigns parameters passed in as values for _category and _unit
    // #2 Base uses FillValues which is overridden to have user assign values to _name & _portion
    // #3 sets prompts to be passed into methods to save repeating code by preventing having to rewrite code with override in derived classes
    SetPrompts();
    // #3 fills the recipe with the food objects kept in the _foodObjectsList
    FillFoodObjectsList();  
    // #3 Figure out and assign _calories    
    int mealCalories = 0;
    foreach (Tracked food in _foodObjectsList)
    {
      mealCalories += food.GetCalories();
    }
    _calories = mealCalories;    
  }  

  // constructor for converting textfile to Recipe object in Tracker Class
  public Recipe(string stringAttributes) : base (stringAttributes)
  {
    // #1 base does textfile to Recipe object uses DivideAttributes(stringAttributes) method, which
    // divides single string of attributes from a textfile into assigned individual attributes 
    // #2 takes in the last attribute of _combinedFoodStrings and creates & loads Food objects into _foodObjectsList list
    StringObjectToObject(DivideStringOfObjects());
  }

// ### METHODS ############################################## //
  // method to create a string of the recipe and its attributes for display
  public override string CreateDisplayString(int count, string numberMarker, string alternate)
  {   
    string subNumberMarker = ".";    
    string alter = ""; 
    if (alternate == "alter")
    {     
      alter = "    #";
      subNumberMarker = "-";
    } 
    if (_portion == 1)
    {
    // reference source: https://stackoverflow.com/questions/3573284/trim-last-character-from-a-string
    _unit = _unit.TrimEnd('s'); // change from plural to singular
    }   
    string space = "  ";
    if (count > 9)
    {
      space = " ";
    }      
    string recipeString = $"{count}{numberMarker}{space}{_name} ({char.ToUpper(_category[0]) + _category.Substring(1)} {GetType()}): {_portion} {_unit} = {_calories} calories";        
    int subcount = 0;
    foreach (Food food in _foodObjectsList)
    {      
      subcount++;
      recipeString += ($"\n    {alter}{food.CreateDisplayString(subcount, subNumberMarker, "normal")}");
    } 
    return recipeString; 
  }

// START OF GROUPING OF 1 METHOD THAT HELPS CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES
  // method to create & return a recipe text string
  public override string CreateObjectString(string alternate)
  {    
    string alter1 = "";
    string alter2 = ""; 
    if (alternate == "alter")  
    {
      alter1 = "@|@#|#";
      alter2 = "#|#@|@";
      
    } 
    if (_portion == 1)
    {
    // reference source: https://stackoverflow.com/questions/3573284/trim-last-character-from-a-string
    _unit = _unit.TrimEnd('s'); // change from plural to singular
    }  
    string _combinedFoodStrings = ""; 
    string divider = "";
    int cycle = 0;
    foreach (Tracked food in _foodObjectsList)
    {
      ++cycle;
      if (cycle > 1)
      {
        divider = "*~*";
      }
      _combinedFoodStrings += $"{divider}{food.CreateObjectString("normal")}";
    }   
    string recipeString = $"{alter1}{GetType()}:|:{_category}-|-{_portion}-|-{_unit}-|-{_calories}-|-{_name}*~*{_combinedFoodStrings}{alter2}";    
    return recipeString; 
  }
// END OF GROUPING OF 1 METHOD THAT HELPS CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES

// START OF GROUPING OF 3 METHODS THAT CONVERTS TEXT STRINGS TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR
  // method to divide the string attributes stirng into their object's variable attributes  
  protected override void DivideAttributes(string stringAttributes)
  {      
    string[] attributes = stringAttributes.Split("-|-");     
    _category = attributes[0];
    _portion = float.Parse(attributes[1]);
    _unit = attributes[2];
    _calories = int.Parse(attributes[3]);
    _name = attributes[4];
    if (attributes.Count() > 5)
    {
    _combinedFoodStrings = attributes[5];
    }
  }

  // method to divide _attributes into strings of Food objects
  protected virtual List<string> DivideStringOfObjects()
  {     
    _foodStringsList.Clear(); // empties the _foodStringsList of strings to prevent duplicating  
    // reference source: https://stackoverflow.com/questions/5340564/counting-how-many-times-a-certain-char-appears-in-a-string-before-any-other-char
    // Console.WriteLine($"The _combinedFoodStrings = {_combinedFoodStrings}"); 
    int count = _combinedFoodStrings.Split("*~*").Count(); // count the number of splits    
    string[] stringObjects = _combinedFoodStrings.Split("*~*"); // seperate the string into strings of Food objects  
    for (int i = 0; i < count; i++)
    {
      string foodString = stringObjects[i];         
      _foodStringsList.Add(foodString); 
    }     
    return _foodStringsList; 
  }

  // method to create Tracked objects from text file strings
  protected virtual List<Tracked> StringObjectToObject(List<string> stringObjectList)
  {   
    _foodObjectsList.Clear(); // empties the _foodStringsList of strings to prevent duplicating          
    foreach (string stringObject in stringObjectList)
    {       
      // seperate the string into the object and its attributes using the colon
      string[] segments = stringObject.Split(":|:");
      if (segments.Count() > 1)
      {     
      // reference source: https://learn.microsoft.com/en-us/dotnet/api/system.activator.createinstance?view=net-7.0#system-activator-createinstance(system-type-system-object())      
      // create a Tracked object or instance from the string of the Tracked base class or Tracked derived classes
      Tracked food = (Tracked)Activator.CreateInstance(Type.GetType(segments[0]), segments[1]);       
      _foodObjectsList.Add(food);       
      }          
    }    
    return _foodObjectsList;
  }  
// END OF GROUPING OF 3 METHODS THAT CONVERTS TEXT STRINGS TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR 

  // method to set prompts to pass into metods so repeated code doesn't need to be reentered
  protected virtual void SetPrompts()
  {    
    _menuLength = 8;
    _foodCategoryMenuPrompt = $"\nWhich category of food are you adding to your {_category}?\nMake your selection by entering a number:\n   1)  Fruit\n   2)  Vegetable\n   3)  Grain Food\n   4)  Dairy Food\n   5)  Protein Food\n   6)  Liquid or Drink\n   7)  Oil or Fat\n   8)  Other Food\nSelection: ";
    _foodSelectionPrompt = $"\nBelow is a list of all the {_menuChoice} options available to add to your {_category}.\nMake your selection by entering its number:\n";
    _addFoodPrompt = "\nTo add the needed food item select '4' when you return to the Main Menu.";
    _fillListPrompt = $"\nDo you have another ingredient to add to your {_name}? ";    
  }

  // method to show food categories to add to the recipe & return the choice
  protected string PresentFoodCategoriesMenu()
  {
    string selection = "No selection made.";
    // pass the PresentCategoryMenuPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator = new Validator("Use prompt", _foodCategoryMenuPrompt);          
    selection = validator.SelectionCheck(_menuLength, "Don't Confirm"); // get an entry that is valid   
    return selection; // return the user's selection
  }

  // method to translate menu number selection into the food category
  protected virtual void NumberToCategory(string menuOption)
  {
    string choice = menuOption;
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
      case "7": // if they chose "Oil or Fat"
        choice = "oil or fat";
        break;   
      case "8": // if they chose "Other Food"
        choice = "other food";
        break;     
    } 
    _menuChoice = choice;
  }

  // method to list the foods in the category and have the user add the Food object to the recipe or _foodObjectsList
  protected void AddToFoodObjectsList()
  {    
    NumberToCategory(PresentFoodCategoriesMenu());       
    FoodComboTracker foods = new FoodComboTracker();
    foods.TextfileToOjects("foods.txt"); // load the list with the saved food in textfile
    int selection = foods.SelectObject(_foodSelectionPrompt, _menuChoice);
    if (selection == -1) // if the user chose the food needs to be added
    {
      // do something to help the user be able to add the food item 
      Console.WriteLine(_addFoodPrompt);     
    }
    else
    {
      Tracked food = foods.ReturnObject(selection);
      _foodObjectsList.Add(food);
    }
  }

  // method overriden to set the value for the _name & _portion
  protected override void FillValues()
  {
    // #1 USER ASSIGNS THE RECIPE _name ***************************************************      
    string recipeNamePrompt = $"What is the name of the {_category} recipe you are entering? ";    
    // pass the recipeNamePrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator = new Validator("Use prompt", recipeNamePrompt);    
    // with "Use prompt" set the method to to use the prompt the first time the method is used
    _name = validator.ConfirmEntry("Use prompt");
    // #2 USER SETS RECIPE _portion ***************************************************
    string portionPrompt = $"How many {_unit} is the {_category} recipe you are adding? ";    
    // pass the portionPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator1 = new Validator("Use prompt", portionPrompt);    
    // set the method to use the prompt the first time the method is used with "Use Prompt"
    // also set to use the ConfirmEntry method after validating number with "Do ConfirmEntry"
    _portion = validator1.PosStringDecimalCheck("Use prompt", "Do ConfirmEntry");
  }
  
  // method to fill the recipe the foods the user ate
  protected void FillFoodObjectsList()
  {     
    // USER FILLS _foodObjectsList   
    string done = "yes";
    while (done == "yes")
    {      
      AddToFoodObjectsList();      
      Console.Write(_fillListPrompt);
      done = Console.ReadLine();
    }    
  }
}