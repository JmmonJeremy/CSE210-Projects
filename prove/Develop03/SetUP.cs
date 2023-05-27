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

  // method to get the verse or verses for memorizing set up 
  public string SetUpScripture(string volume, string startReference, string endReference)
  {
    // create a variable to hold a verse if only one
    string selectedVerses = "There was an error while setting up your scritpure.";
    // create a list to hold the verses selected
    List<string> verseList = new List<string>();
    // create ScritureVolumes object to access its methods
    ScriptureVolumes volumes = new ScriptureVolumes();
    // create a variable to hold the weblink for the scripture volumes
    // and get the weblink through the ScriptureVolumes' get method   
    string linkOT = volumes.GetWebLinkOldTestament();
    string linkNT = volumes.GetWebLinkNewTestament();
    string linkBOM = volumes.GetWebLinkBookOfMormon();
    string linkDAC = volumes.GetWebLinkDoctrineAndCovenants();
    string linkPOGP = volumes.GetWebLinkPearlOfGreatPrice();    
    // use a variable to hold the async task waiting for the 
    // ScriptureVolumes method to load its _json"VolumeName" string
    var getOTJson = Task.Run(async () => await volumes.SetJsonOldTestament(linkOT));
    var getNTJson = Task.Run(async () => await volumes.SetJsonNewTestament(linkNT));
    var getBOMJson = Task.Run(async () => await volumes.SetJsonBookOfMormon(linkBOM));
    var getDACJson = Task.Run(async () => await volumes.SetJsonDoctrineAndCovenants(linkDAC));
    var getPOGPJson = Task.Run(async () => await volumes.SetJsonPearlOfGreatPrice(linkPOGP));
    // use the Wait method to wait until the _json"VolumeName" 
    // string is loaded in ScriptureVolumes by the set method
    getOTJson.Wait();
    getNTJson.Wait();
    getBOMJson.Wait();
    getDACJson.Wait();
    getPOGPJson.Wait();  
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
    // if there are item in the list
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