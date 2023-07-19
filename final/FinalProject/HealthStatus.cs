using System;
using System.IO;
using System.Reflection;

// ### CLASS ################################################ //
// class to hold the health status statistics
public class HealthStatus : Tracked
{
// ### VARIABLE ATTRIBUTES ################################## // 
  private Tracker tracker = new Tracker(); 
  private DateTime _date; 
  private int _minutes;   
  private float _bmi; 
  private float _weight; 
  private int _height;  
  private List<HealthStatus> _finalValues = new List<HealthStatus>();
  
// ### CONSTRUCTORS ######################################### //
  // main constructor to set up a Food object with the user's inputs used in Menu class
  public HealthStatus(string category, string unit) :base (category, unit)
  {      
    if (category == "intake")
    {
      SetStat("No prompt", "intake", 11); 
    }    
    if (category == "weight")
    {
      SetStat("Please enter your weight in pounds: ", "_weight", 11);
      LoadHeight();  
      SetStat("No prompt", "_bmi", 11);      
    } 
    if (category == "exercise")
    {
      SetStat("No prompt", "_minutes", 11); 
    }     
  }  

  // constructor for converting textfile to Food object in Tracker Class & for the ClassToString method in derived classes
  public HealthStatus(string stringAttributes) : base(stringAttributes)
  {
    if (stringAttributes == "Set up empty")
    {      
      // do nothing to have an empty object set up
    }
    else
    {      
      // divides single string of attributes from a textfile into assigned individual attributes
      DivideAttributes(stringAttributes); 
    }
  }

// ### METHODS ############################################## //
 // method to create a user display string
  public override string CreateDisplayString(int count, string numberMarker, string alternate)
  {       
    string space = "  ";
    if (count > 9)
    {
      space = " ";
    }   
    // source reference: https://www.educative.io/answers/how-to-capitalize-the-first-letter-of-a-string-in-c-sharp
    string displayString = $"{count}{numberMarker}{space} ({char.ToUpper(_category[0]) + _category.Substring(1)}): Date = {_date} Height = {_height}, Weight = {_weight} lbs, BMI = {_bmi}, calories = {_calories}, unit = {_unit}, portion = {_portion}";          
    return displayString;
  }

// START OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES
  // method to create & return a food text string
  public override string CreateObjectString()
  {           
    string foodString = $"{GetType()}:|:{_category}=|={_portion}=|={_calories}=|={_unit}=|={_height}=|={_weight}=|={_bmi}=|={_date}";        
    return foodString; 
  }
// END OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES

// START OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR
  // method to divide the string attributes stirng into their object's variable attributes  
  protected override void DivideAttributes(string stringAttributes)
  {            
    string[] attributes = stringAttributes.Split("=|="); 
    _category = attributes[0];
    _portion = float.Parse(attributes[1]);
    _calories = int.Parse(attributes[2]); 
    _unit = attributes[3];     
    _height = int.Parse(attributes[4]);     
    _weight = float.Parse(attributes[5]);
    _bmi = float.Parse(attributes[6]);    
    _date = DateTime.Parse(attributes[7]);     
  }
// END OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR

  // method to check if variable is null or empty
  private string ConditionallyChangeValue(string date, string original, string savedValue)
  {    
    if ((_date < DateTime.Parse(date) || string.IsNullOrEmpty(original)) && float.Parse(savedValue) != 0)
    {
      original = savedValue;
    }
    return original;
  }
  
  // method to save newly created HealthStatus object to a text file
  public void SaveToTextfile(string filename) 
  {      
    using (StreamWriter outputFile = new StreamWriter(filename))
    {        
      outputFile.WriteLine(CreateObjectString());
    }
  }
// END OF GROUPING OF 1 METHOD THAT CONVERTS ATTRIBUTES TO A TEXTFILE STRING

// START OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO ATTRIBUTE VALUES
  // method to load a HealthStatus object's attributes from a text file string
  public void LoadAttributes(string filename)
  {   
      // #1 SET UP NEEDED VARIABLES **********************************************************
      DateTime mostRecent = DateTime.Parse("01/01/2000"); // to find most recent date
      List<HealthStatus> recentEntries = new List<HealthStatus>(); // to hold most recent entry      
      HealthStatus healthy = new HealthStatus("Set up empty");      
      HealthStatusTracker heightTracker = new HealthStatusTracker();             
      heightTracker.TextfileToOjects("healthTrackerHistory.txt"); // put textfile into a list    
      // #2 ASSIGN LATEST VALUE TO _height ****************************************************
      foreach (HealthStatus item in heightTracker.GetItems())  //ITEM
      {
        if (item._height != 0) // create list with no nonvalues
        {
          recentEntries.Add(item);
        }
      }
      foreach (HealthStatus item1 in recentEntries)  //ITEM1
      {           
        if (mostRecent < item1.GetDate()) // assign latest date with a _height value
        {          
          mostRecent = item1.GetDate();
        }      
      }       
       foreach (HealthStatus item2 in heightTracker.GetItems())  //ITEM2
      {
        if (item2.GetDate() != mostRecent) // remove all but latest entry
        {        
          recentEntries.Remove(item2);
        }
      }
      _height = recentEntries.Last()._height;       
      healthy._height = recentEntries.Last()._height; 
      mostRecent = DateTime.Parse("01/01/2000"); // reset date
      recentEntries.Clear(); // reset list
      // Console.WriteLine($"_height = {_height}, list length = {recentEntries.Count}");
      // #3 ASSIGN LATEST VALUE TO _weight ****************************************************
      foreach (HealthStatus item3 in heightTracker.GetItems())  //ITEM3
      {
        if (item3._weight != 0) // create list with no nonvalues
        {
          recentEntries.Add(item3);
        }
      }
      foreach (HealthStatus item4 in recentEntries)  //ITEM4
      {           
        if (mostRecent < item4.GetDate()) // assign latest date with a _weight value
        {          
          mostRecent = item4.GetDate();
        }      
      }    
      foreach (HealthStatus item5 in heightTracker.GetItems())  //ITEM5
      {       
        if (item5.GetDate() != mostRecent)
        {        
          recentEntries.Remove(item5);
        }
      }
      _weight = recentEntries.Last()._weight;       
      healthy._weight = recentEntries.Last()._weight;
      mostRecent = DateTime.Parse("01/01/2000"); // reset date
      recentEntries.Clear(); // reset list
      // Console.WriteLine($"_weight = {_weight}, list length = {recentEntries.Count}");
      // #4 ASSIGN LATEST VALUE TO _calories ****************************************************
      foreach (HealthStatus item6 in heightTracker.GetItems())  //ITEM6
      {
        if (item6._calories != 0) // create list with no nonvalues
        {
          recentEntries.Add(item6);
        }
      }

      foreach (HealthStatus item7 in recentEntries) //ITEM7
      {           
        if (mostRecent < item7.GetDate()) // assign latest date with a _weight value
        {          
          mostRecent = item7.GetDate();
        }      
      }    
      foreach (HealthStatus item8 in heightTracker.GetItems())  //ITEM8
      {   
        
        DateTime date1 = item8.GetDate();
        DateTime date2 = mostRecent;
        string dateOnly1 = date1.ToShortDateString();
        string dateOnly2 = date2.ToShortDateString();        
        if (dateOnly1 != dateOnly2)
        {                 
          recentEntries.Remove(item8);
        }
      }
      if (recentEntries.Count > 0)
      {    
        _calories = 0;        
        int count = 0;
        foreach(HealthStatus calorie in recentEntries)
        {
          count ++;
          _calories = _calories + calorie._calories;           
        }
      }         
      healthy._calories = _calories;
      mostRecent = DateTime.Parse("01/01/2000"); // reset date
      recentEntries.Clear(); // reset list
      // Console.WriteLine($"_calories = {_calories}, list length = {recentEntries.Count}");
       // #5 ASSIGN LATEST VALUE TO _bmi ****************************************************     
      _bmi = (float)Math.Round(_weight / Math.Pow(_height, 2.0) * 703, 2);
      mostRecent = DateTime.Parse("01/01/2000"); // reset date
      recentEntries.Clear(); // reset list
      // Console.WriteLine($"_bmi = {_bmi}, list length = {recentEntries.Count}");
      // healthy.SaveToTextfile("healthTracker.txt");
      // DivideAttributes(attributes); 
  }
// END OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO ATTRIBUTE VALUES

  private void SetStat(string statPrompt, string attribute, int displayWidth)
  { 
    float stat = 0; 
    if (statPrompt != "No prompt")
    {  
    // #1 USER SETS STAT ********************************************************************      
    // pass the statPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator2 = new Validator("Use prompt", statPrompt);    
    // set the method to use the prompt the first time the method is used with "Use Prompt"
    // also set to use the ConfirmEntry method after validating number with "Do ConfirmEntry"
    stat = validator2.PosStringDecimalCheck("Use prompt", "Don't ConfirmEntry");   
    }
    // #2 ASSIGN VALUE GIVEN TO CORRESPONDING ATTRIBUTE *************************************    
    switch (attribute)
    {
      // RUN OPTION USER CHOSE
      case "intake": // if they chose "Record Height" 
        DateOnly mostRecent = DateOnly.Parse("01/01/2000");       
        tracker.TextfileToOjects("Jeremys_MealRecord.txt"); 
        foreach (Meal meal1 in tracker.GetItems())
        {
          // mostRecent = meal1.GetDateOnly();
          // break;
          if(mostRecent < meal1.GetDateOnly())
          {
            mostRecent = meal1.GetDateOnly();
          }
        }      
        foreach (Meal meal1 in tracker.GetItems())
        {
          if(mostRecent < meal1.GetDateOnly())
          {
            mostRecent = meal1.GetDateOnly();
          }
          if (meal1.GetDateOnly() == DateOnly.FromDateTime(DateTime.Now))
          {
            // _date = meal1.GetDateOnly().ToDateTime(TimeOnly.Parse("12:00:00 AM"));
            string date = meal1.GetDateOnly().ToString();
            _date = DateTime.Parse(date);
            // Console.WriteLine($"The date meal was created is {date}");
            _calories += meal1.GetCalories();
          }
        }
        if (_calories == 0)
        {          
          foreach (Meal meal2 in tracker.GetItems())
          {
            if (meal2.GetDateOnly() == mostRecent)
          {
            // _date = meal2.GetDateOnly().ToDateTime(TimeOnly.Parse("12:00:00 AM"));
            string date = meal2.GetDateOnly().ToString();
            _date = DateTime.Parse(date);
            // Console.WriteLine($"The date is {date}");
            _calories += meal2.GetCalories();
          }
          }  
        }
        // Console.WriteLine($"_calories = {_calories}");     
        break;
      case "_height": // if they chose "Record Height"        
        _height = (int)stat;     
        break;
      case "_weight": // if they chose "Record Height"        
        _weight = stat; 
        break;
      case "_bmi": // if they chose "Record Height"  
        _bmi = (float)Math.Round(_weight / Math.Pow(_height, 2.0) * 703, 2);       
        // Console.WriteLine($"_weight = {_weight} _height = {_height} bmi = {_bmi}");      
        break;
      case "_exercise": // if they chose "Record Height"        
        _ = stat; 
        break;       
    }   
  } 

  private string CreateStatString(float stat, string statAddOn, int displayWidth)
  {      
    int statWidth = (stat.ToString() + statAddOn).Count();
    // Console.WriteLine($"The statWidth is: {statWidth}");
    int startSpaceNumber = (int)Math.Floor((Decimal)(displayWidth - statWidth) / 2);
    // Console.WriteLine($"The startSpaceNumber is: {startSpaceNumber}");
    int endSpaceNumber = (int)Math.Ceiling((Decimal)(displayWidth - statWidth) / 2);
    // Console.WriteLine($"The endSpaceNumber is: {endSpaceNumber}");
    string startSpace = new string(' ', startSpaceNumber);
    string endSpace = new string(' ', endSpaceNumber);
    string statString = $"{startSpace}{stat}{statAddOn}{endSpace}";
    return statString;
  }
  // method to figure out cup value of the food
  public void PortionTotal()
  {
    
  }

  public void CalorieTotal()
  {

  }

  public string CreateHealthString()
  {
    string healthString = "";
    return healthString;
  } 

  public void StatsToTextfile(string filename)
  {

  }

  public void TextfileToAttributes(string filename)
  {

  }
 
  // method to display a Health Dashboard
  public void HealthDashboard()
  {  
    // (BMI) reference source: https://www.cdc.gov/healthyweight/assessing/bmi/adult_bmi/index.html
    // (Calories) reference source: https://health.clevelandclinic.org/how-many-calories-a-day-should-i-eat/#
    // (Exercise) reference source: https://www.cdc.gov/physicalactivity/basics/adults/index.htm
    // reference source: https://myxperiencefitness.com/7-ways-besides-weight-to-gauge-your-health/
    LoadAttributes("healthTrackerHistory.txt");
    CreateSectionTitles();    
    CreateBoardTop();
    CreateBoardSides(); 
    // LINE #1 OF HEALTH DASHBOARD
    DisplayMeasuredStats("Weight:       ", " Between 149 - 163 Pounds ", "   ", CreateStatString(_weight, " lbs", 11));    
    DisplayDoingStats("Calories:     ", "   Between 1600 - 3000    ", "   ", CreateStatString(_calories, "", 11)); 
    CreateBoardSides(); 
    // LINE #2 OF HEALTH DASHBOARD
    DisplayMeasuredStats("BMI:          ", "   Between 18.5 - 24.9    ", "   ", CreateStatString(_bmi, "", 11));    
    DisplayDoingStats("Exercise:     ", "  150 Minutes Cardio/Week ", "   ", "  30 Min   ");
    CreateBoardSides();  
    CreateBoardSides(); 
    CreateBoardBottom(); 
    // reference source: https://my.clevelandclinic.org/health/articles/11920-cholesterol-numbers-what-do-they-mean
    // reference source: mayoclinic.org/healthy-lifestyle/nutrition-and-healthy-eating/in-depth/water/art-20044256
    // reference source: https://www.myplate.gov/eat-healthy/fruits
    // reference source: https://www.myplate.gov/eat-healthy/vegetables
    // reference source: https://www.cdc.gov/bloodpressure/about.htm#
  }
  
  // method to display the text for the measurement stats
  private void DisplayMeasuredStats(string category, string standard, string space, string stat)
  {  
    Console.ForegroundColor = ConsoleColor.DarkGray;  Console.Write("  |");     
    Console.ForegroundColor = ConsoleColor.Yellow;    Console.Write(category); Console.ResetColor();    
    Console.BackgroundColor = ConsoleColor.DarkGray;  Console.Write(standard); 
    Console.ResetColor();                             Console.Write(space);  
    Console.BackgroundColor = ConsoleColor.DarkGray;  Console.Write(stat);   
    Console.ResetColor();                             Console.Write("       "); 
  }

  // method to display the text for the doing stats
  private void DisplayDoingStats(string category, string standard, string space, string stat)
  {          
    Console.ForegroundColor = ConsoleColor.Yellow;    Console.Write(category); Console.ResetColor();   
    Console.BackgroundColor = ConsoleColor.DarkGray;  Console.Write(standard);    
    Console.ResetColor();                             Console.Write(space);     
    Console.BackgroundColor = ConsoleColor.DarkGray;  Console.Write(stat); Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.DarkGray;  Console.WriteLine("| "); Console.ResetColor();
  }

  // method to create title sections for the HealthDashboard
  private void CreateSectionTitles()
  {
    Console.WriteLine("\n\n");
    Console.ForegroundColor = ConsoleColor.Cyan;     Console.Write(":");
    Console.BackgroundColor = ConsoleColor.DarkBlue; Console.Write("  Category   ");    
                                                     Console.Write($"{Convert.ToChar(183)}:{Convert.ToChar(183)}");
                                                     Console.Write($"          Healthy         ");
                                                     Console.Write($"{Convert.ToChar(183)}:{Convert.ToChar(183)}");
                                                     Console.Write($" Last Entry  ");
                                                     Console.Write($"{Convert.ToChar(183)}:{Convert.ToChar(183)}");
                                                     Console.Write("  Category  ");    
                                                     Console.Write($"{Convert.ToChar(183)}:{Convert.ToChar(183)}");
                                                     Console.Write($"          Healthy          ");
                                                     Console.Write($"{Convert.ToChar(183)}:{Convert.ToChar(183)}");
                                                     Console.Write($" Last Entry  "); Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Cyan;     Console.WriteLine(":"); Console.ResetColor();
  }

  // method to create the top of the Health Dashboard
  private void CreateBoardTop()
  {  
    string line = new string('_', 57);    
    string space = new string(' ', 58);    
    Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($" {line}#_#_#{line} ");
    Console.WriteLine($"|{space}\\|/{space}|") ; Console.ResetColor(); 
  }

  // method to create the sides of the Health Dashboard
  private void CreateBoardSides()
  {
    string space = new string(' ', 59); 
    Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($"|{space}|{space}|");
    Console.ResetColor();
  }

  // method to create the bottom of the Health Dashboard
  private void CreateBoardBottom()
  {  
    string line = new string('_', 58);
    string topLine = new string('\u0304', 57); 
    Console.ForegroundColor = ConsoleColor.Cyan;       
    Console.WriteLine($"|{line}/|\\{line}|");
    CreateScrollLine("");   
    Console.ResetColor(); Console.WriteLine(); 
  }

  // method to recreate the scroll line at the bottom of the Health Dashboard 
  public void CreateScrollLine(string spacing)
  {
    // reference source: https://stackoverflow.com/questions/26661670/overline-in-console-programming 
    // & https://en.wikipedia.org/wiki/Overline & https://stackoverflow.com/questions/411752/best-way-to-repeat-a-character-in-c-sharp
    Console.Write(spacing);
    string topLine = new string('\u0304', 57); 
    Console.ForegroundColor = ConsoleColor.Cyan; 
    Console.WriteLine($"{Convert.ToChar(186)}{topLine}*\u0304*\u0304*{topLine}{Convert.ToChar(186)}");    
    Console.ResetColor(); Console.WriteLine();
  }

  public DateTime GetDate()
  {
    return _date;
  }

  public void LoadHeight()
  {
     // #1 SET UP NEEDED VARIABLES **********************************************************
      DateTime mostRecent = DateTime.Parse("01/01/2000"); // to find most recent date
      List<HealthStatus> recentEntries = new List<HealthStatus>(); // to hold most recent entry      
      HealthStatus healthy = new HealthStatus("Set up empty");      
      HealthStatusTracker heightTracker = new HealthStatusTracker();             
      heightTracker.TextfileToOjects("healthTrackerHistory.txt"); // put textfile into a list    
      // #2 ASSIGN LATEST VALUE TO _height ****************************************************
      foreach (HealthStatus item in heightTracker.GetItems())  //ITEM
      {
        if (item._height != 0) // create list with no nonvalues
        {
          recentEntries.Add(item);
        }
      }
      foreach (HealthStatus item1 in recentEntries)  //ITEM1
      {           
        if (mostRecent < item1.GetDate()) // assign latest date with a _height value
        {          
          mostRecent = item1.GetDate();
        }      
      }       
       foreach (HealthStatus item2 in heightTracker.GetItems())  //ITEM2
      {
        if (item2.GetDate() != mostRecent) // remove all but latest entry
        {        
          recentEntries.Remove(item2);
        }
      }
      _height = recentEntries.Last()._height;       
      healthy._height = recentEntries.Last()._height;     
  }
}
