using System;
using System.Collections.Generic;
using System.Linq;
using Aufgabe_1.Models;

namespace Aufgabe_1.Data
{
    public static class SeedData
    {
        public static List<Airline> airlines = new List<Airline>();
        public static List<Airplane> airplanes = new List<Airplane>();
        public static List<Pilot> pilots = new List<Pilot>();
        public static List<Gate> gates = new List<Gate>();
        public static List<Terminal> terminals = new List<Terminal>();
        public static List<Airport> airports = new List<Airport>();
        public static List<Flight> flights = new List<Flight>();
        public static List<Passenger> passengers = new List<Passenger>();
        public static List<Ticket> tickets = new List<Ticket>();

        public static void Initialize(TicketVerwaltungDbContext context)
        {
            if (context.Airlines.Any()) // naja. weird check. aba reicht für uns.
            {
                return;   // DB wurde bereits initialisiert
            }

            // ---------------------------------------------------------
            // 1. AIRLINES
            // ---------------------------------------------------------
            var airline1 = new Airline { Name = "Lufthansa" };
            var airline2 = new Airline { Name = "Emirates" };
            var airline3 = new Airline { Name = "Ryanair" };
            var airline4 = new Airline { Name = "Delta Airlines" };
            var airline5 = new Airline { Name = "British Airways" };
            var airline6 = new Airline { Name = "Air France" };
            var airline7 = new Airline { Name = "KLM" };
            var airline8 = new Airline { Name = "Qatar Airways" };
            var airline9 = new Airline { Name = "Singapore Airlines" };
            var airline10 = new Airline { Name = "Austrian Airlines" };

            airlines.AddRange(new[] { airline1, airline2, airline3, airline4, airline5, airline6, airline7, airline8, airline9, airline10 });
            context.Airlines.AddRange(airlines);

            // ---------------------------------------------------------
            // 2. AIRPLANES
            // ---------------------------------------------------------
            var plane1 = new Airplane { ManufactoringDate = new DateTime(2015, 5, 20), Airline = airline1 };
            var plane2 = new Airplane { ManufactoringDate = new DateTime(2018, 3, 15), Airline = airline2 };
            var plane3 = new Airplane { ManufactoringDate = new DateTime(2010, 8, 10), Airline = airline3 };
            var plane4 = new Airplane { ManufactoringDate = new DateTime(2019, 11, 1), Airline = airline4 };
            var plane5 = new Airplane { ManufactoringDate = new DateTime(2016, 6, 30), Airline = airline5 };
            var plane6 = new Airplane { ManufactoringDate = new DateTime(2020, 1, 20), Airline = airline6 };
            var plane7 = new Airplane { ManufactoringDate = new DateTime(2017, 9, 12), Airline = airline7 };
            var plane8 = new Airplane { ManufactoringDate = new DateTime(2021, 2, 28), Airline = airline8 };
            var plane9 = new Airplane { ManufactoringDate = new DateTime(2014, 7, 14), Airline = airline9 };
            var plane10 = new Airplane { ManufactoringDate = new DateTime(2012, 12, 5), Airline = airline10 };

            airplanes.AddRange(new[] { plane1, plane2, plane3, plane4, plane5, plane6, plane7, plane8, plane9, plane10 });
            context.Airplanes.AddRange(airplanes);

            // ---------------------------------------------------------
            // 3. PILOTS
            // ---------------------------------------------------------
            var pilot1 = new Pilot { Name = "Markus Söder" };
            var pilot2 = new Pilot { Name = "Angela Merkel" };
            var pilot3 = new Pilot { Name = "Olaf Scholz" };
            var pilot4 = new Pilot { Name = "Friedrich Merz" };
            var pilot5 = new Pilot { Name = "Robert Habeck" };
            var pilot6 = new Pilot { Name = "Annalena Baerbock" };
            var pilot7 = new Pilot { Name = "Christian Lindner" };
            var pilot8 = new Pilot { Name = "Ursula von der Leyen" };
            var pilot9 = new Pilot { Name = "Boris Johnson" };
            var pilot10 = new Pilot { Name = "Emmanuel Macron" };

            pilots.AddRange(new[] { pilot1, pilot2, pilot3, pilot4, pilot5, pilot6, pilot7, pilot8, pilot9, pilot10 });
            context.Pilots.AddRange(pilots);

            // ---------------------------------------------------------
            // 4. GATES
            // ---------------------------------------------------------
            var gate1 = new Gate { Name = "A01", Location = "Terminal 1 West" };
            var gate2 = new Gate { Name = "A02", Location = "Terminal 1 West" };
            var gate3 = new Gate { Name = "B01", Location = "Terminal 1 Ost" };
            var gate4 = new Gate { Name = "B02", Location = "Terminal 1 Ost" };
            var gate5 = new Gate { Name = "C01", Location = "Terminal 2 Nord" };
            var gate6 = new Gate { Name = "C02", Location = "Terminal 2 Nord" };
            var gate7 = new Gate { Name = "D01", Location = "Terminal 2 Süd" };
            var gate8 = new Gate { Name = "D02", Location = "Terminal 2 Süd" };
            var gate9 = new Gate { Name = "E01", Location = "Terminal 3" };
            var gate10 = new Gate { Name = "E02", Location = "Terminal 3" };

            gates.AddRange(new[] { gate1, gate2, gate3, gate4, gate5, gate6, gate7, gate8, gate9, gate10 });
            context.Gates.AddRange(gates);

            // ---------------------------------------------------------
            // 5. TERMINALS
            // ---------------------------------------------------------
            var term1 = new Terminal { Name = "Terminal 1 FRA", Gates = new List<Gate> { gate1 } };
            var term2 = new Terminal { Name = "Terminal 2 FRA", Gates = new List<Gate> { gate2 } };
            var term3 = new Terminal { Name = "Terminal 1 MUC", Gates = new List<Gate> { gate3 } };
            var term4 = new Terminal { Name = "Terminal 2 MUC", Gates = new List<Gate> { gate4 } };
            var term5 = new Terminal { Name = "Terminal 5 LHR", Gates = new List<Gate> { gate5 } };
            var term6 = new Terminal { Name = "Terminal 2 LHR", Gates = new List<Gate> { gate6 } };
            var term7 = new Terminal { Name = "Terminal 1 JFK", Gates = new List<Gate> { gate7 } };
            var term8 = new Terminal { Name = "Terminal 4 JFK", Gates = new List<Gate> { gate8 } };
            var term9 = new Terminal { Name = "Terminal 3 DXB", Gates = new List<Gate> { gate9 } };
            var term10 = new Terminal { Name = "Terminal 1 VIE", Gates = new List<Gate> { gate10 } };

            terminals.AddRange(new[] { term1, term2, term3, term4, term5, term6, term7, term8, term9, term10 });
            context.Terminals.AddRange(terminals);

            // ---------------------------------------------------------
            // 6. AIRPORTS
            // ---------------------------------------------------------
            var airport1 = new Airport { Ort = "Frankfurt", Land = "Deutschland", Kennung = "FRA", Terminals = new List<Terminal> { term1, term2 } };
            var airport2 = new Airport { Ort = "München", Land = "Deutschland", Kennung = "MUC", Terminals = new List<Terminal> { term3, term4 } };
            var airport3 = new Airport { Ort = "London", Land = "UK", Kennung = "LHR", Terminals = new List<Terminal> { term5, term6 } };
            var airport4 = new Airport { Ort = "New York", Land = "USA", Kennung = "JFK", Terminals = new List<Terminal> { term7, term8 } };
            var airport5 = new Airport { Ort = "Dubai", Land = "VAE", Kennung = "DXB", Terminals = new List<Terminal> { term9 } };
            var airport6 = new Airport { Ort = "Wien", Land = "Österreich", Kennung = "VIE", Terminals = new List<Terminal> { term10 } };
            var airport7 = new Airport { Ort = "Paris", Land = "Frankreich", Kennung = "CDG", Terminals = new List<Terminal>() };
            var airport8 = new Airport { Ort = "Amsterdam", Land = "Niederlande", Kennung = "AMS", Terminals = new List<Terminal>() };
            var airport9 = new Airport { Ort = "Tokio", Land = "Japan", Kennung = "HND", Terminals = new List<Terminal>() };
            var airport10 = new Airport { Ort = "Sydney", Land = "Australien", Kennung = "SYD", Terminals = new List<Terminal>() };

            airports.AddRange(new[] { airport1, airport2, airport3, airport4, airport5, airport6, airport7, airport8, airport9, airport10 });
            context.Airports.AddRange(airports);

            // ---------------------------------------------------------
            // 7. FLIGHTS
            // ---------------------------------------------------------
            var GateOpensForAllFlights = DateTime.Now.AddHours(2).AddMinutes(-45);
            var GateClosesForAllFlights = DateTime.Now.AddHours(2).AddMinutes(-15);

            var flight1 = new Flight { Kennung = "LH100", GateOpens = GateOpensForAllFlights, GateCloses = GateClosesForAllFlights, FlyFrom = airport1, FlyTo = airport2, Pilot = pilot1, CoPilot = pilot2, Airplane = plane1, Gate = gate1, TakeOff = DateTime.Now.AddHours(2) };
            var flight2 = new Flight { Kennung = "EK202", GateOpens = GateOpensForAllFlights, GateCloses = GateClosesForAllFlights, FlyFrom = airport5, FlyTo = airport3, Pilot = pilot3, CoPilot = pilot4, Airplane = plane2, Gate = gate9, TakeOff = DateTime.Now.AddHours(5) };
            var flight3 = new Flight { Kennung = "FR303", GateOpens = GateOpensForAllFlights, GateCloses = GateClosesForAllFlights, FlyFrom = airport3, FlyTo = airport8, Pilot = pilot5, CoPilot = pilot6, Airplane = plane3, Gate = gate5, TakeOff = DateTime.Now.AddHours(1) };
            var flight4 = new Flight { Kennung = "DL404", GateOpens = GateOpensForAllFlights, GateCloses = GateClosesForAllFlights, FlyFrom = airport4, FlyTo = airport1, Pilot = pilot7, CoPilot = pilot8, Airplane = plane4, Gate = gate7, TakeOff = DateTime.Now.AddHours(10) };
            var flight5 = new Flight { Kennung = "BA505", GateOpens = GateOpensForAllFlights, GateCloses = GateClosesForAllFlights, FlyFrom = airport3, FlyTo = airport7, Pilot = pilot9, CoPilot = pilot10, Airplane = plane5, Gate = gate6, TakeOff = DateTime.Now.AddHours(3) };
            var flight6 = new Flight { Kennung = "AF606", GateOpens = GateOpensForAllFlights, GateCloses = GateClosesForAllFlights, FlyFrom = airport7, FlyTo = airport2, Pilot = pilot1, CoPilot = pilot3, Airplane = plane6, Gate = gate1, TakeOff = DateTime.Now.AddHours(4) };
            var flight7 = new Flight { Kennung = "KL707", GateOpens = GateOpensForAllFlights, GateCloses = GateClosesForAllFlights, FlyFrom = airport8, FlyTo = airport9, Pilot = pilot2, CoPilot = pilot4, Airplane = plane7, Gate = gate2, TakeOff = DateTime.Now.AddHours(12) };
            var flight8 = new Flight { Kennung = "QR808", GateOpens = GateOpensForAllFlights, GateCloses = GateClosesForAllFlights, FlyFrom = airport5, FlyTo = airport10, Pilot = pilot5, CoPilot = pilot7, Airplane = plane8, Gate = gate9, TakeOff = DateTime.Now.AddHours(14) };
            var flight9 = new Flight { Kennung = "SQ909", GateOpens = GateOpensForAllFlights, GateCloses = GateClosesForAllFlights, FlyFrom = airport9, FlyTo = airport6, Pilot = pilot6, CoPilot = pilot8, Airplane = plane9, Gate = gate1, TakeOff = DateTime.Now.AddHours(11) };
            var flight10 = new Flight { Kennung = "OS010", GateOpens = GateOpensForAllFlights, GateCloses = GateClosesForAllFlights, FlyFrom = airport6, FlyTo = airport1, Pilot = pilot9, CoPilot = pilot1, Airplane = plane10, Gate = gate10, TakeOff = DateTime.Now.AddHours(1) };

            flights.AddRange(new[] { flight1, flight2, flight3, flight4, flight5, flight6, flight7, flight8, flight9, flight10 });
            context.Flights.AddRange(flights);

            // ---------------------------------------------------------
            // 8. PASSENGERS
            // ---------------------------------------------------------
            // Wir erstellen zuerst die Passagiere, die Liste der Tickets bleibt hier leer.
            // Durch die Zuweisung im Ticket (unten) wird die Beziehung in der DB korrekt gesetzt.
            var p1 = new Passenger { Name = "Max Mustermann" };
            var p2 = new Passenger { Name = "Erika Musterfrau" };
            var p3 = new Passenger { Name = "John Doe" };
            var p4 = new Passenger { Name = "Jane Doe" };
            var p5 = new Passenger { Name = "Mario Rossi" };
            var p6 = new Passenger { Name = "Luigi Verdi" };
            var p7 = new Passenger { Name = "Jean Dupont" };
            var p8 = new Passenger { Name = "Marie Curie" };
            var p9 = new Passenger { Name = "Albert Einstein" };
            var p10 = new Passenger { Name = "Isaac Newton" };

            passengers.AddRange(new[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 });
            context.Passengers.AddRange(passengers);

            // ---------------------------------------------------------
            // 9. TICKETS (50 Objekte)
            // ---------------------------------------------------------
            // Hier weisen wir die Passagiere gemischt den Flügen zu.

            // Flug 1: Gemischte Passagiere (p1 - p5)
            var t1 = new Ticket { Price = 120m, BoughtOn = DateTime.Now.AddDays(-10), Flight = flight1, Passenger = p1 };
            var t2 = new Ticket { Price = 130m, BoughtOn = DateTime.Now.AddDays(-9), Flight = flight1, Passenger = p2 };
            var t3 = new Ticket { Price = 110m, BoughtOn = DateTime.Now.AddDays(-8), Flight = flight1, Passenger = p3 };
            var t4 = new Ticket { Price = 150m, BoughtOn = DateTime.Now.AddDays(-7), Flight = flight1, Passenger = p4 };
            var t5 = new Ticket { Price = 125m, BoughtOn = DateTime.Now.AddDays(-6), Flight = flight1, Passenger = p5 };

            // Flug 2: Gemischte Passagiere (p6 - p10)
            var t6 = new Ticket { Price = 500m, BoughtOn = DateTime.Now.AddDays(-20), Flight = flight2, Passenger = p6 };
            var t7 = new Ticket { Price = 550m, BoughtOn = DateTime.Now.AddDays(-19), Flight = flight2, Passenger = p7 };
            var t8 = new Ticket { Price = 520m, BoughtOn = DateTime.Now.AddDays(-18), Flight = flight2, Passenger = p8 };
            var t9 = new Ticket { Price = 480m, BoughtOn = DateTime.Now.AddDays(-17), Flight = flight2, Passenger = p9 };
            var t10 = new Ticket { Price = 600m, BoughtOn = DateTime.Now.AddDays(-16), Flight = flight2, Passenger = p10 };

            // Flug 3: Gemischte Passagiere (Wiederholung, etwas versetzt)
            var t11 = new Ticket { Price = 40m, BoughtOn = DateTime.Now.AddDays(-5), Flight = flight3, Passenger = p1 };
            var t12 = new Ticket { Price = 35m, BoughtOn = DateTime.Now.AddDays(-5), Flight = flight3, Passenger = p3 };
            var t13 = new Ticket { Price = 45m, BoughtOn = DateTime.Now.AddDays(-4), Flight = flight3, Passenger = p5 };
            var t14 = new Ticket { Price = 50m, BoughtOn = DateTime.Now.AddDays(-3), Flight = flight3, Passenger = p7 };
            var t15 = new Ticket { Price = 29m, BoughtOn = DateTime.Now.AddDays(-2), Flight = flight3, Passenger = p9 };

            // Flug 4
            var t16 = new Ticket { Price = 800m, BoughtOn = DateTime.Now.AddDays(-30), Flight = flight4, Passenger = p2 };
            var t17 = new Ticket { Price = 850m, BoughtOn = DateTime.Now.AddDays(-28), Flight = flight4, Passenger = p4 };
            var t18 = new Ticket { Price = 780m, BoughtOn = DateTime.Now.AddDays(-25), Flight = flight4, Passenger = p6 };
            var t19 = new Ticket { Price = 820m, BoughtOn = DateTime.Now.AddDays(-22), Flight = flight4, Passenger = p8 };
            var t20 = new Ticket { Price = 900m, BoughtOn = DateTime.Now.AddDays(-20), Flight = flight4, Passenger = p10 };

            // Flug 5
            var t21 = new Ticket { Price = 200m, BoughtOn = DateTime.Now.AddDays(-12), Flight = flight5, Passenger = p1 };
            var t22 = new Ticket { Price = 210m, BoughtOn = DateTime.Now.AddDays(-11), Flight = flight5, Passenger = p2 };
            var t23 = new Ticket { Price = 190m, BoughtOn = DateTime.Now.AddDays(-10), Flight = flight5, Passenger = p1 }; // Vielflieger p1
            var t24 = new Ticket { Price = 220m, BoughtOn = DateTime.Now.AddDays(-9), Flight = flight5, Passenger = p4 };
            var t25 = new Ticket { Price = 205m, BoughtOn = DateTime.Now.AddDays(-8), Flight = flight5, Passenger = p5 };

            // Flug 6
            var t26 = new Ticket { Price = 180m, BoughtOn = DateTime.Now.AddDays(-14), Flight = flight6, Passenger = p6 };
            var t27 = new Ticket { Price = 185m, BoughtOn = DateTime.Now.AddDays(-13), Flight = flight6, Passenger = p7 };
            var t28 = new Ticket { Price = 175m, BoughtOn = DateTime.Now.AddDays(-12), Flight = flight6, Passenger = p8 };
            var t29 = new Ticket { Price = 190m, BoughtOn = DateTime.Now.AddDays(-11), Flight = flight6, Passenger = p9 };
            var t30 = new Ticket { Price = 160m, BoughtOn = DateTime.Now.AddDays(-10), Flight = flight6, Passenger = p10 };

            // Flug 7
            var t31 = new Ticket { Price = 300m, BoughtOn = DateTime.Now.AddDays(-15), Flight = flight7, Passenger = p3 };
            var t32 = new Ticket { Price = 310m, BoughtOn = DateTime.Now.AddDays(-14), Flight = flight7, Passenger = p4 };
            var t33 = new Ticket { Price = 320m, BoughtOn = DateTime.Now.AddDays(-13), Flight = flight7, Passenger = p1 };
            var t34 = new Ticket { Price = 290m, BoughtOn = DateTime.Now.AddDays(-12), Flight = flight7, Passenger = p2 };
            var t35 = new Ticket { Price = 330m, BoughtOn = DateTime.Now.AddDays(-11), Flight = flight7, Passenger = p5 };

            // Flug 8
            var t36 = new Ticket { Price = 700m, BoughtOn = DateTime.Now.AddDays(-25), Flight = flight8, Passenger = p6 };
            var t37 = new Ticket { Price = 720m, BoughtOn = DateTime.Now.AddDays(-24), Flight = flight8, Passenger = p10 };
            var t38 = new Ticket { Price = 680m, BoughtOn = DateTime.Now.AddDays(-23), Flight = flight8, Passenger = p7 };
            var t39 = new Ticket { Price = 750m, BoughtOn = DateTime.Now.AddDays(-22), Flight = flight8, Passenger = p8 };
            var t40 = new Ticket { Price = 710m, BoughtOn = DateTime.Now.AddDays(-21), Flight = flight8, Passenger = p9 };

            // Flug 9
            var t41 = new Ticket { Price = 950m, BoughtOn = DateTime.Now.AddDays(-40), Flight = flight9, Passenger = p1 };
            var t42 = new Ticket { Price = 980m, BoughtOn = DateTime.Now.AddDays(-38), Flight = flight9, Passenger = p10 };
            var t43 = new Ticket { Price = 920m, BoughtOn = DateTime.Now.AddDays(-35), Flight = flight9, Passenger = p2 };
            var t44 = new Ticket { Price = 960m, BoughtOn = DateTime.Now.AddDays(-32), Flight = flight9, Passenger = p9 };
            var t45 = new Ticket { Price = 990m, BoughtOn = DateTime.Now.AddDays(-30), Flight = flight9, Passenger = p3 };

            // Flug 10
            var t46 = new Ticket { Price = 100m, BoughtOn = DateTime.Now.AddDays(-5), Flight = flight10, Passenger = p1 };
            var t47 = new Ticket { Price = 110m, BoughtOn = DateTime.Now.AddDays(-4), Flight = flight10, Passenger = p2 };
            var t48 = new Ticket { Price = 95m, BoughtOn = DateTime.Now.AddDays(-3), Flight = flight10, Passenger = p3 };
            var t49 = new Ticket { Price = 105m, BoughtOn = DateTime.Now.AddDays(-2), Flight = flight10, Passenger = p4 };
            var t50 = new Ticket { Price = 90m, BoughtOn = DateTime.Now.AddDays(-1), Flight = flight10, Passenger = p5 };
            var t51 = new Ticket { Price = 100m, BoughtOn = DateTime.Now.AddDays(-5), Flight = flight10, Passenger = p6 };
            var t52 = new Ticket { Price = 110m, BoughtOn = DateTime.Now.AddDays(-4), Flight = flight10, Passenger = p7 };
            var t53 = new Ticket { Price = 95m, BoughtOn = DateTime.Now.AddDays(-3), Flight = flight10, Passenger = p8 };
            var t54 = new Ticket { Price = 105m, BoughtOn = DateTime.Now.AddDays(-2), Flight = flight10, Passenger = p9 };
            var t55 = new Ticket { Price = 90m, BoughtOn = DateTime.Now.AddDays(-1), Flight = flight10, Passenger = p10 };

            tickets.AddRange(new[] {
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
                t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
                t21, t22, t23, t24, t25, t26, t27, t28, t29, t30,
                t31, t32, t33, t34, t35, t36, t37, t38, t39, t40,
                t41, t42, t43, t44, t45, t46, t47, t48, t49, t50,
                t51, t52, t53, t54, t55
            });
            context.Tickets.AddRange(tickets);

            // ---------------------------------------------------------
            // 10. BERECHNUNG UMSATZ (LINQ)
            // ---------------------------------------------------------
            // Berechnet den Umsatz der Airlines basierend auf den generierten Tickets
            airlines.ForEach(airline =>
            {
                airline.Umsatz = tickets
                    .Where(t => t.Flight?.Airplane?.Airline == airline)
                    .Sum(t => t.Price);
            });

            // ---------------------------------------------------------
            // 11. SPEICHERN IN DIE DATENBANK
            // ---------------------------------------------------------
            context.SaveChanges();
        }
    }
}