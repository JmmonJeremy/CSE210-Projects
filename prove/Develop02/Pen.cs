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
  // variable to hold the username for users
  // which is used to make the file that holds
  // the entry backup file associated with them
  string _userName;
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
  // method to tag all entries to their user
  public string Username()
  {
    // create a boolean to use to keep a while loop running
    string moveOn = "no";
    // create a loop that runs until the user has entered a valid username
    // and until the user has verified that the usernam they entered is correct
    while (moveOn == "no")
    {
      // ask the user to enter their username
      Console.Write("Please enter your username: ");
      // store their answer in the _entryBackupFile variable
      _entryBackupFile = Console.ReadLine();
      // verify that the username only contains letters and numbers
      // reference source: https://www.techiedelight.com/check-string-consists-alphanumeric-characters-csharp/
      if ((_entryBackupFile.All(char.IsLetterOrDigit)) == false)
      {
        // show the user the username they entered
        Console.WriteLine($"\nYou entered: {_entryBackupFile}");        
        // If it is not, inform the user and ask them to enter a different username
        Console.WriteLine("The username must consist of only letters and numbers with no spaces.\nPlease only use alphanumeric characters.");
      }      
      // if the username is the correct format, then 
      // ensure the user entered the username they meant to
      else
      {
        // show the user the username they entered
        Console.WriteLine($"\nYou entered: {_entryBackupFile}");       
        // ask for a yes or no answer for if the name is correct
        Console.WriteLine("Is this the name you meant to enter for your username? (yes or no)");
        // create a variable to keep the while loop running
        string answer = "wrong";
        // create another while loop that will keep running
        // until "yes" or "no" is entered by the user
        while (answer != "yes" && answer != "no")
        {
          Console.Write("Correct username? ");
          // assign the answer to the variable answer
          answer = Console.ReadLine();
          // do this if it isn't yes or no
          if (answer != "yes" && answer != "no")
          {
            Console.WriteLine($"You entered: {answer}");
            Console.WriteLine("Only 'yes' or 'no' are vaild answers, please try again.");
          }
        }
        // assign the value of the answer to the moveOn variable so the loop 
        // will end if the answer is yes and loop again if the answer is no         
        moveOn = answer;
        // add an empty line after the response if the answer is no
        if (answer == "no")
        {
          // empty line
          Console.WriteLine();
        }
      }
    }
    // add .txt to the username so it can be used
    // as a filename and store it in this method
    return _entryBackupFile += ".txt";  
  }
  
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

  // method to display the list of uncommited prompts
  public void DisplayEntries()
  {
    // use this classes Username method to have the backup
    // file be recorded to the correct user text document
    string file = Username();
    // set the returning dictionary list equal to
    // the ViewEntries method from this class
    var list = ViewEntries();            
    // add a space before transition statement
    Console.WriteLine();
    // change type color of ending statement to red to draw user's attention
    Console.ForegroundColor = ConsoleColor.Red;
    // tell the user where to find the requested information
    Console.WriteLine($"|{Convert.ToChar(25)} {Convert.ToChar(31)} {Convert.ToChar(25)}| Below are all of the journal entries not yet committed to your Journal |{Convert.ToChar(25)} {Convert.ToChar(31)} {Convert.ToChar(25)}|\n");
    // reset the console writing color
    Console.ResetColor();
    // add a space before the list of entries
    Console.WriteLine();
    // loop through the dictionary and print out the key and
    // tuple of the date, prompt, and entry with spaces between each set
    foreach (var tuple in list)
    {
      // color the title red
      Console.ForegroundColor = ConsoleColor.Red;
      // show just the day and time underlined
      // for the entry marker or title
      TextStyles.WriteUnderline($"{tuple.Key.DayOfWeek} ");
      TextStyles.WriteUnderline(tuple.Key.ToString("h:mm tt\n"));
      // color the date and time yellow
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      // show the date and time
      Console.WriteLine(tuple.Value.Item1);
      // color the journal prompt blue
      Console.ForegroundColor = ConsoleColor.Cyan;
      // show the prompt
      Console.WriteLine(tuple.Value.Item2);
      // reset the text color to original
      Console.ResetColor();
      // show the entry
      Console.WriteLine(tuple.Value.Item3);
      // add space between entries
      Console.WriteLine();                 
    }
    Console.ForegroundColor = ConsoleColor.Red;            
    // let the user know what has happened with a space before it
    // plus add in an arrow pointing up            
    Console.WriteLine($"\n|{Convert.ToChar(24)} {Convert.ToChar(30)} {Convert.ToChar(24)}| Your uncommitted journal entries are now displayed in the terminal space above here |{Convert.ToChar(24)} {Convert.ToChar(30)} {Convert.ToChar(24)}|"); 
    // reset the console writing color
    Console.ResetColor();
  }
}