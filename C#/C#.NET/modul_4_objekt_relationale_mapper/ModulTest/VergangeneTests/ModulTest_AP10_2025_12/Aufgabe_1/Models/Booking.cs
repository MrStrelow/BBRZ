using System;
using System.Collections.Generic;

namespace Aufgabe_1.Models;

public class Booking
{
    public int Id { get; set; }
    public string BookingReference { get; set; } = string.Empty;
    public DateTime BookingDate { get; set; }
    public decimal Price { get; set; }
    public BookingStatus Status { get; set; } = BookingStatus.Confirmed;
    public Passenger? Passenger { get; set; }
    public Flight? Flight { get; set; }
    public BoardingPass? BoardingPass { get; set; }
    public List<Luggage> LuggageItems { get; set; } = new List<Luggage>();
}