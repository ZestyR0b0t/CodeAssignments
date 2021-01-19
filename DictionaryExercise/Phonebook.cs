using System;
using System.Collections.Generic;

namespace DictionaryExercise
{
    public class Phonebook
    {
        private readonly Dictionary<string, string> firstDictionary = new Dictionary<string, string>();
        private const string PHONEBOOK_FILE = "phonebook.txt";
        
        public Phonebook()
        {
            InitPhonebookFromFile();
        }

        private void InitPhonebookFromFile()
        {
            string[] phonebookLines = System.IO.File.ReadAllLines(PHONEBOOK_FILE); // Read in all lines from "phonebook" file

            foreach (string phonebookLine in phonebookLines)
            {
                string[] nameAndNumber = phonebookLine.Split('|', StringSplitOptions.TrimEntries);

                string name = nameAndNumber[0];
                string phoneNumber = nameAndNumber[1];

                firstDictionary[name] = phoneNumber;
            }
        }
        public void LookUpNumberBasedOnName(string name)
        {
            if (firstDictionary.ContainsKey(name))
            {
                Console.WriteLine($"{firstDictionary[name]}");
                return;
            }
            Console.WriteLine($"No contact by the name of {name} was found!");
        }
    }
}
