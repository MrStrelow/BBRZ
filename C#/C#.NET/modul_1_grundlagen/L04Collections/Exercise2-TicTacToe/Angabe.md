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

Erstelle eine Konsolenanwendung, die zwei verschiedene Arten von Tic-Tac-Toe implementiert. 

## Normales Tic-Tac-Toe

* **Datenstruktur:** Verwenden Sie ein zweidimensionales Array (`string[,]`) für das 3x3-Spielfeld.
* **Symbole:**
    * Spieler 1: `🔴`
    * Spieler 2: `🔵`
    * Spielfelder: Initialisiere das Brett mit den Zahlen als Text (`"1"`, `"2"`, ..., `"9"`), um dem Benutzer die Auswahl zu erleichtern.
* **Spiellogik:**
    * Die Spieler wählen abwechselnd ein Feld durch Eingabe einer Zahl von 1-9.
    * Implementieren Sie eine Guard welche ungültige Eingaben abfängt und den Benutzer erneut zur Eingabe auffordert. Verwenden Sie hierfür eine `while (!guardsUeberstanden)` worin sich verschiedene Guards (keine Zahl, Zahl außerhalb des Bereichs, Feld bereits belegt) befinden..
    * Das Spiel endet bei einem Sieg (3 gleiche Symbole in einer Reihe, Spalte oder Diagonale) oder einem Unentschieden (alle 9 Felder belegt).
* **Struktur:** Gliedern Sie den Code in private Methoden wie `SpielbrettAusgeben()`, `FeldBelegen(int, string)` und `GewinnerPruefen()`.

### Erwarteter Output
```
-------------
| 🔵 | 2 | 🔴 |
-------------
| 🔴 | 🔴 | 6 |
-------------
| 🔵 | 🔵 | 9 |
-------------

Spieler 🔴 ist am Zug.
Wähle ein freies Feld (1-9): sechs
Ungültige Eingabe - sechs - Zahl zwischen 1 und 9 eingeben.

Spieler 🔴 ist am Zug.
Wähle ein freies Feld (1-9): 66
Ungültige Eingabe - 66 - außerhalb von 1 und 9

Spieler 🔴 ist am Zug.
Wähle ein freies Feld (1-9): 5
Ungültige Eingabe - 5 - Dieses Feld ist bereits belegt!

Spieler 🔴 ist am Zug.
Wähle ein freies Feld (1-9): 6

🏁 Spiel beendet! 🏁
-------------
| 🔵 | 2 | 🔴 |
-------------
| 🔴 | 🔴 | 🔴 |
-------------
| 🔵 | 🔵 | 9 |
-------------

🏆 Herzlichen Glückwunsch! Spieler 🔴 hat gewonnen! 🏆
--- Drücke eine beliegibe Taste um mit der Jagged Version weiterzumachen. ---
```

### Vorlage
Siehe [hier](#vorlage-1).

---

## Das variables Tic-Tac-Toe

Implementieren Sie eine erweiterte Version von Tic-Tac-Toe in der Klasse `JaggedGame`. Diese Version wird auf einem vom Benutzer definierten, unregelmäßigen Spielfeld gespielt.

* **Datenstruktur:** Verwenden Sie ein **Jagged Array** (`string[][]`).
* **Symbole:**
    * Spieler 1: `🔴`
    * Spieler 2: `🔵`
    * Leere Felder: `🟦`
* **Spiellogik:**
    * **Initialisierung:** Bevor das Spiel startet, fragen Sie den Benutzer nach der Anzahl der Zeilen. Anschließend fragen Sie für jede Zeile einzeln nach der gewünschten Anzahl an Spalten. Erstellen Sie das Jagged Array dynamisch basierend auf diesen Eingaben.
    * **Spielzüge:** Die Spieler wählen ein Feld durch Eingabe von Koordinaten (z.B. `"1 2"` für Zeile 1, Spalte 2).
    * **Siegbedingung:** Ein Sieg wird durch **3** (`SiegAnzahl = 3`) gleiche Symbole in einer Reihe erzielt (horizontal, vertikal oder in beide Diagonalrichtungen).
    * **Gewinnprüfung:** Implementieren Sie die `GewinnerPruefen()`-Methode. Die Logik muss robust genug sein, um die unregelmäßige Struktur des Bretts zu berücksichtigen und "Index out of Bounds"-Fehler zu vermeiden, insbesondere bei der vertikalen und diagonalen Prüfung.
    * Das Spiel endet bei einem Sieg oder einem Unentschieden (alle Felder belegt).
* **Struktur:** Gliedern Sie den Code in private Methoden wie `FeldInitialisieren()`, `SpielbrettAusgeben()` und `GewinnerPruefen(string)`.

### Erwarteter Output
```
--- Konfiguration des variablen Spielfelds ---
Geben Sie die Anzahl der Zeilen ein (mind. 3): 3
Geben Sie die Anzahl der Spalten für Zeile 1 ein (mind. 3): 4
Geben Sie die Anzahl der Spalten für Zeile 2 ein (mind. 3): 8
Geben Sie die Anzahl der Spalten für Zeile 3 ein (mind. 3): 12

--- Variables Tic-Tac-Toe (Jagged Array) ---
-------------------------------------------------
| 🔵 | 🔴 | 🔵 | 🔴 |
-------------------------------------------------
| 🔴 | 🔵 | 🔵 | 🔲 | 🔲 | 🔲 | 🔲 | 🔲 |
-------------------------------------------------
| 🔴 | 🔵 | 🔴 | 🔲 | 🔲 | 🔲 | 🔲 | 🔲 | 🔲 | 🔵 | 🔴 | 🔴 |
-------------------------------------------------

Spieler 🔵 ist am Zug.
Gib Zeile und Spalte ein (z.B. '1 2'): yes me win
Ungültige Eingabe! Bitte im Format 'Zeile Spalte' eingeben.

Spieler 🔵 ist am Zug.
Gib Zeile und Spalte ein (z.B. '1 2'): zwei vier
Ungültige Eingabe! Bitte im Format 'Zeile Spalte' eingeben.

Spieler 🔵 ist am Zug.
Gib Zeile und Spalte ein (z.B. '1 2'): 2    4?
Ungültige Eingabe! Bitte im Format 'Zeile Spalte' eingeben.

Spieler 🔵 ist am Zug.
Gib Zeile und Spalte ein (z.B. '1 2'): 2 4 6
Ungültige Eingabe! Bitte im Format 'Zeile Spalte' eingeben.

Spieler 🔵 ist am Zug.
Gib Zeile und Spalte ein (z.B. '1 2'): 2     4

🏁 Spiel beendet! 🏁
-------------------------------------------------
| 🔵 | 🔴 | 🔵 | 🔴 |
-------------------------------------------------
| 🔴 | 🔵 | 🔵 | 🔵 | 🔲 | 🔲 | 🔲 | 🔲 |
-------------------------------------------------
| 🔴 | 🔵 | 🔴 | 🔲 | 🔲 | 🔲 | 🔲 | 🔲 | 🔲 | 🔵 | 🔴 | 🔴 |
-------------------------------------------------

🏆 Herzlichen Glückwunsch! Spieler 🔵 hat gewonnen! 🏆
```

## Vorlage
```csharp
using System.Text;

// Top - Level Statement
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("############### Standard TickTackToe wird ausgeführt ###############");
StandardGame standard = new StandardGame();
standard.Starten();

Console.WriteLine("############### Jagged TickTackToe wird ausgeführt ###############");
JaggedGame jagged = new JaggedGame();
jagged.Starten();

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
        throw new NotImplementedException();
    }

    public void Starten()
    {
        throw new NotImplementedException();
    }

    private void SpielbrettAusgeben()
    {
        throw new NotImplementedException();
    }

    private void FeldBelegen(int position, string spieler)
    {
       throw new NotImplementedException();
    }

    private bool GewinnerPruefen()
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    private void FeldInitialisieren()
    {
        throw new NotImplementedException();
    }

    private void SpielbrettAusgeben()
    {
        throw new NotImplementedException();
    }

    private bool GewinnerPruefen(string spieler)
    {
        throw new NotImplementedException();
    }
}
```