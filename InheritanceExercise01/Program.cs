using System;

namespace InheritanceExercise01
{
    class Program
    {
        static void Main(string[] args)
        {   
            Random rnd = new Random();
            Bank bank = new Bank();

            bank.AssistCustomer(rnd);
        }
    }
}
