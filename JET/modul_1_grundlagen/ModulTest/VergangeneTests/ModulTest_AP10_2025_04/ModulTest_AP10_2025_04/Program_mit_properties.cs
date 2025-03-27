//public class Shop
//{
//    public string OenaceCode { get; }
//    public double Kassa { get; set; }
//    public Employee MyFirstEmployee { get; }
//    public Shop? PartnerShop { get; private set; }

//    public Shop(string oenaceCode, Employee myFirstEmployee, Shop partnerShop = null)
//    {
//        OenaceCode = oenaceCode;
//        MyFirstEmployee = myFirstEmployee;
//        myFirstEmployee.Workplace = this;
//        if (partnerShop is not null)
//        {
//            PartnerShop = partnerShop;
//            PartnerShop.PartnerShop = this;
//        }
//        Kassa = 0;
//    }

//    public void relocate(Employee employee)
//    {
//        throw new NotImplementedException();
//    }
//}

//public class Employee
//{
//    public string Name { get; }
//    public double Salary { get; }
//    public Shop Workplace { get; set; }

//    public Employee(string name, double salary)
//    {
//        Name = name;
//        Salary = salary;
//    }

//    public void Working()
//    {

//        double diffSalaryKassa = Salary - Workplace.Kassa;
//        double payment;

//        if (diffSalaryKassa < 0)
//        {
//            payment = Salary;
//            Workplace.Kassa -= Salary;
//        }
//        else if (Workplace.PartnerShop is not null) // hier gilt: diffSalaryKassa >= 0
//        {
//            if (Workplace.PartnerShop.Kassa >= diffSalaryKassa)
//            { 
//                payment = Salary;
//                Workplace.Kassa = 0;
//                Workplace.PartnerShop.Kassa -= diffSalaryKassa;
//            }
//            else // hier gilt: Workplace.PartnerShop.Kassa < diffSalaryKassa
//            {
//                payment = Workplace.Kassa + Workplace.PartnerShop.Kassa;
//                Workplace.Kassa = 0;
//                Workplace.PartnerShop.Kassa = 0;
//            }
//        }
//        else
//        {
//            payment = Workplace.Kassa;
//        }

//        Console.WriteLine($"{Name} hat {payment:C} verdient bei einem Gehalt von {Salary:C}. Kassa: {Workplace.Kassa:C} - Kassa Partner: {Workplace.PartnerShop.Kassa:C} ");
//    }
//}

//public enum Produkt
//{
//    Standard,
//    Papierflieger,
//    Goldbarren
//}

//public class Kunde
//{
//    public string Name { get; }
//    public Shop Shop { get; }
//    public Kunde? Bekannter { get; }

//    public Kunde(string name, Shop shop, Kunde? bekannter = null)
//    {
//        Name = name;
//        Shop = shop;
//        Bekannter = bekannter;
//    }

//    public Kunde(Kunde original) // Kopierkonstruktor
//    {
//        Name = original.Name;
//        Shop = original.Shop;
//        Bekannter = original.Bekannter;
//    }

//    public void Kaufen(Produkt produkt)
//    {
//        double preis = produkt switch
//        {
//            Produkt.Papierflieger => 2.5,
//            Produkt.Goldbarren => 10000,
//            _ => 1000
//        };

//        Shop.Kassa += preis;
//        Console.WriteLine($"{Name} hat {produkt} für {preis:C} gekauft. Kassa: {Shop.Kassa:C}");
//    }
//}

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        Employee alice = new Employee(name: "Alice", salary: 3000);
//        Employee bob = new Employee(name: "Bob", salary: 3000);

//        Shop shopB = new Shop(oenaceCode: "DE67890", myFirstEmployee: bob);
//        Shop shopA = new Shop(oenaceCode: "AT12345", myFirstEmployee: alice, partnerShop: shopB);

//        Kunde max = new Kunde("Max", shopB);
//        Kunde hannah = new Kunde("Anna", shopA, max);

//        for (int i = 0; i < 1000; i++)
//        {
//            max.Kaufen(Produkt.Papierflieger);
//        }

//        hannah.Kaufen(Produkt.Goldbarren);

//        for (int i = 0; i < 4; i++)
//        {
//            alice.Working();
//        }

//        bob.Working();

//        // Erstellt eine Kopie von Shop A
//        Kunde sanna = new Kunde(hannah);
//    }
//}