using System;
using System.Threading.Tasks;
using Serilog;
using Ticketverkauf.DTOs;
using Ticketverkauf.Entities;
using Ticketverkauf.Repositories;

namespace Ticketverkauf.Services
{
    public interface IZugService
    {
        Task<Ticket> KaufeZugTicketAsync(TicketKaufWunschDto wunsch);
    }

    public class ZugService : IZugService
    {
        // TODO: Erstelle die benötigten Felder und Eigenschaften.
        private readonly IKundenRepository _kundenRepository;
        private readonly IZugRepository _zugRepository;
        private readonly ITicketRepository _ticketRepository;

        // TODO: Implementiere den Konstruktor.
        public ZugService(IKundenRepository kundenRepo, IZugRepository zugRepo, ITicketRepository ticketRepo)
        {
            _kundenRepository = kundenRepo;
            _zugRepository = zugRepo;
            _ticketRepository = ticketRepo;
        }

        public async Task<Ticket> KaufeZugTicketAsync(TicketKaufWunschDto wunsch)
        {
            // TODO: Implementiere die Erstellung eines Tickets:
            // * rufe dazu _kundeRepository.GetByIdAsync, sowie _zugRepository.GetByIdAsync auf.
            if (wunsch.Typ != VerkehrsmittelTyp.Zug)
            {
                throw new ArgumentException("Dieser Service kann nur Zugtickets bearbeiten.");
            }

            var kunde = await _kundenRepository.GetByIdAsync(wunsch.KundenId)
                        ?? throw new InvalidOperationException($"Kunde mit ID {wunsch.KundenId} nicht gefunden.");

            var zug = await _zugRepository.GetByIdAsync(wunsch.VerkehrsmittelId)
                      ?? throw new InvalidOperationException($"Zug mit ID {wunsch.VerkehrsmittelId} nicht gefunden.");

            // * Erstelle ein Objekt neuesTicket, welches Kaeufer, GekauftesVerkehrsmittel und den Preis (kommt aus dem Parameter wunsch) beinhaltet.
            var neuesTicket = new Ticket
            {
                Kaeufer = kunde,
                GekauftesVerkehrsmittel = zug,
                Preis = zug.TicketPreis
            };

            Log.Information("Zugticket für Zug {ZugNummer} ({Start} -> {Ziel}) an {KundenName} für {Preis}€ verkauft.",
                zug.ZugNummer, zug.StartBahnhof, zug.ZielBahnhof, kunde.Name, zug.TicketPreis);

            // * Füge das Ticket dem _ticketRepository mit AddAsync hinzu.
            await _ticketRepository.AddAsync(neuesTicket);
            return neuesTicket;
        }
    }
}