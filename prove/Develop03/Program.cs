/*
Requirements and what I did to exceed the requirements
1) Use the principles of Encapsulation and use good style
    1- I used the principles of encapsulation, making all of my attributes private and keeping all of the 
    setting of attributes within their class. Using encapsulation really helped me to more tightly confine 
    related code within classes.
2) Have at least 3 classes in addition to the Program class for #1 the scripture, #2 the reference, #3 a word 
    -2 I had those basic extra 3 classes as #1 Chalkboard, #2 Source, #3 Chalk - in addition I also had
       a #4 Eraser, #5 SetUp, #6 ScriptureVolumes, #7 Verses, & #8 Verse class. The Eraser class was in charge
       of subsituting a placeholder in place of the word. The SetUp class was in charge of setting things up to
       work and run together. The ScriptureVolumes class was in charge of holding the volumes of scripture and 
       their file pathways and links. The Verses and Verse classes were for matching the patter of the Json files
       and turning their data into loaded classes.
3) Provide multiple consructors for the scripture reference to handle the case of a single vers and a verse range
    -3 I provided 3 constructors for the Source class: one just for calling methods, and the two others to fulfill
       the requirement above for a single vers and for a verse range.

Other additional things I did to exceed the requirements were:
1) I set up a menu so that you could load the last scripture you had been working on just by selecting that choice
2) I put in tons of answer validations throughout the program
3) I put in try/catch and if statements to weed out or stop errors from happening
4) I added a submodule of a git repository with all of the scripture files in json form. I then ran methods to get
the location of the file instead of hardcoding it so that the file path would be correct no matter who's computer 
the file was being run on. I also put in backup file loading using HttpClient and WebClient in case the file path
didn't work for some reason (I did that in large part because I wanted to learn how to get json data from a website
using the C# language but also to try and make sure the scripture volumes would be available to the user).
5) I put in a program where the user enters any scripture verses they are wanting to memorize and they will be
automatically loaded into the program.
6) For the word placeholders I put in a method to replace each letter with an underscore so the placeholder is
the exact same size as the original word. I also made the area where the word was be a diffent color to make it
look like the word is being covered up.
7) I also put in a way for the user to restart if they put in an incorrect scripture reference by using the 
keyword "restart"
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

// ### CLASS ################################################ //
// class to run the program
class Program
{
// ### VARIABLE ATTRIBUTES ################################## //
// bool to restart everything if needed
private bool _restart = false;

// ### METHODS ############################################## //
    // method that runs the program
    static void Main(string[] args)
    {      
        // Test CODE      

// ###############################################################################################
        // create a program object to access the _restart private variable
        Program program = new Program();
        // set up a loop to run if the user enters an incorrect reference
        do
        {
        // ### PROGRAM DESCRIPTION ##################################    
        // create setUp object to access its method
        SetUp setUp = new SetUp();
        // run the ProgramDescription method to show intro
        setUp.ProgramDescription();

        // ### CHOOSING SCRIPTURE REFERENCE #########################        
        // create Source object to access its methods
        Source sourceMethods = new Source();      
        // run the SetSource method to set the source    
        sourceMethods.SetSource();
        // get the ending verse stored in a variable
        string endVerse = sourceMethods.GetEndVerse();
        // get the source with one verse stored in a variable
        string source = sourceMethods.GetSource();
        // get the final source with or without an endVerse
        string finalSource = setUp.SetUpSource(endVerse, source);
        // load the _startReference variable to be able to get it
        sourceMethods.SetStartReference();
        // load the _endReference variable to be able to get it
        sourceMethods.SetEndReference();       
        // load the scripture or list of scriptures into a string variable
        string scripture = setUp.SetUpScripture(sourceMethods.GetVolume(), sourceMethods.GetStartReference(), sourceMethods.GetEndReference());       
               
        // // ### RUN THE SCRIPTURE MEMORIZER ##########################
        // load the source and the scripture into the 
        // chalkboard constructor to create an object
        Chalkboard chalkboard = new Chalkboard(finalSource, scripture);
        // load the scripture word list into a variable
        List<string> scriptureWords = chalkboard.GetScriptureWords();
        // load _eachWord Chalk list with words from the 
        // scriptureWords list while setting _hide to false
        // and set the boolean for the do/while loop to run
        // if the user entered a bad reference for a verse
        program._restart = chalkboard.SetEachWord();
        // get the _eachWord list
        List<Chalk> eachWord = chalkboard.GetEachWord();       
        // set up a loop to display the source and scripture repeatedly
        // until all the words are hidden or quit is entered by the user
        setUp.QuitLoop(eachWord, finalSource, scripture);
        }
        // condition for running the loop when user enters incorrect reference
        while (program._restart == true);
    }

    // setter method to set the _restart bolean
    public void SetRestart(bool state)
    {
        _restart = state;
    }

    // getter method for the _restart
    public bool GetRestart()
    {
        return _restart;
    }
}
