using System;

/*
Requirements and what I did to exceed the requirements
1) Use inheritance by having a separate class for each kind of activity with a base class to contain any shared attributes or behaviors.
    1 - I used the base class of Activity and used inheritance for the BreathingActivity, ReflectionActivity, and ListingActivity classes.
    
2) Avoid duplicating code in classes where it could instead be placed in a base class.
    2 - I avoided duplicationg code in classes by having the derived classes use the base class constructor, the SetSpinnerSymbols, 
    GetSpinnerSymbols, Spinner, Opening, PrepareActivity, EndActivity, Closing, and RunActivity methhods.
3) Follow the principles of encapsulation and abstraction by having private member variables and putting related items in the same class.
    3 - I used the principle of encapsulation by making all of the member variables private. I used the principle of abstraction by keeping
    related code in their respective classes. I created and used the base class of #1 Activity, with the derived classes of #2 Breathing Activity, 
    #3 ReflectionActivity, and #4 ListingActivity. In addition, I created and used the #5 Menu class, #6 Validator class, #7 FileListRelationship
    class.
Other additional things I did to exceed the requirements were:
1) I created a very acurrate spinner method that counts the seconds and is tested accurate to the second for up to 15 minutes. I assume it is
accurate no matter what the time amount is, but I tested it for 5, 10, and 15 minutes - as well as shorter time spans. 
2) I inserted and used different symbols for the spinner to try and make the spinner a have more character.
3) I had the spinner count go up to 10 and then restart the count at the beginning of the line for every count of 10 ie. 10, 20, 30, etc
3) I used different inserted symbols and colors for number count and the spinner background with the different activites. 
4) I used the Activity class for a timed activity to be used and added it to the menu.
5) I used a set of beeps at the end of the timed activity selection to notify the user their time was up for the activity. For Windows OS
I used different tones to make the signal melodic. For other operating systems I used try and catch to stop the exception and then used the 
generic beep that was available.
6) I added 2 special classes: #1 for validation of user input and #2 for saving lists to a file and then converting a file into a list.
7) I made it so that no prompt would be used again until they have been used once during a session.
8) I then went a step further and made it so that no prompt would be used again until they had all been used even if you start the program over
again, by saving the lists to a file and updating the lists from that file when the program is run again.
*/

class Program
{
    static void Main(string[] args)
    {        
        // create a menu object to run its method
        Menu menu = new Menu();
        // run the choices of the user
        menu.RunChoices();
       
    }
}