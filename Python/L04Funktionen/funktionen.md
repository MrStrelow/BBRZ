# Funktionen in Python und Java

## Python-Funktionen
In Python werden Funktionen mit dem Schlüsselwort `def` definiert. Die Syntax ist einfach und flexibel, und es gibt keine Angabe von Rückgabetypen oder Parametertypen in der Funktionsdefinition:

### Syntax einer Funktion in Python
```python
# Beispiel einer einfachen Funktion
def beispiel_funktion(param1, param2="Default"):
    """
    Dies ist ein Beispiel für eine Funktion in Python.
    param1: Ein beliebiger Parameter
    param2: Ein Parameter mit einem Standardwert
    """
    print(f"Parameter 1: {param1}, Parameter 2: {param2}")
    return param1 + len(param2)
```

#### Java-Äquivalent
```java
// Beispiel einer Methode in Java
public class Beispiel {
    public int beispielMethode(String param1, String param2) {
        if (param2 == null) param2 = "Default";
        System.out.println("Parameter 1: " + param1 + ", Parameter 2: " + param2);
        return param1.length() + param2.length();
    }
}
```

### Besonderheiten von Python-Funktionen
- **Dynamische Typisierung**: Parameter und Rückgabewerte haben keine feste Typenbindung.
- **Optionale Parameter**: Parameter können Standardwerte erhalten.
- **Dokstrings**: Mehrzeilige Kommentare zur Beschreibung der Funktion.
- **Anonyme Funktionen**: Mit dem Schlüsselwort `lambda` können kleine, einmalige Funktionen definiert werden.

```python
# Lambda-Funktion
addiere = lambda x, y: x + y
print(addiere(5, 3))  # Ausgabe: 8
```

#### Java-Äquivalent
```java
// Lambda-Funktion in Java (ab Java 8)
import java.util.function.BiFunction;

public class LambdaBeispiel {
    public static void main(String[] args) {
        BiFunction<Integer, Integer, Integer> addiere = (x, y) -> x + y;
        System.out.println(addiere.apply(5, 3));  // Ausgabe: 8
    }
}
```

---

## Argumenttypen in Python: Positional vs. Keyword

### Positional Arguments
Positional Arguments werden in der Reihenfolge übergeben, in der sie in der Funktionsdefinition angegeben sind.

```python
def beispiel(pos1, pos2):
    return pos1 * pos2

print(beispiel(5, 3))  # Ausgabe: 15
```

#### Java-Äquivalent
```java
public class Argumente {
    public int beispiel(int pos1, int pos2) {
        return pos1 * pos2;
    }

    public static void main(String[] args) {
        Argumente arg = new Argumente();
        System.out.println(arg.beispiel(5, 3));  // Ausgabe: 15
    }
}
```

### Keyword Arguments
Keyword Arguments erlauben es, Parameter explizit durch ihren Namen zu benennen, was die Lesbarkeit verbessert.

```python
def beispiel_kwarg(arg1, arg2=10):
    return arg1 + arg2

print(beispiel_kwarg(arg1=5, arg2=20))  # Ausgabe: 25
```

#### Java-Äquivalent
In Java gibt es keine direkte Unterstützung für Keyword-Argumente. Man kann jedoch Builder-Pattern oder optionale Parameter simulieren:

```java
public class KeywordArgumente {
    public int beispielKwarg(int arg1, Integer arg2) {
        if (arg2 == null) arg2 = 10;
        return arg1 + arg2;
    }

    public static void main(String[] args) {
        KeywordArgumente kwarg = new KeywordArgumente();
        System.out.println(kwarg.beispielKwarg(5, 20));  // Ausgabe: 25
    }
}
```

### Kombination aus Positional und Keyword Arguments
- In Python können Positional und Keyword Arguments kombiniert werden.
- Das `/`-Symbol kennzeichnet Argumente, die nur positional verwendet werden dürfen.
- Das `*`-Symbol markiert den Beginn von nur-Keyword-Argumenten.

```python
def gemischte_funktion(pos1, /, pos2, *, kwarg1, kwarg2="default"):
    print(f"Positional: {pos1}, {pos2}")
    print(f"Keyword: {kwarg1}, {kwarg2}")

# Aufruf
gemischte_funktion(1, 2, kwarg1="Hallo")
# Ausgabe:
# Positional: 1, 2
# Keyword: Hallo, default
```

In Java gibt es keine direkte Entsprechung für `/` und `*`, aber man kann überladene Methoden nutzen, um die Argumente zu beschränken.

---

### `*args` und `**kwargs`
- `*args` wird für eine variable Anzahl von positional arguments verwendet.
- `**kwargs` erlaubt eine variable Anzahl von Keyword arguments.

```python
def flexible_funktion(*args, **kwargs):
    print(f"Args: {args}")
    print(f"Kwargs: {kwargs}")

flexible_funktion(1, 2, 3, key1="Wert1", key2="Wert2")
# Ausgabe:
# Args: (1, 2, 3)
# Kwargs: {'key1': 'Wert1', 'key2': 'Wert2'}
```

#### Java-Äquivalent
Java unterstützt `*args`-ähnliche Funktionen mit `varargs`, jedoch gibt es keine direkte Entsprechung für `**kwargs`.

```java
public class FlexibleFunktion {
    public void flexibleFunktion(String... args) {
        for (String arg : args) {
            System.out.println(arg);
        }
    }

    public static void main(String[] args) {
        FlexibleFunktion flex = new FlexibleFunktion();
        flex.flexibleFunktion("Wert1", "Wert2", "Wert3");
        // Ausgabe:
        // Wert1
        // Wert2
        // Wert3
    }
}
```

---

## Rückgabetypen in Python
- In Python gibt es keine strikte Definition des Rückgabetyps.
- Funktionen können Werte beliebigen Typs zurückgeben oder auch nichts (`None`).

```python
def kein_rueckgabewert():
    print("Nur eine Ausgabe")

print(kein_rueckgabewert())  # Ausgabe: None

# Rückgabe mehrerer Werte
def mehrere_rueckgabewerte():
    return 1, 2, 3

x, y, z = mehrere_rueckgabewerte()
print(x, y, z)  # Ausgabe: 1 2 3
```

#### Java-Äquivalent
In Java müssen Methoden einen spezifischen Rückgabewert haben. Um mehrere Werte zurückzugeben, kann man eine Klasse verwenden:

```java
public class Rueckgabewerte {
    public void keinRueckgabewert() {
        System.out.println("Nur eine Ausgabe");
    }

    public int[] mehrereRueckgabewerte() {
        return new int[]{1, 2, 3};
    }

    public static void main(String[] args) {
        Rueckgabewerte rueck = new Rueckgabewerte();
        rueck.keinRueckgabewert();
        int[] werte = rueck.mehrereRueckgabewerte();
        System.out.println(werte[0] + " " + werte[1] + " " + werte[2]);
    }
}
```

---

### Listen-Split (Entpacken von Rückgabewerten in Python)
Python erlaubt es, Listen oder Tupel, die von einer Funktion zurückgegeben werden, direkt in Variablen zu entpacken:

```python
def get_list():
    return ["a", "b", "c"]

# Entpacken der Liste
x, y, z = get_list()
print(x, y, z)  # Ausgabe: a b c
```

#### Java-Äquivalent
In Java ist das Entpacken von Rückgabewerten nicht direkt möglich.
