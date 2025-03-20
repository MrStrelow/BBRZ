Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Schleifen
* Verzweigungen
* 2D-Arrays (Multidimensional Arrays)
* User-Input
* Operatoren
* Methoden (Arrays als Argument in Methoden - Call By Reference/Value)
* StringBuilder (Ersetzen von allen gleichen Symbolen in einem String)

Welche ``Denkwweisen`` üben wir hier?
* Wie löse wir ``kleinere Teile`` eines ``großen Problems`` und ``kombiniere`` diese?
* Wie gehe ich mit einer Mathematischen Funktion im Programmieren um (lineare Funktion, Steigung)?

Bei Unklarheiten hier nachlesen:
* [java vs. c#](https://github.com/MrStrelow/BBRZ/blob/main/JET/modul_1_c%23_basics/L02BasicProgrammingConcepts/L02BasicProgrammingConcepts/L02.0C%23_vs_Java_Syntax.md)

## 4. Aus Dreiecken 📐 werden Diamanten 💠
Generiere ``Formen``, welche vom ``User gewählt`` werden, sowie die benötigten Parameter der Formen. 

Verwende dazu folgende Methoden welche alle in einer `ausführbaren Klasse` sich befinden (Klasse mit einer `Main` Methode):
* static string[,] DrawTriangle(string[,] field, string symbol): zeichnet die [Basisform](#basisform) in ein 2d-Array.
* static string[,] MirrorX(string[,] field): spiegle ein 2d-Array um die x-Achse.
* static string[,] MirrorY(string[,] field): spiegle ein 2d-Array um die y-Achse.

Versuche mit `MirrorY`, `MirrorX` und `DrawTriangle` alle 4 Fälle Teile des [Diamanten](#zusammengesetzte-formen) darzustellen.
Verwende nun:
* static string[,] CombineForm(String[,] container, String[,] part, Position position): um die 4 Teile des Diamanten zusammenzufügen.

Für spätere Aufgaben, wie [Steigung der Formen](#steigung-der-formen) und [Muster der Formen](#muster-der-formen) sind folgende Methoden hilfreich:
* ``static string[,] Transpose(string[,] field)``: hier vertausche zeilen und spalten eines 2d-Arrays.

* ``static string[,] Rotate(string[,] field)``: verwende `Transpose(MirrorX(field));` um das umzusetzten.

* ``static string[,] DrawPattern(string[,] field, int n, string fillForm, string newFillForm)``: Diese Methode zeichnet jede `nte` Zeile ein neues Symbol in die gesamte Zeile. Für spaltenweises zeichnen verwende vorher die Methode `drehen` und führe danach `DrawPattern` aus. Danach drehe es wieder zurück (also so oft, bis es wieder gleich wie am Anfang ist).

* ``static string[,] DrawTriangle(string[,] field, string symbol, double slope)``: hier erzeuge ein neues 2d-Array. Die größe ist durch die Steigung `slope` auszurechnen. Danach zeichne die linie ein welche durch $y=k*x$ gegeben ist. Fülle alles was links von dem symbol der line ist mit diesem aus.

Hilfsmethoden:
* ``static void Print(string[,] field)``: Gibt ein 2d-Array aus. Es soll die 1. Dimension in der `y Achse` und die 2. Dimension in der `x Achse` der Konsole sichbar sein (also nicht alles in eine Zeile schreiben).

* ``static string[,] FillCanvas(string[,] field, string symbol)``: Befüllt ein 2d-Array komplett mit einem Symbol.
* ``static string[,] Copy(string[,] field)``: Kopiert den Parameter field in ein neues 2d-Array und gibt es zurück. Das ist nicht zwingend notwendig, jedoch denke an [call by value vs reference](https://github.com/MrStrelow/BBRZ/blob/main/JET/modul_1_c%23_basics/L02BasicProgrammingConcepts/L02BasicProgrammingConcepts/L02.2CallByValueOrReference.md)


Zuerst gibt der User an, welche Form generiert wird. Die Eingabe des Users soll der Name der Form sein. Diese sind:
* Dreieck (rechtwinklig, gleichschenklig)
* Raute (Diamant)

`Weitere Spezifikationen` nach der Wahl der Form folgen danach:
* **Für die Form `Dreieck`:**
  * Rechter Winkel ist `links-unten, rechts-unten, links-oben, rechts-oben`
  * Höhe des Dreiecks: User-Eingabe (z. B. `6`). Die Höhe ist hier die Anzahl der `Zeilen`.
* **Für die Form `Raute (Diamant)`:**
  * Halbe Diagonale der Raute: User-Eingabe (z. B. `6` erzeugt eine Raute mit `12 Zeilen`).
* **Für `alle` Formen:**
  * Hintergrundsymbol: User-Eingabe (z. B. `"◽"`)
  * Symbol der Form: User-Eingabe (z. B. `"🔷"`)
  * Muster der Formen: Siehe [Muster der Formen](#muster-der-formen).
  * Steigung der Formen: Siehe [Steigung der Formen](#steigung-der-formen).

---

### Basisform
``Dreieck - links-unten``
```
🔷◽◽◽◽◽
🔷🔷◽◽◽◽
🔷🔷🔷◽◽◽
🔷🔷🔷🔷◽◽
🔷🔷🔷🔷🔷◽
🔷🔷🔷🔷🔷🔷
```

### Basisform um 90° gedreht
``Dreieck - links-oben``
```
🔷🔷🔷🔷🔷🔷
🔷🔷🔷🔷🔷◽
🔷🔷🔷🔷◽◽
🔷🔷🔷◽◽◽
🔷🔷◽◽◽◽
🔷◽◽◽◽◽
```

### Basisform um 180° gedreht
``Dreieck - rechts-oben``
```
🔷🔷🔷🔷🔷🔷
◽🔷🔷🔷🔷🔷
◽◽🔷🔷🔷🔷
◽◽◽🔷🔷🔷
◽◽◽◽🔷🔷
◽◽◽◽◽🔷
```

### Basisform um 270° gedreht
``Dreieck - rechts-unten``
```
◽◽◽◽◽🔷
◽◽◽◽🔷🔷
◽◽◽🔷🔷🔷
◽◽🔷🔷🔷🔷
◽🔷🔷🔷🔷🔷
🔷🔷🔷🔷🔷🔷
```

### Zusammengesetzte Formen
``Raute (Diamond)``
```
◽◽◽◽◽🔷🔷◽◽◽◽◽
◽◽◽◽🔷🔷🔷🔷◽◽◽◽
◽◽◽🔷🔷🔷🔷🔷🔷◽◽◽
◽◽🔷🔷🔷🔷🔷🔷🔷🔷◽◽
◽🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷◽
🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷
🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷
◽🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷◽
◽◽🔷🔷🔷🔷🔷🔷🔷🔷◽◽
◽◽◽🔷🔷🔷🔷🔷🔷◽◽◽
◽◽◽◽🔷🔷🔷🔷◽◽◽◽
◽◽◽◽◽🔷🔷◽◽◽◽◽
```

### Muster der Formen 
Es soll dem User möglich sein, ein "Muster" für die Formen angeben zu können. Das bedeutet der User soll, z.B. "jede 2. Zeile" die gezeichneten Symbole mit ``🔸`` ausgetauschen können. Es kann aber auch jede 3., 4. oder sonstige ``Zeile`` oder ``Spalte`` ausgetauscht werden sein. ``Hinweis``: Löse zuerst das Problem für die Zeilen. Danach überlege wie kannst du den Code für das Austauschen der Zeilen für die Spalten verwenden? Welche Methoden haben wir bereits geschrieben?
``` 
Jede 2. Zeile
◽◽◽◽◽🔸🔸◽◽◽◽◽
◽◽◽◽🔷🔷🔷🔷◽◽◽◽
◽◽◽🔸🔸🔸🔸🔸🔸◽◽◽
◽◽🔷🔷🔷🔷🔷🔷🔷🔷◽◽
◽🔸🔸🔸🔸🔸🔸🔸🔸🔸🔸◽
🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷
🔸🔸🔸🔸🔸🔸🔸🔸🔸🔸🔸🔸
◽🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷◽
◽◽🔸🔸🔸🔸🔸🔸🔸🔸◽◽
◽◽◽🔷🔷🔷🔷🔷🔷◽◽◽
◽◽◽◽🔸🔸🔸🔸◽◽◽◽
◽◽◽◽◽🔷🔷◽◽◽◽◽
```

``` 
Jede 4. Zeile
◽◽◽◽◽🔸🔸◽◽◽◽◽
◽◽◽◽🔷🔷🔷🔷◽◽◽◽
◽◽◽🔷🔷🔷🔷🔷🔷◽◽◽
◽◽🔷🔷🔷🔷🔷🔷🔷🔷◽◽
◽🔸🔸🔸🔸🔸🔸🔸🔸🔸🔸◽
🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷
🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷
◽🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷◽
◽◽🔸🔸🔸🔸🔸🔸🔸🔸◽◽
◽◽◽🔷🔷🔷🔷🔷🔷◽◽◽
◽◽◽◽🔷🔷🔷🔷◽◽◽◽
◽◽◽◽◽🔷🔷◽◽◽◽◽
```

``` 
Jede 3. Spalte
◽◽◽◽◽🔷🔸◽◽◽◽◽
◽◽◽◽🔷🔷🔸🔷◽◽◽◽
◽◽◽🔸🔷🔷🔸🔷🔷◽◽◽
◽◽🔷🔸🔷🔷🔸🔷🔷🔸◽◽
◽🔷🔷🔸🔷🔷🔸🔷🔷🔸🔷◽
🔸🔷🔷🔸🔷🔷🔸🔷🔷🔸🔷🔷
🔸🔷🔷🔸🔷🔷🔸🔷🔷🔸🔷🔷
◽🔷🔷🔸🔷🔷🔸🔷🔷🔸🔷◽
◽◽🔷🔸🔷🔷🔸🔷🔷🔸◽◽
◽◽◽🔸🔷🔷🔸🔷🔷◽◽◽
◽◽◽◽🔷🔷🔸🔷◽◽◽◽
◽◽◽◽◽🔷🔸◽◽◽◽◽
```

### Steigung der Formen
Hier soll durch die Eingabe der ``Steigung`` gesteuert werden wie "spitz" das generierte Muster ist.

#### Ein Beispiel
* Steigung $1$ bedeutet dass $\frac{\Delta y}{\Delta x}=k=1$. ``y`` bedeutet hier die vertikale (Zeilen) und ``x`` die horizontale (Spalten). Lösen Sie zuerst das Problem mit Steigung kleiner als $1$ und danach größer als $1$. 
* ``Achtung!`` Da die Anzahl der Zeilen (y Achse) vom User fixiert ist, müssen solange die Schritte in x gegangen werden, bis diese Anzahl an Zeilen erreicht ist!
* Wählen Sie frei ob sie, wenn die Steigung nicht genau dargestellt werden kann floor, ceiling oder round verwenden. Dies beeinflusst das generierte Muster, sie sind jedoch alle richtig. Es wird ``ceiling`` empfohlen, da hier am wenigsten auf ``Randbedingungen`` aufgepasst werden muss.

Hier ein Beispiel zur Steigung $\frac{\Delta y}{\Delta x}=k=0.67=\frac{2}{3}$ und ein möglicher Lösungsversuch:
* Stellen Sie sich auf die linke Ecke, und gehen Sie einen Schritt nach rechts. Die Koordinate $x=1$. Wir gehen hier nach rechts weiter. Wenn wir wissen wollen welches Feld in $y$ von der Linie berührt wird, wenn wir einen Schritt nach rechts gehen (\Delta x=1), sagt uns $y=k \cdot x$ eben dieses Feld. $\frac{\Delta y}{\Delta x}=k$ wissen wir durch die Eingabe des Users. Dieser sagt uns z.B. ``k=0.67``.

* ``x`` und ``y`` ist die Position eines Arrays. Also $0.67*1=0.67$. Bedeutet gerundet $x=1$ und $y=1$. 
Für $x=2$  $y=0.67*2=1.33$ und gerundet $y=1$. Wenn wir das weiter machen, haben wir

| x◽◽◽| 1◽◽◽ | 2◽◽◽ | 3◽◽◽ | 4◽◽◽ | 5◽◽◽ | 6◽◽◽ | 7◽◽◽ | 8◽◽◽ | 9◽◽◽ |
| --- | ---- | ---- | ---- | ---- | ---- | ---- | ---- | ---- | ---- |
| y◽◽◽| 0.67 | 1.33 | 2◽◽◽ | 2.67 | 3.33 | 4◽◽◽ | 4.67 | 5.33 | 6◽◽◽ |
| runden | 1◽◽◽ | 1◽◽◽ | 2◽◽◽ | 3◽◽◽ | 3◽◽◽ | 4◽◽◽ | 5◽◽◽ | 5◽◽◽ | 6◽◽◽ |

 Wir haben also in der letzten Reihe 9 Symbole und 6 Symbole als höhe, was wieder $\frac{\Delta y}{\Delta x}=k=\frac{6}{9}$ ergibt. Folgendes Muster entsteht dadurch.


```
🔷🔷◽◽◽◽◽◽◽
◽◽🔷◽◽◽◽◽◽
◽◽◽🔷🔷◽◽◽◽
◽◽◽◽◽🔷◽◽◽
◽◽◽◽◽◽🔷🔷◽
◽◽◽◽◽◽◽◽🔷
```

Verwende ein 2d-Array um diese Linie anzulegen. Danach suche das Symbol ‚🔷‘ in jeder Zeile und fülle nach rechts auf.
Verwende ein 2d-Array um diese Linie anzulegen. Danach suche das Symbol ‚🔷‘ in jeder Zeile und fülle nach rechts auf.
```
🔷🔷◽◽◽◽◽◽◽
🔷🔷🔷◽◽◽◽◽◽
🔷🔷🔷🔷🔷◽◽◽◽
🔷🔷🔷🔷🔷🔷◽◽◽
🔷🔷🔷🔷🔷🔷🔷🔷◽
🔷🔷🔷🔷🔷🔷🔷🔷🔷
```

Für kompliziertere Fomren, wie die Raute, teile das Problem in 4 kleinere Probleme (das wir und gerade angeschaut haben ist eines davon) und füge diese danach zusammen. Also
```
◽◽◽◽◽◽◽🔷🔷
◽◽◽◽◽◽🔷🔷🔷
◽◽◽◽🔷🔷🔷🔷🔷
◽◽◽🔷🔷🔷🔷🔷🔷
◽🔷🔷🔷🔷🔷🔷🔷🔷
🔷🔷🔷🔷🔷🔷🔷🔷🔷

🔷🔷🔷🔷🔷🔷🔷🔷🔷
◽🔷🔷🔷🔷🔷🔷🔷🔷
◽◽◽🔷🔷🔷🔷🔷🔷
◽◽◽◽🔷🔷🔷🔷🔷
◽◽◽◽◽◽🔷🔷🔷
◽◽◽◽◽◽◽🔷🔷

🔷🔷◽◽◽◽◽◽◽
🔷🔷🔷◽◽◽◽◽◽
🔷🔷🔷🔷🔷◽◽◽◽
🔷🔷🔷🔷🔷🔷◽◽◽
🔷🔷🔷🔷🔷🔷🔷🔷◽
🔷🔷🔷🔷🔷🔷🔷🔷🔷

🔷🔷🔷🔷🔷🔷🔷🔷🔷
🔷🔷🔷🔷🔷🔷🔷🔷◽
🔷🔷🔷🔷🔷🔷◽◽◽
🔷🔷🔷🔷🔷◽◽◽◽
🔷🔷🔷◽◽◽◽◽◽
🔷🔷◽◽◽◽◽◽◽
```

Ergibt zusammengefügt
```
◽◽◽◽◽◽◽🔷🔷🔷🔷◽◽◽◽◽◽◽
◽◽◽◽◽◽🔷🔷🔷🔷🔷🔷◽◽◽◽◽◽
◽◽◽◽🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷◽◽◽◽
◽◽◽🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷◽◽◽
◽🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷◽
🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷
🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷
◽🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷◽
◽◽◽🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷◽◽◽
◽◽◽◽🔷🔷🔷🔷🔷🔷🔷🔷🔷🔷◽◽◽◽
◽◽◽◽◽◽🔷🔷🔷🔷🔷🔷◽◽◽◽◽◽
◽◽◽◽◽◽◽🔷🔷🔷🔷◽◽◽◽◽◽◽
```
