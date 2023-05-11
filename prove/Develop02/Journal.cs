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
// list to hold all of the entries for one day
List<string> _dayEntries = new List<string>();
// dictionary list to hold the journal entries by date
IDictionary<DateOnly, List<string>> _journalEntries = new Dictionary<DateOnly, List<string>>();
// dictionary to hold numbers for the keys so new lists can be generated with each loop iteration
IDictionary<int, List<string>> _jE = new Dictionary<int, List<string>>();

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
          _jE[day] = new List<string>();
        }       
        // load entry parts into list for matching day
        // ##############        
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
          _jE[day] = new List<string>();
        }  
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

// method to retrieve entries from the Journal
public void Retrieve()
{

}

// method to display Journal entries to the console
public void Display()
{

}
}
