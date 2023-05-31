using System;

// ### CLASS ################################################ //
// class to hold writing assignments
public class WritingAssignment : Assignment
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // variable to hold the title of the writing assignment
  private string _title;
// ### CONSTRUCTORS ######################################### //
  // constructor sets up the object to recieve a string for the inherited _studentName, 
  // _topic, and for the _title upon initialization of the object
  public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
  { 
    // set _title equal to the title passed in 
    _title = title;   
  }

// ### METHODS ############################################## //
  // getter method to get the _textbookSection and _problems
  public string GetWritingInformation()
  { 
    return $"{_title} by {GetStudentName()}";
  }
}