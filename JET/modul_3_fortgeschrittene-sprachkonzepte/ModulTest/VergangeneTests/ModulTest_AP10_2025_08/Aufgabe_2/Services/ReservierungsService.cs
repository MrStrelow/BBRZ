using Fahrradverleih.DTOs;
using Fahrradverleih.Entities;
using Fahrradverleih.Exceptions;
using Fahrradverleih.Repositories;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Fahrradverleih.Services;

public interface IReservierungService
{
    Task<Reservierung> ErstelleReservierungAsync(ReservierungsWunschDto wunsch);
}

public class ReservierungService : IReservierungService
{
    private readonly IKundeRepository _kundeRepository;
    private readonly IFahrradRepository _fahrradRepository;
    private readonly IReservierungsRepository _reservierungRepository;

    public ReservierungService(IKundeRepository kundeRepository, IFahrradRepository fahrradRepository, IReservierungsRepository reservierungRepository)
    {
        _kundeRepository = kundeRepository;
        _fahrradRepository = fahrradRepository;
        _reservierungRepository = reservierungRepository;
    }

    public async Task<Reservierung> ErstelleReservierungAsync(ReservierungsWunschDto wunsch)
    {
        var kunde = await _kundeRepository.GetByIdAsync(wunsch.KundenId)
            ?? throw new InvalidOperationException($"Kunde mit ID {wunsch.KundenId} nicht gefunden.");

        var fahrrad = await _fahrradRepository.GetByIdAsync(wunsch.FahrradId)
            ?? throw new FahrradNichtVerfuegbarException($"Fahrrad mit ID {wunsch.FahrradId} konnte nicht gefunden werden.");

        Log.Information("Erstelle Reservierung für Kunde {KundenName} für Fahrrad {FahrradModell} am {ReservierungsDatum}",
            kunde.Name, fahrrad.Modell, wunsch.ReservierungsDatum);

        var reservierung = new Reservierung
        {
            Kunde = kunde, // Ganzes Objekt
            Fahrrad = fahrrad, // Ganzes Objekt
            ReservierungsDatum = wunsch.ReservierungsDatum
        };

        await _reservierungRepository.AddAsync(reservierung);
        Log.Information("Reservierung erfolgreich erstellt.");
        return reservierung;
    }
}