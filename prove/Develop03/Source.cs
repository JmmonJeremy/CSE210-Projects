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
  // setter method to set the volume the scripture comes from
  public void SetVolume() 
  {
    // create a variable to run the main while loop 
    // until the selection is confirmed by the user
    string runAll = "Run loop"; 
    // set confirmation to != yes or no so
    // the while loop will run to confirm
    string confirmed = "Run loop";   
    // create a variable to hold the users selection
    string selection = "Run loop";    
    // do this until the user confirms their selection
    while (runAll != "done")
    {     
      // do this until 1,2,3,or 4 is entered
      while (selection != "1" && selection != "2" && selection != "3" && selection!= "4" && selection!= "5")
      {
        // tell the user what to do
        Console.WriteLine("For the scripture you are memorizing, please select the volume it comes from.");
        Console.WriteLine("To make your selection enter the corresponding number for the volume below:");
        // Show the user the options
        Console.WriteLine(" 1 - The Old Testament");
        Console.WriteLine(" 2 - The New Testament");
        Console.WriteLine(" 3 - The Book of Mormon");
        Console.WriteLine(" 4 - The Doctrine and Covenants");
        Console.WriteLine(" 5 - The Pearl of Great Price");
        Console.Write("Volume: ");
        selection = Console.ReadLine();
        Console.WriteLine();
        // do this if the didn't enter 1,2,3, or 4
        if (selection != "1" && selection != "2" && selection != "3" && selection!= "4" && selection!= "5")
        {
          // let the user know what they need to enter
          Console.WriteLine("That is not a valid entry, you must enter 1, 2, 3, or 4. Please make a valid entry.\n");
        }     
      }  
      // use switch to assign the chosen volume to the variable
      switch(selection)
      {
        case "1":
        _volume = "The Old Testament";
        break;
        case "2":
        _volume = "The New Testament";
        break;
        case "3":
        _volume = "The Book of Mormon";
        break;
        case "4":
        _volume = "The Doctrine and Covenants";
        break;
        case "5":
        _volume = "The Pearl of Great Price";
        break;
      }
      // do this from the ConfirmAnswer method
      // until yes is the outcom
      confirmed = ConfirmAnswer(confirmed, _volume);     
      // if they confirmed their choice
      if (confirmed == "yes")
      {
        // end loop
        runAll = "done";
      }
      else
      {
        // start selection loop over again
        selection = "Run loop"; 
        // set ConfirmAnswer method to run again
        confirmed = "Run loop"; 
      }
    }    
  }
  
  // getter method to get the volume source
  public string GetVolume()
  { 
    return _volume;
  }

  // setter method to set the book source
  public void SetBook()
  {     
    // create a variable to run the main while loop 
    // until the selection is confirmed by the user
    string runAll = "Run loop";
    // set confirmation to != yes or no so
    // the while loop will run to confirm
    string confirmed = "Run loop"; 
    // do this until the user confirms their entry
    while (runAll != "done")
    {      
      // ask the user for the book that the scripture comes from
      Console.WriteLine("Please enter the name of the book");
      Console.Write("that the scripture comes from: ");
      // set the _book variable to users input
      _book = Console.ReadLine();
      Console.WriteLine();
      // do this from the ConfirmAnswer method
      // until yes is the outcom
      confirmed = ConfirmAnswer(confirmed, _book);       
      // if they confirmed their choice
      if (confirmed == "yes")
      {
        // end loop
        runAll = "done";
      } 
      else
      {
        // set ConfirmAnswer method to run again
        confirmed = "Run loop"; 
      }
    } 
  }

  // getter method to get the book source
  public string GetBook()
  { 
    return _book;
  }

  // setter method to set the chapter source
  public void SetChapter()
  {     
    // create a variable to run the main while loop 
    // until the selection is confirmed by the user
    string runAll = "Run loop";
     // create direction to pass into the StringNumberCheck 
    string direction = "Please enter the chapter number \nfor the scripture: "; 
    // create a boolean to pass into the StringNumberCheck
    bool isNumber = false;    
    // create a variable to hold the answer converted to an int
    // so it can be used by the StringNumberCheck & returned for further use
    int chapterInt = 0;    
    // set confirmation to != yes or no so
    // the while loop will run to confirm
    // from the ConfirmAnswer method
    string confirmed = "Run loop"; 
    // do this until the user confirms their entry
    while (runAll != "done")
    {   
      // run the StringNumberCheck method to make sure user enters a number
      _chapter = (StringNumberCheck(isNumber, chapterInt, direction)).ToString();
      // put an empty space between statements
      Console.WriteLine();
      // do this from the ConfirmAnswer method
      // until yes is the outcom
      confirmed = ConfirmAnswer(confirmed, _chapter);       
      // if they confirmed their choice
      if (confirmed == "yes")
      {
        // end loop
        runAll = "done";
      } 
      else
      {
        // set ConfirmAnswer method to run again
        confirmed = "Run loop"; 
      }
    } 
  }

  // getter method to get the chapter source
  public string GetChapter()
  {
    return _chapter;
  }

  // setter method to set the verse source
  public void SetVerse()
  {     
    // create a variable to run the main while loop 
    // until the selection is confirmed by the user
    string runAll = "Run loop";
    // create direction to pass into the StringNumberCheck 
    string direction = "Please enter the beginning verse number \nfor the scripture: "; 
    // create a boolean to pass into the StringNumberCheck
    bool isNumber = false;    
    // create a variable to hold the answer converted to an int
    // so it can be used by the StringNumberCheck & returned for further use
    int verseInt = 0;    
    // set confirmation to != yes or no so
    // the while loop will run to confirm
    // from the ConfirmAnswer method
    string confirmed = "Run loop"; 
    // do this until the user confirms their entry
    while (runAll != "done")
    { 
      // run the StringNumberCheck method to make sure user enters a number
      _verse = (StringNumberCheck(isNumber, verseInt, direction)).ToString();
      // put an empty space between statements
      Console.WriteLine();
      // do this from the ConfirmAnswer method
      // until yes is the outcom
      confirmed = ConfirmAnswer(confirmed, _verse);       
      // if they confirmed their choice
      if (confirmed == "yes")
      {
        // end loop
        runAll = "done";
      } 
      else
      {
        // set ConfirmAnswer method to run again
        confirmed = "Run loop"; 
      }
    } 
  }
  
  // getter method to get the verse source
  public string GetVerse()
  {
    return _verse;
  }

    // setter method to set the end verse source with a
    // value if there is one and as empty if there isn't
  public void SetEndVerse()
  { 
    // set confirmation to != yes or no so
    // the while loop will run to confirm
    // from the ConfirmAnswer method
    string confirmed = "Run loop";
    // create question to pass into the StringNumberCheck 
    string question = "How many verses does your scripture have? ";
    // create a boolean to run the while loop & if statement
    bool isNumber = false;
    // // create a variable to hold the number of verses answer
    // // so it can be passed into the ConfirmAnswer method   
    int versesInt = 0;
    // run method loop this part until user confirms their entry
    while (confirmed != "yes" && confirmed != "no")
    {
      // run the StringNumberCheck method to make sure user enters a number
      versesInt = StringNumberCheck(isNumber, versesInt, question);
      // set value to a string to pass to the ConfirmAnswer method
      string versesStr = versesInt.ToString();
      // put an empty space between statements
      Console.WriteLine();     
      // do this from the ConfirmAnswer method
      // until yes is the outcom
      confirmed = ConfirmAnswer(confirmed, versesStr);       
      // if they didn't confirm their choice loop starts over
      if (confirmed == "no")
      {
        // set ConfirmAnswer method to run again
        confirmed = "Run loop"; 
      }   
    }
    // set the endVerse if there is more than one verse
    if (versesInt > 1)
    { 
      // create a variable to run the main while loop 
      // until the selection is confirmed by the user
      string runAll = "Run loop";     
      // create direction to pass into the StringNumberCheck 
      string direction = "Please enter the ending verse number \nfor the scripture: ";         
      // create a variable to hold the answer converted to an int
      // so it can be used by the StringNumberCheck & returned for further use
      int endVerseInt = 0;

      confirmed = "Run loop";     
      // do this until the user confirms their entry
      while (runAll != "done")
      {  
        // run the StringNumberCheck method to make sure user enters a number
        _endVerse = (StringNumberCheck(isNumber, endVerseInt, direction)).ToString();
        // put an empty space between statements
        Console.WriteLine();       
        // do this from the ConfirmAnswer method
        // until yes is the outcom
        confirmed = ConfirmAnswer(confirmed, _endVerse);       
        // if they confirmed their choice
        if (confirmed == "yes")
        {
          // end loop
          runAll = "done";
        } 
        else
        {
          // set ConfirmAnswer method to run again
          confirmed = "Run loop"; 
        }
      }
    }
    else
    {
      _endVerse = "";
    } 
  }

  // getter method to get the ending verse source
  public string GetEndVerse()
  {
    return _endVerse;
  }

  // method to set volume, book, chapter, & verse
  // from the last scripture the user used
  public void LoadLastScripture()
  {
    // sets the _volume equal to the incoming volume parameter
    _volume = "The New Testament";
    // sets the _book equal to the incoming book parameter 
    _book = "John";
    // sets the _chapter equal to the incoming chapter parameter 
    _chapter = "11";
    // sets the _verse equal to the incoming verse parameter 
    _verse = "25";
    // sets the _endVerse equal to the incoming endVerse parameter
    _endVerse = "";
  }

  // method to confirm the user's inputs
  public string ConfirmAnswer(string confirmed, string source)
  {
    // do this until yes or no is entered
    while (confirmed != "yes" && confirmed != "no")
    {
      // have the user confirm they selected the volume they wanted to
      Console.WriteLine($"{source} is what you selected.");
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
    return confirmed;
  }

  // method to insure the input was a number
  public int StringNumberCheck(bool checker, int number, string direction)
  {
     // run this until they enter a number
      while (!checker || number < 1)
      {  
        // ask the user how many verses are in the scripture
        Console.Write(direction);
        // store the answer to how many verses in a variable
        string versesStr = Console.ReadLine();
        // ensure the user is entering a number by testing it
        // convert the string to an int if it is a number
        checker = int.TryParse(versesStr, out number);
        // if it is not a number have them enter again
        if (!checker || number < 1)
        {
          Console.WriteLine("\nYour entry was not a valid number, you must enter a number of 1 or greater.");
          Console.WriteLine("Please try again by entering a valid number.\n");
        }
      }
      return number;
  }
}