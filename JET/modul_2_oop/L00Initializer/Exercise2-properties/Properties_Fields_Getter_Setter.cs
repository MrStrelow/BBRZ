using Mit = MitProperties;
using Ohne = ohneProperties;

namespace MitProperties
{
    public class Shop
    {
        public string OenaceCode { get; }
        public double Kassa { get; set; }
        public Employee MyFirstEmployee { get; }
        public Shop PartnerShop { get; private set; }

        public Shop(string oenaceCode, Employee myFirstEmployee, Shop partnerShop = null)
        {
            OenaceCode = oenaceCode;
            MyFirstEmployee = myFirstEmployee;
            myFirstEmployee.Workplace = this;

            if (partnerShop is not null)
            {
                PartnerShop = partnerShop;
                PartnerShop.PartnerShop = this;
            }

            Kassa = 0;
        }

        public Shop() { }

        public void relocate(Employee employee)
        {
            throw new NotImplementedException();
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public Shop Workplace { get; set; }

       public void Working()
       {

            double diffSalaryKassa = Salary - Workplace.Kassa;
            double payment;

            if (diffSalaryKassa < 0)
            {
                payment = Salary;
                Workplace.Kassa -= Salary;
            }
            else if (Workplace.PartnerShop is not null) // hier gilt: diffSalaryKassa >= 0
            {
                if (Workplace.PartnerShop.Kassa >= diffSalaryKassa)
                { 
                    payment = Salary;
                    Workplace.Kassa = 0;
                    Workplace.PartnerShop.Kassa -= diffSalaryKassa;
                }
                else // hier gilt: Workplace.PartnerShop.Kassa < diffSalaryKassa
                {
                    payment = Workplace.Kassa + Workplace.PartnerShop.Kassa;
                    Workplace.Kassa = 0;
                    Workplace.PartnerShop.Kassa = 0;
                }
            }
            else
            {
                payment = Workplace.Kassa;
            }

            Console.WriteLine($"{Name} hat {payment:C} verdient bei einem Gehalt von {Salary:C}. Kassa: {Workplace.Kassa:C} - Kassa Partner: {Workplace.PartnerShop.Kassa:C} ");
        }
    }

    public enum Produkt
    {
       Standard,
       Papierflieger,
       Goldbarren
    }

    public class Kunde
    {
        public string Name { get; set; }
        public Shop Shop { get; set; }
        public Kunde Bekannter { get; set; }

        public Kunde(Kunde original) // Kopierkonstruktor
        {
            Name = original.Name;
            Shop = original.Shop;
            Bekannter = original.Bekannter;
        }

        public Kunde() { }

        public void Kaufen(Produkt produkt)
        {
            double preis = produkt switch
           {
               Produkt.Papierflieger => 2.5,
               Produkt.Goldbarren => 10000,
               _ => 1000
           };

           Shop.Kassa += preis;
           Console.WriteLine($"{Name} hat {produkt} für {preis:C} gekauft. Kassa: {Shop.Kassa:C}");
        }
    }
}

namespace ohneProperties
{
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
}

public class Program
{
    public static void CallMitProperties()
    {
        // Use the 'Mit' alias for types from MitProperties namespace
        Mit.Employee alice = new Mit.Employee { Name = "Alice", Salary = 3000 };
        Mit.Employee bob = new Mit.Employee { Name = "Bob", Salary = 3000 };

        // Note: 'bob' here is Mit.Employee, ensure constructor matches.
        // If myFirstEmployee in Shop constructor expects Mit.Employee, this is correct.
        Mit.Shop shopB = new Mit.Shop(oenaceCode: "DE67890", myFirstEmployee: bob);
        Mit.Shop shopA = new Mit.Shop(oenaceCode: "AT12345", myFirstEmployee: alice, partnerShop: shopB);

        Mit.Kunde max = new Mit.Kunde { Name = "Max", Shop = shopB };
        Mit.Kunde hannah = new Mit.Kunde { Name = "Anna", Shop = shopA, Bekannter = max };

        for (int i = 0; i < 10; i++)
        {
            // Specify the 'Produkt' from the 'Mit' namespace
            max.Kaufen(Mit.Produkt.Papierflieger);
        }

        hannah.Kaufen(Mit.Produkt.Goldbarren);
        hannah.Kaufen(Mit.Produkt.Goldbarren);

        for (int i = 0; i < 4; i++)
        {
            alice.Working();
        }

        for (int i = 0; i < 4; i++)
        {
            bob.Working();
        }

        Mit.Kunde sanna = new Mit.Kunde(hannah); // Uses Mit.Kunde's copy constructor
    }

    public static void CallOhneProperties()
    {
        // Use the 'Ohne' alias for types from ohneProperties namespace
        Ohne.Employee alice = new Ohne.Employee("Alice", 3000);
        Ohne.Employee bob = new Ohne.Employee("Bob", 3000);

        Ohne.Shop shopB = new Ohne.Shop("DE67890", bob, null);
        Ohne.Shop shopA = new Ohne.Shop("AT12345", alice, shopB);

        Ohne.Kunde max = new Ohne.Kunde("Max", shopB, null);
        Ohne.Kunde hannah = new Ohne.Kunde("Anna", shopA, max);

        for (int i = 0; i < 10; i++)
        {
            // Specify the 'Produkt' from the 'Ohne' namespace
            max.Kaufen(Ohne.Produkt.Papierflieger);
        }

        hannah.Kaufen(Ohne.Produkt.Goldbarren);
        hannah.Kaufen(Ohne.Produkt.Goldbarren);

        Ohne.Kunde sanna = new Ohne.Kunde(hannah); // Uses Ohne.Kunde's copy constructor

        for (int i = 0; i < 4; i++)
        {
            alice.Working();
        }

        for (int i = 0; i < 4; i++)
        {
            bob.Working();
        }
    }

    static void Main(string[] args)
    {
        CallMitProperties();
        Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
        CallOhneProperties();
    }
}