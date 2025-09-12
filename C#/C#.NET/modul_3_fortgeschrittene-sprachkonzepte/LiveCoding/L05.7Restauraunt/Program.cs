using Serilog;
using Restauraunt.Services;
using Restaurant.DTOs;

namespace Restauraunt;
public class Programm
{
    static async Task Main(string[] args)
    {
        // 1. Logger init
        Log.Logger = new LoggerConfiguration().
            MinimumLevel.Debug().
            WriteTo.Console().
            CreateLogger();

        Log.Information("Hello! Operation Fruehstueck initiated.");

        // 2. Services initialisieren
        var dishService = new DishService();
        await dishService.PrepareDishAsync(101);
        //var menueService = new MenuService(dishService);
        //var billService = new BillService(menueService);

        //var analyticsService = new AnalyticsService();

        //// 3. Bestellungen aufnehmen
        //var orderForTable1 = new TableOrderDto(TableNumber: 1, CustomerOrders: new() { new(CustomerName: "Anna", MenuId: 99 ), new(CustomerName: "Ben", MenuId: 2)});
        //var orderForTable3 = new TableOrderDto(TableNumber: 3, CustomerOrders: new() { new(CustomerName: "Carla", MenuId: 3 ), new(CustomerName: "David", MenuId: 1)});

        //var ordersToProcess = new List<TableOrderDto> { orderForTable1, orderForTable3 };
        //var promisesToProcess = new List<Task>();

        //foreach (var order in ordersToProcess)
        //{
        //    Task promise = billService.PlaceOrderAsync(order);
        //    promisesToProcess.Add(promise);
        //}

        //await Task.WhenAll(promisesToProcess);

        // lokal schließt und wir schauen uns die tagesbilanz an
        // -> analytics service


    }
}