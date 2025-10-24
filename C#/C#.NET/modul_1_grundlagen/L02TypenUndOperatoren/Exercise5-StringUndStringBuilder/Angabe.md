Welche ``Konzepte`` der Programmiersprache üben wir hier?
* immutability vs mutability
* Create, Read, Update, Delete (C.R.U.D)

Welche ``Denkweisen`` üben wir hier?
* What you see is NOT what you get! Strings *+=* vs StringBuilders Append manipuliert beides jedoch baut der Computer im Hintergrund was konzeptionell anderes.

Bei Unklarheiten hier nachlesen: 
* [Was ist der Unterschied zwischen String und StringBuilder? - mutability vs. immutability](../Skripten/L02.4StringBuilder.md.md)

## **Hinweis:**
Erstelle für jede Aufgabe eine Methode ``static void Aufgabe1`` und ``static void Aufgabe2`` und führe unter der ``Methodendefinition`` aus. Der Grund ist in einem ``Projekt`` darf nur ein ``ausführbares Programm`` sein (``main`` oder ``top-level statement``).

```csharp
static void Aufgabe1()
{
    // TODO: hier.
}

static void Aufgabe2()
{
    // TODO: hier.
}

Aufgabe1();
Aufgabe2();
```

## String vs. StringBuilder

### Aufgabe 1: Textbearbeitung mit C.R.U.D - Logik

Die Methoden eines `StringBuilder` stellen die Funktionalität der **C.R.U.D.** dar:
* **C (Create):** Erstellt neue Inhalte (`Append`, `Insert`).
* **R (Read):** Liest Inhalte (z. B. `ToString()`, hier nicht im Fokus).
* **U (Update):** Aktualisiert bestehende Inhalte (`Replace`, Indexer `[]`).
* **D (Delete):** Löscht Inhalte (`Remove`).

Führen die folgenden Schritte aus und kommentiere jede `StringBuilder`-Operation mit dem passenden CRUD-Kommentar (`// CRUD: C`, `// CRUD: U`, `// CRUD: D`).

Verwende die unten angegebene Vorlage um folgendes umzusetzen:
0)  **Vorbereitung:** Erstellen Sie aus der ``Variable`` *basisText* (mit ``Typ`` *String*) einen *Substring*, der mit "C# ist eine ..." beginnt, und initialisieren Sie damit Ihren `StringBuilder`.
1)  Entfernen Sie das Wort "langweilige".
2)  Fügen Sie an derselben Stelle das Wort "vielseitige" ein.
3)  Ersetzen Sie alle Vorkommen des Buchstabens 'e' durch 'E'.
4)  Ändern Sie das 'C' am Anfang zu einem 'c'.
5)  Hängen Sie den Satzteil " und C# macht Spaß!" dreimal an.
6)  Entfernen Sie die letzten 10 Zeichen des Ergebnisses.

```csharp
using System.Text;

string basisText = "Man sagt, C# ist eine langweilige Programmiersprache.";

// 1. Initialisieren Sie den StringBuilder mit einem Teilstring (ab Index 10).
// TODO: Code hier.

// 2. Entfernen Sie das Wort "langweilige" (10 Zeichen lang, startet bei Index 14).
// TODO: Code hier.

// 3. Fügen Sie an derselben Position das Wort "vielseitige" ein.
// TODO: Code hier.

// 4. Ersetzen Sie alle 'e' durch 'E'.
// TODO: Code hier.

// 5. Ändern Sie das erste Zeichen ('C') auf ein kleines 'c'.
// TODO: Code hier.

// 6. Hängen Sie " und C# macht Spaß!" dreimal an.
// TODO: Code hier.

// 7. Entfernen Sie die letzten 10 Zeichen.
// TODO: Code hier.

Console.WriteLine($"\nEndgültiges Ergebnis:\n{sb}");
```

### Erwarteter Output:
```
c# ist EinE viElsEitigE ProgrammiErspachE und C# macht Spaß! und C# macht Spaß! und C# m
```

### Aufgabe 2: Mutability vs. Immutability

1) Führe beide folgenden Code-Snippets aus. Notieren Sie die ausgegebene Zeit.
2) Warum ist die Version mit `string` so viel langsamer als die mit `StringBuilder`? Erklären das Konzept dahinter.

**Snippet 1: Mit `StringBuilder`**
```csharp
// mit dem Typ: StringBuilder
Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

StringBuilder resultStringBuilder = new StringBuilder();

for (int i = 0; i < 100000; i++)
{
    resultStringBuilder.Append("Hello ");
}

stopwatch.Stop();
Console.WriteLine("Mit StringBuilder: " + stopwatch.ElapsedMilliseconds + " ms");

// mit dem Typ: string
stopwatch = new Stopwatch();
stopwatch.Start();

string resultString = "";

for (int i = 0; i < 100000; i++)
{
    resultString += "Hello ";
}

stopwatch.Stop();
Console.WriteLine("Mit string: " + stopwatch.ElapsedMilliseconds + " ms");
```

### Erwarteter Output (nicht genau das, aber ca. so):
```
Mit StringBuilder: 1 ms
Mit string: 11126 ms
```