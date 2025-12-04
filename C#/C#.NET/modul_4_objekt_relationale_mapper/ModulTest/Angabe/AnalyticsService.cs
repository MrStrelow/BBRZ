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
             // TODO
        }

        // --- 2. Hole alle bookings aus der Datenbank.
        public async Task<List<Booking>> GetBookingssWithPassengerAsync()
        {
            // TODO
        }

        // --- 2. Berechne Bookings welche eine spezifische fligntNumber haben und sortiere das Ergebnis nach BoardingGroup. Verwende Include um Auf den BoardingPass zugreifen zu können.
        public async Task<List<Booking>> GetPassengerManifestAsync(string flightNumber)
        {
            // TODO
        }

        // --- 3. Berechne wie viele Passagiere "Cleared", "Denied" oder "AdditionalScreening" in einem SecurityCheck hatten. Verwende dazu ein GroupBy, danach ein Select mit g.Key.ToString() und g.Count().
        public async Task<List<object>> GetSecurityCheckStatsAsync()
        {
            // var stats = ...
            // TODO

            return stats.Cast<object>().ToList();
        }
    }
}