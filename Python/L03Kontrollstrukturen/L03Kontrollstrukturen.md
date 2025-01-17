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

### 3. **map**
Die `map`-Funktion wendet eine Funktion auf jedes Element eines Iterierbaren an und gibt einen Iterator zurück.

### Beispiel:
```python
liste = [1, 2, 3]
result = map(lambda x: x * 2, liste)
print(list(result))  # [2, 4, 6]
```

### 4. **filter**
Die `filter`-Funktion filtert Elemente aus einer Liste basierend auf einer Bedingung.

### Beispiel:
```python
liste = [1, 2, 3, 4, 5]
result = filter(lambda x: x % 2 == 0, liste)
print(list(result))  # [2, 4]
```

### 5. **sorted**
Die `sorted`-Funktion gibt eine sortierte Kopie einer Liste zurück.

### Beispiel:
```python
liste = [3, 1, 4, 1, 5, 9]
sorted_liste = sorted(liste)
print(sorted_liste)  # [1, 1, 3, 4, 5, 9]
```

### 6. **all und any**
- `all()` gibt `True` zurück, wenn alle Elemente eines Iterierbaren `True` sind.
- `any()` gibt `True` zurück, wenn mindestens ein Element eines Iterierbaren `True` ist.

### Beispiel:
```python
liste = [True, True, False]
print(all(liste))  # False
print(any(liste))  # True
```

## Fazit
- In Java sind Kontrollstrukturen wie `switch` und `do-while` nativ verfügbar, während Python alternative Methoden oder Konstrukte verwendet.
- Python bietet nützliche Funktionen wie `zip`, `enumerate`, `map`, `filter` und `sorted`, die in vielen Fällen den Code vereinfachen und lesbarer machen.
