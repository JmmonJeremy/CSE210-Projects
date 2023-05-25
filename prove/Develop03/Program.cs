using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

// ### CLASS ################################################ //
// class to run the program
class Program
{
// ### METHODS ############################################## //
    // method that runs the program
    static void Main(string[] args)
    {      
        // Test Json
        string filePath = @"D:\Users\Owner\Documents\#1 Learning Resources\Programming Languages\CSE210-Projects\scriptures-json\flat\new-testament-flat.json";
        var versesJson = File.ReadAllText(filePath);
        // Verses verses = new Verses();
        Verses verses = JsonSerializer.Deserialize<Verses>(versesJson); 
        string request = verses.FindVerse("Revelation 22:21");
        Console.WriteLine(request);
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
        // create variable to pass the source string around
        string source = sourceMethods.GetSource();
       
        // TODO put in getting scripture form API        
       
        // get the scripture into a variable
        string scripture = "Jesus said unto her, I am the resurrection, and the life: he that believeth in me, though he were dead, yet shall he live:";

        // // ### RUN THE SCRIPTURE MEMORIZER ##########################
        // load the source and the scripture into the 
        // chalkboard constructor to create an object
        Chalkboard chalkboard = new Chalkboard(source, scripture);
        // load the scripture word list into a variable
        List<string> scriptureWords = chalkboard.GetScriptureWords();
        // load _eachWord Chalk list with words from the 
        // scriptureWords list while setting _hide to false
        chalkboard.SetEachWord();
        // get the _eachWord list
        List<Chalk> eachWord = chalkboard.GetEachWord();       
        // set up a loop to display the source and scripture repeatedly
        // until all the words are hidden or quit is entered by the user
        setUp.QuitLoop(eachWord, source, scripture);
    }
}

        // // ############## sort this area out into classes
        // // variable to count rotations of hiding words in while/loop 
        // // start at -1 so the first while/loop isn't counted
        // // because words aren't blanked out until the 2nd loop
        // int rotations = -1;        
        // // set variable for the amount of items in a list
        // int count = scriptureWords.Count;
        // // create a random object for randomly hiding the words 
        // Random randomGenerator = new Random();           
        // // randomly select the list index for the prompt        
        // int index = randomGenerator.Next(0, count);
        // // create a variable to represent quit being entered
        // string quit = "Run loop";
        // // create a variable to count the total number of words that
        // // have been hidden to compare with the count of the 
        // // scriptureWords list count to know when to shut down 
        // int hideNum = 0;
     

        // // Chalk writeWord = new Chalk("hi", false); ????????

        // // ############## ADDED LIST to Chalkboard class
        // // create another list to hold all the words        
        // List<Chalk> eachWord = new List<Chalk>();

        // // ############# PUT IN SetEachWord() method in the Chalkboard class
        // // load eachWord Chalk list with words from
        // // the _scriptureWords list & set bool value to false
        // foreach (string word in scriptureWords)
        // {
        //     Chalk writeWord = new Chalk(word, false);
        //     eachWord.Add(writeWord);
        // }

        // // ######### PUT IN QuitLoop method in the SetUp class
        // // create a loop to run until the user enters "quit"
        // // or until all the words in the scripture are covered
        // while (quit != "quit" && rotations != count)
        // {    
        //     // reset the hideNum variable to 0 so that it
        //     // counts the list total marked as _hide = true
        //     hideNum = 0;   
        //     // count the rotations to avoid hiding 
        //     // a word the first time
        //     rotations += 1;
        //     // randomly select the list index for the prompt 
        //     index = randomGenerator.Next(0, count);

        //     // ########### PUT IN  DisplayScripture method in the Chalkboard class
        //     // clear the console screen
        //     Console.Clear();
        //     // display the scritpure source
        //     Console.Write($"{source}  ");

        //     // ############ PUT IN the SetAllHidden method in the Chalkboard class
        //     // cycle through the Chalk objects to add up
        //     // all the hide boleans that are set to true
        //     foreach (Chalk labeledWord in eachWord)
        //     {
        //         // when hide bolean is set to true
        //         if (labeledWord.GetHide())
        //         {
        //             // set the changeCount variable value for one of the conditions
        //             // to stop the while/loop after all the words are hidden
        //             hideNum += 1;
        //         }
        //     }

        //     // ################## PUT IN the QuitLoop method in the SetUp class
        //     // when the condition of the changes being done to 
        //     // every item in the list happen do this                
        //     if (hideNum == count)
        //     {   
        //         // cycle through all of the Chalk objects
        //         foreach (Chalk labeledWord in eachWord)
        //         {
        //             // ############ PUT IN the EraseAllWords in the Chalkboard class
        //             // create an Eraser object & pass the Chalk object into it
        //             Eraser erase = new Eraser(labeledWord.GetWord());
        //             // Change the background color on the screen to dark gray
        //             Console.BackgroundColor = ConsoleColor.DarkGray;
        //             // display the erase object's _placeHolder to the 
        //             // console screen instead of the Chalk object's word
        //             Console.Write(erase.GetPlaceHolder());
        //             // reset the background color to original setting
        //             Console.ResetColor();
        //             // add a space after the placeholder
        //             Console.Write(" ");
        //         }
        //         // Console.WriteLine($"Number of words hidden: {hideNum} == Number of words in the scripture: {count}");
        //         break;
        //     }
            

        //     // List<Chalk> hideWords = new List<Chalk>();
        //     // display the scripture to the screen
           

        //     // to show if a word has just been hidden
        //     bool hidOne = false;

        //     // ############ PUT IN the EraseMarkedWords in the Chalkboard class
        //     // loop through list of eachWord Chalk objects
        //     for (int i = 0; i < count; i++)
        //     {    
        //         // ############ PUT IN the EraseRandomWords in the Chalkboard class 
        //         // if Chalk object is marked as true to hide 
        //         if (eachWord[i].GetHide())
        //         {                    
        //             // create an Eraser object & pass the Chalk object into it
        //             Eraser erase = new Eraser(eachWord[i].GetWord());
        //             // Change the background color on the screen to dark gray
        //             Console.BackgroundColor = ConsoleColor.DarkGray;
        //             // display the erase object's _placeHolder to the 
        //             // console screen instead of the Chalk object's word
        //             Console.Write(erase.GetPlaceHolder());
        //             // reset the background color to original setting
        //             Console.ResetColor();
        //             // add a space after the placeholder
        //             Console.Write(" ");
        //         }
        //         // if Chalk object is not marked as true to hide
        //         else
        //         {
        //            // display the word to the console screen
        //            Console.Write($"{eachWord[i].GetWord()} "); 
        //         }
        //         // when the Chalk object is already set to true for hide & 
        //         // the random number matches the index & the result of the
        //         // index + 1 = less than the last index number in the list 
        //         if (eachWord[i].GetHide() && index == i && index + 1 < count)
        //         {
        //             // then add one to the random index selection number
        //             index += 1;                       
        //         }  
        //         // when the Chalk obect is set to false for the hide value &
        //         // the random number for selecting an index matches the index               
        //         if (index == i && eachWord[i].GetHide() == false)
        //         {         
        //             // set the Chalk object's hide bolean to true  
        //             eachWord[i].SetHide(true);
        //             // set the hidOne bolean to true
        //             hidOne = true;
        //             // // hideNum += 1;
        //         }
        //         // when it is the last word in the Chalk object list &
        //         // the hide bolean wasn't just marked as true & this    
        //         if (i == count -1 && hidOne == false)
        //         {
        //             // // Console.ForegroundColor = ConsoleColor.Cyan;
        //             // // Console.Write($"Set by foreach loop!!! {rotations}");
        //             // // Console.ResetColor();

        //             // start cycling through the Chalk objects
        //             // objects from the front of the list
        //             foreach (Chalk word in eachWord)
        //             {
        //                 // find the first Chalk object's
        //                 // hide bolean that is set to false
        //                 if (word.GetHide() == false)
        //                 {
        //                     // and set its bolean to true
        //                     word.SetHide(true);
        //                     // // hideNum += 1;
        //                     // then stop the loop
        //                     break;
        //                 }
        //             }
        //         }              
              
        //     }
       
          
        //     // add two empty lines after the scritpure
        //     Console.WriteLine("\n");
        //     // display instructions for the user
        //     Console.Write("Press enter to hide a word or enter 'quit' to exit: ");
        //     // gather and use the input from the user
        //     quit = Console.ReadLine();
        //     // replace a word if they press enter

                 
        // }         
    // }
// }