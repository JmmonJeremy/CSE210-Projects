using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

// ### CLASS ################################################ //
// class to retrieve and hold all the scripture volumes
public class ScriptureVolumes
{
// ### VARIABLE ATTRIBUTES ################################## //
  // string variable to hold the path to the Old Testament web json file
  private string _webLinkOldTestament = "https://raw.githubusercontent.com/bcbooks/scriptures-json/master/flat/old-testament-flat.json";
  // string variable to hold the path to the New Testament web json file
  private string _webLinkNewTestament = "https://raw.githubusercontent.com/bcbooks/scriptures-json/master/flat/new-testament-flat.json";
  // string variable to hold the path to the Book of Mormon web json file
  private string _webLinkBookOfMormon = "https://raw.githubusercontent.com/bcbooks/scriptures-json/master/flat/book-of-mormon-flat.json";
  // string variable to hold the path to the Doctrine and Covenants web json file
  private string _webLinkDoctrineAndCovenants = "https://raw.githubusercontent.com/bcbooks/scriptures-json/master/flat/doctrine-and-covenants-flat.json";
  // string variable to hold the path to the Pearl of Great Price web json file
  private string _webLinkPearlOfGreatPrice = "https://github.com/bcbooks/scriptures-json/blob/master/flat/pearl-of-great-price-flat.json";
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
  // and then can fill json string attributes by using its object to call 
  // the Set & Get "json-volume" methods 
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

    // read the whole Book of Mormon into the json string file
    _jsonBookOfMormon = File.ReadAllText(_filePathBookOfMormon);
    // read the whole Doctrine and Covenants into the json string file
    _jsonDoctrineAndCovenants = File.ReadAllText(_filePathDoctrineAndCovenants);
    // read the whole Pearl of Great Price into the json string file
    _jsonPearlOfGreatPrice = File.ReadAllText(_filePathPearlOfGreatPrice); 
  } 

// ### METHODS ############################################## //
  // getter method for the Old Testament json web link 
  public string GetWebLinkOldTestament()
  {    
    return _webLinkOldTestament;
  }

  // getter method for the New Testament json web link 
  public string GetWebLinkNewTestament()
  {    
    return _webLinkNewTestament;
  }

  // getter method for the Book of Mormon json web link 
  public string GetWebLinkBookOfMormon()
  {    
    return _webLinkBookOfMormon;
  }

  // getter method for the Doctrine and Covenants json web link 
  public string GetWebLinkDoctrineAndCovenants()
  {    
    return _webLinkDoctrineAndCovenants;
  }

  // getter method for the Pearl of Great Price json web link 
  public string GetWebLinkPearlOfGreatPrice()
  {    
    return _webLinkPearlOfGreatPrice;
  }

  // method to set the Old Testament json scripture variable
  public async Task SetJsonOldTestament(string website)
  {
    // ### 1ST TRY to get the volume from the website USING HTTPCLIENT 
    using (var client = new HttpClient())
    {
      // Call asynchronous network methods in a try/catch block to handle exceptions.
      try
      {     
        // wait for the response
        _jsonOldTestament = await client.GetStringAsync(website);          
        // show where the file came from for debugging
        Console.WriteLine("Got this from HttpClient.");       
      }
      // catch errors and handle them
      catch (HttpRequestException e)
      { 
        // communicate what happened for debugging 
        Console.WriteLine("\nException Caught!");
        Console.WriteLine("Message :{0} ", e.Message);
      }     
    }
    // if the HttpClient request returned nothing or did't return a json file
    if (string.IsNullOrEmpty(_jsonOldTestament) || _jsonOldTestament[0] != '{')
    {
      // ### 2nd TRY to get the volume from the website THIS TIME USING WEBCLIENT
      // reference source: https://stackoverflow.com/questions/5566942/how-to-get-a-json-string-from-url & 
      // https://stackoverflow.com/questions/40208647/how-to-use-httpclient-without-async & https://stackoverflow.com/questions/54680159/c-sharp-how-to-retry-if-await-url-getstringasync-null 
      // tool from System.Net used to get the json file from the website
      using (WebClient webClient = new WebClient())
      {   
        // save the whole Old Testament into the json string file
        _jsonOldTestament = webClient.DownloadString(website); 
      } 
    } 
    // if the both web requests returned nothing or did't return a json file   
    if (String.IsNullOrEmpty(_jsonOldTestament) || _jsonOldTestament[0] != '{')
    {
      // ### 3rd TRY to get the volume THIS TIME USING THE FILEPATH TO THE LOCAL FILE 
      // reference source: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.readalltext?view=net-7.0
      // & https://stackoverflow.com/questions/7387085/how-to-read-an-entire-file-to-a-string-using-c *
      // https://stackoverflow.com/questions/34064067/test-for-a-json-file-in-the-bin-folder    
      if (File.Exists(_filePathOldTestament))
      {
        // read the whole Old Testament into the json string file
        _jsonOldTestament = File.ReadAllText(_filePathOldTestament);
        Console.WriteLine("Got it from the local file!");
      }
      else
      {
        // let the user know that neither the web request or the file pathway was good
        _jsonOldTestament = "Neither the web or file download of json file was successful.";
        Console.Write(_jsonOldTestament);
      }
    }    
  }

  // method to set the New Testament json scripture variable
  public async Task SetJsonNewTestament(string website)
  {
    // ### 1ST TRY to get the volume from the website USING HTTPCLIENT 
    using (var client = new HttpClient())
    {
      // Call asynchronous network methods in a try/catch block to handle exceptions.
      try
      {     
        // wait for the response
        _jsonNewTestament = await client.GetStringAsync(website);          
        // show where the file came from for debugging
        Console.WriteLine("Got this from HttpClient.");       
      }
      // catch errors and handle them
      catch (HttpRequestException e)
      { 
        // communicate what happened for debugging 
        Console.WriteLine("\nException Caught!");
        Console.WriteLine("Message :{0} ", e.Message);
      }     
    }
    // if the HttpClient request returned nothing or did't return a json file
    if (string.IsNullOrEmpty(_jsonNewTestament) || _jsonNewTestament[0] != '{')
    {
      // ### 2nd TRY to get the volume from the website THIS TIME USING WEBCLIENT      
      // tool from System.Net used to get the json file from the website
      using (WebClient webClient = new WebClient())
      {   
        // save the whole New Testament into the json string file
        _jsonNewTestament = webClient.DownloadString(website); 
      } 
    } 
    // if the both web requests returned nothing or did't return a json file   
    if (String.IsNullOrEmpty(_jsonNewTestament) || _jsonNewTestament[0] != '{')
    {
      // ### 3rd TRY to get the volume THIS TIME USING THE FILEPATH TO THE LOCAL FILE         
      if (File.Exists(_filePathNewTestament))
      {
        // read the whole New Testament into the json string file
        _jsonNewTestament = File.ReadAllText(_filePathNewTestament);
        Console.WriteLine("Got it from the local file!");
      }
      else
      {
        // let the user know that neither the web request or the file pathway was good
        _jsonNewTestament = "Neither the web or file download of json file was successful.";
        Console.Write(_jsonNewTestament);
      }
    }    
  }

  // method to set the Book of Mormon json scripture variable
  public async Task SetJsonBookOfMormon(string website)
  {
    // ### 1ST TRY to get the volume from the website USING HTTPCLIENT 
    using (var client = new HttpClient())
    {
      // Call asynchronous network methods in a try/catch block to handle exceptions.
      try
      {     
        // wait for the response
        _jsonBookOfMormon = await client.GetStringAsync(website);          
        // show where the file came from for debugging
        Console.WriteLine("Got this from HttpClient.");       
      }
      // catch errors and handle them
      catch (HttpRequestException e)
      { 
        // communicate what happened for debugging 
        Console.WriteLine("\nException Caught!");
        Console.WriteLine("Message :{0} ", e.Message);
      }     
    }
    // if the HttpClient request returned nothing or did't return a json file
    if (string.IsNullOrEmpty(_jsonBookOfMormon) || _jsonBookOfMormon[0] != '{')
    {
      // ### 2nd TRY to get the volume from the website THIS TIME USING WEBCLIENT      
      // tool from System.Net used to get the json file from the website
      using (WebClient webClient = new WebClient())
      {   
        // save the whole Book of Mormon into the json string file
        _jsonBookOfMormon = webClient.DownloadString(website); 
      } 
    } 
    // if the both web requests returned nothing or did't return a json file   
    if (String.IsNullOrEmpty(_jsonBookOfMormon) || _jsonBookOfMormon[0] != '{')
    {
      // ### 3rd TRY to get the volume THIS TIME USING THE FILEPATH TO THE LOCAL FILE         
      if (File.Exists(_filePathBookOfMormon))
      {
        // read the whole Book of Mormon into the json string file
        _jsonBookOfMormon = File.ReadAllText(_filePathBookOfMormon);
        Console.WriteLine("Got it from the local file!");
      }
      else
      {
        // let the user know that neither the web request or the file pathway was good
        _jsonBookOfMormon = "Neither the web or file download of json file was successful.";
        Console.Write(_jsonBookOfMormon);
      }
    }    
  }

  // method to set the Doctrine and Covenants json scripture variable
  public async Task SetJsonDoctrineAndCovenants(string website)
  {
    // ### 1ST TRY to get the volume from the website USING HTTPCLIENT 
    using (var client = new HttpClient())
    {
      // Call asynchronous network methods in a try/catch block to handle exceptions.
      try
      {     
        // wait for the response
        _jsonDoctrineAndCovenants = await client.GetStringAsync(website);          
        // show where the file came from for debugging
        Console.WriteLine("Got this from HttpClient.");       
      }
      // catch errors and handle them
      catch (HttpRequestException e)
      { 
        // communicate what happened for debugging 
        Console.WriteLine("\nException Caught!");
        Console.WriteLine("Message :{0} ", e.Message);
      }     
    }
    // if the HttpClient request returned nothing or did't return a json file
    if (string.IsNullOrEmpty(_jsonDoctrineAndCovenants) || _jsonDoctrineAndCovenants[0] != '{')
    {
      // ### 2nd TRY to get the volume from the website THIS TIME USING WEBCLIENT      
      // tool from System.Net used to get the json file from the website
      using (WebClient webClient = new WebClient())
      {   
        // save the whole Doctrine and Covenants into the json string file
        _jsonDoctrineAndCovenants = webClient.DownloadString(website); 
      } 
    } 
    // if the both web requests returned nothing or did't return a json file   
    if (String.IsNullOrEmpty(_jsonDoctrineAndCovenants) || _jsonDoctrineAndCovenants[0] != '{')
    {
      // ### 3rd TRY to get the volume THIS TIME USING THE FILEPATH TO THE LOCAL FILE         
      if (File.Exists(_filePathDoctrineAndCovenants))
      {
        // read the whole Doctrine and Covenants into the json string file
        _jsonDoctrineAndCovenants = File.ReadAllText(_filePathDoctrineAndCovenants);
        Console.WriteLine("Got it from the local file!");
      }
      else
      {
        // let the user know that neither the web request or the file pathway was good
        _jsonDoctrineAndCovenants = "Neither the web or file download of json file was successful.";
        Console.Write(_jsonDoctrineAndCovenants);
      }
    }    
  }

  // method to set the Pearl of Great Price json scripture variable
  public async Task SetJsonPearlOfGreatPrice(string website)
  {
    // ### 1ST TRY to get the volume from the website USING HTTPCLIENT 
    using (var client = new HttpClient())
    {
      // Call asynchronous network methods in a try/catch block to handle exceptions.
      try
      {     
        // wait for the response
        _jsonPearlOfGreatPrice = await client.GetStringAsync(website);          
        // show where the file came from for debugging
        Console.WriteLine("Got this from HttpClient.");       
      }
      // catch errors and handle them
      catch (HttpRequestException e)
      { 
        // communicate what happened for debugging 
        Console.WriteLine("\nException Caught!");
        Console.WriteLine("Message :{0} ", e.Message);
      }     
    }
    // if the HttpClient request returned nothing or did't return a json file
    if (string.IsNullOrEmpty(_jsonPearlOfGreatPrice) || _jsonPearlOfGreatPrice[0] != '{')
    {
      // ### 2nd TRY to get the volume from the website THIS TIME USING WEBCLIENT      
      // tool from System.Net used to get the json file from the website
      using (WebClient webClient = new WebClient())
      {   
        // save the whole Pearl of Great Price into the json string file
        _jsonPearlOfGreatPrice = webClient.DownloadString(website); 
      } 
    } 
    // if the both web requests returned nothing or did't return a json file   
    if (String.IsNullOrEmpty(_jsonPearlOfGreatPrice) || _jsonPearlOfGreatPrice[0] != '{')
    {
      // ### 3rd TRY to get the volume THIS TIME USING THE FILEPATH TO THE LOCAL FILE         
      if (File.Exists(_filePathPearlOfGreatPrice))
      {
        // read the whole Pearl of Great Price into the json string file
        _jsonPearlOfGreatPrice = File.ReadAllText(_filePathPearlOfGreatPrice);
        Console.WriteLine("Got it from the local file!");
      }
      else
      {
        // let the user know that neither the web request or the file pathway was good
        _jsonPearlOfGreatPrice = "Neither the web or file download of json file was successful.";
        Console.Write(_jsonPearlOfGreatPrice);
      }
    }    
  }

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