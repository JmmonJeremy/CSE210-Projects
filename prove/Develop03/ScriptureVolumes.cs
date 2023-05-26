using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

// ### CLASS ################################################ //
// class to retrieve and hold all the scripture volumes
public class ScriptureVolumes
{
// ### VARIABLE ATTRIBUTES ################################## //
  // string variable to hold the file path to the Old Testament
  // json file, as well as the file name
  private string _filePathOldTestament;
  // string variable to hold the file path to the New Testament
  // json file, as well as the file name
  private string _filePathNewTestament;
  // string variable to hold the file path to the New Testament
  // json file, as well as the file name
  private string _filePathBookOfMormon;
  // string variable to hold the file path to the New Testament
  // json file, as well as the file name
  private string _filePathDoctrineAndCovenants;
  // string variable to hold the file path to the New Testament
  // json file, as well as the file name
  private string _filePathPearlOfGreatPrice;
  // string variable to hold the Old Testament json string file
  private string _jsonOldTestament;
  // string variable to hold the New Testament json string file
  private string _jsonNewTestament;
  // string variable to hold the Book of Mormon json string file
  private string _jsonBookOfMormon;
  // string variable to hold the Doctine and Covenants json string file
  private string _jsonDoctrineAndCovenants;
  // string variable to hold the Pearl of Great Price json string file
  private string _jsonPearlOfGreatPrice;
// ### CONSTRUCTORS ######################################### //
  // construtor that builds the string value of the volume paths variables
  // and fills the volume variables with their respective volumes string json
  public ScriptureVolumes()
  {
    // build the path from Path class methods so it will find the correct 
    // correct path on any computer - on my computer this is the file path
    // @"D:\Users\Owner\Documents\#1 Learning Resources\Programming Languages\
    // CSE210-Projects\scriptures-json\flat\(scriputre volume name).json";

    // ### USED TO HELP BUILD ALL SCRIPTURE VOLUME PATHS
    // this is the path of the folder holding the repository starting 
    // from the directory you are running the program code from
    // reference source: https://yetanotherchris.dev/csharp/6-ways-to-get-the-current-directory-in-csharp/ 
    // & https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getparent?view=net-7.0 &
    // https://stackoverflow.com/questions/6875904/how-do-i-find-the-parent-directory-in-c
    string repositoryPath = Directory.GetParent((Directory.GetParent(Directory.GetCurrentDirectory())).ToString()).ToString();
    // ### OLD TESTAMENT ENDING PATH ONLY
    // this is the path of the submodule's json scriputure volume on my computer 
    // using Path.GetFullPath to get it except for the drive D:(rest of path below)
    // reference source: https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath?view=net-7.0
    string submodulePathOT = @"\scriptures-json\flat\old-testament-flat.json";         
    // add the repository Path to the submodulePath for the correct file path
    // hopefully that resulted in the correct file path for your computer
    // reference source: https://learn.microsoft.com/en-us/dotnet/api/system.io.path.join?view=net-7.0#system-io-path-join(system-readonlyspan((system-char))-system-readonlyspan((system-char)))
    _filePathOldTestament = Path.Join(repositoryPath, submodulePathOT);
    // ### NEW TESTAMENT ENDING PATH ONLY
    // this is the path of the submodule's json scriputure volume on my computer 
    // using Path.GetFullPath to get it except for the drive D:(rest of path below)    
    string submodulePathNT = @"\scriptures-json\flat\new-testament-flat.json";         
    // add the repository Path to the submodulePath for the correct file path
    // hopefully that resulted in the correct file path for your computer
    _filePathNewTestament = Path.Join(repositoryPath, submodulePathNT); 
    // ### BOOK OF MORMON ENDING PATH ONLY
    // this is the path of the submodule's json scriputure volume on my computer 
    // using Path.GetFullPath to get it except for the drive D:(rest of path below)    
    string submodulePathBofM = @"\scriptures-json\flat\book-of-mormon-flat.json";         
    // add the repository Path to the submodulePath for the correct file path
    // hopefully that resulted in the correct file path for your computer
    _filePathBookOfMormon = Path.Join(repositoryPath, submodulePathBofM); 
    // ### DOCTRINE AND COVENANTS ENDING PATH ONLY
    // this is the path of the submodule's json scriputure volume on my computer 
    // using Path.GetFullPath to get it except for the drive D:(rest of path below)    
    string submodulePathDandC = @"\scriptures-json\flat\doctrine-and-covenants-flat.json";         
    // add the repository Path to the submodulePath for the correct file path
    // hopefully that resulted in the correct file path for your computer
    _filePathDoctrineAndCovenants = Path.Join(repositoryPath, submodulePathDandC);
    // ### PEARL OF GREAT PRICE ENDING PATH ONLY
    // this is the path of the submodule's json scriputure volume on my computer 
    // using Path.GetFullPath to get it except for the drive D:(rest of path below)    
    string submodulePathPofGP = @"\scriptures-json\flat\pearl-of-great-price-flat.json";         
    // add the repository Path to the submodulePath for the correct file path
    // hopefully that resulted in the correct file path for your computer
    _filePathPearlOfGreatPrice = Path.Join(repositoryPath, submodulePathPofGP);
    // reference source: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.readalltext?view=net-7.0
    // & https://stackoverflow.com/questions/7387085/how-to-read-an-entire-file-to-a-string-using-c
    // read the whole Old Testament into the json string file
    _jsonOldTestament = File.ReadAllText(_filePathOldTestament);
    // read the whole the New Testament into the json string file
    _jsonNewTestament = File.ReadAllText(_filePathNewTestament);
    // read the whole Book of Mormon into the json string file
    _jsonBookOfMormon = File.ReadAllText(_filePathBookOfMormon);
    // read the whole Doctrine and Covenants into the json string file
    _jsonDoctrineAndCovenants = File.ReadAllText(_filePathDoctrineAndCovenants);
    // read the whole Pearl of Great Price into the json string file
    _jsonPearlOfGreatPrice = File.ReadAllText(_filePathPearlOfGreatPrice);  
  }

// ### METHODS ############################################## //
  // getter method for the _jsonOldTestament
  public string GetJsonOldTestament()
  {    
    return _jsonOldTestament;
  }

  // getter method for the _jsonNewTestament
  public string GetJsonNewTestament()
  {    
    return _jsonNewTestament;
  }

  // getter method for the _jsonBookOfMormon
  public string GetJsonBookOfMormon()
  {    
    return _jsonBookOfMormon;
  }

  // getter method for the _jsonDoctrineAndCovenants
  public string GetJsonDoctrineAndCovenants()
  {    
    return _jsonDoctrineAndCovenants;
  }

  // getter method for the _jsonPearlOfGreatPrice
  public string GetJsonPearlOfGreatPrice()
  {    
    return _jsonPearlOfGreatPrice;
  }


}