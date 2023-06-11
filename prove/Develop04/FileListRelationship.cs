using System;
using System.IO;

// ### CLASS ################################################ //
// class for functions that deal with file and list interactions
public class FileListRelationship
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // no variables needed yet
// ### CONSTRUCTORS ######################################### //
  // no constructors needed yet
// ### METHODS ############################################## //
  // method to save a list to a file to keep the list the same when a program is restarted
  public void ListToFile(List<string> list, string file)
  {
    // create a StreamWriter object holding a file
     using (StreamWriter createFile = new StreamWriter(file))
      {  
        // loop through the list    
        foreach (var entry in list)
        {
          // write each list entry to the file as a line
          createFile.WriteLine(entry);
        }
      }
  }
  
  // method to convert a file into a list
  public void FileToList(string file, List<string> list) 
  {    
    // double check if file exists 1st
    if (File.Exists(file))
    {   
      // load all file entries to a string list    
      string[] entries = System.IO.File.ReadAllLines(file);
      // show the string list length - used for debugging
      // Console.WriteLine($"The file to string length is {entries.Count()}");
      // make sure the file is not empty
      if (entries.Count() > 0)
      {
        // clear list before filling it 
        list.Clear();     
        // loop through the newly created list object
        foreach (string entry in entries) 
        {                   
          // add each line into the list as an entry    
          list.Add(entry);    
        } 
      }       
    }
  }
}