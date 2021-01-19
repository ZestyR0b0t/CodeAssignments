This exercise is to help you get used to using Dictionaries!

WHAT IS A DICTIONARY?

Dictionaries are exactly what they sound like -- 
you can use them to "look up" one thing using another thing!
The thing you use to look something up is called the "key", 
and the thing that key maps to is called a "value".

So in the case of a real-world Dictionary...
KEY: "unicorn"
VALUE: "A mythical animal typically represented as a horse 
with a single straight horn projecting from its forehead."

KEY: "minotaur"
VALUE: "A monster shaped half like a man and half like a bull."

------

HOW TO USE DICTIONARIES:

What does a dictionary look like in code?
Dictionary<KEY TYPE, VALUE TYPE> myDictionary = new Dictionary<KEY TYPE, VALUE TYPE>();

For example, if we wanted to use string keys to look up integer values, 
the dictionary would be of type Dictionary<string, int>.

You can add "key-value pairs" to dictionaries using "indexers" (square brackets)... 
just like lists and arrays! 

For example:
Dictionary<string, int> numberForName = new Dictionary<string, int>();
numberForName["one"] = 1;
numberForName["two"] = 2;

Similarly, you can use indexers to retrieve values based on keys:
int numberOne = numberForName["one"];
int numberTwo = numberForName["two"];

If you want to iterate over the "key-value pairs" in a dictionary, 
you can use a foreach loop. You shouldn't need to do this at all in this exercise, 
but it's good to know.
The type of each item in the Dictionary is going to be KeyValuePair<KEY TYPE, VALUE TYPE>.

foreach (KeyValuePair<string, int> number in numberForName)
{
    string strNumber = number.Key;
    int intNumber = number.Value;
}

IMPORTANT NOTE:
If you attempt to retrieve a value using a key that does not exist in the dictionary, 
the program will throw a "KeyNotFoundException".
To avoid this, you should check if the dictionary contains the key before trying to get the value. 
You can do this by using the
"ContainsKey" method, which returns a boolean.

if (numberForName.ContainsKey("one"))
{
    int numberOne = numberForName["one"];
}

This is not the most efficient way of doing this, 
but it's the best thing to use with the tools you have now.

-------------------

EXERCISE OVERVIEW:

In this exercise, we're going to create a "virtual phonebook". 
How do you think we could use the Dictionary data structure to represent that?

The virtual phonebook should be populated using the "phonebook.txt" file I added to this project. 
I've provided a function that does most of the heavy-lifting 
when it comes to parsing that file -- but it doesn't store any of the values that get read in yet. 
You'll need to do that yourself, including figuring out where/how you want 
to store them (you'll see a "TODO" comment for this in "Phonebook.cs").

The end result of this exercise should be a console application where the user can type in a name,
and the console will print that person's phone number (if it exists in the phonebook).

No real rules here. The "TODO" comments will be your guide.