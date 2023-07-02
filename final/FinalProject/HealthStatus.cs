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
  private float _weightGoal; 
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
  private string _fruitIntakeStandard = "Between 2 Cups a Day";
  private float _fruitIntake;
  // reference source: https://www.myplate.gov/eat-healthy/vegetables
  private string _veggieIntakeStandard = "Between 3 - 4 Cups a Day";
  private float _veggieIntake;
  // reference source: https://health.clevelandclinic.org/how-many-calories-a-day-should-i-eat/#
  private string _calorieStandard = "Between 1600 - 3000";
  private int _calorieGoal;
  private int _caloriesTotal;
  // reference source: https://www.mayoclinic.org/healthy-lifestyle/nutrition-and-healthy-eating/in-depth/water/art-20044256#
  private string _liquidIntakeStandard = "Between 11.5 - 15.5 Cups";
  private float _liquidIntake;
  
// ### CONSTRUCTORS ######################################### //
  // main constructor to set up a Food object with the user's inputs used in Menu class
  public HealthStatus(string update, string account)
  { 
    Console.WriteLine("Do you have a username?");
    account = Console.ReadLine();
    if (account == "yes")
    {
      // load account from text file including getting their height and weight
    }
    else
    {
      // set up account
    }
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
  public virtual void DeterminePortionValue()
  {
    
  }

// START OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES
  // method to turn the class name to a string
  public virtual string ClassToString()
  {    
    Food food = new Food("Set up empty");    
    return food.GetType().ToString();
  }

  // method to create & return a food text string
  public virtual string CreateFoodString()
  {      
    string foodString = $"{ClassToString()}:{_foodName}~|~{_portion}~|~{_calories}";    
    return foodString; 
  }
// END OF GROUPING OF 2 METHODS THAT HELP CONVERT OBJECT TO A STRING USED IN TRACKER & DERIVED CLASSES

// START OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR
  // method to divide the string attributes stirng into their object's variable attributes  
  private void DivideAttributes(string stringAttributes)
  {       
    string[] attributes = stringAttributes.Split("~|~");    
    _foodName = attributes[0];     
    _portion = Convert.ToInt32(attributes[1]);
    _calories = int.Parse(attributes[2]);
  }
// END OF GROUPING OF 1 METHOD THAT CONVERTS TEXT STRING TO OBJECT ATTRIBUTES USED IN CONSTRUCTOR
}