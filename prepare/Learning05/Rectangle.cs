using System;

// ### CLASS ################################################ //
// class for the rectangle shape
public class Rectangle : Shape
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // variable to hold the rectangle's side length
  private double _length;  
  // variable to hold the rectangle's side width
  private double _width; 

// ### CONSTRUCTORS ######################################### //
  // constructor sets up the object to recieve a string for the _color through the base
  // class and a side length and width upon initialization of the object
  public Rectangle(string color, double length, double width) : base(color)
  { 
    // set _length equal to the length passed in 
    _length = length;
    // set _width equal to the width passed in 
    _width = width; 
  } 

// ### METHODS ############################################## //
  // getter method to get the area of the rectangle
  public override double GetArea()
  {
    // calculate the area of the rectangle
    double area = _length * _width;
    // return the area of the rectangle
    return area;
  }
}
  