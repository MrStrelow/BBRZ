using Fahrradverleih.DTOs;
using Fahrradverleih.Entities;
using Fahrradverleih.Repositories;
using Fahrradverleih.Exceptions;
using Fahrradverleih.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("Willkommen beim Fahrradverleih 'Fahrrad-Blitz'!");

var kundeRepository = new KundeRepository();
var fahrradRepository = new FahrradRepository();
var rechnungRepository = new RechnungRepository();
var reservierungRepository = new ReservierungsRepository();

var fahrradService = new FahrradService(fahrradRepository);
var kundenService = new KundenService(fahrradService, rechnungRepository, kundeRepository);
var reservierungService = new ReservierungsService(kundeRepository, fahrradRepository, reservierungRepository);
var analyticsService = new AnalyticsService(rechnungRepository, reservierungRepository);

Log.Information("--- Reservierungen werden erstellt ---");

var reservierungsWunsch1 = new ReservierungsWunschDto { KundenId = 1, FahrradId = 2, ReservierungsDatum = DateTime.Now.AddDays(2) };
var reservierungsWunsch2 = new ReservierungsWunschDto { KundenId = 1, FahrradId = 3, ReservierungsDatum = DateTime.Now.AddDays(3) };
var reservierungsWunsch3 = new ReservierungsWunschDto { KundenId = 2, FahrradId = 1, ReservierungsDatum = DateTime.Now.AddDays(2) };

await reservierungService.ErstelleReservierungAsync(reservierungsWunsch1);
await reservierungService.ErstelleReservierungAsync(reservierungsWunsch2);
await reservierungService.ErstelleReservierungAsync(reservierungsWunsch3);

Log.Information("--- Mietanfragen werden entgegengenommen ---");
// Wir stellen uns vor die DTOs werden serialisiert und über das internet zu dem service gesendet. 
// Wir arbeiten mit Ids, da wir nicht mehr momentan brauchen. Falls die Usereingabe bzw. Website mehr Infors braucht, senden wir mehr.
var anfrageKunde1 = new KundenWunschDto { KundenId = 1, Ausleihwuensche = new() { new() { FahrradId = 1 }, new() { FahrradId = 2 } } };
var anfrageKunde2 = new KundenWunschDto { KundenId = 2, Ausleihwuensche = new() { new() { FahrradId = 3 } } };
var anfrageKunde3 = new KundenWunschDto { KundenId = 3, Ausleihwuensche = new() { new() { FahrradId = 99 } } }; // falsche Anfrage
var anfrageKunde4 = new KundenWunschDto { KundenId = 99, Ausleihwuensche = new() { new() { FahrradId = 1 } } }; // falscher Kunde

var anfragen = new List<KundenWunschDto> { anfrageKunde1, anfrageKunde2, anfrageKunde3, anfrageKunde4 };
var anfrageTasks = new List<Task>();

foreach (var anfrage in anfragen)
{
    anfrageTasks.Add(BearbeiteAnfrageAsync(anfrage));
}

await Task.WhenAll(anfrageTasks);

Log.Information("Alle Anfragen wurden versucht zu verarbeiten.");
Log.Information("--- Tagesanalyse des Verleihs ---");

var analytics = await analyticsService.GetVerleihAnalyticsAsync();
Log.Information("Beliebtestes Fahrrad SEIT ERÖFFNUNG: Fahrrad Nr. {BeliebtestesFahrrad}", analytics.BeliebtestesFahrrad);
Log.Information("Kunde mit den meisten Reservierungen: Kunde Nr. {KundenId}", analytics.KundeMitDenMeistenReservierungenId);


Log.Information("Simulation beendet.");


async Task<Rechnung?> BearbeiteAnfrageAsync(KundenWunschDto anfrage)
{
    try
    {
        return await kundenService.MieteFahrradAsync(anfrage);
    }
    catch (AusleihvorgangException ex)
    {
        Log.Error(ex, "Fehler bei der Bearbeitung der Anfrage von Kunde {KundenId}.", anfrage.KundenId);
    }
    catch (InvalidOperationException ex)
    {
        Log.Error(ex, "Ungültige Operation bei der Anfrage von Kunde {KundenId}.", anfrage.KundenId);
    }
    catch (Exception ex)
    {
        Log.Fatal(ex, "Ein unerwarteter Fehler ist bei der Anfrage von Kunde {KundenId} aufgetreten.", anfrage.KundenId);
    }

    return null;
}