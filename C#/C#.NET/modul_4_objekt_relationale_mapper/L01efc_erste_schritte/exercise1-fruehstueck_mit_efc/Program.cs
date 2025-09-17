using Microsoft.EntityFrameworkCore;
using MorgenstundRestaurant.Data;
using MorgenstundRestaurant.DTOs;
using MorgenstundRestaurant.Entities;
using MorgenstundRestaurant.Exceptions;
using MorgenstundRestaurant.Repositories;
using MorgenstundRestaurant.Services;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// --- 1. Konfiguration ---
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("Guten Morgen! Das Frühstücksrestaurant 'Morgenstund' öffnet.");

// --- 2. Datenbank initialisieren und befüllen ---
await SeedDatabaseAsync();

// --- 3. Service Instanziierung ---
var customerService = new CustomerService(new MenuService(new DishService()));
var analyticsService = new AnalyticsService();

// --- 4. Bestellsimulation (unverändert) ---
Log.Information("--- Bestellungen werden aufgenommen ---");

var orderForTable1 = new TableOrderDto { TableNumber = 1, CustomerOrders = new() { new() { CustomerName = "Anna", MenuId = 99 }, new() { CustomerName = "Ben", MenuId = 2 } } };
var orderForTable3 = new TableOrderDto { TableNumber = 3, CustomerOrders = new() { new() { CustomerName = "Carla", MenuId = 3 }, new() { CustomerName = "David", MenuId = 3 } } };
var orderForTable6 = new TableOrderDto { TableNumber = 6, CustomerOrders = new() { new() { CustomerName = "Gwen", MenuId = 1 }, new() { CustomerName = "Jen", MenuId = 1 } } };
var anotherOrderForTable6 = new TableOrderDto { TableNumber = 6, CustomerOrders = new() { new() { CustomerName = "Qwer", MenuId = 2 }, new() { CustomerName = "Asdf", MenuId = 2 } } };
var yetAnotherOrderForTable6 = new TableOrderDto { TableNumber = 6, CustomerOrders = new() { new() { CustomerName = "Set", MenuId = 1 }, new() { CustomerName = "Let", MenuId = 2 } } };

var ordersToProcess = new List<TableOrderDto> { orderForTable1, orderForTable3, orderForTable6, anotherOrderForTable6, yetAnotherOrderForTable6 };
var orderTasks = new List<Task>();

foreach (var order in ordersToProcess)
{
    orderTasks.Add(ProcessOrderAsync(order));
}

await Task.WhenAll(orderTasks);

Log.Information("Alle Bestellungen wurden versucht zu verarbeiten.");
Log.Information("--- Restaurant-Tagesanalyse ---");

var analytics = await analyticsService.GetRestaurantAnalyticsAsync();
Log.Information("Meistbesuchter Tisch SEIT ERÖFFNUNG: Tisch Nr. {MostVisitedTable}", analytics.MostVisitedTable);
Log.Information("Beliebtestes Menü SEIT ERÖFFNUNG: {MostPopularMenu}", analytics.MostPopularMenu);

Log.Information("Simulation beendet.");


// --- HILFSMETHODEN ---

async Task<Bill?> ProcessOrderAsync(TableOrderDto order)
{
    try
    {
        return await customerService.PlaceOrderAsync(order);
    }
    catch (OrderProcessingException ex)
    {
        Log.Error(ex, "Fehler bei der Auftragsverarbeitung für Tisch {TableNumber}.", order.TableNumber);
    }
    catch (Exception ex)
    {
        Log.Fatal(ex, "Ein unerwarteter Fehler ist aufgetreten bei Tisch {TableNumber}.", order.TableNumber);
    }

    return null;
}

async Task SeedDatabaseAsync()
{
    Log.Information("Prüfe Datenbank und lege Stammdaten an, falls nötig...");
    using var context = new RestaurantDbContext();

    // Stellt sicher, dass die DB existiert
    await context.Database.MigrateAsync();

    // Prüfen, ob schon Gerichte existieren. Wenn ja, überspringen wir das Seeding.
    if (await context.Dishes.AnyAsync())
    {
        Log.Information("Datenbank enthält bereits Gerichte. Seeding wird übersprungen.");
        return;
    }

    Log.Information("Lege Gerichte und Menüs an...");

    // 1. Gerichte anlegen
    var dish1 = new Dish { Name = "Rührei", Price = 5.50m };
    var dish2 = new Dish { Name = "Kaffee", Price = 2.80m };
    var dish3 = new Dish { Name = "Croissant", Price = 2.20m };
    var dish4 = new Dish { Name = "Spiegelei", Price = 5.20m };
    var dish5 = new Dish { Name = "Orangensaft", Price = 3.50m };

    context.Dishes.AddRange(dish1, dish2, dish3, dish4, dish5);
    await context.SaveChangesAsync(); // Wichtig, damit die IDs generiert werden

    // 2. Menüs mit den Gerichten verknüpfen
    var menu1 = new Menu { Name = "Frühstücksklassiker", Dishes = { dish1, dish2 } };
    var menu2 = new Menu { Name = "Süßer Start", Dishes = { dish3, dish5 } };
    var menu3 = new Menu { Name = "Herzhafter Morgen", Dishes = { dish4, dish2 } };

    context.Menus.AddRange(menu1, menu2, menu3);
    await context.SaveChangesAsync();

    Log.Information("Stammdaten wurden erfolgreich angelegt.");
}