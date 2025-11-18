using System;
using System.Collections.Generic;
using System.Text;

namespace Aufgabe_1.Models;

public class Airplane
{
    public int Id { get; set; }
    public DateTime? ManufactoringDate { get; set; }
    public Airline? Airline { get; set; }
}
