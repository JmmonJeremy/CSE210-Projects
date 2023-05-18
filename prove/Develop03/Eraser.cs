using System;

// ### CLASS ################################################ //
// class to hold and replace a word with underscores for a placeholder
public class Eraser
{
// ### VARIABLE ATTRIBUTES ################################## // 
// variable to hold an individual word
private string _word;
// variable to hold the placeholder for the word
private string _placeholder = "________";

// ### CONSTRUCTORS ######################################### //
// constructor sets up the object to recieve a string for the _word
// replaces that word with underscores for the _placeholder
public Eraser(string word)
{ 
  // set word equal to the input parameter 
  _word = word;
  // get the number of letters in the word & store it in a variable
  // reference resource: https://stackoverflow.com/questions/17096494/counting-number-of-letters-in-a-string-variable
  int amount = _word.Length;
  // replace each character in a word with an underscore
  // reference resource: https://stackoverflow.com/questions/532892/can-i-multiply-a-string-in-c & https://www.w3schools.com/cs/cs_strings_concat.php & https://www.codingame.com/playgrounds/60055/c-linq-introduction/enumerables & https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.repeat?view=net-7.0
  _placeholder = String.Concat(Enumerable.Repeat("_", amount));
}

// ### METHODS ############################################## //

// getter method to get the placeholder
public string GetPlaceHolder()
{
  return _placeholder;
}

}