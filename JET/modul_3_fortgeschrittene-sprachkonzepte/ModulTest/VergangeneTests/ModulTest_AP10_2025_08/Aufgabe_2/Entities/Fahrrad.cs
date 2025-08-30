using System.Collections.Generic;

namespace Fahrradverleih.Entities;

public class Fahrrad
{
    public int Id { get; set; }
    public string Modell { get; set; } = string.Empty;
    public decimal PreisProStunde { get; set; }
}