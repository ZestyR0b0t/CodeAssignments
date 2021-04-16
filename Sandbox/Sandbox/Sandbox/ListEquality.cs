using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox
{
    class ListEquality
    {
        public static void TestListEquality()
        {
            // Test list equality for lists of integers
            List<int> intListA = new List<int>() { 1, 2 };
            List<int> intListB = new List<int>() { 1, 2 };

            bool areIntListsEqual = ListEquals(intListA, intListB);
            Console.WriteLine("Are integer lists equal? " + areIntListsEqual);

            // Test list equality for lists of People
            Person bob1 = new Person("Bob Greene", 1975);
            Person bob2 = new Person("Bob Greene", 1975);

            Person susan1 = new Person("Susan Smith", 1962);
            Person susan2 = new Person("Susan Smith", 1962);

            List<Person> personListA = new List<Person>() { bob1, susan1 };
            List<Person> personListB = new List<Person>() { bob2, susan2 };

            bool arePersonListsEqual = ListEquals(personListA, personListB);
            Console.WriteLine("Are person lists equal? " + arePersonListsEqual);
        }

        public static bool ListEquals<T>(List<T> aList, List<T> bList)
        {
            if (aList.Count != bList.Count)
            {
                return false;
            }

            for (int i = 0; i < aList.Count; i++)
            {
                if (aList[i].Equals(bList[i]) == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
