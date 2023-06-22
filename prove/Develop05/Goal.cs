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
  // variable to hold the unfinished goal number for user selection
  private int _unfinishedGoalNumber;
  // variable boolean to indicate if the goal has been accomplished
  private bool _goalCompleted;
  // variable to hold the check off box for a listed goal
  private string _completedBox;
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
  // constructor to be able to use the Goal methods in the Menu class
  // it is also used to return goals saved to a textfile by
  // creating an OneOffGoal object in the GetGoalType method
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
    // create a validator object to run its method with and
    // pass the prompt question into the object  & for the user's 
    // entry value put 'Use prompt' since user will change value after the prompt
    Validator validator2 = new Validator("Use prompt", pointsPrompt);    
    // set the _points equal to the int number the StringNumberCheck method returns
    // and set the method to use the prompt the first time the method is used with "Use Prompt"
    // also set to use the ConfirmEntry method after validating number with "Do ConfirmEntry"
    _points = validator2.StringNumberCheck("Use prompt", "Do ConfirmEntry");
    // set the _completedBox string value
    _completedBox = "[ ]";
    // set _earnedPoints as 0
    _earnedPoints = 0;
  }

// ### METHODS ############################################## //
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
      // create a validator object to run its method with and
      // pass the prompt question into the object  & for the user's 
      // entry value put 'Use prompt' since user will change value after the prompt
      Validator validator = new Validator("Use prompt", goalTitlePrompt);    
      // set the _goalTitle equal to the string the ConfirmEntry method returns and with
      // "Use prompt" set the method to to use the prompt the first time the method is used
      _goalTitle = validator.ConfirmEntry("Use prompt"); 
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

  // method to set the goal description
  public void SetDescription(string description)
  { 
    // if user is setting it up pass in "userSets" 
    if (description == "userSets")
    {  
      // create user prompt for setting the goal description associated with this goal & save it in a variable
      string descriptionPrompt = "Please enter a short description of your goal: ";
      // create a validator object to run its method with and
      // pass the prompt question into the object  & for the user's 
      // entry value put 'Use prompt' since user will change value after the prompt
      Validator validator = new Validator("Use prompt", descriptionPrompt);    
      // set the _description equal to the string the ConfirmEntry method returns and with
      // "Use prompt" set the method to to use the prompt the first time the method is used
      _description = validator.ConfirmEntry("Use prompt");
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

  // setter method for the _unfinishedGoalNumber
  public void SetUnfinishedGoalNumber(int unfinishedGoalNumber)
  {
    _unfinishedGoalNumber = unfinishedGoalNumber;
  }

  // getter method for the _unfinishedGoalNumber bool
  public int GetUnfinishedGoalNumber()
  {
    return _unfinishedGoalNumber;
  }

  // setter method for the _goalCompleted bool
  public void SetGoalCompleted(bool goalCompleted)
  {
    _goalCompleted = goalCompleted;
  }

  // getter method for the _goalCompleted bool
  public bool GetGoalCompleted()
  {
    return _goalCompleted;
  }

  // setter method for the _completed variable
  public void SetCompletedBox(string completedBox)
  {
    _completedBox = completedBox;    
  }

  // getter method for the _completed variable
  public string GetCompletedBox()
  {
    return _completedBox;    
  }

  // method to add a goal to the list
  public void SetGoalList(Goal goal)
  {
    // reference source: https://www.techiedelight.com/add-item-at-the-beginning-of-a-list-in-csharp/
    // add the goal to the beginning of the list
    _goalList.Insert(0, goal);
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
    // reference source: https://www.tutorialspoint.com/how-to-get-last-4-characters-from-string-in-chash
    // if the 'filenamePrompt' passed in doesn't end with .txt
    if (filenamePrompt.Substring(filenamePrompt.Length - 4) != ".txt") 
    {   
      // create a validator object to run its method with and
      // pass the prompt question into the object  & for the user's 
      // entry value put 'Use prompt' since user will change value after the prompt
      Validator validator = new Validator("Use prompt", filenamePrompt);    
      // set a variable equal to the string the ConfirmEntry method returns with .txt on the end 
      // and with "Use prompt" set the method to to use the prompt the first time the method is used
      _filename = $"{validator.ConfirmEntry("Use prompt")}.txt";
    }
    // if not prompting the user to set the _filename
    // identified by the filenamePrompt passed in ending with .txt
    else
    {
      // set _filename equal to what is passed in
      _filename = filenamePrompt;
    }
  }

  // getter method for the _filename variable
  public string GetFilename()
  {
    return _filename;
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

  // setter method to load a file of goal objects into a list
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
      // // debugging code to see what object were created and what the attributes saved were
      // foreach (Goal type in GetRetrievedObjects())
      // {
      //   Console.WriteLine($"The goal type is: {type.GetGoalType()}");
      //   Console.WriteLine($"The attributes are: {type.GetAttributes()}");
      // }
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

  // getter method for the _retrievedObjects list
  public List<Goal> GetRetrievedObjects()
  {
    return _retrievedObjects;
  }

  // method to get the class name
  public virtual string GetGoalType()
  {
    // create an object of the class
    Goal goal = new Goal();
    // return type as a string
    return goal.GetType().ToString();
  }

  // method to list out a goal
  public virtual string CreateListedGoal(int count)
  {   
    // use this variable to space listings 1-9 different from 10 or greater
    string space = "  ";
    if (count > 9)
    {
      space = " ";
    } 
    // list the goal for the user to see
    string listedGoal = $"{count}.{space}{GetCompletedBox()} {GetGoalTitle()} ({GetDescription()})";
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

  // method to create & return a goal string
  public virtual string CreateGoalText()
  {           
    // list the goal for the user to see
    string goalText = $"{GetGoalType()}:{GetCompletedBox()}~|~{GetGoalTitle()}~|~{GetDescription()}~|~{GetPoints()}~|~{GetGoalCompleted()}~|~{GetFilename()}";
    // return the listed goal string
    return goalText; 
  }

  // method to save goals to a text file
  public void SaveGoals()
  {           
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

  // method to load _goalList with Goals from textfile
  public void LoadGoalList()
  {
    // create a boolean to prevent loading the same goal multiple times
    bool duplicate = false;
    // retrieve goals objects from textfile
    SetRetrievedOjects();      
    // // debugging code for finding duplicates of goals when loading the list multiple time
    // Console.WriteLine($"The GoalList count in LoadGoalList before adding Goal object types to the GoalList is: {GetGoalList().Count}");
    // cycle through the _retrievedObjects list
    foreach (Goal type in GetRetrievedObjects())
    {
      // set duplicate to false to start each comparison
      duplicate = false;  
      // fill the goal object attributes and put in #1 Goal objects _earnedPoints & #2 _goalList
      type.DivideAttributes();
      // pass on the _earnedPoints value from the saved textfile 
      // to the current Goal objects's _earnedPoints variable
      _earnedPoints = GetRetrievedObjects()[0]._earnedPoints;
      // // debugging code to figure out how to pass on the __earnedPoints value
      // Console.WriteLine($"#1 The type in _divided attributes _earned points is: {type._earnedPoints}");
      // Console.WriteLine($"#2 The _earnedpoints is: {_earnedPoints}");
      // Console.WriteLine($"#3 The GetRetrievedObjects()[0] _earnedpoints is: {GetRetrievedObjects()[0]._earnedPoints}");
      // if the Goal object has a _goalTitle
      if (!string.IsNullOrEmpty(type.GetGoalTitle()))
      {          
        // cycle through the _goalList 
        foreach (Goal goal in _goalList) 
        {                           
          // if the type & goal objects have matching _goalTitle and _description 
          if (goal.GetGoalTitle() == type.GetGoalTitle() && goal.GetDescription() == type.GetDescription())
          {
            // identify them as a duplicate
            duplicate = true;
            // if the goals are the same but the _completionBox and _goalCompleted values are different
            if (goal.GetCompletedBox() != type.GetCompletedBox() && goal.GetGoalCompleted() != type.GetGoalCompleted()) 
            {              
              // reset the value of the _completedBox in the _goalList
              goal.SetCompletedBox(type.GetCompletedBox());
              // reset the value of the _goalCompleted bool value in the _goalList
              goal.SetGoalCompleted(type.GetGoalCompleted());
              // // debugging code to figure out how to pass on the _completeionBox & _goalCompleted values
              // Console.WriteLine($"The goal in _goalList completed box is: {goal.GetCompletedBox()}");
              // Console.WriteLine($"The type in _divided attributes completed box is: {type.GetCompletedBox()}");
              // debugging code to figure out how to pass on the __earnedPoints value
              // Console.WriteLine($"#3 The goal in _goalListearned points is: {goal._earnedPoints}");
              // Console.WriteLine($"#4 The type in _divided attributes _earned points is: {type._earnedPoints}");
            }            
          }
          // // debugging code to figure out how to pass on the __earnedPoints value
          // Console.WriteLine($"#5 The goal in _goalListearned points is: {goal._earnedPoints}");
          // Console.WriteLine($"#6 The type in _divided attributes _earnedpoints is: {type._earnedPoints}");
             
        }
        // if the _goalTitle and _description didn't have a match
        if (duplicate == false) 
        { 
        // add the goals or Goal objects from the textfile to the _goalList
        // unless they are already loaded into the _goalList
        GetGoalList().Add(type);
        }
      }        
    }
    // // debugging code for finding duplicates of goals when loading the list multiple time
    // Console.WriteLine($"The GoalList count in LoadGoalList after adding Goal object types to the GoalList is: {GetGoalList().Count}");
    
    // empty the _retrievedObjects list so it is empty if another list is loaded
    _retrievedObjects.Clear();
    // reference source: https://www.techiedelight.com/remove-elements-from-list-while-iterating-csharp/
    // create a list to remove goal objects with the wrong filename
    List<Goal> wrongList = new List<Goal>();
    // cycle through the _goalList 
    foreach (Goal goal in _goalList) 
    { 
    // if the filename in list doesn't match the loaded filename
    if (goal.GetFilename() != _filename) 
      {  
        // add that goal object to a list so it will be removed
        wrongList.Add(goal);
        // // debugging code for figuring out how to remove goal objects with different filenames
        // Console.WriteLine($"The _goalList filename is: {goal.GetFilename()}");
        // Console.WriteLine($"The loaded filename is: {_filename}");
      }
    } 
    // remove the goal objects with the wrong filename
    _goalList.RemoveAll(wrongList.Contains);
  }

  // method to break up retrieved attribute into the different variables
  public virtual void DivideAttributes()
  {   
    // reference source: https://www.c-sharpcorner.com/UploadFile/mahesh/split-string-in-C-Sharp/#
    // split the attribute string by its "~|~" separator characters
    string[] attributes = GetAttributes().Split("~|~");
    // fill the _earnedPoints variable with the right hand side of the 1st split
    _earnedPoints = int.Parse(attributes[1]); 
    // //debugging code to find why _earned point value wasn't being passed on
    // Console.WriteLine($"#0 The _earnedPoint value in DivideAttributes is: {_earnedPoints}"); 
  }  

  // method to list goals available to be marked as fully or partially completed
  public int ListUnfinishedGoals()
  {       
    // create a variable to show a number next to the goal
    int count = 0;
    // make sure there are goals in the list
    if (_goalList.Count > 0)
    {
      // change the color of the text to blue to have it stand out
        Console.ForegroundColor = ConsoleColor.Cyan;
      // tell the user you are listing the unfinished goals with an empty line before it
      Console.WriteLine("\nHere is a list of the goals you have not yet noted as complete:");
      // reset the text color to the original settings
      Console.ResetColor();
      // cycle through the list of Goal objects
      foreach (Goal goal in _goalList)
      {        
        // determine if the goal is completed or not
        if (!goal.GetGoalCompleted())
        {
          // increase count variable by 1 for each cycle
          count ++;
          // set the _unfinishedGoalNumber so to this number
          // so what the user enters will pick that goal
          goal.SetUnfinishedGoalNumber(count);
          // use this variable to space listings 1-9 different from 10 or greater
          string space = "  ";
          if (count > 9)
          {
            space = " ";
          }    
          // list the goal with the _unfinishedNumber next to it
          Console.WriteLine($"{goal.GetUnfinishedGoalNumber()}){space}{goal.GetGoalTitle()}");          
        }       
      }
      // if no goals in the list were uncompleted
      if (count == 0)
      {
      // put the cursor at the beginning of the line again to write over the first line title
      Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
      // change the color of the text to red to alert the user
      Console.ForegroundColor = ConsoleColor.Red;
      // let the user know there are no goals available to mark as complete add blank spaces to erase title
      Console.WriteLine("Sorry, there are no goals for you to record as complete.       ");
      // reset the text color to the original settings
      Console.ResetColor();
      // let the user know all goals they've entered are already completed
      Console.WriteLine("All of the goals you have entered are already marked as complete.");
      // let the user know what they need to do before they can record any goals as complete
      Console.WriteLine("You must create a new goal before you can record a goal as complete.");
      // end the menu option to it doesn't perform the other methods by returning 0
      return count;
      }
    }
    // if there are no goals
    else
    {
      // change the color of the text to red to alert the user
      Console.ForegroundColor = ConsoleColor.Red;
      // let the user know there are no goals available to mark as complete
      Console.WriteLine("Sorry, there are no goals for you to record as complete.");
      // reset the text color to the original settings
      Console.ResetColor();
      // let the user know the program shows no goals for them
      Console.WriteLine("You have no goals loaded into the program at this time.");
      // let the user know what they need to do before they can record any goals as complete
      Console.WriteLine("You must create a goal or load saved goals before you can record a goal as complete.");
      // end the menu option to it doesn't perform the other methods by returning 0
      return count;
    }
    // return a number > 0 to show there is a goal available to complete
    return count;
  }

  // method to make changes when recording goal completion
  public virtual void MarkComplete()
  {
    // mark the goal as completed in the _completedBox variable
    SetCompletedBox("[X]");
    // change the _goalCompleted bool to true
    SetGoalCompleted(true);    
  }

  // method to show when part or all of a goal has been completed
  public void NoteAccomplishment(int upperLimit)
  {      
    // create a variable to hold the user's goal selection
    string goalSelection = "";
    // only do if there is something listed to check off as done
    if (upperLimit > 0)
  {
      // create prompt asking the user which goal they want to check off
      // store prompt in a variable to pass into a Validator method
      string goalSelectionPrompt = "Select the goal to note its accomplishment by entering its number:\nSelection: ";
      // create a validator object to run its method with and
      // pass the prompt question into the object & for the user's 
      // entry value put 'Use prompt' since user will change value after the prompt
      Validator validator = new Validator("Use prompt", goalSelectionPrompt);    
      // using the SelectionCheck method get an entry that is confirmed and valid 
      goalSelection = validator.SelectionCheck(upperLimit);      
      // cycle through each goal object in the list
      foreach (Goal goal in _goalList)
      {
        // if the goal Selection matches a goal listed
        if (int.Parse(goalSelection) == goal.GetUnfinishedGoalNumber())
        {
          // mark the goal complete as appropriate for the goal object
          goal.MarkComplete();
          // add the _point value for this goal to the _earnedPoints value
          _earnedPoints += goal.GetPoints();
          // set the _unfinishedGoalNumber associated with the user's
          // selection to 0 so it won't accidentally be used again
          goal.SetUnfinishedGoalNumber(0);
        }
      }   
    }
  }  
}