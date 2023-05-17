using System;
using System.Runtime.InteropServices;

/* Comments Explaining how I exceeded the core requirements:
The core requirements were to have the program be able to:
1) Show a random prompt from a list and save #1 the response #2 the prompt #3 the date as an entry
2) Display the journal to the screen
3) Save the journal to a file, prompting the user for the file name
4) Load the journal from a file, prompting the user for the file name to load
5) Provide a menu that allows the user to choose these options
6) My list of prompts must contain at least 5 different prompts
7) Contain classes for the major components of the program
8) Contain at least 2 classes in addition to the Program class
9) Demonstrate the use of abstraction by using member methods and variables

In addition to completing all of those core requirements I did the following:
1) In addition to providing a random prompt for the user I gave them the options of:
    1. Auto-generating a different propmt if they didn't like the one given
    2. Hand picking a prompt from a list of the prompts if they wanted to pick the prompt
2) In addition to just displaying the whole journal file to the screen I gave the user the options of:
    1. Displaying the entries not yet committed to their journal file
    2. Displaying any date range from a single entry to whatever range desired.
    3. I organized the display into dates for the journal with an empty line between dates
    4. I organized the display of the entries not yet committed by day and time with an empty line between times
    3. I colored and underlined text to help the user be able to more easily read and identify parts of entries
3) In additon to saving the journal to a file I also:
    1. Saved the propmt responses to a temporary file tied to the user with a username until they were ready to commit them to their journal file - at which time the temporary file is emptied
    2. Saved the list of prompts to a document with the thought of compiling a list that the user could add to (however I never added this feature, but I did create and use a method to write the list to a text document)
    3. Organized the entries by date, so that all entries throughout the day were listed under one key in a dictionary from the IDictionary class
    4. Had the responses kept in a dictionary under the same class as above with date and time of each entry 
    as the key
4) In addition to loading the journal from a file:
    1. I loaded the temporary file of the journal entries not yet committed to the journal
5) In addition to providing a menu that allowed the user to choose the core options:
    1. I provided an option to load a different random prompt if they didn't like the first one
    2. Provided an option to hand pick a prompt from a list of the prompts
    3. Provided an option to display the temporary file of entries not saved to the journal yet.
    4. Provided an option to diplay any given range of dates with journal entries
    5. Provided an option to start an autoprompter that sends a reminder message, gives a random prompt, and 
    displays the menu on a schedule of every two hours and will run until shut off
    6. Provided the option of turning off the autoprompter
    7. Provided a key word entry of "menu" to take the user back to the main menu 
6) In addition to providing 5 prompts:
    1. I provided 5 more for 10 in total with plans to add a feature for the user to be able to add addtional
    prompts and change or modify the prompts listed.
7) As required my program contains classes for the major components of the program:
    1. In addition I added a class for styling console text
8) In addition to having at least 2 classes in additon to the Program class:
    1. I created 3 additional classes in addition to the 2 extra requred for a total of 5 classes beyond
    the Program class
9) I demonstrated abstraction by using member methods and variables:
    1. My Journal class was responsible for what would be a finished volume or book.
        a. It was responsible for allowing user to read it
        b. It was responsible for allowing a user to add to it
        c. It was responsible for helping a user to search it
    2. My Pen class was responsible for writings in the works (thus titled pen)
        a. It was responsible for allowing user to go over what written so far
        b. Keeping those temporary works organized
        c. It was responsible to help a user make further entries
    3. My Prompt class was responsible for holding and using prompts
        a. It was responsible to randomly display different prompts
        b. It was responsible to allow a user to ask for antoer randomly selected prompt
        c. It was responsible to allow a user to pick any prompt fro a list
        d. It was planned to be responsible for allowing the user to add, subract or edit prompts (ran out of time)
    4. My Initiator class was responsible for initiating prompts throughout the day
        a. It was responsible to be running non-stop
        b. It was responsible for displaying a reminder message to make an entry
        c. It was responsible to display prompts on a schedule
        d. It was responsible for starting the menu and application
        e. It was responsible for shutting itself off
    5. My Menu class was responsible for providing an interface for the user
        a. It was responsible for displaying the menu options
        b. It was responsible for communicating to the user what was going on
        c. It was responsible for connecting the actions to the menu
        d. It was responsible for organizing everyting
    6. The Program class was just responsible for starting the running of the code
*/ 

// class to run the Journal application
class Program
{
    // main method to run the Journal application
    static void Main(string[] args)
    {
        // create a Menu object to be able to
        // call and use its methods
        Menu menu = new Menu();
        // call the transition method to run
        // the journal program
        menu.Transition("menu");

        // ### THIS WAS CREATED WITH THE IDEA OF
        // ALLOWING A USER TO ADD PROMPTS TO THE
        // PROMPTS LIST, BUT THE FULL FEATURE IS
        // NOT YET ADDED 
        // create a Prompt object to be able to 
        // call and use its methods
        Prompt prompts = new Prompt();
        // call the UpdateLog method 
        // to update the entry backup list
        prompts.UpdateLog(prompts._inUsePromptList);  
    }    
}