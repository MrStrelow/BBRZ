using System;
using System.Collections.Generic;
using System.Text;

namespace Aufgabe_1.Models;

public class Airport
{
    public int Id { get; set; }
    public string Ort { get; set; } = string.Empty;
    public string Land { get; set; } = string.Empty;
    public string Kennung { get; set; } = string.Empty;
    public IEnumerable<Terminal> Terminals { get; set; } = new List<Terminal>();
}
