using System;
using System.Collections.Generic;

namespace InheritanceExercise01
{
    class Bank 
    {   
        public enum Services
        {
            Create,
            Withdraw,
            Deposit, 
            Apply,
            Write,
            View,
            Quit
        };
        public enum Products
        {
            Unknown,
            Checking, 
            Savings, 
            Check, 
            Balance, 
            Interest,
        };
        private readonly List<string> ListOfServices = new List<string>
        {
            "Create Checking",
            "Create Savings", 
            "Apply Interest",
            "View Balance",
            "Write Check",
            "Withdraw",
            "Deposit",  
            "Quit"
        };
        private Dictionary<string, Account> ActiveAccounts = new Dictionary<string, Account>();
        private Dictionary<string, Checking> ActiveCheckingAccounts = new Dictionary<string, Checking>();
        private Dictionary<string, Savings> ActiveSavingsAccounts = new Dictionary<string, Savings>();
        private bool _greetedCustomer = false; 
        private bool _validRequest;
        
        public Bank()
        {

        }

        public void AssistCustomer(Random rnd)
        {
            while (true)
            {
                GreetCustomerOfferServices();
                CompleteService(ParseUserRequest(GetUserInput()), rnd);
            }
        }
        private void GreetCustomerOfferServices()
        {
            if (_greetedCustomer == true)
            {
                Console.WriteLine("\n Is there anything else we can do for you today?\n");
            }

            if (_greetedCustomer == false)
            {
                Console.WriteLine("\n Welcome to the VVonder Bank!");
                Console.WriteLine("\n How can we be of assistance today?\n");

                _greetedCustomer = true;
            }
            foreach (string service in ListOfServices)
            {
                Console.WriteLine(" " + service);
            }
        }
        private string GetUserInput()
        {
            Console.Write("\n > ");
            string input = Console.ReadLine();
            return input;
        }
        private Request ParseUserRequest(string input)
        {
            string[] parsedRequest = input.Split(" ", 2, StringSplitOptions.TrimEntries);
            string serviceRequested = parsedRequest[0];
            string productRequested = "unknown";
            
            if (serviceRequested.EqualsIgnoreCase("quit"))
            {
                Console.WriteLine("\n Have a nice day!");
                Environment.Exit(0);
                return null;
            }
            
            if (parsedRequest.Length == 2)
            {
                productRequested = parsedRequest[1];
            }

            Bank.Services service;
            if (Enum.TryParse<Bank.Services>(serviceRequested, true, out service) == false)
            {
                Console.WriteLine($"\n ** {serviceRequested} is not a valid service. **");
                _validRequest = false;
                return null;
            }

            Bank.Products product;
            if (Enum.TryParse<Bank.Products>(productRequested, true, out product) == false)
            {
                Console.WriteLine($"\n ** {productRequested} is not a valid product. **");
                _validRequest = false;
                return null;
            }

            Request request = new Request(service, product);
            _validRequest = true;
            return request;
        }
        private void CompleteService(Request request, Random rnd)
        {
            if (_validRequest == false)
            {
                return;
            }

            Services service = request.GetServiceRequest();
            Products product = request.GetproductRequest();

            if (service == Services.Create)
            {
                if (product == Products.Checking)
                {
                    Console.WriteLine("\n Please provide the following: Name | Initial Deposit");
                    string [] checkingInfo = GetUserInput().Split("|", StringSplitOptions.TrimEntries);
                    
                    double deposit;
                    Double.TryParse(checkingInfo[1], out deposit);

                    string number = Convert.ToString(rnd.Next(1000, 1999));

                    Checking checking = new Checking(checkingInfo[0], number, deposit);
                    ActiveCheckingAccounts[number] = checking;
                    ActiveAccounts[number] = checking;
                    Console.WriteLine($"\n Your new checking account number is {number}");
                    return;
                }

                if (product == Products.Savings)
                {
                    Console.WriteLine("\n Please provide the following: Name | Initial Deposit | Interest Rate");
                    string [] savingsInfo = GetUserInput().Split("|", StringSplitOptions.TrimEntries);
                    
                    double deposit;
                    Double.TryParse(savingsInfo[1], out deposit);
                    double rate;
                    Double.TryParse(savingsInfo[2], out rate);

                    string number = Convert.ToString(rnd.Next(2000, 2999));

                    Savings savings = new Savings(savingsInfo[0], number, deposit, rate);
                    ActiveSavingsAccounts[number] = savings;
                    ActiveAccounts[number] = savings;
                    Console.WriteLine($"\n Your new savings account number is {number}");
                    return;
                }
            }



            Console.WriteLine("\n Please enter your account number:");
            string accountNo = GetUserInput();



            if (ActiveAccounts.ContainsKey(accountNo) == false)
            {
                Console.WriteLine("\n This is not an active account.");
                return;
            }

            if (service == Services.Withdraw)
            {
                Console.WriteLine("\n How much would you like to withdraw?");
                double amount;
                Double.TryParse(GetUserInput(), out amount);

                ActiveAccounts[accountNo].WithdrawFunds(amount);
                return;
            }

            if (service == Services.Deposit)
            {
                Console.WriteLine("\n How much would you like to deposit?");
                double amount;
                Double.TryParse(GetUserInput(), out amount);

                ActiveAccounts[accountNo].DepositFunds(amount);
                return;
            }

            if (service == Services.View)
            {
                ActiveAccounts[accountNo].ShowBalance();
                return;
            }

            if (service == Services.Write)
            {
                if (ActiveCheckingAccounts.ContainsKey(accountNo))
                {
                    Console.WriteLine("\n Please provide the following: Recipient Name | Amount");
                    string [] checkInfo = GetUserInput().Split("|", StringSplitOptions.TrimEntries);
                    
                    string name = checkInfo[0];
                    double amount;
                    Double.TryParse(checkInfo[1], out amount);

                    Checking checking = ActiveCheckingAccounts[accountNo];
                    checking.WriteCheck(amount, checking.GetAccountNo(), name).GetCheckInfo();
                    return;
                }
                Console.WriteLine("\n You cannot write a check from this account.");
                return;
            }

            if (service == Services.Apply)
            {
                if (ActiveSavingsAccounts.ContainsKey(accountNo))
                {
                    ActiveSavingsAccounts[accountNo].ApplyInterestAnnually();
                    return;
                }
                Console.WriteLine("\n You cannot apply interest to this account.");
                return;
            }
        }
    }

    class Request
    {
        private readonly Bank.Services _service;
        private readonly Bank.Products _product;

        public Request(Bank.Services serviceRequested, Bank.Products productRequested)
        {
            _service = serviceRequested;
            _product = productRequested;
        }

        public Bank.Services GetServiceRequest()
        {
            return _service;
        }

        public Bank.Products GetproductRequest()
        {
            return _product;
        }

    }

}