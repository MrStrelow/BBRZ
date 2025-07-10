// File: Program.cs
using MorgenstundRestaurant.DTOs;
using MorgenstundRestaurant.Entities;
using MorgenstundRestaurant.Repositories;
using MorgenstundRestaurant.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Guten Morgen! Das Frühstücksrestaurant 'Morgenstund' öffnet.");

        // Services instantiieren
        var customerService = new CustomerService();
        var analyticsService = new AnalyticsService();

        // Datenbank mit Anfangsdaten befüllen
        await SeedDatabaseAsync();

        Console.WriteLine("\n--- Bestellungen werden aufgenommen ---");

        var orderForTable1 = new OrderDto { TableNumber = 1, CustomerOrders = new() { new() { CustomerName = "Anna", MenuId = 1 }, new() { CustomerName = "Ben", MenuId = 2 } } };
        var orderForTable3 = new OrderDto { TableNumber = 3, CustomerOrders = new() { new() { CustomerName = "Carla", MenuId = 3 }, new() { CustomerName = "David", MenuId = 1 }, new() { CustomerName = "Eva", MenuId = 1 } } };
        var orderForTable2 = new OrderDto { TableNumber = 2, CustomerOrders = new() { new() { CustomerName = "Frank", MenuId = 2 } } };

        var orderTasks = new List<Task<Bill>>
        {
            customerService.PlaceOrderAsync(orderForTable1),
            customerService.PlaceOrderAsync(orderForTable2),
            customerService.PlaceOrderAsync(orderForTable3)
        };

        // Zeigen, welcher Tisch zuerst fertig ist
        var firstCompletedTask = await Task.WhenAny(orderTasks);
        var firstBill = await firstCompletedTask;
        Console.WriteLine($"\n+++ INFO: Die erste Bestellung ist fertig! Tisch {firstBill.TableNumber} wurde soeben abgerechnet. +++");

        // Warten, bis alle Bestellungen fertig sind
        await Task.WhenAll(orderTasks);
        Console.WriteLine("\nAlle Bestellungen wurden verarbeitet und die Rechnungen gespeichert.");

        Console.WriteLine("\n--- Restaurant-Tagesanalyse ---");
        var analytics = await analyticsService.GetRestaurantAnalyticsAsync();

        Console.WriteLine($"Meistbesuchter Tisch heute: Tisch Nr. {analytics.MostVisitedTable}");
        Console.WriteLine($"Beliebtestes Menü heute: {analytics.MostPopularMenu}");
        Console.WriteLine("Verkaufsstatistik:");
        foreach (var sale in analytics.MenuSales.OrderByDescending(s => s.Value))
        {
            Console.WriteLine($" - {sale.Key}: {sale.Value}x verkauft");
        }

        Console.WriteLine("\nSimulation beendet. Auf Wiedersehen!");
    }

    private static async Task SeedDatabaseAsync()
    {
        Console.WriteLine("Prüfe und erstelle Anfangsdaten...");
        var dishRepo = new DishRepository();
        var menuRepo = new MenuRepository();
        var stockRepo = new StockRepository();
        var billRepo = new BillRepository();

        if (!(await dishRepo.GetAllAsync()).Any())
        {
            await dishRepo.SaveAllAsync(new List<Dish>
            {
                new() { Id = 101, Name = "Rührei mit Schnittlauch", Price = 4.5m, Ingredients = new() { "Ei", "Milch", "Schnittlauch" }, PreparationSteps = new() { "verquirlen", "braten" } },
                new() { Id = 102, Name = "Semmel mit Butter", Price = 1.5m, Ingredients = new() { "Semmel", "Butter" }, PreparationSteps = new() { "aufschneiden", "bestreichen" } },
                new() { Id = 201, Name = "Joghurt mit Früchten", Price = 3.8m, Ingredients = new() { "Joghurt", "Beeren", "Honig" }, PreparationSteps = new() { "mischen" } },
                new() { Id = 202, Name = "Vollkornbrot mit Avocado", Price = 5.2m, Ingredients = new() { "Vollkornbrot", "Avocado" }, PreparationSteps = new() { "aufschneiden", "zerdrücken", "bestreichen" } },
                new() { Id = 301, Name = "Croissant mit Marmelade", Price = 2.8m, Ingredients = new() { "Croissant", "Marmelade" }, PreparationSteps = new() { "bestreichen" } },
                new() { Id = 302, Name = "Kaffee", Price = 3.0m, Ingredients = new() { "Kaffeebohnen", "Wasser" }, PreparationSteps = new() { "mahlen", "brühen" } }
            });
        }

        if (!(await menuRepo.GetAllAsync()).Any())
        {
            await menuRepo.SaveAllAsync(new List<Menu>
            {
                new() { Id = 1, Name = "Wiener Frühstück", DishIds = new() { 101, 102, 302 } },
                new() { Id = 2, Name = "Vital Frühstück", DishIds = new() { 201, 202 } },
                new() { Id = 3, Name = "Süßer Start", DishIds = new() { 301, 302 } }
            });
        }

        if (!(await stockRepo.GetAllAsync()).Any())
        {
            await stockRepo.SaveAllAsync(new List<StockItem>
            {
                new() { Name = "Ei", Quantity = 100 }, new() { Name = "Milch", Quantity = 100 }, new() { Name = "Schnittlauch", Quantity = 100 },
                new() { Name = "Semmel", Quantity = 100 }, new() { Name = "Butter", Quantity = 100 }, new() { Name = "Joghurt", Quantity = 100 },
                new() { Name = "Beeren", Quantity = 100 }, new() { Name = "Honig", Quantity = 100 }, new() { Name = "Vollkornbrot", Quantity = 100 },
                new() { Name = "Avocado", Quantity = 100 }, new() { Name = "Croissant", Quantity = 100 }, new() { Name = "Marmelade", Quantity = 100 },
                new() { Name = "Kaffeebohnen", Quantity = 100 }, new() { Name = "Wasser", Quantity = 100 }
            });
        }
        // Alte Rechnungen für einen sauberen Start der Simulation löschen
        await billRepo.SaveAllAsync(new List<Bill>());
    }
}