using System;
using System.Collections.Generic;
using System.IO;

// ### CLASS ################################################ //
// class to record temporary journal entries
public class Pen
{
// ### VARIABLE ATTRIBUTES ################################## //
  // variable to hold the date
  string _dateTime;
  // variable to hold the used prompt
  string _promptUsed;
  // variable to hold the entry
  string _entry;
  // variable to hold the entry backup file
  string _entryBackupFile = "entryBackup.txt";
  // variable to hold the entry number  
  DateTime _timeKey;
  // tuple to hold the three differnt items for an entry
  // reference source: https://www.tutorialsteacher.com/csharp/csharp-tuple
  (string dateTime, string promptUsed, string entry) _entryItems;
  // list to hold the pending journal entries
  // reference source: https://www.tutorialsteacher.com/csharp/csharp-dictionary & https://stackoverflow.com/questions/14987156/one-key-to-multiple-values-dictionary-in-c
  IDictionary<DateTime, (string,string,string)> _pendingEntries = new Dictionary<DateTime, (string, string, string)>();

// ### METHODS ############################################## //
  // method to add a temporary entry
  public void Add(DateTime timeKey, string dateTime, string _prompt)
  {
     // store the dateTime for a key
    _timeKey = timeKey;
    // store date & time of entry in a variable
    _dateTime = dateTime;   
    // and store prompt in a variable     
    _promptUsed = _prompt;   
    // store journal entry in variable
    _entry = Console.ReadLine();   
    // store entry parts into a tuple
    // reference source: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
    _entryItems = (_dateTime, _promptUsed, _entry);
    // make sure file exists - only time it won't is when first run
    // reference source: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.appendtext?view=net-8.0
    if (File.Exists(_entryBackupFile))
    { 
      // load all backup entries to the dictionary that haven't been saved to the journal
      // by reading the _entryBackupFile text file
      string[] entries = System.IO.File.ReadAllLines(_entryBackupFile);
      foreach (string entry in entries)
      {    
        // this divides each line into # of items per "WriteLine" entry [0], which is blank
        // so for the first line you skip [0] because it is empty and start with entryPart [1]
        string[] entryPart = entry.Split("~|~");
        // seperate out the key     
        DateTime key = Convert.ToDateTime(entryPart[1]);
        // seperate out the three string parts for the tuple 
        string time = entryPart[2]; 
        string prompt = entryPart[3];
        string response = entryPart[4];
        // add the string parts of the entry to the tuple
        (string, string, string) entryLog = (time, prompt, response);        
        // add the entry to the dictionary
        _pendingEntries.Add(key, entryLog);     
      }
    }
    // load entry parts into dictionary to store entry parts under a timeKey 
    // reference source: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2?view=net-7.0    
    _pendingEntries.Add(_timeKey, _entryItems);
    // create a file that will add new entries each time this is called by adding append:true
    // reference source: https://stackoverflow.com/questions/8255533/how-to-add-new-line-into-txt-file
    // create the entry backup text file
    using (StreamWriter createFile = new StreamWriter(_entryBackupFile))
    {     
      // this puts the ~|~ characters in front of every entry part as a seperator
      // and writes the list of prompts to the file - overwriting anything there already 
      foreach (var entryFile in _pendingEntries)
      { 
        // create variable to hold the key
        DateTime key = entryFile.Key;
        // createFile.WriteLine($"~|~{entryFile}"); 
        createFile.Write($"~|~{entryFile.Key}"); 
        createFile.Write($"~|~{entryFile.Value.Item1}");
        createFile.Write($"~|~{entryFile.Value.Item2}");
        createFile.WriteLine($"~|~{entryFile.Value.Item3}");      
      }          
    }

    // // ############# LEARNING CODE ###################
    // // go through each value
    // foreach(var entryParts in _pendingEntries)
    // {
    //   // convert string into DateTime
    //   // reference source: https://www.c-sharpcorner.com/UploadFile/manas1/string-to-datetime-conversion-in-C-Sharp/ 
    //   DateTime find = Convert.ToDateTime("5/9/2023 11:13:32 PM");
    //   find = find.Date.AddHours(find.Hour).AddMinutes(find.Minute);
    //   timeKey = timeKey.Date.AddHours(timeKey.Hour).AddMinutes(timeKey.Minute);
    //   if (timeKey == find)
    //   {
    //     Console.WriteLine($"{timeKey} == {find}");
    //     Console.WriteLine("You passed the test");
    //   }
    //   // print out each item in tuple seperately
    //   // reference source: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
    //   Console.WriteLine(_entryItems.dateTime);
    //   Console.WriteLine(_entryItems.promptUsed);
    //   Console.WriteLine(_entryItems.entry);
    //   Console.WriteLine(_timeKey);
    //   // reference source: https://www.c-sharpcorner.com/UploadFile/mahesh/how-to-get-all-keys-of-a-dictionary-with-C-Sharp/ 
     
    //   Console.WriteLine("Key: {0}", entryParts);
    //   Console.WriteLine(_pendingEntries[entryParts.Key]);
    // }
    // Console.WriteLine(_timeKey);
    // // reference source: https://www.dofactory.com/code-examples/csharp/dictionary-value-by-key & https://stackoverflow.com/questions/40574787/how-to-get-from-dictionarychar-tuple-int-char-int-value-for-specific-key
    // Console.WriteLine(_pendingEntries[_timeKey].Item1);
    // Console.WriteLine(_pendingEntries[_timeKey].Item2);
    // Console.WriteLine(_pendingEntries[_timeKey].Item3);
    // Console.WriteLine(_pendingEntries.Values);
    // // reference sources: https://social.msdn.microsoft.com/Forums/vstudio/en-US/78132906-9d0a-4eff-836a-9c48253305e4/in-c-how-do-you-output-the-contents-of-a-dictionary-class?forum=csharpgeneral
    // foreach (var value in _pendingEntries.Values)
    //         {
    //             Console.WriteLine("Value of the Dictionary Item is: {0}", value.Item1);
    //         }
    // // ############# LEARNING CODE ###################
  }

  // method to view pending journal entries
  public void View()
  {

  }

  // method to edit pending journal entries
  public void Edit()
  {
    
  }
}