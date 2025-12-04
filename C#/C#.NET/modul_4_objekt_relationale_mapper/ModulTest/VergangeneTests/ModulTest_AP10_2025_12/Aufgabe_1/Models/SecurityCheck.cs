using System;

namespace Aufgabe_1.Models;

public class SecurityCheck
{
    public int Id { get; set; }
    public DateTime CheckedAt { get; set; }
    public SecurityResult Result { get; set; }
    public Booking? Booking { get; set; }
}