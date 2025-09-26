Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Die ``Keywords`` ``ref`` und ``out``
* Erster Kontakt mit ``Try-Methoden`` im Vergleich zu ``Exceptions``

Welche ``Denkweisen`` üben wir hier?
* ``Parameter`` sind nicht gleich ``Argumente``
* Erster Kontakt der ``Wertdatensemantik``- bzw. ``Referenzdatensemantik``

Bei Unklarheiten hier nachlesen: 
* [Was ist Call By Value und Call By Reference?](../Skripten/L03.2CallByValueOrReference.md)
* [exceptions: der 1. Absatz um eine Exception werfen zu können ist notwendig.](../../../modul_3_fortgeschrittene-sprachkonzepte/L00Exceptions/Skripten/L00Exceptions.md)

## Projektstruktur
Erstelle für jede der folgenden ``Aufgaben`` jeweils ein ``Projekt``, welche sich alle in einer ``Solution`` (Projektmappe) befinden.
In einem Projekt kann nur *eine* ausführbare ``Klasse`` sein. Also nur ein ``Main-Methode`` oder ein ``Top-Level Statement``.

>Für VS: Erstelle dazu eine ``Solution``(Projektmappe) und in dieser ``Solution`` (Projektmappe), füge mit *Rechtsclick auf die Solution (![alt text](image.png)) -> Add (Hinzufügen) -> new Project (neues Projekt) mit Namen Aufgabe 1* ein neues ``Projekt`` in der bestehenden ``Solution`` ein. Wiederhole für Aufgabe 2, 3 und 4.

## Call by Value vs. Call by Reference

**Kurze Wiederholung**:
* ``Werttypen`` (`int`, `bool`, `struct`, etc.) werden standardmäßig **by value** übergeben. Das bedeutet, die Methode erhält eine Kopie der Daten. Referenztypen (`string`, `array`, `class`) werden durch ``call by reference`` übergeben (streng genommen`` call by copy reference`` aber das ist nicht wichtig und nur verwirrend), aber der Wert, der übergeben wird, ist die **Speicheradresse** (die Referenz) selbst. Mit dem `ref`-Schlüsselwort kann man erzwingen, dass auch Werttypen **by reference** übergeben werden.

* ``Arrays`` sind ``Referenztypen``. Wenn ein ``Array`` an eine ``Methode`` übergeben wird (**ohne ``keyword`` ``ref``**), wird die ``Referenz`` auf das ``Array`` übergeben. Was das genau bedeutet sehen wir in späteren Modulen. Änderungen an den Elementen des ``Arrays`` innerhalb der ``Methode`` sind daher auch außerhalb sichtbar. Dies nennt man einen ``Seiteneffekt``. Auch schon in den vorherigen Übungen ist mit dem ``Keyword`` ``out`` ein ``Seiteneffekt`` verwendet worden.

### Aufgabe 1: int und ref int als Parameter einer Methode
Schreibe zwei ``Methode`` *Altern*, welche beide zwei ``Parameter`` *aktuellesAlter* und *zaehleHinzu* haben. Der Unterschied ist jedoch eine ``Methode`` verwendet ``Call By Value`` die andere ``Call By Reference``.
Merke in Kommentaren an, was die Konsequenz der Übergabe der ``Variable`` *alter* als ``Argument`` unter Verwendung von ``Call By Value`` und ``Call By Reference`` ist.
Verwende dazu folgende Vorlage:
```csharp
class Program
{
    static void Main()
    {
        CallByValue();
        CallByReference();
    }

    static void CallByValue()
    {
        int alter = 10;
        int um = 13;
        Console.WriteLine($"Vor dem Aufruf: {alter}");
        ... // Rufe Altern auf
        Console.WriteLine($"Nach dem Aufruf: {alter}");
    }

    static void CallByReference()
    {
        int alter = 10;
        int um = 13;
        Console.WriteLine($"Vor dem Aufruf: {alter}");
        ... // Rufe Altern auf
        Console.WriteLine($"Nach dem Aufruf: {alter}");
    }

    ... // Methodensignatur für Call by Value von Altere mit Parameter aktuellesAlter und zaehleHinzu
    ... // Methodensignatur für Call By Reference von Altere mit Parameter aktuellesAlter und zaehleHinzu
}
```
---

### Aufgabe 2: Arrays und Seiteneffekte
Erstelle ein ``Array`` von ``int`` und rufe die ``Methode`` *ModifyArray* auf.
```csharp
class Program
{
    static void Main()
    {
        Console.WriteLine("--- Value Style ---");
        ArraySideEffectExampleValueStyle();
        Console.WriteLine("--- Reference Style ---");
        ArraySideEffectExampleReferenceStyle();
    }

    static void ArraySideEffectExampleValueStyle()
    {
        int[] numbers = { 10, 20, 30 };
        Console.WriteLine("Array vor dem Aufruf: " + string.Join(", ", numbers)); 

        ModifyArrayValueStyleStyle(numbers);

        Console.WriteLine("Array nach dem Aufruf: " + string.Join(", ", numbers)); 
    }

    static void ArraySideEffectExampleReferenceStyle()
    {
        int[] numbers = { 10, 20, 30 };
        Console.WriteLine("Array vor dem Aufruf: " + string.Join(", ", numbers)); 

        ModifyArrayReferenceStyle(numbers);

        Console.WriteLine("Array nach dem Aufruf: " + string.Join(", ", numbers)); 
    }

    static void ModifyArrayValueStyle(int[] arr)
    {
        // Kopiere arr in ein neues Array mit namen kopie.
        // Verwende dazu eine for - Schleife
        ...

        // manipuliere das neue Array
        if (kopie.Length > 0)
        {
            ...
        }
    }

    static void ModifyArrayReferenceStyle(int[] arr)
    {
        // Ändere ein Element des Arrays, jedoch kopiere zuerst alle elemente des Parameters arr.
        if (arr.Length > 0)
        {
            ...
        }
    }
}
```

---

## Die ``Methode`` *TryParse* und das ``Keyword`` *out*
**Kurze Wiederholung**:
Die *TryParse*-Methode ist ein klassisches Beispiel für die Verwendung von `out`-Parametern. `out` ist ähnlich wie `ref`, da es eine Variable by reference übergibt. Der Hauptunterschied ist, dass eine `out`-Variable nicht initialisiert sein muss, bevor sie übergeben wird. Das passiert gleichzeitg. Innerhalb von *TryPase* wird dann der ``Wert`` der ``Variable`` welche mit *out* gekennzeichnet wird belegt.

### Aufgabe 3 *TryParse* und ``Variablen`` des ``Typs`` *int*
Verwende die *TryParse* ``Methode`` um folgende Aufgabe zu lösen. Beachte die ``Kommentare`` und den ``Scope`` (den Block, also die ``{}``) der ``Variablen``.

```csharp
class Program
{
    static void Main()
    {
        Console.WriteLine("---- mit If ----");
        TryParseIntExampleIf();
        Console.WriteLine("---- mit If - und verwendung der out variable außerhalb des if ----");
        TryParseIntExampleIfMitVerwendungDerVariableAußerhalbDerIf();
        Console.WriteLine("---- mit While ----");
        TryParseIntExampleWhile();
        Console.WriteLine("---- mit While - und verwendung der out variable außerhalb der while ----");
        TryParseIntExampleWhileMitVerwendungDerVariableAußerhalbDerWhile();
    }

    static void TryParseIntExampleIf()
    {
        Console.WriteLine("Bitte gib dein Alter ein: ");
        string alterAlsString = ...

        if (...)
        {
            Console.WriteLine($"Parse erfolgreich: {aterAlsInt}");
        }
        else
        {
            //Console.WriteLine($"Geht das? {alterAlsInt}"); 
            Console.WriteLine($"Parse fehlgeschlagen.");
        }
        //Console.WriteLine($"Geht das? {alterAlsInt}");
    }

    static void TryParseIntExampleIfMitVerwendungDerVariableAußerhalbDerIf()
    {
        Console.WriteLine("Bitte gib dein Alter ein: ");
        string alterAlsString = ...

        int alterAlsInt;
        if (...)
        {
            Console.WriteLine($"Parse erfolgreich: {alterAlsInt}");
        }
        else
        {
            Console.WriteLine($"Parse von {alterAlsInt} fehlgeschlagen."); // was steht inalterAlsInt, wenn TyParse fehlschlägt?
        }

        Console.WriteLine($"Ah, der Scope der Variable {alterAlsInt}, ist nun in der gesamten Methode.");
    }

    static void TryParseIntExampleWhile()
    {
        Console.WriteLine("Bitte gib dein Alter ein: ");
        string alterAlsString = ...

        while (...)
        {
            Console.WriteLine($"Parse erfolgreich: {alterAlsInt}");
        }

        //Console.WriteLine($"Geht das? {alterAlsInt}");
    }

    static void TryParseIntExampleWhileMitVerwendungDerVariableAußerhalbDerWhile()
    {
        Console.WriteLine("Bitte gib dein Alter ein: ");
        string alterAlsString = ...

        int alterAlsInt;
        while (...)
        {
            Console.WriteLine($"Parse erfolgreich: {alterAlsInt}");
        }

        Console.WriteLine($"Ah, der Scope der Variable {alterAlsInt}, ist nun in der gesamten Methode.");
    }
```

### Aufgabe 4 - *TryParse* und ``Variablen`` des ``Typs`` *Enum*
Versuche nun mit ``Enum`` anstatt von int zu arbeiten.

```csharp
public enum Richtung
{
    North,
    East,
    West,
    South
}

class Program
{
    static void Main()
    {
        TryParseEnumExample();
    }
    static void TryParseEnumExample()
    {
        string input = "wESt";
        Richtung richtung;

        // Hinweis: Der zweite Parameter 'true' ignoriert Groß-/Kleinschreibung
        if (...) // wir wollen hier keinen int sondern einen Enum umwandeln!
        {
            Console.WriteLine($"Parse erfolgreich: Die Richtung ist {richtung}");
        }
        else
        {
            Console.WriteLine("Parse fehlgeschlagen.");
        }

        Console.WriteLine($"Wir können wieder {richtung} verwenden, da es außerhalb der If-Verzweigung definiert wurde.");
    }
}
```