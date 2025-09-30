### Abstrakte Klassen
### Interfaces



Ein UML-Klassendiagramm hilft, die Beziehungen zwischen Klassen zu modellieren:

- **Ist-Beziehung**: Wird in C# mit Vererbung umgesetzt. Eine Subklasse "ist" ein Typ der Basisklasse.
- **Hat-Beziehung**: Wird durch Felder oder Eigenschaften umgesetzt, die auf andere Klassen zeigen.

/**
 * UML-Klassendiagramme definieren:
 * - Welche Klassen existieren.
 * - Wie Klassen miteinander interagieren (z. B. Ist- oder Hat-Beziehungen).
 *
 * Beispiel für ein UML-Diagramm:
 * - Ein "Hundebesitzer" hat Hunde (Hat-Beziehung).
 * - Ein "Schäferhund" ist ein Hund (Ist-Beziehung).
 */

- **Kardinalitäten**: UML unterscheidet verschiedene Typen von Hat-Beziehungen, z. B.:
  - 1 zu 1: Ein Hund hat einen Besitzer und umgekehrt.
  - 1 zu n: Ein Hundebesitzer kann mehrere Hunde haben, aber ein Hund hat genau einen Besitzer.

In C# werden diese Kardinalitäten durch Datenstrukturen wie Arrays oder Listen modelliert.

---







# Abstrakte Klassen und Interfaces

/**
 * - **Abstrakte Klassen** definieren allgemeines Verhalten und können nicht direkt instanziiert werden.
 * - **Interfaces** legen fest, welche Methoden eine Klasse implementieren muss.
 */

## Beispiel: Abstrakte Klasse `Tier`

```csharp
public abstract class Tier
{
    private string _name;

    protected Tier(string name)
    {
        _name = name;
    }

    public string Name => _name;

    public abstract void MakeSound();
}
```

/**
 * Die abstrakte Klasse `Tier` definiert ein gemeinsames Verhalten für alle Tiere.
 * - Abgeleitete Klassen müssen die Methode `MakeSound` implementieren.
 */

## Beispiel: Interface `ILebewesen`

```csharp
public interface ILebewesen
{
    void Atmen();
    void Bewegen();
}
```

/**
 * Interfaces definieren nur die Struktur. Sie enthalten keine Implementierungen.
 * Klassen können mehrere Interfaces implementieren.
 */

---