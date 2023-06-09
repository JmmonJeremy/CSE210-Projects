using System;
using System.IO;

// ### CLASS ################################################ //
// class to run the listing activity
public class ListingActivity : Activity
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // variable to hold the activity name
  private string _listingName = "Listing Activity";
  // variable to hold the activity description
  private string _listingDescription = "remember the good characteristics, desires, people, events, accomplishments, and circumstances in your life by having you list as many things about a referenced subject as you can.";   
  // list to hold the list of listing prompts for the activity
  private List<string> _subjectList = new List<string>()
  {
    "What am I looking forward to today?",
    "What positive things happened today?",
    "What am I grateful for today?",
    "Who am I?",
    "What makes me feel alive?",
    "What are my core values?",
    "What people am I grateful for?",
    "What are my personal strengths?",
    "Who did I serve this month?",
    "When have I feel the Spirit lately?",
    "Who are my personal heroes?",
    "At the end of my life, what will I hope to have experienced?",
    "What am I glad that I have done?",
    "What matters most to me?",
    "If I only had one year left to live, how would I spend it?",
    "What are my happy places?",
    "When do I feel most like ‘me’?",
    "If I was sure to succeed, what would I begin doing tomorrow?",
    "What do I love about my life?",
    "What are my favorite memories?",
    "What makes me smile?",
    "What words would I like to live by?",
    "What have I done to show love to myself?",
    "What have I done to show love to others?",
    "What are my greatest talents or skills?",
    "What things represent me and why?",    
  };
  // variable to hold the number of entries in response to a subject
  private int _responseCount;

  // ### CONSTRUCTORS ######################################### //
  // constructor to be able to use the RunAllListing methods
  public ListingActivity()
  {
    // nothing needed in here    
  }
  // constructor to set up for the Listing Activity
  public ListingActivity(string activityName, string description) : base (activityName, description)
  {
    // base variables are all done in the Activity base class      
  }

// ### METHODS ############################################## //
  // method to get & return a random subject question
  public string RandomSubject()
  {
    // set a variable to hold the _subjectList count
    int count = _subjectList.Count;
    // create a Random object for selecting the index #
    Random _randomIndexSelector = new Random();
    // randomly select a number to represent a list index
    int indexSelector = _randomIndexSelector.Next(0, count);    
    // return the subject question with that index from the _subjectList
    return _subjectList[indexSelector];
  } 

  // method to give instructions and prepare user for the listing exercises
  public void PrepareListing()
  {
    // give the user directions on what to do
    Console.WriteLine("Enter as many responses as you can for the following subject:");    
    // put an empty space before the prompt and indent it
    Console.Write("\n    ");
    // change the color of the background for the prompt
    Console.BackgroundColor = ConsoleColor.DarkGray;    
    // display the subject prompt with a space after it
    Console.WriteLine($" {Convert.ToChar(2)}{Convert.ToChar(2)}{Convert.ToChar(2)} {RandomSubject()} {Convert.ToChar(2)}{Convert.ToChar(2)}{Convert.ToChar(2)} \n");
    // reset the backgroung color to what it was
    Console.ResetColor();
    // prepare them to begin
    Console.WriteLine("Starting in 10 seconds. . . "); 
    // display a count and clock spinner for a countdown
    Spinner(ConsoleColor.Cyan, ConsoleColor.DarkBlue, 10);
    // enter an empty space before the subject questions
    Console.WriteLine();
  }

  // method to direct the listing exercises
  public void ListingExercises()
  {       
    // change the color of the background for the response question
    Console.BackgroundColor = ConsoleColor.DarkGray;
    // show user where to make the entry with a symbol
    Console.Write($"{Convert.ToChar(21)}{Convert.ToChar(16)}");
    // reset the backgroung color to what it was
    Console.ResetColor();
    // add an empty space between the entry symbol and the response
    Console.Write(" ");
    // place for user to make an entry
    Console.ReadLine();
    // keep a count of the entries
    _responseCount ++;              
  }

  // method to display the amount of responses they entered
  public void DisplayCount() 
  {
    // show the user how many responses they listed with an empty space before it
    Console.WriteLine($"\nYou listed {_responseCount} reponses!");
  }

  // method to run everyting for the Listing Activity
  public string RunAllListing()
  {    
    // create listing object so the correct activity name and description are passed in
    // as well as all of the other things for the intro and the boolean
    ListingActivity listing = new ListingActivity(_listingName, _listingDescription);
    // run the opening with the correct activity name & descriptiorn from using
    // the object while running this inherited method from the Activity class
    listing.Opening();
    // run prepare with the correct activity name from using the object 
    // while running this inherited method from the Activity class
    listing.PrepareActivity(); 
    // run this class specific PrepareListing method
    PrepareListing();
    // run the central part of the Listing Activity with the object while running this inherited method 
    // from the Activity class so it works properly by including the boolean and _sessionLength values   
    listing.RunActivity(ListingExercises);
    // run this class specific DisplayCount method
    DisplayCount();
    // run end activity message in this inherited method from the Activity class
    EndActivity();
    // run the closing with the correct activity name with the object while running this inherited
    // method from the Activity class then save the choice of the user in the choice variable  
    string choice = listing.Closing();
    // return the user's choice
    return choice;
  }
}