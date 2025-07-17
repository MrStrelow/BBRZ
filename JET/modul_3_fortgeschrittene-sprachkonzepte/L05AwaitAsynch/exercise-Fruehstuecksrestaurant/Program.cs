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

await SeedDatabaseAsync();

Log.Information("--- Bestellungen werden aufgenommen ---");

// Order with an invalid Menu ID (99) to trigger the exception flow
var orderForTable1 = new TableOrderDto { TableNumber = 1, CustomerOrders = new() { new() { CustomerName = "Anna", MenuId = 99 }, new() { CustomerName = "Ben", MenuId = 2 } } };
var orderForTable3 = new TableOrderDto { TableNumber = 3, CustomerOrders = new() { new() { CustomerName = "Carla", MenuId = 3 }, new() { CustomerName = "David", MenuId = 1 } } };

var ordersToProcess = new List<TableOrderDto> { orderForTable1, orderForTable3 };
var orderTasks = new List<Task>();

foreach (var order in ordersToProcess)
{
    var orderTask = ProcessOrderAsync(order);
    orderTasks.Add(orderTask);
}

// Asynchronously wait for all the started tasks to complete.
await Task.WhenAll(orderTasks);

Log.Information("Alle Bestellungen wurden versucht zu verarbeiten.");
Log.Information("--- Restaurant-Tagesanalyse ---");

var analytics = await analyticsService.GetRestaurantAnalyticsAsync();
Log.Information("Meistbesuchter Tisch heute: Tisch Nr. {MostVisitedTable}", analytics.MostVisitedTable);
Log.Information("Beliebtestes Menü heute: {MostPopularMenu}", analytics.MostPopularMenu);

Log.Information("Simulation beendet.");
   

async Task SeedDatabaseAsync()
{
    Log.Information("Prüfe und erstelle Anfangsdaten...");
    // Seeding logic remains the same
    var dishRepo = new DishRepository();
    var menuRepo = new MenuRepository();
    var stockRepo = new StockRepository();
    var billRepo = new BillRepository();

    if (!(await dishRepo.GetAllAsync()).Any()) await dishRepo.SaveAllAsync(new List<Dish> { /* ... */ });
    if (!(await menuRepo.GetAllAsync()).Any()) await menuRepo.SaveAllAsync(new List<Menu> { /* ... */ });
    if (!(await stockRepo.GetAllAsync()).Any()) await stockRepo.SaveAllAsync(new List<StockItem> { /* ... */ });
    await billRepo.SaveAllAsync(new List<Bill>());
}

// It's good practice to have the try/catch logic in its own method.
async Task ProcessOrderAsync(TableOrderDto order)
{
    try
    {
        await customerService.PlaceOrderAsync(order);
    }
    catch (OrderProcessingException ex)
    {
        Log.Error(ex, "Fehler bei der Auftragsverarbeitung für Tisch {TableNumber}.", order.TableNumber);
    }
    catch (Exception ex)
    {
        Log.Fatal(ex, "Ein unerwarteter Fehler ist aufgetreten bei Tisch {TableNumber}.", order.TableNumber);
    }
}
