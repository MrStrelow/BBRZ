using System;
using System.Collections.Generic;

namespace Aufgabe_1.Models;

public class BaggageClaim
{
    public int Id { get; set; }
    public string CarouselNumber { get; set; } = string.Empty; 
    public string LocationDescription { get; set; } = string.Empty; 
    public int? CurrentFlightId { get; set; }
    public Flight? CurrentFlight { get; set; }
}