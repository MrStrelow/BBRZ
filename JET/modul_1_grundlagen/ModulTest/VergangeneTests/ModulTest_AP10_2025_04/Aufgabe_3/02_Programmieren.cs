namespace javalike;

public class Shop
{
    private string oenaceCode;
    private double kassa;
    private List<Employee> employees = new List<Employee>(); // muss aber nicht weiter implementiert werden.
    //private List<Employee> employees = []; // oder kurz
    private List<Kunde> kunden = new List<Kunde>(); // muss aber nicht weiter implementiert werden...
    //private List<Kunde> kunden = []; // oder kurz
    private Shop partnerShop;

    public Shop(string oenaceCode, Employee myFirstEmployee, Shop partnerShop) // ... deshalb muss es auch hier kein Kunde übergeben werden.
    {
        this.oenaceCode = oenaceCode;
        employees.Add(myFirstEmployee);
        this.partnerShop = partnerShop;
        myFirstEmployee.SetWorkplace(this);

        if (partnerShop != null)
        {
            this.partnerShop.SetPartnerShop(this);
        }

        this.kassa = 0;
    }

    public string GetOenaceCode()
    {
        return oenaceCode;
    }

    public double GetKassa()
    {
        return kassa;
    }

    public void SetKassa(double value)
    {
        kassa = value;
    }

    public Shop GetPartnerShop()
    {
        return partnerShop;
    }

    public void SetPartnerShop(Shop partner)
    {
        partnerShop = partner;
    }
}

public class Employee
{
    private string name;
    private double salary;
    private Shop workplace;

    public Employee(string name, double salary)
    {
        this.name = name;
        this.salary = salary;
    }

    public string GetName()
    {
        return name;
    }

    public double GetSalary()
    {
        return salary;
    }

    public Shop GetWorkplace()
    {
        return workplace;
    }

    public void SetWorkplace(Shop workplace)
    {
        this.workplace = workplace;
    }

    public void Working()
    {
        double diffSalaryKassa = salary - workplace.GetKassa();
        double payment;

        if (diffSalaryKassa < 0)
        {
            payment = salary;
            workplace.SetKassa(workplace.GetKassa() - salary);
        }
        else if (workplace.GetPartnerShop() != null)
        {
            if (workplace.GetPartnerShop().GetKassa() >= diffSalaryKassa)
            {
                payment = salary;
                workplace.SetKassa(0);
                workplace.GetPartnerShop().SetKassa(workplace.GetPartnerShop().GetKassa() - diffSalaryKassa);
            }
            else
            {
                payment = workplace.GetKassa() + workplace.GetPartnerShop().GetKassa();
                workplace.SetKassa(0);
                workplace.GetPartnerShop().SetKassa(0);
            }
        }
        else
        {
            payment = workplace.GetKassa();
        }

        // {payment:C} ist die Kurzform von payment.ToString("C");
        Console.WriteLine($"{name} hat im Shop {workplace.GetHashCode()} - {payment:C} verdient. Das Gehalt ist {salary:C}. Kassa: {workplace.GetKassa():C} - Kassa Partner: {workplace.GetPartnerShop().GetKassa():C}");
    }
}

public class Kunde
{
    private string name;
    private Shop shop;
    private Kunde bekannter;

    public Kunde(string name, Shop shop, Kunde bekannter)
    {
        this.name = name;
        this.shop = shop;
        this.bekannter = bekannter;
    }

    public Kunde(Kunde original)
    {
        this.name = original.GetName();
        this.shop = original.GetShop();
        this.bekannter = original.GetBekannter();
    }

    public string GetName()
    {
        return name;
    }

    public Shop GetShop()
    {
        return shop;
    }

    public Kunde GetBekannter()
    {
        return bekannter;
    }

    public void Kaufen(Produkt produkt)
    {
        double preis;
        if (produkt == Produkt.Papierflieger)
        {
            preis = 2.5;
        }
        else if (produkt == Produkt.Goldbarren)
        {
            preis = 10000;
        }
        else
        {
            preis = 1000;
        }

        shop.SetKassa(shop.GetKassa() + preis);

        Console.WriteLine($"{name} hat {produkt} für {preis:C} gekauft. Kassa von Shop {shop.GetHashCode()}: {shop.GetKassa():C}");
    }
}

public enum Produkt
{
    Standard,
    Papierflieger,
    Goldbarren
}

public class Program
{
    public static void Main(string[] args)
    {
        Employee alice = new Employee("Alice", 3000);
        Employee bob = new Employee("Bob", 3000);

        Shop shopB = new Shop("DE67890", bob, null);
        Shop shopA = new Shop("AT12345", alice, shopB);

        Kunde max = new Kunde("Max", shopB, null);
        Kunde hannah = new Kunde("Anna", shopA, max);

        for (int i = 0; i < 10; i++)
        {
            max.Kaufen(Produkt.Papierflieger);
        }

        hannah.Kaufen(Produkt.Goldbarren);
        hannah.Kaufen(Produkt.Goldbarren);

        Kunde sanna = new Kunde(hannah);

        // BONUS Aufgabe!
        for (int i = 0; i < 4; i++)
        {
            alice.Working();
        }

        for (int i = 0; i < 4; i++)
        {
            bob.Working();
        }

    }
}