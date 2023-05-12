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
  // dictionary to hold a desired range of dates
  IDictionary<DateOnly, List<string>> _dateRange = new Dictionary<DateOnly, List<string>>();

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

  // method to load all of the journal file into a dictionary list
  public IDictionary<DateOnly, List<string>> FileToList()
  {
    // check if file exists 1st
    if (File.Exists(_journalFile))
    {       
      // establish variable for comparisonKey here 
      // so it won't be isolated or exculedin any function below
      DateOnly comparisonKey = DateOnly.FromDateTime(DateTime.Parse("6/9/1972"));     
      // load all journal entries to the dictionary
      // by reading the _journalFile text file
      string[] entries = System.IO.File.ReadAllLines(_journalFile);
      // create a variable to add numbers for seperate list names
      int entryNumber = 1; 
      // create variable to hold the number of looping iterations
      int loops = 0; 
      // create varialb to keep track of repeat day entries in file
      int repeatDay = 0;    
      // create a varible to compare the loops to the dictionary list's count
      int totalEntries = entries.Count(); 
      // doing this to get the 1st date as a standard check 
      // for the variable established above to be used anywhere
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
        // do this for the first loop only
        // so it is included in the list
        if (loops == 1)
        {
          // add the list just made to the dictionary
          _journalVolume.Add(key, _jV[entryNumber]);
          // increase the number by one for the date set
          entryNumber += 1;          
        }
        // must be before comparisonKey != key so that it skips this case 
        // and loads data before reaching this from comparisonKey != key case 
        // do this if repeat of same date & not 1st day iteration
        if (comparisonKey == key && loops != 1)
        {
          // create a variable to make index numbers for beginning of list
          int index = -1;       
          // take the last committed list information out of the last list in the dictionary
          foreach (string repeatDayStart in _journalVolume[_journalVolume.Keys.Last()])
          {
            // increase the index number by one every insert & iteration 
            // reference source: https://www.techiedelight.com/add-item-at-the-beginning-of-a-list-in-csharp/ 
            index += 1;             
            _jV[entryNumber].Insert(index, repeatDayStart);                  
          }
          // take the last committed list out of dictionary
          // remove key because it still needs to load more data from the same day
          _journalVolume.Remove(key); 
          // add the list made to the dictionary to cover the case
          // that this is the only additonal entry for the same date
          _journalVolume.Add(key, _jV[entryNumber]); 
          // change the number to be able to create a new list
          entryNumber += 1;
        }
        // do this when it is a new date
        if (comparisonKey != key)
        {          
          // add the list made to the dictionary
          _journalVolume.Add(key, _jV[entryNumber]);        
          // set the comparison equal to the new date
          comparisonKey = key;
          // increase the number by one for each date set
          entryNumber += 1;                      
        }        
      }     
    } 
    return _journalVolume;         
  }

  // method to create a dictionary list from the requested date range
  public IDictionary<DateOnly, List<string>> GetSelection(IDictionary<DateOnly, List<string>> journal, string _startDate, string _endDate)
  {  
    // create variables to be uses and i in for loop
    int indexStart = -1;
    // create a variable to hold the ending index number
    int indexEnd = -1;
    // convert start date & end date to DateOnly
    DateOnly startDate = DateOnly.FromDateTime(Convert.ToDateTime(_startDate));
    DateOnly endDate = DateOnly.FromDateTime(Convert.ToDateTime(_endDate));
    // make sure start date file exists
    // reference source: https://www.techiedelight.com/determine-key-exists-dictionary-csharp/ 
    if(journal.TryGetValue(startDate, out var start))
    {
      // let the user know that there is a journal entry for that date
      Console.WriteLine($"The date {_startDate} does have a journal entry.");
      // cycle through the journal dictionary 
      foreach (var key in journal)
      {
        // add one for each cycle to match index numbers
        indexStart += 1; 
        // check for when the startDate given matches the date key
        if (key.Key == startDate)
        {
          // stop on the starting index number
          break;
        }
      }
    }
    else
    {
      // let the user know that there is not a journal entry for that date
      Console.WriteLine($"There is no journal entry for {_startDate}, the closest date prior to that was:");
    }
    // make sure end date file exists
    // reference source: https://www.techiedelight.com/determine-key-exists-dictionary-csharp/ 
    if(journal.TryGetValue(endDate, out var end))
    {
      // let the user know that there is a journal entry for that date
      Console.WriteLine($"The date {_endDate} does have a journal entry.");      
      // cycle through the journal dictionary
      foreach (var key in journal)
      {
        // add one for each cycle to match index numbers
        indexEnd += 1; 
        // check for when the endDate given matches the date key
        if (key.Key == endDate)
        {
          // stop on the ending index number
          break;
        }
      }
    }
    else
    {
      // let the user know that there is not a journal entry for that date
      Console.WriteLine($"There is no journal entry for {_endDate}, the closet date after that was: ");
    } 
    // create iteration variable starting at -1 so count matches index #s
    int i = -1;   
    // cycle through dictionary and move all lists of journal 
    // entries in the date range into their own dictionary list    
    foreach (var date in journal)
    {   
      // #increase index every iteration 
      i += 1;    
      // determine when to start & stop
      if (i >= indexStart && i <= indexEnd)
      {        
        // fill _dateRange dictionary with the date range requested
        // reference source: https://www.dofactory.com/code-examples/csharp/dictionary-value-by-key
        _dateRange.Add(date.Key, date.Value);
      }
    }    
    // return the list for display purposes
    return _dateRange;
  }

  // method to diplay the journal to the console
  public void ConsoleDisplay(IDictionary<DateOnly, List<string>> journal)
  {
    // create variable for count of lines after each date      
    int lineSelector = 0;
    // cycle through each line
    foreach (var date in journal)
    {       
      // print the date in underlined in red to the console
      Console.ForegroundColor = ConsoleColor.Red;
      Program.WriteUnderline($"{date.Key.ToString()}\n");
      Console.ResetColor();   
      // then print each line to the console
      foreach (string line in date.Value)
      {
        // numbers each line after the date 
        lineSelector += 1;
          // colors each question blue
        if (lineSelector == 1 || (lineSelector-1)%3 == 0)
        {
          Console.ForegroundColor = ConsoleColor.DarkYellow;
          Console.WriteLine(line);
          Console.ResetColor();          
        }
        // colors each question yellow
        else if (lineSelector == 2 || (lineSelector-2)%3 == 0)
        {
          Console.ForegroundColor = ConsoleColor.Cyan;
          Console.WriteLine(line);
          Console.ResetColor();          
        }
        else
        {  
          // prints the rest of the lines normal to console 
          Console.WriteLine($"{line}");            
        }                 
      }
      // puts a space between each date entry
      Console.WriteLine();
      // resets line count to start at 1 for each date
      lineSelector = 0;
    }
  }
}




