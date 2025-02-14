## Typen von Variablen und Umwandlungen

### Erkennen von Typen

Welche Datentypen haben folgende Aussagen?

- Alter eines Menschen
- Das Jahresgehalt in ganzen Euro-Beträgen
- Das Geschlecht einer Person
- Die Anrede einer Person (Herr, Frau, ...)
- Die eulerische Zahl e mit 14 Nachkommastellen
- Das Gewicht in kg
- Wurde Rechnung schon bezahlt?

### Einstieg

1. Lokale `int` Variable `a` mit Wert `47` erstellen
2. Globale `int` Konstante `K1` mit Wert `111` erstellen
3. Berechnen von `a + K1` und in `c` speichern
4. Ausgabe von `c` auf der Konsole (`System.out.println(...);`)
5. Lokale `double` Variable `b` mit Wert `101.98` erstellen
6. Lokale `double` Variable `d` ohne Wert anlegen
7. `d = a + b` berechnen
8. `d` ausgeben
9. `d` in `int` umwandeln und in neue `int` Variable `e` speichern
10. `boolean` Variable `b1` mit Wert `false` anlegen
11. `b1` auf `true` setzen
12. `String hello` mit "Hallo" anlegen
13. `String name` mit Ihrem Namen anlegen
14. Neue `String` Variable `greeting` erstellen, die "Hallo Max!" beinhaltet
15. Geben Sie auf die Konsole aus: `Das Ergebnis von a + b ist c`. `a`, `b`, `c` sollen durch aktuelle Werte ersetzt werden.

### Taschenrechner light

Erstellen Sie zwei `int` Variablen `x` und `y` und berechnen Sie folgende Ausdrücke:

```java
x + y  // 4 + 3 = 7
x - y  // 4 - 3 = 1
x / y  // 4 / 3 = 1  (als int)
x / y  // 4 / 3 = 1.333  (als double)
x % y  // 4 % 3 = 1
```

### Rechnung

1. Legen Sie 3 globale Konstanten an: `cola = 2€`, `wasser = 1€`, `bier = 4€`
2. Legen Sie 3 lokale Variablen an: `anzCola`, `anzWasser`, `anzBier`
3. Berechnen Sie die Summe und geben Sie aus:
   ```
   Die Rechnung von 3 Cola, 2 Wasser und 1 Bier ergibt 12€
   ```
4. Berechnen Sie den Durchschnittspreis der 3 Produkte und geben Sie ihn aus.

### Rechteck

1. Variablen für Länge und Breite eines Rechtecks anlegen
2. Umfang berechnen: `2 * (a + b)`
3. Fläche berechnen: `a * b`

### Kreis

1. Variable für Radius `r` anlegen
2. Umfang berechnen: `U = 2 * Math.PI * r`
3. Fläche berechnen: `A = Math.PI * r * r` oder `Math.pow(r, 2)`

### Umwandlung von Datentypen

**Wie viele Bytes benötigt man, um folgende Dezimalzahlen binär kodiert zu speichern?**
- 18
- 128
- 7635
- 897613
- 232

Welche Rechenergebnisse liefern folgende 9 Ausdrücke?

```java
int i = 4;
int j = 5;
double x;
x = (double) i / j;  
x = 1.0 * i / j * 10;
x = i / j * 10;  
x = 1.0 * (i / j) * 10;  
x = i * 10 / j;  
x = 10.0 * i / j;
x = (10.0 * i) / j;
x = i / 0.1 * j;
x = i / (0.1 * j);
```

### Weitere Übungen

1. Deklarieren Sie Variablen der Typen `int`, `double`, `char`, `boolean`, `long`, `float` und weisen Sie Werte zu.

2. Führen Sie eine Addition zweier int-Variablen + speichern in neuer Variable. Geben Sie das Ergebnis
auf die Konsole aus.

3. Führen Sie eine Subtraktion zweier double-Variablen durch.

4. Multiplizieren Sie zwei int-Variablen.

5. Teilen Sie zwei float-Variablen.

6. Erstellen Sie eine Variable vom Typ int und weisen Sie ihr den Wert einer double-Variable nach
Typumwandlung (Casting) zu.

7. Erstellen Sie eine Variable vom Typ double und weisen Sie ihr den Wert einer int-Variable nach Typumwandlung (Casting) zu.

8. Führen Sie eine Division von zwei int-Variablen durch und speichern Sie das Ergebnis in einer double-
Variablen.

9. Führen Sie eine Division von zwei double-Variablen durch und speichern Sie das Ergebnis in einer int-
Variablen.

10. Vergleichen Sie, ob zwei int-Variablen gleich sind und speichern Sie das Ergebnis in einer boolean-
Variablen. ``(a == b)``

11. Vergleichen Sie zwei double-Variablen und speichern Sie das Ergebnis in einer boolean-Variablen.

12. Deklarieren Sie eine char-Variable und weisen Sie ihr den Wert 'A' zu. Ändern Sie dann den Wert auf
'B'.

13. Deklarieren Sie eine boolean-Variable und weisen Sie ihr den Wert true zu. Ändern Sie dann den Wert
auf false.

14. Berechnen Sie den Durchschnitt von drei double-Variablen und speichern Sie das Ergebnis in einer
double-Variablen.

15. Berechnen Sie die Summe der ersten 10 natürlichen Zahlen (1 + 2 + 3 + ... + 10) und speichern Sie
das Ergebnis in einer int-Variablen.

16. Deklarieren Sie eine int-Variable und weisen Sie ihr den Wert 1000 zu. Führen Sie eine
Typumwandlung durch, um ihn in eine byte-Variable zu speichern.

17. Deklarieren Sie eine double-Variable und weisen Sie ihr den Wert 3.14159265359 zu. Führen Sie eine
Typumwandlung durch, um ihn in eine float-Variable zu speichern.

18. Erstellen Sie eine boolean-Variable und weisen Sie ihr den Wert true zu. Führen Sie eine
Typumwandlung durch, um ihn in eine int-Variable zu speichern (1 für true und 0 für false).

19. Deklarieren Sie eine char-Variable und weisen Sie ihr den Wert 'X' zu. Führen Sie eine
Typumwandlung durch, um ihn in eine int-Variable zu speichern.

Alle Übungen sollen auf der Konsole ausgegeben werden.

