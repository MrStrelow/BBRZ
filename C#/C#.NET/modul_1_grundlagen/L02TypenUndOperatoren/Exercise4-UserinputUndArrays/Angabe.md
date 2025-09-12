# Variablenumwandlung
Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Umgang mit vordefinierten methoden zur Umwandlung von Variablen
* Userinput auf der Console

Welche ``Denkwweisen`` üben wir hier?
* Umgang mit Mathematischen Formeln

Bei Unklarheiten hier nachlesen:
* [wie wandle ich variablen um?](../Skripten/L02.3VariablenUmwandeln.md)
* [wie gehe ich mit Arrays um?](../../L04Collections/Skripten/L04.0JaggedUndMultidimensionalArrays.md)

## Aufgabe: Schachbrett-Koordinaten
Wir wollen auf einem Schachbrett zwei Punkte angeben, die einen Zug darstellen sollen. Deine Aufgabe ist es, die Distanz zwischen diesen Punkten zu berechnen und auszugeben.

1.  Verwende `Console.ReadLine()`, um eine ganze Zeile einzulesen.
2.  Trenne den eingelesenen `string` in die x- und y-Koordinaten auf und wandle diese in `int`-Werte um.

**Anforderungen:**

* Verwende `userInputAlsString.Split()`, um den vom Benutzer eingegebenen `string` in zwei Teile aufzutrennen.
    * Folgende Trennzeichen sollen erlaubt sein: ` ` (Leerschlag), `/`, `-`, `🧱`, oder `🔺`.
    * Du kannst ein Array von Trennzeichen definieren und an die `Split`-Methode übergeben: `string[] trennzeichen = { " ", "/", "-", "🧱", "🔺" };`
    * Weise das Ergebnis von `Split` einer Variable zu: `string[] mehrereKoordinaten = userInputAlsString.Split(trennzeichen, StringSplitOptions.RemoveEmptyEntries);`. Das Ergebnis, `mehrereKoordinaten`, ist ein Array, in dem die x- und y-Koordinaten als Text gespeichert sind.
* Wandle nun die x- und y-Koordinaten in `int`-Werte um.
    * Verwende dazu `int.Parse()`. Die x-Koordinate findest du mit `mehrereKoordinaten[0]` und die y-Koordinate mit `mehrereKoordinaten[1]`.
* Verwende für die Distanzberechnung folgende Formel: $\sqrt{(x_\text{end} - x_\text{start})^2 + (y_\text{end} - y_\text{start})^2}$.
    * Nutze für die Umsetzung in C# `Math.Sqrt()` für die Wurzel ($\sqrt{}$) und `Math.Pow(basis, exponent)` für die Potenz ($x^2$).
* Die berechnete Distanz soll auf zwei Nachkommastellen gerundet und im deutschen Zahlenformat (mit `,` als Dezimaltrennzeichen) ausgegeben werden.
    * Erstelle dafür eine `CultureInfo` für Deutschland: `new CultureInfo("de-DE")`.
    * Formatiere die Zahl mit `distanz.ToString("F2", new CultureInfo("de-DE"))`.

**Beispielhafter Programmablauf:**

\```
Wähle die Spielfigur [x y]: 3 5
Wähle das Ziel [x y]: 5🧱7
Die Figur auf Position [x:3 y:5] wurde auf Position [x:5 y:7] geschoben. Distanz: 2,83
\```