Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Umgang mit vordefinierten methoden zur Umwandlung von Variablen
* type-casting

Welche ``Denkwweisen`` üben wir hier?
* keine

Bei Unklarheiten hier nachlesen:
* [wie wandle ich variablen um?](https://github.com/MrStrelow/BBRZ/blob/main/JET/modul_1_grundlagen/L02BasicProgrammingConcepts/L02BasicProgrammingConcepts/L02.1VariablenUmwandeln.md)

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
namespace Exercise2;
public class Program
{
    public static void Main(string[] args)
    {
        MyConverter converter = new MyConverter();

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

class MyConverter
{
    // Zahl zu Zahl: Int zu Double
    public double ConvertIntToDouble(int number)
    {
        // TODO: implementiere mich :)
    }

    // Zahl zu Zahl: Double zu Int
    public int ConvertDoubleToInt(double number)
    {
        // TODO:
    }

    // String zu Zahl: String zu Int - versuche hier TryPasre zu verwenden.
    public int ParseStringToInt(string str)
    {
        // TODO:
    }

    // String zu Zahl: String zu Double - versuche hier TryPasre zu verwenden.
    public double ParseStringToDouble(string str)
    {
        // TODO:
    }

    public string ConvertIntToString(int number)
    {
        // TODO:
    }

    public string ConvertDoubleToString(double number)
    {
        // TODO:
    }

    public string ConvertBoolToString(bool value)
    {
        // TODO:
    }

    public double ConvertDecimalToDouble(decimal number)
    {
        // TODO:
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