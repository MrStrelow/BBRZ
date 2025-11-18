using System;
using System.Collections.Generic;
using System.Text;

namespace Aufgabe_1.Models;

public class Ticket
{
    public int Id { get; set; }
    public DateTime? BoughtOn { get; set; }
    public Flight Flight { get; set; }
}
