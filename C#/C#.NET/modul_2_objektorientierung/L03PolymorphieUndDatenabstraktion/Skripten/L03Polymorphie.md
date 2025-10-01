# Polymorphismus, Abstraktion und SOLID

## 1. Polymorphismus (Vielseitigkeit)

Polymorphismus bedeutet **"Vielgestaltigkeit"**. In der Programmierung bezieht sich dies auf die Fähigkeit einer Variable, eines Objekts oder einer Methode, je nach Kontext unterschiedliche Formen oder Verhaltensweisen anzunehmen. Wir konzentrieren uns hier auf den **dynamischen Polymorphismus** (zur Laufzeit bekannt), der durch Vererbung und dem ``override`` von ``Methoden`` ermöglicht wird. Wir gehen *noch* nicht auf **statischen Polymorphismus** (zur Compilezeit), welcher *Methodenüberlagerung* (gleicher Name, andere Parameter) und *Generizität* behandelt. 

### Die "Ist-eine"-Beziehung und Vererbung

Das Herzstück des Polymorphismus ist die **Vererbung** und die damit verbundene **"ist-eine"-Beziehung**.

* **Obertyp (Base Type):** Eine allgemeine Klasse (z.B. `Fahrzeug`).
* **Untertyp (Derived Type):** Eine spezialisierte Klasse, die vom Obertyp erbt (z.B. `Auto`).

Die Beziehung lautet: Ein `Auto` **ist ein** `Fahrzeug`. Das bedeutet, ein `Auto`-Objekt besitzt alles, was ein `Fahrzeug` besitzt, und kann zusätzlich eigene, spezialisierte Eigenschaften und Methoden haben.

Diese Beziehung macht den Code "vielseitig": Eine Variable vom Typ `Fahrzeug` kann nicht nur ein `Fahrzeug`-Objekt halten, sondern auch jedes Objekt eines Untertyps, wie `Auto`, `Motorrad` oder `LKW`.

```csharp
// Obertyp (Base Type)
public class Tier
{
    public string Name { get; set; }

    // Diese Methode ist als 'virtual' markiert.
    // Das bedeutet: "Untertypen dürfen diese Methode überschreiben, wenn sie wollen."
    public virtual void GibLaut()
    {
        Console.WriteLine("Ein unbestimmtes Tiergeräusch.");
    }
}

// Untertyp (Derived Type)
public class Hund : Tier // Ein Hund "ist ein" Tier
{
    // Diese Methode 'überschreibt' die Methode des Obertyps.
    // Das geht nur, weil die Basismethode 'virtual' ist.
    public override void GibLaut()
    {
        Console.WriteLine("Wuff!");
    }
}

// Ein weiterer Untertyp
public class Katze : Tier // Eine Katze "ist ein" Tier
{
    public override void GibLaut()
    {
        Console.WriteLine("Miau!");
    }
}

public class Programm
{
    public static void Main()
    {
        // Polymorphismus in Aktion!
        // Die Variable 'meinTier' ist vom Typ Tier, kann aber verschiedene
        // konkrete Tier-Objekte halten.
        Tier meinTier;

        meinTier = new Hund { Name = "Bello" };
        // Obwohl die Variable vom Typ Tier ist, wird zur Laufzeit die
        // überschriebene Methode von Hund aufgerufen.
        meinTier.GibLaut(); // Gibt "Wuff!" aus.

        meinTier = new Katze { Name = "Minka" };
        meinTier.GibLaut(); // Gibt "Miau!" aus.
        
        // Man kann sie auch in einer Liste mischen.
        List<Tier> zoo = new List<Tier>
        {
            new Hund(),
            new Katze(),
            new Tier() // Hier wird die ursprüngliche Methode aufgerufen
        };

        foreach (var tier in zoo)
        {
            tier.GibLaut();
        }
    }
}
```

* `virtual`: Ein Schlüsselwort in der Basisklasse, das anzeigt, dass eine Methode von abgeleiteten Klassen überschrieben werden *kann*.
* `override`: Ein Schlüsselwort in der abgeleiteten Klasse, das anzeigt, dass sie die Implementierung der Basismethode bewusst ersetzt.


### Was wenn kein Virtual ist?

```csharp
// Obertyp (Base Type)
public class Tier
{
    public string Name { get; set; }

    // KEIN 'virtual'
    public void GibLaut()
    {
        Console.WriteLine("Ein unbestimmtes Tiergeräusch.");
    }
}

// Untertyp (Derived Type)
public class Hund : Tier
{
    // KEIN 'override'. Dies ist eine NEUE, unabhängige Methode,
    // die die Methode der Basisklasse nur "versteckt" (hides).
    // Der Compiler gibt hier oft eine Warnung aus.
    public void GibLaut()
    {
        Console.WriteLine("Wuff!");
    }
}

public class Programm
{
    public static void Main()
    {
        // Szenario 1: Variable ist vom Typ Hund
        Hund bello = new Hund();
        bello.GibLaut(); // Gibt "Wuff!" aus. (Hier ist der Typ zur Compile-Zeit klar)

        // Szenario 2: Polymorphismus
        Tier meinTier = new Hund(); // Ein Hund-Objekt in einer Tier-Variable

        // HIER ist der entscheidende Unterschied:
        // Weil 'GibLaut' in Tier nicht 'virtual' ist, wird die Methode
        // des deklarierten Typs der Variable ('Tier') aufgerufen.
        meinTier.GibLaut(); // Gibt "Ein unbestimmtes Tiergeräusch." aus!

        Hund meinHund = new Hund(); // Ein Hund-Objekt in einer Hund-Variable
        meinTier.GibLaut(); // Gibt "Ein unbestimmtes Tiergeräusch." aus!
    }
}
```

---

## 2. Abstrakte Klassen

Eine abstrakte Klasse ist eine spezielle Art von Klasse, die als **unvollständiger Bauplan** dient. Sie hat zwei Hauptzwecke:

1.  **Instanziierung verhindern:** Man kann kein Objekt direkt von einer abstrakten Klasse erstellen (z.B. `new Fahrzeug()` ist verboten, wenn `Fahrzeug` abstrakt ist). Sie zwingt uns, spezifische Untertypen wie `Auto` oder `Motorrad` zu verwenden.
2.  **Abstrakte Methoden definieren:** Eine abstrakte Methode hat **keine Implementierung** (keinen Code-Körper). Sie ist ein Vertrag, der besagt: "Jede nicht-abstrakte Klasse, die von mir erbt, **muss** eine eigene Implementierung für diese Methode bereitstellen."

Abstrakte Klassen können auch normale, implementierte Methoden (`virtual` oder nicht) enthalten, die von den Untertypen gemeinsam genutzt werden.

```csharp
// Ein unvollständiger Bauplan. Man kann kein "Grafikobjekt" erstellen.
public abstract class Grafikobjekt
{
    public int X { get; set; }
    public int Y { get; set; }

    // Eine normale Methode, die von allen Untertypen geteilt wird.
    public void Verschieben(int dx, int dy)
    {
        X += dx;
        Y += dy;
    }

    // Eine abstrakte Methode: kein Code, nur eine Signatur.
    // JEDER Untertyp MUSS diese Methode implementieren.
    public abstract void Zeichnen();
}

public class Kreis : Grafikobjekt
{
    public int Radius { get; set; }

    // Die 'Zeichnen'-Methode MUSS hier überschrieben werden.
    public override void Zeichnen()
    {
        Console.WriteLine($"Zeichne einen Kreis an Position ({X},{Y}) mit Radius {Radius}.");
    }
}

public class Rechteck : Grafikobjekt
{
    public int Breite { get; set; }
    public int Hoehe { get; set; }

    public override void Zeichnen()
    {
        Console.WriteLine($"Zeichne ein Rechteck an Position ({X},{Y}) mit Größe ({Breite}x{Hoehe}).");
    }
}
```

---

## 3. Interfaces

Ein Interface ist ein reiner **Vertrag**. Man kann es sich als eine extrem eingeschränkte abstrakte Klasse vorstellen:

* Es enthält **ausschließlich** abstrakte Member (Methoden, Properties, Events). Es gibt **keine Implementierung** und keine Felder.
* Eine Klasse kann **mehrere Interfaces implementieren**, aber nur von **einer** Klasse erben.
* Die Beziehung wird als **"implementiert-eine"**-Beziehung bezeichnet, nicht als Vererbung.

Ein Interface zwingt die implementierende Klasse, eine öffentliche Implementierung für alle seine Member bereitzustellen. Es gibt kein `override`, da es nichts zu überschreiben gibt – die Implementierung wird neu erstellt.

```csharp
// Ein Vertrag, der vorschreibt, was ein "speicherbares" Objekt können muss.
public interface ISpeicherbar
{
    // Abstrakte Property: Jede implementierende Klasse MUSS eine
    // öffentliche 'Id'-Property mit get und set haben.
    int Id { get; set; }

    // Abstrakte Methode: Jede implementierende Klasse MUSS diese Methode bereitstellen.
    void Speichern();
    void Laden(int id);
}

public class Dokument : ISpeicherbar
{
    public int Id { get; set; }
    public string Inhalt { get; set; }

    // Erzwungene Implementierung der Methode
    public void Speichern()
    {
        Console.WriteLine($"Dokument mit Id {Id} wird gespeichert...");
    }
    
    public void Laden(int id)
    {
        Console.WriteLine($"Dokument mit Id {id} wird geladen...");
        this.Id = id;
    }
}

public class Bild : ISpeicherbar
{
    // Explizite Implementierung einer Property mit dem 'field'-Keyword (C# 11+)
    public int Id { get; set; } = field;

    // Erzwungene Implementierung
    public void Speichern() => Console.WriteLine($"Bild {Id} wird gespeichert...");
    public void Laden(int id) => Console.WriteLine($"Bild {id} wird geladen...");
}

// Explizite Interface-Implementierung
public class Video : ISpeicherbar
{
    // Die 'Id' ist nicht direkt über eine 'Video'-Variable sichtbar.
    int ISpeicherbar.Id { get; set; }
    
    // Diese Methode kann nur aufgerufen werden, wenn das Objekt
    // als Interface-Typ behandelt wird.
    void ISpeicherbar.Speichern() => Console.WriteLine("Video wird explizit gespeichert...");
    void ISpeicherbar.Laden(int id) { /* ... */ }

    // Normale öffentliche Methode der Klasse
    public void Abspielen() => Console.WriteLine("Video wird abgespielt...");
}

public class Programm
{
    public static void Main()
    {
        Video meinVideo = new Video();
        meinVideo.Abspielen();
        // meinVideo.Speichern(); // FEHLER: Ist nicht öffentlich sichtbar

        // Um auf die expliziten Member zuzugreifen, müssen wir das Objekt "casten".
        ISpeicherbar speicherbaresVideo = meinVideo;
        speicherbaresVideo.Speichern(); // Funktioniert!
    }
}
```
**Explizite Interfaces** werden verwendet, um Namenskonflikte zu vermeiden (wenn zwei Interfaces dieselbe Methode definieren) oder um die öffentliche Schnittstelle einer Klasse sauber zu halten, indem Implementierungsdetails des Interfaces "verborgen" werden.

---

### Anwendung in der Hamster-Simulation

#### `IRenderer` in Exercise1-Interfaces

In diesem Beispiel wird ein Interface verwendet, um die **Darstellungslogik** von der **Simulationslogik** zu entkoppeln.

* **Das Problem:** Die `Plane`-Klasse ist fest mit der `Console` verbunden. Sie schreibt direkt in die Konsole. Was ist, wenn wir die Simulation stattdessen in eine HTML-Datei oder ein GUI-Fenster zeichnen wollen? Wir müssten die `Plane`-Klasse umschreiben.
* **Die Lösung (`IRenderer`):** Wir definieren einen Vertrag `IRenderer`, der vorschreibt, was ein "Renderer" können muss (z.B. die Simulation zeichnen, den Bildschirm löschen).

    ```csharp
    // Der Vertrag
    public interface IRenderer
    {
        void Render(string[,] plane);
        void Clear();
    }
    ```
    Die `Plane`-Klasse arbeitet dann nicht mehr direkt mit der `Console`, sondern mit einer beliebigen Klasse, die `IRenderer` **implementiert**.

    ```csharp
    public class Plane
    {
        private readonly IRenderer _renderer;
        public Plane(int size, IRenderer renderer) // Wir übergeben einen Renderer
        {
            _renderer = renderer;
        }

        public void Print()
        {
            _renderer.Clear();
            _renderer.Render(_plane); // Delegiert das Zeichnen an den Renderer
        }
    }
    ```
    Jetzt können wir verschiedene Renderer erstellen (`ConsoleRenderer`, `HtmlRenderer`), und die `Plane` funktioniert mit beiden, ohne dass eine einzige Zeile in ihr geändert werden muss. Das ist ein perfektes Beispiel für lose Kopplung.

#### Abstrakte `Hamster`-Klasse in Exercise2-AbstractClasses

Hier wird eine abstrakte Klasse verwendet, um eine **Familie von ähnlichen Objekten** zu definieren.

* **Das Ziel:** Wir wollen verschiedene Arten von Hamstern haben (`BigMouthHamster`, `BigLegHamster`), die vieles gemeinsam haben (Position, Bewegung), sich aber in bestimmten Verhaltensweisen unterscheiden (z.B. wie sie fressen).
* **Die Lösung (`abstract class Hamster`):**
    * Die `Hamster`-Klasse wird `abstract` gemacht. Man kann keinen generischen "Hamster" mehr erstellen, nur noch spezifische Typen.
    * Gemeinsames Verhalten (wie `Move()`) wird in der `Hamster`-Basisklasse implementiert und von allen Untertypen **geerbt**.
    * Spezifisches Verhalten (wie `NutritionBehaviour()`) kann als `abstract` oder `virtual` definiert werden, sodass die Untertypen es **implementieren müssen** oder **überschreiben können**.

Die abstrakte Klasse dient hier als **Template** (Vorlage), das eine Grundfunktionalität bereitstellt, aber gleichzeitig sicherstellt, dass die spezifischen Implementierungen in den abgeleiteten Klassen nicht vergessen werden.

---

## 4. Die SOLID-Prinzipien (Grobüberblick)

SOLID ist ein Akronym für fünf Design-Prinzipien, die helfen, sauberen, wartbaren und flexiblen Code zu schreiben.

* **S** - Single Responsibility Principle: Eine Klasse sollte nur einen einzigen Grund haben, sich zu ändern (d.h. nur eine Verantwortlichkeit haben).
* **O** - **Open/Closed Principle:** Software-Einheiten (Klassen, Module) sollten **offen für Erweiterungen**, aber **geschlossen für Änderungen** sein. Man sollte neues Verhalten hinzufügen können, ohne bestehenden, funktionierenden Code ändern zu müssen.
* **L** - Liskov Substitution Principle: Untertypen müssen sich so verhalten, dass sie die Obertypen jederzeit ersetzen können, ohne das Programm zu zerstören.
* **I** - **Interface Segregation Principle:** Clients sollten nicht gezwungen werden, von Interfaces abhängig zu sein, die sie nicht verwenden. Besser sind viele kleine, spezifische Interfaces als ein großes, generelles.
* **D** - **Dependency Inversion Principle:** High-Level-Module sollten nicht von Low-Level-Modulen abhängen. Beide sollten von **Abstraktionen (Interfaces)** abhängen. Details sollten von Abstraktionen abhängen, nicht umgekehrt.

### SOLID in Exercise4: Das Strategy Pattern

In diesem Beispiel wird das Design weiter verbessert, indem spezifische Verhaltensweisen in eigene "Strategie"-Klassen ausgelagert werden.

* **Dependency Inversion:** Die `Hamster`-Klasse hängt nicht mehr direkt von einer `RandomMovement`-Logik ab. Sie hängt nur noch von der Abstraktion `IMovementStrategy` ab. Wir können ihr zur Laufzeit verschiedene Bewegungsstrategien "injizieren" (übergeben).
* **Interface Segregation:** Statt eines großen "Hamster-Interfaces" gibt es viele kleine, fokussierte Interfaces wie `IVisuals`, `IRenderer`, `IRepresentation`. Andere Klassen hängen nur von den Verträgen ab, die sie wirklich benötigen.
* **Open/Closed Principle:** Das ist der größte Gewinn. Wollen wir eine neue Bewegungsart für Hamster einführen (z.B. `CircularMovement`)? Wir müssen die `Hamster`-Klasse **nicht ändern**. Wir erstellen einfach eine neue Klasse `CircularMovementStrategy`, die `IMovementStrategy` implementiert, und übergeben eine Instanz davon an den Hamster. Das System ist **offen für Erweiterungen** (neue Strategien), aber die `Hamster`-Klasse selbst ist **geschlossen für Änderungen**.

Die `NutritionBehaviour` als abstrakte Klasse zu belassen, und hier kein ``Interface``. ist eine pragmatische Entscheidung. Wenn das Fressverhalten bei allen Hamster-Arten sehr ähnlich ist und viel Code geteilt wird, ist eine abstrakte Basisklasse mit `virtual`-Methoden oft sinnvoller als ein Interface, bei dem man den gesamten Code in jeder implementierenden Klasse duplizieren müsste.