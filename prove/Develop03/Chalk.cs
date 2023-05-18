using System;

// ### CLASS ################################################ //
// class to hold a word from the scripture
public class Chalk
{
// ### VARIABLE ATTRIBUTES ################################## // 
// variable to hold an individual word from the scripture
private string _word;

// ### CONSTRUCTORS ######################################### //
// constructor sets up the object to recieve a string for the word
public Chalk(string word)
{ 
  // set word equal to the word passed in 
  _word = word;
}

// ### METHODS ############################################## //

// getter method to get the scripture verse
public List<string> GetVerse()
{
  List<string> verse = new List<string>();
  return verse;
}

// getter method to get the word
public string GetWord()
{
  return _word;
}

}