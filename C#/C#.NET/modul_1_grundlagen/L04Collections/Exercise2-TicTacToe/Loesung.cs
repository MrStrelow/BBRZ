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
        Status spielStatus = Status.IMGANGE;

        while (spielStatus == Status.IMGANGE)
        {
            Console.Clear();
            Console.WriteLine("--- Standard Tic-Tac-Toe (3x3) ---");

            int auswahl = -1;
            bool guardsUeberstanden = false;

            Console.Clear();
            SpielbrettAusgeben();

            while (!guardsUeberstanden)
            {
                Console.WriteLine($"\nSpieler {aktuellerSpieler} ist am Zug.");
                Console.Write("Wähle ein freies Feld (1-9): ");

                string userEingabe = Console.ReadLine();

                // ❌ ungewünschte Zustände
                // 1) User gibt keine Zahl ein.
                if (!int.TryParse(userEingabe, out auswahl))
                {
                    Console.WriteLine($"Ungültige Eingabe - {userEingabe} - Zahl zwischen 1 und 9 eingeben.");
                    continue;
                }

                // 2) User gibt Zahlen außerhalb von 1 und 9 ein
                if (!(1 <= auswahl && auswahl <= 9))
                {
                    Console.WriteLine($"Ungültige Eingabe - {auswahl} - außerhalb von 1 und 9");
                    continue;
                }

                // Rechne den Zeilen- und Spaltenindex der Auswahl aus.
                int zeile = (auswahl - 1) / 3;
                int spalte = (auswahl - 1) % 3;

                // 3) Feld ist bereits belegt
                if (brett[zeile, spalte] == SpielerEins || brett[zeile, spalte] == SpielerZwei)
                {
                    Console.WriteLine($"Ungültige Eingabe - {auswahl} - Dieses Feld ist bereits belegt!");
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

        }

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

        Console.WriteLine("--- Drücke eine beliegibe Taste um mit der Jagged Version weiterzumachen. ---");
        Console.ReadLine();
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
    private string LeerFeld = "🔲";
    private int SiegAnzahl = 3;

    // Jagged Array
    private string[][] brett; 

    private string aktuellerSpieler;
    private int anzahlZuege;
    private int maxZuege;

    public void Starten()
    {
        FeldInitialisieren(); // Zuerst das Feld vom Benutzer erstellen lassen
        Status spielStatus = Status.IMGANGE;

        while (spielStatus == Status.IMGANGE)
        {
            Console.Clear();
            Console.WriteLine("--- Variables Tic-Tac-Toe (Jagged Array) ---");
            SpielbrettAusgeben();

            int zeile = -1;
            int spalte = -1;
            bool guardsUeberstanden = false;

            while (!guardsUeberstanden)
            {
                Console.WriteLine($"\nSpieler {aktuellerSpieler} ist am Zug.");
                Console.Write("Gib Zeile und Spalte ein (z.B. '1 2'): ");
                string[] input = Console.ReadLine().Split(new[] { ' ' }, 2);

                if (input.Length != 2 || !int.TryParse(input[0], out zeile) || !int.TryParse(input[1], out spalte))
                {
                    Console.WriteLine("Ungültige Eingabe! Bitte im Format 'Zeile Spalte' eingeben.");
                    continue;
                }

                if (zeile < 1 || zeile > brett.Length || spalte < 1 || spalte > brett[zeile - 1].Length)
                {
                    Console.WriteLine("Eingabe außerhalb des Spielfelds!");
                    continue;
                }

                if (brett[zeile - 1][spalte - 1] != LeerFeld)
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

        }

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

        brett = new string[anzahlZeilen][];
        maxZuege = 0;
        aktuellerSpieler = SpielerEins;
        anzahlZuege = 0;

        for (int i = 0; i < anzahlZeilen; i++)
        {
            Console.Write($"Geben Sie die Anzahl der Spalten für Zeile {i + 1} ein (mind. 3): ");
            int spalten;
            userEingabe = Console.ReadLine();

            while (!int.TryParse(userEingabe, out spalten))
            {
                Console.Write($"Keine Zahl eingegeben - {userEingabe} - Bitte eine Zahl groeßer 3 eingeben.");
                Console.Write("Geben Sie die Anzahl der Spalten für Zeile {i + 1} ein (mind. 3): ");
                userEingabe = Console.ReadLine();
            }

            brett[i] = new string[spalten];
            maxZuege += spalten;

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
