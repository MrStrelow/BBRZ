using Microsoft.EntityFrameworkCore;
using Aufgabe_1.Data;
using Aufgabe_1.Models;
using Aufgabe_1.DTOs;

namespace Aufgabe_1.Services
{
    public class AnalyticsService
    {
        private readonly TicketVerwaltungDbContext _context;

        public AnalyticsService(TicketVerwaltungDbContext context)
        {
            _context = context;
        }

        // --- 1) Async Select * (Alle Flugzeuge) ---
        public async Task<List<Airplane>> GetAllAirplanesAsync()
        {
            return await _context.Airplanes.ToListAsync();
        }

        // --- 2) Where mit Select (Projektion) ---
        public async Task<List<TicketInfoDto>> GetExpensiveTicketsAsync(decimal minPrice)
        {
            return await _context.Tickets
                .Where(t => t.Price > minPrice)
                .Select(t => new TicketInfoDto(t.Id, t.Price, t.Passenger.Name)) // Mapping in DTO
                .ToListAsync();
        }

        // --- 4) Group By: Top 3 Kunden pro Airline ---
        public async Task<List<AirlineTopCustomersDto>> GetTop3CustomersPerAirlineAsync()
        {
            // Schritt 1: Daten in der DB aggregieren (Summe pro Airline & Kunde)
            var rawData = await _context.Tickets
                .Select(t => new
                {
                    AirlineName = t.Flight.Airplane.Airline.Name,
                    PassengerName = t.Passenger.Name,
                    Preis = t.Price
                })
                .GroupBy(x => new { x.AirlineName, x.PassengerName })
                .Select(g => new
                {
                    Airline = g.Key.AirlineName,
                    Passenger = g.Key.PassengerName,
                    GesamtUmsatz = g.Sum(x => x.Preis)
                })
                .ToListAsync(); // Materialisierung im RAM

            // Schritt 2: Im Speicher die Top 3 filtern
            var result = rawData
                .GroupBy(x => x.Airline)
                .Select(g => new AirlineTopCustomersDto(
                    g.Key,
                    g.OrderByDescending(x => x.GesamtUmsatz)
                     .Take(3)
                     .Select(x => new CustomerRevenueDto(x.Passenger, x.GesamtUmsatz))
                     .ToList()
                ))
                .ToList();

            return result;
        }

        // --- 5) Einfache Joins (Include) ---
        public async Task<List<Flight>> GetFlightsWithPilotsAndGatesAsync()
        {
            return await _context.Flights
                .Include(f => f.Pilot)
                .Include(f => f.CoPilot)
                .Include(f => f.Gate)
                .ToListAsync();
        }

        // --- 6) Tiefe Joins (Include & ThenInclude) ---
        public async Task<List<Flight>> GetFlightsWithDeepDetailsAsync()
        {
            return await _context.Flights
                .Include(f => f.Airplane)
                    .ThenInclude(a => a.Airline)
                .Include(f => f.FlyFrom)
                    .ThenInclude(a => a.Terminals)
                .ToListAsync();
        }
    }
}