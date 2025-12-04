using System;
using System.Collections.Generic;
using System.Linq;
using Aufgabe_1.Models;

namespace Aufgabe_1.Data
{
    public static class SeedData
    {
        // Listen zum Zwischenspeichern der Objekte für Relationen
        public static List<Airport> airports = new List<Airport>();
        public static List<Gate> gates = new List<Gate>();
        public static List<Flight> flights = new List<Flight>();
        public static List<Passenger> passengers = new List<Passenger>();
        public static List<Booking> bookings = new List<Booking>();

        public static void Initialize(TicketVerwaltungDbContext context)
        {
            // Prüfen, ob DB schon initialisiert ist
            if (context.Airports.Any())
            {
                return;
            }

            // ---------------------------------------------------------
            // 1. AIRPORTS & BAGGAGE CLAIMS
            // ---------------------------------------------------------
            var fra = new Airport
            {
                Code = "FRA",
                City = "Frankfurt",
                BaggageCarousels = new List<BaggageClaim>
                {
                    new BaggageClaim { CarouselNumber = "Band 1", LocationDescription = "Halle A" },
                    new BaggageClaim { CarouselNumber = "Band 8", LocationDescription = "Halle B (International)" }
                }
            };

            var vie = new Airport
            {
                Code = "VIE",
                City = "Vienna",
                BaggageCarousels = new List<BaggageClaim>
                {
                    new BaggageClaim { CarouselNumber = "Gepäckausgabe 1", LocationDescription = "Terminal 3" }
                }
            };

            var jfk = new Airport
            {
                Code = "JFK",
                City = "New York",
                BaggageCarousels = new List<BaggageClaim>
                {
                    new BaggageClaim { CarouselNumber = "Carousel 5", LocationDescription = "Arrivals Level" }
                }
            };

            airports.AddRange(new[] { fra, vie, jfk });
            context.Airports.AddRange(airports);

            // ---------------------------------------------------------
            // 2. GATES
            // ---------------------------------------------------------
            var gateFra1 = new Gate { Name = "A15", Location = "Terminal 1 FRA" };
            var gateVie1 = new Gate { Name = "F03", Location = "Terminal 3 VIE" };

            gates.AddRange(new[] { gateFra1, gateVie1 });
            context.Gates.AddRange(gates);

            // ---------------------------------------------------------
            // 3. FLIGHTS
            // ---------------------------------------------------------
            // Flug LH123: FRA -> VIE
            var flight1 = new Flight
            {
                FlightNumber = "LH123",
                ScheduledDeparture = DateTime.Now.AddHours(2),
                ScheduledArrival = DateTime.Now.AddHours(3.5),
                FromAirport = fra,
                ToAirport = vie,
                BaggageClaim = vie.BaggageCarousels.First(b => b.CarouselNumber == "Gepäckausgabe 1")
            };

            // Flug OS087: VIE -> JFK
            var flight2 = new Flight
            {
                FlightNumber = "OS087",
                ScheduledDeparture = DateTime.Now.AddHours(5),
                ScheduledArrival = DateTime.Now.AddHours(13),
                FromAirport = vie,
                ToAirport = jfk,
                BaggageClaim = jfk.BaggageCarousels.First(b => b.CarouselNumber == "Carousel 5")
            };

            flights.AddRange(new[] { flight1, flight2 });
            context.Flights.AddRange(flights);

            // ---------------------------------------------------------
            // 4. PASSENGERS
            // ---------------------------------------------------------
            var p1 = new Passenger { FirstName = "Max", LastName = "Mustermann", Email = "max@demo.com", PassportNumber = "P001" };
            var p2 = new Passenger { FirstName = "Erika", LastName = "Musterfrau", Email = "erika@demo.com", PassportNumber = "P002" };
            var p3 = new Passenger { FirstName = "John", LastName = "Doe", Email = "john@demo.com", PassportNumber = "US555" };
            var p4 = new Passenger { FirstName = "Jane", LastName = "Lost", Email = "jane@demo.com", PassportNumber = "UK111" };
            var p5 = new Passenger { FirstName = "Hans", LastName = "NoShow", Email = "hans@late.com", PassportNumber = "DE999" };
            var p6 = new Passenger { FirstName = "Gary", LastName = "Danger", Email = "gary@danger.com", PassportNumber = "XX000" };

            passengers.AddRange(new[] { p1, p2, p3, p4, p5, p6 });
            context.Passengers.AddRange(passengers);

            // ---------------------------------------------------------
            // 5. BOOKINGS & PROCESS DATA
            // ---------------------------------------------------------

            // --- Szenario A: Normaler Passagier (Cleared) ---
            var b1 = new Booking { BookingReference = "REF01", Status = BookingStatus.CheckedIn, Passenger = p1, Flight = flight1, Price = 150m, BookingDate = DateTime.Now.AddDays(-10) };
            b1.BoardingPass = new BoardingPass { SeatNumber = "12A", BoardingGroup = 1, IssuedAt = DateTime.Now.AddHours(-2), Gate = gateFra1 };
            var sec1 = new SecurityCheck { Result = SecurityResult.Cleared, CheckedAt = DateTime.Now.AddHours(-1.5), Booking = b1 };

            // --- Szenario B: Normaler Passagier (Cleared) - Andere Boarding Group ---
            var b2 = new Booking { BookingReference = "REF02", Status = BookingStatus.CheckedIn, Passenger = p2, Flight = flight1, Price = 120m, BookingDate = DateTime.Now.AddDays(-5) };
            b2.BoardingPass = new BoardingPass { SeatNumber = "12B", BoardingGroup = 2, IssuedAt = DateTime.Now.AddHours(-2), Gate = gateFra1 };
            var sec2 = new SecurityCheck { Result = SecurityResult.Cleared, CheckedAt = DateTime.Now.AddHours(-1.4), Booking = b2 };

            // --- Szenario C: Gepäck verloren (Cleared) ---
            var b3 = new Booking { BookingReference = "REF03", Status = BookingStatus.CheckedIn, Passenger = p4, Flight = flight1, Price = 200m, BookingDate = DateTime.Now.AddDays(-20) };
            b3.BoardingPass = new BoardingPass { SeatNumber = "14C", BoardingGroup = 3, IssuedAt = DateTime.Now.AddHours(-2), Gate = gateFra1 };
            b3.LuggageItems.Add(new Luggage { TagId = "LOST-99", Status = LuggageStatus.Lost, WeightInKg = 20 });
            var sec3 = new SecurityCheck { Result = SecurityResult.Cleared, CheckedAt = DateTime.Now.AddHours(-1.6), Booking = b3 };

            // --- Szenario D: No-Show (Confirmed, aber KEIN BoardingPass) ---
            // Dieser Passagier taucht im Manifest NICHT auf, da BoardingPass null ist
            var b4 = new Booking { BookingReference = "REF04", Status = BookingStatus.Confirmed, Passenger = p5, Flight = flight1, Price = 300m, BookingDate = DateTime.Now.AddDays(-2) };
            // Keine Security, Kein BoardingPass

            // --- Szenario E: Security Check - Additional Screening ---
            var b5 = new Booking { BookingReference = "REF05", Status = BookingStatus.CheckedIn, Passenger = p3, Flight = flight2, Price = 850m, BookingDate = DateTime.Now.AddDays(-30) };
            b5.BoardingPass = new BoardingPass { SeatNumber = "45D", BoardingGroup = 4, IssuedAt = DateTime.Now.AddHours(-4), Gate = gateVie1 };
            var sec5 = new SecurityCheck { Result = SecurityResult.AdditionalScreeningRequired, CheckedAt = DateTime.Now.AddHours(-3), Booking = b5 };

            // --- Szenario F: Security Check - DENIED (Gefahr!) ---
            // Neu hinzugefügt für Analytics Abfrage 3
            var b6 = new Booking { BookingReference = "REF06", Status = BookingStatus.CheckedIn, Passenger = p6, Flight = flight1, Price = 500m, BookingDate = DateTime.Now.AddDays(-1) };
            b6.BoardingPass = new BoardingPass { SeatNumber = "99Z", BoardingGroup = 5, IssuedAt = DateTime.Now.AddHours(-1), Gate = gateFra1 };
            var sec6 = new SecurityCheck { Result = SecurityResult.Denied, CheckedAt = DateTime.Now.AddHours(-0.5), Booking = b6 };

            bookings.AddRange(new[] { b1, b2, b3, b4, b5, b6 });
            context.Bookings.AddRange(bookings);

            // Security Checks explizit hinzufügen (da DbSet vorhanden ist)
            context.SecurityChecks.AddRange(new[] { sec1, sec2, sec3, sec5, sec6 });

            context.SaveChanges();
        }
    }
}