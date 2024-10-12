## 1. Übung - Argumente von Methoden: Call by Value oder Reference?

Erstelle eine Klasse namens `Calculator` mit den folgenden Methoden:
- `Add(int a, int b)`: Gibt die Summe von zwei Ganzzahlen zurück (Call by Value).
- `Multiply(int a, int b)`: Multipliziert zwei Ganzzahlen (Call by Reference).
- `Initialize(int result)`: Initialisiert die Ergebnisvariable auf 100 (Call by Reference).
- `Average(int firstNumber, int secondNumber, ...)`: Berechnet den Durchschnitt einer variablen Anzahl von Ganzzahlen (Params).

Erstelle nun ein Objekt von der Klasse `Calculator` und rufe die Methoden anhand von Beispielen auf.

Des weiten schreibe eine statische methode `static void destroyAndInitObject(Calculator calculator)` und rufe in der Main methode diese über call by reference auf. Ersetze das bestehende Objekt welches der Methode übergeben wurde mit einem neuen und manipuliere dieses durch call by reference.

Erstelle nun `static void pretendToDestroyAndInitObject(Calculator calculator)` mit call by value mit ansonsten der gleichen Implementierung wie `destroyAndInitObject`.

Gib dazwischen Ergebnisse aus und vergewissere dich, dass die call by value bzw. call by value Übergaben sinnvoll sind.

Schreibe nun eine statische methode `static void fiddleWithNumber(Calculator calculator)` und rufe in der Main methode diese über call by value auf. Setze dort `calculator.ergebnis = 5;`. Wird hier die Änderung außerhalb der Methode angenommen? Warum, wenn hier doch mit call by value gearbeitet wird?

### Beispiel - Testcode
```csharp
static void Main(string[] args)
{
    var calc = new Calculator();
    int ergebnis = calc.Add(2, 5);

    int a = 5;
    calc.Multiply(ref a, ref a);

    int b;
    calc.Initialize(out b);

    calc.Average(10, 10, 10);

    Console.WriteLine(calc.ergebnis);

    destroyAndInitObject(ref calc);
    Console.WriteLine(calc.ergebnis);

    calc.Add(a, a);
    pretendToDestroyAndInitObject(calc);
    Console.WriteLine(calc.ergebnis);

    fiddleWithNumber(calc);
    Console.WriteLine(calc.ergebnis);
}
```

### Erwartete Ausgabe:

```plaintext
10
0
50
5
```