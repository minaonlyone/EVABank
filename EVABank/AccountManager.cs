using System.Collections.Generic;
using System.Linq;

public class AccountManager
{
    private AccountBST accountTree;
    private Queue<Account> accountQueue;
    private TransactionManager transactionManager;

    public AccountManager()
    {
        accountTree = new AccountBST();
        transactionManager = new TransactionManager();
        accountQueue = new Queue<Account>();
    }


    public void AddAccount(Account account)
    {
        accountTree.Insert(account);
        accountQueue.Enqueue(account);
    }

    public void Deposit(int accountNumber, decimal amount)
    {
        var account = accountTree.Search(accountNumber);
        if (account == null)
            throw new InvalidOperationException("Account not found.");

        account.Deposit(amount);
    }


    public decimal CheckBalance(int accountNumber)
    {
        var account = accountTree.Search(accountNumber);
        if (account == null)
            throw new InvalidOperationException("Account not found.");

        return account.Balance;
    }
    public void getAccounts() { 
        if(accountQueue.Count<0)
            return ; 
        while(accountQueue.Count > 0)
        {
           var account= accountQueue.Dequeue();
            Console.WriteLine(account.AccountNumber);
        }
    
    }


    public void Proccess(TransactionQueue transactionQueue)
    {
        transactionManager.ProcessTransactions(transactionQueue, accountTree);
    }

    // Methods for retrieving customer and account information
}
