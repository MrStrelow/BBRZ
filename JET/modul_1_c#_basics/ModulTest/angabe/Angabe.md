# Modultest 1 - JET AP09

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

* Die Abgabe des Programmcodes erfolgt über Teams (ein zip-File des Projektes mir bis spätestens 16:00 schicken)
* Viel Erfolg! :)

Notenschlüssel:
[0-50): N5; [50-62.5%): G4; [62.5-75%): B3; [75-87.5%): G2; [87.5-100%]: S1., (Schulnotensystem)

---

## Guard Clauses [50 / 100 Punkte]

### Programmverständnis [10 / 50 Teilpunkte]
Gegeben ist folgender Code welcher eine Guard Clause darstellt. Die Felder (Eigenschaften) der Objekte der Klasse Bergführer haben den Typ `bool`.

```csharp
if (guide == null){
    throw new ArgumentNullException("Bergführer darf nicht null sein.");
}

if (!guide.HasCertification)
{
    Console.WriteLine("Der Bergführer besitzt keine gültige Zertifizierung. Tour abgebrochen.");
    return;
}

if (!guide.IsMedicallyCleared)
{
    Console.WriteLine("Der Bergführer hat keine aktuelle medizinische Freigabe.");
}

if (!equipment.IsOperational)
{
    return;
    throw new GuideCheckException("Die Ausrüstung ist nicht einsatzbereit.");
}

Console.WriteLine("Alle Checks bestanden. Die Tour kann starten!");
```

 - a) Finde die Fehler in diesem Code und markiere diese.
 - b) Erkläre wieso diese Fehler zu einer nicht gültigen `Guard Clause` führen.

---

### Programmieren [35 / 50 Teilpunkte]
Schreibe folgendes `nested (verschachteltes) IF` als `Guard Clause` um.
(Hinweis: alle ❗ sind Teil der `Guards`, alle ✅ sind Teil der `gültigen Zustände`)

Erstelle dazu ein Projekt in `Visual Studio` (oder einem Editor deiner Wahl) und kopiere den `gesamten Code` in ein `Programm.cs` File.

```csharp
using System.Text;

public class Berg
{
    public bool IstGefährlich { get; set; }
    public int höhe { get; set; }
}


public class Bergführer
{
    // Eigenschaften / Felder
    public bool IsActive { get; set; }
    public int Age { get; set; }
    public string MedicalClearanceCertificate { get; set; }
    public DateTime CertificationExpiry { get; set; }
    public int TourCount { get; set; }

    // Hat-Beziehungen
    public Berg BergRoute { get; set; }

    public void ValidateGuide()
    {
        if (IsActive)
        {
            if (Age >= 21)
            {
                if (!string.IsNullOrEmpty(MedicalClearanceCertificate))
                {
                    if (CertificationExpiry > DateTime.Now)
                    {
                        if (BergRoute.IstGefährlich)
                        {
                            if (TourCount >= 50 && TourCount <= 200)
                            {
                                Console.WriteLine(“✅ Bergführer hat zwischen 50 und 200 Touren. Ein weiterer erfahrener Guide ist erforderlich, um diese Route zu bewältigen.”);
                            }
                            else if (TourCount > 200)
                            {
                                Console.WriteLine(“✅ Bergführer hat mehr als 200 Touren. Dieser Guide darf die Route alleine führen.”);
                            }
                            else
                            {
                                throw new InvalidOperationException(“❗ Bergführer hat zu wenig Erfahrung für diese Route.”);
                            }
                        }
                        else
                        {
                            if (BergRoute.höhe > 5000) 
                            {
                                Console.WriteLine(“✅ Berg ist zu hoch. Ein weiterer erfahrener Guide ist erforderlich, um diese Route zu bewältigen.”);
                            } 
                            else 
                            {
                                Console.WriteLine(“✅ Bergführer darf die Tour durchführen.”);
                            }
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException(“❗ Die Zertifizierung des Bergführers ist abgelaufen.”);
                    }
                }
                else
                {
                    throw new InvalidOperationException(“❗ Bergführer besitzt kein medizinisches Freigabezertifikat.”);
                }
            }
            else
            {
                throw new InvalidOperationException(“❗ Bergführer muss älter als 21 Jahre sein.”);
            }
        }
        else
        {
            throw new InvalidOperationException(“❗ Bergführer ist nicht aktiv.”);
        }
    }

    public void ValidateGuideGuardClause()
    {
        // TODO: Schreibe hier das in ValidateGuide verschachtelte IF in eine Guard Clause um.
        throw new NotImplementedException("This method is not yet implemented: Schreibe hier das in ValidateGuide verschachtelte IF in eine Guard Clause um.");
    }
}


public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Bergführer guide = new Bergführer
        {
            IsActive = true,
            Age = 35,
            MedicalClearanceCertificate = "ValidCertificate",
            CertificationExpiry = DateTime.Now.AddMonths(12),
            TourCount = 150,
            BergRoute = new Berg { IstGefährlich = true, höhe = 4000 }
        };

        try
        {
            guide.ValidateGuide();
            guide.ValidateGuideGuardClause();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Fehler: {ex.Message}");
        }
    }
}
```

---

### Theorie [5 / 50 Teilpunkte]
* a) Welches Gesetz hilft uns `nested (verschachteltes) IF` als `Guard Clause` umzuschreiben? Versuche intuitiv zu erklären wieso.
* b) In C#, kann in einem `Switch-Statement` die Bedingung `x > 50` abgefragt werden und damit in Guard Clauses immer verwendet werden? `Hinweis für C# Kenner`: Es ist **keine** `switch-expression` bzw. **kein** `Pattern Matching` gemeint und auch keine Verwendung von `case guards` vorgesehen. Diese Konzepte lernen wir erst später kennen.)
* c) Beschreibe den Unterschied zwischen `Vergleichsoperatoren` und `logischen Operatoren`. Gibt es einen? Beide geben einen `Booleschen` Wert zurück. 

---

## OOP und Collections: Hat Beziehung implementieren [50 Punkte]
### Programmieren [40 / 50 Teilpunkte]

Implementiere folgende `Hat-Beziehungen`:
* Ein `Berg` hat mehrere `Routen`
* Eine `Route` hat mehrere `Stationen`
* Eine `Station` hat maximal 5 `Bergsteiger`
* Ein `Bergsteiger` hat genau eine `Station`
* Ein `Bergführer` hat genau eine `Route`
* Eine `Route` hat genau einen `Bergführer` (das selbe Objekt, wie in der vorherigen Beziehung)

Implementiere folgendes `Verhalten` mit `Methoden`:
* `Bergsteiger` können sich eine `Station` aussuchen an der diese bleiben.
* `Bergführer` können einen `Bergsteiger` auf der zuständigen `Route` suchen. Versuche dazu eine `Collection (Datenstruktur)` zu verwenden, welche immer gleich schnell ist, egal wie viele `Bergsteiger/Stationen` sich auf der Route befinden.

`Näheres` zur Implementierung ist im unteren Programmcode beim Aufruf der `NotImplementedExceptions` und in Kommentaren welche `//TODO` beinhalten, zu finden.

```csharp
using System;
using System.Collections.Generic;

namespace ModulTest;

public class Mountaineer
{
    // Hat-Beziehungen
    // TODO: Bilde hier die gegebene Hat-Beziehung ab.

    // Konstruktor
    public Mountaineer(Route route)
    {
        throw new NotImplementedException("TODO: Wenn ein Bergsteiger-Objekt erstellt wird, bekommt dieser eine Route.");
    }

    // Methoden
    public void AddMountaineerToStation(Station station)
    {
        throw new NotImplementedException("Bonus: Prüfe ob ein Bergsteiger bereits an einer anderen Station ist.");

        throw new NotImplementedException("TODO: Wenn die als Argument übergebene Station noch nicht der Route hinzugefügt wurde, wird diese hier hinzugefügt.");
        throw new NotImplementedException("TODO: Füge den Bergsteiger der Collection in der Station hinzu.");
        throw new NotImplementedException("TODO: Hier muss die Collection des Bergführers, befüllt werden, damit beide Collections den selben Inhalt haben.");
    }
}

public class Station
{
    // Hat-Beziehungen
    // TODO:
    //  Bilde hier die gegebene Hat-Beziehung ab.
    //  Verwende dazu eine Collection (Array, Liste, Dictionary) deiner Wahl.

    // Methoden
    public void AddMountaineer(Mountaineer mountaineer)
    {
        throw new NotImplementedException("TODO: Hier soll ein Bergsteiger der Collection hinzugefügt werden.");
        throw new NotImplementedException("TODO: Falls kein Platz mehr an der Station ist, soll diese Zuweisung nicht erfolgreich sein.");
    }

    // TODO: ersetze ? mit den gewählten Typ der Collection
    public ? GetMountaineers()
    {
        throw new NotImplementedException("TODO: Gib die gewählte Collection zurück.");
    }
}

public class Route
{
    // Hat-Beziehungen
    // TODO:
    //  Bilde hier die gegebene Hat-Beziehungen ab.
    //  Verwende dazu eine Collection (Array, Liste, Dictionary) deiner Wahl.
    
    // Konstruktor
    public Route(Guide guide)
    {
        throw new NotImplementedException("TODO: Konstruktor mit Bergführer als Parameter");
    }

    // Default Konstruktor ohne Parameter - hier muss nichts getan werden.
    public Route(){}

    // Methoden
    public ? GetStations()
    {
        throw new NotImplementedException("TODO: Ersetze das `?` beim Rückgabetyp der Methode mit den gewählten Typ der Collection und gib das Objekt der Collection zurück.");
    }

    public Guide GetGuide()
    {
        throw new NotImplementedException("TODO: Gib den Bergführer zurück.");
    }

    public void SetGuide(Guide guide)
    {
        throw new NotImplementedException("TODO: Setze den Bergführer auf jenen welcher als Parameter übergeben wird.");
    }
}

public class Guide
{
    // TODO:
    // Felder/Eigenschaften
    //  Erstelle eine Collection (Array, Liste, Dictionary) deiner Wahl,
    //  um einen schnellstmöglichen Zugriff auf die Station eines Bergsteigers zu gewährleisten.
    //  (Anders formuliert: Gegeben ein Bergsteiger, wie bekommen wir dessen Station?)

    // Hat-Beziehungen
    // TODO:
    //  Bilde hier die gegebene Hat-Beziehungen ab.

    // Konstruktor
    public Guide(Route route)
    {
        throw new NotImplementedException("TODO: Wenn ein Bergführer-Objekt erstellt wird, bekommt dieser eine Route.");
        throw new NotImplementedException("TODO: Hier muss auch die Collection des Bergführers, mit dem Inhalt befüllt werden, damit die Datenstruktur des Bergführers und jene der Route den selben Inhalt haben.");
    }

    // Methoden
    public Station FindMountaineerOnRoute(Mountaineer mountaineer)
    {
        throw new NotImplementedException("TODO: Hier sucht ein Bergführer einen Bergsteiger welcher schnellstmöglich gefunden werden muss. Gefunden bedeutet, dass die Station des Bergsteigers gefunden wird.");
    }

    public void PutMountaineerInLookup(Station station, Mountaineer mountaineer)
    {
        throw new NotImplementedException("TODO: Verbinde die Station mit dem Bergsteiger und füge es der Collection hinzu.");
    }

    public ? GetMountaineerLookup()
    {
        throw new NotImplementedException("TODO: Ersetze das `?` beim Rückgabetyp der Methode und gib die Collection zurück.");
    }
}

public class Mountain
{
    // Hat-Beziehungen
    // TODO:
    //  Erstelle eine Collection (Array, Liste, Dictionary) deiner Wahl welche Routen verwaltet.

    // Methoden
    public void AddRoute(Route route)
    {
        throw new NotImplementedException("TODO: Füge eine Route der Collection hinzu.");
    }

    public ? GetRoutes()
    {
        throw new NotImplementedException("TODO: Ersetze das `?` beim Rückgabetyp der Methode und gib die Collection zurück.");
    }
}

public class Program
{
    public static void Main()
    {
        throw new NotImplementedException("TODO: Erstelle einen Berg.");
        throw new NotImplementedException("TODO: Erstelle zwei Routen mit dem Default Konstruktor.");
        throw new NotImplementedException("TODO: Erstelle zwei Bergführer mit dem Konstruktor welcher Routen übernimmt.");
        throw new NotImplementedException("TODO: Setze gib nun die Routen den Bergführern über eine Set Methode.");
        throw new NotImplementedException("TODO: Füge die Routen dem Berg hinzu.");
        throw new NotImplementedException("TODO: Füge 2 Stationen der ersten Route und 2 Stationen der zweiten Route hinzu.");
        throw new NotImplementedException("TODO: Erstelle drei Bergsteiger für jede der Routen.");
        
        throw new NotImplementedException("TODO: Setze 3 Bergsteiger auf die Stationen in einer Route und 2 Bergsteiger auf Stationen in der anderen Route.");
        
        throw new NotImplementedException("TODO: Setze den fehlenden Bergsteiger auf eine noch nicht in der Route existierende Station.");
        
        throw new NotImplementedException("TODO: Einer der Bergführer sucht (auf welche Station soll er/sie schauen?) schnell einen Bergsteiger deiner Wahl. Gib dazu diesen mit dessen Station aus. Es reicht das Objekt auf die Konsole auszugeben. Es muss kein Menschen lesbarer Text verwendet werden.");
        
        throw new NotImplementedException("TODO: Gib alle Bergsteiger inklusive Station im Berg auf die Konsole aus.");

        throw new NotImplementedException("TODO: Füge einen Bergsteiger einer freien Station in einer Route hinzu. Findet der Bergführer diesen?");

        throw new NotImplementedException("TODO: Ein neuer Bergführer bekommt eine bestehende Route. Überschreibe dazu den Bergführer in einer bestehenden Route mit dem Objekt des neuen Bergführers. Findet er die Bergsteiger?");
        
        throw new NotImplementedException("TODO: Suche nun mit dem Bergführer der anderen Route. Was passiert nun?");
    }
}
```

### Theorie [10 / 50 Teilpunkte]
* Unsere `Felder` bzw. `Hat-Beziehungen` hier sind als `private` gekennzeichnet. Nenne Gründe warum dies sinnvoll sein kann.
* Erkläre die grundlegende Funktion einer `Liste` im Vergleich zu einem `Dictionary` (es muss nicht auf Implementierungen, wie LinkedList oder ArrayList eingegangen werden).
* Nenne Situationen wann es sinnvoll erscheint ein `Dictionary` zu verwenden?


