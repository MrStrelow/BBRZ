using System;
using System.Collections.Generic;

namespace Aufgabe_1.Models;

public class Flight
{
    public int Id { get; set; }
    public string FlightNumber { get; set; } = string.Empty;
    public DateTime ScheduledDeparture { get; set; }
    public DateTime ScheduledArrival { get; set; }
    public Airport? FromAirport { get; set; }
    public Airport? ToAirport { get; set; }
    public BaggageClaim? BaggageClaim { get; set; }

    public IEnumerable<Booking> Bookings { get; set; } = new List<Booking>();
}