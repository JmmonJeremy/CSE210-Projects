using System;
using System.IO;
using System.Reflection;

// ### CLASS ################################################ //
// base class for something being tracked
public class Tracked
{
// ### VARIABLE ATTRIBUTES ################################## //   
  private string _trackedName;  
  private int _portion;   
  private int _calories; 
  private string _attributes; 
  
// ### CONSTRUCTORS ######################################### //
  // constructor for converting textfile to object in Tracker Class & for the ClassToString method in derived classes
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
// START OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES
  // method to create & return a text string of something being tracked
  public virtual string CreateTrackedString(Object type)
  {      
    string trackedString = $"{type.GetType()}:{_trackedName}~|~{_portion}~|~{_calories}";    
    return trackedString; 
  }
// END OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES

// START OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR
  // method to divide the string attributes stirng into their object's variable attributes  
  private void DivideAttributes(string stringAttributes)
  {       
    string[] attributes = stringAttributes.Split("~|~");    
    _trackedName = attributes[0];     
    _portion = Convert.ToInt32(attributes[1]);
    _calories = int.Parse(attributes[2]);
  }
// END OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR
}