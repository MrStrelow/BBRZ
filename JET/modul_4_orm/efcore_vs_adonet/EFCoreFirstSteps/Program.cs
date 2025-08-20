using Fruehstuecksrestaurant.Data;
using Fruehstuecksrestaurant.Models;
using System;
using System.Linq;

using (var context = new ApplicationDbContext())
{
    // NEUES GERICHT HINZUFÜGEN
    Console.WriteLine("Füge ein neues Gericht hinzu...");
    context.Dishes.Add(new Dish
    {
        Name = "Pancakes",
        Description = "Mit Ahornsirup und Früchten",
        Price = 7.50
    });
    context.SaveChanges();
    Console.WriteLine("Gericht hinzugefügt!");
    Console.WriteLine();

    // ALLE GERICHTE AUSLESEN UND ANZEIGEN
    Console.WriteLine("Alle Gerichte in der Datenbank:");
    var dishes = context.Dishes.ToList();
    foreach (var dish in dishes)
    {
        Console.WriteLine($" - {dish.Name}: {dish.Description} ({dish.Price} EUR)");
    }
    Console.WriteLine();

    // EIN GERICHT AKTUALISIEREN
    Console.WriteLine("Aktualisiere Pancakes...");
    var pancakeToUpdate = context.Dishes.FirstOrDefault(d => d.Name == "Pancakes");
    if (pancakeToUpdate != null)
    {
        pancakeToUpdate.Price = 8.00;
        context.SaveChanges();
        Console.WriteLine("Preis aktualisiert!");
    }
    Console.WriteLine();


    // EIN GERICHT LÖSCHEN
    Console.WriteLine("Lösche Pancakes...");
    var pancakeToDelete = context.Dishes.FirstOrDefault(d => d.Name == "Pancakes");
    if (pancakeToDelete != null)
    {
        context.Dishes.Remove(pancakeToDelete);
        context.SaveChanges();
        Console.WriteLine("Gericht gelöscht!");
    }
}

Console.WriteLine("Drücke eine beliebige Taste zum Beenden.");
Console.ReadKey();