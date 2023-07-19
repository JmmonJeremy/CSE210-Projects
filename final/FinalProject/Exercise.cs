using System;
using System.IO;
using System.Reflection;

// ### CLASS ################################################ //
// base class for tracking an exercise
public class Exercise : Tracked
{
// ### VARIABLE ATTRIBUTES ################################## // 
  private DateOnly _date = DateOnly.FromDateTime(DateTime.Now);
  private string _exerciseName; 
  

// ### CONSTRUCTORS ######################################### // 
  // main constructor to set up a Exercise object with the user's inputs
  public Exercise() : base("exercise", "minutes")
  {    
    // uses base class to set up 
     // #1 USER SETS FOOD _name **************************************************
    string namePrompt = $"What is the name of the {_category}? ";    
    // pass the namePrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator = new Validator("Use prompt", namePrompt);    
    // with "Use prompt" set the method to to use the prompt the first time the method is used
    _exerciseName = validator.ConfirmEntry("Use prompt");
    // #2 USER SETS FOOD _portion ***************************************************
    string portionPrompt = $"How many {_unit} will you be exercising? ";    
    // pass the portionPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator1 = new Validator("Use prompt", portionPrompt);    
    // set the method to use the prompt the first time the method is used with "Use Prompt"
    // also set to use the ConfirmEntry method after validating number with "Do ConfirmEntry"
    _portion = validator1.PosStringDecimalCheck("Use prompt", "Do ConfirmEntry");
    // #3 USER SETS FOOD _calories ***************************************************
    string caloriesPrompt = $"How many calories will you expend while exercising? ";    
    // pass the caloriesPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator2 = new Validator("Use prompt", caloriesPrompt);    
    // set the method to use the prompt the first time the method is used with "Use Prompt"
    // also set to use the ConfirmEntry method after validating number with "Do ConfirmEntry"
    _calories = validator2.PosStringNumberCheck("Use prompt", "Do ConfirmEntry", 0); 
  }

  // constructor for #1 the ClassToString method & #2 converting textfile to Exercise object
  public Exercise(string stringAttributes) : base (stringAttributes)
  {
    // #1 for ClassToString method do nothing to have an empty object set up
    // #2 for textfile to Exercise object uses DivideAttributes(stringAttributes) method, which
    // divides single string of attributes from a textfile into assigned individual attributes       
  }

// ### METHODS ############################################## //  
  // method to create a user selection string
  public override string CreateDisplayString(int count, string numberMarker, string alternate)
  {
    string space = "  ";
    if (count > 9)
    {
      space = " ";
    }
    string selectionString = $"   {count}{numberMarker}{space}{_exerciseName} ({GetType()}) ";  
    selectionString += base.CreateDisplayString(count, ".", "normal");
    selectionString += $" ~ Added on {_date.ToLongDateString()}";     
    return selectionString;
  }

// START OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES
  // method to create & return a exercise text string
  public override string CreateObjectString()
  {     
    string exerciseString = base.CreateObjectString();     
    exerciseString += $"~|~{_exerciseName}~|~{_date.Year}~|~{_date.Month}~|~{_date.Day}";        
    return exerciseString; 
  }
// END OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES

// START OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR
  // method to divide the string attributes stirng into their object's variable attributes  
  protected override void DivideAttributes(string stringAttributes)
  {   
    // reference source: https://stackoverflow.com/questions/36911460/adding-to-virtual-function-in-derived-class
    base.DivideAttributes(stringAttributes); 
    string[] attributes = stringAttributes.Split("~|~");
    _exerciseName = attributes[4];
    _date = new DateOnly(int.Parse(attributes[5]), int.Parse(attributes[6]), int.Parse(attributes[7]));     
  }
// END OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR

  // method to list the exercises and have the user add the Exercise object to the exercise storage List
  public Tracked AddToExerciseList()
  {  
    Tracked exercise;   
    string exerciseSelectionPrompt = "Which of the following exercises did you do?\nMake your selection by entering a number:\n";       
    SelectionTracker exercises = new SelectionTracker();
    exercises.TextfileToOjects("exercises.txt"); // load the list with the saved exercise in textfile
    int selection = exercises.SelectObject(exerciseSelectionPrompt, "exercise", "   ");
    if (selection == -1) // if the user chose the food needs to be added
    {
      // do something to help the user be able to add the food item 
      exercise = new Tracked("exercise", "minutes");;     
    }
    else
    {
      exercise = exercises.ReturnObject(selection);
      
    }
    return exercise;
  }

  public DateOnly GetDate()
  {
    return _date;
  }

    // method to create a user display string
  public string CreateCompletedString(int count, string numberMarker)
  {       
    string space = "  ";
    if (count > 9)
    {
      space = " ";
    }
    string selectionString = $"   {count}{numberMarker}{space}{_exerciseName} ({GetType()}) ";  
    selectionString += base.CreateDisplayString(count, ".", "normal");
    selectionString += $" ~ Recorded as Done.";     
    return selectionString;
  }
}