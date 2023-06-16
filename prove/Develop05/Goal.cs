using System;
using System.IO;
using System.Reflection;

// ### CLASS ################################################ //
// base class for goals
public class Goal
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // variable to hold the goal type
  private string _goalTitle;
  // variable to hold the goal's decription
  private string _description;
  // variable to hold the value in points assigned to a goal
  private int _points;
  // variable to hold the value in earned points for the user
  private int _earnedPoints;
  // variable to hold a list of goals
  private List<Goal> _goalList = new List<Goal>();
  // varialbe to hold the filename for saving goals to a textfile
  private string _filename;  
  // variable to hold the string of attributes retrieved from a textfile  
  private string _attributes;
  // list to hold the goal objects retrieved from a textfile
  private List<Goal> _retrievedObjects = new List<Goal>();

// ### CONSTRUCTORS ######################################### //
// constructor to be able to use the Goal methods
  public Goal()
  {
    // nothing needed in here 
  }

  // constructor that sets the _goalTitle and goal _description on initiation
  public Goal(string goalTitle, string description)
  {    
    // set the _goalTitle to what is passed in
    _goalTitle = goalTitle;
    // set the _description to what is passed in
    _description = description;    
    // create user prompt for setting the points associated with this goal & save it in a variable
    string pointsPrompt = "How many points would you like this goal to be worth? ";
    // create a validator object to run its method with
    // and pass the prompt question into the object
    Validator validator = new Validator(pointsPrompt);    
    // set the _points equal to the int number the StringNumberCheck method returns
    _points = validator.StringNumberCheck();   
    // set _earnedPoints as 0
    _earnedPoints = 0;
  }

// ### METHODS ############################################## //
  // setter method for the _points variable
  public void SetPoints(int points)
  {
    _points = points;
  }

  // getter method for the _points variable
  public int GetPoints()
  {
    return _points;
  }

  // method to display the points a user has earned
  public void DisplayPoints()
  { 
    // change the color of the text to yellow
    Console.ForegroundColor = ConsoleColor.Yellow;
    // give the user a lead in statement for how many points they have with empty line before
    Console.Write("\nYour earned points score is:");
    // change the color of the text to dark blue
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    // display special characters before the point total
    Console.Write($" {Convert.ToChar(183)}:{Convert.ToChar(183)}  ");
    // change the text color back to the original settings
    Console.ResetColor();
    // change the background color for the space showing the amount of points
    Console.BackgroundColor = ConsoleColor.DarkBlue;
    // display points
    Console.Write($" {_earnedPoints} ");
    // reset the background color to original settings
    Console.ResetColor();
    // set text color to dark blue to put in the symbols
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    // display special characters after the point total
    Console.Write($"  {Convert.ToChar(183)}:{Convert.ToChar(183)}");
    // reset the text color to original settings
    Console.ResetColor();
    // add a new line and an empty space after the statement
    Console.WriteLine("\n"); 
  }

  // method to set the goal title
  public void SetGoalTitle(string goalTitle)
  {  
    // if user is setting it up pass in "userSets"   
    if (goalTitle == "userSets")
    {  
      // create user prompt for setting the goal title associated with this goal & save it in a variable
      string goalTitlePrompt = "What is the title for your goal? ";
      // create a validator object to run its method with
      // and pass the prompt question into the object
      Validator validator = new Validator(goalTitlePrompt);    
      // set the _goalTitle equal to the string the ConfirmEntry method returns
      _goalTitle = validator.ConfirmEntry(); 
    }
    // otherwise
    else
    {
      // set _goalTitle equal to what is passed in 
      _goalTitle = goalTitle;
    }
  }

  // method to get the goal title
  public string GetGoalTitle()
  {
    return _goalTitle;
  }

  // method to se the goal description
  public void SetDescription(string description)
  { 
    // if user is setting it up pass in "userSets" 
    if (description == "userSets")
    {  
      // create user prompt for setting the goal description associated with this goal & save it in a variable
      string descriptionPrompt = "Please enter a short description of your goal: ";
      // create a validator object to run its method with
      // and pass the prompt question into the object
      Validator validator = new Validator(descriptionPrompt);    
      // set the _description equal to the string the ConfirmEntry method returns
      _description = validator.ConfirmEntry();
    }
    // otherwise
    else
    {
      // set _description equal to what is passed in
      _description = description;
    } 
  }

  // method to get the goal description
  public string GetDescription()
  {
    return _description;
  }

  // method to add a goal to the list
  public void SetGoalList(Goal goal)
  {
    // add the goal to the list
    _goalList.Add(goal);
    // // debuggin code - found that the object creation had to be outside the while loop
    // Console.WriteLine($"The list count after adding the object is: {_goalList.Count}");
  }

  // getter method for the _goalList
  public List<Goal> GetGoalList()
  {
    return _goalList;
  }

  // setter method for the _filename variable
  public void SetFilename(string filenamePrompt)
  {      
    // create a validator object to run its method with
    // and pass the prompt question into the object
    Validator validator = new Validator(filenamePrompt);    
    // set a variable equal to the string the ConfirmEntry method returns with .txt on the end      
    _filename = $"{validator.ConfirmEntry()}.txt";
  }
  
  // setter method for the _attributes variable
  public void SetAttributes(string attributes)
  {
    _attributes = attributes;
  }
  
  // getter method for the _attributes variable
  public string GetAttributes()
  {
    return _attributes;
  }

  // getter method for the _retrievedObjects list
  public List<Goal> GetRetrievedObjects()
  {
    return _retrievedObjects;
  }

  // method to list out a goal
  public virtual string CreateListedGoal(int count)
  {           
    // list the goal for the user to see
    string listedGoal = $"{count}) [ ] {GetGoalTitle()} ({GetDescription()})";
    // return the listed goal string
    return listedGoal; 
  }

  // method to list all goals
  public void ListGoals()
  {    
    // change the color of the text to yellow
    Console.ForegroundColor = ConsoleColor.Yellow;
    // give an introductory statement
    Console.WriteLine("The goals you have set for yourself are:");    
    // create a variable to number the goals that are set 
    int count = 0;
    // // debuggin code - found that the object creation had to be outside the while loop
    // Console.WriteLine($"The list count after starting the ListGoals method is: {_goalList.Count}");
    // check to make sure the list isn't empty
    if (_goalList.Count > 0)
    {
      // change the color of the text to blue
      Console.ForegroundColor = ConsoleColor.Cyan;
      // list goals for the user to see
      foreach (Goal goal in _goalList)
      {
        // increment the count by 1 for each loop
        count ++;
        // list the goal for the user to see
        Console.WriteLine($"{goal.CreateListedGoal(count)}");
      }
      // reset the text color to the original settings
      Console.ResetColor();
    }
    // if it is empty 
    else
    {
      // change the color of the text to red
      Console.ForegroundColor = ConsoleColor.Red;
      // let the user know they have no goals set
      Console.WriteLine("You currently have no goals set at this time.");
      // reset the text color to original settings
      Console.ResetColor();
    }
  }

  // method to get the class name
  public virtual string GetGoalType()
  {
    // create an object of the class
    Goal goal = new Goal();
    // return type as a string
    return goal.GetType().ToString();
  }

  // method to create & return a goal string
  public virtual string CreateGoalText()
  {           
    // list the goal for the user to see
    string goalText = $"{GetGoalType()}:~|~{GetGoalTitle()}~|~{GetDescription()}~|~{GetPoints()}";
    // return the listed goal string
    return goalText; 
  }

  // method to save goals to a text file
  public void SaveGoals()
  {
    // after the _filename is set load any previous Goal objects saved under this filename
    LoadGoalList(); 
    // create a StreamWriter object to be able to write a textfile
    using (StreamWriter outputFile = new StreamWriter(_filename))
    {  
      // save this information to the textfile
      // Goal class and points earned
      outputFile.WriteLine($"Goal:~|~{_earnedPoints}");
      // OneOffGoal's: goal class, goal title, description, point value, done: true or false
      // HabitGoal's : goal class, goal title, description, point value
      // AccrualGoal's: goal class, goal title, description, point value, bonus point value, accrual number, times done
      foreach (Goal goal in _goalList)
      {
        
        // list the goal for the user to see
        outputFile.WriteLine($"{goal.CreateGoalText()}");
      }    
    }
  }

  // method to load a file of goal objects into a list
  public void SetRetrievedOjects()
  {    
    // double check if file exists 1st
    if (File.Exists(_filename))
    {
      // load all file entries to a string list    
      string[] entries = System.IO.File.ReadAllLines(_filename);
      // cycle through each entry
      foreach (string entry in entries)
      {
        // seperate the string into the object and its attributes using the colon
        string[] segments = entry.Split(":");  
        // reference source: https://codereview.stackexchange.com/questions/4174/better-way-to-create-objects-from-strings & https://learn.microsoft.com/en-us/dotnet/api/system.reflection.assembly.getexecutingassembly?view=net-7.0 & https://medium.com/knowledge-pills/what-is-getexecutingassembly-in-c-1d7830f38f85# & https://learn.microsoft.com/en-us/dotnet/api/system.reflection.assembly.createinstance?view=net-7.0 
        // #2 "as" Operator: https://www.geeksforgeeks.org/c-sharp-as-operator-keyword/
        // ### ALTERNATE OPTION: create Goal object from the string of the Goal base class or Goal derived classes
        // Goal goal = Assembly.GetExecutingAssembly().CreateInstance(segments[0]) as Goal;
        // reference source: #1 Casing: https://exceptionnotfound.net/csharp-in-simple-terms-3-casting-conversion-parsing-is-as-and-typeof/ 
        // #2 Activator.CreateInstance method: https://learn.microsoft.com/en-us/dotnet/api/System.Activator.Createinstance?view=net-7.0
        // #3 Type.GetType method: https://stackoverflow.com/questions/4876683/c-sharp-convert-dynamic-string-to-existing-class & https://learn.microsoft.com/en-us/dotnet/api/system.type.gettype?view=net-7.0
        // create a Goal object or instance from the string of the Goal base class or Goal derived classes
        Goal goal = (Goal)Activator.CreateInstance(Type.GetType(segments[0]));
        // store the attributes in the _attributes variable
        goal.SetAttributes(segments[1]);
        // load the object into the _retrievedOjects list
        _retrievedObjects.Add(goal);             
      }      
    }
    // if filename doesn't exist
    else
    {
      // let the user know that this file doesn't exist
      Console.Write("The filename ");
      // change the color of the text to green so the text stands out
      Console.ForegroundColor = ConsoleColor.Green;
      // reference source: https://reactgo.com/csharp-remove-last-n-characters-string/
      // show the user what they entered
      Console.Write($"{_filename.Remove(_filename.Length-4)}");     
      // reset the text color to the original settings
      Console.ResetColor();
      // let the user know that this file doesn't exist & to check their spelling
      Console.WriteLine(" does not exist. Please check the spelling of your filename.");
    }
  }

  // method to load _goalList with Goals from textfile
  public void LoadGoalList()
  {
    // retrieve goals objects from textfile
    SetRetrievedOjects();
    // cycle through the _retrievedObjects list
    foreach (Goal type in GetRetrievedObjects())
    {
      // fill the goal object attributes & put in __goalList
      type.DivideAttributes();
      // if the Goal object has a _goalTitle
      if (!string.IsNullOrEmpty(type.GetGoalTitle()))
      {
        // add the goal Goal object to the _goalList
        GetGoalList().Add(type);
      }
    }
  }

  // method to break up retrieved attribute into the different variables
  public virtual void DivideAttributes()
  {   
    // reference source: https://www.c-sharpcorner.com/UploadFile/mahesh/split-string-in-C-Sharp/#
    // split the attribute string by its "~|~" separator characters
    string[] attributes = GetAttributes().Split("~|~");
    // fill the _earnedPoints variable with the right hand side of the 1st split
    _earnedPoints = int.Parse(attributes[1]);    
  }
  
}