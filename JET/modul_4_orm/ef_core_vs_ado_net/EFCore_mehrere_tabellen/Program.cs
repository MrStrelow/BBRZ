using FruehstuecksrestaurantMore.Data;
using FruehstuecksrestaurantMore.Models;
using Microsoft.EntityFrameworkCore; // Wichtig für .Include() und .ThenInclude()
using System;
using System.Linq;

using (var context = new ApplicationDbContext())
{
    Console.WriteLine("--- Komplexes Gericht erstellen ---");

    // Zuerst prüfen, ob die Zutaten schon existieren, um Duplikate zu vermeiden.
    var egg = context.Ingredients.FirstOrDefault(i => i.Name == "Ei") ?? new Ingredient { Name = "Ei", Unit = "Stück" };
    var milk = context.Ingredients.FirstOrDefault(i => i.Name == "Milch") ?? new Ingredient { Name = "Milch", Unit = "ml" };
    var flour = context.Ingredients.FirstOrDefault(i => i.Name == "Mehl") ?? new Ingredient { Name = "Mehl", Unit = "g" };

    // Erstelle ein neues komplexes Gericht
    var scrambledEggs = new MoreDish
    {
        Name = "Rührei Deluxe",
        Description = "Cremiges Rührei mit frischen Kräutern.",
        Ingredients = { egg, milk }, // Füge die Zutaten hinzu
        PreparationSteps =
        {
            new PreparationStep { StepNumber = 1, Instruction = "Eier und Milch in einer Schüssel verquirlen." },
            new PreparationStep { StepNumber = 2, Instruction = "In einer heißen Pfanne stocken lassen." },
            new PreparationStep { StepNumber = 3, Instruction = "Mit Salz und Pfeffer würzen und servieren." }
        }
    };

    // Füge das neue Gericht zum Context hinzu. EF Core kümmert sich um alle verbundenen Entitäten.
    context.MoreDishes.Add(scrambledEggs);
    context.SaveChanges(); // Speichert alles in einer Transaktion!

    Console.WriteLine("Rührei Deluxe wurde zur Datenbank hinzugefügt!");
    Console.WriteLine();


    Console.WriteLine("--- Lese komplexes Gericht aus ---");

    // Lese das Gericht aus der Datenbank und lade explizit die verbundenen Daten.
    var dishFromDb = context.MoreDishes
                            .Include(d => d.Ingredients) // Lade die Zutaten
                            .Include(d => d.PreparationSteps) // Lade die Zubereitungsschritte
                            .FirstOrDefault(d => d.Name == "Rührei Deluxe");

    if (dishFromDb != null)
    {
        Console.WriteLine($"Gericht: {dishFromDb.Name}");
        Console.WriteLine($"Beschreibung: {dishFromDb.Description}");

        Console.WriteLine("\nZutaten:");
        foreach (var ingredient in dishFromDb.Ingredients)
        {
            Console.WriteLine($" - {ingredient.Name} ({ingredient.Unit})");
        }

        Console.WriteLine("\nZubereitung:");
        foreach (var step in dishFromDb.PreparationSteps.OrderBy(s => s.StepNumber))
        {
            Console.WriteLine($" {step.StepNumber}. {step.Instruction}");
        }
    }
}

Console.WriteLine("\nDrücke eine beliebige Taste zum Beenden.");
Console.ReadKey();

