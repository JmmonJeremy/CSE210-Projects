using System;

// ### CLASS ################################################ //
// class to hold assignments
public class Assignment
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // variable to hold the student's name
  private string _studentName;
  // variable to hold the topic of the assignment
  private string _topic;
// ### CONSTRUCTORS ######################################### //
  // constructor sets up the object to recieve a string for the 
  // _studentName and _topic upon initialization of the object
  public Assignment(string studentName, string topic)
  { 
    // set _studentName equal to the studentName passed in 
    _studentName = studentName;
    // set _topic equal to the topic passed in 
    _topic = topic;
  }

// ### METHODS ############################################## //
  // getter method to get the _studentName
  public string GetStudentName()
  {
    return _studentName;
  }
  // getter method to get the _studentName
  public string GetTopic()
  {
    return _topic;
  }
  // getter method to get the _studentName and _topic
  public string GetSummary()
  { 
    return $"{_studentName} - {_topic}";
  }
}