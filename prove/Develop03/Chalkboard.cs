using System;
using System.Collections.Generic;
using System.IO;

// ### CLASS ################################################ //
// class to hold and display the scripture to the user
public class Chalkboard
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // variable to hold the reference
  private string _reference;
  // list to hold all the words of the scripture
  private List<string> _scriptureWords = new List<string>();
  // list to hold all the Chalk objects
  private List<Chalk> _eachWord; 
  // a bolean to show when all the Chalk
  // object's hide boleans are set to true
  private bool _allHidden;
  // a bolean to show if a word on the Chalkboard
  // was just hidden for a particular round
  private bool _hidOne;

// ### CONSTRUCTORS ######################################### //
  // constructor sets up the object to recieve a string for the reference
  // and to recieve a string for the scripture verse and turn it into a list of words
  public Chalkboard(string source, string scripture)
  {
    _reference = source;
    // split string scripture up and load into the list
    // reference source: https://stackoverflow.com/questions/9263695/how-to-split-a-delimited-string-to-a-liststring
    _scriptureWords = scripture.Split(" ").ToList();
    // insert the Chalk list attribute to be filled
    _eachWord = new List<Chalk>();    
    // this starts out as false
    _allHidden = false;
    // this starts out as false
    _hidOne = false;
  }

// ### METHODS ############################################## //
  // getter method to get the _scriptureWords list that is
  // made up of the words of the scripture to be memorized
  public List<string> GetScriptureWords()
  {
    return _scriptureWords;
  }

  // setter method for the _eachWord list
  public bool SetEachWord()
  {
    bool restart = false;
    // load eachWord Chalk list with words from
    // the _scriptureWords list & set bool value to false
    foreach (string word in _scriptureWords)
    {
      if (word == "!!!")
      restart = true;
      Chalk writeWord = new Chalk(word, false);
      _eachWord.Add(writeWord);
    }
    return restart;
  }

  public List<Chalk> GetEachWord()
  {
    return _eachWord;
  }

  // method to increase the random index selector & return it
  public int IncreaseIndexSelector(List<Chalk> eachWord,  int i, int indexSelector)
  {
    // when the Chalk object is already set to true for hide & 
    // the random number matches the index & the result of the
    // index + 1 = less than the last index number in the list 
    if (eachWord[i].GetHide() && indexSelector == i && indexSelector + 1 < eachWord.Count)
    {
      // then add one to the random index selection number
      indexSelector += 1;                       
    }   
    return indexSelector;  
  }

  // must be done after Increase is done and change _hide attempted 
  // method to find index not holding _hiden true and reset both 
  // the index and indexSelector to that number & return them both
  public void MoveIndexSelection(List<Chalk> eachWord,  int i)
  {
    
    // create a dictionary to return two values
    IDictionary<string, int> numbers = new Dictionary<string, int>();
    // when it is the last word in the Chalk object list &
    // the hide bolean wasn't just marked as true & this    
    if (i == (eachWord.Count -1) && _hidOne == false)
    {
      // start cycling through the Chalk objects
      // objects from the front of the list 
      foreach (Chalk word in eachWord)
      {
        // find the first Chalk object's
        // hide bolean that is set to false
        if (word.GetHide() == false)
        {
          // and set its bolean to true
          word.SetHide(true);                           
          // then stop the loop
          break;
        }
      }
    }   
  }  

  // method to hide random words in the scriture
  public void EraseRandomWords(List<Chalk> eachWord)
  {
    // set a variable to hold the Chalk list count
    int count = eachWord.Count;
    // create a Random object for selecting the index #
    Random _randomIndexSelector = new Random();
    // randomly select a number to represent a list index
    int indexSelector = _randomIndexSelector.Next(0, count);    
   
    // loop through list of eachWord Chalk objects  
    for (int i = 0; i < count; i++)
    {       
      // if Chalk object's _hide is marked as true 
      // display the erase object's _placeHolder 
      EraseMarkedWord(eachWord, i);
      // if Chalk object's _hide is marked as false
      // display the word to the console screen
      DisplayWord(eachWord, i);     
      // increase randomly picked indexSelector by one
      indexSelector = IncreaseIndexSelector(eachWord, i, indexSelector);                       
      // match index with indexSelector & change 
      // _hide bolean to true if it is false
      MatchAndChange(eachWord, i, indexSelector);
      // search front end of list & find a Chalk object's
      // _hide bolean set to false and set it to true
      MoveIndexSelection(eachWord, i);
    } 
  }

  // method to match indexes & indexSelect 
  // & then change _hide value if it is false
  public void MatchAndChange(List<Chalk> eachWord, int i, int indexSelector)
  {
     if (indexSelector == i && !eachWord[i].GetHide())
      {         
        // set the Chalk object's hide bolean to true  
        eachWord[i].SetHide(true);
        // set the _hidOne bolean to true
        _hidOne = true;        
      }
  } 

  // method to display the Chalk word with _hide set to false
  public void DisplayWord(List<Chalk> eachWord, int i)
  {
    // when Chalk object's _hide bolean is marked as false 
    if (!eachWord[i].GetHide())
    { 
      // display the word to the console screen
      Console.Write($"{eachWord[i].GetWord()} "); 
    }
  }

  // method to hide the Chalk word with _hide set to true
  // from the Chalk word list useing the Eraser class
  public void EraseMarkedWord(List<Chalk> eachWord, int i)
  {   
    // when Chalk object's _hide bolean is marked as true 
    if (eachWord[i].GetHide())
    {        
      // create an Eraser object & pass the Chalk object into it
      Eraser erase = new Eraser(eachWord[i].GetWord());
      // Change the background color on the screen to dark gray
      Console.BackgroundColor = ConsoleColor.DarkGray;
      // display the erase object's _placeHolder to the 
      // console screen instead of the Chalk object's word
      Console.Write(erase.GetPlaceHolder());
      // reset the background color to original setting
      Console.ResetColor();
      // add a space after the placeholder
      Console.Write(" ");      
    }
  }

  // method to hide all the words in the scritpure
  public void EraseAllWords(List<Chalk> eachWord) 
  {
    // cycle through all of the Chalk objects
    foreach (Chalk hideWord in eachWord)
    {
      // ############ PUT IN the EraseAllWords in the Chalkboard class
      // create an Eraser object & pass the Chalk object into it
      Eraser erase = new Eraser(hideWord.GetWord());
      // Change the background color on the screen to dark gray
      Console.BackgroundColor = ConsoleColor.DarkGray;
      // display the erase object's _placeHolder to the 
      // console screen instead of the Chalk object's word
      Console.Write(erase.GetPlaceHolder());
      // reset the background color to original setting
      Console.ResetColor();
      // add a space after the placeholder
      Console.Write(" ");
    }
  }

  // method setting the _allHidden value
  public void SetAllHidden(List<Chalk> eachWord)
  {
    // create a count start number for counting 
    // the Chalk objects with _hide marked as true
    int hideCt = 0;
    // cycle through the Chalk objects to add up
    // all the hide boleans that are set to true
    foreach (Chalk hideTrue in eachWord)
    {
      // when hide bolean is set to true
      if (hideTrue.GetHide())
      {     
        // advance the count by one for each true _hide value 
        hideCt += 1;
      }
    }
    // when all the Chalk object's _hide value are true
    if (hideCt == eachWord.Count())
    {
      _allHidden = true;
    }
  }

  // method getting the _allHidden value
  public bool GetAllHidden()
  {
    return _allHidden;
  }
}