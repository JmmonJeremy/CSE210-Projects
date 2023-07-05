using System;
using System.IO;
using System.Reflection;

// ### CLASS ################################################ //
// base class for fruit
public class Fruit : Food
{
// ### VARIABLE ATTRIBUTES ################################## //   
 
// ### CONSTRUCTORS ######################################### // 
  // main constructor to set up a Fruit object with the user's inputs
  public Fruit() : base("fruit", "cups")
  {    
    // uses base class to set up 
  }

  // constructor for #1 the ClassToString method & #2 converting textfile to Fruit object
  public Fruit(string stringAttributes) : base (stringAttributes)
  {
    // #1 for ClassToString method do nothing to have an empty object set up
    // #2 for textfile to Fruit object uses DivideAttributes(stringAttributes) method, which
    // divides single string of attributes from a textfile into assigned individual attributes    
  }

// ### METHODS ############################################## //  
  // method to figure out portion value of the food
  public override void DeterminePortionValue()
  {
    
  }
}