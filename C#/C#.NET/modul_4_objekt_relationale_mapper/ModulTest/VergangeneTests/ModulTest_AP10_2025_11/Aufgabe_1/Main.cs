using Aufgabe_1.Data;
using Aufgabe_1.DTOs;
using Aufgabe_1.Services;
using Microsoft.EntityFrameworkCore;

using (var context = new TicketVerwaltungDbContext())
{
    Console.WriteLine("Initialisiere Daten...");
    SeedData.Initialize(context);
    Console.WriteLine("Daten wurden erfolgreich geladen.");

    // Überprüfung (optional):
    var initTickets = await context.Tickets.ToListAsync();
    var initPassengers = await context.Passengers.ToListAsync();
    
    Console.WriteLine($"Anzahl geladener Tickets: {initTickets.Count}");
    Console.WriteLine($"Anzahl geladener Passagiere: {initPassengers.Count}");

    // Service instanziieren
    var service = new AnalyticsService(context);

    Console.WriteLine("--- 2) Alle Flugzeuge ---");
    var planes = await service.GetAllAirplanesAsync();
    foreach (var p in planes)
        Console.WriteLine($"Plane {p.Id} ({p.ManufactoringDate:d})");

    Console.WriteLine("\n--- 3) Teure Tickets (> 500 EUR) ---");
    var tickets = await service.GetExpensiveTicketsAsync(500);
    foreach (var t in tickets)
        Console.WriteLine($"Ticket {t.TicketId}: {t.Preis} EUR - {t.PassagierName}");

    Console.WriteLine("\n--- 4) Top 3 Kunden pro Airline ---");
    var stats = await service.GetTop3CustomersPerAirlineAsync();
    foreach (var airline in stats)
    {
        Console.WriteLine($"Airline: {airline.AirlineName}");
        foreach (var customer in airline.TopCustomers)
        {
            Console.WriteLine($"  - {customer.PassengerName}: {customer.Umsatz:C}");
        }
    }

    Console.WriteLine("\n--- 5) Flüge mit Piloten & Gates ---");
    var flightsBasic = await service.GetFlightsWithPilotsAndGatesAsync();
    foreach (var f in flightsBasic.Take(3))
        Console.WriteLine($"Flug {f.Kennung}: Pilot {f.Pilot?.Name}");

    Console.WriteLine("\n--- 6) Flüge mit Deep Details ---");
    var flightsDeep = await service.GetFlightsWithDeepDetailsAsync();
    foreach (var f in flightsDeep.Take(3))
        Console.WriteLine($"Flug {f.Kennung} von {f.FlyFrom?.Ort} mit {f.Airplane?.Airline?.Name}");
}