# Übung: Modernes C# – Properties & Object Initializer

Diese Übung führt von klassischen Java-Stil Gettern/Settern hin zu modernen C# Features wie `init`, `required` und dem neuen `field` Keyword aus .NET 10.

---

## Übung 1: Vom Legacy Code zu Modern C#

Wir haben eine alte Klasse `LegacyUser`, die sehr explizit geschrieben ist. Sie nutzt Felder, manuelle Methoden und erzwingt Daten über Konstruktoren.

**Aufgabe:**
Refactore diesen Code in eine neue Klasse `ModernUser`.

**Anforderungen:**
1.  Ersetze die `Get` und `Set` Methoden durch **Auto-Properties**.
2.  Entferne alle 3 Konstruktoren.
3.  Das Feld `_username`, welches in den alten Konstruktoren immer gesetzt werden musste, soll durch das `required` Keyword erzwungen werden.
4.  Erstelle eine Instanz der neuen Klasse in der `Program.cs` unter Verwendung des **Object Initializers**.

**Legacy Code (Vorlage):**
```csharp
public class LegacyUser
{
    private string _username; // Muss immer da sein
    private string _email;
    private int _age;

    // Konstruktor 1
    public LegacyUser(string username)
    {
        _username = username;
    }

    // Konstruktor 2
    public LegacyUser(string username, string email)
    {
        _username = username;
        _email = email;
    }

    // Konstruktor 3
    public LegacyUser(string username, string email, int age)
    {
        _username = username;
        _email = email;
        _age = age;
    }

    public string GetUsername() => _username;
    // Kein Setter für Username (simulierte Immutability)

    public void SetEmail(string email) { _email = email; }
    public string GetEmail() { return _email; }
}
```

**Ziel-Syntax (Instanziierung):**
```csharp
var user = new ModernUser 
{ 
    Username = "DevMaster", 
    Email = "dev@code.com" 
};
```

---

## Übung 2: Mischbetrieb (Konstruktor + Initializer)

Oft gibt es Szenarien, wo bestimmte Daten zwingend über einen Konstruktor kommen müssen (z.B. Abhängigkeiten oder IDs, die Logik auslösen), aber der Rest optional ist.

**Aufgabe:**
1.  Erstelle eine Klasse `Order`.
2.  Diese soll einen Konstruktor haben, der eine `OrderId` (string) annimmt.
3.  Die `OrderId` darf **nicht** im Object Initializer auftauchen (nur getter).
4.  Füge Properties für `Product` (string) und `Quantity` (int) hinzu.
5.  Erstelle eine Instanz, die den Konstruktor nutzt, aber gleichzeitig `Product` und `Quantity` über den Object Initializer setzt.

**Erwartetes Ergebnis:**
```csharp
var order = new Order("ORD-2025-X")
{
    Product = "Laptop",
    Quantity = 1
};
```

---

## Übung 3: Visibility & Immutability (Reverse Engineering)

In dieser Übung ist der **Konsumenten-Code** (Program.cs) gegeben. Deine Aufgabe ist es, die Klasse `AccessControl` zu schreiben, damit die unten beschriebenen Regeln gelten.

**Gegebener Code (Program.cs - Top Level Statements):**
Kopiere das in deine `Program.cs`. Kommentiere die Fehlerzeilen ein, um zu prüfen, ob deine Klasse korrekt implementiert ist (der Compiler muss dort meckern).

```csharp
Console.WriteLine("--- Visibility Test ---");

var obj = new AccessControl
{
    StandardProp = "A",     // Muss funktionieren
    InitProp = "B",         // Muss funktionieren
    
    // PrivateSetProp = "C", // FEHLER ERWARTET: Darf hier nicht setzbar sein
    // ReadOnlyProp = "D"    // FEHLER ERWARTET: Darf kein Set haben
};

// Nachträgliche Änderungen testen
obj.StandardProp = "A_Neu"; // Muss funktionieren

// obj.InitProp = "B_Neu";       // FEHLER ERWARTET: Darf nur bei Init gesetzt werden
// obj.PrivateSetProp = "C_Neu"; // FEHLER ERWARTET: Setter ist private

obj.ChangeInternals(); // Methode in der Klasse, die PrivateSetProp ändert -> Muss gehen
```

**Aufgabe:**
Schreibe die Klasse `AccessControl`, sodass die obigen Regeln gelten:
1.  `StandardProp`: Darf immer gelesen und geschrieben werden.
2.  `InitProp`: Darf nur bei der Initialisierung geschrieben werden (`init`).
3.  `PrivateSetProp`: Darf von außen gelesen, aber nur von innen geschrieben werden (`private set`).
4.  `ReadOnlyProp`: Darf gar kein `set` oder `init` haben (nur `get`).
5.  Methode `ChangeInternals()`: Setzt `PrivateSetProp` auf einen neuen Wert.

**Zusatzaufgabe (Visibility):**
Ändere in deiner fertigen Klasse `InitProp` so ab, dass der `get` Teil `public` bleibt, aber der `init` Teil `protected` ist. Versuche den Code oben erneut zu kompilieren. Was passiert im Object Initializer?

**Daumenregeln (Merken!):**

> **Regel 1: Visibility & Mutability**
> * **`public ... { get; init; }`**: Der Standard für DTOs. Immutable nach Erstellung.
> * **`public ... { get; set; }`**: Wenn sich der Wert von außen ändern muss.
> * **`public ... { get; private set; }`**: Wenn Logik in der Klasse den Wert ändert (DDD Style).

> **Regel 2: Ctor vs. Initializer**
> Starte immer mit **Object Initializern**. Steige erst auf **Konstruktoren** um, wenn du echte "Ist-Beziehungen" brauchst oder Konstruktor-Logik unverzichtbar ist.

---

## Übung 4: Guards & Das neue `field` Keyword (.NET 10)

Wir schauen uns an, wie man Validierung (Guards) in Properties einbaut und wie C# 13 / .NET 10 das vereinfacht.

### Teil A: Die Endlosschleife (Der Klassiker)
Kopiere diesen Code. Er enthält einen häufigen Anfängerfehler.
Führe ihn aus und beobachte die `StackOverflowException`.

```csharp
public class LoopExample
{
    public int Value
    {
        get { return Value; } // <--- Fehler hier
        set 
        { 
            // Validierung
            if (value < 0) value = 0;
            
            Value = value; // <--- Fehler hier: Ruft rekursiv den Setter auf
        }
    }
}
```

### Teil B: Modern Fix (.NET 10 Preview Feature)
Repariere die Klasse aus Teil A, indem du das neue Kontext-Keyword `field` verwendest.
Dies greift auf den internen Speicher der Property zu, ohne dass du selbst ein Feld deklarieren musst.

```csharp
// Benötigt <LangVersion>preview</LangVersion> in der .csproj
public int Value
{
    get;
    set
    {
        if (value < 0) throw new ArgumentException("Darf nicht negativ sein!");
        field = value; // 'field' ist der interne Speicher, 'value' der neue Wert
    }
}
```

### Teil C: Legacy Fix (Backing Fields & Lambda)
Es gibt Situationen (oder alte Codebases), wo man das Feld explizit sehen will.
Schreibe eine Property `LegacyValue`:
1.  Erstelle ein privates Feld `private int _legacyValue;`.
2.  Nutze im `get` den Lambda-Operator (`=>`), um das Feld zurückzugeben.
3.  Setze im `set` das Feld `_legacyValue`.

### Teil D: Sanity Checks
Erstelle eine Klasse `TemperatureSensor`.
Die Property `Celsius` soll folgende Logik im Setter haben (nutze das `field` Keyword):
* Wenn der Wert (`value`) unter -273.15 ist, gib eine Warnung auf der Konsole aus und setze `field` auf -273.15 (Physikalisches Minimum).
* Andernfalls setze `field` auf `value`.

Dies zeigt, wie `value` (Input Parameter) und `field` (interner Speicher/Variable) zusammenspielen.

```csharp
public double Celsius
{
    get;
    set
    {
        // Dein Guard Code hier...
    }
}
```

---

## Übung 5: Collection Initializers (Weniger Code, mehr Übersicht)

Bisher haben wir uns Eigenschaften (Properties) angesehen. C# bietet aber auch eine sehr mächtige Syntax, um Listen und Dictionaries zu initialisieren. Dies spart enorm viel Tipparbeit und reduziert "Boilerplate Code" (wiederkehrenden Standardcode).

**Aufgabe:**
Wir haben drei Szenarien, die im "alten Stil" (ähnlich wie in Java vor Java 9) geschrieben sind: Erst Instanziierung, dann viele einzelne `Add()`-Aufrufe.

**Deine Aufgabe:**
Schreibe die folgenden Code-Blöcke in der `Program.cs` neu. Verwende dabei **Collection Initializers**. Das Ziel ist, dass jede Datenstruktur in *einem einzigen Statement* (mit Semikolon am Ende) initialisiert wird.

### Teil A: Die Liste (List<T>)
Hier werden 5 Städte einzeln hinzugefügt. Das sind 6 Zeilen Code. Mach daraus eine (bzw. einen Block).

**Legacy Code:**
```csharp
List<string> cities = new List<string>();
cities.Add("Wien");
cities.Add("Berlin");
cities.Add("Zürich");
cities.Add("München");
cities.Add("Hamburg");
```

### Teil B: Das Dictionary (Dictionary<Key, Value>)
Hier werden 5 Fehlercodes und ihre Bedeutung gespeichert.
Verwende die Initializer-Syntax `{ key, value }` innerhalb der geschweiften Klammern des Dictionaries.

**Legacy Code:**
```csharp
Dictionary<int, string> errorCodes = new Dictionary<int, string>();
errorCodes.Add(404, "Not Found");
errorCodes.Add(500, "Internal Server Error");
errorCodes.Add(401, "Unauthorized");
errorCodes.Add(403, "Forbidden");
errorCodes.Add(200, "OK");
```

### Teil C: Verschachtelung (Nested Collections)
Hier zeigt sich die wahre Stärke. Wir haben ein Dictionary, dessen *Values* wiederum Listen sind (z.B. Abteilungen und ihre Mitarbeiter).
Im alten Stil muss man Hilfsvariablen für die Listen erstellen oder sehr umständlich tippen.

**Aufgabe:** Wandle dies in einen einzigen, sauberen Initialisierungsbaum um. Du brauchst keine Variablen wie `devs` oder `hr` mehr, du kannst die Listen direkt im Dictionary initialisieren (`new List<string> { ... }`).

**Legacy Code:**
```csharp
Dictionary<string, List<string>> departments = new Dictionary<string, List<string>>();

// Abteilung 1
List<string> devs = new List<string>();
devs.Add("Alice");
devs.Add("Bob");
departments.Add("Development", devs);

// Abteilung 2
List<string> hr = new List<string>();
hr.Add("Charly");
hr.Add("Dana");
departments.Add("Human Resources", hr);
```