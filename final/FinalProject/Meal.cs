using System;
using System.IO;
using System.Reflection;

// ### CLASS ################################################ //
// base class for meals
public class Meal : Tracked
{
// ### VARIABLE ATTRIBUTES ################################## //
  // reference source: https://www.stevejgordon.co.uk/using-dateonly-and-timeonly-in-dotnet-6
  private DateOnly _date = DateOnly.FromDateTime(DateTime.Now);   
  private string _mealType; 
  private string _mealFood; 
  private List<string> _mealList = new List<string>(); // change this to a food object list
  private List<Food> _foods = new List<Food>(); // holds the saved list of foods
  
// ### CONSTRUCTORS ######################################### //
  // main constructor to set up a Meal object with the user's inputs used in Menu class
  public Meal(string category, string unit) :base (category, unit)
  {     
    // #1 ASSIGN TODAY'S DATE TO _date *****************************************
    // reference source: https://zetcode.com/csharp/dateonly/
    string date = _date.ToLongDateString();    
    // #2 USER SETS _mealList ***************************************************
    // change this to a method that asks for foods until the list is full !!!!!!!!!!!!!!!!
    string done = "yes";
    while (done == "yes")
    {
      // first ask which category of food it is ie. fruit, vegetable, etc !!!!!!!!!!!!!!!!!
      // change this to a choice from a list of Food objects method !!!!!!!!!!!!!!!!!!!!!!!
      string foodPrompt = $"What food needs to be added to your {_category} for today, {date}? ";    
      // pass the foodPrompt into the object & for the user's 
      // entry value put "Use prompt" since user will change value after the prompt
      Validator validator2 = new Validator("Use prompt", foodPrompt);    
      // with "Use prompt" set the method to to use the prompt the first time the method is used
      _mealFood = validator2.ConfirmEntry("Use prompt");
      _mealList.Add(_mealFood);
      Console.Write($"\nDo you have another {category} to add? ");
      done = Console.ReadLine();
    }    
  }  

  // constructor for converting textfile to Meal object in Tracker Class
  public Meal(string stringAttributes) : base (stringAttributes)
  {
    // For textfile to Food object uses DivideAttributes(stringAttributes) method, which
    // divides single string of attributes from a textfile into assigned individual attributes 
  }

// ### METHODS ############################################## // 
  // method to show food categories to add to the meal & return the choice
  public string PresentMealCategoryMenu()
  {
    string selection = "No selection made.";
    Console.WriteLine($"\nWhich category of food are you adding to your {_category}?");
    string MealCategoryMenuPrompt = "Make your selection by entering a number:\n  1 - Fruit\n  2 - Vegetable\n  3 - Grain Food\n  4 - Dairy Food\n  5 - Protein Food\n  6 - Oil or Fat\n  7 - Liquid or Drink\n  8 - The meal is complete\nSelection: ";
    // pass the RemoveFoodMenuPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator = new Validator("Use prompt", MealCategoryMenuPrompt);          
    selection = validator.SelectionCheck(8, "Don't Confirm"); // get an entry that is valid   
    return selection; // return the user's selection
  }

  // method to list the foods in the category and have the user add the object to the meal
  public void AddToMeal()
  {    
    FoodTracker foods = new FoodTracker();
    foods.TextfileToOjects("foods.txt");
    foods.DisplayObjects("fruit");
  }

  // method to figure out cup value of the meal
  public virtual void DeterminePortionValue()
  {
    
  }

// START OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES
    // method to create & return a meal text string
  public override string CreateTrackedString(Object type)
  {    
    string mealList = ""; 
    foreach (string mealFood in _mealList)
    {
      mealList += $"~|~{mealFood}";
    } 
    string mealString = $"{type.GetType()}:{_date.Year}~|~{_date.Month}~|~{_date.Day}~|~{_mealType}{mealList}";    
    return mealString; 
  }
// END OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES

// START OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR
  // method to divide the string attributes stirng into their object's variable attributes  
  public override void DivideAttributes(string stringAttributes)
  {       
    string[] attributes = stringAttributes.Split("~|~");    
    _date = new DateOnly(int.Parse(attributes[0]), int.Parse(attributes[1]), int.Parse(attributes[2]));
    _mealType = attributes[3];  
    for (int i = 4; i < attributes.Count(); i++) 
    {          
      _mealList.Add(attributes[i]); // add remaining items to the list        
    }    
  }
// END OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR
}