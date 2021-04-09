using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> Attacks = new Stack<int>();

            Attacks.Push(1);
            Attacks.Push(2);
            Attacks.Push(3);

            Attacks.PrintAll();

            Console.WriteLine(Attacks.Peek());

            Attacks.Pop();

            Attacks.PrintAll();
            Console.WriteLine(Attacks.Peek());
        }
    }
}
