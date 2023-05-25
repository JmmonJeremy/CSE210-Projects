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
  // variable to hold the verse reference matching the json key word
  // the variable name cannot be _reference or the Deserialization process will not work
  [JsonInclude]
  // using auto-implemented properties
  // reference source: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
  public string reference { get; private set;}
  // variable to hold the verse text matching the json key word
  // the variable name cannot be _text or the Deserialization process will not work
  [JsonInclude]
  // using auto-implemented properties
  // reference source: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
  public string text {get; private set;}
}