# Modultest 1 - JET AP10

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

* Die Abgabe des Programmcodes erfolgt über Teams (ein zip-File des Projektes mir bis spätestens 10:15 schicken)
* Viel Erfolg! :)

Notenschlüssel:
[0-50): N5; [50-62.5%): G4; [62.5-75%): B3; [75-87.5%): G2; [87.5-100%]: S1., (Schulnotensystem)

---

## Guard Clauses [35 / 100 Punkte]

### Programmverständnis [10 / 35 Teilpunkte]
Gegeben ist folgender Code welcher eine Guard Clause darstellt. Die Felder (Eigenschaften) der Objekte der Klasse Pilot haben den Typ `bool`.

```csharp
if (kunde == null)
    throw new ArgumentNullException("Kunde darf nicht null sein.");

if (!kunde.IstAktiv)
{
    Console.WriteLine("Der Kunde ist nicht aktiv. Vorgang abgebrochen.");
    return;
}
else 
{
    Console.WriteLine("Der Kunde ist aktiv.");
    return;
}

if (!string.IsNullOrEmpty(kunde.Kundenkarte))
{
    Console.WriteLine("Der Kunde hat keine Kundenkarte.");
}

if (kunde.MitgliedschaftGueltigBis <= DateTime.Now || true)
    throw new KundenCheckException("Die Mitgliedschaft des Kunden ist abgelaufen.");

Console.WriteLine("Alle Überprüfungen bestanden. Der Kunde darf einkaufen!");
```

 - a) Finde die Fehler in diesem Code und markiere diese.
 - b) Erkläre wieso diese Fehler zu einer nicht gültigen bzw. konzeptionellen falschen `Guard Clause` führen. 

---

### Programmieren [20 / 35 Teilpunkte]
Schreibe folgendes `nested (verschachteltes) IF` als `Guard Clause` um.
(Hinweis: alle ❗ sind Teil der `Guards`, alle ✅ sind Teil der `gültigen Zustände`)

Erstelle dazu ein Projekt in `Visual Studio` (oder einem Editor deiner Wahl) und kopiere den `gesamten Code` in ein `Programm.cs` File.

```csharp
using System;
using System.Text;

public class Produkt
{
    public bool IstPremium { get; set; }
    public decimal Preis { get; set; }
}

public class Kunde
{
    // Eigenschaften / Felder
    public bool IstAktiv { get; set; }
    public int Alter { get; set; }
    public string Kundenkarte { get; set; }
    public DateTime MitgliedschaftGueltigBis { get; set; }
    public int Bestellhistorie { get; set; }
    public decimal Budget { get; set; }
    public bool IstKreditwürdig{ get; set; }

    // Hat-Beziehungen
    public Produkt Produkt { get; set; }

    public void ValidateKunde()
    {
        if (IstAktiv)
        {
            if (Alter >= 21)
            {
                if (!string.IsNullOrEmpty(Kundenkarte))
                {
                    if (MitgliedschaftGueltigBis > DateTime.Now)
                    {
                        if (Produkt.IstPremium)
                        {
                            if (Bestellhistorie > 20)
                            {
                                if (Produkt.Preis > Budget)
                                {
                                    if (IstKreditwürdig)
                                    {
                                        Console.WriteLine("✅ Kunde hat mehr als 20 Bestellungen und hat einen Kredit. Dieser Kunde darf Premium-Produkte kaufen.");
                                    }
                                    else 
                                    {
                                        Console.WriteLine("❗ Kunde benötigt einen Kredit, da das Produkt zu teuer ist.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("✅ Kunde hat mehr als 20 Bestellungen. Dieser Kunde darf Premium-Produkte kaufen.");
                                }
                            }
                            else
                            {
                                throw new InvalidOperationException("❗ Kunde hat zu wenig Bestellungen für Premium-Produkte.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("✅ Kunde darf das Produkt kaufen.");
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("❗ Die Mitgliedschaft des Kunden ist abgelaufen.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("❗ Kunde wird gefragt ob eine Kundenkarte erwünscht ist. Diese:r ist generft und geht aus dem Geschäft.");
                }
            }
            else
            {
                throw new InvalidOperationException("❗ Kunde muss mindestens 21 Jahre alt sein.");
            }
        }
        else
        {
            throw new InvalidOperationException("❗ Kunde ist nicht aktiv.");
        }
    }

    public void ValidateKundeGuardClause()
    {
        // Guards: ungültige Zustände 
        //TODO: implement me
        throw new NotImplementedException();

        // Gültige: ungültige Zustände 
        //TODO: implement me
        throw new NotImplementedException();
    }
}

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Kunde kunde = new Kunde
        {
            IstAktiv = true,
            Alter = 25,
            Kundenkarte = "GoldCard",
            MitgliedschaftGueltigBis = DateTime.Now.AddMonths(12),
            Bestellhistorie = 15,
            Budget = 1000,
            Produkt = new Produkt { IstPremium = true, Preis = 10005 }
        };

        try
        {
            kunde.ValidateKunde();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Fehler: {ex.Message}");
        }

        try
        {
            kunde.ValidateKundeGuardClause();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Fehler: {ex.Message}");
        }
    }
}
```

---

### Theorie [5 / 35 Teilpunkte]
* a) Warum brauchen wir ``try-catch`` Blöcke in der ``Main`` Methode für ``kunde.ValidateKunde();`` und ``kunde.ValidateKundeGuardClause();``? Was wäre der Unterschied wenn beide Methodenaufrufe in einem ``try-catch`` Block wären?
* b) Die gültigen Zustände des Programms sind mit ✅ gekennzeichnet. Können diese zu einem gültigen Zustand ✅ Zusammengefasst werden? 

---

## Muster erstellen [25 Punkte]
### Programmverständnis [10 / 25 Teilpunkte]
Gegeben ist folgendes Muster
```
             x
       0 1 2  3 4  5
    0 🔺🟩🟦🔺🟦🟩
    1 🟩🟦🔺🟦🟩🔺
  y 2 🟦🔺🟦🟩🔺🟩
    3 🔺🟦🟩🔺🟩🟦
    4 🟦🟩🔺🟩🟦🔺
    5 🟩🔺🟩🟦🔺🟦
```
Überlege: 
* Was ist die ``Formel`` für ein *blaues* Feld? 
* Was ist die ``Formel`` für ein *grünes* Feld?
* Was ist die ``Formel`` für ein *rotes* Feld?

---

### Programmieren [15 / 25 Teilpunkte]
Erzeuge mithilfe von 2 verschachtelten ``for`` Schleifen das oben angegebene Muster. Erzeuge ein ``Multidimensionales String Array`` und weise diesem die Symbole 🟩🟦🔺 basierend auf einer ``if-Verzweigung`` zu. Verwende in dieser ``if-Verzweigung`` die oben erstellte ``Formel`` um zwischen den zu zeichnenden Symbolen 🟩🟦🔺zu unterscheiden. 

Verwende ``Console.OutputEncoding = Encoding.UTF8;`` um die verwendeten Symbole im Terminal darzustellen. 

Verwende für die Ausgabe folgende print Methode:
```csharp
static void Print(string[,] field)
{
    for (int y = 0; y < field.GetLength(0); y++)
    {
        for (int x = 0; x < field.GetLength(0); x++)
        {
            Console.Write(field[y, x]);
        }
        Console.WriteLine();
    }
}
```

---

## Klassen erstellen und Beziehung implementieren [40 Punkte]
### Programmverständnis [10 / 40 Teilpunkte]
Gehe auf folgende Fragen zu dem im Klassendiagramm angegebenen Inhalten.
* Ist die ``Beziehung`` zwischen ``Kunde`` und ``Kunde`` eine Hat-Beziehung oder Ist- Beziehung? Ist diese Bidirektional oder Unidirektional?
* Was bedeutet das neben der ``Methode`` *informieren* eingezeichnete **-**? Ist es sinnvoll die ``Methode`` sozu modellieren? Wenn ja, warum, wenn nein, was soll geändert werden?
* Ist die ``Beziehung`` *vertretet* eine Hat- oder Ist-Beziehung? Was bedeutet *1-n*?
* Die Hat-Beziehung zwischen *Shop* und *Employee* zwingt jedes `Objekt` der ``Klasse`` Employee zu allen Zeitpunkten mindestens einem *Shop* zugewiesen zu sein. Andererseits hat ein *Shop* mindestens einen *Employee*. Tritt bei der Erstellung der ``Objekte`` *Shop* und *Employee* dadurch ein Problem auf?

![alt](https://raw.githubusercontent.com/MrStrelow/BBRZ/refs/heads/main/JET/modul_1_c%23_basics/ModulTest/VergangeneTests/ModulTest_AP10_2025_03/exam_dark.png)


---

### Programmieren [25 / 40 Teilpunkte]

Implementiere das oben angegebene Klassendiagramm in C#
* ``Definiere`` dazu zuerst die ``Klassen`` sowie dessen ``Mitglieder`` und ``Beziehungen`` (Erstelle nur Get und Set Methoden welche im weiten Code benötigt werden). 
* Wähle die ``Parameter`` der ``Konstruktoren`` nach eigenem Ermessen. Füge jedoch einen ``Copy-Konstruktor`` in den Klassen ``Shop``, ``Kunden`` und ``Employee`` ein. Vergiss nicht den Aufruf des ``Konstruktors`` der ``Basisklasse`` bei den ``Ist-Beziehungen``.
* ``Implementiere`` danach die unten angegebenen ``Methoden``.
* Erstelle eine ``Main-Klasse`` welches die zu implementierenden ``Methoden`` aufruft. Ein Implementierungsvorschlag dazu ist bereits weiter [unten](#hilfestellung) zu finden.

Implementiere folgendes `Verhalten` mit `Methoden`:
* `Kunden` können sich über ein ``Produkt`` bei einem ihnen *bekannten* ``Kunden`` informieren. Das geschieht über den aufruf der ``informieren`` Methode. Gib dazu im Terminal aus, über welches Produkt und wer sich darüber informiert hat. Falls kein bekannter ``Kunde`` existiert soll eine ``Exception`` geworfen werden, falls die Methode `informieren` aufgerufen wird.
* Einem ``Shop`` soll es möglich sein einen ``Employee`` einem anderen Shop zu übergeben. Dies geschieht mit der Methode ``relocate``. Falls kein PartnerShop existiert, soll eine Exception geworfen werden.

---

#### **Hilfestellung:**

Testprogramm:
```csharp
public class Program
{
    public static void Main(string[] args)
    {
        Employee emp1 = new Employee(name: "Alice", salary: 3000);
        Employee emp2 = new Employee(name: "Bob", salary: 3000);

        Shop shopB = new Shop(oenaceCode: "DE67890", myFirstEmployee: emp2);
        Shop shopA = new Shop(oenaceCode: "AT12345", myFirstEmployee: emp1, partnerShop: shopB);

        Kunde kunde1 = new Kunde("Max", shopA);
        Kunde kunde2 = new Kunde("Anna", shopA, kunde1);

        kunde2.Informieren(Produkt.Laptop);

        try
        {
            shopA.Relocate(emp1);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        shopA.PrintEmployees();
        
        // Erstellt eine Kopie von Shop A
        Shop shopACopy = new Shop(shopA);
    }
}
```

Shop:
```csharp
public class Shop
{
    // Felder
    // TODO: implement me

    // Hat-Beziehungen
    // TODO: implement me

    // Konstruktoren
    public Shop(string oenaceCode, Employee myFirstEmployee, Shop partnerShop = null)
    {
        // TODO: implement me

        if (partnerShop is not null)
        {
            // TODO: implement me 
            // Achtung! Bidirektionale Beziehung.
        }
    }

    public Shop(Shop toCopy)
    {
        // TODO: implement me

        this.kunden = new List<Kunde>();
        foreach (var kunde in toCopy.kunden)
        {
            this.kunden.Add(new Kunde(kunde));
        }

        this.employees = new List<Employee>();
        foreach (var employee in toCopy.employees)
        {
            this.employees.Add(new Employee(employee));
        }
    }

    // Methoden
    public void Relocate(Employee employee)
    {
        // TODO: implement me

        // print den Zustand vor der Veränderung
        Console.WriteLine($"Shop: {GetHashCode()}");
        this.PrintEmployees();

        Console.WriteLine($"Shop: {partnerShop.GetHashCode()}");
        partnerShop.PrintEmployees();

        // TODO: implement me

        // print den Zustand nach der Veränderung
        Console.WriteLine($"Shop: {GetHashCode()}");
        this.PrintEmployees();

        Console.WriteLine($"Shop: {partnerShop.GetHashCode()}");
        partnerShop.PrintEmployees();
    }

    public void PrintEmployees()
    {
        foreach (var emplyee in employees)
        {
            Console.WriteLine(emplyee.GetName());
        }
    }
}
```

---

### Theorie [5 / 40 Teilpunkte]
* Erkläre was eine Hat und was eine Ist Beziehung darstellen soll. Welche Beziehung erweitert das Verhalten einer Bestehenden Klasse und welche erlaubt zugriffe auf ein anderes Objekt?



