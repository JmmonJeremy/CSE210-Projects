using System;

// ### CLASS ################################################ //
// class for shapes
public abstract class Shape
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // variable to hold the shape's color
  private string _color; 
  // variable to hold the name of the shape
  private string _name; 

// ### CONSTRUCTORS ######################################### //
  // constructor sets up the object to recieve a string for the 
  // _color upon initialization of the object
  public Shape(string color)
  { 
    // set _color equal to the color passed in 
    _color = color;   
  } 

// ### METHODS ############################################## //
  // getter method to get the _color
  public string GetColor()
  {
    return _color;
  }

  // method to set the color
  public void SetColor(string color)
  {
    _color = color;
  }

  // method to get the name of the shape
  public string GetName()
  {
    return _name;
  }

  // method to get the area of a shape
  public virtual double GetArea()
  {
    // create a variable for the area
    double area = 0;
    // returns the area of a shape
    return area;
  }
}