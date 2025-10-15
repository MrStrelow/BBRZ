# Hunde und dessen Besitzer:innen

## Zu verwendende Konzepte
| Konzept | Beschreibung | Implementierung |
| :--- | :--- | :--- |
| **Vererbung (Ist-Beziehung)** | `HundeBesitzer` ist ein `Mensch`. `SchaeferHund` und `Pudel` sind ein `Hund`. | C# `class Subklasse : Basisklasse` |
| **Assoziationen (Hat-Beziehung)** | Beschreibt die Beziehungen zwischen Objekten (z.B. ein Mensch hat einen Love Interest). | Private Felder vom Typ der assoziierten Klasse (z.B. `private Mensch _myLoveInterest;`). |
| **Bidrektionale und Unidirektionale Hat-Beziehungen** | Eine Beziehung, die in beide Richtungen konsistent sein muss (z.B. SpielFreund) ist ``bidirektional``. Beide ``Objekte`` wissen voneinander. Wenn nur ein ``Objekt`` von der ``Hat-Beziehung`` weiß, ist diese ``unidirektional`` | Die Methode `SetSpielFreund()` in `Hund` stellt sicher, dass wenn A, B als Spielfreund hat, B auch A als Spielfreund hat. |
| **Guard Clauses** | Code-Blöcke am Anfang von ``Methoden``, die ``unerwünschte Zustände`` (z.B. `null`-Referenzen, Kapazitätsüberschreitung, logische Fehler) abfangen. | *if (condition) return;* oder *if (condition) throw new Exception("¯\_(ツ)_/¯");* (hier keine ``Exceptions``, sondern *Console.WriteLine* mit einem `return` darunter). |
| **Downcasting** | Ein ``Objekt`` der ``Basisklasse`` z.B. *Hund* wird temporär in einen ``abgeleiteten Typ`` umgewandelt. | In `HundeBesitzer.Buersten()` wird geprüft, ob ein `Hund` ein `Pudel` ist, um auf `Pudel`-spezifische Methoden (`SetFluff()`) zuzugreifen. Wir tun das mit dem ``Mustervergleich`` *if (hund is Pudel pudel) { ... }*. Innerhalb der geschwungenen Klammern kann auf die ``Variable`` *pudel* zugegriffen werden, welche die ``Variable`` *hund* als ``Pudel`` darstellt. **Achtung!** Dafür muss der *hund* aber auch den ``Typ`` *Pudel* von anfang an haben! sonst ist das if flasch und wir gehen weiter.|
| **Kopierkonstruktor** | Ein Konstruktor wird ``Kopierkonstruktor`` genannt, wenn dieser die ``Felder`` und dessen ``Werte`` bzw. ``Referenzen`` übernimmt und ein neues Objekt daraus erstellt. Wir "klonen" quasi das alte Objekt. Wir werden es verwenden um einen *HundeBesitzer* aus einem *Mensch* zu machen (das ist kein ``up-`` oder ``downcasting``!). Dazu verwendne wir *new Hundebesitzer(this, hatHundeFührerschein, capacity)*. |
| **override** anwenden bei *ToString()* | Wir überschreiben mit dem ``Keyword`` ``override`` die ``Implementierung`` einer ``Methode`` aus einer ``Basisklasse``. Jedes ``Klasse`` kann *public virtual string ToString* aus der ``Klasse`` *Object* überschreiben um *Console.WriteLine(einHundeObjekt);* sinnvoll ausgeben zu können. Ansonsten wird der sogenannte ``HashCode`` ausgegeben. Wir tun das in unserer ``Klasse`` z.B. *Hund* und *Mensch* mit z.B. *public override string ToString() { return $"{_name}:{_alter}:{_darstellung}" }*|

---

## Klassen und Methoden ``definieren`` und ``implementieren``
Halte dich an folgendes ``Klassendiagramm`` welches [IST](Klassendiagramm/IST_generiert.png) genannt ist

![IST](Klassendiagramm/IST_generiert.png)

Dieses ist aus der Lösung generiert und stellt alle Methoden und Felder dar, welche zu implementieren sind. Die Konstruktoren werden jedoch nicht einzeln angezeigt. In der Angabe wird erwähnt welche ``Parameter`` die jeweiligen ``Konstruktoren`` haben sollen. Verwende zudem die Vorlage von *Program.cs*. Diese zeigt Fehler an, falls einer der Konstruktoren vergessen wurde. Die ausprogrammierte *Program.cs* ist [hier](#das-ferige-programcs) oder in der [Lösung](Program.cs) zu finden.

**Anmerkung:** 
1) Die ``ToString`` sowie ``Get-`` und ``Set-Methoden`` sind nicht in folgenden Auflistungen enthalten. Außnhamen sind jene ``Set-Methoden`` welche komplizierteres Verhalten haben (``Guard-Clauses`` , ``bidriektionale`` Beziehungen sicherstellen, etc.). 
2) Beim Implmentieren der Klasse führe lafuend das Programm aus! Ansonsten ist es schwer zu erkennen wo Fehler gemacht wurden.

### UML-Klassendiagramm
Vergleiche [IST](Klassendiagramm/IST_generiert.png) mit ![SOLL](Klassendiagramm/SOLL.bright.png) und beantworte folgende Fragen.
* Wie sind die ```Kardinalitäten`` in beiden Diagrammen dargestellt? 
* Warum sind in einem Diagramm viel weniger ``Methoden`` vorhanden als im anderen?

### Klasse: Mensch.cs

| Methode / Konstruktor | Hintergrund & Implementierung |
| :--- | :--- |
| 🤗 `Mensch(...)` | Überladene Konstruktoren zur Initialisierung aller Felder, inklusive optionalem `_myLoveInterest`. Wir benötigen folgende Konstruktoren: **``1)``** *public Mensch(string name, double happiness, int alter)* und **``2)``** *Mensch(string name, double happiness, int alter, Mensch loveInterest) : this(name, happiness, alter)*. Nutzt `this()` um bereits bestehende Konstruktoren zu verwenden. Das geht nur bei ``Konstruktoren`` und nicht bei *normalen* ``Methoden``|
| 🤔 `WirdEinHundeBesitzer()` | Ermöglicht die **Konvertierung** zu einem `HundeBesitzer`. Erstellt ein **neues** ``Objekt`` *HundeBesitzer* aus dem aktuellen ``Objekt`` *Mensch*. Danach kauft diese:r einen ersten *Hund* und gibt das **neue** ``Objekt`` vom ``Typ`` *HundeBesitzer* zurück. Es wird ein ``Kopierkonstruktor`` von *HundeBesitzer* verwendet. |
| 🤔 `MehrereHundeKaufen()` | Kauft ein ``Array`` von Hunden. **Guard Clause**: Prüft, ob die Kapazität (`capacity`) groß genug für alle Hunde ist. |
| 🙂 `DetectMutualLove()` | Prüft die bidirektionale Love-Interest-Beziehung: `this == _myLoveInterest._myLoveInterest`. |
| 🤔 `DetectLoveTriangle()` | Prüft, ob ein Dreiecksverhältnis der Größe 3 vorliegt (`A.love.love.love == A`). |
| 💀 `DetectLoveTriangleUntilSize()` | Sucht iterativ nach Love Triangles bis zur Größe `n`. |
| 🙂 `ToString()` | **override**: Überschreibe die ``Methode`` *ToString* und schreibe dort *public override string ToString() { return $"{_name}:{_alter}:{_darstellung}" }*. Drücke auf das in VS links stehende *blaue o*. Zu welcher Klasse kommst du? Diese ``Klasse`` ist der ``Basetype`` der ``Klasse`` *Hund* (obwohl wir gar keine ``Ist-Beziehung`` angegeben haben!). |

### Klasse: Hund.cs
| Methode / Konstruktor | Hintergrund & Implementierung |
| :--- | :--- |
| 🙂 `Hund(...)` | Es werden folgende ``Konstruktoren`` benötigt: **``1)``** ``Copy-Konstruktor`` *Hund(Hund toCopy)*: Erstellt eine neue `Hund`-Instanz mit denselben Werten (ohne `_besitzer` und `_spielFreund`), **``2)``** *public Hund(string name, int alter, string geschlecht, double health, bool chipped)*, **``3)``** *public Hund(string name, int alter, string geschlecht, double health, bool chipped, HundeBesitzer besitzer) : this(name, alter, geschlecht, health, chipped)*, **``4)``** *public Hund(string name, int alter, string geschlecht, double health, bool chipped, Hund spielFreund) : this(name, alter, geschlecht, health, chipped)* und **``5)``** *public Hund(string name, int alter, string geschlecht, double health, bool chipped, HundeBesitzer besitzer, Hund spielFreund) : this(name, alter, geschlecht, health, chipped)* |
| 🤗 `Fressen(Essen essen)` | Gibt auf die ``Console`` aus welcher *Hund* welches *Essen* gefressen wird. |
| 🤗 `Spielen()` | Gibt auf die ``Console`` das ``Feld`` *_spielFreund*, *das eigene ``Objekt``* und den *_besitzer* aus. |
| 🤗 `Bellen()` | Gibt auf die ``Console`` das ``Feld`` *_lautBeimBellen* aus. |
| 🙂 `Weglaufen()` | Simuliert das Weglaufen. Ruft `_besitzer.Aussetzen(this)` auf, um den Hund aus der Liste des Besitzers zu entfernen. |
| 🤔 `SetSpielFreund()` | Stellt die **bidirektionale Beziehung (1:1)** her. Stellt sicher, dass wenn `this` den `spielFreund` setzt, der `spielFreund` auch `this` als `_spielFreund` setzt. **Guard Clauses**: Frage ab ob der ``Parameter`` *Hund spielFreund* ``null`` ist. Frage auch ab ob der ``Parameter`` *Hund spielFreund* "ich selbst bin". Beides soll zu einem Abbruch führen.|
| 🤔 `SetBesitzer()` | **Guard Clauses**: Verhindert die Zuweisung von `null`. Prüft mit `BesitztHund()` in `HundeBesitzer.cs`, ob der Hund bereits besessen wird. Ruft bei Zuweisung `besitzer.AddHund(this)` auf. |
| 🙂 `ToString()` | **override**: Überschreibe die ``Methode`` *ToString* und schreibe dort *public override string ToString() { return $"{_name}:{_alter}:{_darstellung}" }*. Drücke auf das in VS links stehende *blaue o*. Zu welcher Klasse kommst du? Diese ``Klasse`` ist der ``Basetype`` der ``Klasse`` *Hund* (obwohl wir gar keine ``Ist-Beziehung`` angegeben haben!). |

### Klasse: HundeBesitzer.cs
| Methode / Konstruktor | Hintergrund & Implementierung |
| :--- | :--- |
| 🙂 `HundeBesitzer(...)` | Drei überladene ``Konstruktoren``. Nutzen *base()* (zum Aufruf des *Mensch*-Konstruktors) und *this()* (für andere ``Konstruktoren`` in der ``Klasse`` *HundeBesitzer*). Rufe im ``Konstruktor`` welcher *base()* verwendet auch *SetDarstellung("😁")* auf. Die Konstruktoren sind **``1)``** *public HundeBesitzer (string name, double happiness, int age, bool hatHundeFuehrerschein, int capacity) : base (name, happiness, age)*, **``2)``** *public HundeBesitzer(Mensch istBaldHundebesitzer, bool hatHundeFuehrerschein, Hund[] hunde, int capacity) : this (istBaldHundebesitzer.GetName(), istBaldHundebesitzer.GetHappiness(), istBaldHundebesitzer.GetAlter(), hatHundeFuehrerschein, capacity)* und **``3)``** *public HundeBesitzer(Mensch istBaldHundebesitzer, bool hatHundeFuehrerschein, int capacity) : this (istBaldHundebesitzer.GetName(), istBaldHundebesitzer.GetHappiness(), istBaldHundebesitzer.GetAlter(), hatHundeFuehrerschein, capacity)*| 
| 🤗 `GassiGehen()` | Gib für alle *Hunde* die vom *HundeBesitzer* besessen werden eine Nachricht auf die ``Console`` aus. |
| 🤗 `Fuettern(Essen essen)` | Rufe für alle *Hunde* die vom *HundeBesitzer* besessen werden die Methode ``Fressen(Essen essen)`` auf. |
| 🙂 `Buersten()` | **Downcasting-Demonstration**: Unterscheidet zwischen *Pudel* und anderen *Hunden*. *Pudel* erhält eine höhere Health-Erhöhung und der `_fluff` wird verdoppelt. Verwende dazu *if (hund is Pudel pudel)* **Anmerkung!** Kann ich direkt auf die ``Felder`` zugreifen oder muss ich die ``Get-`` und ``Set-Methoden`` verwenden?|
| 🤔 `Aussetzen(Hund hund)` | Entferne den Hund aus der internen `hunde`-Liste des *HundeBesitzers* und setzt dessen `_besitzer`-Feld auf `null`. **Guard Clause**: Prüfe ob der Hund überhaupt von mir besessen wird. Schreibe dazu eine ``private`` ``Hilfsmethode`` *bool BesitztHund(Hund hund)*. |
| 🤔 `Finden(Hund hund)` | Rufe die *SetBesitzer* ``Methode`` auf um den ``Parameter`` *Hund hund* in Besitz zu nehmen. **Guard Clause**: Prüft, ob es sich um einen *Schäferhund* handelt, da dann der *Besitzer* einen `_hatHundeFuehrerschein` besitzen muss.|
| 🤔 `Kaufen(Hund hund)` | Rufe die *SetBesitzer* ``Methode`` auf um den ``Parameter`` *Hund hund* in Besitz zu nehmen. **Guard Clause**: Prüft, ob es sich um einen *Schäferhund* handelt, da dann der *Besitzer* einen `_hatHundeFuehrerschein` besitzen muss. |
| 🤔 `Verkaufen(Hund hund, HundeBesitzer neuerBeistzer)` | Rufe die ``Methode`` *Aussetzen* auf und danach die ``Methode`` *Kaufen* des ``Parameters`` *Besitzer neuerBesitzer* und übergebe dort den ``Parameter`` *Hund hund*. |
| 🤔 `AddHund()` | Fügt einen Hund zum `hunde`-Array hinzu. **Guard Clauses**: Verhindert `null`, Duplikate (`BesitztHund()`) und Kapazitätsüberschreitung (`WoHabeIchPlatz()`). Implementiere dazu eine ``private`` ``Hilfsmethode`` *int WoHabeIchPlatz()* welche einen freien Ort im ``Array`` *_hunde* zurückgibt. Wenn es keinen gibt, gib *-1* zurück. |

### Klasse: SchaeferHund.cs
| Methode / Konstruktor | Hintergrund & Implementierung |
| :--- | :--- |
| 🤗 `SchaeferHund(...)` | Mehrere überladene Konstruktoren. Initialisiert das `_behueteteHunde`-Array und setzt die Darstellung auf `🐕‍🦺`. Die ``Konstruktoren`` sind **``1)``** *public SchaeferHund(string name, int alter, string geschlecht, double health, bool chipped, int capacity, Hund[] behuetendeHunde) : base(name, alter, geschlecht, health, chipped)*, **``2)``** *public SchaeferHund(string name, int alter, string geschlecht, double health, bool chipped, int capacity, Hund[] behuetendeHunde, HundeBesitzer besitzer, Hund spielFreund) : this(name, alter, geschlecht, health, chipped, capacity, behuetendeHunde)*, **``3)``** *public SchaeferHund(string name, int alter, string geschlecht, double health, bool chipped,int capacity, Hund[] behuetendeHunde, HundeBesitzer besitzer) : this(name, alter, geschlecht, health, chipped, capacity, behuetendeHunde)* und **``4)``** *public SchaeferHund(string name, int alter, string geschlecht, double health, bool chipped, int capacity, Hund[] behuetendeHunde, Hund spielFreund) : this(name, alter, geschlecht, health, chipped, capacity, behuetendeHunde)* |
| 🤗 `Hueten()` | Ausgabe aller *Hunde* im ``Feld`` *_behueteteHunde* in der ``Konsole``. |
| 🤔 `AddZuBehuetendeHunde(Hund hund)` | Fügt einen Hund zur Hüteliste hinzu. **Guard Clauses** gegen ``Parameter`` *Hund hund* ist ``null``, wird bereits von "mir" behütet und führt zu einer Kapazitätsüberschreitung. Implementiere dazu zwei ``Hilfsmethoden``. **``1)``** Die ``private`` ``Hilfsmethode`` *int WoHabeIchPlatz()*. Diese gibt den index eines freien (null) Platzes im ``Feld`` *_behueteteHunde* an. **``2)``** die ``public`` ``Hilfsmethode`` *bool HuetetBereitsHund(Hund hund)*. Diese gibt den ``Wert`` *true* zurück der ``Parameter`` *Hund hund* im ``Feld`` *_behueteteHunde* vorkommt.|
| 🙂 `VerstoesseHund(Hund hund)` | suche den ``Parameter`` *Hund hund* im ``Feld`` *_behueteteHunde* und entferne diesen. |

### Klasse: Pudel.cs
| Methode / Konstruktor | Hintergrund & Implementierung |
| :--- | :--- |
| 🤗 `Pudel(...)` | Mehrere überladene Konstruktoren zur Initialisierung aller Felder inkl. `_fluff`. Setzt die Darstellung auf `🐩`. Diese sind **``1``** * public Pudel(string name, int alter, string geschlecht, double health, bool chipped, double fluff) : base(name, alter, geschlecht, health, chipped)*, **``2)``** *public Pudel(string name, int alter, string geschlecht, double health, bool chipped, double fluff, HundeBesitzer besitzer, Hund spielFreund) : this(name, alter, geschlecht, health, chipped, fluff)*, **``3)``** *public Pudel(string name, int alter, string geschlecht, double health, bool chipped, double fluff, HundeBesitzer besitzer) : this(name, alter, geschlecht, health, chipped, fluff)* und **``4)``** *public Pudel(string name, int alter, string geschlecht, double health, bool chipped, double fluff, Hund spielFreund) : this(name, alter, geschlecht, health, chipped, fluff)* |
| 🤗 `Winseln()` | Simuliert das Winseln *Console.WriteLine(".winsel.")*. Zudem wird die Health des *Pudels* um 1 verringert. |

---