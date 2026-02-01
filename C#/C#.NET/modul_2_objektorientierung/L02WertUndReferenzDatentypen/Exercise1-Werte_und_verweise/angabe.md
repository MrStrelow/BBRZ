# Übung: Referenz- vs. Wertdatentypen
---

## Übung 0: String – Der "spezielle" Referenztyp

Strings sind Referenztypen (Klassen), fühlen sich aber oft an wie Werttypen. Das liegt an der **Immutability** (Unveränderlichkeit) und dem **Interning**.

**Aufgabe:**
Schreibe ein kleines Programm, das die Identität von Strings vergleicht. Wir nutzen `object.ReferenceEquals(a, b)`, um zu prüfen, ob zwei Variablen wirklich auf **dieselbe Speicheradresse** zeigen.

1.  Erstelle `string a = "Test";` und `string b = "Test";`. Prüfe ReferenceEquals.
2.  Erstelle `string c = new string("Test".ToCharArray());` (oder nutze `new string('x', 5)`). Prüfe ReferenceEquals mit `a`.

**Frage:** Warum verhalten sich 1 und 2 unterschiedlich, obwohl der Inhalt gleich ist?

```csharp
string s1 = "Hallo";
string s2 = "Hallo";
string s3 = new string("Hallo"); // Erzwingt neue Speicherallokation

Console.WriteLine($"a)");
Console.WriteLine($"s1 == s2 (Inhalt): {s1 == s2}");
Console.WriteLine($"s1 same Ref as s2: {object.ReferenceEquals(s1, s2)}"); // Erwarte True (Intern Pool)

Console.WriteLine($"s1 == s3 (Inhalt): {s1 == s3}");
Console.WriteLine($"s1 same Ref as s3: {object.ReferenceEquals(s1, s3)}"); // Erwarte False

Console.WriteLine("b) Wir setzen nun s1 gleich s3 -> der Zuweisungsoperator legt nun die Referenz in s1 welche auf die Daten im Pool 'Test' zeigt, um auf den Ort im Speicher von den Daten von s3.");

s1 = s3;
Console.WriteLine($"s1 ('Test') == s2 ('Test') Inhalt gleich?  : {s1 == s2}");
Console.WriteLine($"s1 und s2 zeigen auf selbe Adresse?        : {object.ReferenceEquals(s1, s2)}");

Console.WriteLine($"s1 ('Test') == s3 (new ...) Inhalt gleich? : {s1 == s3}");
Console.WriteLine($"s1 und s3 zeigen auf selbe Adresse?        : {object.ReferenceEquals(s1, s3)}");

Console.WriteLine("c) Wir manipulieren nun s3 und sagen es ist eine andere Variable. Was passiert mit s1?");
s3 = "anderer string"; // new string("anderer string aber mit new"); //macht keinen wirklichen unterschied 

Console.WriteLine($"s1 ('Test') == s2 ('Test') Inhalt gleich?  : {s1 == s2}");
Console.WriteLine($"s1 und s2 zeigen auf selbe Adresse?        : {object.ReferenceEquals(s1, s2)}");

Console.WriteLine($"s1 ('Test') == s3 (new ...) Inhalt gleich? : {s1 == s3}");
Console.WriteLine($"s1 und s3 zeigen auf selbe Adresse?        : {object.ReferenceEquals(s1, s3)}");
```

#### Bild für c
Die Pfeile sind die Referenzen.

Vor der manipulation von s3.
```
Stack          Heap (String Pool / Heap)
-----          -------------------------
s1  ---------> [ "Test" ]
                  ^
s3  --------------|
```

Nach der manipulation von s3.
```
Stack          Heap
-----          ----
s1  ---------> [ "Test" ]  <-- s1 zeigt immer noch hierhin!

s3  ---------> [ "anderer string" ]   <-- s3 zeigt jetzt hierhin.
```
---

## Übung 1: Stack oder Heap? Die Container-Regel

Ein häufiges Missverständnis ist: *"Int liegt immer am Stack, Klassen immer am Heap."*
Das ist **falsch**. Ein Werttyp (int, bool, struct) liegt dort, wo sein Container liegt.

**Aufgabe:**
1.  Erstelle eine Klasse `ContainerClass` mit einem `public int Number;`.
2.  Erstelle eine Instanz davon: `var c = new ContainerClass();`.

**Analyse (Gedankenexperiment):**
* Die Variable `c` liegt auf dem **Stack** (als Referenz/Pointer).
* Das Objekt `ContainerClass` liegt auf dem **Heap** (wegen `new`).
* **Frage:** Wo liegt das `int Number`?
    * Es ist Teil des Objekts auf dem Heap. Es verbraucht dort 4 Byte innerhalb des Speicherblocks der Klasse.

> **Merke:** Instanzvariablen (Felder) von Klassen landen immer auf dem Heap, auch wenn sie primitive Typen (int, byte) sind. Nur lokale Variablen in Methoden (die keine Closures sind) landen auf dem Stack.

---

## Übung 2: Aliasing & Seiteneffekte (Klasse vs. Struct)

Hier beweisen wir den Unterschied zwischen Kopieren einer Referenz (Pointer) und Kopieren eines Wertes.

**Aufgabe:**
1.  Erstelle eine Klasse `RefPoint` mit `X` und `Y`.
2.  Erstelle ein Struct `ValPoint` mit `X` und `Y`.
3.  Führe folgenden Code aus und erkläre das Ergebnis:

```csharp
// 1. Referenztyp Szenario
RefPoint a = new RefPoint { X = 10 };
RefPoint b = a; // Kopiert nur die "Fernbedienung" (Adresse), nicht das Objekt!
b.X = 999;

Console.WriteLine($"Klasse A.X: {a.X}"); // Wurde A verändert? Warum?

// 2. Werttyp Szenario
ValPoint v1 = new ValPoint { X = 10 };
ValPoint v2 = v1; // Kopiert den echten Inhalt (Werte X und Y)
v2.X = 999;

Console.WriteLine($"Struct V1.X: {v1.X}"); // Wurde V1 verändert?
```

**Erkenntnis:** Bei Klassen (Referenztypen) müssen wir immer mit **Seiteneffekten** rechnen (Aliasing), wenn wir Variablen zuweisen. Bei Structs (Werttypen) sind die Daten isoliert.

---

## Übung 3: Deep Dive – Memory Consumption & Flyweight

In dieser Übung analysieren wir den Speicherverbrauch basierend auf Referenz-Design. Wir nutzen das **Flyweight Pattern** (Fliegengewicht), indem wir Objekte teilen (`static` oder String Interning), anstatt sie millionenfach neu zu erstellen.

### Szenario: Die Hamster-Invasion
Wir erstellen 100.000.000 Hamster. Je nachdem, wie wir den String im Hamster speichern, explodiert der Arbeitsspeicher oder bleibt moderat.

**Code Vorlage:**

```csharp
using System.Diagnostics;
using System.Text;

// Beginne hier zu lesen!
public class Programm
{
    public class Hamster
    {
        // Version 1: Static (1x im Speicher für ALLE Hamster)
        // static string darstellung_static = "🐹"; 
        
        // Version 2: String Literal (Nutzt Internal String Pool -> 1x Referenz pro Hamster, aber Text geteilt)
        // string darstellung_instance_interned = "🐹"; 
        
        // Version 3: Explizites New (Jeder Hamster hat seinen EIGENEN String am Heap)
        string darsellung_instance_new = new string("🐹");
        
        // Version 4: Leere Klasse
        // kommentiere alles oben aus und definiere damit eine leere Klasse.
    }

    static void Main(string[] args)
    {
        // Beende hier zu lesen!
        Console.OutputEncoding = Encoding.UTF8;

        long memoryBefore = GC.GetTotalMemory(true);
        
        // Beginne hier zu lesen!
        var hamsters = new List<Hamster>(100_000_000); // Pre-Sizing für Performance
        for (int i = 0; i < 100_000_000; i++)
        {
            hamsters.Add(new Hamster());
        }

        // Beende hier zu lesen!
        long memoryAfter = GC.GetTotalMemory(true);
        
        long memoryUsedByGC = memoryAfter - memoryBefore;

        Console.WriteLine($"Approximate managed memory used: {memoryUsedByGC / (1024.0 * 1024.0):F2} MB");

        GC.KeepAlive(hamsters); // Verhindert, dass der GC aufräumt bevor wir messen
    }
}
```

**Messwerte (Referenz):**
1.  **static ... "🐹"**: ~3312 MB
2.  **literal "🐹"**: ~4075 MB
3.  **new string("🐹")**: ~10179 MB
4.  **Leere Klasse**: ~3312 MB

### Aufgaben zur Analyse

Bitte beantworte die folgenden Fragen detailliert basierend auf den Messwerten.

#### a) Verhalten von Referenzdaten
Begründe, warum die 4 Fälle so unterschiedlich viel Speicher brauchen. Gehe dabei auf folgende Punkte ein:
* **Visualisierung:** Wenn wir 100 Mio. Hamster haben: Wie viele Pfeile (Referenzen) zeigen worauf?
    * *Fall 1 (Static):* Wo liegt das Feld? Haben die Instanzen überhaupt einen Overhead?
    * *Fall 3 (New String):* Zeigen alle auf das Gleiche oder jeder auf etwas Eigenes?
* **String Pool:** Warum ist Fall 2 ("🐹") viel sparsamer als Fall 3 (`new string`), obwohl beides Instanz-Variablen sind? Was macht der **Internal String Pool** hier?

#### b) Rechenübung (Speicherbedarf prüfen)
Versuche rechnerisch nachzuvollziehen, warum die Gigabyte-Zahlen (GB) plausibel sind.

**Nutze diese Faustregeln für 64-Bit Systeme:**
1.  **Referenz (Pointer):** 8 Byte.
2.  **Object Header (Verwaltung):** 16 Byte (Minimum pro Objekt am Heap).
3.  **Minimum Objektgröße:** Ein Objekt ist immer min. 24 Byte (Header + Daten, oft aufgerundet auf 8er Schritte -> 24 oder 32 Byte).
4.  **String Objekt:** * Header (16 Byte) 
    * + Länge (4 Byte) 
    * + Zeichen (2 Byte pro Char) 
    * + Null-Terminator/Padding.
    * *Annahme:* Ein String mit 1 Emoji ("🐹") benötigt ca. **32 Byte** (inkl. Overhead).

**Berechne:**
* **Zu Fall 4 (Leere Klasse):** 100.000.000 Hamster * (Header 16 Byte + Min. Padding/Alignment auf 24 Byte).
    Kommst du in die Nähe von ~2.4 - 3.3 GB? (Beachte: Die `List<Hamster>` selbst braucht auch Speicher für das interne Array, welches 100 Mio Referenzen hält -> 100 Mio * 8 Byte = 800 MB).
    
* **Zu Fall 3 (New String):**
    Rechne: (Größe aller Hamster-Objekte wie in Fall 4) + (100.000.000 * Größe eines String-Objekts).
    Passt das zu den ~10 GB?

#### c) Detailfrage zu Unicode
Der Hamster 🐹 ist ein Emoji.
Warum rechnen wir bei der String-Größe mit **`2 * 2 bytes`** für den Character-Teil?
Ein normales `char` in C# ist 16 Bit (2 Byte).
* Reicht ein `char`, um einen Hamster darzustellen?
* Recherchiere kurz den Begriff "Surrogate Pair" in UTF-16.