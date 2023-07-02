using System;
using System.IO;
using System.Reflection;

// ### CLASS ################################################ //
// base class for meals
public class Meal
{
// ### VARIABLE ATTRIBUTES ################################## //
  // reference source: https://www.stevejgordon.co.uk/using-dateonly-and-timeonly-in-dotnet-6
  private DateOnly _date = DateOnly.FromDateTime(DateTime.Now);   
  private string _mealType; 
  private string _mealFood; 
  private List<string> _mealList = new List<string>(); // change this to a food object list
  private string _mealAttributes; 
  
// ### CONSTRUCTORS ######################################### //
  // main constructor to set up a Meal object with the user's inputs used in Menu class
  public Meal(string mealType, string category)
  {     
    // #1 ASSIGN TODAY'S DATE TO _date *****************************************
    // reference source: https://zetcode.com/csharp/dateonly/
    string date = _date.ToLongDateString();
    // #2 ASSIGN _mealType **************************************************    
    _mealType = mealType;
    // #3 USER SETS _mealList ***************************************************
    // change this to a method that asks for foods until the list is full !!!!!!!!!!!!!!!!
    string done = "yes";
    while (done == "yes")
    {
      // first ask which category of food it is ie. fruit, vegetable, etc !!!!!!!!!!!!!!!!!
      // change this to a choice from a list of Food objects method !!!!!!!!!!!!!!!!!!!!!!!
      string foodPrompt = $"What food needs to be added to your {_mealType} for today, {date}? ";    
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

  // constructor for converting textfile to Meal object in Tracker Class & for the ClassToString method in derived classes
  public Meal(string stringAttributes)
  {
    if (stringAttributes == "Set up empty")
    {      
      // do nothing to have an empty object set up
    }
    else
    {      
      // divides single string of attributes from a textfile into assigned individual attributes
      DivideAttributes(stringAttributes); 
    }
  }

// ### METHODS ############################################## // 
  // method to figure out cup value of the meal
  public virtual void DeterminePortionValue()
  {
    
  }

// START OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES
  // method to turn the class name to a string
  public virtual string ClassToString()
  {    
    Meal meal = new Meal("Set up empty");    
    return meal.GetType().ToString();
  }

  // method to create & return a meal text string
  public virtual string CreateMealString()
  {    
    string mealList = ""; 
    foreach (string mealFood in _mealList)
    {
      mealList += $"~|~{mealFood}";
    } 
    string mealString = $"{ClassToString()}:{_date.Year}~|~{_date.Month}~|~{_date.Day}~|~{_mealType}{mealList}";    
    return mealString; 
  }
// END OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES

// START OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR
  // method to divide the string attributes stirng into their object's variable attributes  
  private void DivideAttributes(string stringAttributes)
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