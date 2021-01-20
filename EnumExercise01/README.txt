ALL ABOUT ENUMS: PART 1
----------------------------

You're going to make a console application in which you type "X of Y", where "X" is a playing card rank, and "Y" is a playing card suit. Upon specifying
a valid rank and suit, the app will create a "Card" object with the associated rank and suit, then output info about the card.

I've already handled the input string splitting and stuff, so all you have to do is handle the parsing and the output. You should use enums to represent the valid
values for card ranks and suits, as well as to store the rank and suit on the "Card" object.

Please read the TODO comments in the code for more details (specifically on how to parse strings into enums, and how to auto-convert enums back into strings). 

RANKS: Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
SUITS: Clubs, Diamonds, Hearts, Spades


REMINDER ON HOW TO DEFINE AN ENUM:
public enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter
}

Note that the first value listed in an enum becomes the "default" value. When I say "default" value, I mean the value of the enum before anything is assigned to it 
(for more context, the default value of an integer is 0, and the default value of a boolean is false). Because of this, you will often see people
define the first value of an enum as "Unknown" or "None" to make it clear when no value has been assigned to an enum.