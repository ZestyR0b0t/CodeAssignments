using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		/***
		 * EXERCISE: CHRISTMAS SPECIAL!!!!
		 * 
		 * Santa is a bit under-the-weather this year, unfortunately, and Tim Allen isn't available to cover for him.
		 * In a last-ditch effort to save Christmas, Santa has hired us to code up a Santa AI to craft the gifts and
		 * deliver them to all the children!
		 *
		 * In this exercise, you'll want to...
		 * - Fill out the "Santa", "Child", and "Gift" classes with whatever methods, constructors, and member variables you need to get the job done. I'll provide more details below.
		 * - In this "Main" method, create five children with different names, some of whom are naughty and some of whom are nice. NOTE: Your logic should be able to support more than just five children.
		 * - In this "Main" method, add the children to a list, representing the children to whom gifts should be delivered.
		 * - In this "Main" method, create a "Santa", and have him craft gifts for the children. All gifts should be crafted before delivery of gifts to children begins.
		 * - In this "Main" method, have "Santa" deliver a gift to each child. Nice children should get "a toy", and naughty children should get "coal".
		 * - In this "Main" method, once all the gifts are delivered, have every child "tell us" (a.k.a. print to console) who they are, and what they received for Christmas (details below in "Expected Output" section).
		 *
		 * What I've already done for you:
		 * - Created the list in "Main" to which the children can be added. Remember, you use the List's "Add" method to add things to it!
		 * - Created "stub" (i.e. empty) classes that you'll need to fill out. Note that these are truly empty, and have no contructors, methods, 
		 *   or member variables. You'll need to add those yourself.
		 ***/
		
		/***
		 * GENERAL RULES/GUIDELINES:
		 * - The "static" keyword should not appear anywhere in this exercise.
		 * - The following classes should not contain any public member variables: Santa, Child, Gift
		 * - All private member variables added to classes should have a name prefixed with an underscore, to help differentiate them from other types of variables (e.g. local variables, parameters). Example: _name
		 * - Throughout this exercise, you'll find that you need the ability to access to certain bits of private data stored in a class from outside that class. For example, Santa will need to be able to tell
		 *   if a child is naughty or nice. You should feel free to provide the ability to do that... just keep the relevant variables themselves private.
		 * 
		 * SPECIFICS FOR EACH CLASS:
		 * I'm not going to tell you *exactly* what you need to do here, but I'm going to strongly nudge you in the right direction.
		 *
		 * CHILD:
		 * - Each child should have their own name, "nice/naughty" status (hmmm... could that be a boolean?), and a "stocking" (thematic way of saying "variable") in which their gift can be stored.
		 * - You should be able to specify what the child's name is, and whether they're naughty/nice when they're "born" (hint, hint).
		 * - Children don't have a gift in their "stocking" when they're born, but you should provide a way to give the child a gift later.
		 *
		 * GIFT:
		 * - A gift should store the name of what's contained within it. I'll just be straightforward here and say that you should store the contents of a gift as a string.
		 * - You should not able able to create a gift without specifying its contents (lol, imagine a gift that's just wrapping paper around... nothing)
		 * - A gift can only contain one thing, so the contents can safely be stored as a single string, rather than a list/array.
		 *
		 * SANTA:
		 * - Santa should have two bags: one for Gifts that contain toys, and one for Gifts that contain coal. This may seem a little overkill, but trust me, this will make your life easier.
		 * - No additional data needs to be specified when Santa is created. All that needs to exist when he gets created are the two bags.
		 * - Santa should have the ability to craft gifts, and subsequently add the crafted gifts to his bags.
		 * - Santa should have the ability to remove a gift from either of his bags and "return it" for the purposes of giving it to a child. A gift should not be given to a child without removing it from Santa's bag first.
		 *   IMPORTANT NOTE ABOUT REMOVING ITEMS FROM LISTS:
		 *   - To remove a particular item from a list (in this example, stored in a var named "myList"), call myList.Remove(item). Never do this within a "foreach" loop that iterates over the list from which you are removing items.
		 *   - To remove an item in a list at a particular index, call myList.RemoveAt(index). If you remove an item at any index besides the last one, all items that come after the removed item in the list "shift forward".
		 *     So if you have a list of 3 items, and you remove the item at index zero, the item that was previously at index 1 will now be at index 0, and the item previously at index 2 will be at index 1.
		 *   - If at any point you are having issues with removing items from the list, especially something that says "ConcurrentModificationException", please come to me and I'll steer you in the right direction.
		 ***/
		
		/***
		 * EXPECTED OUTPUT (one line per-child, word in <angle brackets> should be replaced with specified info):
		 * 
		 * My name is <child's name>, and I'm <naughty/nice>. I got <gift type> for Christmas!
		 ***/
		
		List<Child> childrenOfTheWorld = new List<Child>();
	}
}

public class Santa
{
	// TODO: Fill out this class!
}

public class Gift
{
	// TODO: Fill out this class!
}

public class Child
{
	// TODO: Fill out this class!
}