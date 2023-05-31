using System;

// ### CLASS ################################################ //
// class to hold math assignments
public class MathAssignment : Assignment
{
// ### VARIABLE ATTRIBUTES ################################## // 
  // variable to hold the textbook section
  private string _textbookSection;
  // variable to hold the problem numbers
  private string _problems;
// ### CONSTRUCTORS ######################################### //
  // constructor sets up the object to recieve a string for the inherited _studentName, 
  // _topic, and for _textbookSection and _problems upon initialization of the object
  public MathAssignment(string studentName, string topic, string textbookSection, string problems) : base(studentName, topic)
  { 
    // set _textbookSection equal to the textbookSection passed in 
    _textbookSection = textbookSection;
    // set _problems equal to the problems passed in 
    _problems = problems;
  }

// ### METHODS ############################################## //
  // getter method to get the _textbookSection and _problems
  public string GetHomeworkList()
  { 
    return $"Section {_textbookSection} Problems {_problems}";
  }
}