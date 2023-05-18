using System;

// ### CLASS ################################################ //
// class to hold a scripture's reference source
public class Source
{
// ### VARIABLE ATTRIBUTES ################################## // 
// variable to hold the book name for the scripture's source
private string _book;
// variable to hold the chapter for the scripture's source
private string _chapter;
// variable to hold the verse for the scripture's source
private string _verse;
// variable to hold the ending verse for the scripture's source
// if there is more than one verse to the scripture being memorized
private string _endVerse;

// ### CONSTRUCTORS ######################################### //
// constructor sets up the object to recieve a string for
// the book, chapter, and verse for the case of 1 verse
public Source(string book, string chapter, string verse)
{ 
  // sets the _book equal to the incoming book parameter 
  _book = book;
  // sets the _chapter equal to the incoming chapter parameter  
  _chapter = chapter;
  // sets the _verse equal to the incoming verse parameter  
  _verse = verse;
}

// constructor sets up the object to recieve a string for the 
// book, chapter, verse and _endVerse for the case of 2 verses
public Source(string book, string chapter, string verse, string endVerse)
{ 
  // sets the _book equal to the incoming book parameter 
  _book = book;
  // sets the _chapter equal to the incoming chapter parameter 
  _chapter = chapter;
  // sets the _verse equal to the incoming verse parameter 
  _verse = verse;
  // sets the _endVerse equal to the incoming endVerse parameter
  _endVerse = endVerse;
}

// ### METHODS ############################################## //

// getter method to get the book source
public string GetBook()
{ 
  return _book;
}

// getter method to get the chapter source
public string GetChapter()
{
  return _chapter;
}

// getter method to get the verse source
public string GetVerse()
{
  return _verse;
}

// getter method to get the ending verse source
public string GetEndVerse()
{
  return _endVerse;
}

}