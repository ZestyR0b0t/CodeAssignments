using System;

namespace InheritanceExercise01
{
    public class Check
    {
        private string _recipientName;
        private string _accountNo;
        private double _amount; 
        
        public Check(double amount, string accountNo, string recipient)
        {
            _amount = amount;
            _accountNo = accountNo;
            _recipientName = recipient;
        }

        public void GetCheckInfo()
        {
            Console.WriteLine($"\n When {_recipientName} uses this check, {_amount} will be withdrawn from {_accountNo}");
        }
    }
}
