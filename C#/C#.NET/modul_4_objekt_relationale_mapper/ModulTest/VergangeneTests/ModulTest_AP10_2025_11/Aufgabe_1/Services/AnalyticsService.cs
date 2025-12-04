using Aufgabe_1.Data;
using Aufgabe_1.DTOs;
using Aufgabe_1.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Aufgabe_1.Services
{
    public class AnalyticsService
    {
        private readonly TicketVerwaltungDbContext _context;

        public AnalyticsService(TicketVerwaltungDbContext context)
        {
            _context = context;
        }

        // --- 1) Gib alle *Flights* in der ``Datenbank`` aus. Dies soll ``asynchron`` umgesetzt werden. ---
        public async Task<List<Airplane>> GetAllAirplanesAsync()
        {
            return await _context.Airplanes.ToListAsync();
        }

        // --- 2) Welche Tickets haben zumidnest den Preis von *50€*? ---
        public async Task<List<Ticket>> GetExpensiveTicketsAsync(decimal minPrice = 50)
        {
            return await _context.Tickets
                .Where(t => t.Price >= minPrice)
                .ToListAsync();
        }

        // --- 3) Welche* Flights* haben* DepartureCity == "Vienna"*? Im Ergebnis soll nur die* Flightnumber* und der *DestinationCity* vorhanden sein ---
        public async Task<List<(string Flightnumber, string DestinationCity)>> GetFlightsWithDepartureCity(string location = "Vienna")
        {
            var result = await _context.Flights
                .Where(f => f.FlyFrom.Ort == location) 
                .Select(f => new
                {
                    Flightnumber = f.Kennung,
                    DestinationCity = f.FlyTo.Ort   
                })
                .ToListAsync();

            return result.Select(x => (x.Flightnumber, x.DestinationCity)).ToList();
        }

        // --- 4) Welche *Flights* haben *DepartureCity == "Vienna"* und zumindest 3 Tickets gekauft? Im Ergebnis soll nur die *Flightnumber* und der *DestinationCity* vorhanden sein. ---
        public async Task<List<(string Flightnumber, string DestinationCity)>> GetFlightsWithDepartureCityWithAtLeastXFlights(string location = "Vienna", int threshold = 3)
        {
            var result =  await _context.Flights
                .Where(f => f.FlyFrom.Ort == location && f.Tickets.Count() >= threshold)
                .Select(f => new
                {
                    Flightnumber = f.Kennung,
                    DestinationCity = f.FlyTo.Ort
                })
                .ToListAsync();

            return result.Select(x => (x.Flightnumber, x.DestinationCity)).ToList();
        }

        // --- 5) Group By: Top 3 Kunden pro Airline ---
        public async Task<List<object>> GetTop3PassengersPerAirlineAsync()
        {
            var result = await _context.Airlines
                .Select(a => new
                {
                    AirlineName = a.Name,
                    TopPassengers = _context.Tickets
                        .Where(t => t.Flight.Airplane.Airline.Id == a.Id)
                        .GroupBy(t => t.Passenger)
                        .Select(g => new
                        {
                            PassengerName = g.Key.Name,
                            Umsatz = g.Sum(t => t.Price)
                        })
                        .OrderByDescending(x => x.Umsatz)
                        .Take(3)
                        .ToList()
                })
                .ToListAsync();

            return result.Cast<object>().ToList();
        }

        // --- 6) Einfache Joins (Include) ---
        public async Task<List<Flight>> GetFlightsWithPilotsAndGatesAsync()
        {
            return await _context.Flights
                .Include(f => f.Pilot)
                .Include(f => f.CoPilot)
                .Include(f => f.Gate)
                .ToListAsync();
        }

        // --- 7) Tiefe Joins (Include & ThenInclude) ---
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