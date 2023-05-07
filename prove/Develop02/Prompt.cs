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

  public class Prompt
  {
    // variable for loading in new prompts for list
    public string _prompt;
    // variable for the file of the full list of prompts
    public string _inUsePromptFile = "inUsePrompts.txt";
    // variable for the file of the used list of prompts
    public string _usedPromptFile = "usedPrompts.txt";
    // variable for the file of deleted prompts
    public string _removedPromptFile = "deletedPrompts.txt";
    // variable for record times of prompts with journal entries
    public string _time; 
  
    // list of prompts in use
    // load list with a set of prompts
    // reference source https://www.tutorialsteacher.com/csharp/csharp-list
    public List<string> _inUsePromptList = new List<string>()
      {
        "What has happened today that you are thankful for?",
        "What challenges have you faced today?",
        "How have you seen the hand of the Lord in your life today?",
        "What happened today that helped to strengthen an important relationship for you?",
        "What did you accomplish that brought you closer to an important goal for you?"                    
      };
      // list of used prompts
      public List<string> _usedPromptList = new List<string>();
      // list of discarded prompts
      public List<string> _removedPromptList = new List<string>();

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
          Console.WriteLine($"{promptNum}) {p}");
        }
      }

      // method to add a new prompt to the prompt list
  }
// }