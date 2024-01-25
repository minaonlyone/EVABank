using System.Collections.Generic;

public class Customer
{
    public int CustomerId { get; private set; }
    public string Name { get; set; }
    public List<Account> Accounts { get; private set; }

    public Customer(int customerId, string name)
    {
        CustomerId = customerId;
        Name = name;
        Accounts = new List<Account>();
    }

    public void AddAccount(Account account)
    {
        Accounts.Add(account);
    }

    // You can add more customer-related methods here
}