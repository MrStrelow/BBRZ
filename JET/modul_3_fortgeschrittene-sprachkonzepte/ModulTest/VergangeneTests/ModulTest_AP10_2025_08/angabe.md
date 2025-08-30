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

Ein Beispiel dafür ist ``double berechneKürzesteDistanz(Graph g)``

Was besitzt ein ``Lambda`` Ausdruck nicht, was eine ``Methode`` haben muss? 

Was besitzt ein ``Lambda`` Ausdruck nicht, was eine ``Methode`` haben muss? 

4) Ein ``Objekt`` hat als ``Typ`` eine ``Klasse``. Durch dessen ``Klasse`` besitzt das ``Objekt`` ``Mitglieder``. Diese beinhalten:
    * ``Felder (Fields)``/``Eigenschaften (Properties)`` und
    * ``Methoden``

Ein Beispiel dafür ist ``new Kunde { Name = "Manuela", Alter = 36}.berechneUmsatz();``.

Was besitzt ein ``Anonymes Objekt`` nicht, was ein ``Objekt`` haben muss? Wie kann ein ``Anonymes Objekt`` bei einem ``LINQ`` Ausdruck verwendet werden?

**Hinweis:** Ein *Anonymes Objekt* wird auch *Anonymer Typ* genannt.

### Programmieren [25 / 45 Teilpunkte]

Schreibe folgenden ``iterativen`` Code in mehrere ``LINQ`` Ausdrücke mit ``Lambda`` Ausdrücken um. 

> **Hinweise:** 
> * Es befindet sich in der Angabe eine Vorlage für den ``LINQ`` code.
> * Suche nach der ``LINQ`` ``Methode`` welche hier verwendet werden kann im Internet. Verwende dazu folgende query ***.net c# linq wenn eine person älter ist als x gib true zurück --ai***. Falls keine sinnvollen resultate zurückkommen, entferne das --ai.

```csharp
bool beinhaltet(List<Kunde> kunden, string filterart, int? älterAls = null, int? grenzePunkte = null)
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

var istAelterAlsX = beinhaltet(kunden, filterart: "istAelterAlsX", älterAls: 18);
var mehrPunkteAlsX = beinhaltet(kunden, filterart: "mehrPunkteAlsX", grenzePunkte: 300);

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
---

## Aufgabe 2: Async, n-Layers und Repositories [55 Punkte]

### Programmverständnis [10 / 55 Teilpunkte]
```csharp
```

### Programmieren [35 / 55 Teilpunkte]
Verwende folgende Vorlage und vervollständige das Programm in den Ebenen:
* Repositories
* Services
* Entities
* DTO

Die grobe implementierung ist in den Interfaces vorgegeben.

---

### Theorie [10 / 55 Teilpunkte]
* Was ist ein ``DTO`` und was eine ``Entitiy``? Wo unterscheiden diese sich?
* ``Hat`` eine ``Service`` Klasse eher ein ``Repository`` oder hat ein ``Repository`` eher einen ``Service``?
* ``Methoden`` mit dem Schlüsselwort ``async`` werden immer ``parallel`` und nie ``sequenziel`` ausgeführt.