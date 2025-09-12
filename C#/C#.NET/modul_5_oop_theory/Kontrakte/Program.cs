using System;

public class BankAccount
{
    //private decimal Balance;
    public decimal Balance { get; set; }

    public BankAccount(decimal initialBalance)
    {
        if (initialBalance < 0) throw new ArgumentException("Vorbedingung: Anfangsbetrag muss positiv sein.");
        Balance = initialBalance;
        CheckInvariant();
    }

    // Methode für eine Nachbedingung
    public void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Vorbedingung: Betrag muss positiv sein.");
        Balance += amount;
        CheckInvariant();  // Invariante: Balance darf nie negativ sein
    }

    // Methode für eine Nachbedingung
    public void Withdraw(decimal amount)
    {
        if (amount > Balance) throw new InvalidOperationException("Nachbedingung: Nicht genug Guthaben.");
        Balance -= amount;
        CheckInvariant();
    }

    private void CheckInvariant()
    {
        if (Balance < 0) throw new InvalidOperationException("Invariante: Der Kontostand darf nie negativ sein.");
    }
}

class Program
{
    static void Main()
    {
        var account = new BankAccount(100);
        account.Deposit(50);     // Balance: 150
        account.Withdraw(30);    // Balance: 120
        // account.Withdraw(200); // Löst eine Ausnahme aus: Nachbedingung verletzt
    }
}
