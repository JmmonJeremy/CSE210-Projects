using System;

// class to run the program
class Program
{
    // method that runs the program
    static void Main(string[] args)
    {         
        // ### PROGRAM DESCRIPTION ##################################    
        // put a line above the explanation
        Console.WriteLine("______________________________________________________________________________");
        // color the text to make sure the user sees the instructions
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        // explain how the program works with 2 empty lines afterwards
        Console.WriteLine("This program is designed to help you memorize any scripure of your choice.");
        // color the text to make sure the user sees the instructions
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("It does so by replacing one word with a placeholder each time you press enter.");
         // return the text color to yellow to make sure the user sees the instructions
        Console.ForegroundColor = ConsoleColor.DarkYellow; 
        Console.WriteLine("The program ends when all of the words are replaced or when 'quit' is entered.\n");
        // reset the text color to previous settings
        Console.ResetColor();

        // ### CHOOSING SCRIPTURE REFERENCE #########################
        // create a variable to hold the opening selection
        // and to run the while loop until the condition is met
        string answer = "Run loop";
        // set confirmation to != yes or no so
        // the while loop will run to confirm
        // from the ConfirmAnswer method
        string confirmed = "Run loop"; 
        // create a Source object to access its methods
        Source sourceMethods = new Source();
        // create variable to hold the reference created in the if/else 
        // statement below to pass into the Chalkboard's constructor
        string source;
        // create a while loop to run until the selection is verified
        while (confirmed != "yes")
        { 
            // create a while loop to run until 1 or 2 is entered
            while (answer != "1" && answer != "2")
            {
                // Communicate options to the user        
                Console.WriteLine($"The last scripture you used was -- ");
                Console.WriteLine("To reuse -- select the option below by entering its option number:");
                Console.WriteLine(" 1 - Reuse --");
                Console.WriteLine(" 2 - Use a different scripture");
                // show user where to enter their selection
                Console.Write("Selection: ");        
                // capture user choice in a variable
                answer = Console.ReadLine();
                // put an empty space between statements
                Console.WriteLine();
                // if user entry is not one of the choices
                if (answer != "1" && answer != "2")
                {
                    Console.WriteLine($"{answer} is not a valid entry. You must enter 1 or 2, please try again.\n");                    
                }
            }
            // do this from the ConfirmAnswer method
            // until yes is the outcom
            confirmed = sourceMethods.ConfirmAnswer(confirmed, answer);       
            // if they didn't confirm their choice loop starts over
            if (confirmed == "no")
            {
                // set ConfirmAnswer method to run again
                confirmed = "Run loop"; 
                // set while loop to run again
                answer = "Run loop";
            } 
        }   
        // put an empty space between statements
        Console.WriteLine();
        // add a condition to avoid entering scritpure reference
        // and to use the last scripture entered instead if desired
        // ### GETTING SCRIPTURE SOURCE FROM LAST USE ###############
        if (answer == "1")
        {            
            // load the values of the last scripture reference into the sourceMethods 
            // object by using the LoadLastScripture method from the Source class
            sourceMethods.LoadLastScripture();
            // put the reference source together in a string
            // and store in a variable to pass into Chalkboard constructor
            Console.WriteLine();
            source = $"\n({sourceMethods.GetVolume()})\n\n{sourceMethods.GetBook()} {sourceMethods.GetChapter()}:{sourceMethods.GetVerse()}";
        }
        // ### GETTING SCRIPTURE SOURCE FROM USER ###################
        else
        {   
            // get the name of the volume the scripture comes from           
            // run the setVolume method with the sourceMethods object
            // to have the user set the string value of the volume
            sourceMethods.SetVolume();
            // run the setBook method with the sourceMethods object
            // to have the user set the string value of the book
            sourceMethods.SetBook();
            // run the setChapter method with the sourceMethods object
            // to have the user set the string value of the chapter
            sourceMethods.SetChapter();
            // run the setVerse method with the sourceMethods object
            // to have the user set the string value of the verse
            sourceMethods.SetVerse();
            // run the setEndVerse method with the sourceMethods object to
            // have the user set the string value of the verse if there is one
            sourceMethods.SetEndVerse();

            // if there isn't an end verse
            if (string.IsNullOrEmpty(sourceMethods.GetEndVerse()))
            {
                // put the reference source together in a string
                // and store in a variable to pass into Chalkboard constructor
                Console.WriteLine();
                source = $"\n({sourceMethods.GetVolume()})\n\n{sourceMethods.GetBook()} {sourceMethods.GetChapter()}:{sourceMethods.GetVerse()}";
            }
            // if there is an end verse
            else
            {
                // put the reference source together in a string
                // and store in a variable to pass into Chalkboard constructor
                Console.WriteLine();
                source = $"\n({sourceMethods.GetVolume()})\n\n{sourceMethods.GetBook()} {sourceMethods.GetChapter()}:{sourceMethods.GetVerse()}-{sourceMethods.GetEndVerse()}";
            }
        }
        // TODO put in getting scripture form API
        // get the scripture into a variable
        string scripture = "Jesus said unto her, I am the resurrection, and the life: he that believeth in me, though he were dead, yet shall he live:";
        // load the source and the scripture into the 
        // chalkboard constructor to create an object
        Chalkboard chalkboard = new Chalkboard(source, scripture);
        // load the scripture word list into a variable
        List<string> scriptureWords = chalkboard.GetVerse();

        // ############## sort this area out into classes
        // variable to count rotations of hiding words in while/loop 
        // start at -1 so the first while/loop isn't counted
        // because words aren't blanked out until the 2nd loop
        int rotations = -1;        
        // set variable for the amount of items in a list
        int count = scriptureWords.Count;
        // create a random object for randomly hiding the words 
        Random randomGenerator = new Random();           
        // randomly select the list index for the prompt        
        int index = randomGenerator.Next(0, count);
        // create a variable to represent quit being entered
        string quit = "Run loop";
        // create a variable to count the total number of words that
        // have been hidden to compare with the count of the 
        // scriptureWords list count to know when to shut down 
        int hideNum = 0;
     

        // Chalk writeWord = new Chalk("hi", false);
        // create another list to hold all the words        
        List<Chalk> eachWord = new List<Chalk>();

        // load eachWord Chalk list with scriptureWords
        foreach (string word in scriptureWords)
        {
            Chalk writeWord = new Chalk(word, false);
            eachWord.Add(writeWord);
        }

        // create a loop to run until the user enters "quit"
        // or until all the words in the scripture are covered
        while (quit != "quit" && rotations != count)
        {    
            // reset the hideNum variable to -1 so the count
            // starts at one in the foreach count of hidden words
            hideNum = 0;   
            // count the rotations to avoid hiding 
            // a word the first time
            rotations += 1;
            // randomly select the list index for the prompt 
            index = randomGenerator.Next(0, count);
            // clear the console screen
            Console.Clear();
            // display the scritpure source
            Console.Write($"{source}  ");

            // set a parameter to stop after all the words are hidden
            foreach (Chalk labeledWord in eachWord)
            {
                if (labeledWord.GetHide())
                {
                    hideNum += 1;
                }
            }                
            if (hideNum == count)
            {   
                foreach (Chalk labeledWord in eachWord)
                {
                Eraser erase = new Eraser(labeledWord.GetWord());
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Write(erase.GetPlaceHolder());
                Console.ResetColor();
                Console.Write(" ");
                }
                // Console.WriteLine($"Number of words hidden: {hideNum} == Number of words in the scripture: {count}");
                break;
            }
            

            List<Chalk> hideWords = new List<Chalk>();
            // display the scripture to the screen
           
            bool hidOne = false;

            for (int i = 0; i < count; i++)
            {             
                if (eachWord[i].GetHide())
                {
                    Eraser erase = new Eraser(eachWord[i].GetWord());
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write(erase.GetPlaceHolder());
                    Console.ResetColor();
                    Console.Write(" ");
                }
                else
                {
                   Console.Write($"{eachWord[i].GetWord()} "); 
                }                             
                    if (eachWord[i].GetHide() && index == i && index + 1 < count)
                    {
                        index += 1;                       
                    }                                                                
                if (index == i && eachWord[i].GetHide() == false)
                {                   
                    eachWord[i].SetHide(true);
                    hidOne = true;
                    // hideNum += 1;
                }  
                if (i == count -1 && hidOne == false && rotations != 1)
                {
                    // Console.ForegroundColor = ConsoleColor.Cyan;
                    // Console.Write($"Set by foreach loop!!! {rotations}");
                    // Console.ResetColor();
                    foreach (Chalk word in eachWord)
                    {
                        if (word.GetHide() == false)
                        {
                            word.SetHide(true);
                            // hideNum += 1;
                            break;
                        }
                    }
                }              
              
            }
       
          
            // add two empty lines after the scritpure
            Console.WriteLine("\n");
            // display instructions for the user
            Console.Write("Press enter to hide a word or enter 'quit' to exit: ");
            // gather and use the input from the user
            quit = Console.ReadLine();
            // replace a word if they press enter

                 
        }         
    }
}