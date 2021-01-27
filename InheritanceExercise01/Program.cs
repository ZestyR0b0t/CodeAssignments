using System;
using System.Collections.Generic;

namespace InheritanceExercise01
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Bank bank = new Bank();
            bool beenGreeted = false;
            string input = null;
            
            while (true)
            {
                if (beenGreeted)
                {
                    Console.WriteLine("\n What else may we do for you today?\n");
                    foreach (string service in bank.Services)
                    {
                        Console.WriteLine(" " + service);
                    }
                    Console.Write("\n > ");
                    input = Console.ReadLine();
                }

                if(beenGreeted == false)
                {
                    Console.WriteLine("\n Welcome to the VVonder Bank!\n What can we do for you today?\n");
                    foreach (string service in bank.Services)
                    {
                        Console.WriteLine(" " + service);
                    }
                    Console.Write("\n > ");
                    input = Console.ReadLine();
                    beenGreeted = true;
                }

                

                if (input.EqualsIgnoreCase("quit"))
                {
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

                    bank.UpdateActiveAccounts(new Checking(parsedInput[0], chkNo, Convert.ToDouble(parsedInput[2])));
                    foreach (Checking account in bank.GetActiveAccounts())
                    {
                        bank.GetActiveAccountBalances()[account.GetAccountNo()] = account.GetBalance();
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
                    
                    bank.UpdateActiveAccounts(new Savings(parsedInput[0], savNo, Convert.ToDouble(parsedInput[2]), Convert.ToDouble(parsedInput[3])));
                    foreach (Savings account in bank.GetActiveAccounts())
                    {
                        bank.GetActiveAccountBalances()[account.GetAccountNo()] = account.GetBalance();
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

                if (bank.GetActiveAccountBalances().ContainsKey(accountNo) == false)
                {
                    Console.WriteLine($"\n {accountNo} is not an active account.");
                    continue;
                }
                    
                if (input.EqualsIgnoreCase("check balance"))
                {
                    Console.WriteLine($"\n Current balance is ${bank.GetActiveAccountBalances()[accountNo]}");
                    continue;
                }

                foreach (Account account in bank.GetActiveAccounts())
                {
                    if(accountNo == account.GetAccountNo())
                    {
                        bank.AccessMyAccount(account);
                        return;
                    }
                }

                if(Convert.ToInt32(accountNo) < 2000)
                {
                    foreach (Checking account in bank.GetActiveAccounts())
                    {
                        if(accountNo == account.GetAccountNo())
                        {
                            bank.AccessMyChecking(account);
                            return;
                        }
                    }
                }

                if(Convert.ToInt32(accountNo) > 2000)
                {
                    foreach (Savings account in bank.GetActiveAccounts())
                    {
                        if(accountNo == account.GetAccountNo())
                        {
                            bank.AccessMySavings(account);
                            return;
                        }
                    }
                }

                if (input.EqualsIgnoreCase("deposit"))
                {
                    Console.WriteLine("\n Enter deposit amount:");
                    Console.Write("\n > ");
                    string depositAmount = Console.ReadLine();

                    bank.GetMyAccount().DepositFunds(Convert.ToDouble(depositAmount));
                    bank.GetMyAccount().ShowBalance();

                    bank.GetActiveAccountBalances()[bank.GetMyAccount().GetAccountNo()] = bank.GetMyAccount().GetBalance();
                    continue;
                }

                if (input.EqualsIgnoreCase("withdraw"))
                {
                    Console.WriteLine("\n Enter withdraw amount:");
                    Console.Write("\n > ");
                    string withdrawAmount = Console.ReadLine();

                    bank.GetMyAccount().WithdrawFunds(Convert.ToDouble(withdrawAmount));
                    bank.GetMyAccount().ShowBalance();

                    bank.GetActiveAccountBalances()[bank.GetMyAccount().GetAccountNo()] = bank.GetMyAccount().GetBalance();
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
                    bank.GetMySavingsAccount().ApplyInterestAnnually();
                    bank.GetMySavingsAccount().ShowBalance();
                    continue;
                    }
                }
            }
        }
    }
}
