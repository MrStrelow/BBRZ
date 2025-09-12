using Fahrradverleih.DTOs;
using Fahrradverleih.Entities;
using Fahrradverleih.Exceptions;
using Fahrradverleih.Repositories;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fahrradverleih.Services
{
    public interface IKundenService
    {
        Task<Rechnung> MieteFahrradAsync(KundenWunschDto wunsch);
    }

    public class KundenService : IKundenService
    {
        private readonly IRechnungRepository _rechnungRepository;
        private readonly IFahrradService _fahrradService;
        private readonly IKundeRepository _kundeRepository;

        public KundenService(IFahrradService fahrradService, IRechnungRepository rechnungRepository, IKundeRepository kundeRepository)
        {
            _rechnungRepository = rechnungRepository;
            _fahrradService = fahrradService;
            _kundeRepository = kundeRepository;
        }

        public async Task<Rechnung> MieteFahrradAsync(KundenWunschDto wunsch)
        {
            var kunde = await _kundeRepository.GetByIdAsync(wunsch.KundenId)
                ?? throw new InvalidOperationException($"Kunde mit ID {wunsch.KundenId} nicht gefunden.");

            if (wunsch.Ausleihwuensche.Count > MaxFahrraederProKunde)
                throw new InvalidOperationException($"Kunde {kunde.Name} (ID: {wunsch.KundenId}) kann nicht mehr als {MaxFahrraederProKunde} Fahrräder ausleihen.");

            Log.ForContext<KundenService>().Information("Anfrage von Kunde {KundenName} (ID: {KundenId}) wird bearbeitet...", kunde.Name, wunsch.KundenId);

            try
            {
                var fahrradVorbereitungsTasks = wunsch.Ausleihwuensche.Select(aw => _fahrradService.BereitstellenAsync(aw.FahrradId));
                var bereitgestellteFahrraeder = await Task.WhenAll(fahrradVorbereitungsTasks);

                var rechnung = new Rechnung
                {
                    Kunde = kunde, // Hier wird das ganze Objekt übergeben
                    AusgelieheneFahrraeder = bereitgestellteFahrraeder.ToList(), // Und hier die Liste der Objekte
                    Gesamtbetrag = bereitgestellteFahrraeder.Sum(f => f.PreisProStunde),
                };

                await _rechnungRepository.AddAsync(rechnung);
                Log.Information("Rechnung für Kunde {KundenName} erstellt. Betrag: {Gesamtbetrag}", rechnung.Kunde.Name, rechnung.Gesamtbetrag);
                return rechnung;
            }
            catch (FahrradNichtVerfuegbarException ex)
            {
                throw new AusleihvorgangException($"Ausleihvorgang für Kunde {kunde.Name} konnte nicht abgeschlossen werden.", ex);
            }
        }

        private const int MaxFahrraederProKunde = 2;
    }
}