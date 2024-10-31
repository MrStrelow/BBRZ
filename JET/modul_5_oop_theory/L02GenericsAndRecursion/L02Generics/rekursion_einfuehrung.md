
# Einführung in die Rekursion

Rekursion ist eine Programmiertechnik, bei der eine Methode sich selbst aufruft, um ein Problem in kleinere Teilprobleme zu zerlegen. Rekursive Algorithmen bestehen in der Regel aus zwei Hauptteilen:
1. **Basisfall**: Der Fall, bei dem die Rekursion endet.
2. **Rekursiver Fall**: Der Fall, bei dem die Methode sich selbst aufruft.

## Einfaches Beispiel: Fakultät berechnen

Ein klassisches Beispiel für Rekursion ist die Berechnung der Fakultät einer Zahl.

### Definition der Fakultät:
Die Fakultät einer Zahl `n` (geschrieben als `n!`) ist das Produkt aller natürlichen Zahlen von 1 bis `n`. Sie kann rekursiv definiert werden als:
- `0! = 1` (Basisfall)
- `n! = n * (n - 1)!` (rekursiver Fall)

### Rekursiver Code:
```csharp
public class RekursionBeispiele
{
    public static int Fakultaet(int n)
    {
        if (n == 0) // Basisfall
        {
            return 1;
        }
        else
        {
            return n * Fakultaet(n - 1); // Rekursiver Fall
        }
    }

    public static void Main(string[] args)
    {
        int ergebnis = Fakultaet(5);
        Console.WriteLine("5! = " + ergebnis); // Ausgabe: 5! = 120
    }
}
```

## Konzepte der Rekursion

### 1. **Direkte Rekursion**
Bei der direkten Rekursion ruft eine Methode sich selbst auf. Dies haben wir im obigen Fakultätsbeispiel gesehen.

### 2. **Indirekte Rekursion**
Indirekte Rekursion liegt vor, wenn eine Methode nicht direkt sich selbst, sondern eine andere Methode aufruft, und diese wiederum die ursprüngliche Methode aufruft.

#### Beispiel:
```csharp
public class IndirekteRekursion
{
    public static void MethodeA(int n)
    {
        if (n > 0)
        {
            Console.WriteLine("MethodeA: " + n);
            MethodeB(n - 1); // Aufruf von MethodeB
        }
    }

    public static void MethodeB(int n)
    {
        if (n > 0)
        {
            Console.WriteLine("MethodeB: " + n);
            MethodeA(n - 1); // Aufruf von MethodeA
        }
    }

    public static void Main(string[] args)
    {
        MethodeA(5);
    }
}
```

Ein Ähnlicher Fall ist die Aufteilung in eine Rekursive Methode und eine nicht rekursive Methode welche z.B. basierend auf einer Vorgabe eines Interfaces implementiert wird.
```csharp
public interface IMyList<T> : IEnumerable<T>
{
    void AddEnd(T element);
}

public class LinkedRecursiveList<T> : LinkedList<T>, IEnumerable<T>
{
    public override void AddEnd(T element)
    {
        Head = AddEndRecursive(Head, element);
    }

    private Node<T> AddEndRecursive(Node<T>? node, T element)
    {
        if (node == null)
            return new Node<T>(element);

        node.Next = AddEndRecursive(node.Next, element);
        return node;
    }
}
```


### 3. **Tail Recursion**
Bei der Tail Recursion wird der rekursive Aufruf als letzte Operation in der Methode ausgeführt, ohne dass danach noch eine weitere Aktion durchgeführt wird. Dies hat den Vorteil, dass der Compiler die Rekursion in eine Schleife umwandeln kann, was Speicher spart.

#### Beispiel:
```csharp
public class Schwanzrekursion
{
    public static int FakultaetTailRec(int n, int ergebnis = 1)
    {
        if (n == 0) // Basisfall
        {
            return ergebnis;
        }
        else
        {
            return FakultaetTailRec(n - 1, ergebnis * n); // Rekursiver Fall
        }
    }

    public static void Main(string[] args)
    {
        int ergebnis = FakultaetTailRec(5);
        Console.WriteLine("5! = " + ergebnis); // Ausgabe: 5! = 120
    }
}
```

### 4. **Rekursion mit mehreren Aufrufen**
In manchen rekursiven Algorithmen ruft eine Methode sich selbst mehrfach auf. Dies wird oft bei der Lösung von Baumstrukturen oder in der Berechnung der Fibonacci-Zahlen verwendet.

#### Beispiel: Fibonacci-Zahlen
Die Fibonacci-Zahlenfolge wird definiert als:
- `F(0) = 0`
- `F(1) = 1`
- `F(n) = F(n - 1) + F(n - 2)` für `n > 1`

Rekursiver Code:
```csharp
public class FibonacciRekursion
{
    public static int Fibonacci(int n)
    {
        if (n == 0) return 0; // Basisfall
        if (n == 1) return 1; // Basisfall
        return Fibonacci(n - 1) + Fibonacci(n - 2); // Rekursiver Fall
    }

    public static void Main(string[] args)
    {
        int ergebnis = Fibonacci(6);
        Console.WriteLine("F(6) = " + ergebnis); // Ausgabe: F(6) = 8
    }
}

class FibonacciRekursionTail
{
    static void Main(string[] args)
    {
        int n = 10; 
        Console.WriteLine(FibonacciTail(n, 0, 1)); // Ausgabe: 55
    }

    static int FibonacciTail(int n, int a, int b)
    {
        if (n == 0) return a;
        if (n == 1) return b;
        return FibonacciTail(n - 1, b, a + b); // Tail Call
    }
}
```

## Wann sollte Rekursion verwendet werden?

Rekursion eignet sich besonders gut für Probleme, die sich auf natürliche Weise in kleinere Teilprobleme zerlegen lassen, wie z.B.:
- Durchsuchen von Baumstrukturen (z.B. binäre Bäume)
- Sortieralgorithmen wie QuickSort und MergeSort
- Berechnungen wie Fakultäten und Fibonacci-Zahlen

## Rekursion vs. Iteration

Obwohl Rekursion elegant und verständlich ist, kann sie in manchen Fällen ineffizient sein, da jeder rekursive Aufruf Speicher im Call-Stack benötigt. Iterative Lösungen können Speicherprobleme umgehen, da sie keine zusätzlichen Aufrufe erzeugen.

#### Beispiel: Fakultät iterativ
```csharp
public class IterativeFakultaet
{
    public static int FakultaetIterativ(int n)
    {
        int ergebnis = 1;
        for (int i = 1; i <= n; i++)
        {
            ergebnis *= i;
        }
        return ergebnis;
    }

    public static void Main(string[] args)
    {
        int ergebnis = FakultaetIterativ(5);
        Console.WriteLine("5! = " + ergebnis); // Ausgabe: 5! = 120
    }
}
```
