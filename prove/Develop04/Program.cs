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
        Activity activity = new Activity();
        int seconds = activity.Opening();
        activity.Spinner(seconds);
        activity.Closing();

        // Console.WriteLine("Hello Develop04 World!");
        }
    }
}