
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

**Ist aber `nicht` im Sinne der statischen Typisierung**
Ist jedoch erlaubt, da es oft zu dieser Umwandlung kommt, jedoch wir nichts falsch machen können. Ein Int ist immer als Double darstellbar.
```java
double x = 5.0;
int y = 1;
x = y;
System.out.println(x); // kein Fehler, sollte aber sein.
```

**Ist aber `nicht` im Sinne der starken Typisierung**
```java
String a = "Test";
int b = 4;
System.out.Println(a + b);  // kein Fehler, sollte aber sein.
```

Achtung! Es ist jedoch anzumerken, dass in JAVA konkrete und `konsistente` Regeln herrschen, wie Ausnahmen funktionieren. Deshalb ist JAVA stark typisiert. Zudem betrachten wir hier eine vereinfachte Version. Für genaueres betrachte folgende Beispiele auf Wikipedia TODO: und hier am Ende in Kapitel X TODO:.

Ein Vergleich einer schwach typisierten Sprache ist JavaScript. Hier herrschen `inkonsistente` Regeln zwischen (verschiedene) Operatoren.
```javascript
5 + "5"  // "55" (String)
5 - "5"  // 0 (Zahl)
```

**Ist im Sinne der starken Typisierung** TODO: falsches beispiel?
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



# Starkes vs. Schwaches Typsystem

Ein starkes und ein schwaches Typsystem unterscheiden sich vor allem durch den Grad der Strenge, mit der Typen in einer Programmiersprache behandelt werden:

## Starkes Typsystem:
- Typen werden strikt eingehalten.
- Typkonvertierungen (implizit oder explizit) müssen genau definiert sein und sind in der Regel restriktiv.
- Operationen zwischen inkompatiblen Typen sind ohne explizite Konvertierung nicht erlaubt.
- **Beispiele:** Java, C#, Python.

## Schwaches Typsystem:
- Typen werden weniger strikt gehandhabt.
- Implizite Typkonvertierungen werden oft durchgeführt, selbst wenn sie nicht sinnvoll oder eindeutig sind.
- Operationen zwischen inkompatiblen Typen können problemlos ausgeführt werden, was potenziell zu Laufzeitfehlern führt.
- **Beispiele:** JavaScript, PHP, Perl.

---

## Warum ist `5 + "5"` in Java erlaubt, obwohl es ein stark typisiertes System ist?
Das Verhalten hängt von der **Spezifikation der Sprache** ab, nicht davon, ob das Typsystem stark oder schwach ist. Java erlaubt die Konkatenation von Strings mit anderen Datentypen, da der Operator `+` in diesem Kontext **überladen** ist:
- Wenn einer der Operanden ein String ist, wird der andere Operand implizit in einen String umgewandelt.
- **Ergebnis:** `"5"` wird nicht zu `int` konvertiert, sondern `5` wird zu `"5"` umgewandelt und die beiden Strings werden konkateniert.

Hier wird also eine **implizite Typumwandlung** durchgeführt, aber unter klar definierten Regeln. Das bedeutet, dass Java in diesem Fall **keine Typverletzung** begeht. Im Gegensatz dazu könnte eine schwach typisierte Sprache wie JavaScript automatisch und unvorhersehbar zwischen Zahlen und Strings hin- und herkonvertieren, z. B.:

```javascript
5 + "5"  // "55" (String)
5 - "5"  // 0 (Zahl)
```

---

## Ist der Unterschied mehr als implizite und explizite Typumwandlungen?
Ja, der Unterschied zwischen starkem und schwachem Typsystem geht über Typkonvertierungen hinaus. Entscheidend ist:

### 1. Konsistenz der Typregeln:
- Ein starkes Typsystem verhindert, dass Operationen zwischen inkompatiblen Typen ohne klare Regeln erlaubt werden.
- Ein schwaches Typsystem erlaubt oft Operationen, die zur Laufzeit Probleme verursachen können.

### 2. Fehlervermeidung:
- Ein starkes Typsystem erkennt Typfehler früh (meist zur Compile-Zeit).
- Ein schwaches Typsystem kann Typfehler erst zur Laufzeit erkennen.

### 3. Sicherheit:
- Ein starkes Typsystem erhöht die Typensicherheit, da Konvertierungen explizit oder nach festgelegten Regeln erfolgen müssen.
- Ein schwaches Typsystem bietet mehr Flexibilität, aber weniger Sicherheit.

---

## Fazit:
Der Unterschied zwischen starkem und schwachem Typsystem liegt weniger in der Frage von **impliziten/ expliziten Typumwandlungen**, sondern vielmehr in der Strenge und Konsistenz der Typregeln. Java erlaubt `5 + "5"` aufgrund der **klar definierten Regeln** zur String-Konkatenation, bleibt dabei aber stark typisiert, da keine unsicheren oder unvorhersehbaren Typkonvertierungen stattfinden.
