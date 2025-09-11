namespace Ticketverkauf.DTOs;

public enum VerkehrsmittelTyp
{
    Bus,
    Zug
}

public class TicketKaufWunschDto
{
    public int KundenId { get; set; }
    public int VerkehrsmittelId { get; set; }
    public VerkehrsmittelTyp Typ { get; set; }
}