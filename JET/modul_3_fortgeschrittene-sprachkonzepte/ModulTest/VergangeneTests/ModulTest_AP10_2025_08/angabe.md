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
var personen = new List<Person>
{
    new Person(Name: "Hans", Alter: 18, Groesse: 1, LieblingsEssen: "Strudel"),
    new Person(Name: "Lans", Alter: 19, Groesse: 2, LieblingsEssen: "Nudeln"),
    new Person(Name: "Gans", Alter: 20, Groesse: 3, LieblingsEssen: "Pudel"),
    new Person(Name: "Mans", Alter: 21, Groesse: 4, LieblingsEssen: "Tofu"),
    new Person(Name: "Tans", Alter: 22, Groesse: 5, LieblingsEssen: "Brokoli"),
    new Person(Name: "Fans", Alter: 23, Groesse: 6, LieblingsEssen: "Tofu")
};

// LINQ Beginn
var gans = personen.Filter(person => person.Name == "Gans");

var nachAlterSortiert = personen.OrderBy(person.Alter);

var strudelFans = personen
    .Select(person => person.Name).
    .Where(person => person.LieblingsEssen == "Strudel");

Person essenMitDuplikateSortiertNachAlter = personen.Select(p => new { p.LieblingsEssen, p.Alter}).OrderBy(p => p.Groesse);

int grenze = ... // TODO selber einfügen.
bool sindAlleGross = personen.All(p => p.Groesse > grenze);

var nachEssenGruppiert = personen.GroupBy(p => p.LieblingsEssen);

var größtePersonWelcheJuengerAls30Ist = personen.OrderBy(p => p.Groesse).FirstOrDefault(p => p.Alter < 30);

double durchschnittsgroesse = personen.Average(p => p.Groesse);

int alterDerAeltestenPerson = personen.Max(p => p.Alter);
// LINQ ENDE

public record Person(string Name, int Alter, double Groesse, string LieblingsEssen);
```

Was ist korrekt oder falsch an folgenden ``LINQ`` Ausdrücken?
* Finde die Fehler in diesem Code und markiere diese. 
* Erkläre wieso diese Fehler zu einem nicht gültigen bzw. konzeptionell falschen ``LINQ``Ausdruck führen.

### Theorie [10 / 45 Teilpunkte]
1) Begründe warum der ``Typ`` des ``Parameters`` *filterBedingung* hier ``Func<Buch, bool>`` oder ``Action<Buch>`` ist? Ersetze dazu den ``...`` mit ``Func<Buch, bool>`` oder ``Action<Buch>``.

>**Hinweis**: Diese ``Typen`` können verwendet werden, um eine ``Methode`` als ``Variable`` zu speichern. Die ``Typparameter`` sind dabei ``Func<ParameterDerMethode, RückgabeDerMethode>`` und ``Action<ParameterDerMethode>``.

```csharp
static List<Buch> FiltereBücher(List<Buch> bücher, ... filterBedingung)
{
    var gefilterteListe = new List<Buch>();

    foreach (var buch in bücher)
    {
        if (filterBedingung(buch))
        {
            gefilterteListe.Add(buch);
        }
    }

    return gefilterteListe;
}
```

2) Markiere in folgendem Code den *Beginn* und das *Ende* des ``Lambda`` Ausdrucks. 
```csharp
Console.WriteLine(string.Join(" ~ ", kunden.Where(t => t.Punkte >= 180)));
```

3) Eine ``Methode`` mit ``Rückgabe`` besitzt eine ``Methodensignatur``. Diese beinhaltet:
    * einen ``Rückgabewert``/``Rückgabetyp``
    * den *Namen* der ``Methode`` und
    * einen oder mehrere ``Parameter``.

Ein Beispiel dafür ist ``double BerechneKuerzesteDistanz(Graph g)``

Was besitzt ein ``Lambda`` Ausdruck nicht, was eine ``Methode`` haben muss? 

4) Ein ``Objekt`` hat als ``Typ`` eine ``Klasse``. Durch dessen ``Klasse`` besitzt das ``Objekt`` ``Mitglieder``. Diese beinhalten:
    * ``Felder (Fields)``/``Eigenschaften (Properties)`` und
    * ``Methoden``

Ein Beispiel dafür ist ``new Kunde { Name = "Manuela", Alter = 36}.BerechneUmsatz();``.

Was besitzt ein ``Anonymes Objekt`` nicht, was ein ``Objekt`` haben muss? Wie kann ein ``Anonymes Objekt`` bei einem ``LINQ`` Ausdruck verwendet werden?

**Hinweis:** Ein *Anonymes Objekt* wird auch *Anonymer Typ* genannt.

### Programmieren [25 / 45 Teilpunkte]

Schreibe folgenden ``iterativen`` Code in mehrere ``LINQ`` Ausdrücke mit ``Lambda`` Ausdrücken um. 

> **Hinweise:** 
> * Es befindet sich in der Angabe eine Vorlage für den ``LINQ`` code.
> * Suche nach der ``LINQ`` ``Methode`` welche hier verwendet werden kann im Internet. Verwende dazu folgende query ***.net c# linq wenn eine person älter ist als x gib true zurück --ai***. Falls keine sinnvollen resultate zurückkommen, entferne das --ai.

```csharp
bool Beinhaltet(List<Kunde> kunden, string filterart, int? älterAls = null, int? grenzePunkte = null)
{
    bool ret = false;

    if (filterart == "istAelterAlsX" && älterAls.HasValue) {
        foreach (Kunde kunde in kunden)
        {
            if (kunde.Alter > älterAls)
            {
                ret = true;
                break;
            }
        }
    }
    else if (filterart == "mehrPunkteAlsX" && grenzePunkte.HasValue) 
    {
        foreach (Kunde kunde in kunden)
        {
            if (kunde.Punkte > grenzePunkte)
            {
                ret = true;
                break;
            }
        }
    }
    else
    {
        Console.WriteLine("Ünbekannter Filterart angegeben");
    }

    return ret;
}

var kunden = new List<Kunde> {
    new Kunde(Name: "Andrea", Alter: 25, Punkte: 100),
    new Kunde(Name: "Landrea", Alter: 35, Punkte: 200),
    new Kunde(Name: "Valrea", Alter: 45, Punkte: 300),
    new Kunde(Name: "Balrea", Alter: 55, Punkte: 400),
    new Kunde(Name: "Madrea", Alter: 65, Punkte: 500),
};

var istAelterAlsX = Beinhaltet(kunden, filterart: "istAelterAlsX", älterAls: 18);
var mehrPunkteAlsX = Beinhaltet(kunden, filterart: "mehrPunkteAlsX", grenzePunkte: 300);

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
True
True
~~~ LINQ ~~~
True
True
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

await CalculateStuff(1);
await CalculateStuff(2);
```

### Programmieren [35 / 55 Teilpunkte]
Verwende die Vorlage (*[Vorlage_Aufgabe_02-02_Programmieren.zip](/Vorlage_Aufgabe_2-02_Programmieren.zip)*) und vervollständige das Programm in den angegebenen Ebenen durch eine ``Reservierung``:
* Repositories: *ReservierungsRepository*
* Services: *AnalyticsService*, *ReservierungsService*

>**Hinweis:** Nutze die Implementierungen in den bereits getätigten Klassen als Vorlage. Die Startklasse ist nicht zu ändern! Alles wo ein TODO: steht ist anzupassen.

**Erwarteter Output:**
```
[00:09:22 INF] Willkommen beim Fahrradverleih 'Fahrrad-Blitz'!
[00:09:22 INF] --- Reservierungen werden erstellt ---
[00:09:23 INF] Erstelle Reservierung für Kunde Max Mustermann für Fahrrad Mountainbike Pro am 09/02/2025 00:09:22
[00:09:23 INF] Reservierung erfolgreich erstellt.
[00:09:23 INF] Erstelle Reservierung für Kunde Max Mustermann für Fahrrad E-Bike Comfort am 09/03/2025 00:09:22
[00:09:23 INF] Reservierung erfolgreich erstellt.
[00:09:23 INF] Erstelle Reservierung für Kunde Lisa Lauter für Fahrrad Citybike Standard am 09/02/2025 00:09:22
[00:09:23 INF] Reservierung erfolgreich erstellt.
[00:09:23 INF] --- Mietanfragen werden entgegengenommen ---
[00:09:23 INF] Anfrage von Kunde Anna Alt (ID: 3) wird bearbeitet...
[00:09:23 INF] Anfrage von Kunde Lisa Lauter (ID: 2) wird bearbeitet...
[00:09:23 INF] Anfrage von Kunde Max Mustermann (ID: 1) wird bearbeitet...
[00:09:23 ERR] Ungültige Operation bei der Anfrage von Kunde 99.
System.InvalidOperationException: Kunde mit ID 99 nicht gefunden.
   at Fahrradverleih.Services.KundenService.MieteFahrradAsync(KundenWunschDto wunsch) in C:\Users\c4321116\Documents\GitHub\BBRZ\JET\modul_3_fortgeschrittene-sprachkonzepte\ModulTest\VergangeneTests\ModulTest_AP10_2025_08\Aufgabe_2\Services\KundenService.cs:line 33
   at Program.<>c__DisplayClass0_0.<<<Main>$>g__BearbeiteAnfrageAsync|0>d.MoveNext() in C:\Users\c4321116\Documents\GitHub\BBRZ\JET\modul_3_fortgeschrittene-sprachkonzepte\ModulTest\VergangeneTests\ModulTest_AP10_2025_08\Aufgabe_2\02_Programmieren.cs:line 71
[00:09:23 ERR] Fehler bei der Bearbeitung der Anfrage von Kunde 3.
Fahrradverleih.Exceptions.AusleihvorgangException: Ausleihvorgang für Kunde Anna Alt konnte nicht abgeschlossen werden.
 ---> Fahrradverleih.Exceptions.FahrradNichtVerfuegbarException: Fahrrad mit ID 99 konnte nicht gefunden werden.
   at Fahrradverleih.Services.FahrradService.BereitstellenAsync(Int32 fahrradId) in C:\Users\c4321116\Documents\GitHub\BBRZ\JET\modul_3_fortgeschrittene-sprachkonzepte\ModulTest\VergangeneTests\ModulTest_AP10_2025_08\Aufgabe_2\Services\BestellService.cs:line 25
   at Fahrradverleih.Services.KundenService.MieteFahrradAsync(KundenWunschDto wunsch) in C:\Users\c4321116\Documents\GitHub\BBRZ\JET\modul_3_fortgeschrittene-sprachkonzepte\ModulTest\VergangeneTests\ModulTest_AP10_2025_08\Aufgabe_2\Services\KundenService.cs:line 44
   --- End of inner exception stack trace ---
   at Fahrradverleih.Services.KundenService.MieteFahrradAsync(KundenWunschDto wunsch) in C:\Users\c4321116\Documents\GitHub\BBRZ\JET\modul_3_fortgeschrittene-sprachkonzepte\ModulTest\VergangeneTests\ModulTest_AP10_2025_08\Aufgabe_2\Services\KundenService.cs:line 59
   at Program.<>c__DisplayClass0_0.<<<Main>$>g__BearbeiteAnfrageAsync|0>d.MoveNext() in C:\Users\c4321116\Documents\GitHub\BBRZ\JET\modul_3_fortgeschrittene-sprachkonzepte\ModulTest\VergangeneTests\ModulTest_AP10_2025_08\Aufgabe_2\02_Programmieren.cs:line 71
[00:09:23 INF] Fahrrad wird bereitgestellt: E-Bike Comfort
[00:09:23 INF] Fahrrad wird bereitgestellt: Citybike Standard
[00:09:23 INF] Fahrrad wird bereitgestellt: Mountainbike Pro
[00:09:23 INF] Fahrrad 'Mountainbike Pro' ist bereit.
[00:09:23 INF] Fahrrad 'E-Bike Comfort' ist bereit.
[00:09:23 INF] Fahrrad 'Citybike Standard' ist bereit.
[00:09:23 INF] Rechnung für Kunde Max Mustermann erstellt. Betrag: 25.50
[00:09:23 INF] Rechnung für Kunde Lisa Lauter erstellt. Betrag: 22.75
[00:09:23 INF] Alle Anfragen wurden versucht zu verarbeiten.
[00:09:23 INF] --- Tagesanalyse des Verleihs ---
[00:09:23 INF] Starte Verleih-Analyse...
[00:09:23 INF] Analyse abgeschlossen.
[00:09:23 INF] Beliebtestes Fahrrad SEIT ERÖFFNUNG: Fahrrad Nr. 1
[00:09:23 INF] Kunde mit den meisten Reservierungen: Kunde Nr. 1
[00:09:23 INF] Simulation beendet.
```

---

### Theorie [10 / 55 Teilpunkte]
* Soll ein ``Repository`` von einem ``Service`` aufgerufen werden können?

* Ein ``DTO`` wird von ``Services`` verwendet um mit einer externen Schnittstelle (anderes Programm welches mit dem service unter http kommuniziert) zu kommunizieren.

* Im ``Repository`` wird die *Datenbank* und *I/O* Logik einer ``Entity`` Zentralisiert. Es ist dort möglich ``CRUD`` und kompliziertere Abfragen durchzuführen.

* Eine ``Methode ``*A* welche eine andere ``Methode`` *B* mit ``await`` aufruf hat zur Folge, dass *A* als ``async`` gekennzeichnet werden muss.

* Wir verwenden ``Task.WhenAll(myTasks)`` und ``Task.WhenAny(myTasks)`` um nicht nur ``asynchron`` sondern auch ``gleichzeitg`` (concurrent) Code ausühren zu können.