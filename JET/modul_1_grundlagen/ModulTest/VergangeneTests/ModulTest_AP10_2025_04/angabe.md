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
if (kunde is not null)
    throw new ArgumentNullException("Kunde darf nicht null sein.");

if (!kunde.IstAktiv)
{
    Console.WriteLine("Der Kunde ist nicht aktiv.");
    return;
}

if (string.IsNullOrEmpty(kunde.Kundenkarte))
{
    return;
    Console.WriteLine("Der Kunde hat keine Kundenkarte.");
}

if (kunde.MitgliedschaftGueltigBis >= DateTime.Now)
    throw new User("Die Mitgliedschaft des Kunden ist abgelaufen.");
else 
    Console.WriteLine("Die Mitgliedschaft des Kunden ist gültig.");

Console.WriteLine("Alle Überprüfungen bestanden. Der Kunde darf einkaufen!");
```

 - a) Finde die Fehler in diesem Code und markiere diese.
 - b) Erkläre wieso diese Fehler zu einer nicht gültigen bzw. konzeptionellen falschen `Guard Clause` führen. 

---

### Programmieren [20 / 35 Teilpunkte]
Schreibe folgendes `nested (verschachteltes) IF` als `Guard Clause` um.
(Hinweis: alle ❗ sind Teil der `Guards`, alle ✅ sind Teil der `gewünschten Zustände`)

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
                                    throw new InvalidOperationException("❗ Kunde darf das Premium-Produkt nicht kaufen. Zu wenig Geld.");
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
                            if (Produkt.Preis > Budget)
                            {
                                if (IstKreditwürdig)
                                {
                                    Console.WriteLine("✅ Kunde hat einen Kredit. Dieser Kunde darf das Produkt kaufen.");
                                }
                                else 
                                {
                                    throw new InvalidOperationException("❗ Kunde benötigt einen Kredit, da das Produkt zu teuer ist.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("✅ Kunde darf das Produkt kaufen.");
                            }
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
        // Guards: ungewünschte Zustände 
        //TODO: implement me
        throw new NotImplementedException();

        // gewünschte Zustände 
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
            Alter = 26,
            IstKreditwürdig = true,
            Kundenkarte = "GoldCard",
            MitgliedschaftGueltigBis = DateTime.Now.AddMonths(12),
            Bestellhistorie = 21,
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
* a) Was ist der Unterschied zwischen einer ``If-Verzweigung`` und einer ``If-Bedingung``?
* b) Gegeben ist eine ``If-Verzweigung`` (if mit else). Was ist die ``logische Formel`` des ``else`` Zweigs, wenn die ``logische Formel`` für den ``if`` Zweig ``alter > 25`` ist?
* c) Kann eine ``If-Verzweigung`` das gleiche Verhalten wie eine ``If-Bedingung`` haben? Vergleiche dazu folgenden Code.
```csharp
if (false) 
{
    Console.WriteLine("If-Zweig")
} 
else 
{
    Console.WriteLine("Else-Zweig")
}
```

vs.

```csharp
if (false) 
{
    Console.WriteLine("If-Bedingung")
} 

if (true) 
{
    Console.WriteLine("Auch eine IF-Bedingung")
}
```


---

## Muster erstellen [25 Punkte]
### Programmverständnis [10 / 25 Teilpunkte]
Gegeben ist folgendes Muster
```
             x
       0 1 2  3 4  5
    0 🔺🟩🟦🔺🟩🟦
    1 🟩🟦🔺🟩🟦🔺
  y 2 🟦🔺🟩🟦🔺🟩
    3 🔺🟩🟦🔺🟩🟦
    4 🟩🟦🔺🟩🟦🔺
    5 🟦🔺🟩🟦🔺🟩
```
Überlege: 
* Was ist die ``Formel`` für ein *blaues* Feld? 
* Was ist die ``Formel`` für ein *grünes* Feld?
* Was ist die ``Formel`` für ein *rotes* Feld?

---

### Programmieren [15 / 25 Teilpunkte]
Erzeuge mithilfe von 2 verschachtelten ``For-Schleifen`` das oben angegebene Muster. Erzeuge ein ``Multidimensionales String Array`` und weise diesem die Symbole 🟩🟦🔺 basierend auf einer ``if-Verzweigung`` zu. Verwende in dieser ``If-Verzweigung`` die oben erstellte ``Formel`` um zwischen den zu zeichnenden Symbolen 🟩🟦🔺zu unterscheiden. 

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
* Ist die ``Beziehung`` zwischen ``Shop`` und ``Employee`` eine ``Hat-Beziehung`` oder ``Ist-Beziehung``?
* Was bedeutet das neben der ``Methode`` *relocateEmployee* eingezeichnete **+**? Ist es sinnvoll die ``Methode`` mit **+** zu modellieren? Wenn ja, warum, wenn nein, was soll geändert werden?
* Ist die ``Beziehung`` *partnerShop* eine Hat- oder Ist-Beziehung? Was bedeutet *0-1*?
* Hat ein ``RetailKunde`` die Möglichkeit ``Produkte`` mithilfe der ``Methode``  zu kaufen?

![alt](https://raw.githubusercontent.com/MrStrelow/BBRZ/refs/heads/main/JET/modul_1_grundlagen/ModulTest/Angabe/exam_dark.png)


---

### Programmieren [25 / 40 Teilpunkte]
Implementiere Teile aus dem oben angegebene Klassendiagramm in C#
1) Verwende die unten zur Verfügung gestellte ``Main-Klasse``. Diese ist [hier](#hilfestellung) zu finden. 
2) ``Definiere`` dazu zuerst die ``Klassen`` sowie dessen ``Mitglieder`` und ``Beziehungen`` (Erstelle nur Get und Set Methoden welche im weiten Code benötigt werden). *Empfehlung: Verwende die Fehler in der zur verfügung gestellten Main-Methode als "Bauplan" für die Aufgabe. Versuche Fehler welche als rot-markiert werden, schrittweise "nicht mehr rot" zu machen. Starte dazu mit der 1. Anweisung ``Employee alice = new Employee(name: "Alice", salary: 3000);`` und kommentiere die restlichen Zeilen aus. Gehe danach zur nächsten Zeile. usw.*
3) Wähle die ``Parameter`` der ``Konstruktoren`` nach eigenem Ermessen. Füge jedoch einen ``Copy-Konstruktor`` in den Klassen ``Shop``, ``Kunden`` und ``Employee`` ein. Vergiss nicht den Aufruf des ``Konstruktors`` der ``Basisklasse`` bei den ``Ist-Beziehungen``.
4) ``Implementiere`` nun die unten angegebenen ``Methoden``.

Implementiere folgendes `Verhalten` mit `Methoden`:
1) Einem ``Kunden`` soll es möglich sein ``Produkte`` zu kaufen. Falls ein Kunde die ``Methode`` *kaufen* aufruft, wird dem ``Shop`` in welchem der ``Kunde`` einkauft ein... 
    * Fixbetrag von ``1.000,00€`` in die *kassa* übergeben. 
    * Falls das ``Produkt`` jedoch ein *Papierflieger* ist, wird **anstatt** der ``1.000,00€``, ``2,50€`` übergeben. 
    * Falls das ``Produkt`` jedoch  100g *Goldbarren* ist, **anstatt** der ``1.000,00€`` ``10.000,00€`` (zehntausend). 
*Hinweis: Implementiere falls notwendig, ``Get-`` sowie ``Set-Methoden`` um von anderen ``Klassen`` auf ``Felder`` zugreifen zu können. Es ist nicht notwenedig für alle ``Felder`` eine ``Get-`` sowie ``Set-Methode`` zu implementieren.*
2) **``[Bonus Aufgabe]``** `Employees` können durch die Methode ``working`` Geld pro Aufruf dieser ``Methode`` verdienen. Verringere dazu das ``Feld`` *kassa* im ``Shop`` in welchem der ``Employee`` arbeitet um den Wert des ``Feldes`` *salary*. Ist die *kassa* leer, muss der Shop sich Geld aus dem partner shop ausleihen. Hat der ``Shop`` keinen *partnerShop* oder auch dieser hat kein Geld mehr, bekommt der ``Employee`` das existierende Geld. Falls nichts vorhanden ist, bekommt dieser nichts. 
---

#### **Hilfestellung:**
Testprogramm:
```csharp
public class Program
{
    public static void Main(string[] args)
    {
        Employee alice = new Employee(name: "Alice", salary: 3000);
        Employee bob = new Employee(name: "Bob", salary: 3000);

        Shop shopB = new Shop(oenaceCode: "DE67890", myFirstEmployee: bob);
        Shop shopA = new Shop(oenaceCode: "AT12345", myFirstEmployee: alice, partnerShop: shopB);

        Kunde max = new Kunde("Max", shopB);
        Kunde hannah = new Kunde("Anna", shopA, max);

        for (int i = 0; i < 10; i++) 
        {
            max.kaufen(Produkt.Papierflieger);
        }

        hannah.kaufen(Produkt.Goldbarren);
        hannah.Kaufen(Produkt.Goldbarren);

        Kunde sanna = new Kunde(hannah);

        // BONUS Aufgabe!
        // for (int i = 0; i < 4; i++)
        // {
        //     alice.Working();
        // }

        // for (int i = 0; i < 4; i++)
        // {
        //     bob.Working();
        // }
        
        // Erstellt eine Kopie von Shop A
    }
}
```

Employee:
```csharp
public class Employee
{
   // Felder
    // TODO: implement me

    // Hat-Beziehungen
    // TODO: implement me

    // Konstruktoren
    public Employee(string name, double salary)
    {
       // TODO: implement me
    }

    // Implementiere diese MEthode für die Bonus Aufgabe!
    public void Working()
    {
        double payment;

        // TODO: implement me

        // {payment:C} ist die Kurzform von payment.ToString("C"); und gibt der Zahl eine "Currency"-Formatierung wie (1.50€).
        Console.WriteLine($"{name} hat im Shop {workplace.GetHashCode()} - {payment:C} verdient. Das Gehalt ist {salary:C}. Kassa: {workplace.GetKassa():C} - Kassa Partner: {workplace.GetPartnerShop().GetKassa():C}");
    }
}
```

Kunde:
```csharp
public class Kunde
{
    // Felder
    // TODO: implement me

    // Hat-Beziehungen
    // TODO: implement me

    // Konstruktoren
     public Kunde(string name, Shop shop, Kunde bekannter)
    {
       // TODO: implement me
    }

    // Implementiere diese Methode für die Bonus Aufgabe!
    public void Kaufen(Produkt produkt)
    {
        // TODO: implement me

        /// {preis:C} ist die Kurzform von preis.ToString("C"); und gibt der Zahl eine "Currency"-Formatierung wie (1.50€).
        Console.WriteLine($"{name} hat {produkt} für {preis:C} gekauft. Kassa von Shop {shop.GetHashCode()}: {shop.GetKassa():C}");
    }
}
```

Erwarteter Output:
```
Max hat Papierflieger für $2.50 gekauft. Kassa von Shop 55915408: $2.50
Max hat Papierflieger für $2.50 gekauft. Kassa von Shop 55915408: $5.00
Max hat Papierflieger für $2.50 gekauft. Kassa von Shop 55915408: $7.50
Max hat Papierflieger für $2.50 gekauft. Kassa von Shop 55915408: $10.00
Max hat Papierflieger für $2.50 gekauft. Kassa von Shop 55915408: $12.50
Max hat Papierflieger für $2.50 gekauft. Kassa von Shop 55915408: $15.00
Max hat Papierflieger für $2.50 gekauft. Kassa von Shop 55915408: $17.50
Max hat Papierflieger für $2.50 gekauft. Kassa von Shop 55915408: $20.00
Max hat Papierflieger für $2.50 gekauft. Kassa von Shop 55915408: $22.50
Max hat Papierflieger für $2.50 gekauft. Kassa von Shop 55915408: $25.00
Anna hat Goldbarren für $10,000.00 gekauft. Kassa von Shop 33476626: $10,000.00
Anna hat Goldbarren für $10,000.00 gekauft. Kassa von Shop 33476626: $20,000.00
```

Erwarteter Output - Bonus:
```
Alice hat im Shop 33476626 - $3,000.00 verdient. Das Gehalt ist $3,000.00. Kassa: $17,000.00 - Kassa Partner: $25.00
Alice hat im Shop 33476626 - $3,000.00 verdient. Das Gehalt ist $3,000.00. Kassa: $14,000.00 - Kassa Partner: $25.00
Alice hat im Shop 33476626 - $3,000.00 verdient. Das Gehalt ist $3,000.00. Kassa: $11,000.00 - Kassa Partner: $25.00
Alice hat im Shop 33476626 - $3,000.00 verdient. Das Gehalt ist $3,000.00. Kassa: $8,000.00 - Kassa Partner: $25.00
Bob hat im Shop 55915408 - $3,000.00 verdient. Das Gehalt ist $3,000.00. Kassa: $0.00 - Kassa Partner: $5,025.00
Bob hat im Shop 55915408 - $3,000.00 verdient. Das Gehalt ist $3,000.00. Kassa: $0.00 - Kassa Partner: $2,025.00
Bob hat im Shop 55915408 - $2,025.00 verdient. Das Gehalt ist $3,000.00. Kassa: $0.00 - Kassa Partner: $0.00
Bob hat im Shop 55915408 - $0.00 verdient. Das Gehalt ist $3,000.00. Kassa: $0.00 - Kassa Partner: $0.00
```

---

### Theorie [5 / 40 Teilpunkte]
* Ist es vorteilhaft eine ``Methode`` an ein ``Objekt`` zu koppeln? Denke an folgendes Beispiel
```csharp
kunde.Informieren(); // Methode aufrufbar beim Objekt
```

vs.

```csharp
Informieren(willInformiertWerden: kunde, informiertAnderen: bekannterDesKunden); // Funktion welche 2 beliebige Kunden entgegennimmt 
```




