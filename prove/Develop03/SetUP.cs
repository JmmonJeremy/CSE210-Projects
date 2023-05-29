using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

// ### CLASS ################################################ //
// class to introduce and set up the resources for
// the scripture memorization program to work
public class SetUp
{
// ### VARIABLE ATTRIBUTES ################################## //
  // variable to run the while loop until the condition is met of
  // quit being entered or all words are hidden to end the program
  string _quit;
  // variable to count rotations of while/loop   
  int _rotations; 

// ### CONSTRUCTORS ######################################### //
  public SetUp()
  {
    // set _quit to "run loop" or not "quit" to run the loop 
    _quit = "Run loop";
    // started at -1 so the first while/loop isn't counted
    // because words aren't blanked out until the 2nd loop
    _rotations = -1;   
  }

// ### METHODS ############################################## //
  // method to display the programs introduction & explanation
  public void ProgramDescription()
  {
    // put a line above the explanation
    Console.WriteLine("______________________________________________________________________________");
    // color the text to make sure the user sees the instructions
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    // explain how the program works with 2 empty lines afterwards
    Console.WriteLine("This program is designed to help you memorize any scripure of your choice.");
    // color the text to make sure the user sees the instructions
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("It does so by replacing one word with a placeholder each time you press enter.");
      // return the text color to yellow to make sure the user sees the instructions
    Console.ForegroundColor = ConsoleColor.DarkYellow; 
    Console.WriteLine("The program ends when all of the words are replaced or when 'quit' is entered.\n");
    // reset the text color to previous settings
    Console.ResetColor();
  }

  // method to get the correct source for the 
  // scripture or scriptures being memorized
  public string SetUpSource(string endVerse, string source)
  {
    // ### set up two Source constructors
    // create a variable to hold the final constructed source
    string finalSource;         
    // determine if the source will include an ending verse    
    if (string.IsNullOrEmpty(endVerse))
    {
    // use constructor for the source containing a single verse
    Source uniSource = new Source(source);
    // and assign it to the variable of finalSource
    finalSource = uniSource.GetSource();            
    }
    // for scriptures with more than one verse
    else
    {
    // use constructor for the source containing multiple verses
    Source multiSource = new Source(source, endVerse);
    // and assign it to the variable of finalSource
    finalSource = multiSource.GetSource();
    }    
    return finalSource;  
  }

  // method to get the verse or verses for memorizing set up 
  public string SetUpScripture(string volume, string startReference, string endReference)
  {
    // create a variable to hold a verse if only one
    string selectedVerses = "There was an error while setting up your scripture.\nThe source providing the scripture volume did not load.";
    // create a list to hold the verses selected
    List<string> verseList = new List<string>();
    // create ScritureVolumes object to access its methods
    ScriptureVolumes volumes = new ScriptureVolumes();
    // set up variable to hold the json volume so it can change
    // according to what the user enters for the volume
    string jsonVolume = "";
    // ### STEP #1 ONLY DO IF THE SCRIPTURE COMES FROM THAT VOLUME
    // determine which volume the user is using
    // ### STEP #2 STORE WEB LINK IN 'link"volume abbreviation' VARIABLE
    // create a variable to hold the weblink for the scripture volumes
    // and get the weblink through the ScriptureVolumes' get method
    // ### STEP #3 STORE ASYNC TASK OF GETTING VOLUME IN 'get"volume abrreviaton"Json VARIABLE
    // use a variable to hold the async task waiting for the 
    // ScriptureVolumes method to load its _json"VolumeName" string
    // ### STEP #4 
    // use the Wait method to wait until the _json"VolumeName" 
    // string is loaded in ScriptureVolumes by the set method
    // OLD TESTAMENT - STEP #1 
    // only do this if the Old Testament is the chosen volume
    if (volume == "The Old Testament") 
    {       
      // STEP #2 store link
      string linkOT = volumes.GetWebLinkOldTestament();
      // STEP #3 store task
      var getOTJson = Task.Run(async () => await volumes.SetJsonOldTestament(linkOT));
      // STEP #4 wait until the task is completed and the volume loaded
      try
      {
        // reference source: https://stackoverflow.com/questions/23048285/call-asynchronous-method-in-constructor
        getOTJson.Wait();
      }
      // catch & identify exception errors
      catch (AggregateException ae) 
      {
        Console.WriteLine("Exception Caught! This error is from the '.Wait()' method.");
        foreach (var ex in ae.InnerExceptions)
        Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);       
      }
      // set the value of the jsonVolume variable to the results after loading the json 
      // Old Testament string into the _jsonOldTestament ScriptureVolumes' attribute
      jsonVolume = volumes.GetJsonOldTestament();      
    }
    // NEW TESTAMENT - STEP #1 
    // only do this if the New Testament is the chosen volume
    if (volume == "The New Testament") 
    {       
      // STEP #2 store link
      string linkNT = volumes.GetWebLinkNewTestament();
      // STEP #3 store task
      var getNTJson = Task.Run(async () => await volumes.SetJsonNewTestament(linkNT));
      // STEP #4 wait until the task is completed and the volume loaded
      try
      {
        getNTJson.Wait();
      }
      // catch & identify exception errors
      catch (AggregateException ae) 
      {
        Console.WriteLine("Exception Caught! This error is from the '.Wait()' method.");
        foreach (var ex in ae.InnerExceptions)
        Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);       
      } 
      // set the value of the jsonVolume variable to the results after loading the json 
      // New Testament string into the _jsonNewTestament ScriptureVolumes' attribute
      jsonVolume = volumes.GetJsonNewTestament();      
    }
    // BOOK OF MORMON - STEP #1 
    // only do this if the Book of Mormon is the chosen volume
    if (volume == "The Book of Mormon") 
    {       
      // STEP #2 store link
      string linkBOM = volumes.GetWebLinkBookOfMormon();
      // STEP #3 store task
      var getBOMJson = Task.Run(async () => await volumes.SetJsonBookOfMormon(linkBOM));
      // STEP #4 wait until the task is completed and the volume loaded      
      try
      {
        getBOMJson.Wait();
      }
      // catch & identify exception errors
      catch (AggregateException ae) 
      {
        Console.WriteLine("Exception Caught! This error is from the '.Wait()' method.");
        foreach (var ex in ae.InnerExceptions)
        Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);       
      }
      // set the value of the jsonVolume variable to the results after loading the json 
      // Book of Mormon string into the _jsonBookofMormon ScriptureVolumes' attribute
      jsonVolume = volumes.GetJsonBookOfMormon();
    }
    // DOCTRINE & COVENANTS - STEP #1 
    // only do this if the Doctrine & Covenants is the chosen volume
    if (volume == "The Doctrine and Covenants") 
    {       
      // STEP #2 store link
      string linkDAC = volumes.GetWebLinkDoctrineAndCovenants();
      // STEP #3 store task
      var getDACJson = Task.Run(async () => await volumes.SetJsonDoctrineAndCovenants(linkDAC));
      // STEP #4 wait until the task is completed and the volume loaded      
      try
      {
        getDACJson.Wait();
      }
      // catch & identify exception errors
      catch (AggregateException ae) 
      {
        Console.WriteLine("Exception Caught! This error is from the '.Wait()' method.");
        foreach (var ex in ae.InnerExceptions)
        Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);       
      }
      // set the value of the jsonVolume variable to the results after loading the json
      // D & C string into the _jsonDoctrineAndCovenants ScriptureVolumes' attribute
      jsonVolume = volumes.GetJsonDoctrineAndCovenants();
    }
    // PEARL OF GREAT PRICE - STEP #1 
    // only do this if the Pearl of Great Price is the chosen volume
    if (volume == "The Pearl of Great Price") 
    {       
      // STEP #2 store link
      string linkPOGP = volumes.GetWebLinkPearlOfGreatPrice();
      // STEP #3 store task
      var getPOGPJson = Task.Run(async () => await volumes.SetJsonPearlOfGreatPrice(linkPOGP));
      // STEP #4 wait until the task is completed and the volume loaded      
      try
      {
        getPOGPJson.Wait();
      }
      // catch & identify exception errors
      catch (AggregateException ae) 
      {
        Console.WriteLine("Exception Caught! This error is from the '.Wait()' method.");
        foreach (var ex in ae.InnerExceptions)
        Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);       
      }
      // set the value of the jsonVolume variable to the results after loading the json 
      // P of GP string into the _jsonPearlOfGreatPrice ScriptureVolumes' attribute
      jsonVolume = volumes.GetJsonPearlOfGreatPrice();
    } 
    if (!string.IsNullOrEmpty(jsonVolume))
    {        
      // when the volume equals Old Testament
      if (volume == "The Old Testament") 
      {
        // create a Verses class object to load with the Old Testament verses
        Verses oldTestamentVerses = JsonSerializer.Deserialize<Verses>(volumes.GetJsonOldTestament());
        // if there is no endReference
        if (string.IsNullOrEmpty(endReference))
        {
          // use the Verses class object to find & return the requested verse
          selectedVerses = oldTestamentVerses.FindVerse(startReference);
        }
        // if there is an endReference
        else
        {
          // use the Verses class object to find & return the requested verses
          verseList = oldTestamentVerses.FindVerses(startReference, endReference);
        }
      }
      // when the volume equals New Testament
      else if (volume == "The New Testament") 
      {
        // create a Verses class object to load with the New Testament verses
        Verses newTestamentVerses = JsonSerializer.Deserialize<Verses>(volumes.GetJsonNewTestament());
        // if there is no endReference
        if (string.IsNullOrEmpty(endReference))
        {
        // use the Verses class object to find & return the requested verse
        selectedVerses = newTestamentVerses.FindVerse(startReference);
        } 
        // if there is an endReference   
        else
        {
          // use the Verses class object to find & return the requested verses
          verseList = newTestamentVerses.FindVerses(startReference, endReference);
        }
      }
      // when the volume equals Book of Mormon
      if (volume == "The Book of Mormon") 
      {
        // create a Verses class object to load with the Book of Mormon verses
        Verses bookOfMormonVerses = JsonSerializer.Deserialize<Verses>(volumes.GetJsonBookOfMormon());
        // if there is no endReference
        if (string.IsNullOrEmpty(endReference))
        {
        // use the Verses class object to find & return the requested verse
        selectedVerses = bookOfMormonVerses.FindVerse(startReference);
        }
        // if there is an endReference
        else
        {
          // use the Verses class object to find & return the requested verses
          verseList = bookOfMormonVerses.FindVerses(startReference, endReference);
        }
      }
      // when the volume equals Doctrine and Covenants
      else if (volume == "The Doctrine and Covenants") 
      {
        // create a Verses class object to load with the Doctrine and Covenants verses
        Verses doctrineAndCovenantsVerses = JsonSerializer.Deserialize<Verses>(volumes.GetJsonDoctrineAndCovenants());
        // if there is no endReference
        if (string.IsNullOrEmpty(endReference))
        {
        // use the Verses class object to find & return the requested verse
        selectedVerses = doctrineAndCovenantsVerses.FindVerse(startReference);
        }
        // if there is an endReference
        else
        {
          // use the Verses class object to find & return the requested verses
          verseList = doctrineAndCovenantsVerses.FindVerses(startReference, endReference);
        }
      }
      // when the volume equals Pearl of Great Price
      else if (volume == "The Pearl of Great Price")
      {
        // create a Verses class object to load with the Pearl of Great Price verses
        Verses pearlOfGreatPriceVerses = JsonSerializer.Deserialize<Verses>(volumes.GetJsonPearlOfGreatPrice());
        // if there is no endReference
        if (string.IsNullOrEmpty(endReference))
        {
        // use the Verses class object to find & return the requested verse
        selectedVerses = pearlOfGreatPriceVerses.FindVerse(startReference);
        }
        // if there is an endReference
        else
        {
          // use the Verses class object to find & return the requested verses
          verseList = pearlOfGreatPriceVerses.FindVerses(startReference, endReference);
        }      
      }
    }     
    // if there are items in the list
    if (verseList.Count > 0)
    {
      // clear string in selectedVerses
      selectedVerses = "";
    }    
    // cycle through the list and create one string
    foreach (string part in verseList)
    {
      // if it is not the last string in the list
      // reference source: https://www.techiedelight.com/find-last-element-in-a-list-in-csharp/
      if (part != (verseList.Last()))
      {
        // put an empty line between it and the line 
        // above it and put a space after the string
        selectedVerses += $"\n\n{part} ";
      }
      // if it is the last string in the list
      else
      {
        // do the same thing without the space after it
        selectedVerses += $"\n\n{part}";
      }            
    } 
    // return the list with the verse or verses
    return selectedVerses;
  }

  // method to run a loop of displaying the scripture as the Chalkboard changes
  // until the program ends with quit or all of the words being covered
  public void QuitLoop(List<Chalk> eachWord, string source, string scripture)
  {
    // create a loop to run until the user enters "quit"
    // or until all the words in the scripture are covered
    while (_quit != "quit" && _quit != "restart" && _rotations != eachWord.Count)
    {      
      // count the rotations of the while loop, this is
      // used to avoid a change in the first rotation
      _rotations += 1;
      // clear the console screen
      Console.Clear();    
      // display the scritpure source
      Console.Write($"{source}  ");
      // create a Chalkboard object to run the methods with
      Chalkboard chalkboard = new Chalkboard(source, scripture);
      // check if all _hide boleans are true
      chalkboard.SetAllHidden(eachWord);      
      // when _allHidden = true
      if (chalkboard.GetAllHidden())
      { 
        // display all words hidden 
        chalkboard.EraseAllWords(eachWord);
        
        // TODO *** put in method to display the encouragement

        // stop the program
        break;
      } 
      // hide random words and display the results
      chalkboard.EraseRandomWords(eachWord);
      // add two empty lines after the scritpure
      Console.WriteLine("\n\n");
      // display instructions for the user
      Console.Write("Press enter to hide a word or enter 'quit' to exit: ");
      // gather and use the input from the user & end program if quit is entered
      // or replace a word if they press enter by starting while loop over again
      _quit = Console.ReadLine();      
    }
  } 
} 