using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// Die verfügbaren Produkte dienen als Nachschlagewerk (Produkt-ID -> Emoji).
var produkte = new Dictionary<string, string>
{
    { "AT-UMBR-RD-01", "🌂" }, 
    { "DE-EXTING-2KG", "🧯" },
    { "EU-BASKET-LG", "🧺"  }, 
    { "AT-BROOM-W-05", "🧹"  },
    { "CH-RAZOR-M3", "🪒"   }, 
    { "DE-SOAP-LAV-1", "🧼"  },
    { "AT-MIRROR-SQR", "🪞" }, 
    { "EU-TOILET-C1", "🚽"  },
    { "DE-PLUNGER-01", "🪠"  }, 
    { "CH-RING-DMND", "💍"  }
};

// Das Lager selbst ist das Dictionary. Es speichert [Paketnummer -> Produkt-ID].
var lager = new Dictionary<int, string>();
int lagerGroesse;

// ----- Programmstart -----

Console.WriteLine("Willkommen bei der Lagerverwaltung!");
Console.WriteLine("Verfügbare Produkte:");
foreach (KeyValuePair<string, string> produkt in produkte)
{
    Console.WriteLine($"  ID: {produkt.Key} -> Produkt: {produkt.Value}");
}

// Benutzer nach der Lagergröße fragen.
Console.Write("\nWie groß ist das Lager [ganze Zahl]? ");

while (!int.TryParse(Console.ReadLine(), out lagerGroesse) && lagerGroesse > 0)
{
    Console.Clear();
    Console.Write("\nWie groß ist das Lager [ganze Zahl]? ");
    Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine positive ganze Zahl ein.");
}

// ----- Hauptschleife -----
while (true)
{
   // Anzeige
    Console.WriteLine("\nAktueller Lagerbestand: ");
    
    foreach (string produktId in lager.Values)
    {
        Console.Write($"{produkte[produktId]} ");
    }

    for (int i = 0; i < lagerGroesse - lager.Keys.Count; i++)
    {
        Console.Write($"📦 ");
    }

    Console.WriteLine();

    // Userinput - Aktion wählen

    Console.Write("Wählen Sie eine Aktion (einlagern, auslagern, beenden): ");
    string aktion = Console.ReadLine().ToLower().Trim();

    switch (aktion)
    {
        case "einlagern":
            Einlagern();
            break;
        case "auslagern":
            Auslagern();
            break;
        case "beenden":
            Console.WriteLine("Programm wird beendet. Auf Wiedersehen!");
            return;
        default:
            Console.WriteLine("Unbekannte Aktion. Bitte versuchen Sie es erneut.");
            break;
    }
}

// ----- Lokale Funktionen -----

void Einlagern()
{
    Console.Write("Geben Sie Paketnummer und Produkt-ID an [Paketnummer Produkt-ID]: ");
    string[] teile = Console.ReadLine().Split(new[] { ' ' }, 2); // nimmt beliebig viele leerzeichen und versucht maximal 2 leerzeichen zu trennen.
    string paketNummerUserInput = teile[0].Trim();
    string produktId = teile[1].Trim();

    // guards - ❌ ungewünschte zustände
    if (lager.Count >= lagerGroesse)
    {
        Console.WriteLine("Lager ist voll. Einlagern nicht möglich.");
        return;
    }

    if (teile.Length != 2 || !int.TryParse(paketNummerUserInput, out int paketNummer))
    {
        Console.WriteLine("Fehler: Ungültige Eingabe. Format: [Zahl] [Text]");
        return;
    }

    if (lager.ContainsKey(paketNummer))
    {
        Console.WriteLine("Fehler: Paketnummer bereits vergeben!");
        return;
    }

    if (!produkte.ContainsKey(produktId))
    {
        Console.WriteLine($"Fehler: Unbekannte Produkt-ID '{produktId}'.");
        return;
    }

    // logik - ✅ gewünschte zustände
    lager.Add(paketNummer, produktId);
    Console.WriteLine($"Produkt {produkte[produktId]} erfolgreich auf Paketnummer {paketNummer} eingelagert.");
}

void Auslagern()
{
    // guards - ❌ ungewünschte zustände
    Console.Write("Geben Sie die Paketnummer ein, die ausgelagert werden soll: ");
    if (!int.TryParse(Console.ReadLine(), out int paketNummer))
    {
        Console.WriteLine("Fehler: Ungültige Eingabe. Bitte geben Sie eine ganze Zahl ein.");
        return;
    }


    // logik - ✅ gewünschte zustände
    if (lager.Remove(paketNummer))
    {
        Console.WriteLine($"Paket {paketNummer} erfolgreich ausgelagert.");
    }
    else
    {
        Console.WriteLine("Fehler: Paketnummer nicht gefunden.");
    }
}