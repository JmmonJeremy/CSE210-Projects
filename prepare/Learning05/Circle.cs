using System;

// ### CLASS ################################################ //
// class for the circle shape
public class Circle : Shape
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // variable to hold the circle's radius length
  private double _radius;  

// ### CONSTRUCTORS ######################################### //
  // constructor sets up the object to recieve a string for the 
  // _color through the base class and a radius length upon initialization of the object
  public Circle(string color, double radius) : base(color)
  { 
    // set _radius equal to the radius passed in 
    _radius = radius;   
  } 

// ### METHODS ############################################## //
  // getter method to get the area of the circle
  public override double GetArea()
  {
    // reference source: https://www.geeksforgeeks.org/how-to-calculate-area-of-circle-in-c-sharp/
    // calculate the area of the circle
    double area = (Math.PI) * _radius * _radius;
    // return the area of the circle
    return area;
  }
}
  