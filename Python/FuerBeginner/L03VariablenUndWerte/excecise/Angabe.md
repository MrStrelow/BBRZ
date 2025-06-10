# Python: Variablen, Typen und grundlegende Operationen

## Erstellen von Variablen und deren Typen

Python verwendet ein **dynamisches Typsystem**, was bedeutet, dass Sie den Datentyp einer Variable nicht deklarieren müssen. Der Typ wird automatisch durch den zugewiesenen Wert bestimmt.

### Erkennen von Typen

Welche Python-Datentypen (`int`, `float`, `str`, `bool`) würden Sie für folgende Informationen verwenden?

-   Alter eines Menschen
-   Das Jahresgehalt in ganzen Euro-Beträgen
-   Das Geschlecht einer Person
-   Die Anrede einer Person (Herr, Frau, Divers, ...)
-   Die eulerische Zahl e mit 14 Nachkommastellen
-   Das Gewicht in kg
-   Wurde die Rechnung schon bezahlt?

---

### Einstieg

Führen Sie die folgenden Schritte in einem Python-Skript aus:

1.  Erstellen Sie eine lokale `int`-Variable `a` mit dem Wert `47`.
2.  Erstellen Sie eine "Konstante" `K1` mit dem Wert `111`. (Konvention in Python: `GROSSBUCHSTABEN`).
3.  Berechnen Sie `a + K1` und speichern Sie das Ergebnis in einer Variable `c`.
4.  Geben Sie `c` auf der Konsole aus (z.B. mit `print()`).
5.  Erstellen Sie eine lokale `float`-Variable `b` mit dem Wert `101.98`.
6.  Legen Sie eine lokale `float`-Variable `d` an und initialisieren Sie sie mit `0.0`.
7.  Berechnen Sie `d = a + b`.
8.  Geben Sie `d` aus.
9.  Wandeln Sie `d` in einen `int` um und speichern Sie das Ergebnis in einer neuen `int`-Variable `e`.
10. Legen Sie eine `bool`-Variable `b1` mit dem Wert `False` an.
11. Setzen Sie den Wert von `b1` auf `True`.
12. Legen Sie eine `str`-Variable `hello` mit dem Text "Hallo" an.
13. Legen Sie eine `str`-Variable `name` an, die Ihren Namen enthält.
14. Erstellen Sie eine neue `str`-Variable `greeting`, die durch die Kombination von `hello` und `name` eine Begrüßung wie "Hallo Max!" ergibt.
15. Geben Sie auf der Konsole den Satz `Das Ergebnis von a + b ist [Ergebnis]` aus. Die Werte für `a`, `b` und das Ergebnis sollen durch die aktuellen Werte der Variablen ersetzt werden.

---

### Taschenrechner light 🧮

Erstellen Sie zwei `int`-Variablen `x` und `y` mit den Werten `4` und `3`. Berechnen und drucken Sie die Ergebnisse der folgenden Ausdrücke.

**Hinweis:** In Python führt der Operator `/` immer eine Fließkommadivision durch. Für die Ganzzahldivision (die Nachkommastellen abschneidet) verwenden Sie den Operator `//`.

-   `x + y`
-   `x - y`
-   Die **Ganzzahl**-Division von `x` und `y`.
-   Die **Fließkomma**-Division von `x` und `y`.
-   Den Rest der Division von `x` durch `y` (Modulo).

---

### Rechnung 🧾

1.  Legen Sie 3 "Konstanten" an: `COLA_PREIS = 2.0`, `WASSER_PREIS = 1.0`, `BIER_PREIS = 4.0`.
2.  Legen Sie 3 lokale Variablen an, die eine Anzahl für jedes Getränk speichern (z.B. `anz_cola`).
3.  Berechnen Sie die Gesamtsumme für eine Beispielrechnung (z.B. 3 Cola, 2 Wasser und 1 Bier) und geben Sie sie in einem Satz wie diesem aus:
    `Die Rechnung von 3 Cola, 2 Wasser und 1 Bier ergibt 12.0€`
4.  Berechnen Sie den Durchschnittspreis der drei Produkte und geben Sie ihn aus.

---

### Geometrie 📐

#### Rechteck

1.  Legen Sie Variablen für die Länge (`a`) und Breite (`b`) eines Rechtecks an.
2.  Berechnen und drucken Sie den Umfang: `2 * (a + b)`.
3.  Berechnen und drucken Sie die Fläche: `a * b`.

#### Kreis

1.  Importieren Sie das `math`-Modul.
2.  Legen Sie eine Variable für den Radius `r` an.
3.  Berechnen Sie den Umfang: `U = 2 * math.pi * r`.
4.  Berechnen Sie die Fläche: `A = math.pi * r**2` (oder mit `math.pow(r, 2)`).

---

### Umwandlung von Datentypen

#### Theoretische Frage

**Wie viele Bytes benötigt man mindestens, um folgende Dezimalzahlen binär kodiert zu speichern?**
(1 Byte = 8 Bit)

-   18
-   128
-   7635
-   897613
-   232

#### Ausdrücke auswerten

Welche Rechenergebnisse liefern die folgenden Ausdrücke, wenn sie **in Python** ausgeführt werden?

```python
i = 4
j = 5
x = 0.0 # Platzhalter für das Ergebnis

# Was ist der Wert von x nach jeder dieser Zeilen?
x = i / j
x = 1.0 * i / j * 10
x = i // j * 10
x = 1.0 * (i // j) * 10
x = i * 10 / j
x = 10.0 * i / j
x = (10.0 * i) / j
x = i / 0.1 * j
x = i / (0.1 * j)
```

Weitere Übungen
* Erstellen Sie Variablen der Typen int, float, bool und str und weisen Sie ihnen passende Werte zu.
* Führen Sie eine Addition zweier int-Variablen durch und speichern Sie das Ergebnis in einer neuen Variable. Geben Sie das Ergebnis aus.
* Führen Sie eine Subtraktion zweier float-Variablen durch.
* Multiplizieren Sie zwei int-Variablen.
* Teilen Sie zwei float-Variablen.
* Erstellen Sie eine Variable vom Typ int und weisen Sie ihr den Wert einer float-Variable nach einer Typumwandlung zu.
* Erstellen Sie eine Variable vom Typ float und weisen Sie ihr den Wert einer int-Variable nach einer Typumwandlung zu.
* Führen Sie eine Division von zwei int-Variablen durch und speichern Sie das Ergebnis in einer float-Variable.
* Führen Sie eine Division von zwei float-Variablen durch und speichern Sie das Ergebnis in einer int-Variable.
* Vergleichen Sie, ob zwei int-Variablen gleich sind, und speichern Sie das Ergebnis (True oder False) in einer bool-Variable.
* Vergleichen Sie zwei float-Variablen auf Gleichheit.
* Erstellen Sie einen String, der den Buchstaben 'A' enthält. Weisen Sie der Variable anschließend den neuen Wert 'B' zu.
* Deklarieren Sie eine bool-Variable und weisen Sie ihr den Wert True zu. Ändern Sie den Wert dann auf False.
* Berechnen Sie den Durchschnitt von drei float-Variablen.
* Berechnen Sie die Summe der ersten 10 natürlichen Zahlen (1 bis 10) und speichern Sie das Ergebnis in einer int-Variable.
* Erstellen Sie eine int-Variable mit dem Wert 1000. Simulieren Sie eine Typumwandlung in ein "Byte", indem Sie berechnen, welcher Wert übrig bleibt (ein Byte kann Werte von 0-255 speichern).
* Erstellen Sie eine float-Variable mit dem Wert 3.14159265359. Weisen Sie diesen Wert einer neuen Variable zu.
* Führen Sie eine Typumwandlung durch, um einen bool-Wert (True und False) in eine int-Variable zu speichern. Was sind die numerischen Äquivalente?
* Erstellen Sie einen String, der das Zeichen 'X' enthält. Führen Sie eine Typumwandlung durch, um den zugehörigen numerischen Unicode/ASCII-Wert in einer int-Variable zu speichern.

Für alle Übungen gilt: Geben Sie die Ergebnisse auf der Konsole aus!