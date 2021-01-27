using System.Collections.Generic;

namespace InheritanceExercise01
{
    public class Bank
    {
        public List<string> Services = new List<string>
        {
            "Create Checking",
            "Create Savings",
            "Check Balance",
            "Write Check",
            "Withdraw",
            "Deposit",
            "Quit"
        };
        private List<Account> ActiveAccounts = new List<Account>();
        private Dictionary<string, double> ActiveAccountBalances = new Dictionary<string, double>();
        
        private Account _myAccount = null;
        private Checking _myCheckingAccount = null;
        private Savings _mySavingsAccount = null;

        public Bank()
        {

        }
        public void UpdateActiveAccounts(Account newAccount)
        {
            ActiveAccounts.Add(newAccount);
        }
        public List<Account> GetActiveAccounts()
        {
            return ActiveAccounts;
        }
        public Dictionary<string, double> GetActiveAccountBalances()
        {
            return ActiveAccountBalances;
        }
        public void AccessMyAccount(Account account)
        {
            _myAccount = account;
        }
        public void AccessMyChecking(Checking account)
        {
            _myCheckingAccount = account;
        }
        public void AccessMySavings(Savings account)
        {
            _mySavingsAccount = account;
        }
        public Account GetMyAccount()
        {
            return _myAccount;
        }
        public Savings GetMySavingsAccount()
        {
            return _mySavingsAccount;
        }
    }
}