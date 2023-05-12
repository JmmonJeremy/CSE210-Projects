using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// ### CLASS ################################################ //
// class to save entries into a journal & read entries from it
public class Journal
{

  // ### VARIABLE ATTRIBUTES ################################## //
  // variable to hold file name for the journal
  string _journalFile = "journal.txt";
  // variable to hold the start date of a range of Journal entries
  DateOnly _startDate;
  // variable to hold the end date of a range of Journal entries
  DateOnly _endDate;
  // list to hold all of the journal entries for viewing all of the journal entries
  List<string> _dayEntries = new List<string>();
   // dictionary list to hold the journal file entries by date
  IDictionary<DateOnly, List<string>> _journalVolume = new Dictionary<DateOnly, List<string>>();
  // dictionary list to hold the journal entries by date
  IDictionary<DateOnly, List<string>> _journalEntries = new Dictionary<DateOnly, List<string>>();
  // dictionary to hold numbers for the keys so new lists can be generated with each loop 
  // iteration for help to save the journal by date in coordination with _journalEntries dictionary
  IDictionary<int, List<string>> _jE = new Dictionary<int, List<string>>();
  // dictionary to hold numbers for the keys so new lists can be generated with each loop 
  //  iteration for viewing specific dates within the journal in coordination with _journalVolume
  IDictionary<int, List<string>> _jV = new Dictionary<int, List<string>>();

  // ### METHODS ############################################## //
  // method to save pending Journal entries to the journal file
  public void AddToJournal(IDictionary<DateTime, (string,string,string)>entries)
  {
    // create a file that will add new entries each time this is called by adding append:true
    // reference source: https://stackoverflow.com/questions/8255533/how-to-add-new-line-into-txt-file
    using (StreamWriter createFile = new StreamWriter(_journalFile, append:true))
    {     
      // create variable to hold the date comparison key
      // reference source: https://stackoverflow.com/questions/57440077/get-first-value-of-dictionary-object-without-using-loop#:~:text=You%20can%20use%20Linq%2C%20.,from%20KeyValuePair%20irrespective%20of%20order. & https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.first?view=net-7.0
      DateOnly comparisonKey = DateOnly.FromDateTime(entries.Keys.First());   
      // create variable to hold count for # of days
      int day = 1;
      // create variable to hold the number of looping iterations
      int loops = 0;
      // create a varible to compare the loops to the dictionary list's count
      int totalEntries = entries.Count; 
      // loop through the dictionary list    
      foreach (var entry in entries)
      {
        // count the number of looping iterations
        loops += 1;          
        // create variable to hold the date key
        // reference source: https://learn.microsoft.com/en-us/dotnet/standard/datetime/how-to-use-dateonly-timeonly
        DateOnly key = DateOnly.FromDateTime(entry.Key);     
        // compare keys to see if it is the same date      
        if (key == comparisonKey)
        {       
          // create generic number lists in a dictionary with controled count equal to pending entry days
          // reference source: https://stackoverflow.com/questions/33570452/create-a-new-list-when-i-have-new-key-while-adding-to-dictionary-in-a-loop
          if (!_jE.ContainsKey(day))
          {
            // create new list
            _jE[day] = new List<string>();
          }       
          // load entry parts into list for matching day
          // reference source: https://social.msdn.microsoft.com/Forums/vstudio/en-US/78132906-9d0a-4eff-836a-9c48253305e4/in-c-how-do-you-output-the-contents-of-a-dictionary-class?     
          _jE[day].Add(entry.Value.Item1);
          _jE[day].Add(entry.Value.Item2);
          _jE[day].Add(entry.Value.Item3);       
        }
        // when new date comes do this
        if (key != comparisonKey)
        {
          // add the list with the date key to the dictionary list
          _journalEntries.Add(comparisonKey, _jE[day]);     
          // set the comparison equal to the new date
          comparisonKey = key;        
          // add to a count to number each key
          day += 1; 
          // load entry parts into list for start of next day
          if (!_jE.ContainsKey(day))
          {
            // create new list
            _jE[day] = new List<string>();
          }  
          // load entry parts into list for matching day
          _jE[day].Add(entry.Value.Item1);
          _jE[day].Add(entry.Value.Item2);
          _jE[day].Add(entry.Value.Item3); 
        }
        // for the last day of entry times that miss above actions
        if (loops == totalEntries)
        {
          // add the list with the last entry day # to the dictionary list
          _journalEntries.Add(key, _jE[day]);        
        }
      }  
      // read contents of dictionary with just the date as the key into file
      foreach (var entryDay in _journalEntries)
      {
        // write the date key into the file 
        // reference resource: https://www.c-sharpcorner.com/UploadFile/mahesh/how-to-get-all-keys-of-a-dictionary-with-C-Sharp/ 
        createFile.Write($"~|~{entryDay.Key}");
        // loop through the list associated with the key
        // reference source: https://social.msdn.microsoft.com/Forums/vstudio/en-US/d63f766c-c8b2-4a6b-af5b-b309cb9b9ec0/dictionaryltstringgtlistltstringgtgt-how-do-i-get-each-individual-item-from-the-list-to?forum=csharpgeneral       
        foreach (string entry in _journalEntries[entryDay.Key])
        {
          // keep all the entries in one line       
          createFile.Write($"~|~{entry}");      
        } 
        // start a new line for the next day of journal entries     
        createFile.WriteLine("");
      }  
    }
  }

  // method to load all the entries from the Journal
  public List<string> LoadAll()
  {   
    // make sure file exists 
    if (File.Exists(_journalFile))
    { 
      // load all journal entries by reading the _journalFile text file
      string[] dailyEntries = System.IO.File.ReadAllLines(_journalFile);
      foreach (string entry in dailyEntries)
      {    
        // this divides each line into # of items 
        string[] entryParts = entry.Split("~|~");
        // add each item into the list    
        foreach (string entryPart in entryParts)
        {
          _dayEntries.Add(entryPart);
        }         
      }
    }    
    // return the list for display purposes
    return _dayEntries;
  }

  // method to display Journal entries by specific dates to the console
  public void SelectDates()
  {
    // check if file exists 1st
    if (File.Exists(_journalFile))
    {     
      // set variable so it can be read in all functions below
      DateOnly comparisonKey = DateOnly.FromDateTime(DateTime.Parse("6/9/1972"));     
      // load all journal entries to the dictionary
      // by reading the _journalFile text file
      string[] entries = System.IO.File.ReadAllLines(_journalFile);
      // create a variable to add numbers for seperate list names
      int entryNumber = 1; 
      // create variable to hold the number of looping iterations
      int loops = 0;    
      // create a varible to compare the loops to the dictionary list's count
      int totalEntries = entries.Count(); 
      // doing this to get the 1st date as a standard check
      foreach (string top in entries) 
      {
        // this divides each line into # of items
        string[] split = top.Split("~|~");
        // create date key checker to lump all the same dates together
        // if there are 2 commits on one day
        comparisonKey = DateOnly.FromDateTime(Convert.ToDateTime(split[1]));
        // stop looping after 1st loop to keep the first key 
        break;
      }      
      // cycle through entries and split them by character
      foreach (string entry in entries)
      { 
        // keep track of each looping
        loops += 1;            
        // this divides each line into # of items
        string[] entryPart = entry.Split("~|~");       
        // put the key in a variable       
        DateOnly key = DateOnly.FromDateTime(Convert.ToDateTime(entryPart[1]));
        // add items to the dictionary list with 
        // a number key corresponding with days
        for (int i = 2; i < entryPart.Count(); i++)
        {  
          // Console.WriteLine($"entryNumber: {entryNumber}");      
          // if the number key doesn't exist
          if (!_jV.ContainsKey(entryNumber))
          {
            // create new list
            _jV[entryNumber] = new List<string>();
          } 
          // add item to the list 
          _jV[entryNumber].Add(entryPart[i]);               
        }
        // if there is a duplicate date
        if (comparisonKey == key)
        {         
          // remove key the duplicate key from the dictionary
          _journalVolume.Remove(key);
           // add the updated list to the dictionary
          _journalVolume.Add(key, _jV[entryNumber]);
        }
        // do this for the first loop
        if (loops == 1)
        {
          // increase the number by one for the date set
          entryNumber += 1;
        }
          // do this when it is a new date
        if (comparisonKey != key)
        {          
          // add the list to the dictionary
          _journalVolume.Add(key, _jV[entryNumber]);        
          // set the comparison equal to the new date
          comparisonKey = key;
          // increase the number by one for each date set
          entryNumber += 1;
          // add items to the dictionary list with 
          // a number key corresponding with days
          for (int i = 2; i < entryPart.Count(); i++)
          {        
            // if the number key doesn't exist
            if (!_jV.ContainsKey(entryNumber))
            {
              // create new list
              _jV[entryNumber] = new List<string>();
            }  
            // add item to the list 
            _jV[entryNumber].Add(entryPart[i]);
          }                    
        }       
      }
    foreach (var date in _journalVolume)
    {
      Console.WriteLine(date.Key);
      foreach (string line in date.Value)
      {
        Console.WriteLine($"{line}");
      }
      Console.WriteLine();
    }     
     
    }
  }
}
