using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

// ### CLASS ################################################ //
// base class for meals
public class Meal : Tracked
{
// ### VARIABLE ATTRIBUTES ################################## //
  // reference source: https://www.stevejgordon.co.uk/using-dateonly-and-timeonly-in-dotnet-6
  private DateOnly _date = DateOnly.FromDateTime(DateTime.Now); 
  private string _mealFoodStrings;
  private List<string> _mealList = new List<string>(); // holds a list of the foods ina a meal as strings
  private List<Tracked> _meal = new List<Tracked>(); // holds a saved list of Food objects for a meal
  
// ### CONSTRUCTORS ######################################### //
  // main constructor to set up a Meal object with the user's inputs used in Menu class
  public Meal(string category, string unit) :base (category, unit)
  {   
    // Base assigns parameters passed in as values for _category and _unit
    // TODAY'S DATE IS ASSIGNED TO MEAL OBJECT & USER ENTERS FOODS INTO ITS _mealList
    FillMeal();     
  }  

  // constructor for converting textfile to Meal object in Tracker Class
  public Meal(string stringAttributes) : base (stringAttributes)
  {
    // #1 base does textfile to Meal object uses DivideAttributes(stringAttributes) method, which
    // divides single string of attributes from a textfile into assigned individual attributes 
    // #2 takes in the last attribut of _mealFoodStrings and creates & loads Food objects into _meal list
    StringObjectToObject(CreateStringObjects(_mealFoodStrings));
  }

// ### METHODS ############################################## //
  // method to figure out cup value of the meal
  public virtual void DeterminePortionValue()
  {
    
  } 

  // method to show food categories to add to the meal & return the choice
  private string PresentMealCategoryMenu(string date)
  {
    string selection = "No selection made.";
    Console.WriteLine($"\nWhich category of food are you adding to your {_category} for today, {date}?");
    string MealCategoryMenuPrompt = "Make your selection by entering a number:\n   1)  Fruit\n   2)  Vegetable\n   3)  Grain Food\n   4)  Dairy Food\n   5)  Protein Food\n   6)  Oil or Fat\n   7)  Liquid or Drink\n   8)  Recipe\nSelection: ";
    // pass the RemoveFoodMenuPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator = new Validator("Use prompt", MealCategoryMenuPrompt);          
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
      case "6": // if they chose "Oil or Fat"
        choice = "oil or fat";
        break;
      case "7": // if they chose "Liquid or Drink"
        choice = "liquid or drink";
        break;
      case "8": // if they chose "The meal is complete"
        choice = "recipe";
        break;     
    } 
    return choice;
  }

  // method to list the foods in the category and have the user add the object to the meal
  private void AddToMeal(string meal, string date)
  {    
    string mealItem = NumberToCategory(PresentMealCategoryMenu(date));     
    FoodTracker foods = new FoodTracker();
    foods.TextfileToOjects("foods.txt", ":|:"); // load the list with the saved food in textfile
    int selection = foods.SelectObject(date, mealItem, meal);
    if (selection == -1) // if the user chose the food needs to be added
    {
      // do something to help the user be able to add the food item 
      Console.WriteLine("\nTo add the needed food item select '5' when you return to the Main Menu.");     
    }
    else
    {
      Tracked food = foods.ReturnObject(selection);
      _meal.Add(food);
    }
  }
  
  // method to fill the meal the foods the user ate
  private void FillMeal()
  {
    // #1 ASSIGN TODAY'S DATE TO _date *******************************************
    // reference source: https://zetcode.com/csharp/dateonly/
    string date = _date.ToLongDateString(); 
    // #2 USER FILLS _mealList ***************************************************    
    string done = "yes";
    while (done == "yes")
    {      
      AddToMeal(_category, date);      
      Console.Write($"\nDo you have another {_category} {_unit} to add to your {_category} for today, {date}? ");
      done = Console.ReadLine();
    }    
  }

// START OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES
  // method to create & return a meal text string
  public override string CreateTrackedString(Tracked type)
  {    
    string mealList = ""; 
    string divider = "";
    int cycle = 0;
    foreach (Tracked mealFood in _meal)
    {
      ++cycle;
      if (cycle > 1)
      {
        divider = "*~*";
      }
      mealList += $"{divider}{mealFood.CreateTrackedString(mealFood)}";
    } 
    string mealString = $"{type.GetType()}:||:{_date.Year}-|-{_date.Month}-|-{_date.Day}-|-{_category}-|-{mealList}";    
    return mealString; 
  }

  // method to create a string of the meal and its attributes for display
  public override string CreateDisplayString(Tracked type, int count)
  {        
    string mealString = $"{count}) {type.GetType()} of {_category} on {_date.ToLongDateString()}.";
    int subcount = 0;
    foreach (Food food in _meal)
    {
      subcount++;
      mealString += ($"\n{food.CreateDisplayString(food, subcount)}");
    } 
    return mealString; 
  }
// END OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES

// START OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR
  // method to divide _attributes into strings of Food objects
  private List<string> CreateStringObjects(string mealFoodsString)
  {     
    _mealList.Clear(); // empties the _mealList of strings to prevent duplicating  
    // reference source: https://stackoverflow.com/questions/5340564/counting-how-many-times-a-certain-char-appears-in-a-string-before-any-other-char 
    int count = mealFoodsString.Split("*~*").Count(); // count the number of splits    
    string[] stringObjects = mealFoodsString.Split("*~*"); // seperate the string into strings of Food objects  
    for (int i = 0; i < count; i++)
    {
      string foodString = stringObjects[i];
      // Console.WriteLine(foodString);       
      _mealList.Add(foodString); 
    }  
    return _mealList; 
  }

// START OF GROUPING OF 1 METHOD THAT USES FOOD CONSTRUCTOR TO CONVERT TEXT STRING TO OBJECT USED IN MENU CLASS
  // method to create Tracked objects from text file strings
  private List<Tracked> StringObjectToObject(List<string> stringObjectList)
  {   
    _meal.Clear(); // empties the _mealList of strings to prevent duplicating          
    foreach (string stringObject in stringObjectList)
    {       
      // seperate the string into the object and its attributes using the colon
      string[] segments = stringObject.Split(":|:");  
      // reference source: https://learn.microsoft.com/en-us/dotnet/api/system.activator.createinstance?view=net-7.0#system-activator-createinstance(system-type-system-object())
      // create a Tracked object or instance from the string of the Tracked base class or Tracked derived classes
      Tracked food = (Tracked)Activator.CreateInstance(Type.GetType(segments[0]), segments[1]);       
      _meal.Add(food);      
    }    
    return _meal;
  }
// END OF GROUPING OF 1 METHOD THAT USES FOOD CONSTRUCTOR TO CONVERT TEXT STRING TO OBJECT USED IN MENU CLASS

  // method to divide the string attributes stirng into their object's variable attributes  
  public override void DivideAttributes(string stringAttributes)
  {  
    string[] attributes = stringAttributes.Split("-|-");    
    _date = new DateOnly(int.Parse(attributes[0]), int.Parse(attributes[1]), int.Parse(attributes[2]));
    _category = attributes[3];
    _mealFoodStrings = attributes[4];
  }
// END OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR
}