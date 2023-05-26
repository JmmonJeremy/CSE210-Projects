using System;
using System.Text.Json.Serialization;

// ### CLASS ################################################ //
// class to use to get the selected verse
// or verses for the JSON scripture files
// reference source: https://www.youtube.com/watch?v=SholKTNGdHk
public class Verses
{  
// ### VARIABLE ATTRIBUTES ################################## //
    // this is as private as is allowed for attributes when using Serializaton
    // reference source: https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/immutability?pivots=dotnet-7-0  
    // list to hold the list from the json scripture volume with name matching json key word
    // the list name cannot be _verses or the Deserialization process will not work
    [JsonInclude]
    // using auto-implemented properties
    // reference source: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
    public List<Verse> verses {get; private set;}

// ### METHODS ############################################## //
    // method to find the verse the user selected
    public string FindVerse(string verseRef)
    {    
        // string to return the scripture verse or a not found message 
        // with a message at the end telling the user how to start over
        string foundVerse = "!!! The reference you entered could not be found.\n\n\nTo try again enter 'restart'";
        // loop through the list
        foreach(Verse verse in verses)
        {
            // when the source entered equals the 
            // Verse class object's reference 
            if (verse.reference == verseRef)
            {
                // set the foundVerse string equal to 
                // the Verse class object's text
                foundVerse = verse.text;
            }
        }
        // return the verse's text
        return foundVerse;
    }

    // method to return the verses the user selected
    public List<string> FindVerses(string startRef, string endRef)
    {           
        // variable to represent the count
        int count = verses.Count; 
        // variable for the index # of the verses' starting reference
        int startRefIndex = 0;
        // variable for the index # of the verses' ending reference 
        int endRefIndex = 0;
        // bolean to show wether the verses' starting reference was found
        bool gotStartRef = false;
        // bolean to show wether the verses' ending reference was found
        bool gotEndRef = false;
        // bolean to show wether both the verses' references were found
        bool listed = true;
        // variable to diplay the string value entered by the 
        // user for the starting reference if it couldn't be found
        string noStartRef = $"{endRef} could not be found.";
        // variable to diplay the string value entered by the  
        // user for the ending reference if it couldn't be found
        string noEndRef = $"{endRef} could not be found.";
        // variable to hold a message letting the user know why their selection
        // wasn't displayed for them to use with the scripture memorizer
        string missingRef = "!!! There was a problem with the references you entered.";
        // list to return the selected verses or the error messages
        List<string> foundVerses = new List<string>();
        // cycle through the list of scriptures from the volume
        for (int i = 0; i < count; i++)
        {          
            // when the verses' starting reference equals
            // the Verse object's reference string value
            if (verses[i].reference == startRef)
            {
                // store the index number in the starting 
                // reference index variable for later use            
                startRefIndex = i;
                // indicate that the verses' starting reference was found
                gotStartRef = true;                         
            }
            // when the verses' ending reference equals
            // the Verse object's reference string value
            if (verses[i].reference == endRef)
            {
                // store the index number in the ending 
                // reference index variable for later use    
                endRefIndex = i;
                // indicate that the verses' starting reference was found
                gotEndRef = true;               
            } 
            // after the last verse in the list is checked for a match, if the
            // starting reference was found, but the ending reference wasn't   
            if (i == (count-1) && gotStartRef && !gotEndRef)
            {
                // indicates that one of the references wasn't found
                listed = false;                
                // let the user know what string end reference wasn't found
                foundVerses.Add(noEndRef);
                // let the user know what string start reference was found
                foundVerses.Add($"{startRef} was found.");
            }
            // after the last verse in the list is checked for a match, if the
            // ending reference was found, but the starting reference wasn't   
            if (i == (count-1) && !gotStartRef && gotEndRef)
            {
                // indicates that one of the references wasn't found
                listed = false;               
                // let the user know what string start reference wasn't found
                foundVerses.Add(noStartRef);
                // let the user know what string end reference was found
                foundVerses.Add($"{endRef} was found.");
            }
            // after the last verse in the list is checked for a match, if the
            // starting reference and the ending reference were both not found 
            if (i == (count - 1) && !gotStartRef && !gotEndRef)
            {               
                // indicates that both of the references weren't found
                listed = false;               
                // let the user know what string start reference wasn't found
                foundVerses.Add(noStartRef);                
                // let the user know what string end reference wasn't found
                foundVerses.Add(noEndRef);
            }
            // if either or both of the verses' references were not found
            if (i == (count - 1) && !listed)
            {
                // insert this message at the beginning of the list
                // so that it is the beginning of the error message
                foundVerses.Insert(0, missingRef); 
                // add a message at the end telling them how to start over
                foundVerses.Add("\n\nTo try again enter 'restart'");
            }
            // if both of the verses's references were found
            if (gotStartRef && gotEndRef)
            {
                // cycle through those only those verses
                for (i = startRefIndex; i <= endRefIndex; i++)
                {                    
                    // and add those verses to the list
                    foundVerses.Add(verses[i].text);                    
                }               
                // end the search
                break;
            }        
        }
        // return the list to be displayed
        return foundVerses;
    }
}