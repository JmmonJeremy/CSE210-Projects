using System;
using System.IO;

// ### CLASS ################################################ //
// class to hold and display the menu for the user
// and to return the user's choice
public class Menu
{
// ### VARIABLE ATTRIBUTES ################################## // 
  private string _textfileName;  
  private string _choice = "run program"; // used for user's choice and to run the while loop   
 
// ### CONSTRUCTORS ######################################### //
  // main constructor to set up a Menu object with the username creating the _textfileName
  public Menu()
  {   
    // Login(); // have user login with a username  
  }  

  
// ### METHODS ############################################## //
  // method to present the main menu to the user and to return the user's choice 
  public string PresentMainMenu()
  {            
    string selection = "No selection made.";
    string space = new string(' ', 39);   
    // save the menu to be passed into the validator method for use    
    string mainMenuPrompt = $"\n{space}Make your selection by entering a number:\n{space}  1 - Record Meal (Last done – Date & Meal)\n{space}  2 - Record Exercise (Last done – Date)\n{space}  3 - Record Health Statistic (Last done – Date)\n{space}  4 - Add Food (Current List of #)\n{space}  5 - Add Recipe (Current List of #)\n{space}  6 - Add Exercise (Current List of #)\n{space}  7 - Display Statistics (Last viewed Date)\n{space}  8 - Close Program\n{space}Selection: ";    
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
      HealthStatus healthy = new HealthStatus("intake", "calories");
      healthy.SaveToTextfile("healthTracker.txt");

      HealthStatus health = new HealthStatus("Set up empty"); 
      health.HealthDashboard();      
     
      _choice = PresentMainMenu(); // display menu options and return user's choice
      // RUN OPTION USER CHOSE      
      if (_choice == "1") // if they chose "Record Meal"
      {         
        health.CreateScrollLine("\n\n\n"); // put decorative seperation line after main menu      
        RunRecordMealChoices(); // present the user the menu to "Record Meal"
      }        
      if (_choice == "2") // if they chose "Record Exercise"
      { 
        health.CreateScrollLine("\n\n\n"); // put decorative seperation line after main menu         
        RunRecordExerciseChoices(); // present the user the menu to "Record Exercise"               
      }      
      if (_choice == "3") // if they chose "Record Health Statistic"
      {
        health.CreateScrollLine("\n\n\n"); // put decorative seperation line after main menu  
        RunRecordHealthChoices(); // present the user the menu to "Record Health Statistic"    
      }     
      if (_choice == "4") // if they chose "Add Food"
      {   
        health.CreateScrollLine("\n\n\n"); // put decorative seperation line after main menu  
        RunAddFoodChoices(); // present the user the menu to "Add Food"                
      }       
      if (_choice == "5") // if they chose "Add Recipe"
      {
        health.CreateScrollLine("\n\n\n"); // put decorative seperation line after main menu  
        RunAddRecipeChoices(); // present the user the menu to "Add Recipe" 
      }      
      if (_choice == "6") // if they chose "Add Exercise"
      {
        health.CreateScrollLine("\n\n\n"); // put decorative seperation line after main menu  
        // AddExercise Method
      }      
      if (_choice == "7") // if they chose "Display Statistics"
      {
        health.CreateScrollLine("\n\n\n"); // put decorative seperation line after main menu  
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
        breakfastTracker.ObjectsToTextfile(_textfileName);        
        breakfastTracker.TextfileToOjects(_textfileName);

        HealthStatus breakfastCalories = new HealthStatus("intake", "calories");
        HealthStatusTracker healthTrackerBkCal = new HealthStatusTracker();
        healthTrackerBkCal.LoadItem(breakfastCalories);
        breakfastCalories.SaveToTextfile(_textfileName);

        breakfastTracker.DisplayObjects();
        break;
      case "2": // if they chose "Lunch Input"
        Meal lunch = new Meal("lunch", "%");
        FoodComboTracker lunchTracker = new FoodComboTracker();
        lunchTracker.LoadItem(lunch);
        lunchTracker.ObjectsToTextfile(_textfileName);        
        lunchTracker.TextfileToOjects(_textfileName);

        HealthStatus lunchCalories = new HealthStatus("intake", "calories");
        HealthStatusTracker healthTrackerDCal = new HealthStatusTracker();
        healthTrackerDCal.LoadItem(lunchCalories);
        lunchCalories.SaveToTextfile(_textfileName);

        lunchTracker.DisplayObjects(); 
        break;
      case "3": // if they chose "Dinner Input"
        Meal dinner = new Meal("dinner", "%");
        FoodComboTracker dinnerTracker = new FoodComboTracker();
        dinnerTracker.LoadItem(dinner);
        dinnerTracker.ObjectsToTextfile(_textfileName);        
        dinnerTracker.TextfileToOjects(_textfileName);

        HealthStatus dinnerCalories = new HealthStatus("intake", "calories");
        HealthStatusTracker healthTrackerLCal = new HealthStatusTracker();
        healthTrackerLCal.LoadItem(dinnerCalories);
        dinnerCalories.SaveToTextfile(_textfileName);

        dinnerTracker.DisplayObjects();       
        break;
      case "4": // if they chose "Snack Input"
        Meal snack = new Meal("snack", "%");
        FoodComboTracker snackTracker = new FoodComboTracker();
        snackTracker.LoadItem(snack);
        snackTracker.ObjectsToTextfile(_textfileName);        
        snackTracker.TextfileToOjects(_textfileName);

        HealthStatus snackCalories = new HealthStatus("intake", "calories");
        HealthStatusTracker healthTrackerSnCal = new HealthStatusTracker();
        healthTrackerSnCal.LoadItem(snackCalories);
        snackCalories.SaveToTextfile(_textfileName);

        snackTracker.DisplayObjects();   
        break;
      case "5": // if they chose "Liquid Input"
        Meal liquid = new Meal("liquid or drink", "%");
        FoodComboTracker liquidTracker = new FoodComboTracker();
        liquidTracker.LoadItem(liquid);
        liquidTracker.ObjectsToTextfile(_textfileName);        
        liquidTracker.TextfileToOjects(_textfileName);

        HealthStatus liquidCalories = new HealthStatus("intake", "calories");
        HealthStatusTracker healthTrackerLiqCal = new HealthStatusTracker();
        healthTrackerLiqCal.LoadItem(liquidCalories);
        liquidCalories.SaveToTextfile(_textfileName);

        liquidTracker.DisplayObjects();   
        break;  
      case "6": // if they chose "Add Food"
        RunAddFoodChoices(); // present the user the menu to "Add Food"
        break;
      case "7": // if they chose "Add Recipe"
        RunAddRecipeChoices();
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
        HealthStatus health = new HealthStatus("weight", "lbs");
        health.SaveToTextfile("healthTracker.txt"); // save current version for display
        // HealthStatusTracker bmiHealthTracker = new HealthStatusTracker();
        // bmiHealthTracker.LoadItem(health);
        // bmiHealthTracker.ObjectsToTextfile("healthTrackerHistory.txt"); // save for record          
        // bmiHealthTracker.TextfileToOjects("healthTrackerHistory.txt");     
        // bmiHealthTracker.DisplayObjects();                
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
        fruitTracker.ObjectsToTextfile("foods.txt");
        fruitTracker.TextfileToOjects("foods.txt");
        fruitTracker.DisplayObjects();        
        break;
      case "2": // if they chose "Add Vegetable"
        Food veggie = new Food("vegetable", "cups");        
        FoodTracker veggieTracker = new FoodTracker();
        veggieTracker.LoadItem(veggie);
        veggieTracker.ObjectsToTextfile("foods.txt");
        veggieTracker.TextfileToOjects("foods.txt");
        veggieTracker.DisplayObjects();        
        break;        
      case "3": // if they chose "Add Grain Food"
        Food grain = new Food("grain food", "cups");        
        FoodTracker grainTracker = new FoodTracker();
        grainTracker.LoadItem(grain);
        grainTracker.ObjectsToTextfile("foods.txt");
        grainTracker.TextfileToOjects("foods.txt");
        grainTracker.DisplayObjects(); 
        break;
      case "4": // if they chose "Add Dairy Food"
        Food dairy = new Food("dairy food", "cups");        
        FoodTracker dairyTracker = new FoodTracker();
        dairyTracker.LoadItem(dairy);
        dairyTracker.ObjectsToTextfile("foods.txt");
        dairyTracker.TextfileToOjects("foods.txt");
        dairyTracker.DisplayObjects();
        break;
      case "5": // if they chose "Add Protein Food"
        Food protein = new Food("protein food", "cups");        
        FoodTracker proteinTracker = new FoodTracker();
        proteinTracker.LoadItem(protein);
        proteinTracker.ObjectsToTextfile("foods.txt");
        proteinTracker.TextfileToOjects("foods.txt");
        proteinTracker.DisplayObjects();
        break;
      case "6": // if they chose "Add Liquid"
        Food liquid = new Food("liquid or drink", "cups");        
        FoodTracker liquidTracker = new FoodTracker();
        liquidTracker.LoadItem(liquid);
        liquidTracker.ObjectsToTextfile("foods.txt");
        liquidTracker.TextfileToOjects("foods.txt");
        liquidTracker.DisplayObjects();
        break;         
      case "7": // if they chose "Add Oil or Fat"
        Food oil = new Food("oil or fat", "cups");        
        FoodTracker oilTracker = new FoodTracker();
        oilTracker.LoadItem(oil);
        oilTracker.ObjectsToTextfile("foods.txt");
        oilTracker.TextfileToOjects("foods.txt");
        oilTracker.DisplayObjects();
        break;     
      case "8": // if they chose "Add Other Food"
        Food other = new Food("other food", "cups");        
        FoodTracker otherTracker = new FoodTracker();
        otherTracker.LoadItem(other);
        otherTracker.ObjectsToTextfile("foods.txt");
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

  // menu for the user to add recipes
  public string PresentAddRecipeMenu()
  {    
    string selection = "No selection made."; 
    // save the menu to be passed into the validator method for use    
    string addRecipeMenuPrompt = "\nMake your selection by entering a number:\n  1 - Add Dish Recipe (Current List of #)\n  2 - Add Soup or Stew Recipe (Current List of #)\n  3 - Add Salad Recipe (Current List of #)\n  4 - Add Bread or Muffin Recipe (Current List of #)\n  5 - Add Sandwich, Wrap, or Taco Recipe (Current List of #)\n  6 - Add Meat Recipe (Current List of #)\n  7 - Add Seafood Recipe (Current List of #)\n  8 - Add Vegetarian Recipe (Current List of #)\n  9 - Add Dessert Recipe (Current List of #)\n 10 - Return to Main Menu\nSelection: ";
    // pass the addRecipMenuPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator = new Validator("Use prompt", addRecipeMenuPrompt);          
    selection = validator.SelectionCheck(10, "Do Confirm"); // get a valid entry & confirm as the user's choice   
    return selection; // return the user's selection
  }

  // method to run the user's choice for the "Add Recipe Menu" 
  public void RunAddRecipeChoices()
  {      
    string choice = PresentAddRecipeMenu(); // display menu options and return user's choice
    switch (choice)
    {
      // RUN OPTION USER CHOSE
      case "1": // if they chose "Add Dish Recipe" 
        Recipe dish = new Recipe("dish", "cups");
        FoodComboTracker dishTracker = new FoodComboTracker();
        dishTracker.LoadItem(dish);
        dishTracker.ObjectsToTextfile("foods.txt");        
        dishTracker.TextfileToOjects("foods.txt");
        dishTracker.DisplayObjects();
        break;
      case "2": // if they chose "Add Soup or Stew Recipe"
        Recipe soup = new Recipe("soup or stew", "cups");
        FoodComboTracker soupTracker = new FoodComboTracker();
        soupTracker.LoadItem(soup);
        soupTracker.ObjectsToTextfile("foods.txt");        
        soupTracker.TextfileToOjects("foods.txt");
        soupTracker.DisplayObjects();
        break;       
      case "3": // if they chose "Add Salad Recipe"
        Recipe salad = new Recipe("salad", "cups");
        FoodComboTracker saladTracker = new FoodComboTracker();
        saladTracker.LoadItem(salad);
        saladTracker.ObjectsToTextfile("foods.txt");        
        saladTracker.TextfileToOjects("foods.txt");
        saladTracker.DisplayObjects(); 
        break;
      case "4": // if they chose "Add Bread or Muffin Recipe"
        Recipe bread = new Recipe("bread or muffin", "pieces");
        FoodComboTracker breadTracker = new FoodComboTracker();
        breadTracker.LoadItem(bread);
        breadTracker.ObjectsToTextfile("foods.txt");        
        breadTracker.TextfileToOjects("foods.txt");
        breadTracker.DisplayObjects();
        break;
      case "5": // if they chose "Add Sandwich, Wrap, or Taco Recipe"
        Recipe wrap = new Recipe("sandwich, wrap, or taco", "servings");
        FoodComboTracker wrapTracker = new FoodComboTracker();
        wrapTracker.LoadItem(wrap);
        wrapTracker.ObjectsToTextfile("foods.txt");        
        wrapTracker.TextfileToOjects("foods.txt");
        wrapTracker.DisplayObjects();
        break;
      case "6": // if they chose "Add Meat Recipe"
        Recipe meat = new Recipe("meat", "cups");
        FoodComboTracker meatTracker = new FoodComboTracker();
        meatTracker.LoadItem(meat);
        meatTracker.ObjectsToTextfile("foods.txt");        
        meatTracker.TextfileToOjects("foods.txt");
        meatTracker.DisplayObjects();
        break;        
      case "7": // if they chose "Add Seafood Recipe"
        Recipe seafood = new Recipe("seafood", "cups");
        FoodComboTracker seafoodTracker = new FoodComboTracker();
        seafoodTracker.LoadItem(seafood);
        seafoodTracker.ObjectsToTextfile("foods.txt");        
        seafoodTracker.TextfileToOjects("foods.txt");
        seafoodTracker.DisplayObjects();
        break;     
      case "8": // if they chose "Add Vegetarian Recipe"
        Recipe vegetarian = new Recipe("vegetarian", "cups");
        FoodComboTracker vegetarianTracker = new FoodComboTracker();
        vegetarianTracker.LoadItem(vegetarian);
        vegetarianTracker.ObjectsToTextfile("foods.txt");        
        vegetarianTracker.TextfileToOjects("foods.txt");
        vegetarianTracker.DisplayObjects();
        break; 
      case "9": // if they chose "Add Dessert Recipe"
        Recipe dessert = new Recipe("dessert", "cups");
        FoodComboTracker dessertTracker = new FoodComboTracker();
        dessertTracker.LoadItem(dessert);
        dessertTracker.ObjectsToTextfile("foods.txt");        
        dessertTracker.TextfileToOjects("foods.txt");
        dessertTracker.DisplayObjects();
        break;         
      default: // if they chose "Return to Main Menu"        
        break; // do nothing to end this menu & return user to the main menu
    }  
  }

   // menu for the user to login or create username login
   public string PresentHealthLoginMenu()
  {    
    // save the loginPrompt to be passed into the validator method for use    
    string loginPrompt = "\nMake your selection by entering a number:\n  1 - Enter Health Tracker Login Username\n  2 - Create Health Tracker Login Username\nSelection: ";
    // pass the loginPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator = new Validator("Use prompt", loginPrompt);          
    string selection = validator.SelectionCheck(2, "Don't Confirm"); // get a valid entry  
    return selection; // return the user's selection
  }  

  // method to so introduction welcome and welcome the user
  public void Welcome(string connector, string who)
  {    
    Console.ForegroundColor = ConsoleColor.Yellow; Console.Write($"\nWelcome {connector}");
    Console.ForegroundColor = ConsoleColor.Cyan;   Console.Write($"'{who}'");
    Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine(" !!!");
    Console.ResetColor();
  }

  // method to perform actions based on user input and conditionally set _textfileName
  public void TextfileNameIfAction(string choice, string selected, bool exists, string textfileName, string username, string created)
  {
    if (choice == selected)
    {
      if (File.Exists(textfileName) == exists)
      {            
        _textfileName = textfileName;
        Welcome("",username);          
      }
      else
      {
                                                      Console.Write("\nThe username ");
        Console.ForegroundColor = ConsoleColor.Green; Console.Write($"'{username}' ");
        Console.ForegroundColor = ConsoleColor.Red;   Console.WriteLine($"{created}.");
        Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Please try again.");
        Console.ResetColor();
        _textfileName = "no";
      }
    }
  }

  // method to require user to enter username to start program
  public void Login()
  {
    // #1 USER ASSIGNS THE MEAL _userName ****************************************************
    _textfileName = "no";
    string fillIn1 = "";    
    Welcome("to the ","Health Tracker");   
    while (_textfileName == "no")
    {               
      string choice = PresentHealthLoginMenu(); // get a valid entry
      if(choice == "2")
      {
        fillIn1 = " desired";
      }        
      // save the usernamePrompt to be passed into the validator method for use      
      string usernamePrompt = $"Please enter your{fillIn1} username: ";    
      // pass the recipeNamePrompt into the object & for the user's 
      // entry value put "Use prompt" since user will change value after the prompt
      Validator validator = new Validator("Use prompt", usernamePrompt);    
      // with "Use prompt" set the method to to use the prompt the first time the method is used
      string username = validator.ConfirmEntry("Use prompt");
      
      HealthStatus health = new HealthStatus("height", "inches");
      health.LoadAttributes("healthTracker");
      health.SaveToTextfile("healthTracker"); // save current version for display
      string textfileName = $"{username}_MealRecord.txt";       
      TextfileNameIfAction(choice,"1", true, textfileName, username, "does not exist");       
      TextfileNameIfAction(choice,"2", false, textfileName, username, "already exists");      
    }
  } 
} 