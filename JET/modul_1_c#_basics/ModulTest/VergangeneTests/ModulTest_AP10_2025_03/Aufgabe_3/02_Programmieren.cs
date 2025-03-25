using System;

public class Kunde
{
    // Felder
    private string name;

    //Hat-Beziehungen
    private Kunde bekannterKunde;
    private Shop myOneAndOnlyShop;

    // Konstruktoren
    public Kunde(string name, Shop myOneAndOnlyShop, Kunde bekannterKunde = null)
    {
        this.name = name;
        this.myOneAndOnlyShop = myOneAndOnlyShop;

        if (bekannterKunde is not null)
        {
            this.bekannterKunde = bekannterKunde;
            bekannterKunde.bekannterKunde = this;
        }
    }

    public Kunde(Kunde toCopy)
    {
        name = toCopy.name;
        bekannterKunde = toCopy.bekannterKunde;
    }

    // Methoden
    public void Informieren(Produkt produkt)
    {
        if (bekannterKunde is null)
            throw new InvalidOperationException($"{name} kennt keinen anderen Kunden und kann sich nicht dadurch nicht informieren.");

        Console.WriteLine($"{name} informiert sich über das Produkt '{produkt}' bei {bekannterKunde.name}.");
    }

    public void Kaufen(Produkt produkt)
    {
        throw new NotImplementedException();
    }

    public void Bewerten()
    {
        throw new NotImplementedException();
    }
}

public class BusinessKunde : Kunde
{
    // Felder
    private bool allowedForCreditLine;

    //Hat-Beziehungen
    private List<Kunde> vertretet = new List<Kunde>();

    // Konstruktoren
    public BusinessKunde(string name, bool allowedForCreditLine, Shop myOneAndOnlyShop, Kunde wirdVertreten) : base(name, myOneAndOnlyShop)
    {
        this.allowedForCreditLine = allowedForCreditLine;
        vertretet.Add(wirdVertreten);
    }

    // Methoden
    public void requestCredit()
    {
        throw new NotImplementedException();
    }
}

public class RetailKunde : Kunde
{
    // Felder
    private bool hasBenefits;

    //Hat-Beziehungen

    // Konstruktoren
    public RetailKunde(string name, bool hasBenefits, Shop myOneAndOnlyShop) : base(name, myOneAndOnlyShop)
    {
        this.hasBenefits = hasBenefits;
    }

    // Methoden
    public void applyBenefit()
    {
        throw new NotImplementedException();
    }
}


public enum Produkt
{
    Laptop,
    Smartphone,
    Tablet,
    Fernseher
}

public class Employee
{
    // Felder
    private string name;
    private double salary;

    //Hat-Beziehungen
    private Shop shop;

    // Konstruktoren
    public Employee(string name, double salary, Shop shop = null)
    {
        this.name = name;
        this.salary = 2500;
        this.shop = shop;
    }

    public Employee(Employee toCopy)
    {
        this.name = toCopy.name;
        this.salary = toCopy.salary;
        this.shop = toCopy.shop;
    }

    // Methoden
    public void working()
    {
        throw new NotImplementedException();
    }

    public string GetName()
    {
        return name;
    }

    public void SetShop(Shop shop)
    {
        this.shop = shop;
    }
}

public class Shop
{
    // Felder
    private double kassa;
    private string oenaceCode;

    // Hat-Beziehungen
    List<Kunde> kunden = new List<Kunde>();
    List<Employee> employees = new List<Employee>();
    Shop partnerShop;

    // Konstruktoren
    public Shop(string oenaceCode, Employee myFirstEmployee, Shop partnerShop = null)
    {
        this.kassa = 0;
        employees.Add(myFirstEmployee);

        if (partnerShop is not null)
        {
            this.partnerShop = partnerShop;
            partnerShop.partnerShop = this;
        }
    }

    public Shop(Shop toCopy)
    {
        this.kassa = toCopy.kassa;
        this.oenaceCode = toCopy.oenaceCode;

        this.kunden = new List<Kunde>();
        foreach (var kunde in toCopy.kunden)
        {
            this.kunden.Add(new Kunde(kunde));
        }

        this.employees = new List<Employee>();
        foreach (var employee in toCopy.employees)
        {
            this.employees.Add(new Employee(employee));
        }

        this.partnerShop = toCopy.partnerShop;
    }

    // Methoden
    public void Relocate(Employee employee)
    {
        if (partnerShop == null)
        {
            throw new InvalidOperationException("Kein Partner-Shop vorhanden.");
        }

        if (employees.Contains(employee)) // Array.Exists(Employees, e => e.ID == employee.ID)
        {
            Console.WriteLine($"Shop: {GetHashCode()}");
            this.PrintEmployees();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");

            Console.WriteLine($"Shop: {partnerShop.GetHashCode()}");
            partnerShop.PrintEmployees();
            Console.WriteLine();

            employees.Remove(employee);
            partnerShop.employees.Add(employee);
            Console.WriteLine($"{employee.GetName()} wurde von {this.GetHashCode()} zu {partnerShop.GetHashCode()} versetzt.");

            Console.WriteLine();
            Console.WriteLine($"Shop: {GetHashCode()}");
            this.PrintEmployees();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");

            Console.WriteLine($"Shop: {partnerShop.GetHashCode()}");
            partnerShop.PrintEmployees();
        }
        else
        {
            throw new InvalidOperationException("Der Employee existiert nicht im aktuellen Shop.");
        }
    }

    private void PrintEmployees()
    {
        foreach (var emplyee in employees)
        {
            Console.WriteLine(emplyee.GetName());
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Employee alice = new Employee(name: "Alice", salary: 3000);
        Employee bob = new Employee(name: "Bob", salary: 3000);

        Shop shopB = new Shop(oenaceCode: "DE67890", myFirstEmployee: bob);
        Shop shopA = new Shop(oenaceCode: "AT12345", myFirstEmployee: alice, partnerShop: shopB);

        Kunde max = new Kunde("Max", shopB);
        Kunde hannah = new Kunde("Hannah", shopA, max);

        hannah.Informieren(Produkt.Laptop);  // müsste eigentlich einen try und catch block haben!
        max.Informieren(Produkt.Smartphone); // müsste eigentlich einen try und catch block haben!

        Shop shopACopy = new Shop(shopA);
        Kunde anna = new Kunde(hannah);
        Employee rob = new Employee(bob);

        Kunde isolde = new Kunde("Isolde", shopA);
        try
        {
            isolde.Informieren(Produkt.Fernseher); // wie hier.
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }


        // BONUS Aufgabe!
        try
        {
            shopA.Relocate(alice);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}