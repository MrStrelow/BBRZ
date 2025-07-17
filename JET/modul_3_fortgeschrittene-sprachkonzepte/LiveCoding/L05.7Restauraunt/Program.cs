using Serilog;
using Restauraunt.Services;

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
        await dishService.PrepareDishAsync(1);
        //var menueService = new MenuService(dishService);
        //var billService = new BillService(menueService);

        var analyticsService = new AnalyticsService();

            
    }
}