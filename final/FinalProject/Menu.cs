using System;
using System.IO;

// ### CLASS ################################################ //
// class to hold and display the menu for the user
// and to return the user's choice
public class Menu
{
// ### VARIABLE ATTRIBUTES ################################## //   
  private string _choice = "run program"; // used for user's choice and to run the while loop 
  // private Tracker _tracker = new Tracker();// to have a Tracker object that can be used throughout all Menu methods
 
// ### CONSTRUCTORS ######################################### //
  // no constructors needed
  
// ### METHODS ############################################## //
  // method to present the main menu to the user and to return the user's choice 
  public string PresentMainMenu()
  {            
    string selection = "No selection made.";
    // _tracker.DisplayHealthDashboard(); // display the Health Recordings verses the Good Health Standards
   
    // save the menu to be passed into the validator method for use    
    string mainMenuPrompt = "\n     Make your selection by entering a number:\n       1 - Record Meal (Last done – Date & Meal)\n       2 - Record Exercise (Last done – Date)\n       3 - Record Health Statistic (Last done – Date)\n       4 - Add Recipe (Current List of #)\n       5 - Add Food (Current List of #)\n       6 - Add Exercise (Current List of #)\n       7 - Display Statistics (Last viewed Date)\n       8 - Close Program\n     Selection: ";    
    // pass the mainMenuPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator = new Validator("Use prompt", mainMenuPrompt);      
    selection = validator.SelectionCheck(8, "Don't Confirm"); // get an entry that is valid   
    return selection; // return the user's selection
  }

   // method to run the user's choice from the main menu
  public void RunMainChoices()
  {    
    while (_choice != "8") // run this until the user chooses to "Close Program"
    {          
      _choice = PresentMainMenu(); // display menu options and return user's choice
      // RUN OPTION USER CHOSE      
      if (_choice == "1") // if they chose "Record Meal"
      {         
        RunRecordMealChoices(); // present the user the menu to "Record Meal"
      }        
      if (_choice == "2") // if they chose "Record Exercise"
      {        
        RunRecordExerciseChoices(); // present the user the menu to "Record Exercise"               
      }      
      if (_choice == "3") // if they chose "Record Health Statistic"
      {
        RunRecordHealthChoices(); // present the user the menu to "Record Health Statistic"    
      }     
      if (_choice == "4") // if they chose "Add Recipe"
      {        
        Recipe recipe = new Recipe("recipe", "%");
        FoodComboTracker recipeTracker = new FoodComboTracker();
        recipeTracker.LoadItem(recipe);
        recipeTracker.ObjectsToTextFile("foods.txt");        
        recipeTracker.TextfileToOjects("foods.txt");
        recipeTracker.DisplayObjects();          
      }       
      if (_choice == "5") // if they chose "Add Food"
      {
        RunAddFoodChoices(); // present the user the menu to "Add Food"
      }      
      if (_choice == "6") // if they chose "Add Exercise"
      {
        // AddExercise Method
      }      
      if (_choice == "7") // if they chose "Display Statistics"
      {
        // DisplayStatistics Method
      }                  
    }
  }

  // menu for the user to record a meal
  public string PresentRecordMealMenu()
  {    
    string selection = "No selection made.";    
    // save the menu to be passed into the validator method for use
    string recordMealMenuPrompt = "\nMake your selection by entering a number:\n  1 - Breakfast Input (Current Streak of #)\n  2 - Lunch Input (Current Streak of #)\n  3 - Dinner Input (Current Streak of #)\n  4 - Snack Input (Current Streak of #)\n  5 - Liquid Input (Current Streak of #)\n  6 - Add Food (Current List of #)\n  7 - Add Recipe (Current List of #)\n  8 - Remove Food (Current List of #)\n  9 - Remove Recipe (Current List of #)\n 10 - Return to Main Menu\nSelection: ";
    // pass the recordMealMenuPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator = new Validator("Use prompt", recordMealMenuPrompt);          
    selection = validator.SelectionCheck(10, "Do Confirm"); // get a valid entry & confirm as the user's choice
    return selection; // return the user's selection
  }

  // method to run the user's choice for the "Record Meal Menu" 
  public void RunRecordMealChoices()
  {     
    string choice = PresentRecordMealMenu(); // display menu options and return user's choice
    switch (choice)
    {
      // RUN OPTION USER CHOSE
      case "1": // if they chose "Breakfast Input"
        Meal breakfast = new Meal("breakfast", "%");
        FoodComboTracker breakfastTracker = new FoodComboTracker();
        breakfastTracker.LoadItem(breakfast);
        breakfastTracker.ObjectsToTextFile("meals.txt");        
        breakfastTracker.TextfileToOjects("meals.txt");
        breakfastTracker.DisplayObjects(); 
        break;
      case "2": // if they chose "Lunch Input"
        Meal lunch = new Meal("lunch", "%");
        FoodComboTracker lunchTracker = new FoodComboTracker();
        lunchTracker.LoadItem(lunch);
        lunchTracker.ObjectsToTextFile("meals.txt");        
        lunchTracker.TextfileToOjects("meals.txt");
        lunchTracker.DisplayObjects(); 
        break;
      case "3": // if they chose "Dinner Input"
        Meal dinner = new Meal("dinner", "%");
        FoodComboTracker dinnerTracker = new FoodComboTracker();
        dinnerTracker.LoadItem(dinner);
        dinnerTracker.ObjectsToTextFile("meals.txt");        
        dinnerTracker.TextfileToOjects("meals.txt");
        dinnerTracker.DisplayObjects();       
        break;
      case "4": // if they chose "Snack Input"
        Meal snack = new Meal("snack", "%");
        FoodComboTracker snackTracker = new FoodComboTracker();
        snackTracker.LoadItem(snack);
        snackTracker.ObjectsToTextFile("meals.txt");        
        snackTracker.TextfileToOjects("meals.txt");
        snackTracker.DisplayObjects();   
        break;
      case "5": // if they chose "Liquid Input"
        Meal liquid = new Meal("liquid or drink", "%");
        FoodComboTracker liquidTracker = new FoodComboTracker();
        liquidTracker.LoadItem(liquid);
        liquidTracker.ObjectsToTextFile("meals.txt");        
        liquidTracker.TextfileToOjects("meals.txt");
        liquidTracker.DisplayObjects();   
        break;  
      case "6": // if they chose "Add Food"
        RunAddFoodChoices(); // present the user the menu to "Add Food"
        break;
      case "7": // if they chose "Add Recipe"
        Recipe recipe = new Recipe("recipe", "%");
        FoodComboTracker recipeTracker = new FoodComboTracker();
        recipeTracker.LoadItem(recipe);
        recipeTracker.ObjectsToTextFile("foods.txt");        
        recipeTracker.TextfileToOjects("foods.txt");
        recipeTracker.DisplayObjects();
        break;
      case "8": // if they chose "Remove Food"
        RunRemoveFoodChoices();
        break;
      case "9": // if they chose "Remove Recipe"
        // method
        break;
      default: // if they chose "Return to Main Menu"        
        break; // do nothing to end this menu & return user to the main menu
    }  
  }

  // menu for the user to record exercise
  public string PresentRecordExerciseMenu()
  {    
    string selection = "No selection made."; 
    // save the menu to be passed into the validator method for use    
    string recordExerciseMenuPrompt = "\nMake your selection by entering a number:\n  1 - Walking (Done # minutes in total)\n  2 - Trampoline Cardio Workout (Done # minutes in total)\n  3 - Lifting Weights (Done # minutes in total)\n  4 - Ab Machine Workout Video (Done # minutes in total)\n  5 - Ab & Cardio Workout Video (Done # minutes in total)\n  6 - Exercise Bike (Done # minutes in total)\n  7 - Add Exercise (Current List of #)\n  8 - Remove Exercise (Current List of #)\n  9 - Return to Main Menu\nSelection: ";
    // pass the recordExerciseMenuPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator = new Validator("Use prompt", recordExerciseMenuPrompt);          
    selection = validator.SelectionCheck(9, "Do Confirm"); // get a valid entry & confirm as the user's choice
    return selection; // return the user's selection
  }

  // method to run the user's choice for the "Record Exercise Menu" 
  public void RunRecordExerciseChoices()
  {     
    string choice = PresentRecordExerciseMenu(); // display menu options and return user's choice
    switch (choice)
    {
      // RUN OPTION USER CHOSE
      case "1": // if they chose "Walking"
        // method
        break;
      case "2": // if they chose "Trampoline Cardio Workout"
        // method
        break;
      case "3": // if they chose "Lifting Weights"
        // method
        break;
      case "4": // if they chose "Ab Machine Workout Video"
        // method
        break;
      case "5": // if they chose "Ab & Cardio Workout Video"
        // method
        break;  
      case "6": // if they chose "Exercise Bike"
        // method
        break;
      case "7": // if they chose "Add Exercise"
        // method
        break;
      case "8": // if they chose "Remove Exercise"
        // method
      default: // if they chose "Return to Main Menu"        
        break; // do nothing to end this menu & return user to the main menu
    }  
  } 

  // menu for the user to record heath statistics
  public string PresentRecordHealthMenu()
  {    
    string selection = "No selection made."; 
    // save the menu to be passed into the validator method for use    
    string recordHealthMenuPrompt = "\nMake your selection by entering a number:\n  1 - Record Body Mass Index (Needed weekly – Last done Date)\n  2 - Record Waist-to-Hip Ratio (Needed monthly – Last done Date)\n  3 - Record Blood Pressure (Needed yearly – Last done Date)\n  4 - Record Cholesterol Level (Needed every 4 years – Last done Date)\n  5 - Return to Main Menu\nSelection: ";
    // pass the recordHealthMenuPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator = new Validator("Use prompt", recordHealthMenuPrompt);          
    selection = validator.SelectionCheck(5, "Do Confirm"); // get a valid entry & confirm as the user's choice
    return selection; // return the user's selection
  }

  // method to run the user's choice for the "Record Health Menu" 
  public void RunRecordHealthChoices()
  {     
    string choice = PresentRecordHealthMenu(); // display menu options and return user's choice
    switch (choice)
    {
      // RUN OPTION USER CHOSE
      case "1": // if they chose "Record Body Mass Index"
        // method
        break;
      case "2": // if they chose "Record Waist-to-Hip Ratio"
        // method
        break;
      case "3": // if they chose "Record Blood Pressure"
        // method
        break;
      case "4": // if they chose "Record Cholesterol Level"
        // method
        break;            
      default: // if they chose "Return to Main Menu"        
        break; // do nothing to end this menu & return user to the main menu
    }  
  }

  // menu for the user to add food
  public string PresentAddFoodMenu()
  {    
    string selection = "No selection made."; 
    // save the menu to be passed into the validator method for use    
    string addFoodMenuPrompt = "\nMake your selection by entering a number:\n  1 - Add Fruit (Current List of #)\n  2 - Add Vegetable (Current List of #)\n  3 - Add Grain Food (Current List of #)\n  4 - Add Dairy Food (Current List of #)\n  5 - Add Protein Food (Current List of #)\n  6 - Add Liquid (Current List of #)\n  7 - Add Oil or Fat (Current List of #)\n  8 - Add Other Food (Current List of #)\n  9 - Return to Main Menu\nSelection: ";
    // pass the addFoodMenuPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator = new Validator("Use prompt", addFoodMenuPrompt);          
    selection = validator.SelectionCheck(9, "Do Confirm"); // get a valid entry & confirm as the user's choice   
    return selection; // return the user's selection
  }

  // method to run the user's choice for the "Add Food Menu" 
  public void RunAddFoodChoices()
  {     
    string choice = PresentAddFoodMenu(); // display menu options and return user's choice
    switch (choice)
    {
      // RUN OPTION USER CHOSE
      case "1": // if they chose "Add Fruit" 
        Food fruit = new Food("fruit", "cups");        
        FoodTracker fruitTracker = new FoodTracker();
        fruitTracker.LoadItem(fruit);
        fruitTracker.ObjectsToTextFile("foods.txt");
        fruitTracker.TextfileToOjects("foods.txt");
        fruitTracker.DisplayObjects();        
        break;
      case "2": // if they chose "Add Vegetable"
        Food veggie = new Food("vegetable", "cups");        
        FoodTracker veggieTracker = new FoodTracker();
        veggieTracker.LoadItem(veggie);
        veggieTracker.ObjectsToTextFile("foods.txt");
        veggieTracker.TextfileToOjects("foods.txt");
        veggieTracker.DisplayObjects();        
        break;        
      case "3": // if they chose "Add Grain Food"
        Food grain = new Food("grain food", "cups");        
        FoodTracker grainTracker = new FoodTracker();
        grainTracker.LoadItem(grain);
        grainTracker.ObjectsToTextFile("foods.txt");
        grainTracker.TextfileToOjects("foods.txt");
        grainTracker.DisplayObjects(); 
        break;
      case "4": // if they chose "Add Dairy Food"
        Food dairy = new Food("dairy food", "cups");        
        FoodTracker dairyTracker = new FoodTracker();
        dairyTracker.LoadItem(dairy);
        dairyTracker.ObjectsToTextFile("foods.txt");
        dairyTracker.TextfileToOjects("foods.txt");
        dairyTracker.DisplayObjects();
        break;
      case "5": // if they chose "Add Protein Food"
        Food protein = new Food("protein food", "cups");        
        FoodTracker proteinTracker = new FoodTracker();
        proteinTracker.LoadItem(protein);
        proteinTracker.ObjectsToTextFile("foods.txt");
        proteinTracker.TextfileToOjects("foods.txt");
        proteinTracker.DisplayObjects();
        break;
      case "6": // if they chose "Add Liquid"
        Food liquid = new Food("liquid or drink", "cups");        
        FoodTracker liquidTracker = new FoodTracker();
        liquidTracker.LoadItem(liquid);
        liquidTracker.ObjectsToTextFile("foods.txt");
        liquidTracker.TextfileToOjects("foods.txt");
        liquidTracker.DisplayObjects();
        break;         
      case "7": // if they chose "Add Oil or Fat"
        Food oil = new Food("oil or fat", "cups");        
        FoodTracker oilTracker = new FoodTracker();
        oilTracker.LoadItem(oil);
        oilTracker.ObjectsToTextFile("foods.txt");
        oilTracker.TextfileToOjects("foods.txt");
        oilTracker.DisplayObjects();
        break;     
      case "8": // if they chose "Add Other Food"
        Food other = new Food("other food", "cups");        
        FoodTracker otherTracker = new FoodTracker();
        otherTracker.LoadItem(other);
        otherTracker.ObjectsToTextFile("foods.txt");
        otherTracker.TextfileToOjects("foods.txt");
        otherTracker.DisplayObjects();
        break;        
      default: // if they chose "Return to Main Menu"        
        break; // do nothing to end this menu & return user to the main menu
    }  
  } 

  // menu for the user to remove food
  public string PresentRemoveFoodMenu()
  {    
    string selection = "No selection made."; 
    // save the menu to be passed into the validator method for use    
    string RemoveFoodMenuPrompt = "\nMake your selection by entering a number:\n  1 - Remove Fruit (Current List of #)\n  2 - Remove Vegetable (Current List of #)\n  3 - Remove Grain Food (Current List of #)\n  4 - Remove Dairy Food (Current List of #)\n  5 - Remove Protein Food (Current List of #)\n  6 - Remove Oil or Fat (Current List of #)\n  7 - Remove Liquid (Current List of #)\n  8 - Return to Main Menu\nSelection: ";
    // pass the RemoveFoodMenuPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator = new Validator("Use prompt", RemoveFoodMenuPrompt);          
    selection = validator.SelectionCheck(8, "Do Confirm"); // get a valid entry & confirm as the user's choice
    return selection; // return the user's selection
  }

  // method to run the user's choice for the "Remove Food Menu" 
  public void RunRemoveFoodChoices()
  {     
    string choice = PresentRemoveFoodMenu(); // display menu options and return user's choice
    switch (choice)
    {
      // RUN OPTION USER CHOSE
      case "1": // if they chose "Remove Fruit"
        // method
        break;
      case "2": // if they chose "Remove Vegetable"
        // method
        break;
      case "3": // if they chose "Remove Grain Food"
        // method
        break;
      case "4": // if they chose "Remove Dairy Food"
        // method
        break;
      case "5": // if they chose "Remove Protein Food"
        // method
        break;  
      case "6": // if they chose "Remove Oil or Fat"
        // method
        break;
      case "7": // if they chose "Remove Liquid"
        // method
        break;      
      default: // if they chose "Return to Main Menu"        
        break; // do nothing to end this menu & return user to the main menu
    }  
  } 
} 