# Zufallszahlen in der Informatik 🎲🖥️

## 1. Pseudo-Zufall vs. Echter Zufall

Ein Computer ist deterministisch. Das bedeutet: Gleicher Input liefert immer den exakt gleichen Output. Echter Zufall ist für einen normalen Prozessor eigentlich unmöglich.

* **Echter Zufall (True Random):** Wird aus physikalischen Prozessen gewonnen, z. B. atmosphärischem Rauschen, Mausbewegungen des Users oder radioaktivem Zerfall. Diese Daten sind unvorhersehbar, aber oft langsam zu sammeln.
* **Pseudo-Zufall (PRNG):** Algorithmen, die eine mathematische Formel nutzen, um eine Zahlenfolge zu erzeugen. Diese Folge sieht für den Menschen absolut zufällig aus, ist aber zu 100 % berechenbar, wenn man den Startwert der Formel kennt. Die C#-Klasse `Random` ist ein solcher Pseudo-Zufallszahlengenerator.


**Sicherheitshinweis:** Weil Pseudo-Zufall berechenbar ist, darf die Klasse `Random` **niemals** für Passwörter, Bank-Tokens oder Verschlüsselung (Kryptographie) verwendet werden. Hacker könnten die nächste Zahl vorhersagen. Für Sicherheit nutzt man in C# die Klasse `RandomNumberGenerator` aus der Kryptographie-Bibliothek.

---

## 2. Der Seed (Startwert)

Jede mathematische Zufalls-Formel braucht einen Startwert, mit dem sie zu rechnen beginnt. Dieser Startwert heißt **Seed**. 

Wenn du `new Random()` ohne Parameter aufrufst, nimmt C# oft die aktuelle Systemzeit (in Millisekunden) als Seed. Da die Zeit immer weiterläuft, bekommst du bei jedem Programmstart einen anderen Seed und damit eine andere "zufällige" Welt.

**Wann ein bekannter Seed ein Problem ist:**
Wenn Hacker herausfinden, welchen Seed dein Programm genutzt hat (z. B. weil sie die genaue Uhrzeit des Serverstarts kennen), können sie exakt vorhersagen, welche "Zufallszahlen" dein Programm als Nächstes ausgibt.

**Wann ein bekannter Seed gut ist:**
In der Entwicklung wollen wir Fehler finden. Wenn ein Spiel durch Zufall abstürzt, müssen wir diesen Fehler reproduzieren. Setzen wir einen fixen Seed, generiert das Programm immer exakt denselben "zufälligen" Ablauf.

```csharp
// 1. Zufälliger Seed (z.B. Systemzeit) -> Jedes Mal andere Zahlen
Random echterZufall = new Random();
Console.WriteLine(echterZufall.Next(0, 100)); 

// 2. Fixer Seed (123) -> Liefert bei JEDEM Programmstart exakt dieselbe Zahlenfolge!
Random testZufall = new Random(101);
Console.WriteLine(testZufall.Next(0, 100)); 
```

---

## 3. Linear Congruential Generator (LCG)

Wie sieht so eine Formel aus, die Pseudo-Zufall erzeugt? Einer der ältesten und bekanntesten Algorithmen ist der **Lineare Kongruenzgenerator (LCG)**.

Die Formel berechnet die nächste Zufallszahl immer auf Basis der vorherigen Zahl:
$X_{n+1}=(a \cdot X_n + c) \pmod{m}$

**Was bedeuten die Variablen?**
* $X_n$: Der aktuelle Wert (Beim allerersten Aufruf ist das unser **Seed**!)
* $a$: Ein Multiplikator (eine feste, oft sehr große Zahl)
* $c$: Ein Inkrement (eine feste Zahl, die addiert wird)
* $m$: Der Modulo-Wert (bestimmt den Maximalwert der Zahl)
* $X_{n+1}$: Die neue, berechnete Zufallszahl.

**Die Verbindung zum C#-Code:**
Wenn du `Random generator = new Random(42)` schreibst, erschaffst du ein Objekt. Dieses Objekt speichert intern den Wert $X_n$ (in diesem Fall 42).
Jedes Mal, wenn du `generator.Next()` aufrufst, führt das Objekt genau einmal diese Formel aus. Das Ergebnis $X_{n+1}$ wird dir als Zufallszahl zurückgegeben, und das Objekt merkt sich dieses Ergebnis als neuen Startwert für den nächsten Aufruf.

---

## 4. Anwendungen: Wofür brauchen wir das?

Zufallszahlen werden nicht nur für Lootboxen oder das Platzieren von Sandinseln gebraucht. Sie sind ein zentrales Werkzeug der modernen Informatik und Computergrafik:

* **Computergrafik & Ray Tracing:** Um realistische Beleuchtung zu simulieren, schießen Algorithmen (Ray Tracer) Millionen von Lichtstrahlen zufällig durch eine 3D-Szene, um zu berechnen, wie Licht abprallt und Schatten wirft. 
    * *Tipp:* Schaut euch auf YouTube die beeindruckenden Erklärvideos von **Sebastian Lague** an (z. B. "Coding Adventure: Ray Tracing").
* **Monte-Carlo-Integration:** Wenn eine Fläche zu komplex ist, um sie mit klassischen Formeln zu berechnen, nutzt man den Zufall. Man wirft zufällige Punkte auf ein Feld und zählt, wie viele davon innerhalb der gesuchten Form landen. Aus dem Verhältnis lässt sich die Fläche (oder sogar die Zahl Pi) extrem genau annähern!