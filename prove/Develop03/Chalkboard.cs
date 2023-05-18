using System;

// ### CLASS ################################################ //
// class to hold and display the scripture to the user
public class Chalkboard
{
// ### VARIABLE ATTRIBUTES ################################## // 
// variable to hold the reference
private string _reference;
// list to hold all the words of the scripture
private List<string> _words = new List<string>();

// ### CONSTRUCTORS ######################################### //
// constructor sets up the object to recieve a string for the reference
// and to recieve a string for the scripture verse and turn it into a list of words
public Chalkboard(string source, string scripture)
{
  _reference = source;
  // split string scripture up and load into the list
  // reference source: https://stackoverflow.com/questions/9263695/how-to-split-a-delimited-string-to-a-liststring
  _words = scripture.Split(" ").ToList();
}

// ### METHODS ############################################## //
// getter method to get the scripture verse
public List<string> GetVerse()
{
  return _words;
}

// method to hide the words
public List<string> InsertBlanks()
{
  return _words;
}

// method for ending when all words are erased
public List<string> AllBlank()
{
  return _words;
}


}