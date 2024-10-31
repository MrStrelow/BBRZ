# Generics

Generics ermöglichen flexibleren und wiederverwendbaren Code, indem man mit Typen auf typsichere Weise arbeitet, ohne den genauen Datentyp im Voraus festzulegen. Im Folgenden werden einige wichtige Konzepte der Generics anhand von Beispielen aus der `List`-Implementierung erläutert.

## Inhaltsverzeichnis

1. [Wofür sind Generics gedacht?](#wofür-sind-generics-gedacht)
2. [Eigene generische Klassen schreiben](#eigene-generische-klassen-schreiben)
3. [Generische Methoden in nicht-generischen Klassen](#generische-methoden-in-nicht-generischen-klassen)
4. [Kovarianz und Kontravarianz bei Methodenparametern](#kovarianz-und-kontravarianz-bei-methodenparametern)
---

## Wofür sind Generics gedacht?

Generics in lösen mehrere objektorientierte Probleme, insbesondere in Bezug auf Code-Wiederverwendbarkeit, Typsicherheit und Performance. Hier ist eine Übersicht der wichtigsten OOP-Probleme, die sie adressieren:

1. **Typsicherheit**: Ohne Generics würde man `object` als Typ verwenden, um verschiedene Objekttypen zuzulassen. Dies führt jedoch zu häufigen Typkonvertierungen, die zu Laufzeitfehlern führen können, wenn die Konvertierung falsch ist. Generics sorgen für Typsicherheit, indem sie zur Kompilierzeit einen bestimmten Typ festlegen und Typfehler frühzeitig erkennen.

2. **Code-Wiederverwendbarkeit (Don't Repeat Yourself)**:  Generics ermöglichen die Erstellung von Code, der für jeden Datentyp funktioniert, und reduzieren so die Duplizierung. Statt mehrere Versionen von Methoden oder Klassen für verschiedene Datentypen zu erstellen, erstellt man eine einzige generische Implementierung. Das ist besonders nützlich bei Sammlungen (z. B. `List<T>`) und Algorithmen wie Sortier- oder Suchverfahren, die für verschiedene Typen anwendbar sind. 
Generizität ist also ein Tool um doppelten Code zu vermeiden. Es kann uns erlauben, lang verkettete Extendsbeziehungen zu vermeiden, welche meistens nicht dem Ersetzbarkeitsprinzip entsprechen.

3. **Vermeidung von Boxing/Unboxing**: Die Verwendung nicht-generischer Sammlungen (wie `ArrayList`) erfordert Boxing (das Einbetten eines Werttyps in ein `object`) und Unboxing (das Extrahieren des Werttyps aus einem `object`). Generics vermeiden diesen Overhead.

4. **Bessere Wartbarkeit**: Generics erleichtern die Wartung des Codes, da die Logik nur einmal implementiert wird. Wenn die Logik geändert werden muss, wird sie an einer Stelle geändert und gilt für alle Typen, die diese generische Klasse oder Methode verwenden.

Generics erlauben also **typsicheren und wiederverwendbaren  Code**, der OOP-Prinzipien wie Abstraktion und Polymorphie aufrechterhält, indem er mehrere Datentypen ohne Einbußen an Typsicherheit verarbeitet.

## Eigene generische Klassen schreiben

Beim Schreiben eigener generischer Klassen in C# können Sie **Constraints (Einschränkungen)** verwenden, um die Typen zu begrenzen, die als Argumente für generische Parameter verwendet werden können. Diese Einschränkungen helfen sicherzustellen, dass die verwendeten Typen bestimmte Eigenschaften besitzen, z. B. eine Referenztyp, ein Werttyp oder einen parameterlosen Konstruktor.

### Typparameter `T` Einschränken mit `where T :`

```csharp
public class MyList<T> where T : /Einschränkung/
{
    ...
}
```

- **Referenztyp-Einschränkung**: `where T : class`
  - Beschränkt `T` darauf, nur ein Referenztyp zu sein. Dies ist nützlich, wenn sichergestellt werden muss, dass der generische Typ eine Klasse ist (z. B. Strings, Objekte usw.).
  - Weiters ist es möglich eine spezifischen Referenztyp anzugeben. Wenn `T` das Interface IComparable implementieren muss, dann ist `where T : IComparable<T>` zu schreiben. Wenn hier nur `where T : IComparable` steht, hat es zur Folge, dass `public class Human : IComparable` implementieren muss, nicht `public class Human : IComparable<Human>`. Der Unterschied liegt dann in der Methode CompareTo. `IComparable` hat `public int CompareTo(Object other)` zur Folge und `IComparable<Human>` hat `public int CompareTo(Human other)` zur Folge.
  Meistens wird diese Art der Einschränkung von `T` verwendet.

- **Werttyp-Einschränkung**: `where T : struct`
  - Beschränkt `T` darauf, nur ein Werttyp zu sein (z. B. `int`, `float`, `DateTime`). Dies ist nützlich, wenn sichergestellt werden muss, dass der generische Typ ein primitiver oder ein Werttyp ist.

- **Konstruktor-Einschränkung**: `where T : new()`
  - Stellt sicher, dass `T` über einen parameterlosen Konstruktor verfügt. Dies ist nützlich, wenn innerhalb Ihrer generischen Klasse Objekte des Typs `T` instanziiert werden sollen. Ohne `where T : new()` kann also nicht `new T();` verwendet werden. Achtung! Die Einschränkung kann leider nicht spezifischer werden. Ein `new(T)` ist nicht möglich. Verwende ein Factory Entwicklungsmuster oder Schnittstellen welche eine `Create(T)` Methode besitzen, um mehr Flexibilität bei der Erstellung von Instanzen von T zu ermöglichen.

#### Beispiel:
Wenn Sie eine generische `Liste` erstellen möchten, die nur Referenztypen (z.B. Klassen) erlaubt und sicherstellt, dass `T` einen parameterlosen Konstruktor hat, verwenden Sie:
```csharp
public class MyArrayList<T> where T : class, new(T), new()
{
    private T[] _items;
    
    public MyList()
    {
        _items = new T[10]; // geht nur wenn new() oben steht
    }
}
```

## Subtypen und Supertypen von generischen Klassen (Kovarianz und Kontravarianz)
Wir haben das Problem, dass der Typ der Generische Klassen immer eine Kombination aus Name und Typparameter T ist. Das Bedeutet `List<Tier> tiere = new List<Hund>();` ist nicht möglich. Es steht links der Typ `List<Tier>`, welcher zusammen mit List und Tier der Typ ist. Dieser ist anders als, `List<Hund>`. Hier gelten keine Typbeziehungen von `Hund` und `Tier`. Wäre das nicht hätten wir Probleme mit Typsicherheit und dem Ersetzbarkeitsprinzip.

Es gibt jedoch unter bestimmten Einschränkungen folgende Möglichkeiten.

### Kovarianz (out)
Kovarianz ermöglicht die Verwendung eines spezialisierteren Typs als ursprünglich angegeben. Bei generischen Schnittstellen und Delegaten wird Kovarianz mit dem Schlüsselwort out angewendet. Dies ist besonders nützlich bei Sammlungen, wenn Sie eine Liste abgeleiteter Typen übergeben möchten, wo eine Liste von Basistypen erwartet wird.

#### Beispiel: 
Wenn Sie eine Liste<Hund> haben, ermöglicht Kovarianz die Übergabe dieser Liste, wo eine Liste<Tier> erwartet wird, da Hund eine Unterklasse von Tier ist.
```csharp
public interface IEnumerable<out T>
{
    T Get();
}

public class Tier { }

public class Hund : Tier { }

public class TierListe : IEnumerable<Hund>
{
    public Hund Get() => new Hund();
}

public static void Main(string[] args)
{
    IEnumerable<Tier> tiere = new TierListe(); // Kovarianz: Hund kann als Tier verwendet werden
    Tier tier = tiere.Get();
}
```

### Kontravarianz (in)
Kontravarianz ist das Gegenteil von Kovarianz. Sie ermöglicht die Verwendung eines allgemeineren Typs als ursprünglich angegeben. Kontravarianz wird mit dem Schlüsselwort in angewendet, oft in Delegaten, wo Sie einen allgemeineren Typ als Eingabe übergeben können.

#### Beispiel:
Wenn Sie eine Liste<Tier> haben, können Sie diese bei Methoden verwenden, die mit Liste<Hund> arbeiten, da Hund ein spezialisierter Typ von Tier ist.
```csharp
public interface IComparer<in T>
{
    int Compare(T x, T y);
}
```

* Verwenden Sie out, wenn Ihr generischer Typ nur zurückgegeben wird (Output).
* Verwenden Sie in, wenn Ihr generischer Typ nur als Eingabe konsumiert wird (Input).

### Anwendung in C#
#### Func<T> und Action<T> Delegates
- **Kovarianz** wird mit dem `Func<out TResult>`-Delegate verwendet, was es ermöglicht, eine Methode, die einen abgeleiteten Typ zurückgibt, einem `Func<Base>` zuzuweisen.
- **Kontravarianz** wird mit dem `Action<in T>`-Delegate verwendet, was es ermöglicht, eine Methode, die einen Basistyp akzeptiert, einem `Action<Derived>` zuzuweisen.

```csharp
  public class Base { }
  public class Derived : Base { }

  public void Beispiel()
  {
      // Kovarianz mit Func
      Func<Derived> getDerived = () => new Derived();
      Func<Base> getBase = getDerived; // Kovarianz

      // Kontravarianz mit Action
      Action<Base> processBase = (b) => { /* Basistyp verarbeiten */ };
      Action<Derived> processDerived = processBase; // hier is Kontravarianz
  }
```

#### LINQ
- LINQ-Methoden (wie `Select`, `Where` usw.) nutzen Kovarianz, um Abfragen von Collections zu ermöglichen. Zum Beispiel können Sie einen abgeleiteten Typ in einer LINQ-Abfrage verwenden, die erwartet, mit einem Basistyp zu arbeiten.

```csharp
  var dogs = new List<Dog> { new Dog() };
  IEnumerable<Animal> animals = dogs.Select(d => (Animal)d); 
  // Kovarianz hier bei List vs. IEnumerable
```

## Generische Methoden in nicht-generischen Klassen
C# ermöglicht es Ihnen, generische Methoden auch in nicht-generischen Klassen zu definieren. Das erlaubt es, Methoden zu erstellen, die flexibel und wiederverwendbar sind, ohne dass die Klasse selbst generisch sein muss.

### Beispiel-Anwendungsfälle   
#### Erstellen einer Listen-Fabrik: 
Sie könnten eine Methode haben, die eine Liste<T> erstellt und als generisches IMyList<T> zurückgibt. So können Sie Instanzen von MyArrayList oder LinkedRecursiveList erstellen und basierend auf Eingabeparametern zurückgeben. Durch die Verwendung von Generics in dieser Methode bleibt sie flexibel.
```csharp
public static IMyList<T> CreateList<T>() where T : class, new()
{
    return new MyArrayList<T>();
}
```

#### Generische Hilfsmethoden: 
Eine Utility-Klasse kann Methoden wie PrintArray<T> haben, die mit Arrays aller Typen arbeiten können. Diese Methoden hängen nicht davon ab, dass die Klasse selbst generisch ist.

```csharp
public class Utility
{
    public static void PrintArray<T>(T[] array)
    {
        foreach (var item in array)
        {
            Console.WriteLine(item);
        }
    }
}
```

# Kovarianz und Kontravarianz bei Methodenparametern

In C# können Kovarianz und Kontravarianz auch bei **Methodenparametern** in generischen Schnittstellen und Delegaten verwendet werden. Sie ermöglichen es, Methoden so zu gestalten, dass sie flexibel mit Typenvererbung arbeiten, ohne die Typsicherheit zu verlieren.

### Theorie

- **Kovarianz** bedeutet, dass Sie einen spezialisierteren Typ (Untertyp) verwenden können, als ursprünglich angegeben wurde. Dies wird oft für **Ausgabewerte** verwendet, die von einer Methode zurückgegeben werden.

- **Kontravarianz** bedeutet, dass Sie einen allgemeineren Typ (Supertyp) verwenden können. Dies wird oft für **Eingabewerte** verwendet, die an eine Methode übergeben werden.

In C# wird Kovarianz mit dem Schlüsselwort `out` und Kontravarianz mit dem Schlüsselwort `in` verwendet. Diese Konzepte treten am häufigsten in generischen Schnittstellen und Delegaten auf.

#### Kovarianz: Rückgabewerte in Methoden

Mit Kovarianz können Sie eine Methode definieren, die einen `Animal`-Typ zurückgibt, aber tatsächlich eine spezialisierte `Cat`-Klasse als Ergebnis zurückgeben kann. Dies ist nützlich, wenn Sie mit Sammlungen oder Schnittstellen arbeiten, die flexibler in der Typzuweisung sein müssen.

## Kovarianz: Rückgabewerte in Methoden
In diesem Beispiel wird ein Objekt vom Typ `ICovariant<Cat>` einer Variablen des Typs `ICovariant<Animal>` zugewiesen. Dies funktioniert, weil `Cat` ein Untertyp von `Animal` ist und die Schnittstelle kovariant (`out T`) ist.

**Beispiel:**

```csharp
public class Cat { }

public class CovariantCat : ICovariant<Cat>
{
    public Cat GetItem()
    {
        return new Cat();
    }
}

public class Animal { }

public void Example()
{
    ICovariant<Animal> animals = new CovariantCat();
    Animal animal = animals.GetItem(); // Dies funktioniert dank Kovarianz
}
```


## Kontravarianz: Eingabewerte in Methoden
Mit Kontravarianz können Sie eine Methode definieren, die einen `Cat`-Typ akzeptiert, aber auch eine allgemeinere `Animal`-Instanz verwenden kann.

### Beispiel:
```csharp
public interface IContravariant<in T>
{
    void SetItem(T item);
}

public class Animal { }

public class Cat : Animal { }

public class ContravariantAnimal : IContravariant<Animal>
{
    public void SetItem(Animal animal) 
    {
        // Verarbeitung eines Animals
    }
}

public void Example()
{
    IContravariant<Cat> cats = new ContravariantAnimal();
    cats.SetItem(new Cat()); // Dies funktioniert dank Kontravarianz
}
```

## Verwendung von Kovarianz und Kontravarianz in Delegaten
Delegaten profitieren ebenfalls von Kovarianz und Kontravarianz, insbesondere wenn es um Methoden mit unterschiedlichen Rückgabe- oder Eingabeparametern geht.

### Kovarianz in Delegaten
Ein Delegat, der eine Methode mit einem spezifischen Rückgabewert (`Cat`) beschreibt, kann an eine Methode mit einem allgemeineren Rückgabewert (`Animal`) zugewiesen werden.

#### Beispiel:
```csharp
public delegate Animal CovariantDelegate();

public Cat ReturnCat()
{
    return new Cat();
}

public void Example()
{
    CovariantDelegate del = ReturnCat;
    Animal result = del(); // Dies funktioniert dank Kovarianz
}
```

## Kontravarianz in Delegaten
Ein Delegat, der eine Methode mit einem spezifischen Parameter (`Animal`) beschreibt, kann an eine Methode mit einem spezialisierteren Parameter (`Cat`) zugewiesen werden.

### Beispiel:
```csharp
public delegate void ContravariantDelegate(Animal animal);

public void AcceptCat(Cat cat) 
{
    // Verarbeitung einer Cat
}

public void Example()
{
    ContravariantDelegate del = AcceptCat;
    del(new Animal()); // Dies funktioniert dank Kontravarianz
}
```

# Wildcards in Java vs. Kovarianz und Kontravarianz in C#
In Java ermöglichen Wildcards (z. B. `<?>`, `<? extends T>`, `<? super T>`) flexiblere Generics, indem sie unbekannte Typen oder Typbeschränkungen angeben. Sie werden häufig verwendet, wenn der exakte generische Typ nicht bekannt ist, was eine gewisse Flexibilität ermöglicht und gleichzeitig bestimmte Typbeschränkungen durchsetzt.

C# hat kein genaues Äquivalent zu den Wildcards in Java, aber es bietet eine ähnliche Funktionalität durch **Kovarianz** und **Kontravarianz** mithilfe der Schlüsselwörter `out` und `in`:

1. **Kovarianz** (`out`-Schlüsselwort): Erlaubt die Verwendung eines spezifischeren Typs als ursprünglich angegeben. Dies wird typischerweise in Situationen verwendet, in denen man nur einen generischen Typ **zurückgeben** oder **lesen** muss. Zum Beispiel ermöglicht `IEnumerable<out T>` in C#, dass man `IEnumerable<Derived>` einem `IEnumerable<Base>` zuweisen kann, wobei `Derived` eine Unterklasse von `Base` ist.

2. **Kontravarianz** (`in`-Schlüsselwort): Erlaubt die Verwendung eines allgemeineren Typs. Es ist nützlich, wenn man nur einen generischen Typ **übergeben** oder **schreiben** muss. Zum Beispiel ermöglicht `IComparer<in T>`, dass man `IComparer<Base>` einem `IComparer<Derived>` zuweisen kann, was eine breitere Palette von Vergleichen zulässt.

Hier ist ein Beispiel, das beide Konzepte in C# zeigt:

```csharp
// Kovarianz (mit 'out')
IEnumerable<string> strings = new List<string> { "Hello", "World" };
IEnumerable<object> objects = strings; // Gültig aufgrund der Kovarianz mit 'out'

// Kontravarianz (mit 'in')
Action<object> action = obj => Console.WriteLine(obj);
Action<string> stringAction = action; // Gültig aufgrund der Kontravarianz mit 'in'
```

## Vergleich von Wildcards mit Kovarianz/Kontravarianz

In Java könnte man Wildcards in einer Methode verwenden, um von einer Sammlung wie `List<? extends Number>` zu lesen, was jede Unterklasse von `Number` zulässt. In C# würde man dies durch ein kovariantes Interface wie `IEnumerable<out T>` erreichen. Ähnlich würde man für `List<? super Integer>` in Java (um jede Oberklasse von `Integer` zuzulassen) in C# Kontravarianz mit `in` verwenden.

### Zusammenfassung
- **Java-Wildcards (`<?>, <? extends T>, <? super T>`)**: Sie bieten flexible, beschränkte Typparameter zum Lesen, Schreiben oder beidem.
- **Kovarianz (`out`) und Kontravarianz (`in`) in C#**: Sie ermöglichen flexible Zuweisungen und fokussieren sich auf Read-Only (`out`) oder Write-Only (`in`) Szenarien.

Die Kovarianz und Kontravarianz in C# decken ähnliche Anwendungsfälle wie Java-Wildcards ab, sind jedoch durch die explizite Verwendung von `in` und `out` in generischen Schnittstellen und Delegaten deutlicher geregelt.


