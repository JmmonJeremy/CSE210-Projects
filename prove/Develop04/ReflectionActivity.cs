using System;
using System.IO;

// ### CLASS ################################################ //
// class to run the reflectoin activity
public class ReflectionActivity : Activity
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // variable to hold the activity name
  private string _reflectionName;
  // variable to hold the activity description
  private string _reflectionDescription;  
  // list to hold the list of reflection prompts for the activity
  private List<string> _promptList = new List<string>()
  {
    "Think of a time when you showed love for someone.",
    "Think of a time when you endured hardship for a good cause.",
    "Think of a time when you helped someone do something that they couldn't have done alone.",
    "Think of a time when you put the needs of someone else above your own needs.",
    "Think of a time when you gave a gift to someone.",
    "Think of a positive contribution you have given to a project.",
    "Think of something positive that you have created.",
    "Think of a time when you gave someone your full attention and listened intently to them.",
    "Think of a time when you did something difficult because you were motivated by love.",
    "Think of a time when you did something uncomfortable because you were motivated by love.",
    "Think of a time when your love overcame your fear.",
    "Think of a time when you did something for someone else when you didn't have to.",
    "Think of some positive thoughts that you have had.",
    "Think of a time when you complemented someone.",
    "Think of a time when dispite someone's mistreatment of you, you returned kindness to them.",
    "Think of something good you have done.",
    "Think of a good characteristic you possess and a time when you demonstrated that characteristic"
  };
  // list to hold questions for further reflection about the prompt 
  private List<string> _questionList = new List<string>()
  {
    "How does this experience confirm the goodness within you?",
    "Have you done something like this more than once?",
    "What moved you to action?",
    "How did this event make you feel?",
    "What helped you to successfully accomplish this?",
    "What do you most cherrish about this experience",
    "Can you learn anything from this experience that you can apply elsewhere?",
    "What does this experience teach you about yourself?",
    "What can you do to better remember times like this in your life?",
    "How can this help you to love yourself?",
    "What can you do to better reinforce actions like this in your life?",
    "Can you see yourself doing things like this more often?",    
  };

// ### CONSTRUCTORS ######################################### //
  // constructor to be able to use set reflection variables
  //  and to use the get methods to get the variables values
  public ReflectionActivity()
  {
    // set the value of the _reflectionName
    _reflectionName = "Reflection Activity";
    // set the value of the _reflectionDescription
    _reflectionDescription = "reflect on times in your life when you have been true to the good that is within you and acted in ways that align with that vision of yourself. This will help you to love yourself, to recognize your goodness, and to reinforce good acts in your life.";    
  }
  // constructor to set up for the Reflectoin Activity
  public ReflectionActivity(string activityName, string description) : base (activityName, description)
  {
    // base variables are all done in the Activity base class      
  }

// ### METHODS ############################################## //
  // getter method to get the _reflectionName
  public string GetReflectionName() 
  {
    return _reflectionName;
  }

  // getter method to get the _reflectionDescription
  public string GetReflectionDescription()
  { 
    return _reflectionDescription;
  } 

  // method to get a random prompt
  public string RandomPrompt()
  {
    // set a variable to hold the _promptList count
    int count = _promptList.Count;
    // create a Random object for selecting the index #
    Random _randomIndexSelector = new Random();
    // randomly select a number to represent a list index
    int indexSelector = _randomIndexSelector.Next(0, count);    
    // return the prompt with that index from the _promptList
    return _promptList[indexSelector];
  } 

   // method to get a random question
  public string RandomQuestion()
  {
    // set a variable to hold the _questionList count
    int count = _questionList.Count;
    // create a Random object for selecting the index #
    Random _randomIndexSelector = new Random();
    // randomly select a number to represent a list index
    int indexSelector = _randomIndexSelector.Next(0, count);    
    // return the prompt with that index
    return _questionList [indexSelector];
  } 

  // method to help the user to prompt to use the prompt
  public void PrepareExercises()
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
    // display a count and clock spinner for a countdown
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
    // display a count and clock spinner for a countdown
    Spinner(ConsoleColor.Green, ConsoleColor.DarkGreen, 15); 
    // set the _spinnerSymbols list to the original contents    
    SetSpinnerSymbols(true, clonedList);    
  }
}