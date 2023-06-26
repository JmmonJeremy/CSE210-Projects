using System;
using System.IO;

// ### CLASS ################################################ //
// class to run the reflectoin activity
public class ReflectionActivity : Activity
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // variable to hold the file for the _promptList storage
  private string _promptsFile = "promptList.txt";
  // variable to hold the file for the _usedPrompts storage
  private string _usedPromptsFile = "UsedPrompts.txt";
  // variable to hold the file for the _questionList storage
  private string _questionsFile = "questonList.txt";
  // variable to hold the file for the _usedQuestions storage
  private string _usedQuestionsFile = "usedQuestions.txt";
  // list to hold the list of reflection prompts for the activity
  private List<string> _promptList = new List<string>()
  {
    "Think of a time when I showed love for someone.",
    "Think of a time when I endured hardship for a good cause.",
    "Think of a time when I helped someone do something that they couldn't have done alone.",
    "Think of a time when I put the needs of someone else above my own needs.",
    "Think of a time when I gave a gift to someone.",
    "Think of a positive contribution I have given to a project.",
    "Think of something positive that I have created.",
    "Think of a time when I gave someone my full attention and listened intently to them.",
    "Think of a time when I did something difficult because I was motivated by love.",
    "Think of a time when I did something uncomfortable because I was motivated by love.",
    "Think of a time when my love overcame my fear.",
    "Think of a time when I did something for someone else when I didn't have to.",
    "Think of some positive thoughts that I have had.",
    "Think of a time when I complemented someone.",
    "Think of a time when dispite someone's mistreatment of me, I returned kindness to them.",
    "Think of something good I have done.",
    "Think of a good characteristic I possess and a time when I demonstrated that characteristic"
  };
  // list to hold the used reflection prompts
  private List<string> _usedPrompts = new List<string>();
  // list to hold questions for further reflection about the prompt 
  private List<string> _questionList = new List<string>()
  {
    "How does this experience confirm the goodness within me?",
    "Have I done something like this more than once?",
    "What moved me to action?",
    "How did this event make me feel?",
    "What helped me to successfully accomplish this?",
    "What do I most cherrish about this experience?",
    "Can I learn anything from this experience that I can apply elsewhere?",
    "What does this experience teach me about myself?",
    "What can I do to better remember times like this in my life?",
    "How can this help me to love myself?",
    "What can I do to better reinforce actions like this in my life?",
    "Can I see myself doing things like this more often?",    
  };
  // list to hold the used reflection questions
  private List<string> _usedQuestions = new List<string>();

// ### CONSTRUCTORS ######################################### //   
  // constructor to set up for the Reflectoin Activity
  public ReflectionActivity() : base ("Reflection Activity", "reflect on times in your life when you have been true to the good that is within you and acted in ways that align with that vision of yourself. This will help you to love yourself, to recognize your goodness, and to reinforce good acts in your life.")
  {
    // base variables are all done in the Activity base class      
  }

// ### METHODS ############################################## //
  // method to get a random prompt
  public string RandomPrompt()
  {
    // PREVENT REUSE OF THE SAME PROMPT - START
    // if the _usedPrompts list is not empty
    if (_usedPrompts.Count > 0)
    {
      // cycle through the list
      foreach (string usedprompt in _usedPrompts)
      { 
        // if the prompt exists in the _usedPrompts list       
        if (_promptList.Contains(usedprompt))
        {
          // remove it from the _promptList 
          _promptList.Remove(usedprompt);
        }        
      }
    // PREVENT REUSE OF THE SAME PROMPT - PAUSE #1
    }       
    // set a variable to hold the _promptList count
    int count = _promptList.Count;
    // PREVENT REUSE OF THE SAME PROMPT - RESTART #1
    // if the _promptList is empty
    if (count == 0)
    {
      // add the contents of the _usedPrompts list to the _promptList
      _promptList.AddRange(_usedPrompts);
      // empty the contents of the _usedPrompts list
      _usedPrompts.Clear();
    // PREVENT REUSE OF THE SAME PROMPT - PAUSE #2
    }    
    // create a Random object for selecting the index #
    Random _randomIndexSelector = new Random();
    // randomly select a number to represent a list index
    int indexSelector = _randomIndexSelector.Next(0, count);    
    // PREVENT REUSE OF THE SAME PROMPT - RESTART #2 & END
    // add the selected prompt to a new list
    _usedPrompts.Add(_promptList[indexSelector]);     
    // return the prompt with that index from the _promptList
    return _promptList[indexSelector];
  } 

  // method to get a random question
  public string RandomQuestion()
  {    
    // PREVENT REUSE OF THE SAME QUESTON - START
    // if the _usedQuestions list is not empty
    if (_usedQuestions.Count > 0)
    {
      // cycle through the list
      foreach (string usedquestion in _usedQuestions)
      { 
        // DEBUG CODE: Console.WriteLine($"USED-Q: {usedquestion}");
        // reference source: https://www.geeksforgeeks.org/c-sharp-how-to-check-whether-a-list-contains-a-specified-element/
        // if the question exists in the _usedQuestions list       
        if (_questionList.Contains(usedquestion))
        {
          // reference source: https://www.educative.io/answers/how-to-remove-elements-from-a-list-in-c-sharp
          // remove it from the _questionList 
          _questionList.Remove(usedquestion);
          // DEBUG CODE: foreach (string question in _questionList)
          // {
          //   Console.WriteLine($"Q-LIST: {question}");
          // }
        }        
      }
    // PREVENT REUSE OF THE SAME QUESTION - PAUSE #1
    } 
    // DEBUG CODE: else{Console.WriteLine("The used question list is empty.");}       
    // set a variable to hold the _questionList count
    int count = _questionList.Count;
    // PREVENT REUSE OF THE SAME QUESTION - RESTART #1
    // if the _questionList is empty
    if (count == 0)
    {
      // reference source: https://www.tutorialspoint.com/How-to-append-a-second-list-to-an-existing-list-in-Chash
      // add the contents of the _usedQuestions list to the _questionList
      _questionList.AddRange(_usedQuestions);
      // reference source: https://www.tutorialspoint.com/how-to-empty-a-chash-list
      // empty the contents of the _usedQuestions list
      _usedQuestions.Clear();
    // PREVENT REUSE OF THE SAME QUESTION - PAUSE #2
    }    
    // create a Random object for selecting the index #
    Random _randomIndexSelector = new Random();
    // randomly select a number to represent a list index
    int indexSelector = _randomIndexSelector.Next(0, count);
    // PREVENT REUSE OF THE SAME QUESTION - RESTART #2 & END
    // add the selected question to a new list
    _usedQuestions.Add(_questionList[indexSelector]);    
    // return the prompt with that index
    return _questionList [indexSelector];
  } 

  // method to display a prompt and prepare the user to start reflection about it
  public void PrepareReflection()
  {
    // tell the user what to do with an empty line before it
    Console.WriteLine("\nThink of a response for the following prompt:");
    // put an empty space before the prompt and indent it
    Console.Write("\n    ");
    // change the color of the background for the prompt
    Console.BackgroundColor = ConsoleColor.DarkGreen;
    // display the prompt with an empty line before it
    Console.WriteLine($" {Convert.ToChar(29)} {RandomPrompt()} {Convert.ToChar(29)} ");
    // reset the backgroung color to what it was
    Console.ResetColor();
    // let the user know what to do when they have thought of something with an empty line before it
    Console.Write($"\n     {Convert.ToChar(18)} When you have your response in mind, start the reflection exercises by pressing enter {Convert.ToChar(18)} ");
    // pause until they press enter
    Console.ReadLine();
    // give the user further instructions with an empty line before it
    Console.WriteLine("\nNow contemplate each of the following questions in relation to your response:");
    // prepare them to begin
    Console.WriteLine("Starting in 10 seconds. . . "); 
    // display a count and clock spinner for a countdown CHANGE FROM 10 TO 1 FOR DEBUGGING
    Spinner(ConsoleColor.Cyan, ConsoleColor.DarkBlue, 10); 
    // clear the screen for the beginning of the reflection activity
    Console.Clear();
  }

  // method to direct the reflection exercises
  public void ReflectionExercises()
  {
    // save the original contents of the _spinnerSymbols list
    List<string> clonedList = new List<string>(GetSpinnerSymbols());
    // change the contents of the _spinnerSymbols for the 
    // Reflection exercise pondering timed counts
    // fill a new list with the contents for the Reflection exercises
    List<string> reflectionSymbols = new List<string>()
    {
      (Convert.ToChar(15)).ToString(),
    };
    // set the _spinnerSymbols list to a new value    
    SetSpinnerSymbols(true, reflectionSymbols);    
    // display the mindfulness prompt
    Console.WriteLine($"{RandomQuestion()}");
    // display a count and clock spinner for a countdown CHANGE FROM 15 TO 1 FOR DEBUGGING
    Spinner(ConsoleColor.Green, ConsoleColor.DarkGreen, 15); 
    // set the _spinnerSymbols list to the original contents    
    SetSpinnerSymbols(true, clonedList);    
  }

  // method to run everyting for the Reflection Activity
  public string RunAllReflection()
  {    
    // create object of FileListRelationship class to run its methods
    FileListRelationship convert = new FileListRelationship();
    // create reflection object so the correct activity name and description are passed in
    // as well as all of the other things for the intro and the boolean
    ReflectionActivity reflection = new ReflectionActivity();
    // run the opening with the correct activity name & descriptiorn from using
    // the object while running this inherited method from the Activity class
    reflection.Opening();
    // convert the _promptsFile, _usedPromptsFile, _questionsFile, & usedQuestonsFile to their matching lists
    convert.FileToList(_promptsFile, _promptList); 
    convert.FileToList(_usedPromptsFile, _usedPrompts);
    convert.FileToList(_questionsFile, _questionList); 
    convert.FileToList(_usedQuestionsFile, _usedQuestions);
    // run prepare with the correct activity name from using the object 
    // while running this inherited method from the Activity class
    reflection.PrepareActivity(); 
    // run this class specific PrepareReflection method
    PrepareReflection();
    // run the central part of the Reflection Activity with the object while running this inherited method 
    // from the Activity class so it works properly by including the boolean and _sessionLength values   
    reflection.RunActivity(ReflectionExercises);
    // save the _promptList, _usedPrompts, _questionList, & usedQuestons lists to a file to recover with next start up    
    convert.ListToFile(_promptList, _promptsFile); 
    convert.ListToFile(_usedPrompts, _usedPromptsFile);
    convert.ListToFile(_questionList, _questionsFile); 
    convert.ListToFile(_usedQuestions, _usedQuestionsFile);
    // run end activity message in this inherited method from the Activity class
    EndActivity();
    // run the closing with the correct activity name with the object while running this inherited
    // method from the Activity class then save the choice of the user in the choice variable  
    string choice = reflection.Closing();
    // return the user's choice
    return choice;
  }
}