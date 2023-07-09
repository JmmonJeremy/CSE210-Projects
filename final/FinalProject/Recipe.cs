using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

// ### CLASS ################################################ //
// base class for tracking a recipe
public class Recipe : Tracked
{
// ### VARIABLE ATTRIBUTES ################################## //
  // reference source: https://www.stevejgordon.co.uk/using-dateonly-and-timeonly-in-dotnet-6
  private DateOnly _date = DateOnly.FromDateTime(DateTime.Now);   
  private string _recipeFoodStrings;
  private List<string> _recipeList = new List<string>(); // holds a list of the foods ina a recipe as strings
  private List<Tracked> _recipe = new List<Tracked>(); // holds a saved list of Food objects for a recipe
  
// ### CONSTRUCTORS ######################################### //
  // main constructor to set up a Recipe object with the user's inputs used in Menu class
  public Recipe(string category, string unit) :base (category, unit)
  {   
    // Base assigns parameters passed in as values for _category and _unit
    // TODAY'S DATE IS ASSIGNED TO RECIPE OBJECT & USER ENTERS FOODS INTO ITS _recipeList
    FillRecipe();     
  }  

  // constructor for converting textfile to Recipe object in Tracker Class
  public Recipe(string stringAttributes) : base (stringAttributes)
  {
    // #1 base does textfile to Recipe object uses DivideAttributes(stringAttributes) method, which
    // divides single string of attributes from a textfile into assigned individual attributes 
    // #2 takes in the last attribut of _recipeFoodStrings and creates & loads Food objects into _recipe list
    StringObjectToObject(DivideStringOfObjects(_recipeFoodStrings));
  }

// ### METHODS ############################################## //

  // method to show food categories to add to the recipe & return the choice
  private string PresentRecipeCategoryMenu(string date)
  {
    string selection = "No selection made.";
    Console.WriteLine($"\nWhich category of food are you adding to your {_category} for today, {date}?");
    string RecipeCategoryMenuPrompt = "Make your selection by entering a number:\n   1)  Fruit\n   2)  Vegetable\n   3)  Grain Food\n   4)  Dairy Food\n   5)  Protein Food\n   6)  Liquid or Drink\n   7)  Oil or Fat\n   8)  Other Food\nSelection: ";
    // pass the PresentCategoryMenuPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator = new Validator("Use prompt", RecipeCategoryMenuPrompt);          
    selection = validator.SelectionCheck(8, "Don't Confirm"); // get an entry that is valid   
    return selection; // return the user's selection
  }

  // method to translate menu number selection into the food category
  private string NumberToCategory(string menuOption)
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
    return choice;
  }

  // method to list the foods in the category and have the user add the object to the recipe
  private void AddToRecipe(string recipe, string date)
  {    
    string recipeItem = NumberToCategory(PresentRecipeCategoryMenu(date));     
    FoodTracker foods = new FoodTracker();
    foods.TextfileToOjects("foods.txt", ":|:"); // load the list with the saved food in textfile
    int selection = foods.SelectObject(date, recipeItem, recipe);
    if (selection == -1) // if the user chose the food needs to be added
    {
      // do something to help the user be able to add the food item 
      Console.WriteLine("\nTo add the needed food item select '5' when you return to the Main Menu.");     
    }
    else
    {
      Tracked food = foods.ReturnObject(selection);
      _recipe.Add(food);
    }
  }
  
  // method to fill the recipe the foods the user ate
  private void FillRecipe()
  {
    // #1 ASSIGN TODAY'S DATE TO _date *******************************************
    // reference source: https://zetcode.com/csharp/dateonly/
    string date = _date.ToLongDateString(); 
    // #2 USER FILLS _recipeList ***************************************************    
    string done = "yes";
    while (done == "yes")
    {      
      AddToRecipe(_category, date);      
      Console.Write($"\nDo you have another {_category} {_unit} to add to your {_category} for today, {date}? ");
      done = Console.ReadLine();
    }    
  }

// START OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES
  // method to create & return a recipe text string
  public override string CreateObjectString()
  {    
    string recipeList = ""; 
    string divider = "";
    int cycle = 0;
    foreach (Tracked recipeFood in _recipe)
    {
      ++cycle;
      if (cycle > 1)
      {
        divider = "*~*";
      }
      recipeList += $"{divider}{recipeFood.CreateObjectString()}";
    } 
    string recipeString = $"{GetType()}:||:{_date.Year}-|-{_date.Month}-|-{_date.Day}-|-{_category}-|-{recipeList}";    
    return recipeString; 
  }

  // method to create a string of the recipe and its attributes for display
  public override string CreateDisplayString(int count)
  {        
    string recipeString = $"{count}) {GetType()} of {_category} on {_date.ToLongDateString()}.";
    int subcount = 0;
    foreach (Food food in _recipe)
    {
      subcount++;
      recipeString += ($"\n{food.CreateDisplayString(subcount)}");
    } 
    return recipeString; 
  }
// END OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES

// START OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR
  // method to divide _attributes into strings of Food objects
  private List<string> DivideStringOfObjects(string recipeFoodsString)
  {     
    _recipeList.Clear(); // empties the _recipeList of strings to prevent duplicating  
    // reference source: https://stackoverflow.com/questions/5340564/counting-how-many-times-a-certain-char-appears-in-a-string-before-any-other-char 
    int count = recipeFoodsString.Split("*~*").Count(); // count the number of splits    
    string[] stringObjects = recipeFoodsString.Split("*~*"); // seperate the string into strings of Food objects  
    for (int i = 0; i < count; i++)
    {
      string foodString = stringObjects[i];
      // Console.WriteLine(foodString);       
      _recipeList.Add(foodString); 
    }  
    return _recipeList; 
  }
  
// START OF GROUPING OF 1 METHOD THAT USES FOOD CONSTRUCTOR TO CONVERT TEXT STRING TO OBJECT USED IN MENU CLASS
  // method to create Tracked objects from text file strings
  private List<Tracked> StringObjectToObject(List<string> stringObjectList)
  {   
    _recipe.Clear(); // empties the _recipeList of strings to prevent duplicating          
    foreach (string stringObject in stringObjectList)
    {       
      // seperate the string into the object and its attributes using the colon
      string[] segments = stringObject.Split(":|:");  
      // reference source: https://learn.microsoft.com/en-us/dotnet/api/system.activator.createinstance?view=net-7.0#system-activator-createinstance(system-type-system-object())
      // create a Tracked object or instance from the string of the Tracked base class or Tracked derived classes
      Tracked food = (Tracked)Activator.CreateInstance(Type.GetType(segments[0]), segments[1]);       
      _recipe.Add(food);      
    }    
    return _recipe;
  }
// END OF GROUPING OF 1 METHOD THAT USES FOOD CONSTRUCTOR TO CONVERT TEXT STRING TO OBJECT USED IN MENU CLASS

  // method to divide the string attributes stirng into their object's variable attributes  
  public override void DivideAttributes(string stringAttributes)
  {  
    string[] attributes = stringAttributes.Split("-|-");    
    _date = new DateOnly(int.Parse(attributes[0]), int.Parse(attributes[1]), int.Parse(attributes[2]));
    _category = attributes[3];
    _recipeFoodStrings = attributes[4];
  }
// END OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR
}