using System;
using System.IO;
using System.Reflection;

// ### CLASS ################################################ //
// base class for foods
public class Food : Tracked
{
// ### VARIABLE ATTRIBUTES ################################## //
  // private string _foodType;   
  private string _foodName;  
  // private int _portion; 
  // // private string _portionScale; 
  // private int _calories;  
  
// ### CONSTRUCTORS ######################################### //
  // main constructor to set up a Food object with the user's inputs used in Menu class
  public Food(string category, string measurement) :base (category, measurement)
  { 
    // _foodType = foodType;
    // _portionScale = portionScale;
    // #1 USER SETS _foodName **************************************************
    string foodNamePrompt = $"What is the name of the {_category}? ";    
    // pass the foodNamePrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator = new Validator("Use prompt", foodNamePrompt);    
    // with "Use prompt" set the method to to use the prompt the first time the method is used
    _foodName = validator.ConfirmEntry("Use prompt");
    // #2 USER SETS _portion ***************************************************
    string portionPrompt = $"How many {_measurement} is the {_category} you are adding? ";    
    // pass the portionPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator1 = new Validator("Use prompt", portionPrompt);    
    // set the method to use the prompt the first time the method is used with "Use Prompt"
    // also set to use the ConfirmEntry method after validating number with "Do ConfirmEntry"
    _portion = validator1.StringNumberCheck("Use prompt", "Do ConfirmEntry");
    // #3 USER SETS _calories ***************************************************
    string caloriesPrompt = $"How many calories is the {_category} you are adding? ";    
    // pass the caloriesPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator2 = new Validator("Use prompt", caloriesPrompt);    
    // set the method to use the prompt the first time the method is used with "Use Prompt"
    // also set to use the ConfirmEntry method after validating number with "Do ConfirmEntry"
    _calories = validator2.StringNumberCheck("Use prompt", "Do ConfirmEntry");
  }  

  // constructor for converting textfile to Food object in Tracker Class
  public Food(string stringAttributes) :base (stringAttributes)
  {
    // For textfile to Food object uses DivideAttributes(stringAttributes) method, which
    // divides single string of attributes from a textfile into assigned individual attributes  
  }

// ### METHODS ############################################## //  
  // method to figure out cup value of the food
  public virtual void DeterminePortionValue()
  {
    
  }

// START OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES
  // method to create & return a food text string
  public override string CreateTrackedString(Object type)
  {     
    string foodString = base.CreateTrackedString(type);     
    foodString += $"~|~{_foodName}";        
    return foodString; 
  }
// END OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES

// START OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR
  // method to divide the string attributes stirng into their object's variable attributes  
  public override void DivideAttributes(string stringAttributes)
  {   
    // reference source: https://stackoverflow.com/questions/36911460/adding-to-virtual-function-in-derived-class
    base.DivideAttributes(stringAttributes); 
    string[] attributes = stringAttributes.Split("~|~");
    _foodName = attributes[3];     
  }
// END OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR
}