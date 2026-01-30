using System;

Console.WriteLine("=== START WORKSHOP LÖSUNG ===\n");

#region Übung 1: Modernisierung (Legacy -> ModernUser)

Console.WriteLine("--- Übung 1: ModernUser ---");

// Instanziierung mit Object Initializer
// 'Username' MUSS gesetzt werden (wegen required), sonst Compiler-Fehler.
var user = new ModernUser
{
    Username = "DevMaster",
    Email = "dev@code.com",
    Age = 25
};

Console.WriteLine($"User erstellt: {user.Username}, {user.Email}");

#endregion

#region Übung 2: Mischbetrieb (Order)

Console.WriteLine("\n--- Übung 2: Mischbetrieb (Order) ---");

// Konstruktor erzwingt ID ("ORD-2025-X"), Rest via Initializer
var order = new Order("ORD-2025-X")
{
    Product = "Gaming Laptop",
    Quantity = 1
};

Console.WriteLine($"Bestellung: {order.OrderId} | Produkt: {order.Product}");

#endregion

#region Übung 3: Visibility & Immutability

Console.WriteLine("\n--- Übung 3: Visibility Test ---");

var access = new AccessControl
{
    StandardProp = "A",     // OK: public set
    InitProp = "B",         // OK: init erlaubt Setzen beim Erstellen
    
    // PrivateSetProp = "C", // FEHLER CS0272: Setter ist private
    // ReadOnlyProp = "D"    // FEHLER CS0200: Property ist read-only
};

// Nachträgliche Änderungen
access.StandardProp = "A_Neu"; // OK

// access.InitProp = "B_Neu";       // FEHLER CS8852: Init-only properties können nach der Initialisierung nicht geändert werden.
// access.PrivateSetProp = "C_Neu"; // FEHLER CS0272: Setter ist unzugänglich.

Console.WriteLine($"Vor internem Change: {access.PrivateSetProp}");
access.ChangeInternals(); // Ruft Methode auf, die das private Feld ändert
Console.WriteLine($"Nach internem Change: {access.PrivateSetProp}");

#endregion

#region Übung 4: Guards & field Keyword

Console.WriteLine("\n--- Übung 4: Guards & field ---");

// Teil A & B: ModernFix (Schutz vor StackOverflow + Validierung)
var modernGuard = new ModernGuard();
try 
{
    modernGuard.Value = -5;
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Fehler abgefangen: {ex.Message}");
}
modernGuard.Value = 10;
Console.WriteLine($"ModernGuard Value: {modernGuard.Value}"); // Nutzt 'field'

// Teil C: Legacy mit Backing Field
var legacyGuard = new LegacyGuard();
legacyGuard.LegacyValue = 42;
Console.WriteLine($"LegacyGuard Value: {legacyGuard.LegacyValue}");

// Teil D: Sanity Check (Temperature)
var sensor = new TemperatureSensor();
Console.WriteLine("Setze Temperatur auf -300°C...");
sensor.Celsius = -300; // Sollte Warnung zeigen und auf -273.15 korrigieren
Console.WriteLine($"Sensor Wert: {sensor.Celsius}°C");

#endregion

Console.WriteLine("\n=== ENDE WORKSHOP ===");


#region Übung 5: Collection Initializers

Console.WriteLine("\n--- Übung 5: Collection Initializers ---");

// Teil A: Liste
// Statt 6 Zeilen -> 1 Ausdruck
List<string> cities = new List<string> 
{ 
    "Wien", 
    "Berlin", 
    "Zürich", 
    "München", 
    "Hamburg" 
};
Console.WriteLine($"Städte initialisiert: {cities.Count}");

// Teil B: Dictionary
// Statt 6 Zeilen -> 1 Ausdruck
Dictionary<int, string> errorCodes = new Dictionary<int, string>
{
    { 404, "Not Found" },
    { 500, "Internal Server Error" },
    { 401, "Unauthorized" },
    { 403, "Forbidden" },
    { 200, "OK" }
};
// Hinweis: In modernem C# geht auch der "Index Initializer":
// [404] = "Not Found",
Console.WriteLine($"Fehlercodes initialisiert: {errorCodes.Count}");

// Teil C: Nested Dictionary<List>
// Das hier ist der größte Gewinn an Lesbarkeit. Die Struktur der Daten ist optisch sofort erkennbar.
var departments = new Dictionary<string, List<string>>
{
    { 
        "Development", 
        new List<string> { "Alice", "Bob" } 
    },
    { 
        "Human Resources", 
        new List<string> { "Charly", "Dana" } 
    }
};

Console.WriteLine("Departments Struktur:");
foreach(var dept in departments)
{
    Console.WriteLine($" - {dept.Key}: {string.Join(", ", dept.Value)}");
}

#endregion

// ---------------------------------------------------------
// KLASSEN DEFINITIONEN
// ---------------------------------------------------------

#region Klassen Übung 1

public class ModernUser
{
    // 'required' erzwingt, dass diese Property im Object Initializer gesetzt wird.
    // Ersetzt den Zwang durch Konstruktoren.
    public required string Username { get; set; }
    
    public string? Email { get; set; }
    public int Age { get; set; }
}

#endregion

#region Klassen Übung 2

public class Order
{
    // Kann nur im Konstruktor gesetzt werden
    public string OrderId { get; } 

    public string? Product { get; set; }
    public int Quantity { get; set; }

    // Konstruktor für die zwingende ID ("Ist-Beziehung" oder Identity)
    public Order(string orderId)
    {
        OrderId = orderId;
    }
}

#endregion

#region Klassen Übung 3

public class AccessControl
{
    // 1. Standard: Lesen/Schreiben immer erlaubt
    public string StandardProp { get; set; } = string.Empty;

    // 2. Init: Schreiben nur im Initializer erlaubt (Immutable danach)
    public string InitProp { get; init; } = string.Empty;

    // 3. Private Set: Lesen public, Schreiben nur innerhalb der Klasse
    public string PrivateSetProp { get; private set; } = "Original";

    // 4. Read Only: Nur Getter (muss hier oder im Ctor initialisiert werden)
    public string ReadOnlyProp { get; } = "ReadOnly";

    // Methode ändert PrivateSetProp (interner Zugriff erlaubt)
    public void ChangeInternals()
    {
        PrivateSetProp = "Intern Geändert";
    }
}

#endregion

#region Klassen Übung 4

// Teil B: Modern Fix mit 'field'
public class ModernGuard
{
    public int Value
    {
        get;
        set
        {
            if (value < 0) throw new ArgumentException("Darf nicht negativ sein!");
            
            // 'field' ist das vom Compiler generierte Backing-Field.
            // Es verhindert die Endlosschleife (StackOverflow), die bei "Value = value" entstehen würde.
            field = value; 
        }
    }
}

// Teil C: Legacy Fix
public class LegacyGuard
{
    private int _legacyValue; // Explizites Backing Field

    public int LegacyValue
    {
        get => _legacyValue; // Lambda Syntax
        set
        {
            // Hier greifen wir auf das explizite Feld zu
            _legacyValue = value;
        }
    }
}

// Teil D: Temperature Sensor
public class TemperatureSensor
{
    public double Celsius
    {
        get;
        set
        {
            if (value < -273.15)
            {
                Console.WriteLine(">> WARNUNG: Wert unter absolutem Nullpunkt. Korrigiere auf -273.15.");
                field = -273.15; // Setze internen Speicher auf Minimum
            }
            else
            {
                field = value; // Setze internen Speicher auf Eingabewert
            }
        }
    }
}

#endregion
