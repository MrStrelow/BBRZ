# Modultest 1 - JET AP09

Sie haben 120 Minuten Zeit die Aufgaben zu lösen
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

* Die Abgabe des Programmcodes erfolgt über Teams (ein zip-File des Projektes mir bis spätestens 10:15 schicken)
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
(Hinweis: alle ❗ sind Teil der `Guards`, alle ✅ sind Teil der `gültigen Zustände`)

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
* b) Wenn ein verschachteltes IF mehrere `✅ gültige zustände` besitzt, ist dann ein Anwenden einer Guard Clause möglich? Begründe dein Antwort.

---

## OOP und Collections: Hat Beziehung implementieren [50 Punkte]
### Programmieren [40 / 50 Teilpunkte]

Implementiere folgende `Hat-Beziehungen`:
* Eine `Schule` hat mehrere `Klassenzimmer`
* Ein `Klassenzimmer` hat mehrere `Tische`
* Ein `Tisch` hat maximal 2 `Schüler`
* Ein `Lehrer` hat genau ein `Klassenzimmer`

Zusätzlich soll es Lehrer:innen möglich sein, so schnell wie möglich den `Tisch` eines `Schülers` zu finden.

Näheres zur Implementierung ist im unteren Programmcode in Kommentaren zu finden.
Versuche dich auf das wesentliche zu kontentrieren! Es muss nicht jede Klasse ein Feld name oder alter haben.

```csharp
using System;
using System.Collections.Generic;

public class Student
{
    // Hat keine Felder/Eigenschaften und Beziehungen.
}

public class Desk
{
    // Hat-Beziehungen
    // Verwende eine Datenstruktur (Array, Liste, Dictionary) deiner Wahl.
    
    // TODO: throw new NotImplementedException("Not yet implemented.");

    // Methoden 
    // Hier soll ein Student der Datenstruktur hinzugefügt werden. Falls kein Platz mehr am Tisch ist, soll diese Zuweisung nicht erfolgreich sein. 
    public void AddStudent(Student student)
    {
        throw new NotImplementedException("Not yet implemented.");
    }

    // Füge anstatt "?" den Typ der gewählten Collection ein 
    public ? GetStudents()
    {
        throw new NotImplementedException("Not yet implemented.");
    }
}

public class Classroom
{
    // Hat-Beziehungen
    // Verwende eine Datenstruktur (Array, Liste, Dictionary) deiner Wahl.
    
    // TODO: throw new NotImplementedException("Not yet implemented.");

    // Methoden 
    // Füge den als Parameter übergebenen Studenten den Parameter Tisch hinzu. 
    // Wenn ein Tisch noch nicht der Klasse hinzugefügt wurde, wird dieser hier hinzugefügt. 
    // Bonus: Prüfe ob ein Schüler schon bereits auf einen anderen Tisch sitzt. 
    public void AddStudentToDesk(Student student, Desk desk)
    {
       throw new NotImplementedException("Not yet implemented.");
    }

    // Füge anstatt "?" den Typ der gewählten Collection ein 
    public ? GetDesks()
    {
        throw new NotImplementedException("Not yet implemented.");
    }
}

public class Teacher
{
    // Felder
    // Erstelle eine Collection (Array, Liste, Dictionary) deiner Wahl um einen schnellstmöglichen Zugriff auf die Tische eines Schüler zu gewährleisten.
    // (Anders formuliert: Wo muss der Lehrer hinschauen wenn er Schüler x sucht?)
    
    // TODO: throw new NotImplementedException("Not yet implemented.");

    // Hat-Beziehungen
    // TODO: throw new NotImplementedException("Not yet implemented.");

    // Konstruktor
    // Wenn ein Lehrer:innen Objekt erstellt wird, bekommt diese einen Klassenraum.
    // Hier muss auch die Collection welche oben definiert wurde, befüllt werden.
    public Teacher(Classroom classroom)
    {
        throw new NotImplementedException("Not yet implemented.");
    }

    // Methoden
    // Hier bekommt ein Lehrer eine Schüler:in welche schnellstmöglich gefunden werden muss. Gefunden bedeutet, dass der Tisch der Schüler:in gefunden wird.
    public Desk FindStudentInRoom(Student student)
    {
        throw new NotImplementedException("Not yet implemented.");
    }
}

public class School
{
    // Erstelle eine Collection (Array, Liste, Dictionary) deiner Wahl welches Klassen verwaltet.
    throw new NotImplementedException("Not yet implemented.");

    // Methode welches ein Hinzufügen von Klassenräumen erlaubt.
    public void AddClassroom(Classroom classroom)
    {
        throw new NotImplementedException("Not yet implemented.");
    }

    // Methode welches die Klassenräume zurückgibt.
    public List<Classroom> GetClassrooms()
    {
        throw new NotImplementedException("Not yet implemented.");
    }
}

public class Program
{
    public static void Main()
    {
        // Erstelle ein School Objekt
        throw new NotImplementedException("Not yet implemented.");

        // Erstelle zwei Classroom Objekte
        throw new NotImplementedException("Not yet implemented.");

        // Füge die Klassen der Schule hinzu
        throw new NotImplementedException("Not yet implemented.");

        // Füge 2 Tische dem 1. Klasseraum und 3 Tische dem 2. Klasseraum hinzu
        throw new NotImplementedException("Not yet implemented.");

        // Erstelle drei Schüler:innen für jede der Klassen
        throw new NotImplementedException("Not yet implemented.");

        // Setze 3 Schüler:innen auf die Tische in einer Klasse und 2 Schüler:innen auf Tische in die andere Klasse
        throw new NotImplementedException("Not yet implemented.");

        // Setze den fehlenden Schüler auf eine noch nicht der Klasse hinzugefügten Tisch
        throw new NotImplementedException("Not yet implemented.");

        // Erstelle zwei Lehrer:innen
        throw new NotImplementedException("Not yet implemented.");

        // Einer der Lehrer:innen sucht (auf welchen Desk soll er/sie schauen?) schnell einen Schüler deiner Wahl.
        // Gib dazu diesen mit dessen Tisch aus. Es reicht das Objekt auf die konsole auszugeben. Es muss kein Menschen lesbarer Text verwendet werden.
       throw new NotImplementedException("Not yet implemented.");

        // Gibt alle Schüler inklusive Tisch in der Schule auf die Console aus.
        Console.WriteLine("\nStudents in the classroom:");
        throw new NotImplementedException("Not yet implemented.");
    }
}
```

### Theorie [10 / 50 Teilpunkte]
* Unsere `Felder` bzw. `Hat-Beziehungen` hier sind als `private` gekennzeichnet. Nenne Gründe warum dies sinnvoll sein kann.
* Erkläre die grundlegende Funktion einer `Liste` im Vergleich zu einem `Dictionary` (es muss nicht auf Implementierungen, wie LinkedList oder ArrayList eingegangen werden).
* Nenne Situationen wann es sinnvoll erscheint ein `Dictionary` zu verwenden?


