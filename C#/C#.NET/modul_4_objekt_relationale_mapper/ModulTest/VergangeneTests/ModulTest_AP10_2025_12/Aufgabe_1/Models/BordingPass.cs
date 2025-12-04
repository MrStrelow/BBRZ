using System;

namespace Aufgabe_1.Models;

public class BoardingPass
{
    public int Id { get; set; }
    public string SeatNumber { get; set; } = string.Empty; 
    public int BoardingGroup { get; set; } 
    public DateTime IssuedAt { get; set; }
    public Gate? Gate{ get; set; }
    public int BookingId { get; set; }
    public Booking? Booking { get; set; }
}