# Referenzdatentyp vs. Wertdatentyp in Java und Python

## Definitionen

### Wertdatentyp (Value Type)
- Speichert direkt die Daten im Speicher.
- Wird normalerweise im Stack gespeichert (in Java).
- Beispiele in Java: Primitive Datentypen wie `int`, `float`, `boolean`, `char`.

### Referenzdatentyp (Reference Type)
- Speichert einen Verweis (Referenz) auf den Speicherort, an dem die eigentlichen Daten gespeichert sind.
- Wird normalerweise im Heap gespeichert, die Referenz selbst im Stack (in Java).
- Beispiele in Java: Arrays, Objekte von Klassen, Strings.

---

## Java: Referenz- und Wertdatentypen

### Wertdatentypen

Beispiel für Wertdatentyp:
```java
int a = 5;
int b = a;
b = 10;
System.out.println(a); // Ausgabe: 5
```
- `b` kopiert den Wert von `a`. Änderungen an `b` beeinflussen `a` nicht.

### Referenzdatentypen

Beispiel für Referenzdatentyp:
```java
int[] array1 = {1, 2, 3};
int[] array2 = array1;
array2[0] = 10;
System.out.println(array1[0]); // Ausgabe: 10
```
- `array2` referenziert denselben Speicherort wie `array1`. Änderungen an `array2` wirken sich auch auf `array1` aus.

---

## Python: Dynamische Typisierung

In Python sind alle Datentypen Referenztypen, auch primitive Typen. Variablen sind lediglich Referenzen auf Objekte im Speicher.

### Beispiel
```python
a = 5
b = a
b = 10
print(a)  # Ausgabe: 5
```
- Obwohl alles Referenztypen sind, wirken primitive Typen wie Werte, da sie unveränderlich (immutable) sind.

### Beispiel mit veränderlichen Typen
```python
list1 = [1, 2, 3]
list2 = list1
list2[0] = 10
print(list1)  # Ausgabe: [10, 2, 3]
```
- Listen sind veränderlich (mutable). Änderungen an `list2` beeinflussen auch `list1`.

---

## Unterschied Java vs. Python

### Speicherverhalten
- **Java:** Unterschied zwischen Werttypen (Stack) und Referenztypen (Heap).
- **Python:** Alle Typen sind Referenztypen, aber unveränderliche Typen (z. B. `int`, `str`) verhalten sich ähnlich wie Werttypen.

### Typisierung
- **Java:** Statisch typisiert; Typen müssen zur Compile-Zeit festgelegt werden.
- **Python:** Dynamisch typisiert; Typen werden zur Laufzeit bestimmt.

---

## Zusammenfassung
| Eigenschaft            | Java Werttyp       | Java Referenztyp | Python              |
|------------------------|--------------------|------------------|---------------------|
| Speicherort            | Stack             | Heap             | Heap                |
| Direkte Datenhaltung   | Ja                | Nein             | Nein                |
| Mutable/Immutable      | Immutable (meist) | Mutable/Immutable| Mutable/Immutable   |
| Typprüfung             | Statisch          | Statisch         | Dynamisch           |
