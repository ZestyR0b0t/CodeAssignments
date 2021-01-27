using System;
using System.Collections.Generic;

namespace InheritanceExercise01
{
    public class Bank
    {
        private List<string> Services = new List<string>
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
        

        //Bank Operations
        private bool _customerGreeted = false;
        public void GreetCustomer(string input)
        {
            if (_customerGreeted)
            {
                Console.WriteLine("\n What else may we do for you today?\n");
            }

            if(_customerGreeted == false)
            {
                Console.WriteLine("\n Welcome to the VVonder Bank!\n What can we do for you today?\n");
                _customerGreeted = true;     
            }
            foreach (string service in Services)
            {
                Console.WriteLine(" " + service);
            } 

            Console.Write("\n > ");
            input = Console.ReadLine(); 
        }
        public void HandleCustomerNeeds(string input, Random rnd)
        {
            while (true)
            {
                GreetCustomer(input);
                if (input.EqualsIgnoreCase("quit"))
                {
                    Console.WriteLine("Have a nice day!");
                    Environment.Exit(0);
                    return;
                }

                if (input.EqualsIgnoreCase("create checking"))
                {
                    Console.WriteLine("\n Input: Name | Initial Deposit");
                    Console.Write("\n > ");
                    string createChecking = Console.ReadLine();
                    string[] parsedInput = createChecking.Split("|", StringSplitOptions.TrimEntries);

                    int chkNo = rnd.Next(1000, 1999);

                    UpdateActiveAccounts(new Checking(parsedInput[0], chkNo, Convert.ToDouble(parsedInput[2])));
                    foreach (Checking account in GetActiveAccounts())
                    {
                        GetActiveAccountBalances()[account.GetAccountNo()] = account.GetBalance();
                    }

                    Console.WriteLine($"\n Checking account created. Your account number is {chkNo}");
                    continue;
                }

                if (input.EqualsIgnoreCase("create savings"))
                {
                    Console.WriteLine("\n Input: Name | Initial Deposit | Interest Rate");
                    Console.Write("\n > ");
                    string createSavings = Console.ReadLine();
                    string[] parsedInput = createSavings.Split("|", StringSplitOptions.TrimEntries);

                    int savNo = rnd.Next(2000, 2999);
                    
                    UpdateActiveAccounts(new Savings(parsedInput[0], savNo, Convert.ToDouble(parsedInput[2]), Convert.ToDouble(parsedInput[3])));
                    foreach (Savings account in GetActiveAccounts())
                    {
                        GetActiveAccountBalances()[account.GetAccountNo()] = account.GetBalance();
                    }
                    
                    Console.WriteLine($"\n Savings account created. \n Your account number is {savNo}.");
                    continue;
                }

                if (input.EqualsIgnoreCase("write check"))
                {
                    Console.WriteLine("\n Please fill out  your check: Amount | Account Number | Recipient Name");
                    Console.Write("\n > ");
                    string checkInfo = Console.ReadLine();
                    string[] parsedCheckInfo = checkInfo.Split("|", StringSplitOptions.TrimEntries);

                    Check ThisCheck = new Check(Convert.ToDouble(parsedCheckInfo[0]), parsedCheckInfo[1], parsedCheckInfo[2]);
                
                    ThisCheck.GetCheckInfo();
                    continue;
                }



                Console.WriteLine("\n Please enter your account number");
                Console.Write("\n > ");
                string accountNo = Console.ReadLine();

                if (GetActiveAccountBalances().ContainsKey(accountNo) == false)
                {
                    Console.WriteLine($"\n {accountNo} is not an active account.");
                    continue;
                }
                    
                if (input.EqualsIgnoreCase("check balance"))
                {
                    Console.WriteLine($"\n Current balance is ${GetActiveAccountBalances()[accountNo]}");
                    continue;
                }

                foreach (Account account in GetActiveAccounts())
                {
                    if(accountNo == account.GetAccountNo())
                    {
                        AccessMyAccount(account);
                        return;
                    }
                }

                if(Convert.ToInt32(accountNo) < 2000)
                {
                    foreach (Checking account in GetActiveAccounts())
                    {
                        if(accountNo == account.GetAccountNo())
                        {
                            AccessMyChecking(account);
                            return;
                        }
                    }
                }

                if(Convert.ToInt32(accountNo) > 2000)
                {
                    foreach (Savings account in GetActiveAccounts())
                    {
                        if(accountNo == account.GetAccountNo())
                        {
                            AccessMySavings(account);
                            return;
                        }
                    }
                }

                if (input.EqualsIgnoreCase("deposit"))
                {
                    Console.WriteLine("\n Enter deposit amount:");
                    Console.Write("\n > ");
                    string depositAmount = Console.ReadLine();

                    GetMyAccount().DepositFunds(Convert.ToDouble(depositAmount));
                    GetMyAccount().ShowBalance();

                    GetActiveAccountBalances()[GetMyAccount().GetAccountNo()] = GetMyAccount().GetBalance();
                    continue;
                }

                if (input.EqualsIgnoreCase("withdraw"))
                {
                    Console.WriteLine("\n Enter withdraw amount:");
                    Console.Write("\n > ");
                    string withdrawAmount = Console.ReadLine();

                    GetMyAccount().WithdrawFunds(Convert.ToDouble(withdrawAmount));
                    GetMyAccount().ShowBalance();

                    GetActiveAccountBalances()[GetMyAccount().GetAccountNo()] = GetMyAccount().GetBalance();
                    continue;
                }

                if (input.EqualsIgnoreCase("apply interest"))
                {
                    if(Convert.ToInt32(accountNo) < 2000)
                    {
                        Console.WriteLine("Checking accounts do not accrue interest.");
                        continue;
                    }
                    else
                    {
                    GetMySavingsAccount().ApplyInterestAnnually();
                    GetMySavingsAccount().ShowBalance();
                    continue;
                    }
                }
            }
        }
    }
}