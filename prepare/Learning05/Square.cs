using System;

// ### CLASS ################################################ //
// class for the square shape
public class Square : Shape
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // variable to hold the square's side length
  private double _side;  

// ### CONSTRUCTORS ######################################### //
  // constructor sets up the object to recieve a string for the 
  // _color through the base class and a side length upon initialization of the object
  public Square(string color, double side) : base(color)
  { 
    // set _side equal to the side length passed in 
    _side = side;   
  } 

// ### METHODS ############################################## //
  // getter method to get the area of the square
  public override double GetArea()
  {
    // calculate the area of the square
    double area = _side * _side;
    // return the area of the square
    return area;
  }
}
  