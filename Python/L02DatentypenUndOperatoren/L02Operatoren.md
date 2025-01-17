# Operatoren in Python vs. Java

In Python und Java gibt es viele Ähnlichkeiten bei den Operatoren, jedoch gibt es auch Unterschiede. Hier sind einige Beispiele, die die Verwendung von Operatoren in beiden Sprachen verdeutlichen.

## Vergleich von Operatoren

### 1. Arithmetische Operatoren

#### Python
```python
x = 10
y = 5
summe = x + y
differenz = x - y
produkt = x * y
quotient = x / y  # Division ergibt immer ein float
rest = x % y
```

#### Java
```java
int x = 10;
int y = 5;
int summe = x + y;
int differenz = x - y;
int produkt = x * y;
double quotient = (double) x / y; // Division muss explizit zu double gecastet werden
int rest = x % y;
```

### 2. Vergleichsoperatoren

#### Python
```python
a = 10
b = 20
is_equal = a == b  # Gleich
is_greater = a > b  # Größer als
is_smaller = a < b  # Kleiner als
is_not_equal = a != b  # Ungleich
```

#### Java
```java
int a = 10;
int b = 20;
boolean isEqual = a == b;  // Gleich
boolean isGreater = a > b; // Größer als
boolean isSmaller = a < b; // Kleiner als
boolean isNotEqual = a != b; // Ungleich
```

### 3. Logische Operatoren

#### Python
```python
a = True
b = False
result_and = a and b  # UND
result_or = a or b  # ODER
result_not = not a  # NICHT
```

#### Java
```java
boolean a = true;
boolean b = false;
boolean resultAnd = a && b;  // UND
boolean resultOr = a || b;   // ODER
boolean resultNot = !a;      // NICHT
```

### 4. Inkrement- und Dekrement-Operatoren

#### Python
In Python gibt es keinen `++` oder `--` Operator. Stattdessen verwendet man:

```python
x = 5
x += 1  # Inkrement
x -= 1  # Dekrement
```

#### Java
In Java gibt es die Inkrement- und Dekrement-Operatoren `++` und `--`:

```java
int x = 5;
x++;  // Inkrement
x--;  // Dekrement
```

### 5. Ternärer Operator (Bedingte Ausdrücke)

#### Python
```python
x = 5
result = "Positiv" if x > 0 else "Negativ"  # Kurzschreibweise für if-else
```

#### Java
```java
int x = 5;
String result = (x > 0) ? "Positiv" : "Negativ";  // Kurzschreibweise für if-else
```

### 6. Bitweise Operatoren

#### Python
```python
x = 5
y = 3
result = x & y  # Bitweises UND
result = x | y  # Bitweises ODER
result = x ^ y  # Bitweises XOR
result = ~x     # Bitweises NOT
result = x << 2 # Linksverschiebung
result = x >> 2 # Rechtsverschiebung
```

#### Java
```java
int x = 5;
int y = 3;
int result = x & y;  // Bitweises UND
result = x | y;      // Bitweises ODER
result = x ^ y;      // Bitweises XOR
result = ~x;         // Bitweises NOT
result = x << 2;     // Linksverschiebung
result = x >> 2;     // Rechtsverschiebung
```

## Fazit
- **Arithmetische Operatoren** und **Vergleichsoperatoren** sind in Python und Java sehr ähnlich, mit dem Unterschied, dass die Division in Python immer einen `float` zurückgibt, während Java bei der Division von Ganzzahlen einen `int` zurückgibt, es sei denn, es wird ein Cast auf `double` gemacht.
- **Logische Operatoren** sind fast identisch, mit dem einzigen Unterschied, dass Python die Schreibweise `not` anstelle von `!` verwendet.
- **Inkrement- und Dekrement-Operatoren** sind in Python nicht verfügbar, und stattdessen müssen `+=` und `-=` verwendet werden.
- **Der ternäre Operator** hat in beiden Sprachen ähnliche Funktionen, verwendet jedoch unterschiedliche Syntax.
- **Bitweise Operatoren** sind in beiden Sprachen weitgehend gleich, da sie auf der gleichen Bit-Operationsebene arbeiten.

Beachten Sie, dass die Typisierung und die Verfügbarkeit von Operatoren aufgrund der unterschiedlichen Sprachparadigmen (Python ist dynamisch typisiert, während Java statisch typisiert ist) leicht variieren können. 
