using System;
using System.Collections.Generic;


namespace Linked_List_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> thisList = new List<int>();
            thisList.Add(1);
            thisList.Add(2);
            thisList.Add(3);
            thisList.Add(4);

            thisList.RemoveAt(0);

            thisList.ForEach(Console.WriteLine);

            Console.WriteLine(thisList[0]);

            Console.ReadLine();
        }
    }
}
