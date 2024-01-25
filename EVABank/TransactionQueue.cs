
using System.Collections.Generic;

public class TransactionQueue
{
    private Queue<Transaction> transactions = new Queue<Transaction>();

    public void EnqueueTransaction(Transaction transaction)
    {
        transactions.Enqueue(transaction);
    }

    public Transaction DequeueTransaction()
    {
        return transactions.Dequeue();
    }

    public bool HasTransactions => transactions.Count > 0;
}
