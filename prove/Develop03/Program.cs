using System;

// class to run the program
class Program
{
    // method that runs the program
    static void Main(string[] args)
    {         
        // // ### PROGRAM DESCRIPTION ##################################    
        // create setUp object to access its method
        SetUp setUp = new SetUp();
        // run the ProgramDescription method to show intro
        setUp.ProgramDescription();

        // // ### CHOOSING SCRIPTURE REFERENCE #########################        
        // create Source object to access its methods
        Source sourceMethods = new Source();      
        // run the SetSource method to set the source    
        sourceMethods.SetSource();
        // create variable to pass the source string around
        string source = sourceMethods.GetSource();
       
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