using Aufgabe_1.Data;
using Aufgabe_1.Models; // Deine Models
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aufgabe_1.Services
{
    public class AnalyticsService
    {
        private readonly TicketVerwaltungDbContext _context;

        public AnalyticsService(TicketVerwaltungDbContext context)
        {
            _context = context;
        }

        // --- 1. Hole alle bookings aus der Datenbank.
        public async Task<List<Booking>> GetBookingssAsync()
        {
             return await _context.Bookings.ToListAsync();
        }

        // --- 2. Hole alle bookings aus der Datenbank.
        public async Task<List<Booking>> GetBookingssWithPassengerAsync()
        {
            return await _context.Bookings
                .Include(b => b.Passenger)
                .ToListAsync();
        }

        // --- 3. Berechne Bookings welche eine spezifische fligntNumber haben und sortiere das Ergebnis nach BoardingGroup.
        public async Task<List<Booking>> GetPassengerManifestAsync(string flightNumber)
        {
            return await _context.Bookings
                .Where(b => b.Flight.FlightNumber == flightNumber && b.BoardingPass != null)
                .OrderBy(x => x.BoardingPass.BoardingGroup)
                .ToListAsync();
        }

        // --- 4. Berechne wie viele Passagiere "Cleared", "Denied" oder "AdditionalScreening" in einem SecurityCheck hatten. Verwende dazu ein GroupBy, danach ein Select mit g.Key.ToString() und g.Count().
        public async Task<List<object>> GetSecurityCheckStatsAsync()
        {
            var stats = await _context.SecurityChecks
                .GroupBy(s => s.Result)
                .Select(g => new
                {
                    Result = g.Key.ToString(),
                    Count = g.Count()
                })
                .ToListAsync();

            return stats.Cast<object>().ToList();
        }
    }
}