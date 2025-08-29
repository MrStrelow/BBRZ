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

## Aufgabe 1: LINQ und Func, Action - Delegates, Lambda [50 / 100 Punkte]
### Programmverständnis [10 / 50 Teilpunkte]
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

### Theorie [10 / 40 Teilpunkte]
* Ist der ``Typ`` des ``Parameters`` *filterBedingung* hier ``Func<Buch, bool>`` oder ``Action<Buch>``? Erinnere dich, dass diese beiden ``Typen`` verwendet werden können um eine ``Methode`` als ``Variable`` speichern zu können. Die ``Typparameter`` sind ``Func<ParameterDerMethode, RückgabeDerMethode>`` und ``Action<ParameterDerMethode>`` in folgendem Code als ``Typ`` des  verwendet werden? Begründe warum.

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

## Aufgabe 2: Async, n-Layers und Repositories [55 Punkte]

### Programmieren [40 / 55 Teilpunkte]
Verwende folgende Vorlage und vervollständige das Programm in den Ebenen:
* Repositories
* Services
* Entities
* DTO

Die grobe implementierung ist in den Interfaces vorgegeben.

---

### Theorie [15 / 55 Teilpunkte]
* Was ist ein ``DTO`` und was eine ``Entitiy``? Wo unterscheiden diese sich?
* ``Hat`` eine ``Service`` Klasse eher ein ``Repository`` oder hat ein ``Repository`` eher einen ``Service``?
* ``Methoden`` mit dem Schlüsselwort ``async`` werden immer ``parallel`` und nie ``sequenziel`` ausgeführt.