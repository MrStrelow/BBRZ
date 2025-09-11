using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Serilog;
using Ticketverkauf.DTOs;
using Ticketverkauf.Entities;
using Ticketverkauf.Repositories;
using Ticketverkauf.Services;

// Serilog Konfiguration
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("--- Ticketverkaufs-System startet ---");

// Repositories
var kundenRepo = new KundenRepository();
var busRepo = new BusRepository();
var zugRepo = new ZugRepository();
var ticketRepo = new TicketRepository();

// Stammdaten
await kundenRepo.SaveAllAsync(new List<Kunde>
{
    new() { Id = 1, Name = "Anna Schmidt" },
    new() { Id = 2, Name = "Ben Meier" },
    new() { Id = 3, Name = "Clara Huber" }
});
await busRepo.SaveAllAsync(new List<Bus>
{
    new() { Id = 101, Linie = "48A", TicketPreis = 2.40m },
    new() { Id = 102, Linie = "13A", TicketPreis = 2.40m }
});
await zugRepo.SaveAllAsync(new List<Zug>
{
    new() { Id = 201, ZugNummer = "RJX 765", StartBahnhof = "Wien Hbf", ZielBahnhof = "Salzburg Hbf", TicketPreis = 59.90m },
    new() { Id = 202, ZugNummer = "ICE 28", StartBahnhof = "Wien Hbf", ZielBahnhof = "München Hbf", TicketPreis = 89.90m }
});

// Services instanziieren
var busService = new BusService(kundenRepo, busRepo, ticketRepo);
var zugService = new ZugService(kundenRepo, zugRepo, ticketRepo);
var ticketService = new TicketService(busService, zugService);

var analyseService = new AnalyseService(ticketRepo);

Log.Information("--- Ticketverkäufe werden simuliert ---");

// Alle Aufrufe erfolgen nun einheitlich über den TicketService
await ticketService.KaufeTicketAsync(new TicketKaufWunschDto { KundenId = 1, VerkehrsmittelId = 101, Typ = VerkehrsmittelTyp.Bus });
await ticketService.KaufeTicketAsync(new TicketKaufWunschDto { KundenId = 2, VerkehrsmittelId = 102, Typ = VerkehrsmittelTyp.Bus });
await ticketService.KaufeTicketAsync(new TicketKaufWunschDto { KundenId = 1, VerkehrsmittelId = 102, Typ = VerkehrsmittelTyp.Bus });
await ticketService.KaufeTicketAsync(new TicketKaufWunschDto { KundenId = 3, VerkehrsmittelId = 201, Typ = VerkehrsmittelTyp.Zug });
await ticketService.KaufeTicketAsync(new TicketKaufWunschDto { KundenId = 1, VerkehrsmittelId = 201, Typ = VerkehrsmittelTyp.Zug });
await ticketService.KaufeTicketAsync(new TicketKaufWunschDto { KundenId = 1, VerkehrsmittelId = 202, Typ = VerkehrsmittelTyp.Zug });


Log.Information("--- Analyse wird durchgeführt ---");
var analyseErgebnis = await analyseService.FindeKundenUndBeliebtesteStreckenAsync();

if (analyseErgebnis.KundeMitDenMeistenTicketsId.HasValue)
{
    Log.Information("Kunde mit den meisten Tickets: {KundenName} (ID: {KundenId})",
        analyseErgebnis.KundeMitDenMeistenTicketsName, analyseErgebnis.KundeMitDenMeistenTicketsId);
}
else
{
    Log.Information("Es konnte kein Kunde mit den meisten Tickets ermittelt werden.");
}

Log.Information("Beliebteste Zugstrecke: {Strecke}", analyseErgebnis.BeliebtesteZugstrecke);

Log.Information("--- System wird beendet ---");