using System;
using System.Collections.Generic;
using System.Text;

namespace Aufgabe_1.Models;

public class Airline
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Umsatz { get; set; }
    public IEnumerable<Airplane> Airplane { get; set; } = new List<Airplane>();
}
