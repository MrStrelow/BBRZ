# Datenstrukturen in Python und Java

## Listen

### Python

Python bietet einen eingebauten Listentyp, der dynamisch ist und heterogene Elemente speichern kann. Listen sind veränderbar und unterstützen verschiedene Operationen wie Anhängen, Entfernen und Slicing.

```python
# Erstellen einer Liste
my_list = [1, 2, 3, "hello", 4.5]

# Elemente hinzufügen
my_list.append(6)

# Liste erweitern
my_list.extend([7, 8, 9])

# Einfügen eines Elements an einer bestimmten Position
my_list.insert(2, "inserted")

# Entfernen von Elementen
my_list.remove(3)

# Entfernen eines Elements nach Index und Erhalten des Wertes
popped_value = my_list.pop(1)

# Index eines Elements finden
index = my_list.index("hello")

# Vorkommen zählen
count = my_list.count(4.5)

# Liste sortieren
numbers = [3, 1, 4, 1, 5, 9]
numbers.sort()

# Liste umkehren
numbers.reverse()

# Kopieren einer Liste
copy_list = my_list.copy()

# Liste leeren
my_list.clear()

# Mitgliedschaft prüfen
print(4.5 in my_list)  # Ausgabe: True
```

### Java

In Java werden Listen mit der Klasse `ArrayList` oder `LinkedList` aus dem Paket `java.util` implementiert. Listen in Java sind veränderbar, erfordern jedoch explizite Typdeklarationen.

```java
import java.util.*;

public class ListExample {
    public static void main(String[] args) {
        List<Object> myList = new ArrayList<>();
        myList.add(1);
        myList.add("hello");
        myList.add(4.5);

        // Elemente hinzufügen
        myList.add(6);

        // Liste erweitern (Hinzufügen mehrerer Elemente)
        myList.addAll(Arrays.asList(7, 8, 9));

        // Einfügen eines Elements an einer bestimmten Position
        myList.add(2, "inserted");

        // Entfernen von Elementen
        myList.remove((Object) 1);

        // Entfernen eines Elements nach Index und Erhalten des Wertes
        Object poppedValue = myList.remove(1);

        // Index eines Elements finden
        int index = myList.indexOf("hello");

        // Vorkommen zählen (Nicht eingebaut, erfordert Iteration)
        long count = myList.stream().filter(e -> e.equals(4.5)).count();

        // Liste sortieren (Nur für Comparable-Typen)
        List<Integer> numbers = Arrays.asList(3, 1, 4, 1, 5, 9);
        Collections.sort(numbers);

        // Liste umkehren
        Collections.reverse(numbers);

        // Kopieren einer Liste
        List<Object> copyList = new ArrayList<>(myList);

        // Liste leeren
        myList.clear();

        // Mitgliedschaft prüfen
        System.out.println(myList.contains(4.5)); // Ausgabe: true
    }
}
```

---

## Stacks und Queues

### Python

Python bietet eingebaute Unterstützung für Stacks und Queues durch Listen und das Modul `collections.deque`. Hier ist das Modul deque verwendet, welches eine Queue und einen Stack gleichzeitg darstellt (Double Ended Queue). Wir können durch anwenden von deque() nun popleft verwenden.

```python
frocollections import deque

# Stack-Implementierung mit Liste
stack = []
stack.append(1)
stack.append(2)
stack.append(3)
print(stack.pop())  # Ausgabe: 3

# Queue-Implementierung mit deque
queue = deque()
queue.append(1)
queue.append(2)
queue.append(3)
print(queue.popleft())  # Ausgabe: 1
```

### Java

Java stellt `Stack` und `Queue` über `java.util` bereit. Es ist auch hier in JAVA die Deque Klasse zu verwenden welches ebenfalls eine Double Ended Queue ist und somit Queue und Stack verhalten in einem darstellt.

```java
import java.util.*;

public class StackQueueExample {
    public static void main(String[] args) {
        Stack<Integer> stack = new Stack<>();
        stack.push(1);
        stack.push(2);
        stack.push(3);
        System.out.println(stack.pop()); // Ausgabe: 3

        Queue<Integer> queue = new LinkedList<>();
        queue.add(1);
        queue.add(2);
        queue.add(3);
        System.out.println(queue.poll()); // Ausgabe: 1
    }
}
```

---

## Tupel

### Python

Tupel sind unveränderliche Listen und werden in runden Klammern definiert.

```python
my_tuple = (1, 2, 3, "hello")
print(my_tuple[1])  # Ausgabe: 2
```

### Verwendung von Tupeln

- **Tupel** sollten verwendet werden, wenn die Werte nicht verändert werden sollen.
- **Listen** sind besser geeignet, wenn Elemente hinzugefügt oder entfernt werden müssen.

---

## Dictionaries

### Python

Das eingebaute `dict`-Typ in Python implementiert eine Hash-Tabelle zur Speicherung von Schlüssel-Wert-Paaren.
Das bedeutet die `Schlüssel` müssen `hashable` sein. Im prinzip sind das alle `immutable` Datentypen, wie `int`, `tuple`, `str`, `frozenset`usw.

```python
# Valid dictionary keys
my_dict = {
    42: "integer",
    3.14: "float",
    "key": "string",
    (1, 2): "tuple",
    frozenset([1, 2]): "frozenset"
}

# Invalid dictionary keys (will raise TypeError)
my_dict = {
    [1, 2, 3]: "list",   # Lists are mutable and not hashable
    {1, 2, 3}: "set"     # Sets are mutable and not hashable
}
```


```python
my_dict = {"a": 1, "b": 2, "c": 3}
print(my_dict["a"])  # Ausgabe: 1

# Eintrag hinzufügen
my_dict["d"] = 4

# Eintrag entfernen
my_dict.pop("b")
```

### Java

Java stellt mit `HashMap` eine vergleichbare Struktur bereit.

```java
import java.util.*;

public class DictExample {
    public static void main(String[] args) {
        Map<String, Integer> myMap = new HashMap<>();
        myMap.put("a", 1);
        myMap.put("b", 2);
        myMap.put("c", 3);
        System.out.println(myMap.get("a")); // Ausgabe: 1

        // Eintrag hinzufügen
        myMap.put("d", 4);

        // Eintrag entfernen
        myMap.remove("b");
    }
}
```

---

## Default Dictionaries

```python
from collections import defaultdict

# Using str as the factory function
def no():
  return "no"

str_defaultdict = defaultdict(no)
print(str_defaultdict)
print(str_defaultdict['greedting'])
print(str_defaultdict)
```

```python
from collections import defaultdict

# Using str as the factory function
str_defaultdict = defaultdict(lambda: "no")
print(str_defaultdict)
print(str_defaultdict['greedting'])
print(str_defaultdict)
```

### String als Schlüssel
```python
from collections import defaultdict

# Using str as the factory function
str_defaultdict = defaultdict(str)
str_defaultdict['greeting'] = 'Hello'
print(str_defaultdict)
```

### int als Schlüssel
```python
from collections import defaultdict
 
# Defining the dict
d = defaultdict(int)
 
L = [1, 2, 3, 4, 2, 4, 1, 2]
 
# Iterate through the list
# for keeping the count
for i in L:
     
    # The default value is 0
    # so there is no need to 
    # enter the key first
    d[i] += 1
     
print(d)
```

### liste als Value

```python
from collections import defaultdict

# Defining a dict
d = defaultdict(list)

for i in range(5):
    d[i].append(i)
    
print("Dictionary with values as list:")
print(d)
```

---

## Geordnete Dictionaries

### Python

Python bietet mit `OrderedDict` aus dem Modul `collections` eine Möglichkeit, die Einfügereihenfolge beizubehalten.

```python
from collections import OrderedDict

ordered_dict = OrderedDict()
ordered_dict['a'] = 1
ordered_dict['b'] = 2
ordered_dict['c'] = 3
print(ordered_dict)  # Ausgabe: OrderedDict([('a', 1), ('b', 2), ('c', 3)])
```

### Java

Java verwendet `LinkedHashMap`, um die Einfügereihenfolge zu bewahren.
Weites kann eine `TreeMap` verwendet werden um schnell rauszufinden ob ein Schlüssel existiert.

```java
import java.util.*;

public class OrderedDictExample {
    public static void main(String[] args) {
        Map<String, Integer> orderedMap = new LinkedHashMap<>();
        orderedMap.put("a", 1);
        orderedMap.put("b", 2);
        orderedMap.put("c", 3);
        System.out.println(orderedMap);
    }
}
```

###

