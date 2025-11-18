using System;
using System.Collections.Generic;
using System.Text;

namespace Aufgabe_1.Models;

public class Passenger
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IEnumerable<Ticket> Tickets { get; set; } = new List<Ticket>();
}
