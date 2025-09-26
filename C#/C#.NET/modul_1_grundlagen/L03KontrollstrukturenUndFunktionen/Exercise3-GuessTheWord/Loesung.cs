using System.Text;

// =================================================================================
// 1. KONSTANTEN UND VARIABLEN
// =================================================================================

const int LAENGE_DES_WORTES = 3;
const int MAX_FEHLER = 6;
string zuErratendesWort = "";
string bereitsGerateneBuchstaben = "";
int fehler = 0;

// =================================================================================
// 2. HAUPTLOGIK (Top-Level Statements)
// =================================================================================

Console.OutputEncoding = Encoding.UTF8;

// Zuständigkeit: Schleife zur Eingabe des zu erratenden Wortes
do
{
    Console.Write($"Wähle das Wort mit {LAENGE_DES_WORTES} Buchstaben (Eingabe wird versteckt): ");

    // Workaround um das Passwort "unsichtbar" zu machen
    string passwort = "";
    ConsoleKeyInfo key;
    do
    {
        key = Console.ReadKey(true); 
        // Es kann auch normal Console.Read verwendet werden. Siehe Java Kurs.
        // Dann brauchen wir die do While nicht und wir sehen das ausgegebene wort nicht.
        
        if (!char.IsControl(key.KeyChar))
        {
            passwort += key.KeyChar;
            Console.Write("*");
        }
    } while (key.Key != ConsoleKey.Enter);

    zuErratendesWort = passwort.Trim();
    Console.WriteLine();

    if (zuErratendesWort.Length != LAENGE_DES_WORTES)
    {
        Console.WriteLine($"Fehler: Das Wort muss genau {LAENGE_DES_WORTES} Buchstaben lang sein.");
    }
} while (zuErratendesWort.Length != LAENGE_DES_WORTES);

// Konsole clearen, um das eingegebene Wort zu verstecken
Console.Clear();

// Das zu erratende Wort mit Unterstrichen initialisieren
StringBuilder angezeigtesWortBuilder = new StringBuilder(new string('_', LAENGE_DES_WORTES));

// Game-Loop
while (fehler < MAX_FEHLER && !angezeigtesWortBuilder.ToString().Equals(zuErratendesWort, StringComparison.OrdinalIgnoreCase))
{
    Console.WriteLine($"Wort: {angezeigtesWortBuilder}");
    Console.WriteLine($"Bereits geraten: {string.Join(", ", bereitsGerateneBuchstaben)}");

    // Wähle eine der drei Zeichnungsmethoden aus
    // zeichneHangman(fehler);
    // zeichneSharkFin(fehler);
    zeichneEisbecher(fehler);

    Console.Write("Rate einen Buchstaben: ");
    string eingabe = Console.ReadLine().ToLower();

    if (eingabe.Length != 1 || !char.IsLetter(eingabe[0]))
    {
        Console.WriteLine("Bitte gib genau einen Buchstaben ein - Drücke eine Tast um fortzufahren.");
        Console.ReadKey(); // Warten auf Tastendruck, damit der Spieler die Meldung lesen kann
        Console.Clear();
        continue;
    }

    char geratenerBuchstabe = eingabe[0];

    if (bereitsGerateneBuchstaben.Contains(geratenerBuchstabe))
    {
        Console.WriteLine("Diesen Buchstaben hast du bereits geraten - Drücke eine Tast um fortzufahren.");
        Console.ReadKey();
        Console.Clear();
        continue;
    }

    bereitsGerateneBuchstaben += geratenerBuchstabe;
    bool treffer = false;

    // Überprüfen, ob der Buchstabe im Wort vorkommt und ggf. die Unterstriche ersetzen
    for (int i = 0; i < LAENGE_DES_WORTES; i++)
    {
        if (char.ToLower(zuErratendesWort[i]) == geratenerBuchstabe)
        {
            angezeigtesWortBuilder[i] = zuErratendesWort[i];
            treffer = true;
        }
    }

    if (!treffer)
    {
        fehler++;
    }

    Console.Clear();
}

// Ausgabe am Spielende
Console.Clear();
if (angezeigtesWortBuilder.ToString().Equals(zuErratendesWort, StringComparison.OrdinalIgnoreCase))
{
    Console.WriteLine("Gewonnen!");
    Console.WriteLine($"Das Wort war: {zuErratendesWort}");
}
else
{
    Console.WriteLine("Verloren.");
    Console.WriteLine($"Wort: {angezeigtesWortBuilder}");
    // Finale Zeichnung anzeigen
    // zeichneHangman(fehler);
    // zeichneSharkFin(fehler);
    zeichneEisbecher(fehler);
    Console.WriteLine($"Das gesuchte Wort war: {zuErratendesWort}");
}


// =================================================================================
// 3. ZEICHNUNGSMETHODEN
// =================================================================================

static void zeichneHangman(int fehler)
{
    Console.WriteLine("  ____ ");
    Console.WriteLine(" |    |");
    Console.WriteLine(" |    " + (fehler >= 1 ? "O" : ""));
    Console.Write(" |   ");

    if (fehler == 2) Console.Write("|");
    else if (fehler == 3) Console.Write("/|");
    else if (fehler >= 4) Console.Write("/|\\");

    Console.WriteLine();
    Console.Write(" |    ");

    if (fehler == 5) Console.Write("/");
    else if (fehler >= 6) Console.Write("/ \\");

    Console.WriteLine();
    Console.WriteLine("_|___ ");
}

static void zeichneSharkFin(int fehlversuche)
{
    string bild = fehlversuche switch
    {
        0 => "🦈🌊🌊🌊🌊🌊🏄🏻",
        1 => "🌊🦈🌊🌊🌊🌊🏄🏻",
        2 => "🌊🌊🦈🌊🌊🌊🏄🏻",
        3 => "🌊🌊🌊🦈🌊🌊🏄🏻",
        4 => "🌊🌊🌊🌊🦈🌊🏄🏻",
        5 => "🌊🌊🌊🌊🌊🦈🏄🏻",
        _ => "🌊🌊🌊🌊🌊🌊🤕", // 6 oder mehr
    };
    Console.WriteLine(bild);
}

static void zeichneEisbecher(int fehlversuche)
{
    string becher = fehlversuche switch
    {
        0 => """
                  🔴
                 🟢🟤
                🟢🟠🐻‍❄️
                """,
        1 => """
                
                 🟢🟤
                🟢🟠🐻‍❄️
                """,
        2 => """
                
                 🟢
                🟢🟠🐻‍❄️
                """,
        3 => """
                
                
                🟢🟠🐻‍❄️
                """,
        4 => """
                
                
                 🟠🐻‍❄️
                """,
        5 => """
                
                
                   🐻‍❄️
                """,
        _ => """
                
                
                
                """,
    };

    Console.WriteLine(becher);
    Console.WriteLine("\\ /\\ /");
    Console.WriteLine(" \\. /");
    Console.WriteLine("  \\/");
}