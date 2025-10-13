Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Schleifen
* Guard-Clauses
* Jagged Arrays und Multidimensional Arrays
* User-Input
* Operatoren
* Methoden

Welche ``Denkweisen`` üben wir hier?
* Wie finde ich eine logische Formel für ein grafisches Muster?

Bei Unklarheiten hier nachlesen:
* [Was sind Jagged und Multidimensional Arrays?](../../L03KontrollstrukturenUndFunktionen/Skripten/L03.5JaggedUndMultidimensionalArrays.md)

# Tic-Tac-Toe 

Erstellen Sie eine Konsolenanwendung, die zwei verschiedene Arten von Tic-Tac-Toe implementiert. 

## 1.1 Launcher (Top-Level Statements)

Der Einstiegspunkt Ihrer Anwendung soll eine Top-Level-Statement-Datei (`Program.cs`) sein. Diese Datei hat folgende Aufgaben:
* Sicherstellen, dass die Konsole Emojis korrekt darstellt.
* Begrüßung des Benutzers.
* Erstellen einer Instanz von `StandardGame` und Aufrufen dessen Start-Methode.
* Warten auf eine Benutzereingabe, bevor das nächste Spiel gestartet wird.
* Erstellen einer Instanz von `JaggedGame` und Aufrufen dessen Start-Methode.
* Ausgabe einer abschließenden Nachricht.

### 1.2 Status Enum
Definieren Sie ein `enum`, das den Zustand des Spiels repräsentiert. Dieses `enum` soll für beide Spielklassen zugänglich sein.

```csharp
public enum Status
{
    GEWONNEN,
    UNENTSCHIEDEN,
    IMGANGE
}
```

---

## 2. Spiel 1: Das klassische Tic-Tac-Toe
Implementieren Sie ein Standard 3x3 Tic-Tac-Toe in der Klasse `StandardGame` innerhalb des Namespace `StandardTicTacToe`.

### 2.1 Anforderungen
* **Datenstruktur:** Verwenden Sie ein zweidimensionales Array (`string[,]`) für das 3x3-Spielfeld.
* **Symbole:**
    * Spieler 1: `🔴`
    * Spieler 2: `🔵`
    * Spielfelder: Initialisieren Sie das Brett mit den Zahlen als Text (`"1"`, `"2"`, ..., `"9"`), um dem Benutzer die Auswahl zu erleichtern.
* **Spiellogik:**
    * Die Spieler wählen abwechselnd ein Feld durch Eingabe einer Zahl von 1-9.
    * Implementieren Sie eine robuste Eingabeschleife, die ungültige Eingaben (keine Zahl, Zahl außerhalb des Bereichs, Feld bereits belegt) abfängt und den Benutzer erneut zur Eingabe auffordert. Verwenden Sie hierfür eine `while(true)`-Schleife mit "Guard Clauses".
    * Das Spiel endet bei einem Sieg (3 gleiche Symbole in einer Reihe, Spalte oder Diagonale) oder einem Unentschieden (alle 9 Felder belegt).
* **Struktur:** Gliedern Sie den Code in private Methoden wie `SpielbrettAusgeben()`, `FeldBelegen(int, string)` und `GewinnerPruefen()`.

---

## 3. Spiel 2: Das variable Tic-Tac-Toe

Implementieren Sie eine erweiterte Version von Tic-Tac-Toe in der Klasse `JaggedGame`. Diese Version wird auf einem vom Benutzer definierten, unregelmäßigen Spielfeld gespielt.

### 3.1 Anforderungen

* **Datenstruktur:** Verwenden Sie ein **Jagged Array** (`string[][]`).
* **Symbole:**
    * Spieler 1: `🔴`
    * Spieler 2: `🔵`
    * Leere Felder: `🟦`
* **Spiellogik:**
    * **Initialisierung:** Bevor das Spiel startet, fragen Sie den Benutzer nach der Anzahl der Zeilen. Anschließend fragen Sie für jede Zeile einzeln nach der gewünschten Anzahl an Spalten. Erstellen Sie das Jagged Array dynamisch basierend auf diesen Eingaben.
    * **Spielzüge:** Die Spieler wählen ein Feld durch Eingabe von Koordinaten (z.B. `"1 2"` für Zeile 1, Spalte 2).
    * **Siegbedingung:** Ein Sieg wird durch **3** (`SiegAnzahl = 3`) gleiche Symbole in einer Reihe erzielt (horizontal, vertikal oder in beide Diagonalrichtungen).
    * **Gewinnprüfung:** Implementieren Sie die `GewinnerPruefen()`-Methode **ohne Verwendung von LINQ**. Sie müssen klassische `for`-Schleifen verwenden. Die Logik muss robust genug sein, um die unregelmäßige Struktur des Bretts zu berücksichtigen und "Index out of Bounds"-Fehler zu vermeiden, insbesondere bei der vertikalen und diagonalen Prüfung.
    * Das Spiel endet bei einem Sieg oder einem Unentschieden (alle Felder belegt).
* **Struktur:** Gliedern Sie den Code in private Methoden wie `FeldInitialisieren()`, `SpielbrettAusgeben()` und `GewinnerPruefen(string)`.

## Vorlage
```csharp
// StandardGame.cs

using System.Text;

// Top - Level Statement
Console.OutputEncoding = Encoding.UTF8;

StandardGame standard = new StandardGame();
//standard.Starten();

JaggedGame jagged = new JaggedGame();
jagged.Starten();

// Klassen und Namespaces für Übungen
// ########################################## Übung 1 ##########################################
enum Status
{
    GEWONNEN, UNENTSCHIEDEN, IMGANGE
}

// Übung 1
public class StandardGame
{
    private const string SpielerEins = "🔴"; // Roter Kreis
    private const string SpielerZwei = "🔵"; // Blauer Kreis

    private string[,] brett;
    private string aktuellerSpieler;
    private int anzahlZuege;

    public StandardGame()
    {
        // multidimensional array
        brett = new string[3, 3]
        {
            { "1", "2", "3" },
            { "4", "5", "6" },
            { "7", "8", "9" }
        };
        aktuellerSpieler = SpielerEins;
        anzahlZuege = 0;
    }

    public void Starten()
    {
        Status spielStatus; 
            
        do
        {
            Console.Clear();
            Console.WriteLine("--- Standard Tic-Tac-Toe (3x3) ---");
            SpielbrettAusgeben();

            int auswahl = -1;
            bool guardsUeberstanden = false;

            while (!guardsUeberstanden)
            {
                // ❌ ungewünschte Zustände
                // 1) User gibt keine Zahl ein.
                Console.WriteLine($"\nSpieler {aktuellerSpieler} ist am Zug.");
                Console.Write("Wähle ein freies Feld (1-9): ");
                string userEingabe = Console.ReadLine();

                while (!int.TryParse(userEingabe, out auswahl))
                {
                    Console.WriteLine($"Ungültige Eingabe - {userEingabe} - Zahl zwischen 1 und 9 eingeben.");
                    Console.Write("Wähle ein freies Feld (1-9): ");
                    userEingabe = Console.ReadLine();
                }

                // 2) User gibt Zahlen außerhalb von 1 und 9 ein
                if (!(1 <= auswahl && auswahl <= 9))
                {
                    Console.WriteLine("Ungültige Eingabe!");
                    continue;
                }

                // Rechne den Zeilen- und Spaltenindex der Auswahl aus.
                int zeile = (auswahl - 1) / 3;
                int spalte = (auswahl - 1) % 3;

                // 3) Feld ist bereits belegt
                if (brett[zeile, spalte] == SpielerEins || brett[zeile, spalte] == SpielerZwei)
                {
                    Console.WriteLine("Dieses Feld ist bereits belegt!");
                    continue;
                }

                // ✅ gewünschter Zustand
                guardsUeberstanden = true;
            }

            FeldBelegen(auswahl, aktuellerSpieler);
            anzahlZuege++;

            if (GewinnerPruefen())
            {
                spielStatus = Status.GEWONNEN;
            }
            else if (anzahlZuege == 9)
            {
                spielStatus = Status.UNENTSCHIEDEN;
            }
            else
            {
                spielStatus = Status.IMGANGE;
                aktuellerSpieler = (aktuellerSpieler == SpielerEins) ? SpielerZwei : SpielerEins;
            }

        } while (spielStatus == Status.IMGANGE);

        Console.Clear();
        Console.WriteLine("🏁 Spiel beendet! 🏁");
        SpielbrettAusgeben();

        if (spielStatus == Status.GEWONNEN)
        {
            Console.WriteLine($"\n🏆 Herzlichen Glückwunsch! Spieler {aktuellerSpieler} hat gewonnen! 🏆");
        }
        else
        {
            Console.WriteLine("\n🤝 Unentschieden! 🤝");
        }
    }

    private void SpielbrettAusgeben()
    {
        Console.WriteLine("-------------");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"| {brett[i, 0]} | {brett[i, 1]} | {brett[i, 2]} |");
            Console.WriteLine("-------------");
        }
    }

    private void FeldBelegen(int position, string spieler)
    {
        int zeile = (position - 1) / 3;
        int spalte = (position - 1) % 3;
        brett[zeile, spalte] = spieler;
    }

    private bool GewinnerPruefen()
    {
        // Logik der Guards - nur umgekehrt - wir haben einen early exit wenn wir wissen es hat wer gewonnen
        for (int i = 0; i < 3; i++)
        {
            // für jede Zeile, Prüfe ob immer das gleiche Symbol dort ist.
            if (brett[i, 0] == brett[i, 1] && brett[i, 1] == brett[i, 2]) 
                return true;

            // für jede Spalte, Prüfe ob immer das gleiche Symbol dort ist.
            if (brett[0, i] == brett[1, i] && brett[1, i] == brett[2, i]) 
                return true;
        }
            
        // Haupt-Diagonale ist gleich
        if (brett[0, 0] == brett[1, 1] && brett[1, 1] == brett[2, 2]) 
            return true;

        // Neben-Diagonale ist gleich
        if (brett[0, 2] == brett[1, 1] && brett[1, 1] == brett[2, 0]) 
            return true;

        // niemand hat gewonnen, also muss false zurückgegeben werden
        return false;
    }
}

// ########################################## Übung 2 ##########################################
public class JaggedGame
{
    private string SpielerEins = "🔴";
    private string SpielerZwei = "🔵";
    private string LeerFeld = "🟦";
    private int SiegAnzahl = 3;

    // Jagged Array
    private string[][] brett; 

    private string aktuellerSpieler;
    private int anzahlZuege;
    private int maxZuege;

    public void Starten()
    {
        FeldInitialisieren(); // Zuerst das Feld vom Benutzer erstellen lassen
        Status spielStatus;

        do
        {
            Console.Clear();
            Console.WriteLine("--- Variables Tic-Tac-Toe (Jagged Array) ---");
            SpielbrettAusgeben();

            int zeile = -1, spalte = -1;
            bool guardsUeberstanden = false;

            while (!guardsUeberstanden)
            {
                Console.WriteLine($"\nSpieler {aktuellerSpieler} ist am Zug.");
                Console.Write("Gib Zeile und Spalte ein (z.B. '1 2'): ");
                string[] input = Console.ReadLine().Split(' ');

                if (...) // TODO
                {
                    Console.WriteLine("Ungültige Eingabe! Bitte im Format 'Zeile Spalte' eingeben.");
                    continue;
                }
                
                if (...) // TODO
                {
                    Console.WriteLine("Eingabe außerhalb des Spielfelds!");
                    continue;
                }

                if (...) // TODO
                {
                    Console.WriteLine("Dieses Feld ist bereits belegt!");
                    continue;
                }

                guardsUeberstanden = true;
            }

            brett[zeile - 1][spalte - 1] = aktuellerSpieler;
            anzahlZuege++;

            if (GewinnerPruefen(aktuellerSpieler))
            {
                spielStatus = Status.GEWONNEN;
            }
            else if (anzahlZuege == maxZuege)
            {
                spielStatus = Status.UNENTSCHIEDEN;
            }
            else
            {
                spielStatus = Status.IMGANGE;
                aktuellerSpieler = (aktuellerSpieler == SpielerEins) ? SpielerZwei : SpielerEins;
            }

        } while (spielStatus == Status.IMGANGE);

        Console.Clear();
        Console.WriteLine("🏁 Spiel beendet! 🏁");
        SpielbrettAusgeben();

        if (spielStatus == Status.GEWONNEN)
        {
            Console.WriteLine($"\n🏆 Herzlichen Glückwunsch! Spieler {aktuellerSpieler} hat gewonnen! 🏆");
        }
        else
        {
            Console.WriteLine("\n🤝 Unentschieden! 🤝");
        }
    }

    private void FeldInitialisieren()
    {
        Console.Clear();
        Console.WriteLine("--- Konfiguration des variablen Spielfelds ---");
        Console.Write("Geben Sie die Anzahl der Zeilen ein (mind. 3): ");

        int anzahlZeilen;
        string userEingabe = Console.ReadLine();
        while (!int.TryParse(userEingabe, out anzahlZeilen))
        {
            Console.Write($"Keine Zahl eingegeben - {userEingabe} - Bitte eine Zahl groeßer 3 eingeben.");
            Console.Write("Geben Sie die Anzahl der Zeilen ein (mind. 3): ");
            userEingabe = Console.ReadLine();
        }

            // TODO: Aufbau des Spiels - User gibt Zeilen und Spalten an - implement me
            throw new NotImplementedException();
            // Kurz, ohne zwei verschachtelte For-Schleifen.
            Array.Fill(brett[i], LeerFeld);
        }
    }

    private void SpielbrettAusgeben()
    {
        // Akzeptiere folgende Zeilen
        int maxSpalten = brett.Max(zeile => zeile.Length);
        string trennlinie = new string('-', maxSpalten * 4 + 1);
        Console.WriteLine(trennlinie);
        foreach (var zeile in brett)
        {
            Console.Write("|");
            foreach (var zelle in zeile)
            {
                Console.Write($" {zelle} |");
            }
            Console.WriteLine();
            Console.WriteLine(trennlinie);
        }
    }

    private bool GewinnerPruefen(string spieler)
    {
        // Iteriere durch jede Zelle des Bretts als möglichen Startpunkt einer Gewinnlinie
        for (int z = 0; z < brett.Length; z++)
        {
            for (int s = 0; s < brett[z].Length; s++)
            {
                // --- 1. Horizontale Prüfung (nach rechts) ---
                // Optimierung: Nur prüfen, wenn überhaupt genug Platz nach rechts ist.
                if (s + SiegAnzahl <= brett[z].Length)
                {
                    bool gewonnen = true; // Annahme: Es ist eine Gewinnlinie
                    for (int i = 0; i < SiegAnzahl; i++)
                    {
                        // Widerlege die Annahme, wenn ein Feld nicht dem Spieler gehört
                        if (brett[z][s + i] != spieler)
                        {
                            gewonnen = false;
                            break; // Die Linie ist unterbrochen, keine weitere Prüfung nötig
                        }
                    }
                    if (gewonnen) return true; // Annahme wurde nicht widerlegt -> Sieg!
                }

                // --- 2. Vertikale Prüfung (nach unten) ---
                // Optimierung: Nur prüfen, wenn genug Zeilen nach unten vorhanden sind.
                if (z + SiegAnzahl <= brett.Length)
                {
                    bool gewonnen = true;
                    for (int i = 0; i < SiegAnzahl; i++)
                    {
                        // WICHTIG: Prüfen, ob die Spalte in der unteren Zeile überhaupt existiert!
                        if (s >= brett[z + i].Length || brett[z + i][s] != spieler)
                        {
                            gewonnen = false;
                            break;
                        }
                    }
                    if (gewonnen) return true;
                }

                // --- 3. Diagonale Prüfung (rechts-unten) ---
                if (z + SiegAnzahl <= brett.Length)
                {
                    bool gewonnen = true;
                    for (int i = 0; i < SiegAnzahl; i++)
                    {
                        // WICHTIG: Prüfen, ob die Spalte in der unteren Zeile existiert!
                        if (s + i >= brett[z + i].Length || brett[z + i][s + i] != spieler)
                        {
                            gewonnen = false;
                            break;
                        }
                    }
                    if (gewonnen) return true;
                }

                // --- 4. Diagonale Prüfung (links-unten) ---
                if (z + SiegAnzahl <= brett.Length)
                {
                    bool gewonnen = true;
                    for (int i = 0; i < SiegAnzahl; i++)
                    {
                        // WICHTIG: Prüfen, ob die Spalte existiert und nicht negativ wird!
                        if (s - i < 0 || s - i >= brett[z + i].Length || brett[z + i][s - i] != spieler)
                        {
                            gewonnen = false;
                            break;
                        }
                    }
                    if (gewonnen) return true;
                }
            }
        }

        // Wenn nach allen Prüfungen kein Gewinner gefunden wurde
        return false;
    }
}
```