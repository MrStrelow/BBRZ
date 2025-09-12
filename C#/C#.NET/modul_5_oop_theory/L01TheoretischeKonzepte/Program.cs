using System.IO.Pipes;
using System.Runtime.InteropServices;

public class Start
{
    static void Main(string[] args)
    {
        var account = BankAccount.getInstance();
        account.Balance = 5;

        var anotherAccount = BankAccount.getInstance();
        var yetAnotherAccount = BankAccount.getInstance();

        Console.WriteLine(account.Balance);
        Console.WriteLine(account == anotherAccount);
        Console.WriteLine(anotherAccount == yetAnotherAccount);
    }
}

public class AnotherSyntaxBankAccount
{
    private static AnotherSyntaxBankAccount _instance;
    private AnotherSyntaxBankAccount() { }

    public static AnotherSyntaxBankAccount Instance 
    {
        get 
        {
            if (_instance == null)
            {
                _instance = new AnotherSyntaxBankAccount();

            }

            return _instance;
        }
    }
}

public class BankAccount {
    private static BankAccount? _instance = null;

    public decimal Balance { get; set; }

    private BankAccount()
    {

    }

    // Ist für die Domain

    // Vorbedingung: amount muss positiv sein
    public void Deposit(decimal amount)
    {
        if (amount < 0) throw new ArgumentException("Vorbedingung: Betrag muss positiv sein."); 
        Balance += amount;

        // Invariante: Es soll immer gelten, dass Balance positive ist.
    }

    // Vorbedingung: amount muss positiv sein
    // Nachbedingung: amount darf nicht größer wie guthaben sein, nach der ausfürung von Withdraw.
    public void Withdraw(decimal amount)
    {
        if (amount < 0) throw new ArgumentException("Vorbedingung: Betrag muss positiv sein.");

        if (amount > Balance) throw new InvalidOperationException("Nachbedingung: Guthaben darf nach Withdraw nicht geringer wie 0 sein");
        
        Balance -= amount;

        // Invariante: Es soll immer gelten, dass Balance positive ist.
        CheckInvariant();
    }

    private void CheckInvariant()
    {
        if (Balance < 0) throw new InvalidOperationException("Invariante: Der Kontostand darf nie negativ sein.");
    }

    // Ist für den Aufbau.
    public static BankAccount getInstance()
    {
        if (_instance == null)
        {
            _instance = new BankAccount();

        }

        return _instance;
    }
}