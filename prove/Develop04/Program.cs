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
        ListingActivity buildActivity = new ListingActivity();
        ListingActivity activity = new ListingActivity(buildActivity.GetListingName(), buildActivity.GetListingDescription());
        int seconds = activity.Opening();
        // activity.SetInhaleTime();
        // activity.SetExhaleTime();
        activity.PrepareActivity(); 
        activity.PrepareListing();       
        activity.RunActivity(seconds, activity.ListingExercises);
        activity.DisplayCount();
        activity.EndActivity();        
        choice = activity.Closing();
        }
    }
}