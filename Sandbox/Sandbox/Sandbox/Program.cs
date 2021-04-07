using System;
using System.Collections.Generic;

namespace Sandbox
{
    class Program 
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<int> listA = new List<int>();
            List<int> listB = new List<int>();

            listA.Add(1);
            listA.Add(2);

            listB.Add(1);
            listB.Add(2);
            CollectionEquals(listA, listB);
        }

        static bool CollectionEquals<T>(List<T> aList, List<T> bList) 
        {
            if (aList.Count != bList.Count)
            {
                return false;
            }

            for (int i = 0; i <= aList.Count; i++)
            {
                if (aList[i].Equals(bList[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
