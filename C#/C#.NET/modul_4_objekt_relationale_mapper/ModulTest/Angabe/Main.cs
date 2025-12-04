using Aufgabe_1.Data;
using Aufgabe_1.Services;
using Aufgabe_1.Models;
using System;
using System.Threading.Tasks;

// 1. Datenbank-Kontext aufbauen
using var context = new TicketVerwaltungDbContext();

// 2. Datenbank sicherstellen und mit Testdaten füllen
// (Wichtig, damit deine Abfragen Ergebnisse liefern)
context.Database.EnsureCreated();
SeedData.Initialize(context);

// 3. Service instanziieren
var service = new AnalyticsService(context);

Console.WriteLine("=== FLUGHAFEN ANALYTICS START ===\n");

// ---------------------------------------------------------
// AUFRUF METHODE 1: GetBookingssAsync
// ---------------------------------------------------------
Console.WriteLine("--- 1. Hole alle Bookings ---");

var allBookings = await service.GetBookingssAsync();

Console.WriteLine($"{allBookings.Count} Buchungen gefunden.");
foreach (var b in allBookings)
{
    string passagierName = b.Passenger?.LastName ?? "Ohje... nicht geladen... warum?"; // was passiedrt wernn passenger null ist?
    Console.WriteLine($" - Ref: {b.BookingReference}, Preis: {b.Price}€, Kunde: {passagierName}");
}

// ---------------------------------------------------------
// AUFRUF METHODE 2: GetBookingssWithPassengerAsync
// ---------------------------------------------------------
Console.WriteLine("\n--- 2. Hole alle Bookings mit Passengers ---");

var allJoinedBookings = await service.GetBookingssWithPassengerAsync();

Console.WriteLine($"{allJoinedBookings.Count} Buchungen gefunden.");
foreach (var b in allJoinedBookings)
{
    string passagierName = b.Passenger?.LastName ?? "Ohje... nicht geladen... warum?"; // was passiedrt wernn passenger null ist?
    Console.WriteLine($" - Ref: {b.BookingReference}, Preis: {b.Price}€, Kunde: {passagierName}");
}

// ---------------------------------------------------------
// AUFRUF METHODE 3: GetPassengerManifestAsync
// ---------------------------------------------------------
string flightNum = "LH123"; // Eine Flugnummer aus den SeedData
Console.WriteLine($"\n--- 3. Manifest für {flightNum} (Sortiert nach BoardingGroup) ---");

var manifest = await service.GetPassengerManifestAsync(flightNum);

if (manifest.Count == 0)
{
    Console.WriteLine("Keine Passagiere gefunden (evtl. falsche Flugnummer oder keine BoardingPässe).");
}

foreach (var booking in manifest)
{
    var group = booking.BoardingPass?.BoardingGroup;
    var seat = booking.BoardingPass?.SeatNumber;
    var name = booking.Passenger?.LastName ?? "Unbekannt";

    Console.WriteLine($"Gruppe {group} | Sitz {seat} | Name: {name}");
}


// ---------------------------------------------------------
// AUFRUF METHODE 4: GetSecurityCheckStatsAsync
// ---------------------------------------------------------
Console.WriteLine("\n--- 4. Security Check Statistik (GroupBy) ---");

var stats = await service.GetSecurityCheckStatsAsync();

foreach (dynamic stat in stats)
{
    Console.WriteLine($"Status: {stat.Result} \t| Anzahl: {stat.Count}");
}

Console.WriteLine("\n=== ENDE ===");
Console.ReadKey();