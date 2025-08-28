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

## Aufgabe 1: LINQ und Func, Action - Delegates, Lambda [40 / 100 Punkte]
### Programmverständnis [10 / 40 Teilpunkte]

Was ist korrekt oder falsch an folgenden ``LINQ`` Ausdrücken?
```csharp
List<Person> personen = new List<> 
{ 
    new Person { Name = "Hans", Alter = , Groesse = 1, Lieblingsessen = "Strudel" }, 
    new Person { Name = "Lans", Alter = , Groesse = 2, Lieblingsessen = "Nudeln" }, 
    new Person { Name = "Gans", Alter = , Groesse = 3, Lieblingsessen = "Pudel" }, 
    new Person { Name = "Rans", Alter = , Groesse = 4, Lieblingsessen = "Tofu" }, 
    new Person { Name = "Tans", Alter = , Groesse = 5, Lieblingsessen = "Brokoli" }, 
    new Person { Name = "Fans", Alter = , Groesse = 6, Lieblingsessen = "Tofu" } 
}

var gans = personen.Filter( person => person.Name == "Gans" );

var nachAlterSortiert = personen.OrderBy(alter);

var strudelFans = personen
    .Where(p => p.LieblingsEssen == "Strudel")
    .Select(p => p.Name);

Person essenMitDuplikateSortiertNachAlter = personen.Select(p => { p.Lieblingsese, p.Alter}).OrderBy( p => p.Alter);

int grenze = ... // TODO selber einfügen.
bool sindAlleGross = personen.All(p => p.Groesse > grenze);

var nachEssenGruppiert = personen.GroupBy(p => p.LieblingsEssen);

var ersteJungePerson = personen.FirstOrDefault(p => p.Alter < 30);

double durchschnittsgroesse = personen.Average(p => p.Groesse);

int alterDerAeltestenPerson = personen.Max(p => p.Alter);

public record Person(string Name, int Alter, double Groesse, string LieblingsEssen); 
```

### Theorie [10 / 60 Teilpunkte]
* Soll ``Func<T, V>`` oder ``Action<T>`` in folgendem Code als ``Typ`` des ``Parameters`` *filterBedingung* verwendet werden? Begründe warum.

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
* Markiere in folgendem Code wo der Lambda Ausdruck beginnt und endet. 
```csharp
myList.Where( t => t.Age >= 18 );
```

* Eine ``Methode`` mit ``Rückgabe`` besitzt eine ``Methodensignatur``, eine ``Rückgabewert``/``Rückgabetyp`` und ``Parameter``. Was fehlt bei folgendem ``Code`` welcher einen ``Lambda Ausdrück`` beinhaltet, was bei einer ``Methode`` vorhandnen sein muss? 
```csharp
myList.Where( t => t.Age >= 18 );
```

* Was ist ein ``Anyonymes Objekt`` und wie wird es bei ``LINQ`` Ausdrücken verwendet?

* Bevorzugt der folgende Code die Verwendung eine ``LINQ`` Ausdrucks oder ein iteratives Konstrukt (for, while, if, ...)?
```csharp
public bool beinhaltet(List<Kunden> kunden, string filterart, int? grenzePunkte) {
    bool ret = false;

    if (string filterart == "istälterals18") {
        for (Kunde kunde in kunden) {
            if (kunde.Alter > 18)
            {
                ret = true;
                break;
            }
        }
    } 
    else if(string filterart == "istpunkteals50" && grenzePunkte.hasValue) 
    {
        for (Kunde kunde in kunden) {
            if (kunde.Alter > 18)
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
}
```

### Programmieren [25 / 45 Teilpunkte]

Schreibe folgenden iterativen Code in einen ``LINQ`` ausdruck mit ``Lambda`` Ausdrücken um. Es gibt keine weiteren Einschränkungen. 

```csharp
public bool beinhaltet(List<Kunden> kunden, string filterart, int? älterAls = null, int? grenzePunkte = null) {
    bool ret = false;

    if (string filterart == "istälteralsX" && älterAls.hasValue) {
        for (Kunde kunde in kunden) {
            if (kunde.Alter > älterAls)
            {
                ret = true;
                break;
            }
        }
    } 
    else if(string filterart == "istpunktealsX" && grenzePunkte.hasValue) 
    {
        for (Kunde kunde in kunden) {
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
}
```
---

## Aufgabe 2: Async, n-Layers und Repositories [45 Punkte]

### Programmieren [25 / 45 Teilpunkte]
Verwende folgende Vorlage und vervollständige das Programm in den Ebenen:
* Repositories
* Services
* Entities
* DTO

Die grobe implementierung ist in den Interfaces vorgegeben.

---