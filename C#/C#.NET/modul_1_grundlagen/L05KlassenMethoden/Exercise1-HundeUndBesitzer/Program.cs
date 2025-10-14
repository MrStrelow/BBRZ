/*
 * Testsuite für die Klassen Mensch, HundeBesitzer, Hund, SchaeferHund und Pudel.
 *
 * Konzepte, die hier getestet und demonstriert werden:
 *
 * 1. Vererbung (Inheritance): HundeBesitzer erbt von Mensch, SchaeferHund und Pudel erben von Hund.
 * 2. Konstruktoren: Testen verschiedener Konstruktor-Überladungen (einschließlich Basisklassen-Aufrufe mit 'base' und Konstruktor-Verkettung mit 'this'). Der Copy-Konstruktor in Hund wird ebenfalls getestet.
 * 3. Assoziationen (Hat-Beziehungen): Testen der 0..1 (SpielFreund, LoveInterest) und 1..n (Hunde-Array in HundeBesitzer, behütete Hunde in SchaeferHund) Beziehungen.
 * 4. Reziproke Beziehungen: Die SpielFreund-Beziehung ist gegenseitig ('reziprok') und wird über SetSpielFreund() konsistent gehalten.
 * 5. Guard Clauses & Null-Referenzen: Testen von Methoden, die unerwünschte Zustände (z.B. SetBesitzer(null), AddHund bei Kapazitätslimit, Kaufen ohne Führerschein für Schäferhund) durch Prüfungen (Guard Clauses) verhindern oder steuern. Das schützt das Objekt vor inkonsistenten Zuständen.
 * 6. Downcasting/Upcasting: Testen der Bürsten-Methode in HundeBesitzer, die mit 'is Pudel pudel' ein Downcasting durchführt, um auf spezifische Pudel-Methoden/Felder (wie SetFluff) zuzugreifen.
 * 7. Method Redefinition (Method Hiding): Methoden der Basisklasse (z.B. GetDarstellung()) werden in abgeleiteten Klassen neu definiert (ohne 'override'). Bei Zugriff über eine Basisklassen-Referenz wird die Basisimplementierung aufgerufen.
 */

using Hunde;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("--- Vorbereitungen: Objekte erstellen ---");

// Initialisierung von Basis-Objekten
HundeBesitzer karo = new HundeBesitzer("Karo", 1.0, 25, false, 5); // Kapazität auf 5 erhöht für mehr Tests
Hund gilbert = new Hund("Gilbert", 1, "m", 10, false);
Hund frido = new Hund("Frido", 2, "w", 15, true);
Hund[] hunde = { frido, gilbert };
Hund[] mehrHunde = { new Hund("Bello", 3, "m", 8, true), new Hund("Lana", 4, "w", 12, false), new Hund("Max", 1, "m", 10, true) };

// Test der bestehenden Logik (SetSpielFreund ist reziprok)
Console.WriteLine($"\n--- Test 1: Reziproke SpielFreund-Beziehung (Hund.SetSpielFreund) ---");
Console.WriteLine($"ist frido.GetSpielFreund() null? {frido.GetSpielFreund() == null}");

gilbert.SetSpielFreund(frido);
Console.WriteLine($"Gilbert's Spielfreund: {gilbert.GetSpielFreund()}");
Console.WriteLine($"Frido's Spielfreund: {frido.GetSpielFreund()}"); // Sollte jetzt nicht mehr null sein!

// Test der bestehenden Logik (Kaufen/Fuettern)
Console.WriteLine($"\n--- Test 2: HundeBesitzer Aktionen (Kaufen, Fuettern) ---");
karo.Kaufen(frido); // Frido hat jetzt Karo als Besitzer
karo.Kaufen(gilbert); // Gilbert hat jetzt Karo als Besitzer
karo.Fuettern(Essen.Fleisch);

gilbert.Spielen();
frido.Spielen();

// Test der bestehenden Logik (Upcasting/Method Hiding)
Console.WriteLine($"\n--- Test 3: Mensch -> HundeBesitzer (Upcasting/Method Redefinition) ---");
Mensch hatBaldHunde = new Mensch("Walo", 0.1, 51);
Console.WriteLine($"Vor Umwandlung - Typ: {hatBaldHunde.GetType()} - Hash: {hatBaldHunde.GetHashCode()} - Darstellung {hatBaldHunde}");

hatBaldHunde = hatBaldHunde.WirdEinHundeBesitzer(new Hund("InitialHund", 1, "m", 10, false), hatHundeFuehrerschein: true, hunde.Length * 2);

Console.WriteLine($"Nach Umwandlung - Typ: {hatBaldHunde.GetType()} - Hash: {hatBaldHunde.GetHashCode()} - Darstellung {hatBaldHunde}");

Mensch hatNieHunde = new Mensch("Raldira", 0.5, 55);
Console.WriteLine($"HatNieHunde Darstellung: {hatNieHunde}");

Console.WriteLine("\n==============================================");
Console.WriteLine("--- ERWEITERTE TESTS FÜR ALLE KLASSENMETHODEN ---");
Console.WriteLine("==============================================");

// ===================================
// A. Mensch.cs Tests
// ===================================
Console.WriteLine("\n--- A. Mensch.cs Tests ---");

// Test A.1: Konstruktor mit LoveInterest
Mensch julia = new Mensch("Julia", 0.9, 30);
Mensch tom = new Mensch("Tom", 0.8, 32, julia);
julia.SetLoveInterest(tom); // Mutual Love

Console.WriteLine($"A.1: Julia und Tom haben Mutual Love: {julia.DetectMutualLove()}");

// Test A.2: MehrereHundeKaufen (Erfolgreich)
Hund[] tempHunde = mehrHunde.Where(h => h.GetBesitzer() == null).ToArray(); // Nur Hunde ohne Besitzer verwenden
HundeBesitzer lisa = julia.MehrereHundeKaufen(tempHunde, hatHundeFuehrerschein: false, capacity: 5);
if (lisa != null)
{
    Console.WriteLine($"A.2: Lisa ist jetzt HundeBesitzer ({lisa.GetName()}) und hat {lisa.GetHunde().Count(h => h != null)} Hunde gekauft.");
}

// Test A.3: MehrereHundeKaufen (Fehler: Kapazität zu klein) - Guard Clause
Console.Write("A.3: ");
HundeBesitzer fehlerLisa = julia.MehrereHundeKaufen(mehrHunde, hatHundeFuehrerschein: false, capacity: 2); // Sollte Konsolenausgabe machen
Console.WriteLine($"A.3: Lisa versucht 3 Hunde mit Kapazität 2 zu kaufen (sollte null sein): {fehlerLisa == null}");

// Test A.4: Get/Set und ToString()
tom.SetHappiness(0.95);
Console.WriteLine($"A.4: Tom's Happiness aktualisiert: {tom.GetHappiness()}");
Console.WriteLine($"A.4: Julia's Love Interest: {julia.GetLoveInterest().GetName()}");
Console.WriteLine($"A.4: Julia's ToString(): {julia.ToString()}");

// ===================================
// B. Hund.cs Tests
// ===================================
Console.WriteLine("\n--- B. Hund.cs Tests ---");

// Vorbereitung für Hund-Tests
HundeBesitzer hansi = new HundeBesitzer("Hansi", 0.7, 40, false, 3);
Hund rex = new Hund("Rex", 5, "m", 10, true);
Hund luna = new Hund("Luna", 3, "w", 12, false, hansi, rex); // Konstr. mit Besitzer & Spielfreund

// Test B.1: Konstruktor mit Besitzer & Spielfreund
Console.WriteLine($"B.1: Luna's Besitzer: {luna.GetBesitzer().GetName()}");
Console.WriteLine($"B.1: Rex's Spielfreund: {rex.GetSpielFreund().GetName()}"); // Reziprok geprüft

// Test B.2: Copy Constructor
Hund rexKopie = new Hund(rex);
Console.WriteLine($"B.2: Rex Kopie erstellt: {rexKopie.ToString()}. Gechippt? {rexKopie.IsChipped()}. Hat sie einen Besitzer? {rexKopie.GetBesitzer() == null}"); // Sollte keinen Besitzer haben

// Test B.3: Bellen & GetLautBeimBellen (Method Redefinition)
Console.Write("B.3: ");
Console.WriteLine($"Rex bellt (Geräusch): {rex.Bellen()}");
Console.WriteLine($"B.3: Rex Laut: {rex.GetLautBeimBellen()}");

// Test B.4: Fressen
Console.Write("B.4: ");
rex.Fressen(Essen.Trockenfutter);

// Test B.5: Weglaufen (Aufruf von HundeBesitzer.Aussetzen)
Console.WriteLine($"B.5: Luna ist bei Hansi: {hansi.BesitztHund(luna)}");
Console.Write("B.5: ");
luna.Weglaufen(); // Sollte Konsolenausgabe machen und Aussetzen aufrufen.
Console.WriteLine($"B.5: Luna ist bei Hansi nach Weglaufen: {hansi.BesitztHund(luna)}");
Console.WriteLine($"B.5: Luna hat keinen Besitzer mehr: {luna.GetBesitzer() == null}");

// Test B.6: SetBesitzer - Unerwünschte Zustände (null und bereits besessen) - Guard Clauses
Hund tobi = new Hund("Tobi", 1, "m", 5, false);
hansi.Kaufen(tobi); // Hansi besitzt Tobi
HundeBesitzer neuerBesitzer = new HundeBesitzer("Otto", 0.5, 35, false, 1);

Console.Write("B.6a: ");
tobi.SetBesitzer(hansi); // Sollte verhindern, da Tobi bereits besessen wird.
Console.Write("B.6b: ");
tobi.SetBesitzer(null); // Sollte Konsolenausgabe geben, da SetBesitzer einen *neuen* Owner erwartet und einen Guard Clause hat.

// Test B.7: Set/Get einfache Felder
rex.SetHealth(9.5);
Console.WriteLine($"B.7: Rex Health: {rex.GetHealth()}");
rex.SetGeschlecht("w");
Console.WriteLine($"B.7: Rex Geschlecht: {rex.GetGeschlecht()}");
Console.WriteLine($"B.7: Rex Darstellung: {rex.GetDarstellung()}");

// ===================================
// C. HundeBesitzer.cs Tests
// ===================================
Console.WriteLine("\n--- C. HundeBesitzer.cs Tests ---");

// Vorbereitung für HundeBesitzer-Tests
HundeBesitzer besitzerOtto = new HundeBesitzer("Otto", 0.5, 35, true, 2);
HundeBesitzer besitzerTina = new HundeBesitzer("Tina", 0.9, 28, false, 2);
Hund dackel = new Hund("Dackel", 4, "m", 7, false);
Hund terrier = new Hund("Terrier", 2, "w", 11, true);
Hund[] startHunde = { dackel };
// Test Konstruktor 2
HundeBesitzer besitzerMarie = new HundeBesitzer(
    hatBaldHunde, hatHundeFuehrerschein: true, startHunde, capacity: 5
);

// Test C.1: Konstruktor 2 und 3
Console.WriteLine($"C.1: Marie's Name aus Mensch übernommen: {besitzerMarie.GetName()}");
Console.WriteLine($"C.1: Marie besitzt den Dackel: {besitzerMarie.BesitztHund(dackel)}");
Console.WriteLine($"C.1: Marie's Darstellung (Redefiniert): {besitzerMarie.GetDarstellung()}");

// Test C.2: Kaufen mit SchaeferHund (Hundeführerschein-Prüfung) - Guard Clause
Hund[] maxHunde = { new Hund("H1", 1, "m", 10, false), new Hund("H2", 1, "m", 10, false) };
SchaeferHund max = new SchaeferHund("Max", 3, "m", 10, true, 2, maxHunde);
HundeBesitzer keinFuehrerschein = new HundeBesitzer("Karl", 0.5, 40, false, 3);
HundeBesitzer mitFuehrerschein = new HundeBesitzer("Erika", 0.5, 40, true, 3);

Console.Write("C.2a: ");
keinFuehrerschein.Kaufen(max); // Sollte Fehler ausgeben (Guard Clause)
Console.Write("C.2b: ");
mitFuehrerschein.Kaufen(max); // Sollte erfolgreich sein
Console.WriteLine($"C.2: Max's Besitzer (Erika): {max.GetBesitzer().GetName()}");

// Test C.3: AddHund - Kapazitätslimit - Guard Clause
Hund limitHund1 = new Hund("L1", 1, "m", 10, false);
Hund limitHund2 = new Hund("L2", 1, "m", 10, false);
Hund limitHund3 = new Hund("L3", 1, "m", 10, false);
HundeBesitzer kleinerBesitzer = new HundeBesitzer("Small", 0.5, 30, false, 2);

kleinerBesitzer.AddHund(limitHund1);
kleinerBesitzer.AddHund(limitHund2);
Console.Write("C.3: ");
kleinerBesitzer.AddHund(limitHund3); // Sollte Fehler ausgeben (Kapazität überschritten)

// Test C.4: AddHund - Duplikat und Null - Guard Clauses
Console.Write("C.4a: ");
kleinerBesitzer.AddHund(limitHund1); // Sollte Fehler ausgeben (Duplikat)
Console.Write("C.4b: ");
kleinerBesitzer.AddHund(null); // Sollte Fehler ausgeben (null)

// Test C.5: GassiGehen
Console.Write("C.5: ");
mitFuehrerschein.GassiGehen();

// Test C.6: Buersten (Downcasting zu Pudel)
Pudel lili = new Pudel("Lili", 2, "w", 10, true, 5.0);
Hund normalHund = new Hund("Normal", 1, "m", 10, false);
besitzerOtto.Kaufen(lili);
besitzerOtto.Kaufen(normalHund);
double liliHealthVorher = lili.GetHealth();
double liliFluffVorher = lili.GetFluff();

besitzerOtto.Buersten();

Console.WriteLine($"C.6: Lili Health: Vorher {liliHealthVorher}, Nachher {lili.GetHealth()} (Pudel +10)");
Console.WriteLine($"C.6: Normal Health: Vorher 10, Nachher {normalHund.GetHealth()} (Hund +1)");
Console.WriteLine($"C.6: Lili Fluff: Vorher {liliFluffVorher}, Nachher {lili.GetFluff()} (Pudel *2)");

// Test C.7: Verkaufen
Console.Write("C.7: ");
besitzerOtto.Verkaufen(lili, besitzerTina); // Lili wird bei Otto ausgesetzt und Tina als Besitzer zugewiesen (über SetBesitzer)
Console.WriteLine($"C.7: Lili's neuer Besitzer: {lili.GetBesitzer().GetName()}");
Console.WriteLine($"C.7: Tina besitzt Lili: {besitzerTina.BesitztHund(lili)}");
Console.WriteLine($"C.7: Otto besitzt Lili: {besitzerOtto.BesitztHund(lili)}"); // Sollte false sein

// Test C.8: Finden
Hund streuner = new Hund("Streuner", 6, "m", 5, false);
Console.Write("C.8: ");
besitzerOtto.Finden(streuner); // Finden ruft SetBesitzer auf, was auch AddHund macht
Console.WriteLine($"C.8: Streuner's Besitzer: {streuner.GetBesitzer().GetName()}");
Console.WriteLine($"C.8: Otto besitzt Streuner: {besitzerOtto.BesitztHund(streuner)}");

// ===================================
// D. SchaeferHund.cs Tests
// ===================================
Console.WriteLine("\n--- D. SchaeferHund.cs Tests ---");

// Vorbereitung für SchaeferHund-Tests
Hund[] zuHuetenInitial = { gilbert, frido };
SchaeferHund bello = new SchaeferHund("Bello", 5, "m", 15, true, 3, zuHuetenInitial);
// Test Konstruktor mit Besitzer & Spielfreund
SchaeferHund sally = new SchaeferHund("Sally", 4, "w", 12, true, 1, new Hund[1], besitzerOtto, max);

// Test D.1: Hueten
Console.Write("D.1: ");
bello.Hueten();

// Test D.2: HuetetBereitsHund
Console.WriteLine($"D.2: Bello hütet Frido: {bello.HuetetBereitsHund(frido)}");
Hund fremd = new Hund("Fremd", 1, "w", 10, false);
Console.WriteLine($"D.2: Bello hütet Fremd: {bello.HuetetBereitsHund(fremd)}");

// Test D.3: AddZuBehuetendeHunde (Erfolgreich)
bello.AddZuBehuetendeHunde(fremd);
Console.WriteLine($"D.3: Bello hütet Fremd nach Add: {bello.HuetetBereitsHund(fremd)}");

// Test D.4: AddZuBehuetendeHunde (Kapazität überschritten) - Guard Clause
Hund limitHund = new Hund("Limit", 1, "m", 10, false);
bello.AddZuBehuetendeHunde(limitHund); // Limit erreicht
Console.Write("D.4: ");
bello.AddZuBehuetendeHunde(new Hund("ZuViel", 1, "m", 10, false)); // Sollte Fehler ausgeben

// Test D.5: VerstoesseHund
bello.VerstoesseHund(gilbert);
Console.WriteLine($"D.5: Bello hütet Gilbert nach Verstoesse: {bello.HuetetBereitsHund(gilbert)}");

// Test D.6: Get/Set Capacity
bello.SetCapacity(5);
Console.WriteLine($"D.6: Bello neue Kapazität: {bello.GetCapacity()}");

// Test D.7: Method Redefinition (Darstellung/Bellen)
Console.WriteLine($"D.7: Bello Darstellung (Redefiniert): {bello.GetDarstellung()}");
Console.WriteLine($"D.7: Bello Laut (Redefiniert): {bello.GetLautBeimBellen()}");

// ===================================
// E. Pudel.cs Tests
// ===================================
Console.WriteLine("\n--- E. Pudel.cs Tests ---");

// Vorbereitung für Pudel-Tests
// Test Konstruktor mit allen Parametern
Pudel fiffi = new Pudel("Fiffi", 2, "m", 12, true, 8.0, besitzerOtto, max);

// Test E.1: Winseln
double healthVorher = fiffi.GetHealth();
Console.Write("E.1: ");
fiffi.Winseln(); // Sollte Konsolenausgabe machen
Console.WriteLine($"E.1: Fiffi Health: Vorher {healthVorher}, Nachher {fiffi.GetHealth()} (Winseln -1)");

// Test E.2: Get/Set Fluff
fiffi.SetFluff(10.5);
Console.WriteLine($"E.2: Fiffi Fluff: {fiffi.GetFluff()}");

// Test E.3: Method Redefinition (Darstellung/Bellen)
Console.WriteLine($"E.3: Fiffi Darstellung (Redefiniert): {fiffi.GetDarstellung()}");
Console.WriteLine($"E.3: Fiffi Laut (Redefiniert): {fiffi.GetLautBeimBellen()}");


// ===================================
// F. Relationships (Love) Tests
// ===================================

// Test F.2: DetectLoveTriangle (Größe 3)
Mensch a = new Mensch("A", 0.5, 20);
Mensch b = new Mensch("B", 0.5, 20);
Mensch c = new Mensch("C", 0.5, 20);
a.SetLoveInterest(b);
b.SetLoveInterest(c);
c.SetLoveInterest(a); // A -> B -> C -> A
Console.WriteLine($"F.2: Love Triangle Größe 3: {a.DetectLoveTriangle()}");

// Test A.3: DetectLoveTriangleUntilSize
int notriangleResult = a.DetectLoveTriangleUntilSize(5);
Console.WriteLine($"F.3: Love Triangle bis Größe 5 gefunden: {notriangleResult == 5}, bis größe: {notriangleResult} gefunden.");
int anotherNoTriangleResult = a.DetectLoveTriangleUntilSize(2);
Console.WriteLine($"F.3: Love Triangle bis Größe 2 gefunden: {anotherNoTriangleResult == 2}, bis größe: {anotherNoTriangleResult} gefunden.");
int aTriangleResult = a.DetectLoveTriangleUntilSize(3);
Console.WriteLine($"F.3: Love Triangle bis Größe 3 gefunden: {aTriangleResult == 3}, bis größe: {aTriangleResult} gefunden.");


Console.WriteLine("\n--- Tests beendet ---");