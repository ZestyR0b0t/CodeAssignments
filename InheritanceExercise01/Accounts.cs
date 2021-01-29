using System;

namespace InheritanceExercise01
{
    public class Account
    {
        private readonly string _owner;
        private readonly string _accountNo;
        private double _balance;

        public Account(string owner, string accountNo, double initialDeposit)
        {
            _owner = owner;
            _accountNo = accountNo;
            _balance = initialDeposit; 
        }
        
        public string GetAccountNo()
        {
            return _accountNo;
        }
        public double GetBalance()
        {
            return _balance;
        }
        public void ShowBalance()
        {
            Console.WriteLine($"\n Current balance = ${GetBalance()}");
        }
        public void WithdrawFunds(double amount)
        {
            if (_balance >= amount)
            {
                _balance = _balance - amount;
                Console.WriteLine($"\n ${amount} has been withdrawn from your account.");
                return;
            }
            Console.WriteLine("Insufficient funds.");
        }
        public void DepositFunds( double amount)
        {
            _balance = _balance + amount;
            Console.WriteLine($"{amount} has been deposited to your account.");
            return;
        }
    }



    public class Checking : Account
    {
        public Checking(string owner, string accountNo, double initialDeposit) 
            : base(owner, accountNo, initialDeposit)
        {

        }

        public void WriteCheck(double amount, string accountNo, string recipient)
        {
            Check ThisCheck = new Check(amount, accountNo, recipient);
        }
    }



    public class Savings : Account
    {
        private double _interestRate; 

        public Savings(string owner, string accountNo, double initialDeposit, double rate) 
            : base(owner, accountNo, initialDeposit)
        {
            _interestRate = rate;
        }

        public void ApplyInterestAnnually()
        {
            DepositFunds(GetBalance() * _interestRate);
        }
    }
}

/***
CHECKING ACCOUNT:
Done - Account owner (string)
Done - Account number (string)
Done - Balance (double)
Done - Ability to specify an initial deposit upon creation
Done - Ability to withdraw funds
Done - Ability to deposit funds
Done - Ability to view current balance (just a "get" method)
Done - Ability to write checks

SAVINGS ACCOUNT:
Done - Account owner (string)
Done - Account number (string)
Done - Balance (double)
Done - Ability to specify an initial deposit upon creation
Done - Ability to withdraw funds
Done - Ability to deposit funds
Done - Ability to view current balance (just a "get" method)
Done - Interest Rate (this can, and usually will be, a fractional value -- use a "double")
Done - Ability to accrue interest annually
***/