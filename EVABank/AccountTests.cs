using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class AccountTests
{
    [TestMethod]
    public void Deposit_ValidAmount_IncreasesBalance()
    {
        var account = new Account(1);
        var initialBalance = account.Balance;
        var depositAmount = 100m;
        account.Deposit(depositAmount);
        Assert.AreEqual(initialBalance + depositAmount, account.Balance);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Withdraw_MoreThanBalance_ThrowsException()
    {
        var account = new Account(1);
        account.Deposit(100m);
        account.Withdraw(200m);
    }
}
