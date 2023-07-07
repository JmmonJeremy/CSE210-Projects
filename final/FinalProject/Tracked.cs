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
  protected int _portion;    
  protected int _calories; 
  private string _attributes; 
  
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
  // getter method for the _category variable
  public string GetCategory()
  {
    return _category;
  }

  // method to create a user selection string
  public virtual string CreateSelectionString(Tracked type)
  {
    if (_portion == 1)
    // reference source: https://stackoverflow.com/questions/3573284/trim-last-character-from-a-string
    _unit = _unit.TrimEnd('s'); // change from plural to singular
    string selectionString = $"{_category}, {_portion} {_unit}, {_calories} calories";    
    return selectionString;
  }

// START OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES
  // method to create & return a text string of something being tracked
  public virtual string CreateTrackedString(Tracked type)
  {  
    // reference source: https://stackoverflow.com/questions/3573284/trim-last-character-from-a-string
    _unit = _unit.TrimEnd('s'); // change from plural to singular    
    string trackedString = $"{type.GetType()}:{_category}~|~{_portion}~|~{_unit}~|~{_calories}";    
    return trackedString; 
  }
// END OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES

// START OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR
  // method to divide the string attributes stirng into their object's variable attributes  
  public virtual void DivideAttributes(string stringAttributes)
  {       
    string[] attributes = stringAttributes.Split("~|~");    
    _category = attributes[0];     
    _portion = Convert.ToInt32(attributes[1]);
    _unit = attributes[2];
    _calories = int.Parse(attributes[3]);
  }
// END OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR
}