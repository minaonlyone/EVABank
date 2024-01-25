using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TransactionProcessingTests
{
    [TestMethod]
    public void ProcessTransaction_DepositAndWithdraw_UpdatesBalanceCorrectly()
    {
        var account = new Account(1);
        var transactionQueue = new TransactionQueue();
        transactionQueue.EnqueueTransaction(new Transaction { AccountNumber = 1, Amount = 100m });
        transactionQueue.EnqueueTransaction(new Transaction { AccountNumber = 1, Amount = -50m });

        // Simulate processing transactions
        while (transactionQueue.HasTransactions)
        {
            var transaction = transactionQueue.DequeueTransaction();
            if (transaction.Amount >= 0)
                account.Deposit(transaction.Amount);
            else
                account.Withdraw(-transaction.Amount);
        }

        Assert.AreEqual(50m, account.Balance); // Example assertion
    }
}