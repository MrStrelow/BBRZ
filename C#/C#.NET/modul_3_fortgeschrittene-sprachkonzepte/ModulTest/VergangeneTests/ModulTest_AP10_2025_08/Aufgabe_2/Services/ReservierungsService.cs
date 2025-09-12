using Fahrradverleih.DTOs;
using Fahrradverleih.Entities;
using Fahrradverleih.Exceptions;
using Fahrradverleih.Repositories;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Fahrradverleih.Services
{
    public interface IReservierungsService
    {
        Task<Reservierung> ErstelleReservierungAsync(ReservierungsWunschDto wunsch);
    }

    public class ReservierungsService : IReservierungsService
    {
        // TODO: Erstelle die benötigten Felder und Eigenschaften.
        private readonly IKundeRepository _kundeRepository;
        private readonly IFahrradRepository _fahrradRepository;
        private readonly IReservierungsRepository _reservierungRepository;

        // TODO: Implementiere den Konstruktor.
        public ReservierungsService(IKundeRepository kundeRepository, IFahrradRepository fahrradRepository, IReservierungsRepository reservierungRepository)
        {
            _kundeRepository = kundeRepository;
            _fahrradRepository = fahrradRepository;
            _reservierungRepository = reservierungRepository;
        }

        public async Task<Reservierung> ErstelleReservierungAsync(ReservierungsWunschDto wunsch)
        {
            // TODO: Implementiere die Erstellung einer Reservierung:
            // * rufe dazu _kundeRepository.GetByIdAsync, sowie _fahrradRepository.GetByIdAsync auf.
            var kunde = await _kundeRepository.GetByIdAsync(wunsch.KundenId)
                ?? throw new InvalidOperationException($"Kunde mit ID {wunsch.KundenId} nicht gefunden.");

            var fahrrad = await _fahrradRepository.GetByIdAsync(wunsch.FahrradId)
                ?? throw new FahrradNichtVerfuegbarException($"Fahrrad mit ID {wunsch.FahrradId} konnte nicht gefunden werden.");

            Log.Information("Erstelle Reservierung für Kunde {KundenName} für Fahrrad {FahrradModell} am {ReservierungsDatum}",
                kunde.Name, fahrrad.Modell, wunsch.ReservierungsDatum);

            // * Erstelle ein Objekt reservierung, welches Kunde, Fahrrad und das ReservierungsDatum (kommt aus dem Parameter wunsch)
            var reservierung = new Reservierung
            {
                Kunde = kunde, 
                Fahrrad = fahrrad, 
                ReservierungsDatum = wunsch.ReservierungsDatum
            };

            // * Füge diese Reservierung dem _reservierungRepository mit AddAsync hinzu.
            await _reservierungRepository.AddAsync(reservierung);
            Log.Information("Reservierung erfolgreich erstellt.");
            return reservierung;
        }
    }
}