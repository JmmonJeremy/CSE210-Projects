using System;
using System.IO;

// ### CLASS ################################################ //
// class to hold and display the menu for the user
// and to return the user's choice
public class Menu
{
// ### VARIABLE ATTRIBUTES ################################## // 
  private HealthStatus _health = new HealthStatus("Set up empty"); 
  private string _mealFile;
  private string _exerciseFile;
  private string _healthFile;
  private string _statSheet; 
  private string _choice = "run program"; // used for user's choice and to run the while loop   
 
// ### CONSTRUCTORS ######################################### //
  // main constructor to set up a Menu object with the username creating the textfile names
  public Menu()
  {   
    Login(); // have user login with a username  
  }  

  
// ### METHODS ############################################## //
  // getter method for the meal filename
  public string GetMealFile()
  {
    return _mealFile;
  }

  // getter method for the exercise filename
  public string GetExerciseFile()
  {
    return _exerciseFile;
  }

  public string GetHealthFile()
  {
    return _healthFile;
  }

  public string GetStatSheet()
  {
    return _statSheet;
  }
  // method to present the main menu to the user and to return the user's choice 
  public string PresentMainMenu()
  {            
    string selection = "No selection made.";
    string space = new string(' ', 39);   
    // save the menu to be passed into the validator method for use    
    string mainMenuPrompt = $"\n{space}Make your selection by entering a number:\n{space}  1 - Record Meal \n{space}  2 - Record Exercise \n{space}  3 - Record Health Statistic \n{space}  4 - Add Food \n{space}  5 - Add Recipe \n{space}  6 - Add Exercise \n{space}  7 - Display Items \n{space}  8 - Close Program\n{space}Selection: ";    
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
      _health.HealthDashboard();      
     
      _choice = PresentMainMenu(); // display menu options and return user's choice
      // RUN OPTION USER CHOSE      
      if (_choice == "1") // if they chose "Record Meal"
      {         
        _health.CreateScrollLine("\n\n\n"); // put decorative seperation line after main menu      
        RunRecordMealChoices(); // present the user the menu to "Record Meal"
      }        
      if (_choice == "2") // if they chose "Record Exercise"
      { 
        HealthStatus healthy = new HealthStatus("exercise", "minutes");
        _health.CreateScrollLine("\n\n\n"); // put decorative seperation line after main menu  
        Exercise exercise = new Exercise("Set up empty");       
        Tracked myExercise = exercise.AddToExerciseList(); // present the user the menu to "Record Exercise" 
        Tracker tracker = new Tracker();
        tracker.LoadItem(myExercise);
        tracker.ObjectsToTextfile(_exerciseFile); // save for record                     
      }      
      if (_choice == "3") // if they chose "Record Health Statistic"
      {
        _health.CreateScrollLine("\n\n\n"); // put decorative seperation line after main menu  
        HealthStatus health = new HealthStatus("weight", "lbs");
        health.SaveToTextfile(_statSheet); // save current version for display
        Tracker bmiHealthTracker = new Tracker();
        bmiHealthTracker.LoadItem(health);
        bmiHealthTracker.ObjectsToTextfile(_healthFile); // save for record                    
        
      }     
      if (_choice == "4") // if they chose "Add Food"
      {   
        _health.CreateScrollLine("\n\n\n"); // put decorative seperation line after main menu  
        RunAddFoodChoices(); // present the user the menu to "Add Food"                
      }       
      if (_choice == "5") // if they chose "Add Recipe"
      {
        _health.CreateScrollLine("\n\n\n"); // put decorative seperation line after main menu  
        RunAddRecipeChoices(); // present the user the menu to "Add Recipe" 
      }      
      if (_choice == "6") // if they chose "Add Exercise"
      {
        _health.CreateScrollLine("\n\n\n"); // put decorative seperation line after main menu  
        Exercise exercise= new Exercise();
        SelectionTracker exercises = new SelectionTracker();
        exercises.LoadItem(exercise);
        exercises.ObjectsToTextfile("exercises.txt");        
      }      
      if (_choice == "7") // if they chose "Display Itemss"
      {
        _health.CreateScrollLine("\n\n\n"); // put decorative seperation line after main menu  
        RunDisplayChoices();
      }                  
    }
  }

  // menu for the user to record a meal
  public string PresentRecordMealMenu()
  {    
    string selection = "No selection made.";    
    // save the menu to be passed into the validator method for use
    string recordMealMenuPrompt = "\nMake your selection by entering a number:\n  1 - Breakfast Input \n  2 - Lunch Input \n  3 - Dinner Input \n  4 - Snack Input \n  5 - Add Food \n  6 - Add Recipe  \n  7 - Return to Main Menu\nSelection: ";
    // pass the recordMealMenuPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator = new Validator("Use prompt", recordMealMenuPrompt);          
    selection = validator.SelectionCheck(7, "Do Confirm"); // get a valid entry & confirm as the user's choice
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
        SelectionTracker breakfastTracker = new SelectionTracker();
        breakfastTracker.LoadItem(breakfast);
        breakfastTracker.ObjectsToTextfile(_mealFile);        
        //  record the calories
        HealthStatus breakfastCalories = new HealthStatus("intake", "calories");
        Tracker healthTrackerBkCal = new Tracker();
        healthTrackerBkCal.LoadItem(breakfastCalories);
        breakfastCalories.SaveToTextfile(_mealFile);      
        break;
      case "2": // if they chose "Lunch Input"
        Meal lunch = new Meal("lunch", "%");
        SelectionTracker lunchTracker = new SelectionTracker();
        lunchTracker.LoadItem(lunch);
        lunchTracker.ObjectsToTextfile(_mealFile);        
        //  record the calories
        HealthStatus lunchCalories = new HealthStatus("intake", "calories");
        Tracker healthTrackerDCal = new Tracker();
        healthTrackerDCal.LoadItem(lunchCalories);
        lunchCalories.SaveToTextfile(_mealFile);      
        break;
      case "3": // if they chose "Dinner Input"
        Meal dinner = new Meal("dinner", "%");
        SelectionTracker dinnerTracker = new SelectionTracker();
        dinnerTracker.LoadItem(dinner);
        dinnerTracker.ObjectsToTextfile(_mealFile);        
        dinnerTracker.TextfileToOjects(_mealFile);
        //  record the calories
        HealthStatus dinnerCalories = new HealthStatus("intake", "calories");
        Tracker healthTrackerLCal = new Tracker();
        healthTrackerLCal.LoadItem(dinnerCalories);
        dinnerCalories.SaveToTextfile(_mealFile);           
        break;
      case "4": // if they chose "Snack Input"
        Meal snack = new Meal("snack", "%");
        SelectionTracker snackTracker = new SelectionTracker();
        snackTracker.LoadItem(snack);
        snackTracker.ObjectsToTextfile(_mealFile);        
        snackTracker.TextfileToOjects(_mealFile);
        //  record the calories
        HealthStatus snackCalories = new HealthStatus("intake", "calories");
        Tracker healthTrackerSnCal = new Tracker();
        healthTrackerSnCal.LoadItem(snackCalories);
        snackCalories.SaveToTextfile(_mealFile);          
        break;       
      case "5": // if they chose "Add Food"
        RunAddFoodChoices(); // present the user the menu to "Add Food"
        break;
      case "6": // if they chose "Add Recipe"
        RunAddRecipeChoices();
        break;    
      default: // if they chose "Return to Main Menu"        
        break; // do nothing to end this menu & return user to the main menu
    }  
  }

  // menu for the user to display the different lists
  public string PresentDisplayMenu()
  {    
    string selection = "No selection made."; 
    // save the menu to be passed into the validator method for use    
    string displayMenuPrompt = "\nMake your selection by entering a number:\n  1 - Display Food & Recipe List \n  2 - Display Meals \n  3 - Display Exercise List \n  4 - Display Recorded Exercises \n  5 - Display Your Health Statistics \n  6 - Return to Main Menu\nSelection: ";
    // pass the displayMenuPrompt into the object & for the user's 
    // entry value put "Use prompt" since user will change value after the prompt
    Validator validator = new Validator("Use prompt", displayMenuPrompt);          
    selection = validator.SelectionCheck(6, "Do Confirm"); // get a valid entry & confirm as the user's choice
    return selection; // return the user's selection
  }

  // method to run the user's choice for the "Display Menu" 
  public void RunDisplayChoices()
  {     
    string choice = PresentDisplayMenu(); // display menu options and return user's choice
    switch (choice)
    {
      // RUN OPTION USER CHOSE
      case "1": // if they chose "Display Food & Recipe List"
        Tracker Tracker = new Tracker();
        Tracker.TextfileToOjects("foods.txt");
        Tracker.DisplayObjects();
        Console.Write("\nPress Enter to Return to the Main Menu: ");
        Console.ReadLine();
        break;
      case "2": // if they chose "Display Meals"
        SelectionTracker mealTracker = new SelectionTracker();
        mealTracker.TextfileToOjects("JeremysMealRecord.txt");
        mealTracker.DisplayObjects();
        Console.Write("\nPress Enter to Return to the Main Menu: ");
        Console.ReadLine();
        break;
      case "3": // if they chose "Display Exercise List"
        SelectionTracker exercises = new SelectionTracker();               
        exercises.TextfileToOjects("exercises.txt");
        exercises.DisplayObjects();
        Console.Write("\nPress Enter to Return to the Main Menu: ");
        Console.ReadLine();
        break;
      case "4": // if they chose "Display Recorded Exercises"
        SelectionTracker exercised = new SelectionTracker();
        exercised.TextfileToOjects("ExerciseRecord.txt");
        exercised.DisplayObjects();
        Console.Write("\nPress Enter to Return to the Main Menu: ");
        Console.ReadLine();
        break;
      case "5": // if they chose "Display Recorded Exercises"       
        Tracker healthy = new Tracker();       
        healthy.TextfileToOjects(_healthFile);
        healthy.DisplayObjects();
        Console.Write("\nPress Enter to Return to the Main Menu: ");
        Console.ReadLine();
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
    string addFoodMenuPrompt = "\nMake your selection by entering a number:\n  1 - Add Fruit \n  2 - Add Vegetable \n  3 - Add Grain Food \n  4 - Add Dairy Food \n  5 - Add Protein Food \n  6 - Add Liquid \n  7 - Add Oil or Fat \n  8 - Add Other Food \n  9 - Return to Main Menu\nSelection: ";
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
        Tracker fruitTracker = new Tracker();
        fruitTracker.LoadItem(fruit);
        fruitTracker.ObjectsToTextfile("foods.txt");              
        break;
      case "2": // if they chose "Add Vegetable"
        Food veggie = new Food("vegetable", "cups");        
        Tracker veggieTracker = new Tracker();
        veggieTracker.LoadItem(veggie);
        veggieTracker.ObjectsToTextfile("foods.txt");              
        break;        
      case "3": // if they chose "Add Grain Food"
        Food grain = new Food("grain food", "cups");        
        Tracker grainTracker = new Tracker();
        grainTracker.LoadItem(grain);
        grainTracker.ObjectsToTextfile("foods.txt");        
        break;
      case "4": // if they chose "Add Dairy Food"
        Food dairy = new Food("dairy food", "cups");        
        Tracker dairyTracker = new Tracker();
        dairyTracker.LoadItem(dairy);
        dairyTracker.ObjectsToTextfile("foods.txt");       
        break;
      case "5": // if they chose "Add Protein Food"
        Food protein = new Food("protein food", "cups");        
        Tracker proteinTracker = new Tracker();
        proteinTracker.LoadItem(protein);
        proteinTracker.ObjectsToTextfile("foods.txt");       
        break;
      case "6": // if they chose "Add Liquid"
        Food liquid = new Food("liquid or drink", "cups");        
        Tracker liquidTracker = new Tracker();
        liquidTracker.LoadItem(liquid);
        liquidTracker.ObjectsToTextfile("foods.txt");       
        break;         
      case "7": // if they chose "Add Oil or Fat"
        Food oil = new Food("oil or fat", "cups");        
        Tracker oilTracker = new Tracker();
        oilTracker.LoadItem(oil);
        oilTracker.ObjectsToTextfile("foods.txt");       
        break;     
      case "8": // if they chose "Add Other Food"
        Food other = new Food("other food", "cups");        
        Tracker otherTracker = new Tracker();
        otherTracker.LoadItem(other);
        otherTracker.ObjectsToTextfile("foods.txt");       
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
        SelectionTracker dishTracker = new SelectionTracker();
        dishTracker.LoadItem(dish);
        dishTracker.ObjectsToTextfile("foods.txt");        
        break;
      case "2": // if they chose "Add Soup or Stew Recipe"
        Recipe soup = new Recipe("soup or stew", "cups");
        SelectionTracker soupTracker = new SelectionTracker();
        soupTracker.LoadItem(soup);
        soupTracker.ObjectsToTextfile("foods.txt");       
        break;       
      case "3": // if they chose "Add Salad Recipe"
        Recipe salad = new Recipe("salad", "cups");
        SelectionTracker saladTracker = new SelectionTracker();
        saladTracker.LoadItem(salad);
        saladTracker.ObjectsToTextfile("foods.txt");        
        break;
      case "4": // if they chose "Add Bread or Muffin Recipe"
        Recipe bread = new Recipe("bread or muffin", "pieces");
        SelectionTracker breadTracker = new SelectionTracker();
        breadTracker.LoadItem(bread);
        breadTracker.ObjectsToTextfile("foods.txt");       
        break;
      case "5": // if they chose "Add Sandwich, Wrap, or Taco Recipe"
        Recipe wrap = new Recipe("sandwich, wrap, or taco", "servings");
        SelectionTracker wrapTracker = new SelectionTracker();
        wrapTracker.LoadItem(wrap);
        wrapTracker.ObjectsToTextfile("foods.txt");       
        break;
      case "6": // if they chose "Add Meat Recipe"
        Recipe meat = new Recipe("meat", "cups");
        SelectionTracker meatTracker = new SelectionTracker();
        meatTracker.LoadItem(meat);
        meatTracker.ObjectsToTextfile("foods.txt");       
        break;        
      case "7": // if they chose "Add Seafood Recipe"
        Recipe seafood = new Recipe("seafood", "cups");
        SelectionTracker seaTracker = new SelectionTracker();
        seaTracker.LoadItem(seafood);
        seaTracker.ObjectsToTextfile("foods.txt");       
        break;     
      case "8": // if they chose "Add Vegetarian Recipe"
        Recipe vegetarian = new Recipe("vegetarian", "cups");
        SelectionTracker vegetarianTracker = new SelectionTracker();
        vegetarianTracker.LoadItem(vegetarian);
        vegetarianTracker.ObjectsToTextfile("foods.txt");        
        break; 
      case "9": // if they chose "Add Dessert Recipe"
        Recipe dessert = new Recipe("dessert", "cups");
        SelectionTracker dessertTracker = new SelectionTracker();
        dessertTracker.LoadItem(dessert);
        dessertTracker.ObjectsToTextfile("foods.txt");       
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

  // method to perform actions based on user input and conditionally set textfile names
  public void TextfileNameIfAction(string choice, string selected, bool exists, string textfileName, string username, string created)
  {
    if (choice == selected)
    {
      if (File.Exists(textfileName) == exists)
      {            
        _mealFile = textfileName;
        _exerciseFile = $"{username}_ExerciseRecord.txt";
        _healthFile = $"{username}_HealthRecord.txt";
        _statSheet = $"{username}_StatSheet.txt";
        Welcome("",username);          
      }
      else
      {
                                                      Console.Write("\nThe username ");
        Console.ForegroundColor = ConsoleColor.Green; Console.Write($"'{username}' ");
        Console.ForegroundColor = ConsoleColor.Red;   Console.WriteLine($"{created}.");
        Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Please try again.");
        Console.ResetColor();
        _mealFile = "no";
      }
    }
  }

  // method to require user to enter username to start program
  public void Login()
  {
    // #1 USER ASSIGNS THE MEAL _userName ****************************************************
    _mealFile = "no";
    string fillIn1 = "";    
    Welcome("to the ","Health Tracker");   
    while (_mealFile == "no")
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