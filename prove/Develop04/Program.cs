using System;

class Program
{
    static void Main(string[] args)
    {
        string choice = "run program";
        // create a menu object to run its method
        Menu menu = new Menu();
        // create a while loop to run until the user chooses "Quit"
        while (choice != "4")
        {
        // use the PresentMenu method to display menu options and return
        // the user's choice - then store it in the while loop variable
        choice = menu.PresentMenu();

        // testing
        ReflectionActivity buildActivity = new ReflectionActivity();
        ReflectionActivity activity = new ReflectionActivity(buildActivity.GetReflectionName(), buildActivity.GetReflectionDescription());
        int seconds = activity.Opening();
        // activity.SetInhaleTime();
        // activity.SetExhaleTime();
        activity.PrepareActivity(); 
        activity.PrepareExercises();       
        activity.RunActivity(seconds, activity.ReflectionExercises);
        activity.EndActivity();        
        choice = activity.Closing();
        }
    }
}