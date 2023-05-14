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
  // dictionary list to hold the pending journal entries
  // reference source: https://www.tutorialsteacher.com/csharp/csharp-dictionary & https://stackoverflow.com/questions/14987156/one-key-to-multiple-values-dictionary-in-c
  public IDictionary<DateTime, (string,string,string)> _pendingEntries = new Dictionary<DateTime, (string, string, string)>();

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
        // reference source: https://www.c-sharpcorner.com/UploadFile/manas1/string-to-datetime-conversion-in-C-Sharp/ 
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
    // create the entry backup text file
    using (StreamWriter createFile = new StreamWriter(_entryBackupFile))
    {     
      // this puts the ~|~ characters in front of every entry part as a seperator
      // and writes the list of prompts to the file - overwriting anything there already 
      foreach (var entryFile in _pendingEntries)
      {       
        // createFile.WriteLine($"~|~{entryFile}");
        // reference source: https://www.dofactory.com/code-examples/csharp/dictionary-value-by-key & https://stackoverflow.com/questions/40574787/how-to-get-from-dictionarychar-tuple-int-char-int-value-for-specific-key 
        createFile.Write($"~|~{entryFile.Key}"); 
        createFile.Write($"~|~{entryFile.Value.Item1}");
        createFile.Write($"~|~{entryFile.Value.Item2}");
        createFile.WriteLine($"~|~{entryFile.Value.Item3}");      
      }          
    }
  }

  // method to view pending journal entries
  public IDictionary<DateTime, (string,string,string)> ViewEntries()
  {
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
    return _pendingEntries;
  }

  // method to erase pending journal entries from temporary file
  public void EmptyList()
  {
    // empty the entry backup text file
    using (StreamWriter emptyFile = new StreamWriter(_entryBackupFile))
    {   
      // empties the contents of the file 
      // reference source: https://social.msdn.microsoft.com/Forums/vstudio/en-US/034f5982-b41f-482a-8a92-a724701543cd/how-to-remove-all-the-content-in-a-text-file-using-c-file-related-classs?forum=netfxbcl & https://social.msdn.microsoft.com/Forums/vstudio/en-US/034f5982-b41f-482a-8a92-a724701543cd/how-to-remove-all-the-content-in-a-text-file-using-c-file-related-classs?forum=netfxbcl
      emptyFile.Flush();              
    }
  }
}