using System;
using System.Collections.Generic;
using System.IO;


// added a namespace to try and fix Prompt class error of:
// '<global namespace>' already contains a definition for 'Prompt' 
// using this resource: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/namespace
// instead found it was a bug in VSCode & fix was  ctr shift P - type "Restart OmniSharp"
// Link to source for the fix: https://stackoverflow.com/questions/7035437/how-to-fix-namespace-x-already-contains-a-definition-for-x-error-happened-aft
// namespace JournalApp
// {

// ### CLASS ################################################ //
// class to run journal prompts
 public class Prompt
  {
// ### VARIABLE ATTRIBUTES ################################## //
    // variable for loading in new prompts for list
    public string _prompt;
    // variable for the file of the full list of prompts
    public string _inUsePromptFile = "inUsePrompts.txt";
    // variable for the file of the used list of prompts
    public string _usedPromptFile = "usedPrompts.txt";
    // variable for the file of deleted prompts
    public string _removedPromptFile = "deletedPrompts.txt";
    // variable for record times of prompts with journal entries
    public int _selection; 
  
    // list of prompts in use
    // load list with a set of prompts
    // reference source https://www.tutorialsteacher.com/csharp/csharp-list
    public List<string> _inUsePromptList = new List<string>()
    {
      "What has happened today that I am thankful for?",
      "What challenges have I faced today?",
      "How have I seen the hand of the Lord in my life today?",
      "What happened today that helped to strengthen an important relationship for me?",
      "What did I accomplish that brought me closer to an important goal for me?",
      "This is what's happened for me so far today:"                    
    };
    // list of used prompts
    public List<string> _usedPromptList = new List<string>();
    // list of discarded prompts
    public List<string> _removedPromptList = new List<string>();

// ### METHODS ############################################## //
    // method to log prompt list changes in an archived textfile
    public void UpdateLog(List<string> list)
    {           
      // create a file
      using (StreamWriter createFile = new StreamWriter(_inUsePromptFile))
      {     
        // this puts the ~|~ characters in front of every prompt as a seperator
        // and writes the list of prompts to the file - overwriting anything there already 
        foreach (string p in list)
        {             
          createFile.WriteLine($"~|~{p}");       
        }          
      }
    }

    // method to update and return prompt lists
    public List<string> UpdateList(List<string> list, string listLog)
    {       
      // read all the prompts in the file
      string[] prompts = System.IO.File.ReadAllLines(listLog);
      foreach (string prompt in prompts)
      {    
        // this divides each line into two items [0], which is blank
        // amd items[1], which holds the prompt without the divider
        string[] items = prompt.Split("~|~");
        // therefore only use items[1]      
        string listedPrompt1 = items[1];         
        // add prompt to the prompt list
        list.Add(listedPrompt1);     
      }
      return list;
    }

    // method to randomly select the prompt
    public string RandomPrompt()
    { 
      // put a space between the data above it
      Console.WriteLine();  
      // highlight the opening statement's background color in red to catch the user's attention     
      Console.BackgroundColor = ConsoleColor.DarkRed; 
      // let the user know their journal prompt is being displayed
      Console.Write("Below is an auto-generated journal prompt to start your journal entry:");
      // reset the console display color
      Console.ResetColor();
      // display the current date and time
      // reference source: https://stackoverflow.com/questions/13044603/convert-time-span-value-to-format-hhmm-am-pm-using-c-sharp 
      DateTime entryTime = DateTime.Now;      
      Console.Write($"\n{entryTime.ToString("D")} ");
      Console.WriteLine($"({entryTime.ToString("t")})");
      // set variable for the amount of items in a list
      int count = _inUsePromptList.Count;       
      // randomly select the list index for the prompt
      Random randomGenerator = new Random();
      int index = randomGenerator.Next(0, count);
      // return the randomly selected prompt
      return _inUsePromptList[index];
    }   

    // method to list the prompts
    public void ListPrompts()
    {
      // variable to number prompts for user
      int promptNum = 0;
      // runt through list of prompts
      foreach (string p in _inUsePromptList)
      {
        // increase number by one for each prompt listed
        promptNum += 1;
        // display prompts in a list for the user to choose from
        Console.WriteLine($" {promptNum} - {p}");
      }    
    }

    // method to select a new prompt from the prompt list
    public string SelectPrompt()
    {   
      // set variable to hold entry line
      string entryLine = "\nSelection: ";
      // set variable to hold bad entry count
      int badEntries = 0;
      // set variable for loop
      bool isNumeric = false;
      // set variable for list count
      int listCount = _inUsePromptList.Count(); 
      // loop until the user enters a valid selection
      while (isNumeric == false)
      {
        // create line for selection entry
        Console.Write(entryLine);
        // capture users prompt selection
        string choice = Console.ReadLine();           
        // check to make sure they entered a number
        // reference source: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/how-to-determine-whether-a-string-represents-a-numeric-value
        // make sure number is in the prompt list
        isNumeric = int.TryParse(choice, out _selection);
        // have user reenter a number for selection if needed
        if (isNumeric == false)
        {         
          Console.Write("Your entry was not a number. For your selection to be valid, please enter the number listed next to the prompt: ");
          // change entry line to show it as new attempt
          entryLine = "\nNumber Entry: ";
          // count bad entries
          badEntries += 1;
        }
        // have user reenter a selection if number is not one listed 
        else if (_selection <= 0 || _selection > listCount)
        {                  
          Console.Write("That number was not a number listed next to one of the prompts. Please try again: ");
          // reset isNumeric to false to recheck new entry
          isNumeric = false;
            // change entry line to show it as new attempt
          entryLine = "\nListed Number: ";
          // count bad entries
          badEntries += 1;
        }
        else if (badEntries != 0)
        {
          Console.WriteLine($"\nSelection: {_selection}");
        }
      }        
      // turn number into index
      int index = _selection - 1;
      // give the transition line       
      Console.WriteLine($"Please make your entry in response to your selected prompt:");
      // display the current date and time
      DateTime entryTime = DateTime.Now;      
      Console.Write($"{entryTime.ToString("D")} ");
      Console.WriteLine($"({entryTime.ToString("t")})");
      // // display the prompt the user selected
      // Console.WriteLine(_inUsePromptList[index]); 
      return _inUsePromptList[index];
    }
  }
// }