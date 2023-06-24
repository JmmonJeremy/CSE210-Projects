using System;
using System.IO;

// ### CLASS ################################################ //
// class for one-off goals
public class OneOffGoal : Goal
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // variable 
  

// ### CONSTRUCTORS ######################################### //
  // constructor used to return goals saved to a textfile by
  // creating an OneOffGoal object in the GetGoalType method  
  public OneOffGoal()
  {
    // nothing needed in here 
  }

  // constructor to pass in the goal title and description from the user
  public OneOffGoal(string goalTitle, string description) : base(goalTitle, description)
  {    
    // this is all done in the base class
  }
// ### METHODS ############################################## //
  // method to communicate goal creation to the user
  public override void CommunicateGoalCreation()
  {
    // COMMUNICATE IN COLOR TO THE USER THE CREATION OF A GOAL
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    // let the user know their goal has been created
    Console.Write("\nThe ");
    // change the color of the text to purple so the word goal stands out
    Console.ForegroundColor = ConsoleColor.Magenta;
    // reference source: https://www.techiedelight.com/remove-n-characters-from-end-string-csharp/
    // save goal type into a string variable
    string goalType = GetGoalType().Substring(0, GetGoalType().Length - 4).ToLower();
    // reference source: https://www.educative.io/answers/how-to-insert-one-string-into-another-using-insert-in-c-sharp
    // put a dash between one and off for that type
    goalType = goalType.Insert(3, "-");
    // let the user know their goal has been created
    Console.Write($"{goalType} goal ");
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    // let the user know their goal has been created
    Console.Write("entitled ");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // change the color of the text to purple so the goal title stands out
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write(GetGoalTitle());
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write(" has been ");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // change the color of the text to purple so created stands out
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write("created");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'"); 
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write(" for you with the total point value of ");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // change the color of the text to purple so the point total stands out
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write($"{GetPoints()} points");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(".");
    // reset the text color to the original settings
    Console.ResetColor();   
  } 

  // method to get the class name
  public override string GetGoalType()
  {
    // create an object of the class
    OneOffGoal oneOff = new OneOffGoal();
    // return type as a string
    return oneOff.GetType().ToString();
  }

  // method to break up retrieved attribute into the different variables
  public override void DivideAttributes()
  {   
    // reference source: https://www.c-sharpcorner.com/UploadFile/mahesh/split-string-in-C-Sharp/#
    // split the attribute string by its "~|~" separator characters
    // ~|~goal title~|~description~|~point value~|~goal completed: true or false
    string[] attributes = GetAttributes().Split("~|~");
    // fill the _completedBox variable with the 1st string value in the list
    SetCompletedBox(attributes[0]);
    // fill the _goalTitle variable with the next string from the split
    SetGoalTitle(attributes[1]);
    // fill the _description variable with the next string from the split
    SetDescription(attributes[2]);
    // fill the _points variable with the next string from the split converted to an int
    SetPoints(int.Parse(attributes[3]));
    // reference source: https://stackoverflow.com/questions/49590754/convert-a-string-to-a-boolean-in-c-sharp
    // fill the _goalCompleted boolean with the next string from the split converted to a bool
    SetGoalCompleted(bool.Parse(attributes[4])); 
    // fill the _filename with the last string from the split
    SetFilename(attributes[5]);       
  }

  // method to communicate goal recording to user
  public override void CommunicateGoalRecording(bool did)
  {
    // create variable inserts for incompletion of goal
    string complete = "been marked as complete ";
    string earning = " for you, earning you ";
    string completionBox = "[X]";
    // change the string values if the did bool is false
    if (!did)
    {
      complete = "accounted for your noncompletion report ";
      earning = " causing a deduction for you of ";
      completionBox = "[ ]";
    }
    // COMMUNICATE IN COLOR TO THE USER THE COMPLETION or NONCOMPLETION OF A GOAL
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    // let the user know their goal has been created
    Console.Write("\nThe ");
    // change the color of the text to purple so the word goal stands out
    Console.ForegroundColor = ConsoleColor.Magenta;
    // reference source: https://www.techiedelight.com/remove-n-characters-from-end-string-csharp/
    // save goal type into a string variable
    string goalType = GetGoalType().Substring(0, GetGoalType().Length - 4).ToLower();
    // reference source: https://www.educative.io/answers/how-to-insert-one-string-into-another-using-insert-in-c-sharp
    // put a dash between one and off for that type
    goalType = goalType.Insert(3, "-");
    // let the user know their goal has been created
    Console.Write($"{goalType} goal ");
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    // let the user know their goal has been created
    Console.Write("entitled: ");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // change the color of the text to purple so the goal title stands out
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write(GetGoalTitle());
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write($", {Convert.ToChar(22)}{Convert.ToChar(16)}{Convert.ToChar(26)} has {complete}");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // change the color of the text to purple so the completion mark stand out
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write($"{completionBox}");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write(earning);
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // change the color of the text to purple so the points earned stand out
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write($"{GetPoints()} points total");
    // change the color of the text to yellow for the single quote mark
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("'");
    // change the color of the text to blue
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("!");
    // reset the text color to the original settings
    Console.ResetColor();  
  }

    // method to create listing for unfinished goals
  public override void CreateGoalTitleListing(int count)
  {
    // use this variable to space listings 1-9 different from 10 or greater
    string space = "  ";
    if (count > 9)
    {
      space = " ";
    } 
    // reference source: https://www.techiedelight.com/remove-n-characters-from-end-string-csharp/
    // save goal type into a string variable
    string goalType = GetGoalType().Substring(0, GetGoalType().Length - 4).ToLower();
    // reference source: https://www.educative.io/answers/how-to-insert-one-string-into-another-using-insert-in-c-sharp
    // put a dash between one and off for that type
    goalType = goalType.Insert(3, "-"); 
    // change the color of the text to blue so the goal type stands out
    Console.ForegroundColor = ConsoleColor.Yellow;  
    // list the goal with the _unfinishedNumber next to it
    Console.Write($"{count}){space}"); 
    // change the color of the text to purple so the goal type stands out
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write($"({goalType} goal) ");
    // change the color of the text to yellow so the goal title stands out
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"{GetGoalTitle()}");
    // reset the text color to original settings
    Console.ResetColor();
  }

  // method to turn the goal type into a string with
  // lower case letters that can be used in a sentence 
  public override string ConvertGoalType()
  {
    // reference source: https://www.techiedelight.com/remove-n-characters-from-end-string-csharp/
    // save goal type into a string variable
    string goalType = GetGoalType().Substring(0, GetGoalType().Length - 4).ToLower();
    // reference source: https://www.educative.io/answers/how-to-insert-one-string-into-another-using-insert-in-c-sharp
    // put a dash between one and off for that type & return it    
    return goalType.Insert(3, "-"); 
  } 
}