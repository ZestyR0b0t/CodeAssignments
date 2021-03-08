using System;


namespace Linked_List_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            LList ThisList = new LList();
            ThisList.AddFirst(3);
            ThisList.AddFirst(2);
            ThisList.AddFirst(1);
            ThisList.AddLast(4);
            ThisList.Remove(3);
            ThisList.RemoveFirst();
            ThisList.RemoveLast();




            ThisList.PrintAll();
            Console.ReadLine();
        }
    }
}
