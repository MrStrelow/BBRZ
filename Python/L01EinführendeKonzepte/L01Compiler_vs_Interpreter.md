
# Compiler vs. Interpreter

## Was ist ein Compiler?
Ein Compiler übersetzt den Quellcode einer Programmiersprache vollständig in Maschinencode (z. B. eine ausführbare Datei), bevor das Programm ausgeführt wird. Beispiele: **Java (mit Bytecode)**, **C**, **C++**. Falls wir einen Fehler einbauen wirft der Compiler einen Fehler der meist kryptisch ist und Erfahrung braucht um diesen zu verstehen. Wir sind also nicht schlauer und wissen nur, dass unser Programm nicht funktioniert (der Debugmodus hilft hier, jedoch muss es eine IDE geben welche diesen implementiert.).
```java
public class Main {
    public static void main(String[] args) {
        String a = "ich besitze ein x";
        System.out.println(a);
        System.out.println(b); // fehler, wir kennen die Variable b nicht, deshalb wird dar Kompilevorgang abgebrochen. Wir sehen nichts von den vorherigen Ergebnissen des Programmes.
    }
}
```
Wir bekommen folgende Fehlermeldung.
```
java: cannot find symbol
  symbol:   variable b
  location: class asdf
```

## Was ist ein Interpreter?
Ein Interpreter übersetzt und führt den Quellcode Zeile für Zeile aus, ohne eine vollständige Übersetzung des Programms vor der Ausführung. Beispiele: **Python**, **Ruby**. Es ist nicht wie beim Compiler notwendig ein korrektes Programm zu schreiben um "Output" erzeugen zu können.
```python
a = "ich besitze ein x"
print(a)
print(b) # fehler, wir kennen die Variable b nicht, aber wir haben vorher die Varaible "a" mit dem Wert "ich besitze ein x" vorher ausgegeben können.
```

Wir bekommen folgende Fehlermeldung, jedoch mit vorherig ausgeführten Code.
```
>>> a = "ich besitze ein x"
>>> print(a)
ich besitze ein x
>>> print(b) # fehler, wir kennen die Variable b nicht, aber wir haben vorher die Varaible "a" mit dem Wert "ich besitze ein x" vorher ausgegeben können.
Traceback (most recent call last):
  File "<stdin>", line 1, in <module>
NameError: name 'b' is not defined
```
Wir können nun im Nachhinein Code schreiben, welcher uns das überprüft. Auch können wir können in den Zustand des Programms schauen und Fehler erkennen.
Das erleichtert uns so genanntes Prototyping (schnelles erstellen von "minimal viable code"). Wenn wir wissen wollen ob eine Variable z.B. ein Symbol "x" enthält, geben wir die variable einfach aus und schauen nach, ohne das Programm neu ausführen zu müssen.

```python
>>> a
'ich besitze ein x'
>>> 'x' in a
True
```
---

## Ablauf der Programmausführung: Java vs. Python

### Java: Kompilierter Ansatz
1. **Kompilierung**:
   - Der Java-Quellcode (*.java) wird mit dem `javac`-Compiler in Bytecode (*.class) übersetzt.
   - Dieser Bytecode ist plattformunabhängig.
2. **Ausführung**:
   - Die Java Virtual Machine (JVM) interpretiert den Bytecode oder nutzt Just-In-Time (JIT)-Kompilierung, um ihn in Maschinencode umzuwandeln.
   - Der optimierte Maschinencode wird dann ausgeführt.

**Vorteile**:
Ein großer Vorteil ist, dass Bytecode effizienter als der direkt interpretierter Code ist. Das hat den Grund, dass der Compiler den erzeugten Code optimieren kann. Für solche Optimierungen kann folgendes helfen:
 - Sprache ist `typtisiert`, erlaubt dem Compiler im vorhinein zu wissen "um was es geht" bei den Variablen.
 - JIT-Kompilierung (Just in Time) oder AOH-Kompilierung (Ahead of Time) erlaubt:
    - Verwendung von Speicherzugriffen welche an das Programm angepasst sind (Daten liegen nebeneinander im Speicher, Caching vs. Hauptspeicher, Verwendung von Registern der CPU, Inline Funktionen, ...)
    - entfernt nicht erreichbaren Programmcode
    - code welcher unabängig ist z.B. in einer Schleife, parallelisieren.
    - ...

**Aufruf in JAVA**:
```
javac Programm.java   // Kompiliert den Quellcode
java Programm         // Führt den Bytecode mit der JVM aus
```

### Python: Interpretierter Ansatz

1. **Quellcode-Analyse**:
   - Der Python-Interpreter übersetzt den Quellcode (*.py) in Bytecode (*.pyc).
2. **Ausführung**:
   - Der Bytecode wird von der Python Virtual Machine (PVM) zeilenweise interpretiert und ausgeführt.
   - es sind nur `sehr beschränkt` optimierungen möglich, da es nur die aktuellen Zustand des Codes kennt und keine Kenntnis über den gesamten Ablauf des Programmes kennt.

**Vorteile**:
- Flexibel und gut für schnelles Prototyping.
- falls compilierung benötigt wird gibt es externe Tools welche eine kompilierte Version von Python erlauben (pypy (JIT), cython (AOT), numba, ...). Ob dies sinnvoll ist, oder eine "inkorrekte" Verwendung der Sprache, ist oft nicht klar und ist dem Software Engineer überlassen.
- externe packages sind meist in anderen (kompilierten, schnellen) Sprachen wie C/C++, Rust oder Go implementiert. Das erlaubt uns aufwändige Operationen auszulagern und den "prototyping" Charakter von interpretierten Sprachen zu genießen.

## **Python code Zeile für Zeile vs. als Kommando aufrufen**

### **1. Eingabe im Interpreter (interaktive Umgebung)**
- Wenn du eine Zeile Code in den Python-Interpreter eingibst, wird der Code sofort **parsiert** und in **Bytecode** übersetzt.
- Dieser Bytecode wird direkt an die Python Virtual Machine (PVM) übergeben, die ihn **interpretiert und ausführt**.

---
### **Ausführung eines `.py`-Files**
Wenn du eine `.py`-Datei ausführst, durchläuft Python mehrere Schritte:

#### **a. Parsing**
Der Quellcode wird analysiert und in eine interne **AST (Abstract Syntax Tree)**-Struktur umgewandelt.

#### **b. Bytecode-Erstellung**
Python übersetzt die gesamte Datei in Bytecode (*.pyc), der im Verzeichnis `__pycache__` gespeichert wird. Dies passiert nur, wenn das Skript als Datei ausgeführt wird, nicht im interaktiven Modus.

---

## Warum sind kompilierte Sprachen meist schneller?
1. **Typprüfung zur Kompilierzeit**:
   - Java prüft Typen während der Kompilierung. Python prüft Typen zur Laufzeit, was zusätzlichen Aufwand während der Ausführung bedeutet.
2. **Optimierung**:
   - Der Compiler führt Optimierungen durch, z. B. memory management oder konstante Ausdrücke vorab berechnen.
3. **Maschinencode**:
   - Kompilierte Programme laufen (meist) direkt auf der Hardware, während interpretierte Programme zusätzlichen Aufwand für die Interpretation benötigen.

---

## Vergleich der Ausführungszeit: Java vs. Python

### Programm 1: Summe von Zahlen berechnen
**Java**:
```
public class Sum {
    public static void main(String[] args) {
        long start = System.nanoTime();
        int sum = 0;
        for (int i = 0; i < 100000000; i++) {
            sum += i;
        }
        long end = System.nanoTime();
        System.out.println("Dauer: " + (end - start) / 1e6 + " ms");
    }
}
```
Dauer: 3.2088 ms

**Python**:
```
import time

start = time.time()
sum = 0
for i in range(100000000):
    sum += i

end = time.time()
print(f"Dauer: {(end - start) * 1000} ms")
```
Dauer: 11039.769649505615 ms (inline)
Dauer: 6971.364498138428 ms (py speed_test.py)

**Ergebnisse**:
- **Java**: Führt die Schleife deutlich schneller aus, da die Typen während der Kompilierung optimiert werden.
- **Python**: Deutlich langsamer, da Typprüfungen für `sum` und `i` bei jedem Schleifendurchlauf stattfinden.

### Programm 2: String-Verkettung
**Java**:
```java
public class Concat {
    public static void main(String[] args) {
        long start = System.nanoTime();
        String s = "";
        for (int i = 0; i < 100000; i++) {
            s += i;
        }
        long end = System.nanoTime();
        System.out.println("Dauer: " + (end - start) / 1e6 + " ms");
    }
}
```
Dauer: 4002.8641 ms

```java
public class asdf {
    public static void main(String[] args) {
        long start = System.nanoTime();
        StringBuilder s = new StringBuilder("");
        for (int i = 0; i < 100000; i++) {
            s.append(i);
        }
        long end = System.nanoTime();
        System.out.println("Dauer: " + (end - start) / 1e6 + " ms");
    }
}
```
Dauer: 6.0571 ms

**Python**:
```python
import time

start = time.time()
s = ""
for i in range(100000):
    s += str(i)


end = time.time()
print(f"Dauer: {(end - start) * 1000} ms")
```
Dauer: 651.8948078155518 ms
Dauer: 735.9282970428467 ms (py speed_test.py)

```python
import time

start = time.time()
s = []
for i in range(100000):
    s.append(str(i))
s = ''.join(s)

end = time.time()
print(f"Dauer: {(end - start) * 1000} ms")
```

Dauer: 27.76336669921875 ms
Dauer: 15.503168106079102 ms (py speed_test.py)

```python
import time

start = time.time()
size = 100000
s = [None] * size
for i in range(size):
    s[i] = str(i)

s = ''.join(s)

end = time.time()
print(f"Dauer: {(end - start) * 1000} ms")
```
Dauer: 29.15644645690918 ms
Dauer: 13.885021209716797 ms  (py speed_test.py)

**Ergebnisse**:
- **Java**: Schneller durch optimierte Speicherverwaltung bei Strings.
- **Python**: Deutlich langsamer, da Strings in Python immutable sind und jedes `+=` eine neue Speicherzuteilung erfordert.

---

## Fazit
- **Java** (kompiliert): Bessere Performance durch statische Typprüfung und Optimierung bei der Kompilierung.
- **Python** (interpretiert): Flexibler, aber langsamer durch dynamische Typprüfung und fehlende Kompilierungsoptimierung.

---
