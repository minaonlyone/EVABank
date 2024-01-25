using System.Collections.Generic;
using System.Linq;

public class AccountManager
{
    private List<Customer> customers;
    private AccountBST accountTree;

    public AccountManager()
    {
        customers = new List<Customer>();
        accountTree = new AccountBST();
    }

    public void AddCustomer(Customer customer)
    {
        if (customers.Any(c => c.CustomerId == customer.CustomerId))
            throw new InvalidOperationException("Customer already exists.");
        customers.Add(customer);
    }

    public void AddAccountToCustomer(Account account, int customerId)
    {
        var customer = customers.FirstOrDefault(c => c.CustomerId == customerId);
        if (customer == null)
            throw new InvalidOperationException("Customer not found");

        customer.AddAccount(account);
        accountTree.Insert(account);
    }

    // Methods for retrieving customer and account information
}
