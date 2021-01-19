using System;

namespace DictionaryExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Phonebook myContacts = new Phonebook();
            
            while(true)
            {
                Console.WriteLine("Type a name to search phonebook, or \"exit\" to quit.\n");
                string input = Console.ReadLine().Trim();

                if (input == "exit" || input == "quit")
                {
                    Environment.Exit(0);
                    return;
                }
                myContacts.LookUpNumberBasedOnName(input);
                Console.WriteLine("-------------\n");
            }
        }
    }
}
                // If we get here, assume input string is the name of a person.

                // TODO: Try to find phone number for the specified person in our "phonebook".

                // TODO: If we find a phone number for the specified person, print it to console.

                // TODO: If we don't find a phone number for the specified person, write to console "No contact by the name of <what user typed> was found!"
