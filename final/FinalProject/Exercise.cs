using System;
using System.IO;
using System.Reflection;

// ### CLASS ################################################ //
// base class for tracking an exercise
public class Exercise : Tracked
{
// ### VARIABLE ATTRIBUTES ################################## //   
  private string _exerciseName; 

// ### CONSTRUCTORS ######################################### // 
  // main constructor to set up a Exercise object with the user's inputs
  public Exercise() : base("exercise", "minutes")
  {    
    // uses base class to set up 
  }

  // constructor for #1 the ClassToString method & #2 converting textfile to Exercise object
  public Exercise(string stringAttributes) : base (stringAttributes)
  {
    // #1 for ClassToString method do nothing to have an empty object set up
    // #2 for textfile to Exercise object uses DivideAttributes(stringAttributes) method, which
    // divides single string of attributes from a textfile into assigned individual attributes    
  }

// ### METHODS ############################################## //  
  // method to create a user selection string
  public override string CreateDisplayString(int count)
  {
    string space = "  ";
    if (count > 9)
    {
      space = " ";
    }
    string selectionString = $"   {count}.{space}{_exerciseName} ";  
    selectionString += base.CreateDisplayString(count);      
    return selectionString;
  }

// START OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES
  // method to create & return a exercise text string
  public override string CreateObjectString()
  {     
    string exerciseString = base.CreateObjectString();     
    exerciseString += $"~|~{_exerciseName}";        
    return exerciseString; 
  }
// END OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES

// START OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR
  // method to divide the string attributes stirng into their object's variable attributes  
  public override void DivideAttributes(string stringAttributes)
  {   
    // reference source: https://stackoverflow.com/questions/36911460/adding-to-virtual-function-in-derived-class
    base.DivideAttributes(stringAttributes); 
    string[] attributes = stringAttributes.Split("~|~");
    _exerciseName = attributes[4];     
  }
// END OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR
}