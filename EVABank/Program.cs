using System;
using System.Collections.Generic;

class Program
{
    static AccountManager accountManager = new AccountManager();
    static TransactionQueue transactionQueue = new TransactionQueue();
    static Dictionary<int, Account> accounts = new Dictionary<int, Account>();

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
            Console.WriteLine("6. Exit");
            Console.Write("Option: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateAccount();
                    break;
                case "2":
                case "3":
                case "4":
                    if (accounts.Count == 0)
                    {
                        Console.WriteLine("No accounts available. Please create an account first.");
                        break;
                    }

                    Console.Write("Enter Account Number: ");
                    if (int.TryParse(Console.ReadLine(), out var accountNumber) && accounts.TryGetValue(accountNumber, out var account))
                    {
                        if (option == "2") HandleDeposit(account);
                        else if (option == "3") HandleWithdrawal(account);
                        else if (option == "4") Console.WriteLine($"Balance: {account.Balance}");
                    }
                    else
                    {
                        Console.WriteLine("Account not found.");
                    }
                    break;
                case "5":
                    ProcessTransactions();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    static void CreateAccount()
    {
        var newAccountId = accounts.Count + 1;
        var newAccount = new Account(newAccountId);
        accounts.Add(newAccountId, newAccount);
        Console.WriteLine($"New account created with Account Number: {newAccountId}");
    }

    static void HandleDeposit(Account account)
    {
        Console.Write("Enter deposit amount: ");
        if (decimal.TryParse(Console.ReadLine(), out var amount))
        {
            var transaction = new Transaction { AccountNumber = account.AccountNumber, Amount = amount, Date = DateTime.Now };
            transactionQueue.EnqueueTransaction(transaction);
            Console.WriteLine("Deposit queued for processing.");
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
    }

    static void HandleWithdrawal(Account account)
    {
        Console.Write("Enter withdrawal amount: ");
        if (decimal.TryParse(Console.ReadLine(), out var amount))
        {
            var transaction = new Transaction { AccountNumber = account.AccountNumber, Amount = -amount, Date = DateTime.Now };
            transactionQueue.EnqueueTransaction(transaction);
            Console.WriteLine("Withdrawal queued for processing.");
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
    }

    static void ProcessTransactions()
    {
        while (transactionQueue.HasTransactions)
        {
            var transaction = transactionQueue.DequeueTransaction();
            if (accounts.TryGetValue(transaction.AccountNumber, out var account))
            {
                try
                {
                    if (transaction.Amount >= 0) account.Deposit(transaction.Amount);
                    else account.Withdraw(-transaction.Amount);

                    Console.WriteLine($"Transaction processed for Account {transaction.AccountNumber}: {(transaction.Amount >= 0 ? "Deposit" : "Withdrawal")} of {Math.Abs(transaction.Amount)}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error processing transaction for Account {transaction.AccountNumber}: {e.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Account {transaction.AccountNumber} not found. Transaction skipped.");
            }
        }
    }
}
