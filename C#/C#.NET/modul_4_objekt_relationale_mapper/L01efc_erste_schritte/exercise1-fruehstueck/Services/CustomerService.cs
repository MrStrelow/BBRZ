using FruehstuecksrestaurantMore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FruehstuecksrestaurantMore.Services;

public class CustomerService
{
    private readonly RestaurantDbContext _context;

    public CustomerService(RestaurantDbContext context)
    {
        _context = context;
    }

    public async Task DemonstrateCartesianExplosionAsync(string customerName)
    {
        Console.WriteLine($"--- Lade die gesamte Bestellhistorie für Kunde: '{customerName}' ---");

        // --- PROBLEM: Eine einzige Abfrage für eine tiefe Hierarchie ---

        Console.WriteLine("\n--- PROBLEM: Abfrage mit Kartesischer Explosion ---");
        var queryProblem = _context.Customers
            // 1:N Join (Kunde -> Besuche)
            .Include(c => c.visits)
                // M:N Join (Besuche -> Gerichte)
                .ThenInclude(v => v.dishes)
                    // 1:N Join (Gerichte -> Zubereitungsschritte)
                    .ThenInclude(d => d.PreparationSteps)
            // Ein weiterer, paralleler Join vom Gericht aus
            .Include(c => c.visits)
                .ThenInclude(v => v.dishes)
                    // M:N Join (Gerichte -> Zutaten)
                    .ThenInclude(d => d.Ingredients)
            .Where(c => c.Name == customerName);

        Console.WriteLine("Generiertes SQL:");
        Console.WriteLine(queryProblem.ToQueryString());

        Console.WriteLine("\n -> Diese EINE Abfrage erzeugt eine GIGANTISCHE Ergebnistabelle.");
        Console.WriteLine(" -> Angenommen, der Kunde hatte 2 Besuche, bei jedem 2 Gerichte bestellt,");
        Console.WriteLine(" -> jedes Gericht hat 5 Schritte und 5 Zutaten.");
        Console.WriteLine(" -> Ergebniszeilen = 2 * 2 * 5 * 5 = 100 Zeilen! Voller redundanter Daten.\n");


        // --- LÖSUNG: Aufteilen der Abfrage mit AsSplitQuery() ---

        Console.WriteLine("--- LÖSUNG: Abfrage mit AsSplitQuery() ---");
        var querySolution = _context.Customers
            .Include(c => c.visits)
                .ThenInclude(v => v.dishes)
                    .ThenInclude(d => d.PreparationSteps)
            .Include(c => c.visits)
                .ThenInclude(v => v.dishes)
                    .ThenInclude(d => d.Ingredients)
            .Where(c => c.Name == customerName)
            .AsSplitQuery(); // <-- Die Lösung!

        Console.WriteLine("Diese Methode generiert mehrere, kleine und effiziente SQL-Abfragen.");
        Console.WriteLine("ToQueryString() zeigt nur die erste Abfrage an:\n");
        Console.WriteLine(querySolution.ToQueryString());

        var result = await querySolution.FirstOrDefaultAsync();

        if (result != null)
        {
            Console.WriteLine($"\nKunde '{result.Name}' erfolgreich geladen.");
            Console.WriteLine($"Anzahl Besuche: {result.visits.Count}");
            // Wir können tief in die geladene Struktur eintauchen
            var firstDish = result.visits.FirstOrDefault()?.dishes.FirstOrDefault();
            if (firstDish != null)
            {
                Console.WriteLine($"Das erste bestellte Gericht war '{firstDish.Name}' mit {firstDish.PreparationSteps.Count} Zubereitungsschritten.");
            }
        }
    }
}