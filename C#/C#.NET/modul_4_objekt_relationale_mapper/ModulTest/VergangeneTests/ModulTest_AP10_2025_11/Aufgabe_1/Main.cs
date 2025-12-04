using Aufgabe_1.Data;
using Aufgabe_1.Services;
using System;

using var context = new TicketVerwaltungDbContext();
SeedData.Initialize(context);

var service = new AnalyticsService(context);

Console.WriteLine("--- 1) Alle Airplanes ---");
var airplanes = await service.GetAllAirplanesAsync();
foreach (var a in airplanes)
{
    Console.WriteLine($"FlightId: {a.Id}, Airline... oh da steht ja nix: {a.Airline?.Name}");
}

Console.WriteLine("\n--- 2) Tickets >= 50€ ---");
var expensiveTickets = await service.GetExpensiveTicketsAsync();
foreach (var t in expensiveTickets)
{
    Console.WriteLine($"TicketId: {t.Id}, Preis: {t.Price}");
}

Console.WriteLine("\n--- 3) Flights ab Vienna (Tuple) ---");
var viennaFlights = await service.GetFlightsWithDepartureCity();
foreach (var (flightNum, dest) in viennaFlights)
{
    Console.WriteLine($"Flight: {flightNum}, Destination: {dest}");
}

Console.WriteLine("\n--- 4) Beliebte Flights ab Vienna (>= 3 Tickets) ---");
var popularFlights = await service.GetFlightsWithDepartureCityWithAtLeastXFlights();
foreach (var (flightNum, dest) in popularFlights)
{
    Console.WriteLine($"Flight: {flightNum}, Destination: {dest}");
}

Console.WriteLine("\n--- 5) Top 3 Passengers pro Airline ---");
var stats = await service.GetTop3PassengersPerAirlineAsync();
foreach (dynamic stat in stats)
{
    Console.WriteLine($"Airline: {stat.AirlineName}");
    foreach (dynamic p in stat.TopPassengers)
    {
        Console.WriteLine($" - {p.PassengerName}: {p.Umsatz}€");
    }
}

// 6)
Console.WriteLine("\n--- Zusatz: Flüge mit Pilot & Gate ---");
var flightsWithDetails = await service.GetFlightsWithPilotsAndGatesAsync();
Console.WriteLine($"{flightsWithDetails.Count} Flüge mit Details geladen.");
foreach (var flight in flightsWithDetails)
{
    Console.WriteLine($"Id:{flight.Id}\n - Airplane: *Id:{flight.Pilot.Name}\n - Airline: *Name{flight.CoPilot.Name}\n Origin: *{flight.FlyFrom}\n Temrinal: *{flight.Airplane}");
}

// 7)
Console.WriteLine("\n--- Zusatz: Flüge mit Pilot & Gate ---");
var flightsWithDeepDetails = await service.GetFlightsWithDeepDetailsAsync();
Console.WriteLine($"{flightsWithDetails.Count} Flüge mit Details geladen.");

foreach(var flight in flightsWithDetails)
{
    Console.WriteLine($"Id:{flight.Id}\n - Airplane: *Id:{flight.Airplane.Id}\n - Airline: *Name{flight.Airplane.Airline.Name}\n Origin: *{flight.FlyFrom}\n Temrinal: *{flight.FlyFrom.Terminals.ToList()}");
}

Console.WriteLine("\nTaste drücken zum Beenden...");
Console.ReadKey();

Console.ReadKey();