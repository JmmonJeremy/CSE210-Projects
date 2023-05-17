using System;

// ### CLASS ################################################ //
// class to hold fractions
public class Fraction
{
// ### VARIABLE ATTRIBUTES ################################## // 
// variable to hold the top fraction number
private int _top;
// variable to hold the bottom fraction number
private int _bottom;

// ### CONSTRUCTORS ######################################### //
// constructor with top & bottom initialized to 1
public Fraction()
{
  _top = 1;
  _bottom = 1;
}

// constructor with top parameter and bottom initialized to 1
public Fraction(int top)
{
  _top = top;
  _bottom = 1;
}

// constructor with parameters for top & bottom
public Fraction(int top, int bottom)
{
  _top = top;
  _bottom = bottom;
}

// ### METHODS ############################################## //
// getter for top number
public int GetTop()
{
  return _top;
}

// setter for top number
public void SetTop(int top)
{
  _top = top;
}

// getter for top number
public int GetBottom()
{
  return _bottom;
}

// setter for top number
public void SetBottom(int bottom)
{
  _bottom = bottom;
}

// getter for the fraction string
public string GetFractionString()
{
  // the way I did it
  string answer = (_top).ToString() + "/" + (_bottom).ToString();
  // alternative way taught
  string text = $"{_top}/{_bottom}";
  return text;
}

// getter for the fraction
public double GetDecimalValue()
{
  // the way I did it
  double answer = Convert.ToDouble(_top)/Convert.ToDouble(_bottom);
  // the way the teacher did it
  return (double)_top / (double)_bottom;
}
}