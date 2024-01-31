using System;
using System.Collections.Generic;

class Program
{
    static AccountManager accountManager = new AccountManager();
    static TransactionQueue transactionQueue = new TransactionQueue();
    private static int lastAccountId = 0; // Class-level variable

    static void Main(string[] args)
    {
        Console.WriteLine("Banking Application");

        while (true)
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Create New Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Check Balance");
            Console.WriteLine("5. Process Transactions");
            Console.WriteLine("6. Retrieve all accounts");
            Console.WriteLine("7. Exit");
            Console.Write("Option: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateAccount();
                    break;
                case "2":
                    HandleDeposit();
                    break;
                case "3":
                    HandleWithdrawal();
                    break;
                case "4":
                    CheckBalance();
                    break;
                case "5":
                    ProcessTransactions();
                    break;
                case "6":
                    RetrieveAccountsInOrder();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    static int GenerateUniqueAccountId()
    {
        return ++lastAccountId; // Increment and return the new ID
    }

    static void CreateAccount()
    {
        var newAccountId = GenerateUniqueAccountId(); // Method to generate a unique account ID
        var newAccount = new Account(newAccountId);
        accountManager.AddAccount(newAccount); // Add the new account using AccountManager
        Console.WriteLine($"New account created with Account Number: {newAccountId}");
    }


    static void HandleDeposit()
    {
        Console.Write("Enter Account Number: ");
        if (int.TryParse(Console.ReadLine(), out var accountNumber))
        {
            Console.Write("Enter deposit amount: ");
            if (decimal.TryParse(Console.ReadLine(), out var amount))
            {
                var transaction = new Transaction { AccountNumber = accountNumber, Amount = amount, Date = DateTime.Now };
                transactionQueue.EnqueueTransaction(transaction);
                Console.WriteLine("Deposit queued for processing.");
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
        }
        else
        {
            Console.WriteLine("Invalid account number.");
        }
    }


    static void HandleWithdrawal()
    {
        Console.Write("Enter Account Number: ");
        if (int.TryParse(Console.ReadLine(), out var accountNumber))
        {
            Console.Write("Enter withdraw amount: ");
            if (decimal.TryParse(Console.ReadLine(), out var amount))
            {
                var transaction = new Transaction { AccountNumber = accountNumber, Amount = -amount, Date = DateTime.Now };
                transactionQueue.EnqueueTransaction(transaction);
                Console.WriteLine("Withdraw queued for processing.");
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
        }
        else
        {
            Console.WriteLine("Invalid account number.");
        }
    }

    static void CheckBalance()
    {
        Console.Write("Enter Account Number: ");
        if (int.TryParse(Console.ReadLine(), out var accountNumber))
        {
            try
            {
                var balance = accountManager.CheckBalance(accountNumber);
                Console.WriteLine($"Balance: {balance}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message); // Account not found or other errors
            }
        }
        else
        {
            Console.WriteLine("Invalid account number.");
        }
    }
    
    static void ProcessTransactions()
    {
        accountManager.Proccess(transactionQueue);
    }
    static void RetrieveAccountsInOrder() {
        accountManager.getAccounts();
    }
}
