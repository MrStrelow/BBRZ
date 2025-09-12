using System;
using System.Threading.Tasks;
using Serilog;
using Ticketverkauf.DTOs;
using Ticketverkauf.Entities;
using Ticketverkauf.Repositories;

namespace Ticketverkauf.Services;

public interface IBusService
{
    Task<Ticket> KaufeBusTicketAsync(TicketKaufWunschDto wunsch);
}

public class BusService : IBusService
{
    private readonly IKundenRepository _kundenRepository;
    private readonly IBusRepository _busRepository;
    private readonly ITicketRepository _ticketRepository;

    public BusService(IKundenRepository kundenRepo, IBusRepository busRepo, ITicketRepository ticketRepo)
    {
        _kundenRepository = kundenRepo;
        _busRepository = busRepo;
        _ticketRepository = ticketRepo;
    }

    public async Task<Ticket> KaufeBusTicketAsync(TicketKaufWunschDto wunsch)
    {
        if (wunsch.Typ != VerkehrsmittelTyp.Bus)
        {
            throw new ArgumentException("Dieser Service kann nur Bustickets bearbeiten.");
        }

        var kunde = await _kundenRepository.GetByIdAsync(wunsch.KundenId)
                    ?? throw new InvalidOperationException($"Kunde mit ID {wunsch.KundenId} nicht gefunden.");

        var bus = await _busRepository.GetByIdAsync(wunsch.VerkehrsmittelId)
                  ?? throw new InvalidOperationException($"Bus mit ID {wunsch.VerkehrsmittelId} nicht gefunden.");

        var neuesTicket = new Ticket
        {
            Kaeufer = kunde,
            GekauftesVerkehrsmittel = bus,
            Preis = bus.TicketPreis
        };

        Log.Information("Busticket für Linie {BusLinie} an {KundenName} für {Preis}€ verkauft.",
            bus.Linie, kunde.Name, bus.TicketPreis);

        await _ticketRepository.AddAsync(neuesTicket);
        return neuesTicket;
    }
}