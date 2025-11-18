using System;
using System.Collections.Generic;
using System.Text;

namespace Aufgabe_1.Models;

public class Terminal
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IEnumerable<Gate> Gates { get; set; } = new List<Gate>();
}
