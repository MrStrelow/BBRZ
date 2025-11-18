using Aufgabe_1.Data;
using Aufgabe_1.Models;
using Microsoft.EntityFrameworkCore;

using (var context = new TicketVerwaltungDbContext())
{
    Console.WriteLine("Initialisiere Daten...");
    SeedData.Initialize(context);
    Console.WriteLine("Daten wurden erfolgreich geladen.");

    // Überprüfung (optional):
    var tickets = await context.Tickets.ToListAsync();
    var passengers = await context.Passengers.ToListAsync();
    
    Console.WriteLine($"Anzahl geladener Tickets: {tickets.Count}");
    Console.WriteLine($"Anzahl geladener Passagiere: {passengers.Count}");
}