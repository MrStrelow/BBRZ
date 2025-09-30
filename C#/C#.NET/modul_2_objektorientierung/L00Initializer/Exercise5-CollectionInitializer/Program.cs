//var tuple = ParseCoordinates("48.2082, 16.3738");
//if (tuple.success)
//{
//    Console.WriteLine($"Latitude: {tuple.latitude}, Longitude: {tuple.longitude}");
//}
//else
//{
//    Console.WriteLine("Ungültiges Format.");
//}

//(bool success, double latitude, double longitude) ParseCoordinates(string input)
//{
//    string[] parts = input.Split(',');
//    if (parts.Length != 2)
//    {
//        return (false, 0, 0); // Fehlerfall zurückgeben
//    }

//    bool latParsed = double.TryParse(parts[0], out var lat);
//    bool lonParsed = double.TryParse(parts[1], out var lon);

//    if (latParsed && lonParsed)
//    {
//        return (true, lat, lon); // Erfolgsfall mit Werten zurückgeben
//    }

//    return (false, 0, 0); // Fehlerfall zurückgeben - Nachteil, es muss immer ein ganzes Tuple zurückgegeben werden, auch wenn Teile dieses Tuples fehlen.
//}

using System.Text;
using System.Linq;
using System.Collections.Generic;

// Das Flyweight-Objekt. Es enthält den geteilten, unveränderlichen Zustand.
public class HamsterDarstellung
{
    public string Symbol { get; set; } // nicht mehr unveränderlich

    public HamsterDarstellung(string symbol)
    {
        Symbol = symbol;
        Console.WriteLine($"--> Neues Flyweight-Objekt für '{Symbol}' erstellt.");
    }
}

// Die Factory, die die Flyweights verwaltet und wiederverwendet.
public class DarstellungFactory
{
    private Dictionary<string, HamsterDarstellung> _flyweights = new();

    public HamsterDarstellung GetDarstellung(string key, string symbol)
    {
        // Prüfen, ob schon ein Flyweight für dieses Symbol existiert.
        if (!_flyweights.ContainsKey(key))
        {
            // Wenn nicht, ein neues erstellen und im Pool speichern.
            _flyweights[key] = new HamsterDarstellung(symbol);
        }

        // Das (ggf. neue oder bereits existierende) Flyweight zurückgeben.
        return _flyweights[key];
    }

    public HamsterDarstellung ChangeDarstellung(string key, string to)
    {
        // Prüfen, ob ein Flyweight für dieses Symbol existiert.
        if (_flyweights.ContainsKey(key))
        {
            // Wenn schon, nimm dieses Darstellungsobjekt und überschreibe das Symbol.
            _flyweights[key].Symbol = to;
        }

        return _flyweights[key];
    }
}

// Der "Context", der das Flyweight verwendet.
public class Hamster
{
    // Hält nur eine Referenz auf das geteilte Flyweight-Objekt.
    public HamsterDarstellung Darstellung { get; set; }
}

public class FlyweightExample
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        // Angenommen, die von der Factory erstellten Objekte sind veränderbar (mutable).
        var factory = new DarstellungFactory();

        var hamster1 = new Hamster { Darstellung = factory.GetDarstellung(key: "normal", symbol: "🐹") };
        var hamster2 = new Hamster { Darstellung = factory.GetDarstellung(key: "normal", symbol: "🐹") };

        Console.WriteLine($"Hamster 1: {hamster1.Darstellung.Symbol}"); // -> 🐹
        Console.WriteLine($"Hamster 2: {hamster2.Darstellung.Symbol}"); // -> 🐹

        Console.WriteLine("\n--- ÄNDERUNG ZUR LAUFZEIT ---");
        // Wir holen uns das geteilte Objekt aus der Factory und verändern es.
        var geteiltesObjekt = factory.ChangeDarstellung(key: "normal", to: "🐰");

        Console.WriteLine($"Hamster 1 jetzt: {hamster1.Darstellung.Symbol}"); // -> 🐰
        Console.WriteLine($"Hamster 2 jetzt: {hamster2.Darstellung.Symbol}"); // -> 🐰
    }
}