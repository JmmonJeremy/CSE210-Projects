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
  private string _foodType;   
  private string _foodName;  
  private float _portionValue; 
  private string _portionScale; 
  private int _caloriesValue; 
  private string _attributes; 

  private string _userName;
  // reference source: https://www.cdc.gov/healthyweight/assessing/bmi/adult_bmi/index.html
  private string _bmiStandard = "Between 18.5 - 24.9";   
  public float _bmi; 
  private string _weightStandard = "Between 149 - 163 lbs"; 
  public float _weight; 
  public int _height; 
  // reference source: https://myxperiencefitness.com/7-ways-besides-weight-to-gauge-your-health/
  private string _waistToHipRatioStandard = "Below 0.95"; 
  private float _waistToHipRatio; 
  private float _waistCircumference;
  private float _hipCircumference;

  // reference source: https://www.cdc.gov/bloodpressure/about.htm#
  private string _bloodPressureStandard = "Below 120/80";
  private string _bloodPressure;
  private int _systolicPressure;
  private int _diastolicPressure;
  // reference source: https://my.clevelandclinic.org/health/articles/11920-cholesterol-numbers-what-do-they-mean
  private string _cholesterolLevelStandard = "Below 200";
  private int _cholesterolLevel;
  // reference source: https://www.myplate.gov/eat-healthy/fruits
  private string _fruitIntakeStandard = "Between 2 - 2.5 Cups a Day";
  private float _fruitIntake;
  // reference source: https://www.myplate.gov/eat-healthy/vegetables
  private string _veggieIntakeStandard = "Between 3 - 4 Cups a Day";
  private float _veggieIntake;
  // reference source: https://health.clevelandclinic.org/how-many-calories-a-day-should-i-eat/#
  private string _calorieStandard = "Between 1600 - 3000";
  private int _calorieGoal;
  private int _calorieTotal;
  // reference source: mayoclinic.org/healthy-lifestyle/nutrition-and-healthy-eating/in-depth/water/art-20044256
  private string _liquidIntakeStandard = "Between 11.5 - 15.5 Cups a Day";
  private float _liquidIntake;
  // reference source: https://www.cdc.gov/physicalactivity/basics/adults/index.htm
  private string _exerciseStandard = "150 Minutes of Cardio & 2 Days of Bodybuilding Weekly";
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
    _calories = int.Parse(ConditionallyChangeValue(attributes[7], _height.ToString(), attributes[2])); 
    _unit = attributes[3];     
    _height = int.Parse(ConditionallyChangeValue(attributes[7], _height.ToString(), attributes[4]));     
    _weight = float.Parse(ConditionallyChangeValue(attributes[7], _weight.ToString(), attributes[5]));
    _bmi = float.Parse(ConditionallyChangeValue(attributes[7], _weight.ToString(), attributes[6]));    
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

// START OF GROUPING OF 1 METHOD THAT CONVERTS ATTRIBUTES TO A TEXTFILE STRING
  // method to load attributes with the latest past recorded value
  private string LoadLatestPastValue(string attribute, string currentValue)
  { 
    // #1 ASSIGN LAST RECORDED VALUE TO CORRESPONDING ATTRIBUTE **********************************    
    int count = 0; // by-pass date if comparison on 1st cycle 
    float pastValue = 0; // use to see if value is 0
    string pastDate = ""; // use for date attribute
    string check = "number"; // send all variables to 2nd if statement except date     
    tracker.TextfileToOjects("healthTrackerHistory.txt");  
    foreach (HealthStatus past in tracker.GetItems())
    {           
      count++;     
      switch (attribute)
      {
        // GET AND ASSIGN CORRECT ATTRIBUTE
        case "intake":        
          pastValue = past._calories;    
          break;
        case "_date":        
          pastDate = past._date.ToString();
          check = "date";    
          break;
        case "_height":        
          pastValue = past._height;    
          break;
        case "_weight":      
          pastValue = past._weight;
          break; 
        case "_bmi":      
          pastValue = past._bmi;           
          break;
        default: // if they chose "Return to Main Menu"        
        break; // do nothing to end this menu & return user to the main menu
      } 
      // Console.WriteLine($"#{count}#{count}#{count} _date ({_date}) past._date ({past._date}) to the pastValue of ({pastValue})");
      if (check == "date")
      {
        if ((_date < past._date || string.IsNullOrEmpty(currentValue)|| count == 1) && pastDate != "1/1/0001 12:00:00 AM")
        {          
          currentValue = pastDate.ToString();
        }
      }        
      if (check == "number")
      {
        if ((_date < past._date || string.IsNullOrEmpty(currentValue) || count == 1) && pastValue != 0 && !string.IsNullOrEmpty(pastValue.ToString()))
        {       
          currentValue = pastValue.ToString();
        }        
      }    
    } 
    return currentValue;   
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
    
    // if (File.Exists(filename))
    // {        
    //   string[] items = System.IO.File.ReadAllLines(filename);      
    //   foreach (string item in items)
    //   {               
    //     // seperate the string into the object and its attributes using the colon
    //     string[] segments = item.Split(":|:"); 

    //     _calories = int.Parse((LoadLatestPastValue("intake", _calories.ToString())));       
              
    //     // Console.WriteLine($"BEFORE assigning value from LoadLatestPastValue _height = ({_height}).");
    //     _height = int.Parse((LoadLatestPastValue("_height", _height.ToString())));
    //     // Console.WriteLine($"AFTER assigning value from LoadLatestPastValue _height = ({_height}).");
                 
    //     _weight = float.Parse(LoadLatestPastValue("_weight", _weight.ToString())); 

    //     _bmi = float.Parse(LoadLatestPastValue("_bmi", _bmi.ToString())); 
        
    //     _date = DateTime.Parse(LoadLatestPastValue("_date", _date.ToString()));        
        
                      
      // } 
    // }   
      // #1 SET UP NEEDED VARIABLES **********************************************************
      DateTime mostRecent = DateTime.Parse("01/01/2000"); // to find most recent date
      List<HealthStatus> recentEntries = new List<HealthStatus>(); // to hold most recent entry
      
      HealthStatus healthy = new HealthStatus("Set up empty");      
      HealthStatusTracker heightTracker = new HealthStatusTracker();             
      heightTracker.TextfileToOjects("healthTrackerHistory.txt"); // put textfile into a list    
      // #1 ASSIGN LATEST VALUE TO _height ****************************************************
      foreach (HealthStatus item1 in heightTracker.GetItems())
      {
        if (item1._height != 0) // create list with no nonvalues
        {
          recentEntries.Add(item1);
        }
      }
      foreach (HealthStatus item in recentEntries) // assign latest date
      {       
        if (mostRecent < item.GetDate())
        {
          mostRecent = item.GetDate();
        }      
      }  
       foreach (HealthStatus item2 in heightTracker.GetItems()) // remove all but latest entry
      {
        if (item2.GetDate() != mostRecent)
        {        
          recentEntries.Remove(item2);
        }
      }
      _height = recentEntries.Last()._height; // assign value to attribute      
      healthy._height = recentEntries.Last()._height;
      _finalValues.Add(healthy);
      Console.WriteLine($"_height = {_height}, list length = {recentEntries.Count}");


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
    // Console.WriteLine(stat);
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
            Console.WriteLine($"The date meal was created is {date}");
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
            Console.WriteLine($"The date is {date}");
            _calories += meal2.GetCalories();
          }
          }  
        }
        Console.WriteLine($"_calories = {_calories}");     
        break;
      case "_height": // if they chose "Record Height"        
        _height = (int)stat;     
        break;
      case "_weight": // if they chose "Record Height"        
        _weight = stat; 
        _bmi = (float)(_weight / Math.Pow(_height, 2.0) * 703);
        Console.WriteLine($"_weight = {_weight} _height = {_height} bmi = {_bmi}");         
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
    LoadAttributes("healthTracker.txt");
    Console.WriteLine($"The _date is {_date}");
    Console.WriteLine($"The _height is {_height}");
    CreateSectionTitles();    
    CreateBoardTop();
    CreateBoardSides(); 
    // LINE #1 OF HEALTH DASHBOARD
    DisplayMeasuredStats("Weight:       ", " Between 149 - 163 Pounds ", "   ", CreateStatString(_weight, " lbs", 11));    
    DisplayDoingStats("Calories:     ", "   Between 1600 - 3000    ", "   ", CreateStatString(_calories, "", 11)); 
    CreateBoardSides(); 
    // LINE #2 OF HEALTH DASHBOARD
    DisplayMeasuredStats("BMI:          ", "   Between 18.5 - 24.9    ", "   ", CreateStatString(_bmi, "", 11));    
    DisplayDoingStats("Fruit:        ", "   Between 2 - 2.5 Cups   ", "   ", "  4 Cups   ");
    CreateBoardSides(); 
    // LINE #3 OF HEALTH DASHBOARD
    DisplayMeasuredStats("Waist/Hip:    ", "        Below .95         ", "   ", "    .99    ");    
    DisplayDoingStats("Vegetable:    ", "    Between 3 - 4 Cups    ", "   ", " 1.75 Cups "); 
    CreateBoardSides(); 
    // LINE #4 OF HEALTH DASHBOARD
    DisplayMeasuredStats("BP:           ", "       Below 120/80       ", "   ", "  130/90   ");    
    DisplayDoingStats("Fluid:        ", " Between 11.5 - 15.5 Cups ", "   ", " 8.5 Cups  ");
    CreateBoardSides();  
    // LINE #5 OF HEALTH DASHBOARD
    DisplayMeasuredStats("Cholesterol:  ", "        Below 200         ", "   ", "   196.6   ");    
    DisplayDoingStats("Exercise:     ", "  150 Minutes Cardio/Week ", "   ", "  30 Min   ");
    CreateBoardSides(); 
    // LINE #5 OF HEALTH DASHBOARD
    DisplayMeasuredStats("LDL & HDL:    ", " Below 100 & 60 or Higher ", "   ", " 100 & 85  ");    
    DisplayDoingStats("Build Muscle: ", "        2 Days/Week       ", "   ", "  2 Days   ");
    CreateBoardSides(); 
    CreateBoardBottom(); 
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
}