using System;
using System.Collections.Generic;
using System.Text;

namespace Aufgabe_1.Models;

public class Gate
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public IEnumerable<Flight> Flights { get; set; } = new List<Flight>();
}
