using System;
using System.IO;
using System.Reflection;

// ### CLASS ################################################ //
// base class for something being tracked
public class Tracked
{
// ### VARIABLE ATTRIBUTES ################################## //  
  protected string _category;  
  protected string _unit;
  protected float _portion;    
  protected int _calories;  
  
// ### CONSTRUCTORS ######################################### //
  // default constructor to set up a Tracked object
  public Tracked(string category, string unit)
  {     
    _category = category;
    _unit = unit;
  }

  // constructor for converting textfile to object in Tracker Class & for the derived classes for other constructors
  public Tracked(string stringAttributes)
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
  // method to create a user selection string
  public virtual string CreateDisplayString(int count, string numberMarker)
  {
    if (_portion == 1)
    {
    // reference source: https://stackoverflow.com/questions/3573284/trim-last-character-from-a-string
    _unit = _unit.TrimEnd('s'); // change from plural to singular
    }
    int lastLetter = _category.Count() - 1;
    if (_category[lastLetter] == 'd') // capitalize food
    {
      // reference source: https://www.educative.io/answers/how-to-remove-characters-from-a-string-using-remove-in-c-sharp
      _category = _category.Remove(_category.Length-4);
      _category += "Food";
    }
    if (_category[lastLetter] == 'k') // capitilize drink
    {
      _category = _category.Remove(_category.Length-5);
      _category += "Drink";
    }
    // source reference: https://www.educative.io/answers/how-to-capitalize-the-first-letter-of-a-string-in-c-sharp
    string selectionString = $"({char.ToUpper(_category[0]) + _category.Substring(1)}): {_portion} {_unit} = {_calories} calories.";    
    return selectionString;
  }

// START OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES
  // method to create & return a text string of something being tracked
  public virtual string CreateObjectString()
  {  
    if (_portion == 1)
    {
    // reference source: https://stackoverflow.com/questions/3573284/trim-last-character-from-a-string
    _unit = _unit.TrimEnd('s'); // change from plural to singular 
    }   
    string trackedString = $"{GetType()}:|:{_category}~|~{_portion}~|~{_unit}~|~{_calories}";    
    return trackedString; 
  }
// END OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES

// START OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO OBJECTs & ATTRIBUTES USED IN CONSTRUCTOR & TRACKER CLASS
  // method to divide the string attributes stirng into their object's variable attributes - used in constructor 
  public virtual void DivideAttributes(string stringAttributes)
  {       
    string[] attributes = stringAttributes.Split("~|~");    
    _category = attributes[0];     
    _portion = float.Parse(attributes[1]);
    _unit = attributes[2];
    _calories = int.Parse(attributes[3]);
  }

  // method to divide string into object and long attribute string
  public Tracked TextStringToObject(string item)
  {
    string divider = "";
     // seperate the string into the object and its attributes using the divider
        string[] segments = item.Split(divider);  
        // reference source: https://learn.microsoft.com/en-us/dotnet/api/system.activator.createinstance?view=net-7.0#system-activator-createinstance(system-type-system-object())
        // create a Tracked object or instance from the string of the Tracked base class or Tracked derived classes
        Tracked food = (Tracked)Activator.CreateInstance(Type.GetType(segments[0]), segments[1]);
        return food;         
  }
// END OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR

    // getter method for the _category variable
  public string GetCategory()
  {
    return _category;
  }

  // getter method to get food calories
  public int GetCalories()
  {
    return _calories;
  }
}