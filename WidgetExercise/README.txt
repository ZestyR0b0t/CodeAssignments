WIDGET EXERCISE:

This exercise is a console application that is nearly complete. Essentially, the application generates a list of random "Widgets", 
each of which have a "description". The Widget descriptions are comprised of an adjective word, and a noun (object) word.

Currently, you can do the following in this application:
- print a list of controls
- print a list of the random widget descriptions
- exit the application

There is also command I added called "investigate" that the user can type, 
which should be followed by words that describe a widget the user is trying to investigate. 

For instance, if the user wants to investigate the "slimy crystal", they would type "investigate slimy crystal". 
I already handled the nitty-gritty user input stuff already, including separating out the "investigate" from the widget description provided by the user.

------

You don't need to handle any of lower-level input parsing stuff yourself. 

In Program.cs, you'll find a method with the following signature:
"public static void OnInvestigateWidget(string widgetDesc, List<Widget> widgets)"
This is being called when the user types "investigate" followed by other words. 

The "widgetDesc" parameter will be the words the user typed after "investigate", 
and "widgets" will be the list of randomly-generated widgets. 
This is where you'll be doing the majority of your work. 

------

I need you to add the following functionality for this "investigate" command:

1.) - If the widget description matches the description of one of the randomly-generated widgets, 
the terminal should print "That <widget object word> is <widget adjective word>!". 

EXAMPLE: 
INPUT = "investigate slimy crystal" 
OUTPUT =  "That crystal is slimy!".

2.) - If the widget description provided by the user does not match any of the randomly-generated widget descriptions: 
OUTPUT = "There is no <user-provided invalid widget description> to investigate." 

I have already written a method in Program.cs named "OnInvalidWidget(string widgetDesc)".
It'll print, "There is no..." string for you. 
OnInvalidWidget() doesn't check for validity, it just prints text. 
This method exists to help you work around one of the exercise restrictions.

-----

RESTRICTIONS:
- You may not add any additional methods or member variables to `Program.cs`. The only thing you may edit in `Program.cs` is the `OnInvestigateWidget` method.

- You may not directly add a `Console.WriteLine` call anywhere in `OnInvestigateWidget`. 
  You *are* allowed to call other methods that use `Console.WriteLine` (such as `OnInvalidWidget`) from within `OnInvestigateWidget`.

- You can add whatever you'd like to the `Widget` class in `Widget.cs`. 
  You may use `Console.WriteLine` in the code you add to this class.  Do not edit/remove existing methods or member variables.

- Do not edit `WidgetGenerator.cs`. Avoid looking at it too, if possible.