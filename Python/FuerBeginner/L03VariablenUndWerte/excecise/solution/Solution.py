# -*- coding: utf-8 -*-

"""
Lösungsskript für die Python-Grundlagenübungen.
Jeder Abschnitt beginnt mit der Aufgabenstellung als mehrzeiligem Kommentar.
"""

print("### LÖSUNGEN ZU DEN PYTHON-ÜBUNGEN ###")

# =============================================================================
# Erstellen von Variablen und deren Typen
# =============================================================================

print("\n--- Abschnitt: Erkennen von Typen ---")
"""
### Erkennen von Typen

Welche Python-Datentypen (`int`, `float`, `str`, `bool`) würden Sie für 
folgende Informationen verwenden?

- Alter eines Menschen
- Das Jahresgehalt in ganzen Euro-Beträgen
- Das Geschlecht einer Person
- Die Anrede einer Person (Herr, Frau, Divers, ...)
- Die eulerische Zahl e mit 14 Nachkommastellen
- Das Gewicht in kg
- Wurde die Rechnung schon bezahlt?
"""
# Lösung als Kommentar:
# - Alter eines Menschen: int
# - Das Jahresgehalt in ganzen Euro-Beträgen: int
# - Das Geschlecht einer Person: str
# - Die Anrede einer Person (Herr, Frau, Divers, ...): str
# - Die eulerische Zahl e mit 14 Nachkommastellen: float
# - Das Gewicht in kg: float
# - Wurde die Rechnung schon bezahlt?: bool
print("Die Lösungen für 'Erkennen von Typen' sind als Kommentar im Code hinterlegt.")


# =============================================================================
# Einstieg
# =============================================================================

print("\n--- Abschnitt: Einstieg ---")
"""
### Einstieg

Führen Sie die folgenden Schritte in einem Python-Skript aus:

1.  Erstellen Sie eine lokale `int`-Variable `a` mit dem Wert `47`.
2.  Erstellen Sie eine "Konstante" `K1` mit dem Wert `111`.
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
14. Erstellen Sie eine neue `str`-Variable `greeting`, die eine Begrüßung ergibt.
15. Geben Sie auf der Konsole den Satz `Das Ergebnis von a + b ist [Ergebnis]` aus.
"""
# 1.
a = 47
# 2.
K1 = 111
# 3.
c = a + K1
# 4.
print(f"Schritt 4: c = {c}")
# 5.
b = 101.98
# 6.
d = 0.0
# 7.
d = a + b
# 8.
print(f"Schritt 8: d = {d}")
# 9.
e = int(d)
print(f"Schritt 9: e (d als int) = {e}")
# 10.
b1 = False
# 11.
b1 = True
print(f"Schritt 11: b1 = {b1}")
# 12.
hello = "Hallo"
# 13.
name = "Max" # Bitte eigenen Namen einsetzen
# 14.
greeting = f"{hello} {name}!"
print(f"Schritt 14: greeting = {greeting}")
# 15.
# Das Ergebnis von a + b ist in der Variable 'd' gespeichert.
print(f"Schritt 15: Das Ergebnis von {a} + {b} ist {d}")


# =============================================================================
# Taschenrechner light
# =============================================================================

print("\n--- Abschnitt: Taschenrechner light 🧮 ---")
"""
### Taschenrechner light 🧮

Erstellen Sie zwei `int`-Variablen `x` und `y` mit den Werten `4` und `3`. 
Berechnen und drucken Sie die Ergebnisse der folgenden Ausdrücke.
"""
x = 4
y = 3
print(f"x = {x}, y = {y}")
print(f"Summe (x + y):            {x + y}")
print(f"Differenz (x - y):        {x - y}")
print(f"Ganzzahl-Division (x // y): {x // y}")
print(f"Fließkomma-Division (x / y):{x / y}")
print(f"Modulo (x % y):             {x % y}")


# =============================================================================
# Rechnung
# =============================================================================

print("\n--- Abschnitt: Rechnung 🧾 ---")
"""
### Rechnung 🧾

1.  Legen Sie 3 "Konstanten" an: `COLA_PREIS = 2.0`, `WASSER_PREIS = 1.0`, `BIER_PREIS = 4.0`.
2.  Legen Sie 3 lokale Variablen an, die eine Anzahl für jedes Getränk speichern.
3.  Berechnen Sie die Gesamtsumme für eine Beispielrechnung und geben Sie sie aus.
4.  Berechnen Sie den Durchschnittspreis der drei Produkte und geben Sie ihn aus.
"""
# 1.
COLA_PREIS = 2.0
WASSER_PREIS = 1.0
BIER_PREIS = 4.0

# 2.
anz_cola = 3
anz_wasser = 2
anz_bier = 1

# 3.
gesamtsumme = (anz_cola * COLA_PREIS) + (anz_wasser * WASSER_PREIS) + (anz_bier * BIER_PREIS)
print(f"Die Rechnung von {anz_cola} Cola, {anz_wasser} Wasser und {anz_bier} Bier ergibt {gesamtsumme}€")

# 4.
durchschnittspreis = (COLA_PREIS + WASSER_PREIS + BIER_PREIS) / 3
# :.2f formatiert den Float auf 2 Nachkommastellen
print(f"Der Durchschnittspreis der Produkte beträgt {durchschnittspreis:.2f}€")


# =============================================================================
# Geometrie
# =============================================================================

print("\n--- Abschnitt: Geometrie 📐 ---")
"""
### Rechteck

1.  Legen Sie Variablen für die Länge (`a`) und Breite (`b`) eines Rechtecks an.
2.  Berechnen und drucken Sie den Umfang: `2 * (a + b)`.
3.  Berechnen und drucken Sie die Fläche: `a * b`.
"""
print("Rechteck:")
a_rect = 12.5
b_rect = 4
umfang_rect = 2 * (a_rect + b_rect)
flaeche_rect = a_rect * b_rect
print(f"Ein Rechteck mit Seiten {a_rect} und {b_rect} hat:")
print(f"  Umfang: {umfang_rect}")
print(f"  Fläche: {flaeche_rect}")

"""
### Kreis

1.  Importieren Sie das `math`-Modul.
2.  Legen Sie eine Variable für den Radius `r` an.
3.  Berechnen Sie den Umfang: `U = 2 * math.pi * r`.
4.  Berechnen Sie die Fläche: `A = math.pi * r**2`.
"""
print("\nKreis:")
# 1.
import math
# 2.
r_kreis = 5.0
# 3.
umfang_kreis = 2 * math.pi * r_kreis
# 4.
flaeche_kreis = math.pi * r_kreis**2
print(f"Ein Kreis mit Radius {r_kreis} hat:")
print(f"  Umfang: {umfang_kreis}")
print(f"  Fläche: {flaeche_kreis}")


# =============================================================================
# Umwandlung von Datentypen
# =============================================================================

print("\n--- Abschnitt: Umwandlung von Datentypen ---")
"""
### Theoretische Frage

**Wie viele Bytes benötigt man mindestens, um folgende Dezimalzahlen binär 
kodiert zu speichern?**

- 18: Benötigt 5 Bits (`10010`). Passt in **1 Byte**.
- 128: Benötigt 8 Bits (`10000000`). Passt in **1 Byte**.
- 7635: Benötigt 13 Bits. Passt in **2 Bytes**.
- 897613: Benötigt 20 Bits. Passt in **3 Bytes**.
- 232: Benötigt 8 Bits (`11101000`). Passt in **1 Byte**.
"""
print("Die Lösungen zur theoretischen Frage sind als Kommentar im Code hinterlegt.")


"""
### Ausdrücke auswerten

Welche Rechenergebnisse liefern die folgenden Ausdrücke, wenn sie **in Python** ausgeführt werden?
"""
print("\nAusdrücke auswerten:")
i = 4
j = 5
print(f"i = {i}, j = {j}")

# Ausdruck 1
x = i / j
print(f"x = i / j                  -> {x}")

# Ausdruck 2
x = 1.0 * i / j * 10
print(f"x = 1.0 * i / j * 10       -> {x}")

# Ausdruck 3
x = i // j * 10
print(f"x = i // j * 10            -> {x}")

# Ausdruck 4
x = 1.0 * (i // j) * 10
print(f"x = 1.0 * (i // j) * 10    -> {x}")

# Ausdruck 5
x = i * 10 / j
print(f"x = i * 10 / j             -> {x}")

# Ausdruck 6
x = 10.0 * i / j
print(f"x = 10.0 * i / j           -> {x}")

# Ausdruck 7
x = (10.0 * i) / j
print(f"x = (10.0 * i) / j         -> {x}")

# Ausdruck 8
x = i / 0.1 * j
print(f"x = i / 0.1 * j            -> {x}")

# Ausdruck 9
x = i / (0.1 * j)
print(f"x = i / (0.1 * j)          -> {x}")


# =============================================================================
# Weitere Übungen
# =============================================================================

print("\n--- Abschnitt: Weitere Übungen ---")

# 1. Erstellen Sie Variablen der Typen `int`, `float`, `bool` und `str`.
int_var = 500
float_var = 199.99
bool_var = True
str_var = "Das ist ein Python-String"
print(f"1. Variablen erstellt: {int_var}, {float_var}, {bool_var}, '{str_var}'")

# 2. Addition zweier `int`-Variablen.
int_sum1 = 101
int_sum2 = 202
int_sum_ergebnis = int_sum1 + int_sum2
print(f"2. {int_sum1} + {int_sum2} = {int_sum_ergebnis}")

# 3. Subtraktion zweier `float`-Variablen.
float_sub1 = 333.33
float_sub2 = 111.11
float_sub_ergebnis = float_sub1 - float_sub2
print(f"3. {float_sub1} - {float_sub2} = {float_sub_ergebnis}")

# 4. Multiplikation zweier `int`-Variablen.
int_mul1 = 7
int_mul2 = 8
int_mul_ergebnis = int_mul1 * int_mul2
print(f"4. {int_mul1} * {int_mul2} = {int_mul_ergebnis}")

# 5. Teilung zweier `float`-Variablen.
float_div1 = 50.0
float_div2 = 4.0
float_div_ergebnis = float_div1 / float_div2
print(f"5. {float_div1} / {float_div2} = {float_div_ergebnis}")

# 6. Typumwandlung: `float` zu `int`.
float_fuer_int = 88.72
int_von_float = int(float_fuer_int)
print(f"6. {float_fuer_int} als int ist {int_von_float}")

# 7. Typumwandlung: `int` zu `float`.
int_fuer_float = 42
float_von_int = float(int_fuer_float)
print(f"7. {int_fuer_float} als float ist {float_von_int}")

# 8. Division von zwei `int`-Variablen, Ergebnis in `float`.
int_div_f1 = 25
int_div_f2 = 2
float_ergebnis = int_div_f1 / int_div_f2
print(f"8. {int_div_f1} / {int_div_f2} = {float_ergebnis} (als float)")

# 9. Division von zwei `float`-Variablen, Ergebnis in `int`.
float_div_i1 = 100.0
float_div_i2 = 9.0
int_ergebnis = int(float_div_i1 / float_div_i2)
print(f"9. {float_div_i1} / {float_div_i2} = {int_ergebnis} (als int)")

# 10. Zwei `int`-Variablen vergleichen.
comp_i1 = 50
comp_i2 = 50
sind_gleich_int = (comp_i1 == comp_i2)
print(f"10. Sind {comp_i1} und {comp_i2} gleich? {sind_gleich_int}")

# 11. Zwei `float`-Variablen vergleichen.
comp_f1 = 0.1 + 0.2
comp_f2 = 0.3
sind_gleich_float = (comp_f1 == comp_f2)
print(f"11. Sind {comp_f1} und {comp_f2} gleich? {sind_gleich_float} (Achtung bei Float-Vergleichen!)")

# 12. String-Variable ('char') ändern.
mein_char = 'A'
print(f"12. Original-char: {mein_char}")
mein_char = 'B'
print(f"12. Geänderter char: {mein_char}")

# 13. Boolean-Variable ändern.
mein_bool = True
print(f"13. Original-bool: {mein_bool}")
mein_bool = False
print(f"13. Geänderter bool: {mein_bool}")

# 14. Durchschnitt von drei `float`-Variablen.
d_avg1, d_avg2, d_avg3 = 15.0, 20.5, 30.0
durchschnitt = (d_avg1 + d_avg2 + d_avg3) / 3
print(f"14. Der Durchschnitt von {d_avg1}, {d_avg2}, {d_avg3} ist {durchschnitt}")

# 15. Summe der ersten 10 natürlichen Zahlen.
summe_1_bis_10 = sum(range(1, 11)) # range(1, 11) generiert Zahlen von 1 bis 10
print(f"15. Die Summe der Zahlen 1 bis 10 ist {summe_1_bis_10}")

# 16. `int` (1000) in "Byte" umwandeln.
wert_1000 = 1000
als_byte_simuliert = wert_1000 % 256 # Modulo 256 simuliert den 8-bit Überlauf
print(f"16. Der Wert {wert_1000} in einem 'Byte' wäre {als_byte_simuliert}")

# 17. `double` zu `float` umwandeln.
# In Python ist `float` bereits ein double-precision float.
double_wert = 3.14159265359
float_wert_kopie = double_wert
print(f"17. Wert {double_wert} einer neuen float-Variable zugewiesen.")

# 18. `bool` zu `int` umwandeln.
int_von_true = int(True)
int_von_false = int(False)
print(f"18. True als int ist {int_von_true}, False als int ist {int_von_false}")

# 19. `char` zu `int` umwandeln.
char_x = 'X'
int_von_char_x = ord(char_x) # ord() gibt den ASCII/Unicode-Wert zurück
print(f"19. Der int-Wert von '{char_x}' ist {int_von_char_x}")