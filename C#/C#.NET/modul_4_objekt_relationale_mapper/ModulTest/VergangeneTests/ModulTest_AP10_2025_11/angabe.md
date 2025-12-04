# Modultest 4

Sie haben `180 Minuten` Zeit die Aufgaben zu lösen
* Sie können maximal 100 Punkte erreichen
* Es sind zur Prüfung zugelassen:
    * Taschenrechner (wenn erwünscht)
    * Transparente Wasserflasche
    * Papier, Geodreieck, Stifte, usw.
    * Am Computer sind alle Unterlagen sowie die Nutzung des Internets erlaubt.

Die Nutzung des Internets umfasst nicht
* Chatbots
* Veröffentlichung der Lösungen
* sonstige Kommunikation mit anderen Usern

Die Nutzung von allen anderen Dingen, muss vorher mit mir abgesprochen werden
(z.B. Nutzung von Ohropax), ansonsten wird dies als schummeln gewertet. 
Die Folge des Schummeln ist eine Bewertung mit 0 Punkten.

* Die Abgabe des Programmcodes erfolgt über Teams (ein zip-File des Projektes mir bis spätestens 15 minuten nach Ende des Tests zu schicken)
* Viel Erfolg! :)

Notenschlüssel:
[0-50): N5; [50-62.5%): G4; [62.5-75%): B3; [75-87.5%): G2; [87.5-100%]: S1., (Schulnotensystem)

---

## Vorbereitung
* **Wie öffne ich die Vorlage?**
    1) Entpacke das [Zib-Archiv](../../../../z_leere_projekte_als_Vorlagen_fuer_pruefungen/DonwloadMe-VorlageProgVisualStudio.zip).
    2) Drücke doppelt auf die **.sln** oder **.slnx** Datei. Diese wird dadurch mit ``Visual Studio`` geöffnet. Falls nicht siehe dem README File innerhalb von [Zib-Archivs](../../../../z_leere_projekte_als_Vorlagen_fuer_pruefungen/DonwloadMe-VorlageProgVisualStudio.zip)

* **Die Verbindung zur ``Datenbank`` mit  ``EF-Core`` funktioniert nicht.**
    Es muss folgendes Installiert sein:
    1) Öffne den ``Task Manager``, gehe zu ``Dienste`` und suche nach ``SQL Server Agent (SQLExpress)``. Sollte das nicht der Fall sein, dann rufe [diesen](https://go.microsoft.com/fwlink/p/?linkid=2216019&clcid=0x409&culture=en-us&country=us) Installer auf (Falls nicht möglich suche nach SQL Server Express in Google).
    2) Installiere den SQL Server und verwende folgenden Connection String ``"Server=localhost\\SQLEXPRESS; Database=TemporaryExamDb; Trusted_Connection=True; TrustServerCertificate=True;"``
    3) Damit die folgenden Aufgaben gelöst werden können, muss eine ``Datenbank`` mit Namen *TemporaryExamDb* erstellt werden. Das ist mit dem *View->SQL-Server-Object-Explorer* in ``Visual Studio`` (oder mit dem ``SQL Server Management Studio``) möglich. Falls keine Rechte dazu besessen werden, siehe weiter unten. 
    (Es kann jeder Name verwendet werden, jedoch muss die ``Datenbank`` welche in *MyDbContext.cs* verwendet wird, am ``SQL-Server`` existieren.) 

    Falls dein User keine Rechte hat um eine ``Datenbank`` anzulegen, rufe folgende Befehle auf:
    1) Öffne nach Abschluss der Installation den ``Terminal`` und gib ``sqlcmd -S localhost\SQLEXPRESS`` ein.
    2) Gib dort 
        ```sql
        CREATE LOGIN [DOMAIN\USERNAME] FROM WINDOWS;
        GO
        ``` 
        ein
    3) Danach gib 
        ```sql
        ALTER SERVER ROLE sysadmin ADD MEMBER [DOMAIN\USERNAME];
        GO
        ```
        ein.
    4) Es soll nun möglich sein eine Datenbank anzulegen (Adminrechte) und sich mit dem oben agegebene Connection string ohne passwort zu verbinden.

---

## Aufgabe 1 - Data Definition Language (DDL) mit EF-Core Model First umsetzen [50 / 100 Punkte]

Folgendes [``UML-Diagramm``](AirportClassDia.png) ist für die **alle** folgenden Aufgaben heranzuziehen.
![alt text](AirportClassDia.png)


### Programmverständnis [15 / 50 Teilpunkte]
Folgende ``Models`` versuchen das [UML-Diagramm](AirportClassDia.png) zu implementieren. Dabei haben sich Fehler eingeschlichen. Finde und behebe diese. Erkläre warum es ein Fehler oder ein konzeptionell falscher Ansatz ist.

```csharp
public class Airport
{
    public int MeinSuperSchlüssel { get; set; }
    public string Kennung { get; }
    public string Land { get; }
    public string Ort { get; }
    private IEnumerable<Terminal> Terminals = new List<Terminal>();
}
```

```csharp
public class Flight
{
    public int Id { get; set; }
    public Gate GateCloses { get; set; }
    public Gate GateOpens { get; set; }
    public string Kennung { get; set; }
    public string TakesOff { get; set; }
    public Ticket Tickets { get; set; }
}
```
---

### Programmieren [25 / 50 Teilpunkte]

Implementiere das gegebene [``UML-Diagramm``](AirportClassDia.png) innerhalb eines Ordners ``Models``.
1) Erstelle die ``Klassen`` und implementiere die ``Beziehungen`` als ``Eigenschaften``. Implementiere auch ``Eigenschaften`` wie z.B. ``Primärschlüssel`` und ``Fremdschlüssel``, wenn diese im [``UML-Diagramm``](AirportClassDia.png) angegeben sind.
2) Erstelle einen ``Migrations`` Ordner mithilfe der ensprechenden ``Commandozeilenbefehle`` von ``Ef-Core``.
3) Führe den ``Code`` innerhlab der ```Migrations`` mithilfe der ensprechenden ``Commandozeilenbefehle`` von ``Ef-Core`` aus. Ziel ist es ``Tabellen`` in der ``Datenbank`` anzulegen, welche über die ``Models`` definiert werden (``Model-First``). 
4) Befülle die Datenbank mit ``Dummy-Daten``. Diese sind in der **bereits** ``Klasse`` *SeedData* **implementiert** und muss nur in der ``Main-Methode``bzw. im ``Top-Level Statement`` aufgerufen werden. Führe diese aus und stelle sicher dass diese in der Datenbank vorhanden sind. Erstelle einen **``Screenshot``** welcher die Daten in der ``Datenbank`` darstellt.
5) Ändere nun die ``Klasse`` *Passenger*. Dort ist nun eine zusätzliche ``Eigenschaft`` *PassPhoto* einfachheitshalber vom ``Typ`` *Byte* vorhanden. Übernimm die Änderungen zuerst in dem ``Migrations`` und danach in die ``Datenbank`` mithilfe der ensprechenden ``Commandozeilenbefehle`` von ``Ef-Core``. **Führe das Programm nicht neu aus! Sind die bereits eingefügten Daten in der ``Datenbank`` noch vorhanden?**

---

### Theorie [10 / 50 Teilpunkte]
1) Was sind ``shadow properties`` vs. ``real properties``? Erkläre anhand eines ``Fremdschlüssels``. 
2) Was erleichtert uns ``Ef-core`` im Vergleich zu ``ado.net``?
4) Es existieren *fünf* ``Migrations``. Die letzte ``Migration`` wurde unabsichtlich erstellt. Wie entfernen wir diese?
5) Es soll die Datenbank auf eine ältere ``Migration`` umgestellt werden. Wie führen wir das durch?
6) Was macht die ``up`` und ``down`` ``Methode`` in den den generierten Files in den ``Migrations``?

---

## Aufgabe 2 - Async Data Manipulation Language (DML) mit EF Core umsetzen [50 Punkte]

### Programmverständnis [10 / 50 Teilpunkte]
Folgende ``Models`` versuchen basierend auf [UML-Diagramm](AirportClassDia.png) Abfragen durchzuführen. Dabei haben sich Fehler eingeschlichen. Finde und behebe diese. Erkläre warum es ein Fehler oder ein konzeptionell falscher Ansatz ist.

1)  ```csharp
    var passenger = await _context.Passenger.Find(1);
    var anotherPassenger = _context.Passenger.FindAsync(1);
    ```

2) ```csharp
    var passenger = new Passenger(...); // wird id = 15 haben
    _context.Passenger.Add(passenger); 

    var passengerAusDbGeholt = await _context.Passenger.Find(15);
    ``` 
    
3) ```csharp
    var passenger = await _context.Passengers
        .Where(p => p.Name == "Müller")
        .ThenInclude(p => p.Tickets) 
        .FirstOrDefaultAsync();
    ``` 

---

### Programmieren [30 / 50 Teilpunkte]
Diese Aufgabe soll in Projekt [Aufgabe 1](#programmieren-25--50-teilpunkte) umgesetzt werden, nicht in Projekt [Aufgabe 2](#programmieren-30--50-teilpunkte)

Erstelle folgende Abfragen im ``Service`` *AnalyticsService*. Die ``Methoden`` sind bereits vordefiniert. Implementiert müssen sie noch werden. Die Abfragen sollen ``asynchron`` umgesetzt werden.
1) Gib alle *Airplanes* in der ``Datenbank`` aus. 
2) Welche *Tickets* haben zumidnest den *Preis* von *50€*?
3) Welche *Flights* haben *DepartureCity == "Vienna"*? Im Ergebnis soll nur die *Flightnumber* und der *DestinationCity* vorhanden sein.
4) Welche *Flights* haben *DepartureCity == "Vienna"* und zumindest 3 Tickets gekauft? Im Ergebnis soll nur die *Flightnumber* und der *DestinationCity* vorhanden sein.
5) Welche drei *Passengers* pro *Airline* haben den meisten *Umsatz* erzeugt? *Hinweis: Suche eine Kette an Verbindungen im Diagramm welche Airline und Passenger verbindet .Verwende ein SubSelect - Innerhalb des Selects eine neue Ef-Core Abfrage mit _context - um es nach Airliens zu gruppieren.*
6) Flache Joins mit Flights, Pilot, CoPilot und Gate:
7) Tiefe Joins Flights:
    * Airplane, Airline und 
    * FlyFrom und Terminals

#### Erwarteter Output:
```bash
--- 1) Alle Airplanes ---
FlightId: 1, Airline... oh da steht ja nix:
FlightId: 2, Airline... oh da steht ja nix:
FlightId: 3, Airline... oh da steht ja nix:
FlightId: 4, Airline... oh da steht ja nix:
FlightId: 5, Airline... oh da steht ja nix:
FlightId: 6, Airline... oh da steht ja nix:
FlightId: 7, Airline... oh da steht ja nix:
FlightId: 8, Airline... oh da steht ja nix:
FlightId: 9, Airline... oh da steht ja nix:
FlightId: 10, Airline... oh da steht ja nix:

--- 2) Tickets >= 50? ---
TicketId: 1, Preis: 120.00
TicketId: 2, Preis: 130.00
TicketId: 3, Preis: 110.00
TicketId: 4, Preis: 150.00
TicketId: 5, Preis: 125.00
TicketId: 6, Preis: 500.00
TicketId: 7, Preis: 550.00
TicketId: 8, Preis: 520.00
TicketId: 9, Preis: 480.00
TicketId: 10, Preis: 600.00
TicketId: 16, Preis: 800.00
TicketId: 17, Preis: 850.00
TicketId: 18, Preis: 780.00
TicketId: 19, Preis: 820.00
TicketId: 20, Preis: 900.00
TicketId: 21, Preis: 200.00
TicketId: 22, Preis: 210.00
TicketId: 23, Preis: 190.00
TicketId: 24, Preis: 220.00
TicketId: 25, Preis: 205.00
TicketId: 26, Preis: 180.00
TicketId: 27, Preis: 185.00
TicketId: 28, Preis: 175.00
TicketId: 29, Preis: 190.00
TicketId: 30, Preis: 160.00
TicketId: 31, Preis: 300.00
TicketId: 32, Preis: 310.00
TicketId: 33, Preis: 320.00
TicketId: 34, Preis: 290.00
TicketId: 35, Preis: 330.00
TicketId: 36, Preis: 700.00
TicketId: 37, Preis: 720.00
TicketId: 38, Preis: 680.00
TicketId: 39, Preis: 750.00
TicketId: 40, Preis: 710.00
TicketId: 41, Preis: 950.00
TicketId: 42, Preis: 980.00
TicketId: 43, Preis: 920.00
TicketId: 44, Preis: 960.00
TicketId: 45, Preis: 990.00
TicketId: 46, Preis: 100.00
TicketId: 47, Preis: 110.00
TicketId: 48, Preis: 95.00
TicketId: 49, Preis: 105.00
TicketId: 50, Preis: 90.00
TicketId: 51, Preis: 100.00
TicketId: 52, Preis: 110.00
TicketId: 53, Preis: 95.00
TicketId: 54, Preis: 105.00
TicketId: 55, Preis: 90.00

--- 3) Flights ab Vienna (Tuple) ---

--- 4) Beliebte Flights ab Vienna (>= 3 Tickets) ---

--- 5) Top 3 Passengers pro Airline ---
Airline: Lufthansa
 - Jane Doe: 150.00?
 - Erika Musterfrau: 130.00?
 - Mario Rossi: 125.00?
Airline: Emirates
 - Isaac Newton: 600.00?
 - Jean Dupont: 550.00?
 - Marie Curie: 520.00?
Airline: Ryanair
 - Jean Dupont: 50.00?
 - Mario Rossi: 45.00?
 - Max Mustermann: 40.00?
Airline: Delta Airlines
 - Isaac Newton: 900.00?
 - Jane Doe: 850.00?
 - Marie Curie: 820.00?
Airline: British Airways
 - Max Mustermann: 390.00?
 - Jane Doe: 220.00?
 - Erika Musterfrau: 210.00?
Airline: Air France
 - Albert Einstein: 190.00?
 - Jean Dupont: 185.00?
 - Luigi Verdi: 180.00?
Airline: KLM
 - Mario Rossi: 330.00?
 - Max Mustermann: 320.00?
 - Jane Doe: 310.00?
Airline: Qatar Airways
 - Marie Curie: 750.00?
 - Isaac Newton: 720.00?
 - Albert Einstein: 710.00?
Airline: Singapore Airlines
 - John Doe: 990.00?
 - Isaac Newton: 980.00?
 - Albert Einstein: 960.00?
Airline: Austrian Airlines
 - Erika Musterfrau: 110.00?
 - Jean Dupont: 110.00?
 - Jane Doe: 105.00?

--- Zusatz: Flüge mit Pilot & Gate ---
10 Flüge mit Details geladen.
Id:1
 - Airplane: *Id:Markus Söder
 - Airline: *NameAngela Merkel
 Origin: *
 Temrinal: *Aufgabe_1.Models.Airplane
Id:2
 - Airplane: *Id:Olaf Scholz
 - Airline: *NameFriedrich Merz
 Origin: *
 Temrinal: *Aufgabe_1.Models.Airplane
Id:3
 - Airplane: *Id:Robert Habeck
 - Airline: *NameAnnalena Baerbock
 Origin: *
 Temrinal: *Aufgabe_1.Models.Airplane
Id:4
 - Airplane: *Id:Christian Lindner
 - Airline: *NameUrsula von der Leyen
 Origin: *
 Temrinal: *Aufgabe_1.Models.Airplane
Id:5
 - Airplane: *Id:Boris Johnson
 - Airline: *NameEmmanuel Macron
 Origin: *
 Temrinal: *Aufgabe_1.Models.Airplane
Id:6
 - Airplane: *Id:Markus Söder
 - Airline: *NameOlaf Scholz
 Origin: *
 Temrinal: *Aufgabe_1.Models.Airplane
Id:7
 - Airplane: *Id:Angela Merkel
 - Airline: *NameFriedrich Merz
 Origin: *
 Temrinal: *Aufgabe_1.Models.Airplane
Id:8
 - Airplane: *Id:Robert Habeck
 - Airline: *NameChristian Lindner
 Origin: *
 Temrinal: *Aufgabe_1.Models.Airplane
Id:9
 - Airplane: *Id:Annalena Baerbock
 - Airline: *NameUrsula von der Leyen
 Origin: *
 Temrinal: *Aufgabe_1.Models.Airplane
Id:10
 - Airplane: *Id:Boris Johnson
 - Airline: *NameMarkus Söder
 Origin: *
 Temrinal: *Aufgabe_1.Models.Airplane

--- Zusatz: Flüge mit Pilot & Gate ---
10 Flüge mit Details geladen.
Id:1
 - Airplane: *Id:1
 - Airline: *NameLufthansa
 Origin: *Aufgabe_1.Models.Airport
 Temrinal: *System.Collections.Generic.List`1[Aufgabe_1.Models.Terminal]
Id:2
 - Airplane: *Id:2
 - Airline: *NameEmirates
 Origin: *Aufgabe_1.Models.Airport
 Temrinal: *System.Collections.Generic.List`1[Aufgabe_1.Models.Terminal]
Id:3
 - Airplane: *Id:3
 - Airline: *NameRyanair
 Origin: *Aufgabe_1.Models.Airport
 Temrinal: *System.Collections.Generic.List`1[Aufgabe_1.Models.Terminal]
Id:4
 - Airplane: *Id:4
 - Airline: *NameDelta Airlines
 Origin: *Aufgabe_1.Models.Airport
 Temrinal: *System.Collections.Generic.List`1[Aufgabe_1.Models.Terminal]
Id:5
 - Airplane: *Id:5
 - Airline: *NameBritish Airways
 Origin: *Aufgabe_1.Models.Airport
 Temrinal: *System.Collections.Generic.List`1[Aufgabe_1.Models.Terminal]
Id:6
 - Airplane: *Id:6
 - Airline: *NameAir France
 Origin: *Aufgabe_1.Models.Airport
 Temrinal: *System.Collections.Generic.List`1[Aufgabe_1.Models.Terminal]
Id:7
 - Airplane: *Id:7
 - Airline: *NameKLM
 Origin: *Aufgabe_1.Models.Airport
 Temrinal: *System.Collections.Generic.List`1[Aufgabe_1.Models.Terminal]
Id:8
 - Airplane: *Id:8
 - Airline: *NameQatar Airways
 Origin: *Aufgabe_1.Models.Airport
 Temrinal: *System.Collections.Generic.List`1[Aufgabe_1.Models.Terminal]
Id:9
 - Airplane: *Id:9
 - Airline: *NameSingapore Airlines
 Origin: *Aufgabe_1.Models.Airport
 Temrinal: *System.Collections.Generic.List`1[Aufgabe_1.Models.Terminal]
Id:10
 - Airplane: *Id:10
 - Airline: *NameAustrian Airlines
 Origin: *Aufgabe_1.Models.Airport
 Temrinal: *System.Collections.Generic.List`1[Aufgabe_1.Models.Terminal]
```

---

### Theorie [10 / 50 Teilpunkte]
1) Ist das ``Keyword`` *Select* in ``LINQ`` und ``SQL`` beides als erstes in einem ``Select-Statement``?
2) Wird ThenInclude verwendet, um direkte Relationen der Hauptentität zu laden, oder um Relationen von bereits durch Include geladenen Entitäten zu laden? // TODO
3) Muss bei der Verwendung von asynchronen Methoden (wie ToListAsync) auf einem DbSet der Rückgabetyp der Methode zwingend ein Task (bzw. Task<T>) sein? // TODO