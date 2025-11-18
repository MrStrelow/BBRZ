using System;
using System.Collections.Generic;
using System.Text;

namespace Aufgabe_1.Models;

public class Pilot
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IEnumerable<Airplane> GeflogeneFlugzeuge { get; set; } = new List<Airplane>();
    public IEnumerable<Flight> GeflogeneFlügePilot { get; set; } = new List<Flight>();
    public IEnumerable<Flight> GeflogeneFlügeCopilot { get; set; } = new List<Flight>();
}
