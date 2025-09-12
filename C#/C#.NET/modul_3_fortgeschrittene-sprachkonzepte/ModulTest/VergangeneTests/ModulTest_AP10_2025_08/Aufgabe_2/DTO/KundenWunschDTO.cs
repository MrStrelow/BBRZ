namespace Fahrradverleih.DTOs;

public class KundenWunschDto
{
    public int KundenId { get; set; }
    public List<KundenAuftragDTO> Ausleihwuensche { get; set; } = new();
}

public class KundenAuftragDTO
{
    public int FahrradId { get; set; }
}

public class ReservierungsWunschDto
{
    public int KundenId { get; set; }
    public int FahrradId { get; set; }
    public DateTime ReservierungsDatum { get; set; }
}