using System;
using System.Collections.Generic;

namespace DictionaryExercise
{
    public class Phonebook
    {
        private const string PHONEBOOK_FILE = "phonebook.txt";
        
        public Phonebook()
        {
            // Empty contstructor, you can remove this if you don't want to use it.
        }

        // Initializes our phonebook from a file. This should only ever be called once. When do you think the best time to call this would be?
        private void InitPhonebookFromFile()
        {
            string[] phonebookLines = System.IO.File.ReadAllLines(PHONEBOOK_FILE); // Read in all lines from "phonebook" file

            foreach (string phonebookLine in phonebookLines)
            {
                // Each line in the file is formatted like this:
                // PERSON NAME | PHONE NUMBER
                string[] nameAndNumber = phonebookLine.Split('|', StringSplitOptions.TrimEntries);

                string name = nameAndNumber[0];
                string phoneNumber = nameAndNumber[1];

                // TODO: Add name and phone number to our phonebook
            }
        }
    }
}
