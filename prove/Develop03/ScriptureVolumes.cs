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
  private string _JsonOldTestament;
  // string variable to hold the New Testament json string file
  private string _JsonNewTestament;
  // string variable to hold the Book of Mormon json string file
  private string _JsonBookOfMormon;
  // string variable to hold the New Testament json string file
  private string _JsonDoctrineAndCovenants;
  // string variable to hold the Book of Mormon json string file
  private string _JsonPearlOfGreatPrice;
// ### CONSTRUCTORS ######################################### //
  // construtor that build the string value of the volume paths
  public ScriptureVolumes()
  {
    // build the path from Path class methods so it will find the correct 
    // correct path on any computer - on my computer this is the file path
    // @"D:\Users\Owner\Documents\#1 Learning Resources\Programming Languages\
    // CSE210-Projects\scriptures-json\flat\(scriputre volume name).json";

    // ### USED TO HELP BUILD ALL SCRIPTURE VOLUME PATHS
    // this is the path of the folder holding the repository starting 
    // from the directory you are running the program code from
    string repositoryPath = Directory.GetParent((Directory.GetParent(Directory.GetCurrentDirectory())).ToString()).ToString();
    // ### OLD TESTAMENT ENDING PATH ONLY
    // this is the path of the submodule's json scriputure volume on my computer 
    // using Path.GetFullPath to get it except for the drive D:(rest of path below)
    string submodulePathOT = @"\scriptures-json\flat\old-testament-flat.json";         
    // add the repository Path to the submodulePath for the correct file path
    // hopefully that resulted in the correct file path for your computer
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
    _filePathNewTestament = Path.Join(repositoryPath, submodulePathDandC);
    // ### PEARL OF GREAT PRICE ENDING PATH ONLY
    // this is the path of the submodule's json scriputure volume on my computer 
    // using Path.GetFullPath to get it except for the drive D:(rest of path below)    
    string submodulePathPofGP = @"\scriptures-json\flat\pearl-of-great-price-flat.json";         
    // add the repository Path to the submodulePath for the correct file path
    // hopefully that resulted in the correct file path for your computer
    _filePathNewTestament = Path.Join(repositoryPath, submodulePathPofGP);  
  }

// ### METHODS ############################################## //
  // getter method for the _filePathOldTestament
  public string GetfilePathNewTestament()
  {    
    return _filePathNewTestament;
  }

  // getter method for the _filePathNewTestament
  public string GetfilePathOldTestament()
  {    
    return _filePathOldTestament;
  }

  // getter method for the _filePathBookOfMormon
  public string GetfilePathBookOfMormon()
  {    
    return _filePathBookOfMormon;
  }

  // getter method for the _filePathDoctrineAndCovenants
  public string GetfileDoctrineAndCovenants()
  {    
    return _filePathDoctrineAndCovenants;
  }

  // getter method for the _filePathPearlOfGreatPrice
  public string GetfilePearlOfGreatPrice()
  {    
    return _filePathPearlOfGreatPrice;
  }
}