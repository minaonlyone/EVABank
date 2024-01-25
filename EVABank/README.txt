This console-based C# banking application provides a simple yet effective demonstration of various Object-Oriented Programming (OOP) principles, data structures, and standard programming practices. It allows users to create accounts, perform transactions (deposits and withdrawals), and process these transactions.

Features
Account Creation: Users can create new bank accounts.
Deposits and Withdrawals: Users can deposit or withdraw money, which are queued as transactions.
Transaction Processing: Processes all queued transactions, updating account balances.
Balance Inquiry: Users can check the balance of an account.
OOP Principles Used
Encapsulation: Data and methods are bundled into classes like Account, Customer, and Transaction.
Inheritance: Not explicitly used in the current design but can be incorporated, for example, by having different types of accounts inherit from a base Account class.
Polymorphism: Can be implemented for different types of transactions or account operations.
Abstraction: The AccountManager and TransactionQueue classes abstract complex operations like managing accounts and handling transactions.
Data Structures
Dictionary: Used for storing and retrieving accounts efficiently.
Queue: Used in TransactionQueue to manage transactions in a FIFO (First In First Out) manner.
Test Case Scenarios
Positive Tests
Create Account: Verify that a new account can be successfully created.
Deposit Money: Test depositing a valid amount to an account.
Withdraw Money: Test withdrawing an amount smaller than the account balance.
Check Balance: Verify that the balance inquiry shows the correct amount after transactions.
Process Transactions: Ensure that processing transactions updates account balances correctly.
Negative Tests
Invalid Account Creation: Attempt to create an account with invalid details.
Deposit Negative Amount: Try depositing a negative amount and expect an error.
Overdraft Withdrawal: Attempt to withdraw more than the account balance.
Invalid Account Operations: Perform operations on a non-existent account.
Empty Transaction Processing: Process transactions when the queue is empty.