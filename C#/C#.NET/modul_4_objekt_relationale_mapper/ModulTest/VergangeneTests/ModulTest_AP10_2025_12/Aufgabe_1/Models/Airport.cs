using System;
using System.Collections.Generic;

namespace Aufgabe_1.Models;

public class Airport
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty; 
    public string City { get; set; } = string.Empty;
    
    public IEnumerable<BaggageClaim> BaggageCarousels { get; set; } = new List<BaggageClaim>();
}