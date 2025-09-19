# Programmieraufgabe: Bubble-Sort
Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Operatoren anwenden
* Variablen anlegen
* Konstrollstrukturen wie Beding-Anweisungen und Schleifen anwenden

Welche ``Denkweisen`` üben wir hier?
* Algorithmisches Denken.

Bei Unklarheiten hier nachlesen: 
* [Wie lege ich Solutions und Projects an?]()
* [Wie arbeite ich mit Git?](https://github.com/MrStrelow/BBRZ/blob/main/JET/modul_1_grundlagen/L02TypenOperatoren/Skripten/L02.1Operatoren.md)

## Was ist Bubble Sort?
![Bubble Sort Animation](https://upload.wikimedia.org/wikipedia/commons/c/c8/Bubble-sort-example-300px.gif)

---

## Aufgabe 1 - Projekt erstellen
Erstelle eine neue C# Konsolenanwendung in Visual Studio oder mit der .NET CLI. Siehe dazu 

## Aufgabe 2. - Daten vorbereiten
Lege in deiner `Program.cs` ein unsortiertes Array von Integer-Zahlen an, das wir sortieren werden.

```csharp
int[] zahlen = { 64, 34, 25, 12, 22, 11, 90 };
```

### 3. Algorithmus implementieren
Implementiere den Bubble-Sort-Algorithmus. Du benötigst dazu **zwei verschachtelte Schleifen** und eine **Bedingte Anweisung**:

* **Äußere Schleife:** Diese Schleife ist für die "Durchläufe" zuständig. Nach jedem vollständigen Durchlauf ist garantiert, dass das größte Element des unsortierten Teils am richtigen Platz ist. Sie muss also `n-1` mal laufen, wobei `n` die Anzahl der Elemente im Array ist.

* **Innere Schleife und Bedingte Anweisung:** Diese Schleife führt die Vergleiche der benachbarten Elemente (`zahlen[i]` und `zahlen[i+1]`) durch. Wenn die Elemente in der falschen Reihenfolge sind, müssen sie getauscht werden.

**Tipp zum Tauschen von zwei Werten:** Du benötigst eine temporäre Hilfsvariable.

### 4. Ausgabe
Gib den Zustand des Arrays **vor** dem Sortieren und **nach** dem Sortieren auf der Konsole aus. Um das Array ansprechend darzustellen, kannst du `string.Join(", ", array)` verwenden.

---

## Erwartete Ausgabe

Wenn dein Programm korrekt funktioniert, sollte die Konsolenausgabe wie folgt aussehen:

```text
Unsortiertes Array:
[64, 34, 25, 12, 22, 11, 90]

Zustand nach Durchlauf 1: [34, 25, 12, 22, 11, 64, 90]
Zustand nach Durchlauf 2: [25, 12, 22, 11, 34, 64, 90]
Zustand nach Durchlauf 3: [12, 22, 11, 25, 34, 64, 90]
Zustand nach Durchlauf 4: [12, 11, 22, 25, 34, 64, 90]
Zustand nach Durchlauf 5: [11, 12, 22, 25, 34, 64, 90]
Zustand nach Durchlauf 6: [11, 12, 22, 25, 34, 64, 90]

Sortiertes Array:
[11, 12, 22, 25, 34, 64, 90]
```

## Bonusaufgabe (Optional)

Der oben beschriebene Bubble Sort macht immer alle `n-1` Durchläufe, auch wenn das Array schon vorher sortiert ist. Optimiere den Algorithmus, indem du nach jedem Durchlauf der äußeren Schleife prüfst, ob in der inneren Schleife überhaupt Tauschvorgänge stattgefunden haben. Wenn in einem kompletten Durchlauf nichts getauscht wurde, ist das Array bereits sortiert, und der Algorithmus kann vorzeitig beendet werden.

**Tipp:** Du benötigst eine `bool`-Variable (z.B. `wurdeGetaucht`), die du vor jeder inneren Schleife zurücksetzt und nur dann auf `true` setzt, wenn ein Tausch stattfindet.