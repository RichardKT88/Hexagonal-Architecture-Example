namespace Hex.Arch.Core.Domain;

public class Account
{
    public Guid Id { get; private set; }
    public string AccountNumber { get; private set; }
    public decimal Balance { get; private set; }
    public string Currency { get; private set; }

    public Account(Guid id, string accountNumber, string currency)
    {
        Id = id;
        AccountNumber = accountNumber;
        Balance = 0;
        Currency = currency;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Amount must be positive");
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Amount must be positive");
        if (Balance < amount) throw new InvalidOperationException("Insufficient funds");
        Balance -= amount;
    }
}
