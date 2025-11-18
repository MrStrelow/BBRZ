using System;
using System.Collections.Generic;
using System.Text;

namespace Aufgabe_1.Models;

public class Flight
{
    public int Id { get; set; }
    public string Kennung { get; set; } = string.Empty;
    public DateTime? TakeOff { get; set; }
    public DateTime? GateCloses { get; set; }
    public DateTime? GateOpens { get; set; }
    public Airplane? Airplane { get; set; }
    public Gate? Gate { get; set; }
    public IEnumerable<Ticket> Tickets { get; set; } = new List<Ticket>();

    public int PilotId { get; set; }
    public Pilot? Pilot { get; set; }

    public int CoPilotId { get; set; }
    public Pilot? CoPilot { get; set; }
}
