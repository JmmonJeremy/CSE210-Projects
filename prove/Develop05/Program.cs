using System;

/*
Requirements and what I did to exceed the requirements
1) All member variables are private, or they are protected if a derived class needs direct access.
    1 - I made all of the member variables private because in our class the lessons have said that choosing
    to make them private is the best choice.    
2) Each specific type of goal class is derived from a base class.
    2 - All of my goal classes OneOffGoal, HabitGoal, and AccrualGoal are derived from the Goal base class.    
3) Method overriding is used in all places where it is appropriate.
    3 - I used the method override on several methods: DivideAttributes, MarkComplete, CommunicateGoalCreation, 
    GetGoalType, CommunicateGoalRecording, CreateGoalTitleListing, ConvertGoalType, CreateListedGoal and CreateGoalText. I only used the override when the behavior was different in the derived goal class. Being able to use the virtual
    and override for a method is a pretty cool feature with Polymorphism. I found it very helpful to be able to make
    things happen without having to make up new methods and then to be able to call one method and have it do the 
    different things needed for that particular goal class.
4) All methods and member variables that could be shared among classes are defined in the base class.
    4 - I defined as much as I could in the base class that would be used in the derived classes. I was surprised how
    by how much of the functionality for each of the derived classes came from the base class. The derived classes
    then ended up just housing what was uniquely needed just for their class. I would list all of the things I 
    defined in the base class, but there is so much it would take too much space here. I had 12 attributes defined
    in the base class, some exampels are: _goalTitle, _description and _points. I had 45 methods that were defined
    in the base class, with 9 of those being virtual methods. That leaves 36 methods that were defined and used from
    the base class to run the general functionality of the goals. Some examples are: the DisplayScoreBoard,
    SetRetrievedOjects, ListGoals and DeleteGoal methods.
5) Simple goals can be displayed, checked off, and points received.
    5 - My "Simple Goal" class is entitled the OneOffGoal. You can display, check it off, and receive points for
    this goal type as required.
6) Eternal goals can be displayed and points received, but they cannot be marked as completed (which is the correct
behavior for these goals).
    6 - My "Eternal Goal" class is entitled HabitGoal. You can display these goals, receive points, but the goal
    never gets checked off and is always available to do again and earn points from again.
7) Checklist goals can be displayed and progress can be recorded incrementally. Points are awarded each time with a
bonus when the goal is finished. The goal shows as being completed when it has been accomplished the required number 
of times.
    7 - My "Checklist Goal" class is entitled AccrualGoal. You can display the goal and the progress is tracked and
    displayed as well. With each step of completion points are awarded and a bonus amount of points is given when
    the goal is finished. The goal also shows as being completed only after the required number of completions
    has been accomplished.
8) The user can create new goals and specify their parameters as defined in the program specification.
    8 - My program allows a user to create new goals and specify the parameters of goal type, title, description, 
    points, and for accrual goals - the number of times required to complete it and he amount of bonus points awarded
    when finished.
9) The list of goals along with the user's progress on those goals can be saved and loaded.
    9- My program provides the options and functionality to list the users goals and shows their title, description,
    and progress for those goals with a box checked as complete or left blank to show it as not complete. For the 
    accrual goals it also show the number of times required to complete it and how many times it has been completed.
    In addition the user can save their list of goals and the progress status and points to a file and can then load
    those saved list of goals at any time.
10) Vertical and horizontal whitespace (blank lines, indentation, braces) is correct throughout the program.
    10 - I have used patterns of indentation and whitespace for my programming files. I have also included very detailed
    comments throughout my files.
11) Classes and methods use TitleCase, member variables use _underscoreCamelCase, local variables use camelCase.
    11 - I have used TitleCase for my methods, _underscoreCamelCase for member variables and camelCase for local 
    variables.
12) The program exceeds the core requirements as explained in comments in the Program.cs.
    12 - I did a ton of things to exceed the core requirements. The description is below.
Other additional things I did to exceed the requirements were:
1) In addition to doing the required earned points display, I added a level display next to the earned points display. 
This required setting up a method to figure out and display when a user advances or declines in their level. I made
each level go in increments of 1000 points. The three text files in my Repository demonstrate the user at different
levels.
2) To add to the gamerization effect I added color and a scoreboard frame around the level and point score display.
This required methods for the top and bottom where I used colors and inserted characters to get the best display
look I could create in the console.
3) In addition to having the 6 menu optoins of #1 Create a new goal, #2 List your goals, #3 Save your goals, #4 Load
your goals, #5 Record goal completion and #6 Quit, I also added a detailed and colorful description display of what happened
after each option is chosen to help keep the user informed immediately with each choice. I did this with the additional
options I added as well. This add on alone, required a ton of time and work to accomplish.
4) In addition to the 6 menu options needed for the core requirements I added another 6 options to the menu. Those 
additional options are #1 Record a missed goal, #2 Reposition a goal, #3 delete a goal, #4 Change a goals' filename,
#5 Combine goals' files #6 Delete goal file. I will explain each option on their own.
5) The functionality of option #6 on my menu of "Record missed goal" allows the user to record a goal not completed
as desired and will subtract the points associated with that goal as a result. This can move the user's score and 
level number into negative numbers if it happens enough. My file "mygoals" demonstrates this.
6) The functionality of option #7 on my menu of "Reposition a goal" lists all of the goals for a user and allows them
to pick a goal by its number and move it to the place of another number in the list.
7) The functionality of option #8 on my menu of "Delete a goal" gives the user the option of deleting a goal of their
choosing from their list. It also provides colorful warnings that this will permanently delete their goal and requires
a second confirmation for the step to be completed and can be backed out of if the user desires.
8) The functionality of option #9 on my menu of "Change goals' filename" allows the user to change the filename
that their goals are saved under if they desire.
9) The functionality of option #10 on my menu of "Combine goals' files" allows a user to combine two different
files of goals into one file. The exception for this is, it will not combine two identical files of goals. It has
to be two different files of goals, so there are no repeats.
10) The functionality of option #11 on my menu of "Delete goal file" allows a user to delete a file of goals if they
desire. It comes with colorful warnings and requires more confirmations to be completed because of its permanent nature.
11) In addition to all of that work, I also added a Validation class with specific reusable validation methods for
all of the user input. I am very proud of this addition and how it is a very useful and reusable class. I put a ton 
of work into that to consolidate code that prevents incorrect entries int reusable methods.
12) in relation to the Validation class, I tested and put in redundancies for every step and entry to try and find
and prevent anything that would cause the program to crash. I put a lot of work and added messages in exception cases.
You will be able to see these messages anytime you try to enter wrong data or do something that you might think would
cause an issue. For example loading a list when their are no goals. Or trying to delete or move a goal when there are
no goals.

In conclusion, I went way, way above and beyond for this project! I did my best to make the program a top notch
program without any bugs.
*/

class Program
{
    static void Main(string[] args)
    {        
        // create a menu object to run its RunMainChoices method
        Menu menu = new Menu();
        // run the RunMainChoices metod until the user quits
        menu.RunMainChoices();
    }
}