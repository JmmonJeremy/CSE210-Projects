using System;
using System.Text.Json.Serialization;

// ### CLASS ################################################ //
// class to store the string reference and verse
// reference source: https://www.youtube.com/watch?v=SholKTNGdHk
public class Verse
{    
// ### VARIABLE ATTRIBUTES ################################## //
  // this is as private as is allowed for attributes when using Serializaton
  // reference source: https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/immutability?pivots=dotnet-7-0 
  // variable to hold the verse reference 
  [JsonInclude]
  public string reference { get; private set;}
  // variable to hold the verse text
  [JsonInclude]
  public string text {get; private set;}
}