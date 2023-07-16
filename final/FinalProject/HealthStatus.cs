using System;
using System.IO;
using System.Reflection;

// ### CLASS ################################################ //
// class to hold the health status statistics
public class HealthStatus
{
// ### VARIABLE ATTRIBUTES ################################## //  
  private string _foodType;   
  private string _foodName;  
  private int _portion; 
  private string _portionScale; 
  private int _calories; 
  private string _attributes; 

  private string _userName;
  // reference source: https://www.cdc.gov/healthyweight/assessing/bmi/adult_bmi/index.html
  private string _bodyMassIndexStandard = "Between 18.5 - 24.9";   
  private float _bodyMassIndex; 
  private string _weightStandard = "Between 149 - 163 lbs"; 
  private float _weight; 
  private float _height; 
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
  
// ### CONSTRUCTORS ######################################### //
  // main constructor to set up a Food object with the user's inputs used in Menu class
  public HealthStatus(string update, string account)
  { 
    
    if (update == "height")
    {
      // have option for each health statistic 
    }    
  }  

  // constructor for converting textfile to Food object in Tracker Class & for the ClassToString method in derived classes
  public HealthStatus(string stringAttributes)
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

  public void DivideAttributes(string stringAttributes)
  {

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
    CreateSectionTitles();    
    CreateBoardTop();
    CreateBoardSides(); 
    // LINE #1 OF HEALTH DASHBOARD
    DisplayMeasuredStats("Weight:       ", " 149 - 163 lbs ", "   ", " 189.6 lbs ");    
    DisplayDoingStats("Calories:   ", "   1600 - 3000    ", "   ", "   2000    "); 
    CreateBoardSides(); 
    // LINE #2 OF HEALTH DASHBOARD
    DisplayMeasuredStats("BMI:          ", "  18.5 - 24.9  ", "   ", "    26.4   ");    
    DisplayDoingStats("Fruit:      ", "   2 - 2.5 Cups   ", "   ", "  4 Cups   ");
    CreateBoardSides(); 
    // LINE #3 OF HEALTH DASHBOARD
    DisplayMeasuredStats("Waist/Hip:    ", "   Below .95   ", "   ", "    .99    ");    
    DisplayDoingStats("Vegetable:  ", "    3 - 4 Cups    ", "   ", " 1.75 Cups "); 
    CreateBoardSides(); 
    // LINE #4 OF HEALTH DASHBOARD
    DisplayMeasuredStats("BP:           ", "  Below 120/80 ", "   ", "  130/90   ");    
    DisplayDoingStats("Fluid:      ", " 11.5 - 15.5 Cups ", "   ", " 8.5 Cups  ");
    CreateBoardSides();  
    // LINE #5 OF HEALTH DASHBOARD
    DisplayMeasuredStats("Cholesterol:  ", "   Below 200   ", "   ", "   196.6   ");    
    DisplayDoingStats("Exercise:   ", "   22 Min Cardio  ", "   ", "  30 Min   ");
    CreateBoardSides(); 
    CreateBoardBottom(); 
  }
  
  // method to display the text for the measurement stats
  private void DisplayMeasuredStats(string category, string standard, string space, string stat)
  {  
    Console.ForegroundColor = ConsoleColor.DarkGray;  Console.Write(" |");     
    Console.ForegroundColor = ConsoleColor.Yellow;    Console.Write(category); Console.ResetColor();    
    Console.BackgroundColor = ConsoleColor.DarkGray;  Console.Write(standard); 
    Console.ResetColor();                             Console.Write(space);  
    Console.BackgroundColor = ConsoleColor.DarkGray;  Console.Write(stat);   
    Console.ResetColor();                             Console.Write("      "); 
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
    Console.BackgroundColor = ConsoleColor.DarkBlue; Console.Write("  Category  ");    
                                                     Console.Write($"{Convert.ToChar(183)}:{Convert.ToChar(183)}");
                                                     Console.Write($"   Standard   ");
                                                     Console.Write($"{Convert.ToChar(183)}:{Convert.ToChar(183)}");
                                                     Console.Write($"  Presently   ");
                                                     Console.Write($"{Convert.ToChar(183)}:{Convert.ToChar(183)}");
                                                     Console.Write("  Category ");    
                                                     Console.Write($"{Convert.ToChar(183)}:{Convert.ToChar(183)}");
                                                     Console.Write($"    Standard    ");
                                                     Console.Write($"{Convert.ToChar(183)}:{Convert.ToChar(183)}");
                                                     Console.Write($"  Presently  "); Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Cyan;     Console.WriteLine(":"); Console.ResetColor();
  }

  // method to create the top of the Health Dashboard
  private void CreateBoardTop()
  {  
    string line = new string('_', 45);    
    string space = new string(' ', 46);    
    Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($" {line}#_#_#{line} ");
    Console.WriteLine($"|{space}\\|/{space}|") ; Console.ResetColor(); 
  }

  // method to create the sides of the Health Dashboard
  private void CreateBoardSides()
  {
    string space = new string(' ', 47); 
    Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($"|{space}|{space}|");
    Console.ResetColor();
  }

  // method to create the bottom of the Health Dashboard
  private void CreateBoardBottom()
  {  
    string line = new string('_', 46);
    string topLine = new string('\u0304', 45); 
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
    string topLine = new string('\u0304', 45); 
    Console.ForegroundColor = ConsoleColor.Cyan; 
    Console.WriteLine($"{Convert.ToChar(186)}{topLine}*\u0304*\u0304*{topLine}{Convert.ToChar(186)}");    
    Console.ResetColor(); Console.WriteLine();
  }
}