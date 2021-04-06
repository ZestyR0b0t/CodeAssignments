using System;
using System.Collections.Generic;

namespace InterfacesAndGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            DemonstrateTimeStructs(); // TODO: Comment this out when you're done checking out the time stuff.

            // EXERCISE
            // 1. Update the TestBasicInterface() method in this class so that the age of each item in the list is printed to the console.
            //    This will require the creation of an interface, as well as modifications to the Person and Document classes.
            //    Also make sure to update the type of the array in the TestBasicInterface() method as instructed in the "TODO" comment.
            //
            // 2. The assertions in the TestGetOlder() method in this class should pass. In order to make sure that happens, you
            //    must implement the GetOlder() utility method in Utils.cs based on the instructions in the "TODO" comments above/within it.
            //    Also make sure to update the TestGetOlder() method in this class based on the "TODO" comments in it.
            //
            // EXTRA NOTE: The 'DateTime' and 'TimeSpan' types are used in this exercise. For more info on those types, scroll down
            // to the bottom of this file and view the comments and logic in the DemonstrateTimeStructs() method.

            TestBasicInterface();
            TestGetOlder(); 
        }

        static void TestBasicInterface()
        {
            Person finn = new Person("Finn", new DateTime(2015, 02, 14));
            Person bertha = new Person("Bertha", new DateTime(1934, 01, 23));
            Document docOld = new Document("older_doc.docx", new DateTime(1990, 12, 8));
            Document docNew = new Document("newer_doc.docx", new DateTime(2020, 1, 10));

            Object[] list = new Object[] { finn, docOld, bertha, docNew }; // TODO: Change the type of this array so that the items in it are not "Object", and you don't have to do any casting to get the age.
            uint[] agesInDays = new uint[list.Length];

            // TODO: Populate the 'agesInDays' array with the age (in days) of each item in 'list'. Do NOT perform any type checking or casting, besides casting from a double to a uint.

            // Printing out results...
            Console.WriteLine("\n--- RESULTS [TestBasicInterface] ---");
            for (int i = 0; i < agesInDays.Length; i++)
            {
                Console.WriteLine(agesInDays[i]);
            }
        }

        static void TestGetOlder()
        {
            Console.WriteLine("\n--- RESULTS [TestGetOlder] ---");

            // Testing Utils.GetOlder() with Person class
            Person finn = new Person("Finn", new DateTime(2015, 02, 14));
            Person bertha = new Person("Bertha", new DateTime(1934, 01, 23));

            Person resultPerson = (Person)Utils.GetOlder(finn, bertha); // TODO: Cast to (Person) only necessary here with 'Object' return type for GetOlder(). Once you refactor method to be generic, remove this cast.
            Utils.Assert(resultPerson == bertha, "Bertha was not returned as the oldest person!"); // Checks whether your logic works!

            // Testing Utils.GetOlder() with Document class
            Document docOld = new Document("older_doc.docx", new DateTime(1996, 6, 9));
            Document docNew = new Document("newer_doc.docx", new DateTime(2020, 1, 10));

            Document resultDoc = (Document)Utils.GetOlder(docOld, docNew); // TODO: Cast to (Document) only necessary here with 'Object' return type for GetOlder(). Once you refactor method to be generic, remove this cast.
            Utils.Assert(resultDoc == docOld, "older_doc.docx was not returned as the oldest document!"); // Checks whether your logic works!
        }

        // DEMO: Intro to DateTime/TimeSpan
        // https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-5.0
        // https://docs.microsoft.com/en-us/dotnet/api/system.timespan?view=net-5.0
        // You've never used DateTime or TimeSpan before, but they're super useful.
        // They represent a date/time, and a time interval (duration/elapsed time) respectively.
        // - DateTime.Now static property represents the current time.
        // - You can get the amount of time between two dates by doing dateTime1.Subtract(dateTime2), which will return a TimeSpan.
        // - You can get the value of the TimeSpan in a whole bunch of different units of measure (days/hours/minutes/seconds) using
        //   its properties. The ones that start with "Total" are what you want to use. https://docs.microsoft.com/en-us/dotnet/api/system.timespan?view=net-5.0#properties
        // - TimeSpan's "Total*" properties are all of type 'double'. Feel free to cast to a less precise type for this exercise.
        // - TimeSpans can be compared to one another using the greater-than and less-than operators. For == equality, they do NOT use reference equality--they actually compare the time data.
        static void DemonstrateTimeStructs()
        {
            Console.WriteLine("--- DEMO: DateTime/TimeSpan ---");

            DateTime rightNow = DateTime.Now;
            Console.WriteLine($"Current date/time: {rightNow}");

            TimeSpan oneYear = new TimeSpan(365, 0, 0, 0);
            Console.WriteLine($"One Year: {oneYear.Days}d {oneYear.Hours}h {oneYear.Minutes}m {oneYear.Seconds}s (Total time in seconds: {oneYear.TotalSeconds})");

            // Why doesn't TimeSpan let you specify years or months, you may ask?
            // Well, you tell me... how many days are in a month?
            // How many are in a year (remember, there is more than just the Gregorian calendar)?
            // That's why.

            DateTime sarahBirthday = new DateTime(1990, 12, 8, 23, 16, 0);
            TimeSpan timeSinceBirthday = rightNow.Subtract(sarahBirthday);

            Console.WriteLine($"Time since Sarah's birthday: {timeSinceBirthday.Days}d {timeSinceBirthday.Hours}h {timeSinceBirthday.Minutes}m {timeSinceBirthday.Seconds}s (Total time in seconds: {timeSinceBirthday.TotalSeconds})");
        }
    }
}
