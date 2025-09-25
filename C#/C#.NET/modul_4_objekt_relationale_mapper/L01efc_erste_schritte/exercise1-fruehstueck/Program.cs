using FruehstuecksrestaurantMore.Data;
using FruehstuecksrestaurantMore.Services;
using System;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        try
        {
            // --- Datenbank-Initialisierung ---

            // 1. Erstelle eine "kurzlebige" Instanz des DbContext.
            // Da OnConfiguring im DbContext ist, braucht der Konstruktor keine Argumente.
            using (var dbContext = new RestaurantDbContext())
            {
                await SeedData.InitializeAsync(dbContext);
                Console.WriteLine("✅ Datenbank wurde erfolgreich initialisiert und mit Daten befüllt.");
            }
            Console.WriteLine("------------------------------------------------------------------");


            // --- Demonstration der Kartesischen Explosion ---

            // 2. Erstelle eine neue DbContext-Instanz für den CustomerService.
            using (var dbContext = new RestaurantDbContext())
            {
                var customerService = new CustomerService(dbContext);
                await customerService.DemonstrateCartesianExplosionAsync("Anna Schmidt");
            }
            Console.WriteLine("------------------------------------------------------------------");


            // --- Restaurant-Analyse ---

            // 3. Erstelle eine weitere DbContext-Instanz für den AnalyticsService.
            using (var dbContext = new RestaurantDbContext())
            {
                var analyticsService = new AnalyticsService(dbContext);
                Console.WriteLine("\nFühre Restaurant-Analyse durch...");
                var analytics = await analyticsService.GetRestaurantAnalyticsAsync();

                Console.WriteLine("\n--- 📈 Restaurant Analyse-Ergebnisse ---");
                Console.WriteLine($"Tisch mit dem höchsten Umsatz: Tisch Nr. {analytics.TableWithHighestRevenueId}");
                Console.WriteLine($"Erzielter Umsatz an diesem Tisch: {analytics.HighestRevenue:C}");
                Console.WriteLine($"Beliebtestes Gericht: {analytics.MostPopularDish}");
                Console.WriteLine("----------------------------------------");
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ein Fehler ist aufgetreten: {ex.Message}");
            Console.ResetColor();
        }

        Console.WriteLine("\nAnwendung beendet. Drücken Sie eine Taste zum Schließen.");
        Console.ReadKey();
    }
}