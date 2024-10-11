## Übungen zu Basiskonzepten
Wir betrachten hier Aufgaben, welche folgende Themen umfassen:
* Primitive Datentypen und Variablen
* Einfache Operatoren (+, -, *, /, %, ^, &&, ||, ...)
* Einfache I/O-Befehle (Console.Write, Console.Read)
* Einfache Typumwandlungen
* Codeblöcke und Scope
* If-Verzweigung
* Switch-Anweisung
* Schleifen (ohne foreach)
* Visual Studio Code-Snippets (cw, if, etc.)
* using-Direktive/Namespaces
* var-Schlüsselwort
* Ternärer Operator 

## 1. Übung - Call by Value

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

## 2. Übung - Variablenumwandlung in C#

In dieser Übung arbeitest du mit verschiedenen Umwandlungsmethoden in C#. Die Aufgabe besteht darin, die Umwandlung von Variablen in unterschiedlichen Szenarien zu üben, einschließlich der Umwandlung von Zahlen zu Zahlen, Zeichenfolgen zu Zahlen und Zahlen zu Zeichenfolgen.

### Aufgabenstellung:

1. **Zahl zu Zahl:**
   - Erstelle eine Methode `ConvertIntToDouble(int number)`, die eine Ganzzahl als Eingabe erhält und diese in einen `double`-Wert umwandelt.
   - Erstelle eine Methode `ConvertDoubleToInt(double number)`, die einen `double`-Wert in eine Ganzzahl umwandelt.

2. **String zu Zahl:**
   - Erstelle eine Methode `ParseStringToInt(string str)`, die eine Zeichenfolge in eine Ganzzahl umwandelt.
   - Erstelle eine Methode `ParseStringToDouble(string str)`, die eine Zeichenfolge in einen `double`-Wert umwandelt.

3. **Zahl zu String:**
   - Erstelle eine Methode `ConvertIntToString(int number)`, die eine Ganzzahl in eine Zeichenfolge umwandelt.
   - Erstelle eine Methode `ConvertDoubleToString(double number)`, die einen `double`-Wert in eine Zeichenfolge umwandelt.

4. **Zusätzliche Umwandlungen (mit der `Convert`-Klasse):**
   - Verwende die `Convert`-Klasse, um andere Umwandlungen zu üben, wie z.B. die Umwandlung von `bool` zu `string` oder von `decimal` zu `double`.

### Aufgabe:

- Implementiere jede Methode in der Klasse `Converter`.
- Teste jede Methode, indem du verschiedene Werte eingibst und das Ergebnis in der Konsole ausgibst.

### Beispiel-Testcode:

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        Converter converter = new Converter();

        // Zahl zu Zahl Umwandlung
        Console.WriteLine(converter.ConvertIntToDouble(10));  // Ausgabe: 10.0
        Console.WriteLine(converter.ConvertDoubleToInt(10.5));  // Ausgabe: 10

        // String zu Zahl Umwandlung
        Console.WriteLine(converter.ParseStringToInt("123"));  // Ausgabe: 123
        Console.WriteLine(converter.ParseStringToDouble("123.45"));  // Ausgabe: 123.45

        // Zahl zu String Umwandlung
        Console.WriteLine(converter.ConvertIntToString(100));  // Ausgabe: "100"
        Console.WriteLine(converter.ConvertDoubleToString(99.99));  // Ausgabe: "99.99"

        // Zusätzliche Umwandlungen
        Console.WriteLine(converter.ConvertBoolToString(true));  // Ausgabe: "True"
        Console.WriteLine(converter.ConvertDecimalToDouble(99.99m));  // Ausgabe: 99.99
    }
}
```

### Erwartete Ausgabe:

```plaintext
10.0
10
123
123.45
100
99.99
True
99.99
```


## 3. Schachbrett und Linien.
* Erstelle ein Schachbrett mit den Dimensionen welche der User eingibt. Verwende dazu `Console.ReadLine` und wandle diesen String in eine Zahl um.
Ein Schachbrett soll als 2D-Array auf der Console dargestellt werden. Die Uni-Codes für schwarze und weiße Symbole sind `d` und `d`.
* Der User soll nun 2 Paare von `x` und `y` Koordinaten wählen, welche miteinander verbunden werden sollen. Markiere die Start- und Endpunkte mit einem `o` und `x`. Verwende für die Verbindung dieser Punkte den Zusammenhang `y=k*x+d` und `Δy/Δx=k`. Verwende für jede Zelle, welche als Teil der Linie von den oben genannten Zusammenhängen ausgewählt wird, das Symbol `*`.

Optional: Versuche wenn die Linie nach rechts oben bzw. links unten geht das Symbol `/`, links oben bzw. rechts unten, `\`, wenn diese "sehr steil" ist `|` und "sehr flach" `-` (oder such in der erweiterten ASCII Tabelle nach Symbolen). 

## 4. Muster kombinieren
siehe doc angabe

