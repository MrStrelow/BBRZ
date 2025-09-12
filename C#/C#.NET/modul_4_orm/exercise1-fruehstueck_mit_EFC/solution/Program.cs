using MorgenstundRestaurant.DTOs;
using MorgenstundRestaurant.Entities;
using MorgenstundRestaurant.Exceptions;
using MorgenstundRestaurant.Repositories;
using MorgenstundRestaurant.Services;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("Guten Morgen! Das Frühstücksrestaurant 'Morgenstund' öffnet.");

// --- 2. Service Instantiation with Manual Dependency Injection ---
var dishService = new DishService();
var menuService = new MenuService(dishService);
var customerService = new CustomerService(menuService);

var analyticsService = new AnalyticsService();

Log.Information("--- Bestellungen werden aufgenommen ---");

// falsche bestellung! Menü 99 gibt es nicht.
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
