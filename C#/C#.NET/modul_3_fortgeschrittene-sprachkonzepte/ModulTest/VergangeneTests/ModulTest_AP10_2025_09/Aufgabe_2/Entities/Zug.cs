namespace Ticketverkauf.Entities;

public class Zug : ITransportmittel
{
    public int Id { get; set; }
    public string ZugNummer { get; set; } = string.Empty;
    public string StartBahnhof { get; set; } = string.Empty;
    public string ZielBahnhof { get; set; } = string.Empty;
    public decimal TicketPreis { get; set; }
}