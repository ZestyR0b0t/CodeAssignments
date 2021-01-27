using System;

namespace InheritanceExercise01
{
    class Program
    {
        static void Main(string[] args)
        {   
            Bank bank = new Bank();
            Random rnd = new Random();
            string input = null;

            bank.HandleCustomerNeeds(input, rnd);
        }
    }
}
