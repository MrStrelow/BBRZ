# Generics
// addbeginning warum kein out of bounds error bei for i = _currentSize?

implementiere abstract class linked list welches den copy constructor von beiden linked lists implementiert.
Was fällt dire auf? auf einmal kommen komisce fehler. -> override schreiben vergesssen!

# Generics - Type #

Generics in C# ermöglichen flexibleren und wiederverwendbaren Code, indem man mit Typen auf typsichere Weise arbeitet, ohne den genauen Datentyp im Voraus festzulegen. Im Folgenden werden einige wichtige Konzepte der Generics anhand von Beispielen aus der `List`-Implementierung erläutert.

## Inhaltsverzeichnis

1. [Eigene generische Klassen schreiben](#eigene-generische-klassen-schreiben)
2. [Subtypen und Supertypen von generischen Klassen (Kovarianz und Kontravarianz)](#subtypen-und-supertypen-von-generischen-klassen)
3. [Generische Methoden in nicht-generischen Klassen](#generische-methoden-in-nicht-generischen-klassen)
4. [Kovarianz und Kontravarianz bei Methodenparametern](#Kovarianz und Kontravarianz bei Methodenparametern)

---

## Eigene generische Klassen schreiben

Beim Schreiben eigener generischer Klassen in C# können Sie **Constraints (Einschränkungen)** verwenden, um die Typen zu begrenzen, die als Argumente für generische Parameter verwendet werden können. Diese Einschränkungen helfen sicherzustellen, dass die verwendeten Typen bestimmte Eigenschaften besitzen, z. B. eine Referenztyp, ein Werttyp oder einen parameterlosen Konstruktor.

### Konzept: Einschränken mit `where T :`

- **Referenztyp-Einschränkung**: `where T : class`
  - Beschränkt `T` darauf, nur ein Referenztyp zu sein. Dies ist nützlich, wenn sichergestellt werden muss, dass der generische Typ eine Klasse ist (z. B. Strings, Objekte usw.).

- **Werttyp-Einschränkung**: `where T : struct`
  - Beschränkt `T` darauf, nur ein Werttyp zu sein (z. B. `int`, `float`, `DateTime`). Dies ist nützlich, wenn sichergestellt werden muss, dass der generische Typ ein primitiver oder ein Werttyp ist.

- **Konstruktor-Einschränkung**: `where T : new()`
  - Stellt sicher, dass `T` über einen parameterlosen Konstruktor verfügt. Dies ist nützlich, wenn innerhalb Ihrer generischen Klasse Objekte des Typs `T` instanziiert werden sollen.

#### Beispiel:

Wenn Sie eine generische `Liste` erstellen möchten, die nur Referenztypen erlaubt und sicherstellt, dass `T` einen parameterlosen Konstruktor hat, verwenden Sie:

```csharp
public class MyList<T> where T : class, new()
{
    private T[] _items;
    
    public MyList()
    {
        _items = new T[10];
    }
}
```


## Subtypen und Supertypen von generischen Klassen (Kovarianz und Kontravarianz)
### Kovarianz (out)
Kovarianz ermöglicht die Verwendung eines spezialisierteren Typs als ursprünglich angegeben. Bei generischen Schnittstellen und Delegaten wird Kovarianz mit dem Schlüsselwort out angewendet. Dies ist besonders nützlich bei Sammlungen, wenn Sie eine Liste abgeleiteter Typen übergeben möchten, wo eine Liste von Basistypen erwartet wird.

#### Beispiel: 
Wenn Sie eine Liste<Hund> haben, ermöglicht Kovarianz die Übergabe dieser Liste, wo eine Liste<Tier> erwartet wird, da Hund eine Unterklasse von Tier ist.
```csharp
public interface IList<out T> 
{ 
    T Get(int index);
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

### Wichtiger Unterschied: Arbeiten mit out und in
* Verwenden Sie out, wenn Ihr generischer Typ nur zurückgegeben wird (Output).
* Verwenden Sie in, wenn Ihr generischer Typ nur als Eingabe konsumiert wird (Input).

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

## TLDR;
Generics in C# bieten eine mächtige Möglichkeit, flexiblen, typsicheren und wiederverwendbaren Code zu schreiben. Durch die Kombination von generischen Klassen, Methoden und fortgeschrittenen Konzepten wie Kovarianz und Kontravarianz können Sie komplexe Szenarien auf eine saubere und effiziente Weise handhaben.

Verwenden Sie Constraints (where T :): um sicherzustellen, dass Ihre generischen Typen bestimmte Anforderungen erfüllen.
Nutzen Sie Kovarianz und Kontravarianz, um mit Subtypen und Supertypen in generischen Sammlungen zu arbeiten.
Definieren Sie generische Methoden in nicht-generischen Klassen, um flexiblen und wiederverwendbaren Code zu erstellen.

# Kovarianz und Kontravarianz bei Methodenparametern

In C# können Kovarianz und Kontravarianz auch bei **Methodenparametern** in generischen Schnittstellen und Delegaten verwendet werden. Sie ermöglichen es, Methoden so zu gestalten, dass sie flexibel mit Typenvererbung arbeiten, ohne die Typsicherheit zu verlieren.

### Theorie

- **Kovarianz** bedeutet, dass Sie einen spezialisierteren Typ (Untertyp) verwenden können, als ursprünglich angegeben wurde. Dies wird oft für **Ausgabewerte** verwendet, die von einer Methode zurückgegeben werden.

- **Kontravarianz** bedeutet, dass Sie einen allgemeineren Typ (Supertyp) verwenden können. Dies wird oft für **Eingabewerte** verwendet, die an eine Methode übergeben werden.

In C# wird Kovarianz mit dem Schlüsselwort `out` und Kontravarianz mit dem Schlüsselwort `in` verwendet. Diese Konzepte treten am häufigsten in generischen Schnittstellen und Delegaten auf.

### Implementierung in C#

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

## Zusammenfassung
- **Kovarianz** (`out T`) erlaubt es, einen spezialisierten Typ zu verwenden, wenn ein generischer Typ oder ein Rückgabewert spezifiziert ist.
- **Kontravarianz** (`in T`) erlaubt es, einen allgemeineren Typ zu verwenden, wenn ein generischer Typ oder ein Methodenparameter spezifiziert ist.

