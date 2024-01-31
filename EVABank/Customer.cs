public class Customer
{
	public string Name { get; private set; }
    public string Address { get; private set; }
	private string Password;
	private List<Account> customerAccounts = new List<Account>();

    public Customer(string name,string address,string password)
	{
		Name = name;
		Address = address;
		Password = password;

    }
	public void addAccount(Account acc) {
		customerAccounts.Add(acc);
    }
	public List<Account> listAccounts(string password)
	{
		if(password != Password)
		{
            throw new InvalidOperationException("Not authorize");
			
		}
		return customerAccounts;
	}
}

