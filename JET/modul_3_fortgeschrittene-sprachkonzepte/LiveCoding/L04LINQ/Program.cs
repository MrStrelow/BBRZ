using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

// ===== 1. DATENMODELLE =====

public class Kunde
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Stadt { get; set; }
}

public class Standort
{
    public int Id { get; set; }
    public string Stadt { get; set; }
    public string Land { get; set; }
}

public class Verkauf
{
    public int KundenId { get; set; }
    public int StandortId { get; set; }
    public string Produktname { get; set; }
    public double Umsatz { get; set; }

    public override string ToString()
    {
        return $"Produkt: {Produktname}, Umsatz: {Umsatz:C} - StandortID: {StandortId}";
    }
}

public class Programm
{
    public static void PrintResults<T>(string title, IEnumerable<T> results)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n◽◽◽◽◽◽◽◽◽◽◽◽◽◽ {title} ◽◽◽◽◽◽◽◽◽◽◽◽◽◽");
        Console.ResetColor();

        if (results == null)
        {
            Console.WriteLine("Ergebnis-Sequenz ist null.");
            return;
        }

        if (!results.Any())
        {
            Console.WriteLine("Keine Ergebnisse gefunden.");
            return;
        }

        // Header aus den Properties des ersten Objekts generieren
        var first = results.First();
        var properties = first.GetType().GetProperties();
        var header = new StringBuilder();
        foreach (var prop in properties)
        {
            header.AppendFormat("{0,-20}", prop.Name);
        }
        Console.WriteLine(header.ToString());
        Console.WriteLine(new string('-', header.Length));

        // Datenzeilen ausgeben
        foreach (var item in results)
        {
            var row = new StringBuilder();
            foreach (var prop in properties)
            {
                row.AppendFormat("{0,-20}", prop.GetValue(item)?.ToString() ?? "NULL");
            }
            Console.WriteLine(row.ToString());
        }
        Console.WriteLine($"Zeilen: {results.Count()}");
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        var kunden = new List<Kunde>
        {
            new Kunde { Id = 1, Name = "Anna Schmidt", Stadt = "Wien" },
            new Kunde { Id = 2, Name = "Ben Meier", Stadt = "Linz" },
            new Kunde { Id = 3, Name = "Carla Huber", Stadt = "Wien" },
            new Kunde { Id = 4, Name = "David Fuchs", Stadt = "Berlin" }
        };

        var standorte = new List<Standort>
        {
            new Standort { Id = 100, Stadt = "Wien", Land = "Österreich" },
            new Standort { Id = 101, Stadt = "Linz", Land = "Österreich" },
            new Standort { Id = 102, Stadt = "Berlin", Land = "Deutschland" }
        };

        var verkaeufe = new List<Verkauf>
        {
            new Verkauf { KundenId = 1, StandortId = 100, Produktname = "Laptop", Umsatz = 1200.50 },
            new Verkauf { KundenId = 2, StandortId = 101, Produktname = "Maus", Umsatz = 49.99 },
            new Verkauf { KundenId = 1, StandortId = 100, Produktname = "Tastatur", Umsatz = 89.90 },
            new Verkauf { KundenId = 3, StandortId = 100, Produktname = "Monitor", Umsatz = 350.00 },
            new Verkauf { KundenId = 4, StandortId = 102, Produktname = "Laptop", Umsatz = 1400.00 },
            new Verkauf { KundenId = 2, StandortId = 101, Produktname = "USB-Hub", Umsatz = 25.00 }
        };

        // Denke an SQL! was gibt es alles dort?
        // SELECT alter, SUM(verkauf), categroy FROM Verkaufe WHERE alter > 18 GROUP BY category Having SUM(Verkauf) > 100
        // [SQL] Where
        var umssetzeMehrAls500 = verkaeufe.Where(verkauf => verkauf.Umsatz > 500); // eine deferred execution: wird erst bei consolwrite ausgeführt
        umssetzeMehrAls500 = from verkauf in verkaeufe where verkauf.Umsatz > 500 select verkauf;

        Console.WriteLine(string.Join("\n", umssetzeMehrAls500));

        // ToList()
        var wirdSofortAusgeführt = verkaeufe.Where(verkauf => verkauf.Umsatz > 500).ToList(); // keine deferred execution: wird sofort gmeacht

        // [SQL] Select()
        var IdVonUmssetzeMehrAls500 = verkaeufe.
            Where(verkauf => verkauf.Umsatz > 500).
            Select(verkauf => verkauf.KundenId);

        Console.WriteLine(string.Join("\n", IdVonUmssetzeMehrAls500)); 

        // Select mit Anonymen Objekten
        var NeuesObjektVonUmssetzeMehrAls500 = verkaeufe.
            Where(verkauf => verkauf.Umsatz > 500).
            Select(verkauf => new { id = verkauf.KundenId, ums = verkauf.Umsatz});

        Console.WriteLine(string.Join("\n", NeuesObjektVonUmssetzeMehrAls500));

        // First und FirstOrDefault
        var ersterUmsatzMehrAls500 = verkaeufe.FirstOrDefault(verkauf => verkauf.Umsatz > 500);
        Console.WriteLine(ersterUmsatzMehrAls500);

        try
        {
            var ersterUmsatzMehrAls500000 = verkaeufe.FirstOrDefault(verkauf => verkauf.Umsatz > 500000); // Exception wird geworfen
            Console.WriteLine(ersterUmsatzMehrAls500000);
        } 
        catch(Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }

        var ersterUmsatzMehrAls50000 = verkaeufe.FirstOrDefault(verkauf => verkauf.Umsatz > 50000); // Null wird zurückgeben (oder ein default wert, wenn definiert.)
        Console.WriteLine(ersterUmsatzMehrAls50000 is null); // true weil null

        // [SQL] OrderBy, OrderByDecending, ThenBy, ThenByDecending
        NeuesObjektVonUmssetzeMehrAls500 = verkaeufe.
            Where(verkauf => verkauf.Umsatz > 500).
            Select(verkauf => new { id = verkauf.KundenId, ums = verkauf.Umsatz }).
            OrderByDescending(u => u.ums). // erste sortierung
            ThenByDescending(u => u.id);  // innerhalb der ersten sortierung verwende diese sortierung.

        Console.WriteLine(string.Join("\n", NeuesObjektVonUmssetzeMehrAls500));

        // [SQL - Aggregationsfunktionen ohne GroupBy] - Sum, Average, Min, Max, Any, All
        var summeAlerUmsätze = verkaeufe.Sum(verkaeufe => verkaeufe.Umsatz);
        Console.WriteLine($"{summeAlerUmsätze:C}");

        // [SQL - Aggregationsfunktionen mit GroupBy] - Sum, Average, Min, Max, Any, All
        var guppierteVerkaeufeNachStandort = verkaeufe.GroupBy(verkaeufe => verkaeufe.StandortId);

        foreach (var gruppe in guppierteVerkaeufeNachStandort)
        {
            Console.WriteLine("++++++++++++++++");
            foreach (var verkauf in gruppe)
            {
                Console.WriteLine(verkauf);
            }
            Console.WriteLine("++++++++++++++++");
        }

        var summeDerVerkaeufeNachStandort = verkaeufe.
            GroupBy(verkaeufe => verkaeufe.StandortId).
            Select(gruppe => new
            { 
                StandortId = gruppe.Key,
                UmsatzProStandort = gruppe.Sum(u => u.Umsatz)
            }).
            Select(umsaetze => new {
                StandortId = umsaetze.StandortId,
                UmsatzProStandort = $"{umsaetze.UmsatzProStandort:C}"
            });

        Console.WriteLine(string.Join("\n", summeDerVerkaeufeNachStandort));


        // [SQL Having -> ist nur ein zeilenfilter, wie where, nur auf die Aggregierung, nach einem GroupBy] -> brauchen wir nicht. Verwenden where.
        Console.WriteLine("#################");
        var summeDerVerkaeufeNachStandortGroesser1000 = verkaeufe.
            GroupBy(verkaeufe => verkaeufe.StandortId).
            Select(gruppe => new
            {
                StandortId = gruppe.Key,
                UmsatzProStandort = gruppe.Sum(u => u.Umsatz)
            }).
            Where(umsaetze => umsaetze.UmsatzProStandort > 1000). // Das ist unser HAVING! 
            Select(umsaetze => new
            {
                StandortId = umsaetze.StandortId,
                UmsatzProStandort = $"{umsaetze.UmsatzProStandort:C}"
            });

        Console.WriteLine(string.Join("\n", summeDerVerkaeufeNachStandortGroesser1000));
        //------------------------------------------------------------------------
        // Guard Clauses mit LINQ

        // Übungen:
        var customers = new List<Customer>
        {
            new Customer { CustomerID = 1, Name = "John Smith", City = "New York" },
            new Customer { CustomerID = 2, Name = "Jane Doe", City = "Los Angeles" },
            new Customer { CustomerID = 3, Name = "Peter Jones", City = "New York" }
        };

        var sales = new List<Sale>
        {
            new Sale { OrderID = 1, CustomerID = 1, Product = "Laptop", Date = new DateTime(2023, 1, 15), Amount = 1200, Quantity = 1 },
            new Sale { OrderID = 2, CustomerID = 2, Product = "Mouse", Date = new DateTime(2023, 1, 20), Amount = 25, Quantity = 2 },
            new Sale { OrderID = 3, CustomerID = 1, Product = "Keyboard", Date = new DateTime(2023, 2, 5), Amount = 75, Quantity = 1 },
            new Sale { OrderID = 4, CustomerID = 3, Product = "Monitor", Date = new DateTime(2023, 2, 10), Amount = 300, Quantity = 1 },
            new Sale { OrderID = 5, CustomerID = 1, Product = "Webcam", Date = new DateTime(2023, 3, 1), Amount = 600, Quantity = 1 },
            new Sale { OrderID = 6, CustomerID = 2, Product = "Laptop", Date = new DateTime(2023, 3, 12), Amount = 1500, Quantity = null }, // Null-Wert für Demo
        };

        PrintResults("Aufgabe 1: Customers Head", customers.Take(5));
        PrintResults("Aufgabe 1: Sales Head", sales.Take(5));

        // === AUFGABE 2: Merge (SQL: JOIN) ===
        // Verbinde 'sales' und 'customers' über die 'CustomerID'. Das Ergebnis soll die Spalten aus beiden Listen enthalten.
        var data = sales.Join(customers,
            sale => sale.CustomerID,
            customer => customer.CustomerID,
            (sale, customer) => new
            {
                sale.OrderID,
                sale.CustomerID,
                sale.Date,
                sale.Amount,
                sale.Quantity,
                sale.Product,
                customer.Name,
                customer.City
            }
        );

        PrintResults("Aufgabe 2: Gejointe Daten (Merge)", data);


        // === AUFGABE 3: Filtern (SQL: WHERE) ===
        // Führe die folgenden Filterungen auf der gejointen 'data'-Liste durch.

        // High value customers: Alle Einträge mit Amount > 500
        throw new NotImplementedException("AUFGABE 3.1: Hier die LINQ-Lösung für 'High Value Sales' einfügen.");

        // Customers aus New York
        throw new NotImplementedException("AUFGABE 3.2: Hier die LINQ-Lösung für 'Kunden aus New York' einfügen.");

        // Beide Bedingungen: Kunden aus NY UND Amount > 500
        throw new NotImplementedException("AUFGABE 3.3: Hier die LINQ-Lösung für die kombinierte Bedingung einfügen.");

        // Nur bestimmte "Spalten" auswählen: Vom Ergebnis der vorigen Abfrage nur Name, City und Amount
        throw new NotImplementedException("AUFGABE 3.4: Hier die LINQ-Lösung für die Spaltenauswahl einfügen.");


        // === AUFGABE 4: Group By und Sorting ===

        // Verkaufsvolumen pro Kunde: Gruppiere nach Kunde und summiere den 'Amount'. Sortiere absteigend.
        throw new NotImplementedException("AUFGABE 4.1: Hier die LINQ-Lösung für das Verkaufsvolumen pro Kunde einfügen.");

        // Anzahl der Verkäufe pro Kunde: Gruppiere nach Kunde und zähle die Einträge.
        throw new NotImplementedException("AUFGABE 4.2: Hier die LINQ-Lösung für die Anzahl der Verkäufe pro Kunde einfügen.");

        // Beides kombiniert in einer Abfrage.
        throw new NotImplementedException("AUFGABE 4.3: Hier die LINQ-Lösung für die kombinierte Summe und Anzahl einfügen.");


        // === AUFGABE 5: SQL `HAVING` Equivalent ===
        // Finde alle Kunden, deren Gesamtumsatz (SUM(Amount)) größer als 1000 ist.
        throw new NotImplementedException("AUFGABE 5: Hier die LINQ-Lösung für das 'HAVING'-Äquivalent einfügen.");

        // Finde alle Kunden aus New York, deren Gesamtumsatz (SUM(Amount)) größer als 1000 ist.
        throw new NotImplementedException("AUFGABE 5: Hier die LINQ-Lösung für das 'HAVING'-Äquivalent einfügen.");
    }
     
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }

    public class Sale
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string Product { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public int? Quantity { get; set; } // Nullable, um dropna/fillna zu zeigen
    }
}