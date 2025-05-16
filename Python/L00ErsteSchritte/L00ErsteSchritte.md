## Was mache ich in einem Programm?

Hier ist nun der Punkt, an dem wir etwas machen können. `Programme` werden vom Computer in der Regel von `oben nach unten` gelesen und ausgeführt. Wir schreiben dort eine Art *Befehl* oder *Anweisung* in jede Zeile. Damit werden die weiter unten geschriebenen "Befehle" später als jene davor ausgeführt.

Hier geben wir "Dinge" auf der `Konsole` (oft auch Terminal genannt) aus. Das wird in Python mit der eingebauten Funktion `print()` gemacht. Wenn wir diese Funktion verwenden, schreiben wir in die runden Klammern `()` das, was wir auf der `Konsole` ausgeben wollen. In unserem Fall ist es der `Wert` "Hello World". Ein `Wert` ist eine von der Programmiersprache akzeptierte Kette an Symbolen (oder Daten), die wir im Speicher des `Programms` wiederfinden können.

```python
# Dateiname könnte z.B. L01_erste_schritte.py sein
# Die folgende Zeile gibt den Text "Hello World" auf der Konsole aus.
print("Hello World")
```

Um einen solchen `Wert` für eine spätere Verwendung "ansprechbar" zu machen, müssen wir diesen Wert in eine `Variable` schreiben. Eine Variable ist im Grunde ein Name, der auf einen Wert im Speicher zeigt.

```python
# L01_erste_schritte.py

# Eine Variable namens 'meine_variable' wird initialisiert,
# indem ihr der Text-Wert "Hello World" zugewiesen wird.
meine_variable = "Hello World"

# Der Inhalt der Variable 'meine_variable' wird auf der Konsole ausgegeben.
print(meine_variable)

# Der Inhalt der Variable 'meine_variable' wird erneut ausgegeben.
print(meine_variable)
```

**Anmerkung:** Die Funktion `print()` ist bereits sehr kurz und direkt. Es gibt keine speziellen Kürzel wie `sout` in manchen Java-IDEs, da `print()` so fundamental und einfach zu tippen ist.

Wir wollen aber mehr als nur das machen. In Programmiersprachen gibt es, unter anderem, folgende wichtige `Kontrollstrukturen`:

* `Variablen`,
* `Verzweigungen` (z.B. `if`/`elif`/`else`-Anweisungen),
* `Operatoren` (z.B. `+`, `-`, `*`, `/`, `and`, `or`) und
* `Schleifen` (z.B. `for`- oder `while`-Schleifen).

Diese vier merken wir uns, denn diese sind für uns momentan am wichtigsten. Mit diesen können wir theoretisch alles Programmieren was ihr an Software kennt. Diese werden in späteren Einheiten erklärt. Alle anderen Konzepte beschäftigen sich damit, wie wir Programme verständlicher und in der Gruppe angenehmer programmieren können. Wenn wir also diese 4 grundlegenden Konzepte erarbeitet und in unsere Denkweise eingebaut haben, können wir schon interessante Dinge programmieren. Bis dahin bitte ich um Geduld.

Wir gehen hier auf `Variablen` ein. Diese sind der Baustein aller weiteren `Kontrollstrukturen`, welche wir verwenden.
Eine Variable ist ein Platzhalter für Werte. Anstatt also zu sagen "Hello World", können wir dieses Wort (diesen Text) in einer Variablen speichern.

Python ist **dynamisch typisiert**. Das bedeutet, der Typ einer Variablen wird automatisch erkannt, wenn ihr ein Wert zugewiesen wird. Wir müssen den Typ nicht vorher explizit festlegen.
Beispielsweise sind `Typen` von Werten (und somit auch Variablen, die sie halten) folgende:

* `str` (String): das sind Zeichenketten/Texte (z.B. `"Hello World"` oder `'Python ist toll'`).
* `int` (Integer): das sind ganze Zahlen (z.B. `-5` und `568`).
* `float` (Floating-point number): das sind Kommazahlen (z.B. `-9.6` und `7.0`).
* `bool` (Boolean): das kann den Wert `True` oder `False` annehmen (Achtung: Großgeschrieben!).

In Python wird eine Variable **initialisiert**, indem ihr ein Wert zugewiesen wird. Bei dieser ersten Zuweisung wird die Variable erstellt, und Python leitet ihren Typ automatisch vom zugewiesenen Wert ab.

```python
# Eine Variable wird initialisiert, indem ihr ein Wert zugewiesen wird.
# Python erkennt automatisch, dass 'mein_string' den Typ 'str' (String) hat.
mein_string = "Hallo Python"
print(mein_string)

# Würde man versuchen, eine Variable zu verwenden, die noch nicht initialisiert wurde,
# (d.h. der noch kein Wert zugewiesen wurde), gäbe es einen NameError.
# print(uninitialisierte_variable) # Dies würde einen Fehler verursachen.
```

Hier haben wir den Namen der Variablen (`mein_string`) links vom Gleichheitszeichen `=` geschrieben und rechts davon den Wert, den sie speichern soll. In Python schließen wir Anweisungen üblicherweise *nicht* mit einem Strichpunkt ab.

Eine Variable wird in Python also **initialisiert**, indem man ihr mit dem Zuweisungsoperator `=` einen Wert gibt. Dies ist der Moment, in dem die Variable "entsteht" und ihren Typ durch den zugewiesenen Wert erhält:

```python
# Initialisieren der Variable (erstellt die Variable und weist einen Wert zu)
alter = 30  # Python erkennt 'alter' als Typ 'int'
print(alter)

# Der Wert einer bereits initialisierten Variable kann jederzeit geändert werden.
# Der Typ kann sich dabei auch ändern (das ist Dynamische Typisierung).
alter = "dreißig" # Jetzt ist 'alter' vom Typ 'str'
print(alter)
```

Das `=` hier wird `Zuweisungsoperator` genannt. `Operatoren` sind spezielle Symbole oder Schlüsselwörter, die es erlauben, `Werte` oder `Variablen` zu bearbeiten oder zu kombinieren.
Wir weisen also der Variablen mit dem Namen `alter` den Wert `30` zu.

Weitere wichtige Operatoren in Python sind z.B. `.` (für Zugriff auf Attribute/Methoden von Objekten), `+` (Addition, aber auch String-Verkettung), `-` (Subtraktion), `*` (Multiplikation, auch String-Wiederholung), `/` (Division), `**` (Potenzierung), `//` (Ganzzahldivision), `%` (Modulo), sowie logische Operatoren wie `and`, `or`, `not`.
Wir werden diese uns aber zu einem späteren Zeitpunkt genauer anschauen.

Hier verbinden (konkatenieren) wir `Variablen` miteinander und fügen dazwischen noch ein Leerzeichen ein:

```python
# Variable initialisieren
erster_string_teil = "Python ist"

# Andere Variable initialisieren
zweiter_string_teil = "super!"

# Variablen mit dem Operator '+' verbinden (String-Konkatenation)
# und das Ergebnis in einer neuen Variable speichern (diese wird dabei initialisiert).
mein_kombinierter_string = erster_string_teil + " " + zweiter_string_teil

# Den Inhalt der kombinierten Variable ausgeben
print(mein_kombinierter_string)
```

Die `Variable` `mein_kombinierter_string` können wir nun ausgeben.

Wir merken uns:

> Ein `Wert` ist eine von der Programmiersprache akzeptierte Einheit von Daten (z.B. eine Zahl, ein Text), die im *Speicher* des `Programms` abgelegt wird.

> Jeder `Wert` hat einen `Typ` (z.B. `int`, `str`, `bool`). Der `Typ` legt die Bedeutung und die möglichen Operationen für diesen `Wert` fest. Python erkennt den Typ dynamisch bei der Wertzuweisung.

> Eine `Variable` ist ein *Name* oder ein *Platzhalter*, der auf einen `Wert` im Speicher verweist.

> Um `Variablen` und `Werte` anschauen zu können, schreiben wir diese mit `print()` auf die `Konsole`.

> Eine `Variable` wird in Python **initialisiert**, indem ihr ein Name gegeben und erstmalig ein Wert zugewiesen wird. Bei diesem Vorgang wird die Variable erstellt und ihr Typ automatisch anhand des zugewiesenen Wertes festgelegt.
