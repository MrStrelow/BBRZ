namespace Ticketverkauf.DTOs;

public class AnalyseDto
{
    public int? KundeMitDenMeistenTicketsId { get; set; }
    public string? KundeMitDenMeistenTicketsName { get; set; }

    public string? BeliebtesteZugstrecke { get; set; }
}