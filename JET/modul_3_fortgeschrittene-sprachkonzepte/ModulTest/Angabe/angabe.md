# Modultest 3 - JET

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

* Die Abgabe des Programmcodes erfolgt über Teams (ein zip-File des Projektes mir bis spätestens 15 nach dem Ende der Prüfung schicken)
* Viel Erfolg! :)

Notenschlüssel:
[0-50): N5; [50-62.5%): G4; [62.5-75%): B3; [75-87.5%): G2; [87.5-100%]: S1., (Schulnotensystem)

---

## Aufgabe 1: LINQ und Func, Action - Delegates, Lambda [45 / 100 Punkte]

### Programmverständnis [10 / 45 Teilpunkte]
Gegeben ist folgender Code welcher ``LINQ`` Ausdrücke verwendet. 

```csharp
var sensoren = new List<Sensor>
{
    new Sensor(Ort: "Wien", InBetriebSeit: 18, NächsteWartung: 1, AktuelleMessung: 26),
    new Sensor(Ort: "Innsbruck", InBetriebSeit: 19, InBetriebSeit: 2, AktuelleMessung: 29),
    new Sensor(Ort: "Graz", InBetriebSeit: 20, InBetriebSeit: 3, AktuelleMessung: 32),
    new Sensor(Ort: "Innsbruck", InBetriebSeit: 21, InBetriebSeit: 4, AktuelleMessung: -125124),
    new Sensor(Ort: "Wien", InBetriebSeit: 22, InBetriebSeit: 5, AktuelleMessung: -8744156),
    new Sensor(Ort: "Wien", InBetriebSeit: 23, InBetriebSeit: 6, AktuelleMessung: 25)
};

// 1) Berechne höchste AktulleMessung aus Wien
var sensorInWien = sensoren.Select(sensor => sensor.Ort == "Wien" && sensor.AktuelleMessung >= -50).Max(sensor => sensor.AktuelleMessung);

// 2) Sensoren aufsteigend sortiert, jedoch nur Ort und AktuelleMessung wird angezeigt
Sensor messungMitOrt = sensoren.OrderBy(s => s.InBetriebSeit).Select(s => new { s.Ort, s.AktuelleMessung });

// 3) Durchschnittliche aktuelle Messung der Temperatur pro Ort
var durchschnittProOrt = sensoren
    .Where(s => s.AktuelleMessung > -50)
    .GroupBy(s => s.Ort)
    .Select(gruppe =>
        new
        {
            Ort = gruppe.Key,
            DurchschnittlicheMessung = gruppe.Average(sensor => sensor.AktuelleMessung)
        }
    );

Console.WriteLine("Durchschnittliche aktuelle Messung der Temperatur pro Ort:");
foreach (var ergebnis in durchschnittProOrt)
{
    Console.WriteLine($"- {ergebnis.Ort}: {Math.Round(ergebnis.DurchschnittlicheMessung, 2)}");
}

public record Sensor(string Ort, int InBetriebSeit, int NächsteWartung, int AktuelleMessung);
```

Sind folgende ``LINQ`` Ausdrücke korrekt oder falsch? Falls diese korrekt sind, schreibe dies dazu, falls diese falsch sind:
* Finde die Fehler in diesem Code und markiere diese. 
* Erkläre wieso diese Fehler zu einem nicht gültigen bzw. konzeptionell falschen ``LINQ``Ausdruck führen.

### Theorie [10 / 45 Teilpunkte]
1) Eine ``Methode`` mit ``Rückgabe`` besitzt eine ``Methodensignatur``. Diese beinhaltet:
    * einen ``Rückgabewert``/``Rückgabetyp``
    * den *Namen* der ``Methode`` und
    * einen oder mehrere ``Parameter``.

Ein Beispiel dafür ist ``double BerechneKuerzesteDistanz(Graph g)``

Was besitzt ein ``Lambda`` Ausdruck nicht, was eine ``Methode`` haben muss? 

2) Ein ``Objekt`` hat als ``Typ`` eine ``Klasse``. Durch dessen ``Klasse`` besitzt das ``Objekt`` ``Mitglieder``. Diese beinhalten:
    * ``Felder (Fields)``/``Eigenschaften (Properties)`` und
    * ``Methoden``

Ein Beispiel dafür ist ``new Kunde { Name = "Manuela", Alter = 36}.BerechneUmsatz();``.

Was besitzt ein ``Anonymes Objekt`` nicht, was ein ``Objekt`` haben muss? Wie kann ein ``Anonymes Objekt`` bei einem ``LINQ`` Ausdruck verwendet werden?

**Hinweis:** Ein *Anonymes Objekt* wird auch *Anonymer Typ* genannt.

### Programmieren [25 / 45 Teilpunkte]

Schreibe folgenden ``iterativen`` Code in mehrere ``LINQ`` Ausdrücke mit ``Lambda`` Ausdrücken um. 

> **Hinweise:** 
> * Es befindet sich in der Angabe eine Vorlage für den ``LINQ`` code.
> * Suche nach der ``LINQ`` ``Methoden`` welche hier verwendet werden können im Internet. Verwende dazu folgende queries: ***c# linq objekt nach höchstem wert eines schlüssels auswählen --ai*** und ***.net c# linq zeilenfilter --ai***. Falls keine sinnvollen resultate zurückkommen, entferne das --ai.

```csharp
Kunde Beinhaltet(List<Kunde> kunden, string filterart, int? mindestAlter = null, int? mindestPunkte = null)
{
    if (filterart == "ältesterSinnvollerKunde" && mindestAlter.HasValue)
    {
        Kunde? ret = null;

        for (int i = 0; i < kunden.Count; i++)
        {
            if (kunden[i].Alter > mindestAlter)
            {
                ret = kunden[i];
            }
        }

        if (ret is null) throw new Exception("Mindestalter nicht passend. Kein Kunde gefunden.");

        foreach (Kunde kunde in kunden)
        {
            if (kunde.Alter > mindestAlter && kunde.Alter > ret.Alter)
            {
                ret = kunde;
            }
        }

        return ret;
    }
    else if (filterart == "sinnvollerKundeMitWenigstenPunkten" && mindestPunkte.HasValue)
    {
        Kunde? ret = null;

        for (int i = 0; i < kunden.Count; i++)
        {
            if (kunden[i].Punkte > mindestPunkte)
            { 
                ret = kunden[i];
            }
        } 

        if (ret is null) throw new Exception("Mindestalter nicht passend. Kein Kunde gefunden.");

        foreach (Kunde kunde in kunden)
        {
            if (kunde.Punkte > mindestPunkte && kunde.Punkte < ret.Punkte)
            {
                ret = kunde;
            }
        }

        return ret ?? throw new Exception("Kunde ist Null - Berchnung fehlgeschlagen.");
    }
    else
    {
        throw new Exception("Ünbekannter Filterart angegeben");
    }
}

var kunden = new List<Kunde> {
    new Kunde(Name: "Andrea", Alter: 25, Punkte: 100),
    new Kunde(Name: "Landrea", Alter: 35, Punkte: 200),
    new Kunde(Name: "Valrea", Alter: 45, Punkte: 300),
    new Kunde(Name: "Balrea", Alter: 55, Punkte: 400),
    new Kunde(Name: "Madrea", Alter: 65, Punkte: 500),
};

var istAelterAlsX = Beinhaltet(kunden, filterart: "ältesterSinnvollerKunde", mindestAlter: 18);
var mehrPunkteAlsX = Beinhaltet(kunden, filterart: "sinnvollerKundeMitWenigstenPunkten", mindestPunkte: 150);

Console.WriteLine("~~~ ITERATIVE ~~~");
Console.WriteLine(istAelterAlsX);
Console.WriteLine(mehrPunkteAlsX);

// TODO: Hier direkt LINQ ausdrücke schreiben, ohne diese in eine Methode zu geben. 
var istAelterAlsX_LINQ = ... // LINQ ausdruck hier.
var mehrPunkteAlsX_LINQ = ... // LINQ ausdruck hier.

Console.WriteLine("~~~ LINQ ~~~");
Console.WriteLine(istAelterAlsX_LINQ);
Console.WriteLine(mehrPunkteAlsX_LINQ);

public record Kunde(string Name, int Alter, double Punkte);
```
**Erwarteter Output:**
```
~~~ ITERATIVE ~~~
Kunde { Name = Madrea, Alter = 65, Punkte = 500 }
Kunde { Name = Landrea, Alter = 35, Punkte = 200 }
~~~ LINQ ~~~
Kunde { Name = Madrea, Alter = 65, Punkte = 500 }
Kunde { Name = Landrea, Alter = 35, Punkte = 200 }
```

---

## Aufgabe 2: Tasks mit Async/Await und Entities, DTOs, Services sowie Repositories [55 Punkte]

### Programmverständnis [10 / 55 Teilpunkte]
Wird folgender Code ``gleichzeitg`` (concurrent) oder ``hintereinander`` (sequential) ausgeführt?
```csharp
async Task CalculateStuff(int id)
{
    for (int i = 0; i < 100; i++)
    {
        await Task.Delay(1); //simuliert einen externen Methodenaufruf, z.B. eines http-requests.
        Console.WriteLine($"Ich bin die Methode mit id: {id}, welche auf Thread: {Thread.CurrentThread.ManagedThreadId} gestartet worden ist und berechne i = {i}");
    }
}

Task firstTask = CalculateStuff(1);
Task secondTask = CalculateStuff(2);

var tasks = new List<Task> { firstTask, secondTask };
await Task.WhenAll(tasks);
```

### Programmieren [35 / 55 Teilpunkte]
Verwende die Vorlage (*[Vorlage_Aufgabe_02-02_Programmieren.zip](https://github.com/MrStrelow/BBRZ/blob/main/JET/modul_3_fortgeschrittene-sprachkonzepte/ModulTest/Angabe/Vorlage_Aufgabe_2-02_Programmieren.zip)*) und vervollständige das Programm in den angegebenen Ebenen durch einen ``Zug``:
* Repositories: *ZugRepository*
* Services: *AnalyticsService*, *ZugService*

>**Hinweis:** Nutze die Implementierungen in den bereits getätigten Klassen als Vorlage. Die Startklasse ist nicht zu ändern! Alles wo ein TODO: steht ist anzupassen.

**Erwarteter Output:**
```
[07:50:48 INF] --- Ticketverkaufs-System startet ---
[07:50:48 INF] --- Ticketverkäufe werden simuliert ---
[07:50:48 INF] Busticket wird für Anna Schmidt vorbereitet.
[07:50:48 INF] Ticket für Anna Schmidt für 2.40? erfolgreich erstellt.
[07:50:48 INF] Busticket wird für Ben Meier vorbereitet.
[07:50:48 INF] Ticket für Ben Meier für 2.40? erfolgreich erstellt.
[07:50:48 INF] Busticket wird für Anna Schmidt vorbereitet.
[07:50:48 INF] Ticket für Anna Schmidt für 2.40? erfolgreich erstellt.
[07:50:49 INF] Zugticket wird für Clara Huber vorbereitet.
[07:50:49 INF] Ticket für Clara Huber für 59.90? erfolgreich erstellt.
[07:50:49 INF] --- Analyse wird durchgeführt ---
[07:50:49 INF] Starte Analyse: Kunde mit den meisten Tickets...
[07:50:49 INF] Der Kunde mit den meisten Tickets ist: Anna Schmidt (ID: 1)
[07:50:49 INF] --- System wird beendet ---
```

---

### Theorie [10 / 55 Teilpunkte]
Schreiben Sie ihre Meinung zu folgenden Aussagen:
* Ein ``Service`` soll von einem ``Reository`` aufgerufen werden.

* Ein ``DTO`` wird von ``Entities`` verwendet um mit einer externen Schnittstelle (anderes Programm welches mit dem service unter http kommuniziert) zu kommunizieren.

* Wir verwenden das ``Keyword`` ``await``, um auf das Ergebnis einer ``asynchronen`` ``Methode`` zu Warten.

* Wenn zwei ``Methoden`` welche mit ``async`` gekennzeichnet sind, hintereinander aufgerufen werden, werden diese ``gleichzeit`` ausgeführt. 