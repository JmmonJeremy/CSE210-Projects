using System;
using System.IO;
using System.Reflection;

// ### CLASS ################################################ //
// class for tracking meals and their calories and portions
public class FoodComboTracker : Tracker
{
// ### VARIABLE ATTRIBUTES ################################## //   
  private string _foodComboSet; // variable to hold the set being tracked  
  private string _foodSelectionPrompt;  
  private List<Tracked> _group = new List<Tracked>();
 

// ### CONSTRUCTORS ######################################### //  
  public FoodComboTracker() : base()
  {
    // nothing needed in here 
  }

// ### METHODS ############################################## //
  // method to figure out the total for the tracked value
  public override float TotalTrackedValue()
  {
    return base.TotalTrackedValue();
  }

  public override void DisplayObjects()
  {
    base.DisplayObjects();
  }

   // method to select the desired object in the list
    public int SelectObject(string foodSelectionPrompt, string subCategory)
  {
    // #1 USER SELECTS OJECT FROM LIST **************************************************
    int indexNumber = 0; // for returning the index of the object desired
    int selectionNumber = 0; // for numbering the selection options
    int needsAddedNumber = 0; // for identifying when a user selects the needs to be added option
    // put together a string of objects to select from in a menu prompt to pass into the Validator object 
    _foodSelectionPrompt = foodSelectionPrompt;     
    foreach (Tracked item in _items)
    {               
      if (item.GetCategory() == subCategory)
      {         
        ++ needsAddedNumber;
        ++ selectionNumber;        
        foodSelectionPrompt += $"{item.CreateDisplayString(selectionNumber, ")", "normal")}\n";
        _group.Add(item);
      }           
    }    
    ++ selectionNumber; // add one for the last added option
    string space = "  ";
    if (selectionNumber > 9)
    {
      space = " ";
    }
    foodSelectionPrompt += $"{selectionNumber}){space}The {subCategory} option needs to be added.\nSelection: ";       
    // pass the foodSelectionPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt  
    Validator validator = new Validator("Use prompt", foodSelectionPrompt);          
    indexNumber = int.Parse(validator.SelectionCheck(_group.Count +1, "Do Confirm")) -1; // get a valid entry & confirm as the user's choice      
    if (indexNumber == needsAddedNumber) 
    {
      indexNumber = -1; // if the item user wants isn't in the list return a -1 to indicate that
    }   
    return indexNumber;
  }

  // method to return the selected object from the list
  public Tracked ReturnObject(int indexNumber)
  {   
    Tracked selection = _group[indexNumber];   
    return selection;  
  }

  public override void RemoveObject()
  {
    base.RemoveObject();
  }
}