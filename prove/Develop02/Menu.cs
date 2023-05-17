using System;
using System.Collections.Generic;

// ### CLASS ################################################ //
// class to run the program menu
public class Menu
{
// ### VARIABLE ATTRIBUTES ################################## //  
  // variable to hold the user's option choice
  string _choice;
  // variable to hold the prompt message
  string _prompt;  
  // list of menu options
  List<string> _options = new List<string>()
  {
    " 1 - Use current prompt for an entry",
    " 2 - Commit all your entries to your Journal",
    " 3 - Auto-generate a different prompt",
    " 4 - Hand pick a new prompt for an entry",
    " 5 - Select and read an old journal entry",
    " 6 - Put off entry & start prompt timer",
  };

// ### METHODS ############################################## //
  // method to diplay a random prompt followed by the main menu for the user
  public void DisplayMenu()
  {
    // create a Prompt object to be able to access its methods
    Prompt prompt = new Prompt();  
    // use the prompt object and run the RandomPrompt method
    // display the prompts to the user by writing them to the console    
    Console.WriteLine(_prompt = prompt.RandomPrompt());
    // reset color to the original settings
    Console.ResetColor();   
    // tell user how to make a selection       
    Console.WriteLine("\nSelect an option by entering its number:");
    Console.ResetColor();
    // display the menu to select from
    foreach (string option in _options)
    {
      Console.WriteLine($"{option}");
    }     
  }

  // method to take the users choice and 
  // translate it into the appropriate actions
  public void Transition(string leadIn)
  { 
    // determine if they are making a choice or stopping the auto-prompter
    // choices would be menu or numbers 1 - 6 in string form
    // if the string is anything else it will ask for a valid entry
    // one exception is "END PROGRAM" which is a special entry
    // it is entered by menu options that start the auto-prompter
    // to stop recalls from happening when stopping the auto-prompter
    // with a "null or empty" string being entered after the auto-prompter
    // has been started by menu option "6" or option "1" suboption "3"

    // if "menu" is passed in through this method's leadIn passed in variable 
    // variable, display the mainn menu for the user and record the choice entered 
    // entered after the menu is displayed as the _choice variable for use below
    if (leadIn == "menu")
    {
    // show them the options
    DisplayMenu();
    // show them where to enter their selection
    Console.Write("\nSelection: ");     
    // record their choice in the variable representing it for use below  
      _choice = Console.ReadLine();
    } 
    // otherwise set _choice equal to the value passed in
    // through the leadIn passed in variable for use below
    else 
    {
      // set _choice variable equal to value passed in
      _choice = leadIn;
    }
    // run a loop until a valid choice is made
    do    
    {   
      // MAIN MENU // CHOICE: 1 - Use current prompt for an entry
      if (_choice == "1")
      {
        // create instand of Pen
        Pen pen = new Pen();
        // use the pen object to call its userName method
        // and store the username for the backup filename
        string backupFileName = pen.Username();
        // give a transition statement with an empty line before it
        Console.Write("\nPlease");
        // add color to emphasize this text
        // reference source: https://stackoverflow.com/questions/2743260/is-it-possible-to-write-to-the-console-in-colour-in-net
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(" make your entry");
         // reset color to the original settings
        Console.ResetColor();
        Console.Write(" and then ");
        // add color to emphasize this text      
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("press Enter to store it");
        // reset color to the original settings
        Console.ResetColor();
        Console.WriteLine(" in response to:");
        // store the current date and time in a variable
        DateTime entryTime = DateTime.Now;       
        // create variable to hold date & time as a string
        string dateTime = entryTime.ToString("D") + " " + entryTime.ToString("t");       
        // display the current date and time
        Console.WriteLine(dateTime);
        // display the journal prompt in color
        Console.ForegroundColor = ConsoleColor.Yellow;
        // display the prompt
        Console.WriteLine(_prompt);
        // reset the text color
        Console.ResetColor();        
        // use Pen method to add an entry
        pen.Add(entryTime, dateTime, _prompt);
        // add a space before the transition statement
        Console.WriteLine();
        // change type color of the smiley face to draw the user's attention
        Console.ForegroundColor = ConsoleColor.Yellow;
        // add a smiley face to help encourage the user
        Console.Write($"{Convert.ToChar(2)} {Convert.ToChar(45)}{Convert.ToChar(16)} ");
        // change type color of ending statement to red to draw user's attention
        Console.ForegroundColor = ConsoleColor.Red;
        // tell the user what happened with a transition statement
        Console.Write ("You have entered a journal response to the given prompt ");
        // change type color of the smiley face to draw the user's attention
        Console.ForegroundColor = ConsoleColor.Yellow;
        // add a smiley face to help encourage the user
        Console.WriteLine ($"{Convert.ToChar(17)}{Convert.ToChar(45)} {Convert.ToChar(2)}\n");
        // reset the console writing color
        Console.ResetColor();
        // give them the choice to do something else or start autoprompter
        // have the user make a closing choice
        Console.WriteLine("\nPlease enter a selection, would you now like to:");
        Console.WriteLine(" 1 - Commit your entries to your Journal"); 
        Console.WriteLine(" 2 - Wait to commit entries and see other options");      
        Console.WriteLine(" 3 - Wait to commit entries and start auto-prompter");     
        // run a loop until a valid choice is made
        do
        {  
          // show user where to enter their selection
          Console.Write("\nSelection: "); 
          // set choice equal to their entry
          _choice = Console.ReadLine();
          // main menu choice(1) SUBMENU // CHOICE: 1 - Commit your entries to your Journal
          if (_choice == "1")
          {
            // place a space after the selection
            Console.WriteLine();
            // change type color of ending statement to red to draw user's attention
            Console.ForegroundColor = ConsoleColor.Red;
            // let the user know what has happened
            Console.WriteLine("You have chosen to commit your entries into your journal file.");
            // reset the console writing color
            Console.ResetColor(); 
            // place a space before the auto-prompter starting statement
            Console.WriteLine();
            // access the dictionary list in the Pen class for the entries
            var entries = pen._pendingEntries;
            // create Journal object to use method to add entries
            Journal journal = new Journal();
            journal.AddToJournal(entries);
            // empty the entries list
            pen.EmptyList();
            // change type color of ending statement to red to draw user's attention
            Console.ForegroundColor = ConsoleColor.Red;
            // give a transition statement with an empty space before it
            Console.WriteLine("\nYour entries have been permanently saved to your Journal by date.");
            // reset the console writing color
            Console.ResetColor();
            // set _choice as "menu" to use for the transition method variable
            // so it shows the menu to the user so they know what to choose from
            _choice = "menu";            
          } 
          // main menu choice(1) SUBMENU // CHOICE: 2 - Wait to commit entries and see other options
          else if (_choice == "2")
          {
            // change type color of ending statement to red to draw user's attention
            Console.ForegroundColor = ConsoleColor.Red;
            // let the user know what has happened with an empty space before it
            Console.WriteLine("\nYou chose to wait to commit your entry to your journal and look at more journal options.");
            // reset the console writing color
            Console.ResetColor(); 
            // place a space before the auto-prompter starting statement
            Console.WriteLine();
            // set _choice as "menu" to send it to the else if menu option in
            // this do/while loop so it will show the menu to the user so they
            // can look at the main menu options and make another choice
            _choice = "menu";            
          } 
          // main menu choice(1) SUBMENU // CHOICE: 3 - Wait to commit entries and start auto-prompter
          else if (_choice == "3")
          {
            // set _choice equal to the "Throw away" else/if option in this do/while loop that
            // is set up to send unneeded repetive menu calls to be killed there thus preventing
            // them from reentering through being passed in by this method's variable "leadIn",
            // that is passed on to this do/while loop through the Initiator's class's method
            // method TurnOn through TurnOn's variable stop, which variable is used to stop the
            // the auto-prompter or to pass on values to this do/while loop for further optoins
            _choice = "END PROGRAM";
            // change type color of ending statement to red to draw user's attention
            Console.ForegroundColor = ConsoleColor.Red;
            // let the user know what has happened with an empty space before it
            Console.WriteLine("\nYour entries have been temporarily saved in an entry list by their entry time.");
            // reset the console writing color
            Console.ResetColor(); 
            // place a space before the auto-prompter starting statement
            Console.WriteLine();            
            // create and instance of the Initiator class to access its method
            Initiator autoprompter = new Initiator();
            // use the instance to access TurnOn Initiator method
            autoprompter.TurnOn();            
          }
          // main menu choice(1) SUBMENU // do/while continuous loop message
          else 
          {  
            // set choice equal to "invalid" to rerun the submenu do/while loop
            _choice = "invalid";
            // tell the user what they must do to enter a valid choice 
            Console.WriteLine("You must enter a valid choice of 1 or 2");
          }
        }
        // main menu choice(1) SUBMENU // condition to keeep the do/while loop running
        while (_choice == "invalid");
      } 
      // MAIN MENU // CHOICE: 2 - Commit all your entries to your Journal
      else if (_choice == "2")
      {
        // create instand of Pen
        Pen pen = new Pen();
        // use the pen object to call its userName method
        // and store the username for the backup filename
        string backupFileName = pen.Username();
        // bring up and store the dictionary list of entries
        // to pass into the Journal class's AddToJournal method 
        var entries = pen.ViewEntries();      
        // change type color of ending statement to red to draw user's attention
        Console.ForegroundColor = ConsoleColor.Red;
        // give a transition statement with an empty space before it
        Console.WriteLine("\nYou have chosen to commit all of your entries to your Journal");
        // reset the console writing color
        Console.ResetColor();
        // add an empty line between text
        Console.WriteLine();
        // access the dictionary list in the Pen class for the entries
        // var entries = pen._pendingEntries;
        // create Journal object to use method to add entries
        Journal journal = new Journal();
        journal.AddToJournal(entries);
        // empty the entries list
        pen.EmptyList();       
        // set _choice as "menu" to use for the transition method variable
        // so it shows the menu to the user so they know what to choose from
        _choice = "menu"; 
      }
      // MAIN MENU // CHOICE: 3 - Auto-generate a different prompt
      else if (_choice == "3")
      {
        // change type color of ending statement to red to draw user's attention
        Console.ForegroundColor = ConsoleColor.Red;
        // give a transition statement with an empty line before it
        Console.WriteLine("\nHere is your new prompt:");
        // reset the console writing color
        Console.ResetColor(); 
        // regenerate a new prompt with options 
        _choice = "menu";        
      }
      // MAIN MENU // CHOICE: 4 - Hand pick a new prompt for an entry
      else if (_choice == "4")
      {
        // create instand of Pen
        Pen pen = new Pen();        
        // use the pen object to call its userName method
        // and store the username for the backup filename
        string backupFileName = pen.Username();
        // display the current date and time
        // store the current date and time in a variable
        DateTime entryTime = DateTime.Now;       
        // create variable to hold date & time as a string
        string dateTime = entryTime.ToString("D") + " " + entryTime.ToString("t");   
        // change type color of ending statement to red to draw user's attention
        Console.ForegroundColor = ConsoleColor.Red;
        // give a transition statement with an empty space before it
        Console.WriteLine("\nYou have chosen to hand pick the prompt to respond to.");        
        // reset the console writing color
        Console.ResetColor();
        // tell the user how to make their choice
        Console.WriteLine("\nChoose your prompt from this list by entering its number:"); 
        // show the list of prompts to the user to choose from
        Prompt prompt = new Prompt();
        prompt.ListPrompts();
        // store the prompt in the _prompt variable
        _prompt = prompt.SelectPrompt();              
        // display the journal prompt in color
        Console.ForegroundColor = ConsoleColor.Yellow;
        // display the prompt
        Console.WriteLine(_prompt);
        // reset the text color
        Console.ResetColor();        
        // use Pen method to add an entry
        pen.Add(entryTime, dateTime, _prompt);
        // add a space before the transition statement
        Console.WriteLine();
        // change type color of the smiley face to draw the user's attention
        Console.ForegroundColor = ConsoleColor.Yellow;
        // add a smiley face to help encourage the user
        Console.Write($"{Convert.ToChar(2)} {Convert.ToChar(45)}{Convert.ToChar(16)} ");
        // change type color of ending statement to red to draw user's attention
        Console.ForegroundColor = ConsoleColor.Red;
        // tell the user what happened with a transition statement
        Console.Write ("You have entered a journal response to the given prompt ");
        // change type color of the smiley face to draw the user's attention
        Console.ForegroundColor = ConsoleColor.Yellow;
        // add a smiley face to help encourage the user
        Console.WriteLine ($"{Convert.ToChar(17)}{Convert.ToChar(45)} {Convert.ToChar(2)}\n");
        // reset the console writing color
        Console.ResetColor();
        // give them the choice to do something else or start autoprompter
        // have the user make a closing choice
        Console.WriteLine("\nPlease enter a selection, would you now like to:");
        Console.WriteLine(" 1 - Commit your entries to your Journal"); 
        Console.WriteLine(" 2 - Wait to commit entries and see other options");      
        Console.WriteLine(" 3 - Wait to commit entries and start auto-prompter");  
        // run a loop until a valid choice is made
        do
        {  
          // show user where to enter their selection
          Console.Write("\nSelection: "); 
          // set choice equal to their entry
          _choice = Console.ReadLine();
          // main menu choice(4) SUBMENU // CHOICE: 1 - Commit your entries to your Journal
          if (_choice == "1")
          {           
            // place a space after the selection
            Console.WriteLine();
            // change type color of ending statement to red to draw user's attention
            Console.ForegroundColor = ConsoleColor.Red;
            // let the user know what has happened
            Console.WriteLine("You have chosen to commit your entries into your journal file.");
            // reset the console writing color
            Console.ResetColor(); 
            // place a space before the auto-prompter starting statement
            Console.WriteLine();
            // access the dictionary list in the Pen class for the entries
            var entries = pen._pendingEntries;
            // create Journal object to use method to add entries
            Journal journal = new Journal();
            journal.AddToJournal(entries);
            // empty the entries list
            pen.EmptyList();
            // change type color of ending statement to red to draw user's attention
            Console.ForegroundColor = ConsoleColor.Red;
            // give a transition statement with an empty space before it
            Console.WriteLine("\nYour entries have been permanently saved to your Journal by date.");
            // reset the console writing color
            Console.ResetColor();
            // set _choice as "menu" to use for the transition method variable
            // so it shows the menu to the user so they know what to choose from
            _choice = "menu"; 
                      
          } 
          // main menu choice(4) SUBMENU // CHOICE: 2 - Wait to commit entries and see other options
          else if (_choice == "2")
          {
            // change type color of ending statement to red to draw user's attention
            Console.ForegroundColor = ConsoleColor.Red;
            // let the user know what has happened with an empty space before it
            Console.WriteLine("\nYou chose to wait to commit your entry to your journal and look at more journal options.");
            // reset the console writing color
            Console.ResetColor(); 
            // place a space before the auto-prompter starting statement
            Console.WriteLine();
            // set _choice as "menu" to send it to the else if menu option in
            // this do/while loop so it will show the menu to the user so they
            // can look at the main menu options and make another choice
            _choice = "menu";                     
          } 
          // main menu choice(4) SUBMENU // CHOICE: 3 - Wait to commit entries and start auto-prompter
          else if (_choice == "3")
          {
            // set _choice equal to the "Throw away" else/if option in this do/while loop that
            // is set up to send unneeded repetive menu calls to be killed there thus preventing
            // them from reentering through being passed in by this method's variable "leadIn",
            // that is passed on to this do/while loop through the Initiator's class's method
            // method TurnOn through TurnOn's variable stop, which variable is used to stop the
            // the auto-prompter or to pass on values to this do/while loop for further optoins
            _choice = "END PROGRAM";
            // change type color of ending statement to red to draw user's attention
            Console.ForegroundColor = ConsoleColor.Red;
            // let the user know what has happened with an empty space before it
            Console.WriteLine("\nYour entries have been temporarily saved in an entry list by their entry time.");
            // reset the console writing color
            Console.ResetColor(); 
            // place a space before the auto-prompter starting statement
            Console.WriteLine();            
            // create and instance of the Initiator class to access its method
            Initiator autoprompter = new Initiator();
            // use the instance to access TurnOn Initiator method
            autoprompter.TurnOn();            
          }
          // main menu choice(1) SUBMENU // do/while continuous loop message
          else 
          {  
            // set choice equal to "invalid" to rerun the submenu do/while loop
            _choice = "invalid";
            // tell the user what they must do to enter a valid choice 
            Console.WriteLine("You must enter a valid choice of 1 or 2");
          }
        }
        // main menu choice(1) SUBMENU // condition to keeep the do/while loop running
        while (_choice == "invalid");     
      }
      // MAIN MENU // CHOICE: 5 - Select and read an old journal entry
      else if (_choice == "5")
      {
        // change type color of ending statement to red to draw user's attention
        Console.ForegroundColor = ConsoleColor.Red;        
        // give a transition statement, show the submenu and tell user how to use it
        Console.WriteLine("\nYou chose to select and read an old journal entry.");
        // reset the console writing color
        Console.ResetColor(); 
        // give the user a list of submenu choices in relation to reading
        // old journal entries and tell them how to select their choice
        Console.WriteLine("\nSelect an option by entering its number:");
        Console.WriteLine(" 1 - Display all uncommitted journal entries");               
        Console.WriteLine(" 2 - Display all entries from a journal volume");
        Console.WriteLine(" 3 - Display a date range of journal entries");
        // run a do/while loop until a valid choice is made
        do
        {  
          // show the user where to enter their choice
          Console.Write("\nSelection: ");
          // make the _choice variable equal to user's entry  
          _choice = Console.ReadLine();
          // main menu choice(5) SUBMENU // CHOICE: 1 - Display all uncommitted journal entries
          if (_choice == "1")
          {
            // change type color of ending statement to red to draw user's attention
            Console.ForegroundColor = ConsoleColor.Red;
            // let the user know what they have chosen
            Console.WriteLine("\nYou have chosen to display all of your uncommitted journal entries.\n");
            // reset the console writing color
            Console.ResetColor();
            // create a Pen class object to access its methods
            Pen pen = new Pen();
            // use the Pen object to use its DisplayEntries method
            pen.DisplayEntries(); 
            // set _choice as "menu" to use for the transition method variable
            // so it shows the menu to the user so they know what to choose from
            _choice = "menu"; 
          }           
          // main menu choice(5) SUBMENU // CHOICE: 2 - Display all entries from a journal volume
          else if (_choice == "2")
          {
            // change type color of ending statement to red to draw user's attention
            Console.ForegroundColor = ConsoleColor.Red;
            // let the user know what has happened with an empty space before and afterward
            Console.WriteLine("\nYou have chosen to display all of your Journal file.\n");
            // reset the console writing color
            Console.ResetColor();
            // create journal instance to use the journal methods         
            Journal journal = new Journal();
            // call FileTo list and get the filename 
            // & save uploaded journal to variable
            var myJournal = journal.FileToList();
            // add a space before transition statement
            Console.WriteLine();
            // change type color of ending statement to red to draw user's attention
            Console.ForegroundColor = ConsoleColor.Red;
            // tell the user where to find the requested information
            Console.WriteLine($"|{Convert.ToChar(25)} {Convert.ToChar(31)} {Convert.ToChar(25)}| Below are all of the journal entries you have committed to your Journal |{Convert.ToChar(25)} {Convert.ToChar(31)} {Convert.ToChar(25)}|\n");
            // reset the console writing color
            Console.ResetColor();
            // display all the journal entries to the console            
            journal.ConsoleDisplay(myJournal);
            // change type color of ending statement to red to draw user's attention
            Console.ForegroundColor = ConsoleColor.Red;
            // let the user know what has happened with a space before it
            // plus add in an arrow pointing up
            // reference source: https://www.codeproject.com/Questions/254514/Displaying-a-symbol-in-csharp & https://en.wikipedia.org/wiki/Code_page_437 & https://www.ascii-codes.com/cp855.html & https://yorktown.cbe.wwu.edu/sandvig/shared/asciicodes.aspx
            Console.WriteLine($"\n|{Convert.ToChar(24)} {Convert.ToChar(30)} {Convert.ToChar(24)}| Your specified journal volume is now displayed in the terminal space above here |{Convert.ToChar(24)} {Convert.ToChar(30)} {Convert.ToChar(24)}|"); 
            // reset the console writing color
            Console.ResetColor();
            // set _choice as "menu" to use for the transition method variable
            // so it shows the menu to the user so they know what to choose from
            _choice = "menu";                  
          }
          // main menu choice(5) SUBMENU // CHOICE: 3 - Display a date range of journal entries
          else if (_choice == "3")
          {  
            // change type color of ending statement to red to draw user's attention
            Console.ForegroundColor = ConsoleColor.Red;
            // let the user know what has happened with an empty space before and afterward
            Console.WriteLine("\nYou have chosen to display a date range of journal entries.\n");
            // reset the console writing color
            Console.ResetColor();           
            // set boolean to false for the starting date
            bool startDateFormat = false;
            // create variable to hold the starting date for the date range
            string startDate;
            // run a do/while loop until proper date formats are entered
            do
            {            
              // prompt user for starting date + show the user the format to use
              Console.WriteLine("Please enter the start date for your desired range in this format: 6/9/2023");
              // show user they are entering the starting date
              Console.Write("Starting date: ");
              // store answer in a variable for use
              startDate = Console.ReadLine();
              // set the variable startTest as a boolean through TryParse method and
              // set the startResult variable as a DateOnly holding the date if it is true
              // referece source: https://www.tutorialspoint.com/chash-int-tryparse-method
              bool startTest = DateOnly.TryParse(startDate, out DateOnly startResult);
              // if it is not a properly formatted date do this
              if (startTest == false)
              {
                // change type color of statement to red to draw user's attention
                Console.ForegroundColor = ConsoleColor.Red;
                // tell the user the date was not in the proper format and to retry
                Console.WriteLine("The date you entered was not in the proper format, please try again.");
                // reset the console writing color
                Console.ResetColor();
                // ensure the startDateFormat boolean is set to false
                startDateFormat = false;
              } 
              // if is is properly formatted do this
              else
              {
                // if it passes the test set the startDateFormat to true
                startDateFormat = true;
              }         
            }
            // continue doing this until they enter a properly formatted date
            while (startDateFormat == false);
            // set boolean to false for the ending date
            bool endDateFormat = false;
            // create variable to hold the ending date for the date range
            string endDate;
            // run a do/while loop until proper date formats are entered
            do
            {
              // prompt user for ending date + show the user the format to use
              Console.WriteLine("Please enter the end date for your desired range in this format: 6/9/2023");
              // show user they are entering the ending date
              Console.Write("Ending date: ");
              // store answer in a variable for use
              endDate = Console.ReadLine();
              // add a space after this to seperate the output
              Console.WriteLine();
              // set the variable endTest as a boolean through TryParse method and
              // set the endResult variable as a DateOnly holding the date if it is true            
              bool endTest = DateOnly.TryParse(endDate, out DateOnly endResult);
              // if it is not a properly formatted date do this
              if (endTest == false)
              {
                // change type color of statement to red to draw user's attention
                Console.ForegroundColor = ConsoleColor.Red;
                // tell the user the date was not in the proper format and to retry
                Console.WriteLine("The date you entered was not in the proper format, please try again.");
                // reset the console writing color
                Console.ResetColor();
                // ensure the endDateFormat boolean is set to false
                endDateFormat = false;
              }
              // if is is properly formatted do this
              else
              {
                // if it passes the test set the endDateFormat to true
                endDateFormat = true;
              }
            }
            // continue doing this until they enter a properly formatted date
            while (endDateFormat == false);
            // make an instance of the Journal class to call methods with
            Journal journal = new Journal();           
            // create variable to hold the journal file in a dictionary list
            // so it's not called twice in a row and gets and error for same keys
            var journalList = journal.FileToList();
            // place space before the dates are displayed from the
            Console.WriteLine();           
            // call the methods to get the start date and store it in a variable
            int startIndex = (journal.GetStartIndex(journalList, startDate));
            // call the methods to get the end date and store it in a variable
            int endIndex = (journal.GetEndIndex(journalList, endDate));
            // do this if the start date isn't in the journal, but end index is
            if (startIndex == -1 || endIndex == -1)
            {   
              // change type color of ending statement to red to draw user's attention
              Console.ForegroundColor = ConsoleColor.Red;
              // let the user know they have to enter a date that has an entry for both dates 
              Console.WriteLine("\nSorry, to return journal entries in a date range the dates entered must both be in the journal.");
              // reset the console writing color
              Console.ResetColor();
              // set _choice as "menu" to use for the transition method variable
              // so it shows the menu to the user so they know what to choose from
              _choice = "menu";             
            }
            // do this if both the start and end dates are in the journal
            else
            {          
              // add a space before transition statement
              Console.WriteLine();
              // change type color of ending statement to red to draw user's attention
              Console.ForegroundColor = ConsoleColor.Red;
              // tell the user where to find the requested entries
              Console.WriteLine($"|{Convert.ToChar(25)} {Convert.ToChar(31)} {Convert.ToChar(25)}| Below are the requested journal entries within the specified date range |{Convert.ToChar(25)} {Convert.ToChar(31)} {Convert.ToChar(25)}|\n");
              // reset the console writing color
              Console.ResetColor();
              // call the methods to get the selection and store it in a variable
              var selection = (journal.GetSelection(journalList, startIndex, endIndex));           
              // add a space before displaying the specified journal entries
              Console.WriteLine();
              // call the display method to display the requested date range 
              journal.ConsoleDisplay(selection);             
              // change type color of ending statement to red to draw user's attention
              Console.ForegroundColor = ConsoleColor.Red;
              // let the user know what has happened with a space before it
              // plus add in an arrow pointing up            
              Console.WriteLine($"\n|{Convert.ToChar(24)} {Convert.ToChar(30)} {Convert.ToChar(24)}| Your journal entries within the date range can now be found above in this terminal |{Convert.ToChar(24)} {Convert.ToChar(30)} {Convert.ToChar(24)}|"); 
              // reset the console writing color
              Console.ResetColor(); 
              // set _choice as "menu" to use for the transition method variable
              // so it shows the menu to the user so they know what to choose from
              _choice = "menu";
            }
          } 
          // main menu choice(5) SUBMENU // do/while continuous loop message     
          else 
          {   
            // set choice equal to "invalid" to rerun the submenu do/while loop 
            _choice = "invalid"; 
            // tell the user what they must do to enter a valid choice 
            Console.WriteLine("You must enter a valid choice of 1, 2, or 3");
          }
        }
        // main menu choice(5) SUBMENU // condition to keeep the do/while loop running
        while (_choice == "invalid");
      }
      // MAIN MENU // CHOICE: 6 - Put off entry & start prompt timer
       else if (_choice == "6")
      {
        // set _choice equal to the "Throw away" else/if option in this do/while loop that
        // is set up to send unneeded repetive menu calls to be killed there thus preventing
        // them from reentering through being passed in by this method's variable "leadIn",
        // that is passed on to this do/while loop through the Initiator's class's method
        // method TurnOn through TurnOn's variable stop, which variable is used to stop the
        // the auto-prompter or to pass on values to this do/while loop for further optoins  
        _choice = "END PROGRAM"; 
        // change type color of ending statement to red to draw user's attention
        Console.ForegroundColor = ConsoleColor.Red;
        // give a transition statement with an empty line before it
        Console.WriteLine("\nYour journal entry has been postponed until the next auto-prompt and program restart.");
        // reset the console writing color
        Console.ResetColor(); 
        // place a space before the auto-prompter starting statement
        Console.WriteLine();        
        // create and instance of the Initiator class to access its method
        Initiator autoprompter = new Initiator();             
        // use the instance to access TurnOn Initiator method               
        autoprompter.TurnOn();             
      }
      // MAIN MENU // CHOICE: "menu"
      // option to show the main menu again // used so the user 
      // can type menu at any time and get back to the main menu //
      // also used to loop other menu option in this do/when loop
      // back to starting the menu again // also used as a error 
      // catch if user didn't mean to start the autoprompt - so 
      // they can enter "menu" and get back to the main menu
      else if (_choice == "menu")
      {        
        // start menu over again
        Transition("menu");         
      }
      // MAIN MENU // CHOICE: unlisted for special case use only
      // this choice is reached through the main menu options of
      // "6" and option "1" submenu option "3" followed by pressing
      // the enter key with nothing entered or a "Null or void" value
      else if (_choice == "END PROGRAM") 
      {
        // a useful debugging line showing looping cycles
        // Console.WriteLine("THROW AWAY!!!!!!!!!!!!");

        // Stop the repeat cycle of this code when "Null or void" is 
        // entered after the auto-prompter is started as a command to
        // stop the program from running the auto-prompter
        break;
      }
      // MAIN MENU // do/while continuous loop message
      else 
      {   
        // tell the user how to enter a valid choice         
        Console.WriteLine("You must enter a valid choice of 1, 2, 3, 4, 5 or 6");
        Console.WriteLine("Please enter your choice again.");
        Console.Write("\nSelection: ");   
        _choice = Console.ReadLine();
      }
    }
    // MAIN MENU // conditions to keep running the loop
    // this is an infinite loop - will always evaluate as true
    while (_choice != "1" || _choice != "2" || _choice != "3" || _choice != "4" || _choice != "5" || _choice != "6");    
  }
}

