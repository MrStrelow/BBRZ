namespace Ticketverkauf.Entities;

public class Bus : ITransportmittel
{
    public int Id { get; set; }
    public string Linie { get; set; } = string.Empty;
    public decimal TicketPreis { get; set; }
}