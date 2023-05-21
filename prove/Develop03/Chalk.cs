using System;

// ### CLASS ################################################ //
// class to hold a word from the scripture
public class Chalk
{
// ### VARIABLE ATTRIBUTES ################################## // 
// variable to hold an individual word from the scripture
private string _word;
// boolean to mark a word to hide
private bool _hide;

// ### CONSTRUCTORS ######################################### //
// constructor sets up the object to recieve a string for the word
public Chalk(string word, bool hide)
{ 
  // set word equal to the word passed in 
  _word = word;
  // set word as marked to hide or not
  _hide = hide;
}

// ### METHODS ############################################## //

// getter method to get the scripture verse
public List<string> GetVerse()
{
  List<string> verse = new List<string>();
  return verse;
}

// setter method for Chalk
public void SetHide(bool hide)
{ 
  _hide = hide;
}

// getter method to get the bool _hide
public bool GetHide()
{
  return _hide;
}

// getter method to get the bool _word
public string GetWord()
{
  return _word;
}

}