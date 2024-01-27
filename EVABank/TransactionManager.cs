public class TransactionManager
{
    public void ProcessTransactions(TransactionQueue transactionQueue,AccountBST accountTree)
    {
        while (transactionQueue.HasTransactions)
        {
            var transaction = transactionQueue.DequeueTransaction();
            var account = accountTree.Search(transaction.AccountNumber);
            if (account != null)
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