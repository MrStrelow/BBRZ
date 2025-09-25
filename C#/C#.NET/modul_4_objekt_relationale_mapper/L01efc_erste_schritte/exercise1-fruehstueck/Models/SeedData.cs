using FruehstuecksrestaurantMore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruehstuecksrestaurantMore.Data;

public static class SeedData
{
    public static async Task InitializeAsync(RestaurantDbContext context)
    {
        // 1. Sicherstellen, dass die DB existiert und alle Migrationen angewendet sind.
        await context.Database.MigrateAsync();

        // 2. Prüfen, ob schon Daten da sind. Wenn ja, nichts tun.
        if (await context.Dishes.AnyAsync())
        {
            return;
        }

        // --- STAMMDATEN ---

        // ZUTATEN: Eine zentrale Liste, die von Gerichten wiederverwendet wird
        var ingredients = new List<Ingredient>
        {
            new() { Name = "Ei", Unit = "Stück" }, new() { Name = "Mehl", Unit = "g" },
            new() { Name = "Milch", Unit = "ml" }, new() { Name = "Zucker", Unit = "g" },
            new() { Name = "Salz", Unit = "Prise" }, new() { Name = "Butter", Unit = "g" },
            new() { Name = "Käse", Unit = "g" }, new() { Name = "Schinken", Unit = "g" },
            new() { Name = "Tomate", Unit = "Stück" }, new() { Name = "Kaffee", Unit = "Bohne" },
            new() { Name = "Avocado", Unit = "Stück"}, new() { Name = "Vollkornbrot", Unit = "Scheibe"}
        };
        await context.Ingredients.AddRangeAsync(ingredients);

        // GERICHTE: 5 verschiedene Gerichte
        var dishes = new List<Dish>
        {
            // Gericht 1
            new() {
                Name = "Rührei Klassik", Description = "Drei Eier mit frischen Kräutern und Buttertoast.", Price = 8.50m,
                Ingredients = { ingredients.Single(i => i.Name == "Ei"), ingredients.Single(i => i.Name == "Salz"), ingredients.Single(i => i.Name == "Butter") },
                PreparationSteps = { new() { StepNumber = 1, Instruction = "Eier verquirlen." }, new() { StepNumber = 2, Instruction = "In der Pfanne stocken lassen." } }
            },
            // Gericht 2
            new() {
                Name = "Pancakes mit Ahornsirup", Description = "Drei fluffige Pancakes, serviert mit frischen Früchten.", Price = 9.20m,
                Ingredients = { ingredients.Single(i => i.Name == "Mehl"), ingredients.Single(i => i.Name == "Milch"), ingredients.Single(i => i.Name == "Zucker"), ingredients.Single(i => i.Name == "Ei") },
                PreparationSteps = { new() { StepNumber = 1, Instruction = "Teig anrühren." }, new() { StepNumber = 2, Instruction = "Goldbraun ausbacken." } }
            },
            // Gericht 3
            new() {
                Name = "Käse-Schinken-Omelett", Description = "Herzhaftes Omelett mit würzigem Käse und saftigem Schinken.", Price = 10.50m,
                Ingredients = { ingredients.Single(i => i.Name == "Ei"), ingredients.Single(i => i.Name == "Käse"), ingredients.Single(i => i.Name == "Schinken"), ingredients.Single(i => i.Name == "Tomate") },
                PreparationSteps = { new() { StepNumber = 1, Instruction = "Zutaten schneiden." }, new() { StepNumber = 2, Instruction = "Omelett in der Pfanne zubereiten." } }
            },
            // Gericht 4
            new() {
                Name = "Avocado-Toast", Description = "Getoastetes Vollkornbrot mit frischer Avocado und einer Prise Chili.", Price = 11.00m,
                Ingredients = { ingredients.Single(i => i.Name == "Avocado"), ingredients.Single(i => i.Name == "Vollkornbrot"), ingredients.Single(i => i.Name == "Salz") },
                PreparationSteps = { new() { StepNumber = 1, Instruction = "Brot toasten." }, new() { StepNumber = 2, Instruction = "Avocado zerdrücken und auf dem Toast verteilen." } }
            },
            // Gericht 5
            new() {
                Name = "Filterkaffee", Description = "Frisch gebrühter, aromatischer Kaffee.", Price = 3.50m,
                Ingredients = { ingredients.Single(i => i.Name == "Kaffee") },
                PreparationSteps = { new() { StepNumber = 1, Instruction = "Bohnen frisch mahlen." }, new() { StepNumber = 2, Instruction = "Mit heißem Wasser aufbrühen." } }
            }
        };
        await context.Dishes.AddRangeAsync(dishes);

        // KUNDEN: 5 verschiedene Kunden
        var customers = new List<Customer>
        {
            new() { Name = "Anna Schmidt" },
            new() { Name = "Max Mustermann" },
            new() { Name = "Julia Meier" },
            new() { Name = "Paul Weber" },
            new() { Name = "Lisa Bauer" }
        };
        await context.Customers.AddRangeAsync(customers);

        // TISCHE: 5 Tische
        var tables = new List<Table> { new(), new(), new(), new(), new() };
        await context.Tables.AddRangeAsync(tables);

        // Wichtig: Änderungen speichern, damit die IDs von der DB generiert werden.
        await context.SaveChangesAsync();

        // --- BEWEGUNGSDATEN (Zufällige Besuche) ---
        var random = new Random();
        var visits = new List<Visit>();
        for (int i = 0; i < 100; i++) // 100 zufällige Besuche generieren
        {
            var tableForVisit = tables[random.Next(tables.Count)];
            var customerForVisit = customers[random.Next(customers.Count)];
            var numberOfDishes = random.Next(1, 4); // 1-3 Gerichte pro Besuch
            var orderedDishes = new List<Dish>();
            for (int j = 0; j < numberOfDishes; j++)
            {
                orderedDishes.Add(dishes[random.Next(dishes.Count)]);
            }

            visits.Add(new Visit
            {
                table = tableForVisit,
                Customer = customerForVisit,
                TimeOfVisit = DateTime.Now.AddDays(-random.Next(1, 60)).AddHours(random.Next(-12, 12)),
                dishes = orderedDishes
            });
        }
        await context.Visits.AddRangeAsync(visits);
        await context.SaveChangesAsync();
    }
}