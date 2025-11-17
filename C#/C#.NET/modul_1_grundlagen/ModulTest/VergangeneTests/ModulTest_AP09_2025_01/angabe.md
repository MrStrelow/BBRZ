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

* Die Abgabe des Programmcodes erfolgt über Teams (ein zip-File des Projektes mir bis spätestens 15 minuten nach Ende des Tests zu schicken)
* Viel Erfolg! :)

Notenschlüssel:
[0-50): N5; [50-62.5%): G4; [62.5-75%): B3; [75-87.5%): G2; [87.5-100%]: S1., (Schulnotensystem)

---

## Guard Clauses [50 / 100 Punkte]

### Programmverständnis [10 / 50 Teilpunkte]
Gegeben ist folgender Code welcher eine Guard Clause darstellt. Die Felder (Eigenschaften) der Objekte der Klasse Pilot haben den Typ `bool`.

```csharp
if (pilot == null){
    throw new ArgumentNullException("Pilot darf nicht null sein.");
}

if (pilot.HasLicense)
{
    Console.WriteLine("Der Pilot besitzt keine gültige Lizenz. Start abgebrochen.");
    return;
}

if (!pilot.IsMedicallyCleared)
{
    Console.WriteLine("Der Pilot hat keine aktuelle medizinische Freigabe.");
}

if (!aircraft.IsOperational)
{
    return;
    throw new PilotCheckException("Das Flugzeug ist nicht betriebsbereit.");
}

Console.WriteLine("Alle Checks bestanden. Der Flug kann starten!");
```

 - a) Finde die Fehler in diesem Code und markiere diese.
 - b) Erkläre wieso diese Fehler zu einer nicht gültigen `Guard Clause` führen. 

---

### Programmieren [35 / 50 Teilpunkte]
Schreibe folgendes `nested (verschachteltes) IF` als `Guard Clause` um.
(Hinweis: alle ❗ sind Teil der `Guards` (``ungewünschten``) Zustände, alle ✅ sind Teil der `gewünschten Zustände`)

Erstelle dazu ein Projekt in `Visual Studio` (oder einem Editor deiner Wahl) und kopiere den `gesamten Code` in ein `Programm.cs` File.

```csharp
using System.Text;

public class Flugzeug
{
    public bool IstGross { get; set; }
}


public class Pilot
{
    // Eigenschaften / Felder
    public bool IsActive { get; set; }
    public int Age { get; set; }
    public string MedicalClearanceCertificate { get; set; }
    public DateTime LicenseExpiry { get; set; }
    public int FlightCount { get; set; }

    // Hat-Beziehungen
    public Flugzeug Flieger { get; set; }

    public void ValidatePilot()
    {
        if (IsActive)
        {
            if (Age >= 18)
            {
                if (!string.IsNullOrEmpty(MedicalClearanceCertificate))
                {
                    if (LicenseExpiry > DateTime.Now)
                    {
                        if (Flieger.IstGross)
                        {
                            if (FlightCount >= 200 && FlightCount <= 500)
                            {
                                Console.WriteLine("✅ Pilot hat zwischen 200 und 500 Flügen. Ein Co-Pilot mit mehr als 500 Flügen ist erforderlich um ein großes Flugzeug fliegen zu können.");
                            }
                            else if (FlightCount > 500)
                            {
                                Console.WriteLine("✅ Pilot hat mehr als 500 Flüge. Dieser Pilot darf ein großes Flugzeug fliegen.");
                            }
                            else
                            {
                                throw new InvalidOperationException("❗Pilot hat zu wenig Flüge für ein Großes Flugzeug.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("✅ Pilot darf das Flugzeug fliegen.");
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("❗Die Lizenz des Piloten ist abgelaufen.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("❗Pilot besitzt kein medizinisches Freigabezertifikat.");
                }
            }
            else
            {
                throw new InvalidOperationException("❗Pilot muss älter als 18 Jahre sein.");
            }
        }
        else
        {
            throw new InvalidOperationException("❗Pilot ist nicht aktiv.");
        }
    }

    public void ValidatePilotGuardClause() 
    {
        // TODO: Schreibe hier das in ValidatePilot verschachtelte IF in eine Guard Clause um.
        throw new NotImplementedException("This method is not yet implemented: Schreibe hier das in ValidatePilot verschachtelte IF in eine Guard Clause um.");
    }
}


public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Pilot pilot = new Pilot
        {
            IsActive = true,
            Age = 30,
            MedicalClearanceCertificate = "VeryValidCertificate",
            LicenseExpiry = DateTime.Now.AddMonths(6),
            FlightCount = 300,
            Flieger = new Flugzeug { IstGross = true }
        };

        try
        {
            pilot.ValidatePilot();
            pilot.ValidatePilotGuardClause();
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
* b) Wenn ein verschachteltes IF mehrere `✅ gewünschte Zustände` besitzt, ist dann ein Anwenden einer Guard Clause möglich? Begründe dein Antwort.

---

## OOP und Collections: Hat Beziehung implementieren [50 Punkte]
### Programmieren [40 / 50 Teilpunkte]

Implementiere folgende `Hat-Beziehungen`:
* Eine `Schule` hat mehrere `Klassenzimmer`
* Ein `Klassenzimmer` hat mehrere `Tische`
* Ein `Tisch` hat maximal 2 `Schüler`
* Ein `Schüler` hat genau einen `Tisch`
* Ein `Lehrer` hat genau ein `Klassenzimmer`
* Ein `Klassenzimmer` hat genau einen `Lehrer` (das selbe Objekt, wie in der vorherigen Beziehung)

Implementiere folgendes `Verhalten` mit `Methoden`:
* `Schüler` können sich einen `Tisch` aussuchen an dem diese sitzen.
* `Lehrer` können einen `Schüler` im zuständigen `Klassenraum` suchen. Versuche dazu eine `Collection (Datenstruktur)` zu verwenden, welche immer gleich schnell ist, egal wie viele `Schüler/Tische` sich in dem Klassenraum befinden.

`Näheres` zur Implementierung ist im unteren Programmcode beim Aufruf der `NotImplementedExceptions` und in Kommentaren welche `//TODO` beinhalten, zu finden.

```csharp
using System;
using System.Collections.Generic;

namespace ModulTest;

public class Student
{
    // Hat-Beziehungen
    // TODO: Bilde hier die gegebene Hat-Beziehung ab.

    // Konstruktor
    public Student(Classroom classroom)
    {
        throw new NotImplementedException("TODO: Wenn ein Lehrer:innen Objekt erstellt wird, bekommt diese einen Klassenraum.");
    }

    // Methoden
    public void AddStudentToDesk(Desk desk)
    {
        throw new NotImplementedException("Bonus: Prüfe ob ein Schüler:in bereits auf einen anderen Tisch sitzt.");

        throw new NotImplementedException("TODO: Wenn der als Argument übergebene Tisch noch nicht dem Klassenraum hinzugefügt wurde, wird dieser hier hinzugefügt.");
        throw new NotImplementedException("TODO: Füge den Studenten der Collection im Tisch hinzu.");
        throw new NotImplementedException("TODO: Hier muss die Collection des Lehrers, befüllt werden, damit beide Collections den selben Inhalt haben.");
    }
}

public class Desk
{
    // Hat-Beziehungen
    // TODO: 
    //  Bilde hier die gegebene Hat-Beziehung ab. 
    //  Verwende dazu eine Collection (Array, Liste, Dictionary) deiner Wahl.

    // Methoden 
    public void AddStudent(Student student)
    {
        throw new NotImplementedException("TODO: Hier soll ein Student der Collection hinzugefügt werden.");
        throw new NotImplementedException("TODO: Falls kein Platz mehr am Tisch ist, soll diese Zuweisung nicht erfolgreich sein.");
    }

    // TODO: ersetze ? mit den gewählten Typ der Collection
    public ? GetStudents()
    {
        throw new NotImplementedException("TODO: Git die gewählte Collection zurück.");
    }
}

public class Classroom
{
    // Hat-Beziehungen
    // TODO: 
    //  Bilde hier die gegebene Hat-Beziehungen ab. 
    //  Verwende dazu eine Collection (Array, Liste, Dictionary) deiner Wahl.
    
    // Konstruktor
    public Classroom(Teacher teacher)
    {
        throw new NotImplementedException("TODO: Konstruktor mit Lehrer als Parameter");
    }

    // Default Konstruktor ohne Parameter - hier muss nichts getan werden.
    public Classroom(){}

    // Methoden 
    public ? GetDesks()
    {
        throw new NotImplementedException("TODO: Ersetze das `?` beim Rückgabetyp der Methode \\
        mit den gewählten Typ der Collection und gib das Objekt der Collection zurück.");
    }

    public Teacher GetTeacher()
    {
        throw new NotImplementedException("TODO: Gib den Lehrer zurück.");
    }

    public void SetTeacher(Teacher teacher)
    {
        throw new NotImplementedException("TODO: Setze den Lehrer auf jenen welcher als parameter übergebn wird.");
    }
}

public class Teacher
{
    // TODO: 
    // Felder/Eigenschaften
    //  Erstelle eine Collection (Array, Liste, Dictionary) deiner Wahl,
    //  um einen schnellstmöglichen Zugriff auf die Tische eines Schüler zu gewährleisten.
    //  (Anders formuliert: Gegeben einen Schüler, wie bekommen wir seinen Tisch?)

    // Hat-Beziehungen
    // TODO: 
    //  Bilde hier die gegebene Hat-Beziehungen ab. 

    // Konstruktor
    public Teacher(Classroom classroom)
    {
        throw new NotImplementedException("TODO: Wenn ein Lehrer:innen Objekt erstellt wird, bekommt diese einen Klassenraum.");
        throw new NotImplementedException("TODO: Hier muss auch die Collection des Lehrers, mit dem Inhalt befüllt werden, \\
                                                damit die Datenstruktur des Lehrers und jene der Classroom \\
                                                 den selben Inhalt haben.");
    }

    // Methoden
    public Desk FindStudentInRoom(Student student)
    {
        throw new NotImplementedException("\\
        TODO: Hier sucht ein Lehrer eine Schüler:in welche schnellstmöglich gefunden werden muss. \\
        Gefunden bedeutet, dass der Tisch der Schüler:in gefunden wird.");
    }

    public void PutStudentInLookup(Desk desk, Student student)
    {
        throw new NotImplementedException("TODO: Verbinde den Tisch mit der Schüler:in und füge es der Collection hinzu.");
    }

    public ? GetSutdentLookup()
    {
        throw new NotImplementedException("TODO: Ersetze das `?` beim Rückgabetyp der Methode und gib die Collection zurück.");
    }
}

public class School
{
    // Hat-Beziehungen
    // TODO:
    //  Erstelle eine Collection (Array, Liste, Dictionary) deiner Wahl welche Klassenzimmer verwaltet.

    // Methoden
    public void AddClassroom(Classroom classroom)
    {
        throw new NotImplementedException("TODO: Füge ein Klassenzimmer der Collection hinzu.");
    }

    public ? GetClassrooms()
    {
        throw new NotImplementedException("TODO: Ersetze das `?` beim Rückgabetyp der Methode und gib die Collection zurück.");
    }
}

public class Programm
{
    public static void Main()
    {
        throw new NotImplementedException("TODO: Erstelle eine Schule.");
        throw new NotImplementedException("TODO: Erstelle zwei Klassenzimmer mit dem Default Konstruktor.");
        throw new NotImplementedException("TODO: Erstelle zwei Lehrer:innen mit dem Konstruktor welcher Klassenräume übernimmt.");
        throw new NotImplementedException("TODO: Setzte gib nun die Klassenräume den Lehrer:innen über eine Set Methode.");
        throw new NotImplementedException("TODO: Füge die Klassenräume der Schule hinzu.");
        throw new NotImplementedException("TODO: Füge 2 Tische dem ersten Klassenraum und 2 Tische dem zewiten Klassenraum hinzu.");
        throw new NotImplementedException("TODO: Erstelle drei Schüler:innen für jede der Klassenräume.");
        
        throw new NotImplementedException("TODO: Setze 3 Schüler:innen auf die Tische in einen Klassenraum \\
        und 2 Schüler:innen auf Tische in den anderen Klasseraum.");
        
        throw new NotImplementedException("TODO: Setze den fehlenden Schüler:innen \\
        auf einen noch nicht im Klassenzimmer existierenden Tisch.");
        
        throw new NotImplementedException("TODO: Einer der Lehrer:innen sucht (auf welchen Tisch soll er/sie schauen?) \\
        schnell einen Schüler:innen deiner Wahl. Gib dazu diesen mit dessen Tisch aus. \\
        Es reicht das Objekt auf die konsole auszugeben. Es muss kein Menschen lesbarer Text verwendet werden.");
        
        throw new NotImplementedException("TODO: Gibt alle Schüler:innen inklusive Tisch in der Schule auf die Console aus.");

        throw new NotImplementedException("TODO: Füge eine:n Schüler:in einem freien Tisch in einem Klassenzimmer hinzu. \\
        Findet der Lehrer diese:n?");

        throw new NotImplementedException("TODO: Eine neue Lehrerin bekommt einen bestehenden Klassenraum. \\
        Überschreibe dazu den Lehrer in einem bestehenden Klassenraum mit dem Objekt der neuen Lehrerin. Findet sie die Schüler?");
        
        throw new NotImplementedException("TODO: Suche nun mit dem Lehrer des anderen Klassenraums. Was passiert nun?");
    }
}
```

### Theorie [10 / 50 Teilpunkte]
* Unsere `Felder` bzw. `Hat-Beziehungen` hier sind als `private` gekennzeichnet. Nenne Gründe warum dies sinnvoll sein kann.
* Erkläre die grundlegende Funktion einer `Liste` im Vergleich zu einem `Dictionary` (es muss nicht auf Implementierungen, wie LinkedList oder ArrayList eingegangen werden).
* Nenne Situationen wann es sinnvoll erscheint ein `Dictionary` zu verwenden?


