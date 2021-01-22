using System;

namespace InheritanceExercise01
{
    public class Check
    {
        private string _recipientName;
        private string _accountNumber;
        private double _amount;
        
        public Check(double amount, string accountNo, string recipient)
        {
            _amount = amount;
            _accountNumber = accountNo;
            _recipientName = recipient;
        }
    }
}
