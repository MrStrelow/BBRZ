# Kontrollstrukturen - Java vs. Python 

## 1. **If-Bedingung**
### Java:
```java
if (bedingung) {
    // Code Block
}
```

### Python:
```python
if bedingung:
    # Code Block
```

**Unterschiede**:
- In Java muss die Bedingung immer in Klammern gesetzt werden, während in Python keine Klammern benötigt werden. Der Codeblock in Python wird durch Einrückung (Whitespace) gesteuert.

## 2. **If-Verzweigung**
### Java:
```java
if (bedingung) {
    // Code Block
} else {
    // Code Block
}
```

### Python:
```python
if bedingung:
    # Code Block
else:
    # Code Block
```

**Unterschiede**:
- Auch hier wird in Java `else` mit Klammern verwendet, während Python nur Einrückung verwendet.

## 3. **Else-if (Mehrfachverzweigung)**
### Java:
```java
if (bedingung1) {
    // Code Block
} else if (bedingung2) {
    // Code Block
} else {
    // Code Block
}
```

### Python:
```python
if bedingung1:
    # Code Block
elif bedingung2:
    # Code Block
else:
    # Code Block
```

**Unterschiede**:
- In Java verwenden wir `else if` für die Verzweigung, während in Python das Schlüsselwort `elif` genutzt wird.

## 4. **Switch-Statement**
### Java:
```java
switch (variable) {
    case wert1:
        // Code Block
        break;
    case wert2:
        // Code Block
        break;
    default:
        // Code Block
}
```

### Python:
```python
# In Python gibt es kein direktes "switch", aber man kann `if`-Bedingungen verwenden:
if variable == wert1:
    # Code Block
elif variable == wert2:
    # Code Block
else:
    # Code Block
```

**Unterschiede**:
- Java hat das `switch`-Statement nativ, Python hingegen nicht. In Python wird häufig eine `if`-Verkettung genutzt.

## 5. **While-Schleife**
### Java:
```java
while (bedingung) {
    // Code Block
}
```

### Python:
```python
while bedingung:
    # Code Block
```

**Unterschiede**:
- In Java wird `while` mit Klammern geschrieben, in Python ohne.

## 6. **Do-While-Schleife**
### Java:
```java
do {
    // Code Block
} while (bedingung);
```

### Python:
```python
# Python hat keine native do-while Schleife, aber man kann eine Endlosschleife verwenden:
while True:
    # Code Block
    if not bedingung:
        break
```

**Unterschiede**:
- Python bietet keine `do-while` Schleife, aber sie kann mit einer `while True` Schleife nachgebildet werden.

## 7. **For-Schleife**
### Java:
```java
for (int i = 0; i < 10; i++) {
    // Code Block
}
```

### Python:
```python
for i in range(10):
    # Code Block
```

**Unterschiede**:
- In Java muss der Schleifenindex explizit deklariert werden, während Python dies intern mit `range()` erledigt.

## 8. **For-Each-Schleife**
### Java:
```java
for (Typ element : liste) {
    // Code Block
}
```

### Python:
```python
for element in liste:
    # Code Block
```

**Unterschiede**:
- Die Syntax ist sehr ähnlich, aber in Python wird einfach `in` anstelle von `:` verwendet.


## List/Dicitonary Comphrehention
# List- und Dictionary-Comprehensions in Python vs. Java

## Was sind Comprehensions in Python?

Comprehensions in Python sind eine elegante und kompakte Möglichkeit, Listen, Sets und Dictionaries zu erstellen. Sie ermöglichen es, eine Sammlung basierend auf einer vorhandenen Sammlung zu erstellen, indem man eine Ausdrucks- und Filterlogik in einer einzigen Zeile anwendet.

### 1. **List Comprehension**

List-Comprehension ist eine Möglichkeit, eine neue Liste zu erstellen, indem man eine Ausdruckslogik auf jede Iteration einer bestehenden Liste anwendet.

#### Beispiel: Quadrieren der Zahlen von 1 bis 5

```python
# Python List Comprehension
numbers = [1, 2, 3, 4, 5]
squares = [x ** 2 for x in numbers]
print(squares)  # Output: [1, 4, 9, 16, 25]
```
Hier wird die Liste squares mit den Quadrierungen der Zahlen von der Liste numbers erstellt.

### Äquivalent in Java
In Java gibt es keine direkte Entsprechung zu List-Comprehensions, aber wir können eine ähnliche Funktionalität mit Streams und Lambdas erreichen.
import java.util.List;
import java.util.stream.Collectors;
```java
public class Main {
    public static void main(String[] args) {
        List<Integer> numbers = List.of(1, 2, 3, 4, 5);
        List<Integer> squares = numbers.stream()
                                       .map(x -> x * x)
                                       .collect(Collectors.toList());
        System.out.println(squares);  // Output: [1, 4, 9, 16, 25]
    }
}
```
In Java verwenden wir Streams und die map-Funktion, um eine Transformation auf die Liste anzuwenden.

## 2. Dictionary Comprehension
Dictionary Comprehension wird verwendet, um ein Dictionary basierend auf einer bestehenden Sammlung zu erstellen, wobei Schlüssel-Wert-Paare generiert werden.

Beispiel: Erstellen eines Dictionaries mit Quadraten der Zahlen

```python
# Python Dictionary Comprehension
numbers = [1, 2, 3, 4, 5]
squares_dict = {x: x ** 2 for x in numbers}
print(squares_dict)  # Output: {1: 1, 2: 4, 3: 9, 4: 16, 5: 25}
```

Hier wird ein Dictionary erstellt, bei dem die Schlüssel die Zahlen aus der Liste sind und die Werte die Quadrierungen dieser Zahlen.

### Äquivalent in Java
In Java gibt es keine eingebaute Syntax für Dictionary Comprehensions. Stattdessen verwenden wir einen Map und Streams.
```java
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

public class Main {
    public static void main(String[] args) {
        List<Integer> numbers = List.of(1, 2, 3, 4, 5);
        Map<Integer, Integer> squaresMap = numbers.stream()
                                                  .collect(Collectors.toMap(x -> x, x -> x * x));
        System.out.println(squaresMap);  // Output: {1=1, 2=4, 3=9, 4=16, 5=25}
    }
}
```
In Java verwenden wir die Collectors.toMap-Methode, um eine Map zu erstellen, wobei der erste Parameter den Schlüssel und der zweite den Wert angibt.

## Nützliche Methoden in Python:

### 1. **zip**
Die `zip`-Funktion kombiniert mehrere Iterierbare und gibt Tupel zurück, die die Elemente aus den Iterierbaren paarweise enthalten.

### Beispiel:
```python
liste1 = [1, 2, 3]
liste2 = ['a', 'b', 'c']
result = zip(liste1, liste2)
print(list(result))  # [(1, 'a'), (2, 'b'), (3, 'c')]
```

### 2. **enumerate**
Die `enumerate`-Funktion gibt jedes Element einer Liste zusammen mit seinem Index zurück.

### Beispiel:
```python
liste = ['a', 'b', 'c']
for index, value in enumerate(liste):
    print(index, value)
# Ausgabe: 0 a, 1 b, 2 c
```
### 3. **sorted**
Die `sorted`-Funktion gibt eine sortierte Kopie einer Liste zurück.

### Beispiel:
```python
liste = [3, 1, 4, 1, 5, 9]
sorted_liste = sorted(liste)
print(sorted_liste)  # [1, 1, 3, 4, 5, 9]
```

### 4. **all und any**
- `all()` gibt `True` zurück, wenn alle Elemente eines Iterierbaren `True` sind.
- `any()` gibt `True` zurück, wenn mindestens ein Element eines Iterierbaren `True` ist.

### Beispiel:
```python
liste = [True, True, False]
print(all(liste))  # False
print(any(liste))  # True
```