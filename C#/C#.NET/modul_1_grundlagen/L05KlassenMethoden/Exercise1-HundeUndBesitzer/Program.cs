/*
 * Testsuite für die Klassen Mensch, HundeBesitzer, Hund, SchaeferHund und Pudel.
 *
 * Konzepte, die hier getestet und demonstriert werden:
 *
 * 1. Vererbung (Ist-Beziehung): HundeBesitzer erbt von Mensch, SchaeferHund und Pudel erben von Hund.
 * 2. Konstruktoren: Testen verschiedener Konstruktor-Überladungen (einschließlich Basisklassen-Aufrufe mit 'base' und Konstruktor-Verkettung mit 'this'). Der Copy-Konstruktor in Hund wird ebenfalls getestet.
 * 3. Beziehungen (Hat-Beziehungen): Testen der 0..1 (SpielFreund, LoveInterest) und 1..n (Hunde-Array in HundeBesitzer, behütete Hunde in SchaeferHund) Beziehungen.
 * 4. Reziproke Beziehungen: Die SpielFreund-Beziehung ist gegenseitig ('reziprok') und wird über SetSpielFreund() konsistent gehalten.
 * 5. Guard Clauses & Null-Referenzen: Testen von Methoden, die unerwünschte Zustände (z.B. SetBesitzer(null), AddHund bei Kapazitätslimit, Kaufen ohne Führerschein für Schäferhund) durch Prüfungen (Guard Clauses) verhindern oder steuern. Das schützt das Objekt vor inkonsistenten Zuständen.
 * 6. Downcasting/Upcasting: Testen der Bürsten-Methode in HundeBesitzer, die mit 'is Pudel pudel' ein Downcasting durchführt, um auf spezifische Pudel-Methoden/Felder (wie SetFluff) zuzugreifen.
 */

using Hunde;
using System;
using System.Linq;
using System.Text;

// Sicherstellen, dass die Ausgabe Umlaute korrekt darstellt
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
// ToString wird verwendet, um die Darstellung zu erhalten
Console.WriteLine($"Vor Umwandlung - Typ: {hatBaldHunde.GetType()} - Hash: {hatBaldHunde.GetHashCode()} - Darstellung {hatBaldHunde}");

Hund initialHund = new Hund("InitialHund", 1, "m", 10, false);
hatBaldHunde = hatBaldHunde.WirdEinHundeBesitzer(initialHund, hatHundeFuehrerschein: true, hunde.Length * 2);

// Die Ausgabe zeigt, dass der Typ HundeBesitzer ist. Die ToString Methode (override) wird korrekt aufgerufen.
Console.WriteLine($"Nach Umwandlung - Typ: {hatBaldHunde.GetType()} - Hash: {hatBaldHunde.GetHashCode()} - Darstellung {hatBaldHunde}");
// Downcasting zu HundeBesitzer, um Redefinition zu prüfen
HundeBesitzer besitzerHund = (HundeBesitzer)hatBaldHunde;
Console.WriteLine($"Darstellung (Redefiniert): {besitzerHund.GetDarstellung()}");

Mensch hatNieHunde = new Mensch("Raldira", 0.5, 55);
Console.WriteLine($"HatNieHunde Darstellung: {hatNieHunde}");

Console.WriteLine("\n==============================================");
Console.WriteLine("--- ERWEITERTE TESTS FÜR ALLE KLASSENMETHODEN ---");
Console.WriteLine("==============================================");

// ===================================
// A. Mensch.cs Tests
// ===================================
Console.WriteLine("\n--- A. Mensch.cs Tests ---");

// Test A.1: Konstruktor mit LoveInterest & Mutual Love Check (bereits vorhanden)
Mensch julia = new Mensch("Julia", 0.9, 30);
Mensch tom = new Mensch("Tom", 0.8, 32, julia);
julia.SetLoveInterest(tom);
Console.WriteLine($"A.1: Julia und Tom haben Mutual Love: {julia.DetectMutualLove()}");

// Test A.2: MehrereHundeKaufen (Erfolgreich) (bereits vorhanden)
Hund[] tempHunde = mehrHunde.Where(h => h.GetBesitzer() == null).ToArray();
HundeBesitzer lisa = julia.MehrereHundeKaufen(tempHunde, hatHundeFuehrerschein: false, capacity: 5);
if (lisa != null)
{
    Console.WriteLine($"A.2: Lisa ist jetzt HundeBesitzer ({lisa.GetName()}) und hat {lisa.GetHunde().Count(h => h != null)} Hunde gekauft.");
}

// Test A.3: MehrereHundeKaufen (Fehler: Kapazität zu klein) (bereits vorhanden)
Console.Write("A.3: ");
HundeBesitzer fehlerLisa = julia.MehrereHundeKaufen(mehrHunde, hatHundeFuehrerschein: false, capacity: 2);
Console.WriteLine($"A.3: Lisa versucht 3 Hunde mit Kapazität 2 zu kaufen (sollte null sein): {fehlerLisa == null}");

// Test A.4: Get/Set und ToString() (bereits vorhanden)
tom.SetHappiness(0.95);
Console.WriteLine($"A.4: Tom's Happiness aktualisiert: {tom.GetHappiness()}");
Console.WriteLine($"A.4: Julia's Love Interest: {julia.GetLoveInterest().GetName()}");
Console.WriteLine($"A.4: Julia's ToString(): {julia.ToString()}");


// ===================================
// B. Hund.cs Tests
// ===================================
Console.WriteLine("\n--- B. Hund.cs Tests ---");
Hund hansi = new Hund("Hansi", 3, "m", 20, true);
Hund rex = new Hund("Rex", 4, "m", 22, false);
Pudel luna = new Pudel("Luna", 2, "w", 18, true, 10.0, karo, hansi);
Console.WriteLine($"B.1: Luna's Besitzer: {luna.GetBesitzer().GetName()}");
rex.SetSpielFreund(hansi);
Console.WriteLine($"B.1: Rex's Spielfreund: {rex.GetSpielFreund().GetName()}");
Hund rexKopie = new Hund(rex);
Console.WriteLine($"B.2: Rex Kopie erstellt: {rexKopie.GetName()}. Gechippt? {rexKopie.IsChipped()}. Hat sie einen Besitzer? {rexKopie.GetBesitzer() != null}");
Console.WriteLine($"B.3: Rex bellt (Geräusch): {rex.Bellen()}");
rex.SetLautBeimBellen("Wauwau");
Console.WriteLine($"B.3: Rex Laut: {rex.GetLautBeimBellen()}");
luna.Spielen();
Console.WriteLine($"B.5: Luna ist bei Hansi: {karo.BesitztHund(luna)}");
luna.Weglaufen();
Console.WriteLine($"B.5: Luna ist bei Hansi nach Weglaufen: {karo.BesitztHund(luna)}");
Console.WriteLine($"B.5: Luna hat keinen Besitzer mehr: {luna.GetBesitzer() == null}");
Hund tobi = new Hund("Tobi", 1, "m", 15, false);
Hund otto = new Hund("Otto", 6, "m", 12, true, tobi);

Console.WriteLine($"B.6a: {otto.GetSpielFreund().GetName()}");
Console.WriteLine($"B.6b: {tobi.GetSpielFreund().GetName()}");
rex.SetHealth(25);
Console.WriteLine($"B.7: Rex Health: {rex.GetHealth()}");
rex.SetGeschlecht("w");
Console.WriteLine($"B.7: Rex Geschlecht: {rex.GetGeschlecht()}");


// ===================================
// C. HundeBesitzer.cs Tests
// ===================================
Console.WriteLine("\n--- C. HundeBesitzer.cs Tests ---");

HundeBesitzer tina = new HundeBesitzer("Tina", 0.8, 28, true, 3);
Hund dackel = new Hund("Dackel", 3, "m", 15, true);
Hund terrier = new Hund("Terrier", 2, "w", 14, false);
tina.AddHund(dackel);
Console.WriteLine($"C.1: Marie's Name aus Mensch übernommen: {tina.GetName()}");
Console.WriteLine($"C.1: Marie besitzt den Dackel: {tina.BesitztHund(dackel)}");
tina.SetDarstellung("👩‍🦰");
Console.WriteLine($"C.1: Marie's Darstellung (Redefiniert): {tina.GetDarstellung()}");
Hund h1 = new Hund("H1", 1, "m", 10, false);
Hund h2 = new Hund("H2", 2, "w", 12, true);
Mensch karl = new Mensch("Karl", 0.7, 40);
Mensch erika = new Mensch("Erika", 0.9, 35);
h1.SetBesitzer(new HundeBesitzer(karl, true, 2));
h2.SetBesitzer(new HundeBesitzer(erika, false, 3));
Console.WriteLine($"C.2a: {h1.GetBesitzer().GetName()}");
Console.WriteLine($"C.2b: {h2.GetBesitzer().GetName()}");
h2.SetBesitzer(new HundeBesitzer(erika, true, 3));
Console.WriteLine($"C.2: Max's Besitzer (Erika): {h2.GetBesitzer().GetName()}");
Hund l1 = new Hund("L1", 1, "m", 10, false);
Hund l2 = new Hund("L2", 1, "m", 10, false);
Hund l3 = new Hund("L3", 1, "m", 10, false);
HundeBesitzer small = new HundeBesitzer("Small", 0.5, 30, false, 2);
small.AddHund(l1);
small.AddHund(l2);
small.AddHund(l3);
Console.WriteLine($"C.3: {small.GetHunde().Count(h => h != null)}");
tina.GassiGehen();
tina.Fuettern(Essen.Trockenfutter);
Pudel lili = new Pudel("Lili", 2, "w", 10, true, 5.0);
Hund normal = new Hund("Normal", 1, "m", 10, false);
tina.AddHund(lili);
tina.AddHund(normal);
Console.WriteLine($"C.6: Lili Health und Fluff - Vorher: Health {lili.GetHealth()} - Fluff {lili.GetFluff()} ...");
tina.Buersten();
Console.WriteLine($"C.6: Lili Health und Fluff - Nachher: Health {lili.GetHealth()} - Fluff {lili.GetFluff()} ...");
Console.WriteLine($"C.6: Normal Health - Vorher: Health {normal.GetHealth()} ...");
tina.Buersten();
Console.WriteLine($"C.6: Normal Health - Nachher: Health {normal.GetHealth()} ...");
HundeBesitzer ottoBesitzer = new HundeBesitzer("Otto", 0.5, 35, true, 2);
tina.Verkaufen(lili, ottoBesitzer);
Console.WriteLine($"C.7: Lili's neuer Besitzer: {lili.GetBesitzer().GetName()}");
Console.WriteLine($"C.7: Tina besitzt Lili: {tina.BesitztHund(lili)}");
Console.WriteLine($"C.7: Otto besitzt Lili: {ottoBesitzer.BesitztHund(lili)}");
Hund streuner = new Hund("Streuner", 4, "m", 8, false);
ottoBesitzer.Finden(streuner);
Console.WriteLine($"C.8: {streuner.GetBesitzer().GetName()}");
Console.WriteLine($"C.8: Streuner's Besitzer: {streuner.GetBesitzer().GetName()}");
Console.WriteLine($"C.8: Otto besitzt Streuner: {ottoBesitzer.BesitztHund(streuner)}");


// ===================================
// D. SchaeferHund.cs Tests
// ===================================
Console.WriteLine("\n--- D. SchaeferHund.cs Tests ---");
SchaeferHund sally = new SchaeferHund("Sally", 3, "w", 18, true, 2, new Hund[2]);
sally.Hueten();
Console.WriteLine($"D.2: Bello hütet Frido: {sally.HuetetBereitsHund(frido)}");
Hund fremd = new Hund("Fremd", 1, "m", 10, false);
sally.AddZuBehuetendeHunde(fremd);
Console.WriteLine($"D.2: Bello hütet Fremd: {sally.HuetetBereitsHund(fremd)}");
sally.AddZuBehuetendeHunde(gilbert);
Console.WriteLine($"D.3: Bello hütet Fremd nach Add: {sally.HuetetBereitsHund(gilbert)}");
Hund limit = new Hund("Limit", 1, "m", 10, false);
sally.AddZuBehuetendeHunde(limit);
Hund zuViel = new Hund("ZuViel", 1, "m", 10, false);
sally.AddZuBehuetendeHunde(zuViel);
sally.VerstoesseHund(fremd);
Console.WriteLine($"D.5: Bello hütet Gilbert nach Verstoesse: {sally.HuetetBereitsHund(gilbert)}");
sally.SetCapacity(5);
Console.WriteLine($"D.6: Bello neue Kapazität: {sally.GetCapacity()}");
sally.SetDarstellung("🐕‍🦺");
Console.WriteLine($"D.7: Bello Darstellung (Redefiniert): {sally.GetDarstellung()}");
sally.SetLautBeimBellen("WUFF!");
Console.WriteLine($"D.7: Bello Laut (Redefiniert): {sally.GetLautBeimBellen()}");


// ===================================
// E. Pudel.cs Tests
// ===================================
Console.WriteLine("\n--- E. Pudel.cs Tests ---");
Pudel fiffi = new Pudel("Fiffi", 1, "w", 12, true, 8.0);
Console.WriteLine($"E.1: Winseln");
fiffi.Winseln();
Console.WriteLine($"E.1: Fiffi Health: Vorher 12, Nachher {fiffi.GetHealth()} (Winseln -1)");
fiffi.SetFluff(12.0);
Console.WriteLine($"E.2: Fiffi Fluff: {fiffi.GetFluff()}");
fiffi.SetDarstellung("🐩");
Console.WriteLine($"E.3: Fiffi Darstellung (Redefiniert): {fiffi.GetDarstellung()}");
fiffi.SetLautBeimBellen("ieek");
Console.WriteLine($"E.3: Fiffi Laut (Redefiniert): {fiffi.GetLautBeimBellen()}");


// ===================================
// F. Relationships (Love) Tests
// ===================================
Console.WriteLine("\n--- F. Relationships (Love) Tests ---");
Mensch a = new Mensch("A", 0.5, 20);
Mensch b = new Mensch("B", 0.5, 20);
Mensch c = new Mensch("C", 0.5, 20);
a.SetLoveInterest(b);
b.SetLoveInterest(c);
c.SetLoveInterest(a);
Console.WriteLine($"F.2: Love Triangle Größe 3: {a.DetectLoveTriangle()}");
int size = a.DetectLoveTriangleUntilSize(5);
Console.WriteLine($"F.3: Love Triangle bis Größe 5 gefunden: {size > 0}, bis größe: {size} gefunden.");
size = a.DetectLoveTriangleUntilSize(2);
Console.WriteLine($"F.3: Love Triangle bis Größe 2 gefunden: {size > 0}, bis größe: {size} gefunden.");
size = a.DetectLoveTriangleUntilSize(3);
Console.WriteLine($"F.3: Love Triangle bis Größe 3 gefunden: {size > 0}, bis größe: {size} gefunden.");


Console.WriteLine("\n--- Tests beendet ---");