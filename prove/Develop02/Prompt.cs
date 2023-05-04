using System;
using System.Collections.Generic;

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
    // variable for set times to prompt
    public string _time = "14:15:00";  

    // list of prompts
    // looked up how to do this from https://www.tutorialsteacher.com/csharp/csharp-list
    public List<string> _prompts = new List<string>()
      {
        "What has happened today that you are thankful for?",
        "What challenges have you faced today?",
        "How have you seen the hand of the Lord in your life today?",
        "What happened today that helped to strengthen an important relationship for you?",
        "What did you accomplish that brought you closer to an important goal for you?"                    
      };

      // method to randomly select the prompt
      public string SelectPrompt()
      {
        // set variable for the amount of items in a list
        int count = _prompts.Count;
       
        // randomly select the list index for the prompt
        Random randomGenerator = new Random();
        int index = randomGenerator.Next(0, count);
        // // check count result
        // Console.WriteLine(count);
        // Console.WriteLine(_prompts[4]);
        return _prompts[index];
      }

      //  method to run as a clock to check for the timer
      public string Clock()
      {
        TimeSpan currentTime = DateTime.Now.TimeOfDay;
        string hour = currentTime.Hours.ToString();
        string minute = currentTime.Minutes.ToString();;
        string second = currentTime.Seconds.ToString();;
        return $"{hour}:{minute}:{second}";
      }

      // method to set periodic times to displaying a prompt
      public void Timer()
      {
        TimeSpan currentTime = DateTime.Now.TimeOfDay;

      }

      // method to list the prompts
      public void ListPrompts()
      {
        foreach (string p in _prompts)
        {
          Console.WriteLine(p);
        }
      }




  }
// }