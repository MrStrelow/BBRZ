using EFCoreFirstSteps.Data;
using EFCoreFirstSteps.Model;

// über LINQ!
// NEUES GERICHT HINZUFÜGEN (Create)
var datenbank = new MyDbContext();

datenbank.Dishes.Add(
    new Dish() { 
        Name = "Tofu", Description = "joa guat halt", Price = 10.36
    }
);

datenbank.SaveChanges();

// ALLE GERICHTE AUSLESEN UND ANZEIGEN (Read)

// EIN GERICHT AKTUALISIEREN (Update)

// EIN GERICHT LÖSCHEN (Delete
Console.WriteLine("Hello, EF Core!");