public class BankAccount
{
    private decimal balance; // private, nur innerhalb der Klasse zugänglich
    public decimal Balance => balance; // öffentlich, aber nur lesbar
    //public decimal Balance { get; }
    //public decimal Balance { set; }
    //public decimal Balance { get; set; }

    public decimal AnotherBalance
    {
        get {
            return balance; 
        }
        set
        {
            if (balance < 0) throw new Exception("");
            balance = value;
        }
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
            balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= balance)
            balance -= amount;
        CheckInvariant();
    }

    private void CheckInvariant()
    {
        if (Balance < 0) throw new InvalidOperationException("Invariante: Der Kontostand darf nie negativ sein.");
    }
}