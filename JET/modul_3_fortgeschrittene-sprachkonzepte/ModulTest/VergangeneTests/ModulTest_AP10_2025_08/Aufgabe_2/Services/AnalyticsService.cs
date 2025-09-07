using Fahrradverleih.DTOs;
using Fahrradverleih.Repositories;
using Serilog;
using System.Linq;
using System.Threading.Tasks;

namespace Fahrradverleih.Services;

public interface IAnalyticsService
{
    Task<VerleihAnalyticsDto> GetVerleihAnalyticsAsync();
}

public class AnalyticsService : IAnalyticsService
{
    private readonly IRechnungRepository _rechnungRepository;
    private readonly IReservierungsRepository _reservierungRepository;

    public AnalyticsService(IRechnungRepository rechnungRepository, IReservierungsRepository reservierungRepository)
    {
        _rechnungRepository = rechnungRepository;
        _reservierungRepository = reservierungRepository;
    }

    public async Task<VerleihAnalyticsDto> GetVerleihAnalyticsAsync()
    {
        Log.ForContext<AnalyticsService>().Information("Starte Verleih-Analyse...");
        var rechnungen = await _rechnungRepository.GetAllAsync();
        var reservierungen = await _reservierungRepository.GetAllAsync();

        if (!rechnungen.Any())
        {
            Log.Warning("Keine Rechnungen für die Analyse gefunden.");
        }

        var beliebtestesFahrrad = rechnungen
            .SelectMany(r => r.AusgelieheneFahrraeder)
            .GroupBy(f => f.Id)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .FirstOrDefault();

        // TODO: berechne den Kunden mit den Meisten Reservierungen. 
        // Hinweis:
        // * gruppiere nach Kunden id,
        // * danach sortiere absteigend,
        // * selektiere von der gruppe den Schlüssel (g => g.Key) und
        // * nimm den ersten wert dieser liste (first)
        var kundeMitMeistenReservierungen = reservierungen
            .GroupBy(r => r.Kunde.Id) 
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .FirstOrDefault();

        var analytics = new VerleihAnalyticsDto
        {
            BeliebtestesFahrrad = beliebtestesFahrrad,
            KundeMitDenMeistenReservierungenId = kundeMitMeistenReservierungen
        };

        Log.Information("Analyse abgeschlossen.");
        return analytics;
    }
}