using System;

// ### CLASS ################################################ //
// class to hold a scripture's reference source
public class Source
{
// ### VARIABLE ATTRIBUTES ################################## // 
// variable to hold the name of the volume of scripture the scripture comes from
// (ie. Bible, Book of Mormon, Doctrine and Covenants, Pearl of Great Price)
private string _volume;
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
// constructor to use to access methods without entering any parameter
// running the methods is the sole purpose of this constructor
public Source() 
{
  // nothing happens with this attribute in this constructor
  _volume = "";
  // nothing happens with this attribute in this constructor 
  _book = "";
  // nothing happens with this attribute in this constructor  
  _chapter = "";
  // nothing happens with this attribute in this constructor 
  _verse = "";
  // nothing happens with this attribute in this constructor
  _endVerse = "";

}

// constructor sets up the object to recieve a string for
// the book, chapter, and verse for the case of 1 verse
public Source(string volume, string book, string chapter, string verse)
{ 
  // sets the _volume equal to the incoming volume parameter
  _volume = volume;
  // sets the _book equal to the incoming book parameter 
  _book = book;
  // sets the _chapter equal to the incoming chapter parameter  
  _chapter = chapter;
  // sets the _verse equal to the incoming verse parameter  
  _verse = verse;
  // nothing happens with this attribute in this constructor
  _endVerse = "";
}

// constructor sets up the object to recieve a string for the 
// book, chapter, verse and _endVerse for the case of 2 verses
public Source(string volume, string book, string chapter, string verse, string endVerse)
{ 
  // sets the _volume equal to the incoming volume parameter
  _volume = volume;
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
public string GetVolume()
{ 
  return _volume;
}

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

// method to select the volume the scripture comes from
public string SelectVolume() 
{
  // create a variable to run the main while loop 
  // until the selection is confirmed by the user
  string confirmed = "Run loop";
  // create a variable to hold the users selection
  string selection = "Run loop";
  // create a variable to hold the selection of the
  // number converted into its corresponding volume
  string volume = "Run loop";
  // do this until the user confirms their selection
  while (confirmed != "confirmed")
  {
    // do this until 1,2,3,or 4 is entered
    while (selection != "1" && selection != "2" && selection != "3" && selection!= "4")
    {
      // tell the user what to do
      Console.WriteLine("For the scripture you are memorizing, please select the volume it comes from.");
      Console.WriteLine("To make your selection enter the corresponding number for the volume below:");
      // Show the user the options
      Console.WriteLine(" 1 - Bible");
      Console.WriteLine(" 2 - The Book of Mormon");
      Console.WriteLine(" 3 - The Doctrine and Covenants");
      Console.WriteLine(" 4 - The Pearl of Great Price");
      Console.Write("Volume: ");
      selection = Console.ReadLine();
      Console.WriteLine();
      // do this if the didn't enter 1,2,3, or 4
      if (selection != "1" && selection != "2" && selection != "3" && selection!= "4")
      {
        // let the user know what they need to enter
        Console.WriteLine("That is not a valid entry, you must enter 1, 2, 3, or 4. Please make a valid entry.\n");
      }     
    }  
    // use switch to assign the chosen volume to the variable
    switch(selection)
    {
      case "1":
      volume = "Bible";
      break;
      case "2":
      volume = "The Book of Mormon";
      break;
      case "3":
      volume = "The Doctrine and Covenants";
      break;
      case "4":
      volume = "The Pearl of Great Price";
      break;
    }    
    // do this until yes or no is entered
    while (confirmed != "yes" && confirmed != "no")
    {
      // have the user confirm they selected the volume they wanted to
      Console.WriteLine($"{volume} is what you selected.");
      Console.Write($"Is this correct (yes or no): ");
      confirmed = Console.ReadLine();
      // add an empty line after the response
      Console.WriteLine();
      // if they didn't enter yes or not
      if (confirmed != "yes" && confirmed != "no")
      {
        // tell the user what they must do
        Console.WriteLine($"{confirmed} is an invalid response. You must enter 'yes' or 'no'.\n");
      }     
    }
    // if they confirmed their choice
    if (confirmed == "yes")
    {
      // end loop
      confirmed = "confirmed";
    }
    else
    {
      // start selection loop over again
      selection = "Run loop";
      // start confirmation loop over again
      confirmed = "Run loop";
    }
  }
  // return the volume as a string to be used
  return volume;
}

}