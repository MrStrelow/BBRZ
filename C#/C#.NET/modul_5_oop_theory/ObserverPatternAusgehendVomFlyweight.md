## TODO: under construction! nicht weiter lesen! Version 3: wir ändern zur Laufzeit 🐹 zu 🐰
TODO: was wenn wir 
```csharp
public HamsterDarstellung ChangeDarstellung(string key, string to)
{
    // Prüfen, ob ein Flyweight für dieses Symbol existiert.
    if (_flyweights.ContainsKey(key))
    {
        // Wenn schon, nimm dieses Darstellungsobjekt und überschreibe das es mit einem NEUEN OBjekt eines Symbols.
        _flyweights[key] = new HamsterDarstellung(to);
    }

    return _flyweights[key];
}
```
schreiben.
Refrenz ist noch im objekt -> im dict nicht mehr -> da unsere hamster noch drauf zeigen wird es nicht gelöscht vom GC.

Symbol der Objekte ändert sicht nicht.

```csharp

using System.Text;
using System.Linq;
using System.Collections.Generic;

// Das Flyweight-Objekt. Es enthält den geteilten, aber nun veränderlichen Zustand.
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
```


DAS ist eine passive änderung! nicht nachvollziehbar. wir wollen hier einen observer einführen der alle objekte trackt welche diese änderung betrifft.

# Flyweight, EF Core und das Change-Tracker-Problem: Eine Lösung mit dem Observer-Pattern

Dieses Dokument zeigt ein gängiges Problem auf, das bei der Kombination des Flyweight-Patterns mit Entity Framework Core auftritt, und präsentiert eine saubere Lösung mithilfe des Observer-Patterns.

**Das Problem:** Wir verwenden ein veränderbares (mutables) Flyweight-Objekt, um den Zustand vieler In-Memory-Objekte gleichzeitig zu ändern. Wir erwarten, dass der EF Core Change Tracker diese Änderungen erkennt und in die Datenbank schreibt. Überraschenderweise tut er das nicht.

**Die Lösung:** Wir führen das Observer-Pattern ein, um eine saubere Kommunikationsbrücke zwischen dem geteilten Flyweight-Objekt und den von EF Core überwachten Entitäten zu schaffen.

---

## Teil 1: Das Problem – Veränderbares Flyweight trifft auf den Change Tracker

Zuerst bauen wir das Szenario auf, das nicht wie erwartet funktioniert.

### Die Modelle

Wir definieren eine `Hamster`-Entität, die von EF Core in der Datenbank gespeichert wird, und ein `HamsterDarstellung`-Objekt, das als veränderbares Flyweight dient.

\```csharp
using System.ComponentModel.DataAnnotations.Schema;

// Die von EF Core überwachte Entität
public class Hamster
{
    public int Id { get; set; }
    
    // Diese Eigenschaft wird in der Datenbank gespeichert und vom Change Tracker überwacht.
    public string Symbol { get; set; }

    // Diese Eigenschaft ist NUR für die In-Memory-Logik.
    // EF Core ignoriert sie komplett.
    [NotMapped]
    public HamsterDarstellung Darstellung { get; set; }
}

// Das veränderbare Flyweight-Objekt
public class HamsterDarstellung
{
    public string Symbol { get; set; } // Veränderbar!

    public HamsterDarstellung(string symbol)
    {
        Symbol = symbol;
        Console.WriteLine($"--> Neues Flyweight-Objekt für '{Symbol}' erstellt.");
    }
}
\```

### Die Factory und die fehlerhafte Logik

Die Factory erstellt und verwaltet die Flyweights. Die `ChangeDarstellung`-Methode ändert das geteilte Objekt direkt.

\```csharp
public class DarstellungFactory
{
    private Dictionary<string, HamsterDarstellung> _flyweights = new();

    public HamsterDarstellung GetDarstellung(string key)
    {
        if (!_flyweights.TryGetValue(key, out var darstellung))
        {
            darstellung = new HamsterDarstellung(key);
            _flyweights.Add(key, darstellung);
        }
        return darstellung;
    }

    // Diese Methode ändert das geteilte Objekt direkt im Speicher.
    public void ChangeDarstellung(string key, string newSymbol)
    {
        if (_flyweights.TryGetValue(key, out HamsterDarstellung existingFlyweight))
        {
            Console.WriteLine($"\n--- ÄNDERE GETEILTES OBJEKT: Ändere '{existingFlyweight.Symbol}' zu '{newSymbol}' ---");
            existingFlyweight.Symbol = newSymbol;
        }
    }
}
\```

### Demonstration des Problems

Im folgenden Code ändern wir das geteilte Objekt und erwarten, dass `SaveChanges()` die Änderungen in die Datenbank schreibt.

\```csharp
public class ProblemExample
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        var factory = new DarstellungFactory();

        // Annahme: Diese Hamster kommen aus einem DbContext und werden überwacht.
        // var hamstersFromDb = context.Hamsters.ToList();
        var hamstersFromDb = new List<Hamster>
        {
            new Hamster { Id = 1, Symbol = "🐹" },
            new Hamster { Id = 2, Symbol = "❤️" },
            new Hamster { Id = 3, Symbol = "🐹" }
        };

        // Flyweight-Pattern im Speicher anwenden
        foreach (var hamster in hamstersFromDb)
        {
            hamster.Darstellung = factory.GetDarstellung(hamster.Symbol);
        }

        var hamster1 = hamstersFromDb[0];
        var hamster3 = hamstersFromDb[2];

        Console.WriteLine($"Vorher - Hamster 1: {hamster1.Darstellung.Symbol}");
        Console.WriteLine($"Vorher - Hamster 3: {hamster3.Darstellung.Symbol}");
        Console.WriteLine(object.ReferenceEquals(hamster1.Darstellung, hamster3.Darstellung) ? "Objekte sind identisch." : "Objekte sind verschieden.");

        // Jetzt ändern wir das geteilte Objekt.
        factory.ChangeDarstellung("🐹", "🐰");

        Console.WriteLine($"\nNachher - Hamster 1: {hamster1.Darstellung.Symbol}"); // Gibt 🐰 aus
        Console.WriteLine($"Nachher - Hamster 3: {hamster3.Darstellung.Symbol}"); // Gibt 🐰 aus

        // DER ENTSCHEIDENDE PUNKT:
        Console.WriteLine("\nRufe context.SaveChanges() auf...");
        // context.SaveChanges(); 
        
        Console.WriteLine("SaveChanges() hat 0 UPDATE-Befehle generiert.");
        Console.WriteLine($"Grund: Die überwachte Eigenschaft 'hamster1.Symbol' ist immer noch '{hamster1.Symbol}'!");
    }
}
\```

#### Warum funktioniert das nicht?

Der EF Core Change Tracker überwacht nur die Eigenschaften, die auf Datenbankspalten gemappt sind (hier: `Hamster.Symbol`). Die `Darstellung`-Eigenschaft ist mit `[NotMapped]` explizit davon ausgenommen.

Wenn Sie `sharedFlyweight.Symbol = "🐰"` aufrufen, ändern Sie ein Objekt, das für EF Core unsichtbar ist. Die Eigenschaft `hamster.Symbol` auf den Entitäten selbst behält ihren ursprünglichen Wert `"🐹"`. Da sich aus Sicht des Change Trackers nichts an den überwachten Entitäten geändert hat, generiert `SaveChanges()` keine `UPDATE`-Befehle.

---

## Teil 2: Die Lösung – Das Observer-Pattern als Brücke

Wir bauen das System so um, dass die Entitäten (Observer) über Änderungen am Zustand (Subject) aktiv benachrichtigt werden und daraufhin ihre eigenen, von EF Core überwachten Eigenschaften aktualisieren.

### Schritt 1: Die Verträge definieren (Interfaces)

\```csharp
public interface ISubject
{
    void Subscribe(IObserver observer);
    void Unsubscribe(IObserver observer);
    void Notify(string newSymbol);
}

public interface IObserver
{
    void Update(string newSymbol);
}
\```

### Schritt 2: Der Subject (Manager)

Dieser Manager ist der neue zentrale Punkt. Er verwaltet die Flyweights und die Abonnenten.

\```csharp
public class DarstellungsManager : ISubject
{
    private List<IObserver> _observers = new();
    private HamsterDarstellung _sharedDarstellung;

    public DarstellungsManager(HamsterDarstellung anfangsDarstellung) {
        _sharedDarstellung = anfangsDarstellung;
    }

    public void ChangeSymbol(string newSymbol) {
        Console.WriteLine($"\n--- MANAGER: Ändere Symbol zu '{newSymbol}' und benachrichtige Abonnenten ---");
        _sharedDarstellung.Symbol = newSymbol;
        Notify(newSymbol);
    }

    public void Subscribe(IObserver observer) => _observers.Add(observer);
    public void Unsubscribe(IObserver observer) => _observers.Remove(observer);
    public void Notify(string newSymbol) {
        // Erstelle eine Kopie der Liste, falls sich die Liste während der Benachrichtigung ändert
        foreach (var observer in _observers.ToList()) {
            observer.Update(newSymbol);
        }
    }
}
\```

### Schritt 3: Der Observer (Die Entität)

Die `Hamster`-Klasse wird zum Observer. Ihre `Update`-Methode enthält die entscheidende Logik, um den Change Tracker zu aktivieren.

\```csharp
// Die EF Core Entität ist jetzt ein Observer
public class Hamster : IObserver
{
    public int Id { get; set; }
    public string Symbol { get; set; }

    public void Update(string newSymbol)
    {
        Console.WriteLine($"HAMSTER (ID: {Id}): Wurde benachrichtigt! Ändere mein Symbol von '{this.Symbol}' zu '{newSymbol}'.");
        // DIESE ZEILE IST DER SCHLÜSSEL!
        // Sie ändert die von EF Core überwachte Eigenschaft.
        this.Symbol = newSymbol;
    }
}
\```

### Schritt 4: Die neue Logik

Jetzt verbinden wir alles. Die Hamster abonnieren den Manager und reagieren auf seine Benachrichtigungen.

\```csharp
public class SolutionExample
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        
        // Setup des Subjects und der Flyweights
        var sharedDarstellung = new HamsterDarstellung("🐹");
        var manager = new DarstellungsManager(sharedDarstellung);

        // Annahme: Diese Hamster kommen aus einem DbContext und werden überwacht.
        var hamstersFromDb = new List<Hamster>
        {
            new Hamster { Id = 1, Symbol = "🐹" },
            new Hamster { Id = 2, Symbol = "❤️" },
            new Hamster { Id = 3, Symbol = "🐹" }
        };

        Console.WriteLine("Abonniere relevante Hamster beim Manager...");
        // Hamster, die betroffen sein sollen, abonnieren den Manager.
        foreach (var hamster in hamstersFromDb.Where(h => h.Symbol == "🐹"))
        {
            manager.Subscribe(hamster);
        }

        // Jetzt die Änderung über den Manager auslösen
        manager.ChangeSymbol("🐰");

        Console.WriteLine($"\nNachher - Hamster 1 Symbol: {hamstersFromDb[0].Symbol}");
        Console.WriteLine($"Nachher - Hamster 2 Symbol: {hamstersFromDb[1].Symbol}"); // Unverändert!
        Console.WriteLine($"Nachher - Hamster 3 Symbol: {hamstersFromDb[2].Symbol}");

        // DER ENTSCHEIDENDE PUNKT:
        Console.WriteLine("\nRufe context.SaveChanges() auf...");
        // context.SaveChanges(); 
        
        Console.WriteLine("SaveChanges() würde jetzt 2 UPDATE-Befehle für Hamster 1 und 3 generieren.");
    }
}
\```

#### Warum funktioniert diese Lösung?

1.  **Explizite Kommunikation:** Statt eines unbemerkten Seiteneffekts gibt es einen klaren Kommunikationsfluss. Der Manager **benachrichtigt** die Hamster.
2.  **Aktive Reaktion:** Die Hamster **reagieren** auf die Benachrichtigung, indem sie ihre eigene, von EF Core überwachte `Symbol`-Eigenschaft ändern.
3.  **Sichtbarkeit für EF Core:** Weil die `Hamster.Symbol`-Eigenschaft geändert wurde, erkennt der Change Tracker die Objekte als `Modified`.
4.  **Erfolgreiches Speichern:** Ein Aufruf von `SaveChanges()` wird nun die korrekten `UPDATE`-Befehle für die geänderten Hamster generieren und in die Datenbank schreiben.