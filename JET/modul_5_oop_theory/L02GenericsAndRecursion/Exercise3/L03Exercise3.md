# Aufgabenstellung

# TODO: objekt coupling und class cohesion einbauen mit add auf verschiedene interfaces aufteilen.

## 1.1) Listen

- Implementiere eine **Linked List** und einen **Knoten**. Implementiere dies entweder rekursiv, ``void a(){ a() }``, oder iterativ mit schleifen.
  - **Linked List**: Eine Linked List ist eine Datenstruktur, die aus einer Reihe von Knoten besteht, wobei jeder Knoten auf den nächsten Knoten in der Liste verweist. Sie ermöglicht das dynamische Hinzufügen und Entfernen von Elementen und ist effizient beim Umgang mit großen Mengen von Daten, da sie keinen festen Speicherplatz benötigt.

  - **Konten**: Ein Konten speicher die übergebenen Daten und kennt seinen Nachbarknoten mit namen Next. Durch aufruf von Knoten current = current.Next, kann somit durch die gesamte Liste angeschaut werden.

- Implementiere eine **Array List**.
  - **Array List**: Eine Array List ist eine dynamische Array-Datenstruktur, die es ermöglicht, Elemente in einem zusammenhängenden Speicherbereich zu speichern. Sie bietet eine schnelle Zugriffsgeschwindigkeit auf Elemente über ihren Index, kann jedoch bei Hinzufügungen und Löschungen von Elementen ineffizient sein, da bei Bedarf das Array möglicherweise neu dimensioniert werden muss.

  Folgendes Interface ist hier gegeben was unsere **IMyList** darstellt
  ```csharp
    public interface IMyList<T> : IEnumerable<T>
    {
        // gib mir ein element an der Position zurück. Fehlerbehandlung bedenken.
        T Get(int position); 

        // füge ein element am anfang der liste hinzu
        void AddEnd(T element);

        // füge ien element am ende der liste hinzu
        void AddBeginning(T element);

        // ersetze ein bestehendes elment an einer position, mit einem anderen.
        void Update(int position, T element);

        // suche ein element und gib das erste passende (equals) element zurück. (Optional: alle - schwer T so zu gestalten dass liste<T> und T als rückgabe akzeptiert wird) 
        (T foundElement, int index) Find(T element);

        // suche ein element und entferne es. (Optional: suche alle elemente, welche equal sind und entferne alle diese)
        void Remove(T element);
    }
  ```

## 1.2) Sortierte Listen
- Eine sich selbst sortierende Liste soll nun erstellt werden. Diese soll nur Typen akzeptieren welche das Interface `IComparable` implementieren. 
  - Ein **Comparator** ist ein Objekt, das eine Methode definiert, um zwei Objekte zu vergleichen und eine Reihenfolge zwischen ihnen zu bestimmen. Er wird häufig verwendet, um benutzerdefinierte Sortierlogik bereitzustellen. In C# wird das `IComparable`-Interface verwendet, um das Vergleichen von Objekten zu ermöglichen. Ein Typ, der `IComparable` implementiert, muss die `CompareTo`-Methode definieren, die zwei Objekte vergleicht und einen Wert zurückgibt, der angibt, ob das aktuelle Objekt kleiner, gleich oder größer als das andere ist.

## 2.1)
- Vresuche den foldneden Code von Co- und Kontravarianz anhand von **Tierschutzheimen** bzw. **Tierlieferanten** zu verstehen, und begründe warum dieser Funktioniert (ist es Kontra oder Kovarianz?). Es fehlt im Code unten die zuweisung der Varianzen. Füge diese hinzu.

### Informationen dazu:

**Kontravarianz:**  
In der realen Welt kannst du immer ein Tierschutzheim für Tiere anstelle eines Tierschutzheims für Kaninchen verwenden, weil jedes Mal, wenn ein Tierschutzheim ein Kaninchen beherbergt, es ein Tier ist. Wenn du jedoch ein Kaninchenheim anstelle eines Tierschutzheims verwendest, können die Mitarbeiter von einem Tiger gefressen werden.

**Kovarianz:**  
In der realen Welt kannst du immer einen Lieferanten für Kaninchen anstelle eines Lieferanten für Tiere verwenden, weil du jedes Mal, wenn ein Kaninchenlieferant dir ein Kaninchen gibt, ein Tier bekommst. Wenn du jedoch einen Tierlieferanten anstelle eines Kaninchenlieferanten verwendest, kannst du von einem Tiger gefressen werden.

Insgesamt ist dies nur eine zur Kompilierzeit überprüfbare Zusicherung von dir, dass du einen generischen Typ auf eine bestimmte Weise behandelst, um die Typensicherheit zu gewährleisten und niemanden gefressen zu bekommen.

Code: 
```csharp
public interface ISupply<T>
{
    T Get();
}

public interface IShelter<T>
{
    void Host(T thing);
}

public class Supply
{
    public class Animal { }
    public class Rabbit : Animal { }

    public void NoCompileErrors()
    {
        ISupply<Animal> animals = null; // hier wäre eine implementierung aber so gehts auch
        ISupply<Rabbit> rabbits = null; // hier wäre eine implementierung aber so gehts auch

        animals = rabbits; 
    }
}

public class Shelter
{
    public class Animal { }
    public class Rabbit : Animal { }

    public void NoCompileErrors()
    {
        IShelter<Animal> animals = null; // hier wäre eine implementierung aber so gehts auch
        IShelter<Rabbit> rabbits = null; // hier wäre eine implementierung aber so gehts auch

        rabbits = animals;
    }
}
```