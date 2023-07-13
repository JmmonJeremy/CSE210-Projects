using System;
using System.IO;
using System.Reflection;

// ### CLASS ################################################ //
// base class for tracking a food
public class Food : Tracked
{
// ### VARIABLE ATTRIBUTES ################################## //   
  public string _name;  
  
// ### CONSTRUCTORS ######################################### //
  // main constructor to set up a Food object with the user's inputs used in Menu class
  public Food(string category, string unit) :base (category, unit)
  { 
    // #1 Base assigns parameters passed in as values for _category and _unit
    // #2 Uses method to have user assign values to _name, _portion and _calories
    FillValues();
  }  

  // constructor for converting textfile to Food object in Tracker Class
  public Food(string stringAttributes) :base (stringAttributes)
  {
    // For textfile to Food object uses DivideAttributes(stringAttributes) method, which
    // divides single string of attributes from a textfile into assigned individual attributes  
  }

// ### METHODS ############################################## // 
  // method to create a user display string
  public override string CreateDisplayString(int count, string numberMarker)
  {
    string space = "  ";
    if (count > 9)
    {
      space = " ";
    }
    int lastLetter = _category.Count() - 1;
    int preFoodSpace = _category.Count() -5;
    if (preFoodSpace < 0)
    {
      preFoodSpace = 1;
    }
     if (_category[lastLetter] == 'd' && _category[preFoodSpace] == ' ') // capitalize food
    {
      // reference source: https://www.educative.io/answers/how-to-remove-characters-from-a-string-using-remove-in-c-sharp
      _category = _category.Remove(_category.Length-4);
      _category += $"{GetType()}";
    }
    if (_category[lastLetter] == 'k') // capitilize drink
    {
      _category = _category.Remove(_category.Length-5);
      _category += "Drink";
    }
    // source reference: https://www.educative.io/answers/how-to-capitalize-the-first-letter-of-a-string-in-c-sharp
    string displayString = $"{count}{numberMarker}{space}{_name} ({char.ToUpper(_category[0]) + _category.Substring(1)}): ";  
    displayString += base.CreateDisplayString(count, "");      
    return displayString;
  }

// START OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES
  // method to create & return a food text string
  public override string CreateObjectString(string alternate)
  {     
    // string alter = "";
    // if (alternate == "alter")
    // {
    //   alter = "#|#";
    // }
    string foodString = base.CreateObjectString("normal");     
    foodString += $"~|~{_name}";        
    return foodString; 
  }
// END OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES

// START OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR
  // method to divide the string attributes stirng into their object's variable attributes  
  protected override void DivideAttributes(string stringAttributes)
  {   
    // reference source: https://stackoverflow.com/questions/36911460/adding-to-virtual-function-in-derived-class
    base.DivideAttributes(stringAttributes); 
    string[] attributes = stringAttributes.Split("~|~");
    _name = attributes[4];     
  }
// END OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR

  // method to set the value for the _name, _portion, & _calories
  protected virtual void FillValues()
  {
    // #1 USER SETS FOOD _name **************************************************
    string namePrompt = $"What is the name of the {_category}? ";    
    // pass the namePrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator = new Validator("Use prompt", namePrompt);    
    // with "Use prompt" set the method to to use the prompt the first time the method is used
    _name = validator.ConfirmEntry("Use prompt");
    // #2 USER SETS FOOD _portion ***************************************************
    string portionPrompt = $"How many {_unit} is the {_category} you are adding? ";    
    // pass the portionPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator1 = new Validator("Use prompt", portionPrompt);    
    // set the method to use the prompt the first time the method is used with "Use Prompt"
    // also set to use the ConfirmEntry method after validating number with "Do ConfirmEntry"
    _portion = validator1.PosStringDecimalCheck("Use prompt", "Do ConfirmEntry");
    // #3 USER SETS FOOD _calories ***************************************************
    string caloriesPrompt = $"How many calories is the {_category} you are adding? ";    
    // pass the caloriesPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator2 = new Validator("Use prompt", caloriesPrompt);    
    // set the method to use the prompt the first time the method is used with "Use Prompt"
    // also set to use the ConfirmEntry method after validating number with "Do ConfirmEntry"
    _calories = validator2.PosStringNumberCheck("Use prompt", "Do ConfirmEntry", 0);   
  }
}