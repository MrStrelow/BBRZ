
# Typisierung in Programmiersprachen: Strikt, Schwach, Statisch und Dynamisch

## Strikte vs. Schwache Typisierung

Sprachen wie Python und JAVA werden oft als **stark typisiert** bezeichnet, was bedeutet, dass der Typ einer Variable nicht automatisch in einen anderen Typ umgewandelt wird, ohne eine explizite Umwandlung vorzunehmen. Zum Beispiel:

```python
x = 5         # x ist eine Zahl
y = "10"      # y ist ein String
z = x + y     # TypeError: unsupported operand type(s) - Führt zu einem Fehler, da ein String und eine Zahl nicht direkt kombiniert werden können.
```

Im Gegensatz dazu kann eine **schwach typisierte** Sprache wie JavaScript Typen implizit konvertieren:

```javascript
console.log("3" + 3);  // Gibt "33" aus.
```

```javascript
let x = "10";     // x ist ein String
let y = 5;        // y ist eine Zahl
let z = x - y;    // "5" - String wird implizit umgewandelt
```

**Strikt typisierte Sprachen**:
- Implizite Typkonvertierungen sind nicht erlaubt oder nur in kontrollierten Ausnahmen möglich.
- Typfehler treten frühzeitig auf.
- Beispiele: **Java**, **Python**, **C/C++**

**Schwach typisierte Sprachen**:
- Implizite Typkonvertierungen (Type Coercion) werden automatisch durchgeführt.
- Potenziell fehleranfällig durch unerwartetes Verhalten.
- Beispiele: **JavaScript**, **PHP**

---

## Statisch vs. Dynamische Typisierung

Zusätzlich zur starken oder schwachen Typisierung können Programmiersprachen **statisch** oder **dynamisch** typisiert sein:

**Statisch typisiert**: 
- Variablen müssen vor ihrer Verwendung deklariert werden, und der Typ ist zur Kompilierzeit festgelegt.
- Typfehler treten frühzeitig (Kompilierzeit) auf.
- Erlaubt dem Kompiler eine Vielzahl an Optimierungen.
- Beispiele: **Java**, **C/C++**, **Rust**

**Dynamisch typisiert**: 
- Der Typ einer Variable wird zur Laufzeit bestimmt. Keine Unterstützung während des Programmierens möglich. Schwer bei komplexeren Programmen die Kontrakte einzuhalten.
- Schlänkeres Programmieren möglich, jedoch meist setzt sich eine Art der statischen Typisierung durch. Grund dafür sind Fehlerhafte Implementierungen werden oft spät erkannt. Iim weitesten Sinne der Statischen Typisierung erlaubt Python die Möglichkeit neben Variablen dessen vorhergesehen Typ hinzuschreiben. Das wird jedoch immer noch zur Laufzeit überprüft.
- Beispiele: **JavaScript**, **Python**

Die Wahl zwischen statischer und dynamischer Typisierung hängt oft von den Anforderungen des Projekts ab. Statische Typisierung bietet mehr Sicherheit und ist in großen, komplexen Systemen vorteilhaft, während dynamische Typisierung eine schnellere Entwicklung ermöglicht und sich gut für kleinere oder explorative (prototyping) Projekte eignet. Wissenschaftliche Sprachen wie **Matlab** und **R** sind meist dynamisch.

## Ausnahmen in JAVA (stark strikt typisiert)

**Ist `nicht` im Sinne der statischen Typisierung**
Ist jedoch erlaubt, da es oft zu dieser Umwandlung kommt, jedoch wir nichts falsch machen können. Ein Int ist immer als Double darstellbar.
```java
double x = 5.0;
int y = 1;
x = y;
System.out.println(x);
```

**Ist `nicht` im Sinne der starken Typisierung**
```java
String a = "Test";
int b = 4;
System.out.Println(a + b);  // Fehler: String kann nicht in int konvertiert werden
```

**Ist im Sinne der starken Typisierung**
```java
String a = "Test";
int b = a;  // Fehler: String kann nicht in int konvertiert werden
```

**Ist im Sinne der statischen Typisierung**
```java
int num = 5;
num = "Hello";  // Fehler, da Typinkompatibilität (int und String)
```
---

## Kombinationen: Dynamisch vs. Statisch, Stark vs. Schwach

| Kombination                  | Typprüfung          | Typkonvertierungen | Beispiele        | Eigenschaften                                                                                   |
|------------------------------|---------------------|---------------------|------------------|-----------------------------------------------------------------------------------------------|
| **Schwach dynamisch**        | Zur Laufzeit        | Erlaubt            | JavaScript, PHP  | Flexibel, aber fehleranfällig durch unerwartete automatische Typkonvertierungen.              |
| **Schwach statisch**         | Zur Kompilierzeit   | Erlaubt            | C, C++           | Potenziell unsicher, da implizite Typkonvertierungen möglich sind (z. B. Speicherprobleme).    |
| **Stark dynamisch**          | Zur Laufzeit        | Nicht erlaubt      | Python, Ruby     | Flexibel, aber sicherer durch die Vermeidung impliziter Typkonvertierungen.                   |
| **Stark statisch**           | Zur Kompilierzeit   | Nicht erlaubt      | Java, Rust       | Höchste Fehlersicherheit, da alle Typen explizit und zur Kompilierzeit überprüft werden.       |