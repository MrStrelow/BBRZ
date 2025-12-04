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
    1) Entpacke das [Zib-Archiv](../../../z_leere_projekte_als_Vorlagen_fuer_pruefungen/DonwloadMe-VorlageProgVisualStudio.zip).
    2) Drücke doppelt auf die **.sln** oder **.slnx** Datei. Diese wird dadurch mit ``Visual Studio`` geöffnet. Falls nicht siehe dem README File innerhalb von [Zib-Archivs](../../../z_leere_projekte_als_Vorlagen_fuer_pruefungen/DonwloadMe-VorlageProgVisualStudio.zip)

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

1) 
```csharp
public class Passenger
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PassportNumber { get; set; } = string.Empty; 
    public string Email { get; set; } = string.Empty;          
    public IEnumerable<string> Bookings { get; set; } = new List<string>();
}
```

2) 
```csharp
public class BoardingPass
{
    public int Id { get; set; }
    public string SeatNumber { get; set; } = string.Empty; 
    public int BoardingGroup { get; set; } 
    public DateTime IssuedAt { get; set; }
    public Gate? Gate{ get; set; }
    public Booking? Booking { get; set; } // Hinweis: Wir haben eine bidirektionale Beziehung (von Boardingpass zu Booking und Booking zu Boardingpass). Ist hier klar ob Boardingpass oder Booking als Fremdschlüssel dient? 
}
```
---

### Programmieren [25 / 50 Teilpunkte]

Implementiere das gegebene [``UML-Diagramm``](AirportClassDia.png) innerhalb eines Ordners ``Models``.
1) Erstelle die ``Klassen`` und implementiere die ``Beziehungen`` als ``Eigenschaften``. Implementiere auch ``Eigenschaften`` wie z.B. ``Primärschlüssel`` und ``Fremdschlüssel``, wenn diese im [``UML-Diagramm``](AirportClassDia.png) angegeben sind.
2) Erstelle einen ``Migrations`` Ordner mithilfe der ensprechenden ``Commandozeilenbefehle`` von ``Ef-Core``.
3) Führe den ``Code`` innerhlab der ```Migrations`` mithilfe der ensprechenden ``Commandozeilenbefehle`` von ``Ef-Core`` aus. Ziel ist es ``Tabellen`` in der ``Datenbank`` anzulegen, welche über die ``Models`` definiert werden (``Model-First``). 
4) Befülle die Datenbank mit ``Dummy-Daten``. Diese sind in der **bereits** ``Klasse`` *SeedData* **implementiert** und muss nur in der ``Main-Methode``bzw. im ``Top-Level Statement`` aufgerufen werden. Führe diese aus und stelle sicher dass diese in der Datenbank vorhanden sind. Erstelle einen **``Screenshot``** welcher die Daten in der ``Datenbank`` darstellt.

Sammlung nützlicher ``Ef-Core``/Terminal Befehle in der ``DeveloperPowerShell``:
*   ```bash
    cd .\Aufgabe_1\
    ```
*   ```bash
    dotnet build
    ```
*   ```bash
    dotnet ef migrations add <hier mein Name der Migration>
    ```
*   ```bash
    dotnet ef database update 
    ```
*   ```bash
    dotnet ef migrations remove
    ```
*   ```bash
    dotnet ef database update <hier mein Name der Migration>
    ```
*   ```bash
    dotnet ef database update 0
    ```

---

### Theorie [10 / 50 Teilpunkte]
1) Was sind ``shadow properties`` vs. ``real properties``? Erkläre anhand eines ``Fremdschlüssels``. 
2) Es existieren *fünf* ``Migrations``. Die letzte ``Migration`` wurde unabsichtlich erstellt. Wie entfernen wir diese?
3) Was macht die ``up`` und ``down`` ``Methode`` in den den generierten Files in den ``Migrations``?

---

## Aufgabe 2 - Async Data Manipulation Language (DML) mit EF Core umsetzen [50 Punkte]

### Programmverständnis [10 / 50 Teilpunkte]
Folgende ``Models`` versuchen basierend auf [UML-Diagramm](AirportClassDia.png) Abfragen durchzuführen. Dabei haben sich Fehler eingeschlichen. Finde und behebe diese. Erkläre warum es ein Fehler oder ein konzeptionell falscher Ansatz ist.

1)  ```csharp
    var passenger = await _context.Bookings.Find(1);
    var anotherPassenger = _context.Bookings.FindAsync(1);
    ```

2) ```csharp
    var pass = new BoardingPass { SeatNumber = "12A", GateId = 5 }; // wird id = 15 haben
    _context.Passenger.Add(pass); 

    var passengerAusDbGeholt = await _context.BoardingPasses.Find(15);
    ``` 
    
3) ```csharp
    var confirmedBookings = await _context.Bookings
        .Where(b => b.Status == BookingStatus.Confirmed)
        .ThenInclude(b => b.LuggageItems) 
        .ToListAsync();
    ``` 

---

### Programmieren [35 / 50 Teilpunkte]
Diese Aufgabe soll in Projekt [Aufgabe 1](#programmieren-25--50-teilpunkte) umgesetzt werden, nicht in Projekt [Aufgabe 2](#programmieren-30--50-teilpunkte)

Erstelle folgende Abfragen im ``Service`` *AnalyticsService*. Die ``Methoden`` sind bereits vordefiniert. Implementiert müssen sie noch werden. Die Abfragen sollen ``asynchron`` umgesetzt werden.
1) Hole alle *Bookings* aus der ``Datenbank``.
1) Hole alle *Bookings* aus der ``Datenbank`` mit einem ``Join`` zu *Passenger*.
2) Berechne *Bookings* welche eine spezifische *fligntNumber* haben und sortiere das Ergebnis nach *BoardingGroup*.
3) Berechne wie viele *Passenger* "Cleared", "Denied" oder "AdditionalScreening" in einem *SecurityCheck* hatten. Starte bei *SecurityCheck* und verwende ein ``GroupBy``, danach ein ``Select`` mit *g.Key.ToString()* und *g.Count()*.

#### Erwarteter Output:
```bash
=== FLUGHAFEN ANALYTICS START ===

--- 1. Hole alle Bookings ---
5 Buchungen gefunden.
 - Ref: XF39A, Preis: 150.00?, Kunde: Ohje... nicht geladen... warum?
 - Ref: AB12C, Preis: 120.00?, Kunde: Ohje... nicht geladen... warum?
 - Ref: LOST1, Preis: 200.00?, Kunde: Ohje... nicht geladen... warum?
 - Ref: LATE1, Preis: 300.00?, Kunde: Ohje... nicht geladen... warum?
 - Ref: USA01, Preis: 850.00?, Kunde: Ohje... nicht geladen... warum?
 
--- 2. Hole alle Bookings mit Passengers ---
5 Buchungen gefunden.
 - Ref: XF39A, Preis: 150.00?, Kunde: Mustermann
 - Ref: AB12C, Preis: 120.00?, Kunde: Musterfrau
 - Ref: LOST1, Preis: 200.00?, Kunde: Lost
 - Ref: LATE1, Preis: 300.00?, Kunde: NoShow
 - Ref: USA01, Preis: 850.00?, Kunde: Doe

--- 3. Manifest für LH123 (Sortiert nach BoardingGroup) ---
Gruppe 1 | Sitz 12A | Name: Mustermann
Gruppe 2 | Sitz 12B | Name: Musterfrau
Gruppe 3 | Sitz 14C | Name: Lost

--- 4. Security Check Statistik (GroupBy) ---
Status: AdditionalScreeningRequired     | Anzahl: 1
Status: Cleared         | Anzahl: 3

=== ENDE ===
```



---

### Theorie [5 / 50 Teilpunkte]
1) Ist das ``Keyword`` *Select* in ``LINQ`` und ``SQL`` beides als erstes in einem ``Select-Statement``?
2) Kann *ThenInclude* bei einem ``Join`` ohne *Inlcude* verwendet werden?