using System;

namespace Aufgabe_1.Models;

public class Luggage
{
    public int Id { get; set; }
    public string TagId { get; set; } = string.Empty; 
    public double WeightInKg { get; set; }
    public bool IsCarryOn { get; set; } 
    public LuggageStatus Status { get; set; } = LuggageStatus.CheckedIn;
    public Booking? Booking { get; set; }
}