//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Text;
//using static System.Net.Mime.MediaTypeNames;

//public class Program
//{
//    // KONFIGURATION FÜR ÜBUNG 3
//    // WARNUNG: Bei 100_000_000 kann der RAM-Verbrauch > 10 GB steigen!
//    // Zum Testen auf 1_000_000 lassen.
//    const int HAMSTER_COUNT = 1_000_000;

//    public static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;
//        Console.WriteLine("=== LÖSUNG: REFERENZ- VS WERTDATENTYPEN & MEMORY ===\n");

//        RunExercise0();
//        RunExercise1();
//        RunExercise2();
//        RunExercise3_HamsterCheck();

//        Console.WriteLine("\n=== ENDE DER LÖSUNG ===");
//    }

//    // ---------------------------------------------------------
//    // ÜBUNG 0: STRING IDENTITÄT
//    // ---------------------------------------------------------
//    static void RunExercise0()
//    {
//        Console.WriteLine("--- Übung 0: String Interning vs. New ---");

//        // Fall A: String Literale
//        string s1 = "Test";
//        string s2 = "Test"; // Der Compiler nutzt automatisch dieselbe Referenz (Intern Pool)

//        // Fall B: Erzwungene neue Allokation
//        // new string(...) umgeht den Pool und fordert frischen Heap-Speicher an
//        string s3 = new string("Test");

//        Console.WriteLine($"s1 ('Test') == s2 ('Test') Inhalt gleich?  : {s1 == s2}");
//        Console.WriteLine($"s1 und s2 zeigen auf selbe Adresse?        : {object.ReferenceEquals(s1, s2)} (Erwartet: True)");

//        Console.WriteLine($"s1 ('Test') == s3 (new ...) Inhalt gleich? : {s1 == s3}");
//        Console.WriteLine($"s1 und s3 zeigen auf selbe Adresse?        : {object.ReferenceEquals(s1, s3)} (Erwartet: False)");

//        Console.WriteLine("-> Erkenntnis: = \"...\" nutzt Speicher gemeinsam (Flyweight), new string() nicht.\n");

//        Console.WriteLine("Wir setzen nun s1 gleich s3 -> der Zuweisungsoperator legt nun die Referenz in s1 welche auf die Daten im Pool 'Test' zeigt, um auf den Ort im Speicher von den Daten von s3.");
        
//        s1 = s3;
//        Console.WriteLine($"s1 ('Test') == s2 ('Test') Inhalt gleich?  : {s1 == s2}");
//        Console.WriteLine($"s1 und s2 zeigen auf selbe Adresse?        : {object.ReferenceEquals(s1, s2)} (Erwartet: False)");

//        Console.WriteLine($"s1 ('Test') == s3 (new ...) Inhalt gleich? : {s1 == s3}");
//        Console.WriteLine($"s1 und s3 zeigen auf selbe Adresse?        : {object.ReferenceEquals(s1, s3)} (Erwartet: True)");

//        Console.WriteLine("-> Erkenntnis: Wir können wenn wir new string nutzen string wie referenzdaten benutzen und die referenzen verändern.\n");

//        Console.WriteLine("Wir manipulieren nun s3 und sagen es ist eine andere Variable. Was passiert mit s1?");
//        s3 = new string("anderer string aber mit new");

//        Console.WriteLine($"s1 ('Test') == s2 ('Test') Inhalt gleich?  : {s1 == s2}");
//        Console.WriteLine($"s1 und s2 zeigen auf selbe Adresse?        : {object.ReferenceEquals(s1, s2)} (Erwartet: False)");

//        Console.WriteLine($"s1 ('Test') == s3 (new ...) Inhalt gleich? : {s1 == s3}");
//        Console.WriteLine($"s1 und s3 zeigen auf selbe Adresse?        : {object.ReferenceEquals(s1, s3)} (Erwartet: False)");

//        Console.WriteLine("-> Erkenntnis: Wir legen die Referenzen um, das hat jedoch keinen Effekt auf s1. Die Logik, wenn s1 'das gleiche' wie s3 ist, dann muss auch wenn ich s3 ändere auch s1 sich ändern ist falsch! Siehe kleines bild in der Angabe.\n");


//        // 1. Objekt erstellen
//        Auto auto1 = new Auto();
//        auto1.Farbe = "Rot";

//        // 2. REFERENZ KOPIEREN (Aliasing)
//        // Beide Variablen zeigen jetzt auf dasselbe Auto im Speicher.
//        Auto auto2 = auto1;

//        Console.WriteLine($"Auto 1 ist: {auto1.Farbe}"); // Rot

//        // 3. SEITENEFFEKT AUSLÖSEN
//        // Wir nutzen den PUNKT (.), um dem "Kabel" zum Objekt zu folgen
//        // und dort den Wert zu ändern.
//        auto2.Farbe = "Blau";

//        // 4. BEWEIS
//        // Obwohl wir 'auto1' nicht angefasst haben, hat es sich geändert.
//        Console.WriteLine($"Auto 1 ist jetzt: {auto1.Farbe}"); // Blau!

//    }

//    // ---------------------------------------------------------
//    // ÜBUNG 1: STACK ODER HEAP?
//    // ---------------------------------------------------------
//    class ContainerClass
//    {
//        public int Number; // Wo liegt das?
//    }

//    static void RunExercise1()
//    {
//        Console.WriteLine("--- Übung 1: Stack vs Heap Container ---");

//        // 'c' ist eine lokale Variable (Referenz) -> Liegt auf dem STACK.
//        // Das Objekt 'new ContainerClass()' -> Liegt auf dem HEAP.
//        ContainerClass c = new ContainerClass();
//        c.Number = 42;

//        Console.WriteLine($"Container erstellt. Wert: {c.Number}");
//        Console.WriteLine("-> Analyse: Die Variable 'c.Number' ist vom Typ int (Werttyp).");
//        Console.WriteLine("   DA SIE ABER Teil einer Klasse ist, liegt sie physisch im HEAP innerhalb des Objekts.");
//        Console.WriteLine("   Regel: Der Container bestimmt den Speicherort, nicht der Typ selbst.\n");
//    }

//    // ---------------------------------------------------------
//    // ÜBUNG 2: ALIASING & SEITENEFFEKTE
//    // ---------------------------------------------------------
//    class RefPoint { public int X; }
//    struct ValPoint { public int X; }

//    static void RunExercise2()
//    {
//        Console.WriteLine("--- Übung 2: Aliasing (Class vs Struct) ---");

//        // 1. Klasse (Referenztyp)
//        RefPoint refA = new RefPoint { X = 10 };
//        RefPoint refB = refA; // Kopiert nur die ADRESSE (Pointer)
//        refB.X = 999;         // Ändert das Objekt, auf das AUCH refA zeigt

//        Console.WriteLine($"Class RefA.X nach Änderung von RefB: {refA.X} (Seiteneffekt!)");

//        // 2. Struct (Werttyp)
//        ValPoint valA = new ValPoint { X = 10 };
//        ValPoint valB = valA; // Kopiert den GANZEN INHALT (Werte)
//        valB.X = 999;         // Ändert nur die Kopie

//        Console.WriteLine($"Struct ValA.X nach Änderung von ValB: {valA.X} (Unverändert)");
//        Console.WriteLine("-> Erkenntnis: Zuweisungen bei Klassen erzeugen Aliases (mehrere Namen für selbes Objekt).\n");
//    }

//    // ---------------------------------------------------------
//    // ÜBUNG 3: DER HAMSTER (MEMORY ANALYSIS)
//    // ---------------------------------------------------------
//    public class Hamster
//    {
//        // -----------------------------------------------------
//        // HIER DIE VERSIONEN EINKOMMENTIEREN ZUM TESTEN
//        // -----------------------------------------------------

//        // FALL 1: Static (Bester Speicherverbrauch neben Empty)
//        // static string darstellung = "🐹"; 

//        // FALL 2: Literal (Gut, da String Pool genutzt wird)
//        // string darstellung = "🐹"; 

//        // FALL 3: New Object (Schlecht: Jeder Hamster hat eigenen String)
//        string darstellung = new string("🐹");

//        // FALL 4: Leer (Nichts einkommentieren)
//    }

//    static void RunExercise3_HamsterCheck()
//    {
//        Console.WriteLine("--- Übung 3: Memory Analysis (Hamster) ---");
//        Console.WriteLine($"Erstelle {HAMSTER_COUNT:N0} Hamster...");

//        long memoryBefore = GC.GetTotalMemory(true);

//        var hamsters = new List<Hamster>(HAMSTER_COUNT);
//        for (int i = 0; i < HAMSTER_COUNT; i++)
//        {
//            hamsters.Add(new Hamster());
//        }

//        long memoryAfter = GC.GetTotalMemory(true);
//        double mbUsed = (memoryAfter - memoryBefore) / (1024.0 * 1024.0);

//        Console.WriteLine($"Verbrauchter Speicher (Managed Heap): {mbUsed:F2} MB");

//        GC.KeepAlive(hamsters);
//        PrintHamsterSolutions();
//    }

//    static void PrintHamsterSolutions()
//    {
//        Console.WriteLine("\n--- LÖSUNGEN ZU DEN FRAGEN (Übung 3) ---");

//        Console.WriteLine("A) WARUM UNTERSCHIEDLICHES VERHALTEN?");
//        Console.WriteLine("   1. Static: Das Feld 'darstellung' existiert nur 1x im Speicher (am Typ-Objekt), egal wie viele Hamster.");
//        Console.WriteLine("      Der Hamster selbst ist fast leer. -> Geringster Speicher.");
//        Console.WriteLine("   2. Literal \"🐹\": Das String-Objekt liegt im 'Internal String Pool'.");
//        Console.WriteLine("      Jeder Hamster hat eine Referenz (8 Byte), aber ALLE zeigen auf denselben String im Pool.");
//        Console.WriteLine("      Speicher = (N * Hamster) + (1 * String).");
//        Console.WriteLine("   3. new string(...): Hier wird der Pool umgangen.");
//        Console.WriteLine("      Jeder Hamster erzeugt ein NEUES String-Objekt am Heap.");
//        Console.WriteLine("      Speicher = (N * Hamster) + (N * String). Das explodiert.");
//        Console.WriteLine("   4. Leer: Nur der Overhead für das Hamster-Objekt selbst und der List-Eintrag.");

//        Console.WriteLine("\nB) RECHNUNG (Überschlag für 100 Mio Hamster):");
//        Console.WriteLine("   Grundlast (List): 100 Mio * 8 Byte (Pointer Array) ≈ 800 MB.");
//        Console.WriteLine("   Hamster-Objekt: Header (16) = Min 24 Byte (mit Padding).");
//        Console.WriteLine("   -> 100 Mio * 24 Byte ≈ 2400 MB.");
//        Console.WriteLine("   -> Basis (Leer/Static): 800 + 2400 ≈ 3.2 GB. (Passt zu Output ~3.3 GB)");
//        Console.WriteLine("   ");
//        Console.WriteLine("   Zusatz bei 'new string(\"🐹\")':");
//        Console.WriteLine("   Ein String-Objekt: Header(16) + Länge(4) + Chars(4) + Null(2) + Padding ≈ 32-48 Byte.");
//        Console.WriteLine("   -> 100 Mio * ~48 Byte Overhead ≈ 4.8 GB extra?");
//        Console.WriteLine("   -> Tatsächlich ist der Overhead pro Objekt im .NET Heap oft höher (MethodTable Ptr, SyncBlock).");
//        Console.WriteLine("   -> Die Differenz von 3.3 GB auf 10 GB sind ca 6.7 GB für Strings.");
//        Console.WriteLine("   -> Das entspricht ca. 67 Byte pro String-Allokation (Objekt + Referenz). Das ist realistisch.");

//        Console.WriteLine("\nC) UNICODE & SURROGATE PAIRS:");
//        Console.WriteLine("   Frage: Warum 2 * 2 Bytes für 1 Hamster?");
//        Console.WriteLine("   Antwort: C# nutzt UTF-16 Encoding im RAM.");
//        Console.WriteLine("   Ein 'char' sind 16 Bit (2 Byte). Damit kann man Werte bis 65.535 darstellen.");
//        Console.WriteLine("   Emojis (wie 🐹) liegen aber im Unicode-Bereich über 65.535 (Astral Planes).");
//        Console.WriteLine("   Sie benötigen ZWEI chars ('High Surrogate' + 'Low Surrogate'), um dargestellt zu werden.");
//        Console.WriteLine("   Daher: 2 Chars * 2 Byte = 4 Byte Nutzdaten nur für das Icon.");
//    }
//}

//// Wir brauchen eine Klasse (Mutable Reference Type)
//public class Auto
//{
//    public string Farbe;
//}