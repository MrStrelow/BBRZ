using Serilog;
using System.Linq;
using System.Threading.Tasks;
using Ticketverkauf.DTOs;
using Ticketverkauf.Entities;
using Ticketverkauf.Repositories;

namespace Ticketverkauf.Services;

public interface IAnalyseService
{
    Task<AnalyseDto> FindeKundenUndBeliebtesteStreckenAsync();
}

public class AnalyseService : IAnalyseService
{
    private readonly ITicketRepository _ticketRepository;

    public AnalyseService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<AnalyseDto> FindeKundenUndBeliebtesteStreckenAsync()
    {
        Log.Information("Starte Analyse: Kunde mit den meisten Tickets...");
        var tickets = await _ticketRepository.GetAllAsync();

        if (!tickets.Any())
        {
            Log.Warning("Keine Tickets für die Analyse gefunden.");
            return new AnalyseDto();
        }

        // TODO: berechne den Kunden mit den Meisten Tickets. 
        // Hinweis:
        // * gruppiere nach Kaeufer id,
        // * danach sortiere absteigend mittels gruppe => gruppe.Count(),,
        // * selektiere von der Gruppe den ersten Käufer (gruppe => gruppe.First().Kaeufer) und
        // * nimm den ersten wert dieser liste (first)
        var kundeMitMeistenTickets = tickets
            .GroupBy(ticket => ticket.Kaeufer.Id)
            .OrderByDescending(gruppe => gruppe.Count())
            .Select(gruppe => gruppe.First().Kaeufer)
            .FirstOrDefault();

        var beliebtesteZugstrecke = tickets
            .Select(ticket => ticket.GekauftesVerkehrsmittel)
            .OfType<Zug>()
            .GroupBy(zug => $"{zug.StartBahnhof} -> {zug.ZielBahnhof}")
            .OrderByDescending(gruppe => gruppe.Count())
            .Select(gruppe => gruppe.Key)
            .FirstOrDefault();

        return new AnalyseDto
        {
            KundeMitDenMeistenTicketsId = kundeMitMeistenTickets?.Id,
            KundeMitDenMeistenTicketsName = kundeMitMeistenTickets?.Name,
            BeliebtesteZugstrecke = beliebtesteZugstrecke ?? "Keine Zugtickets verkauft."
        };
    }
}