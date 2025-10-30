Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Schleifen
* Verzweigungen
* Listen (multidimensional)
* User-Input
* Operatoren (besonders logische)

Welche ``Denkweisen`` üben wir hier?
* Wie gehe ich mit einer Mathematischen Funktion um (lineare Funktion, Steigung)?

Bei Unklarheiten hier nachlesen:
* [welche Kontrollstrukturen soll ich verwenden?](../Skripten/L03.1Kontrollstrukturen.md)

# Schachbrett und Linien.
**Anmerkungen:** 
* Es existiert eine Vorlage welche die Punkte 2) und 3) aus der [Übersicht](#übersicht) bereits implementiert hat. Verwende diese und versuche diese zu grob verstehen!
* >Die **Aufgabe ist** konzeptionell mit [Schritt 1](#schritt-1---level----erster-versuch) **abgeschlossen**. Die weiteren Schritte sind für besonders detailverliebte Teilnehmer:innen, welche dieses Beispiel besonders motiviert.

## Übersicht
1) Der User soll 2 Paare von `y` und `x` Koordinaten wählen, welche miteinander verbunden werden sollen. Markiere die Start- und Endpunkte mit den Symbolen 🏌🏻 und ⛳. Verwende für die Verbindung dieser Punkte den Zusammenhang $y=k\cdot x+d$ und $\frac{\Delta y}{\Delta x}=k$. Verwende für jede Zelle, welche vom Programm als Teil der Linie ausgewählt wird, das Symbol ``🔸``.
2) Erstelle ein Schachbrett mit den Dimensionen welche der User eingibt. Verwende dazu `Console.ReadLine` und wandle diesen String in eine Zahl um. Verwende *TryParse* mit eine ``While-Schleife`` um falsche Inputs abzufangen. Ein Schachbrett soll als 2D-Array auf der Console dargestellt werden. 
3) Es soll möglich sein **mehrere** Linien im gleichen ``2D-Array`` zu zeichnen. Frage den User mit ``weiter? [true/false]: `` ob diese:r eine weitere Linie einzeichnen will.

**Anmerkung:**
* Die 16-bit (4-hexbit) Uni-Codes für schwarze ⬛ und weiße ⬜ Symbole sind `\u21B1` und `\u21B2`. Falls diese nicht schön ausgefüllt dargestellt werden (die verwendete Font im Terminal unterstützt diese Symbole nicht als "emoji") verwende die 24-bit (5-hexbit) emojis 🔲 `\u1F532` und 🔳 `\u1F533`. (*``windows-taste + .``* öffnet dir einen preview einiger Emojis auf Windows. Füge diese dann in den Code ``string blackSquare = "⬛"`` ein)

Der Zusammenhang zwischen Zwei Punkten auf einer Linie ist hier bildlich dargestellt:
![alt text](figures/steigungsdreieck.png)

Weitere Erklärungen folgen in den jeweiligen Schritten.

---

## **Schritt 1 - level: 🤔 - erster Versuch**:
Wir starten **ein Feld rechts von ``🏌🏻``**. Von dort aus wollen wir entlang der *x-Achse*, *nach rechts* jedes Feld des ``2D-Arrays`` mit einer `For-Schleife` abtasten, bis wir **ein Feld links vom Ziels ``⛳`` sind**. 
```
Wähle die Figur... [x y]: 1 2
... und wähle das Ziel [x y]: 10 4
🟦0️⃣1️⃣2️⃣3️⃣4️⃣5️⃣7️⃣6️⃣8️⃣9️⃣🔟➡️x-Achse
0️⃣🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
1️⃣🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
2️⃣🔲🏌🏻🔸🔸🔲🔳🔲🔳🔲🔳🔲
3️⃣🔳🔲🔳🔲🔸🔸🔸🔸🔳🔲🔳
4️⃣🔲🔳🔲🔳🔲🔳🔲🔳🔸🔸⛳
...            ...         ...
⬇️y-Achse
```

Für den ``Schleifen-Index`` *x* der ``For-Schleife`` stellen wir uns folgendes vor:
* Die Distanz zwischen ``🏌🏻`` und ``⛳`` auf der x-Achse wird $\Delta x$ genannt. Wir berechnen es mit *xEnd - xStart = 10 - 1 = 9*. xEnd und xStart sind die vom User angegebenen Werte in x.
* Wir tun nun so als wäre bei ``🏌🏻`` *x=0* und *y=0*. Wir können also den ``Schleifen-Index`` **x** der ``For-Schleife`` von **1** bis (exclusive) **$\Delta x$** nehmen.

```
🟦0️⃣1️⃣2️⃣3️⃣4️⃣5️⃣7️⃣6️⃣8️⃣9️⃣➡️x-Achse
0️⃣🏌🏻🔸🔸🔳🔲🔳🔲🔳🔲🔳
1️⃣🔳🔲🔳🔸🔸🔸🔸🔲🔳🔲
2️⃣🔲🔳🔲🔳🔲🔳🔲🔸🔸⛳
...            ...         ...
⬇️y-Achse
```

Nun berechen wir folgendes:
1) *Steigung der Linie:* $k = \frac{\Delta y}{\Delta x} = \frac{\text{Ende in y} - \text{Start in y}}{\text{Ende in y} - \text{Start in y}} = \frac{4 - 2}{10 - 1}= \frac{2}{9} = 0.22...$
2) *Die Position von ``🔸``:
    * Wir wissen den x-Wert *x=1* da es der erste ``Schleifenindex`` der ``For-Schleife`` ist. Aber was ist der y-Wert auf der Linie? Die Antwort ist, $y = k \cdot x = 0.22 \cdot 1 = 0.22$*. Da wir kein Feld des ``2D-Arrays`` mit einer Kommazahl ansprechen können, runden wir diese **auf** (*ceiling*), **ab** (*floor*) oder **kaufmännisch** (*round*). Wir verwenden *round* und bekommen dadurch $0$. Da wir bei ``🏌🏻`` *x=0* und *y=0* gesetzt haben, müssen wir die Position im ``2D-Array`` anpassen. Wir tun dies mit ``field[yStart + y, xStart + x]`` was eingesetzt ``field[2 + 0, 1 + 1]``, also ``field[2, 2] = "🔸"`` ist. Wir sehen, dass folgendes eingezeichnet wurde und mit der oben gezeigen Linie übereinstimmt.
    ```
    ... und wähle das Ziel [x y]: 10 4
    🟦0️⃣1️⃣2️⃣3️⃣4️⃣5️⃣7️⃣6️⃣8️⃣9️⃣🔟➡️x-Achse
    0️⃣🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
    1️⃣🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
    2️⃣🔲🏌🏻🔸🔳🔲🔳🔲🔳🔲🔳🔲
    3️⃣🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
    4️⃣🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳⛳
    ...            ...         ...
    ⬇️y-Achse
    ```

Wir wiederholen Punkt 2. bis wir alle Felder in der For-Schleife abgeganben sind. 1. ändert sich nicht und muss deshalb nur ein mal außerhalb der Schleife berechnet werden.

### Testfälle und erwartete Ergebnisse:

a) ✅ [oberhalb, rechts, flach] und b) ✅ [unterhalb, rechts, flach]
```
Größe des Spielfields eingeben: 31
Wähle die Figur... [x y]: 15 15
... und wähle das Ziel [x y]: 25 13
                ... Brett in Angabe aus Platzgründen nicht dargestellt ...
weiter? [true/false]: true
Wähle die Figur... [x y]: 15 15
... und wähle das Ziel [x y]: 25 17
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔸🔸⛳🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔸🔸🔸🔸🔸🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🏌🏻🔸🔸🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔸🔸🔸🔸🔸🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔸🔸⛳🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
```

---

## **Schritt 2 - Level: 😵‍💫 - flach vs. steil, oberhalb vs. unterhalb und rechts vs. links**
Der Schein trügt, haben wir wirklich alles bedacht? Wir Testen dafür nun $8=2^3$ Fälle mit verschiedenen Ziele: 
* oberhalb des Spielers vs. unterhalb des Spielers, 
* rechts des Spielers vs. links des Spielers
* "flache" Linie vs. "steile" Linie

**Anmerkung für besonders Interessierte:** Das Fachwort dafür wäre ``Äquivalenzklassentest`` - ein Test je Gruppe, welche sehr ähnlich "aussieht". Nicht 5 verschiedene Linien testen, die alle *flach*, *rechts* und *oberhalb* sind. Meistens funktioniert das Programm für alle diese, oder keine.

### Testfälle und erwartete Ergebnisse:
Wir erkennen folgendes:

a) ✅ [unterhalb, **rechts**, **flach**] und b) ✅ [oberhalb, **rechts**, **flach**] siehe Schritt 1.

c) ❌ [unterhalb, **rechts**, **steil**] und d) ❌ [oberhalb, **rechts**, **steil**]

Das scheint nicht funktioniert zu haben. Überlege was hier passiert ist. 

```
Größe des Spielfields eingeben: 31
Wähle die Figur... [x y]: 15 15
... und wähle das Ziel [x y]: 17 25
                ... Brett in Angabe aus Platzgründen nicht dargestellt ...
weiter? [true/false]: true
Wähle die Figur... [x y]: 15 15
... und wähle das Ziel [x y]: 17 5
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳⛳🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔸🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🏌🏻🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔸🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳⛳🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
```

e) ❌ [unterhalb, **links**, steil]
f) ❌ [unterhalb, **links**, flach]
g) ❌ [oberhalb,  **links**, flach]
h) ❌ [oberhalb,  **links**, steil]

Das scheint nicht funktioniert zu haben. Überlege was hier passiert ist. 
```
Größe des Spielfields eingeben: 31
Wähle die Figur... [x y]: 15 15
... und wähle das Ziel [x y]: 13 25
                ... Brett in Angabe aus Platzgründen nicht dargestellt ...
weiter? [true/false]: true
Wähle die Figur... [x y]: 15 15
... und wähle das Ziel [x y]: 5 17
                ... Brett in Angabe aus Platzgründen nicht dargestellt ...
weiter? [true/false]: true
Wähle die Figur... [x y]: 15 15
... und wähle das Ziel [x y]: 5 13
                ... Brett in Angabe aus Platzgründen nicht dargestellt ...
weiter? [true/false]: true
Wähle die Figur... [x y]: 15 15
... und wähle das Ziel [x y]: 13 5
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳⛳🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳⛳🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🏌🏻🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳⛳🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳⛳🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
```

Durch die **8 Testfälle** haben wir folgendes erkannt:
1) flach vs. steil:
    * Bei *steilen Linien* gehen wir die *y-Achse* in der ``For-Schleife``ab und vertauschen die *Steigung*. Also $k=\frac{\Delta x}{\Delta y}$. 
    * Bei *flachen Linien* gehen wir die *x-Achse* in der ``For-Schleife``ab und behalten *Steigung* $k=\frac{\Delta y}{\Delta x}$. 
    * Wir unterscheiden beide Fälle mit einer ``Verzweigung`` mit der ``Bedingung`` *gehe der Achse entlang, welche länger ist*.
2) links vs. rechts:
    * In unserer ``For-Schleife`` gehen wir im [Schritt 1](#schritt-1---level----erster-versuch) mit dem ``Schleifen-Index`` *x* von *x = 1* nach *x = $\Delta X$*. Wenn wir die ``Werte``von *x* so übernehmen sind diese *aufsteigend*. Wenn aber der *Startpunkt* ``🏌🏻`` rechts vom *Endpunkt* ``⛳`` ist, müssen wir von *x = $\Delta X$* nach *x = 1* gehen. Also *absteigend*, nicht *aufsteigend*. Unserer ``Schleifen-Index`` *x* muss sich also ändern. **Hinweis:** Wir belassen den ``Schleifen-Index`` *x* bei *x = 1* nach *x = $\Delta X$*, jedoch drehen wir diesen um, wenn wir auf unser ``2D-Array`` zugreifen ``for (int x = 1; ... ) { ... field[xStart + x, ...] }`` vs. ``for (int x = 1; ... ) { field[xStart - x, ...] }``.
3) oberhalb vs. unterhalb
    * **Kein wirklicher technischer Unterschied fällt auf**. Es funktioniert z.B. Test a) und b), jedoch c) und d) nicht. Der Unterschied zwischen diesen ist jedoch **steil vs. flach**, nicht **oberhalb vs. unterhalb**. Es kann also sein, dass wir hier gar nicht unterscheiden müssen. Wir unterscheiden trotzdem um sicher zu gehen. Im nachhinein können wir immer die ``Zweige`` einer ``Mehrfachverzweigung`` ohne viel Aufwand zusammenfassen. Jedoch wenn wir einen spezialfall übersehen, ist dieser oft nicht leicht zu erkennen.

Es scheint also *8 Fälle* zu geben welche wir in einer ``Mehrfachverzweigung`` abfragen können und die angesprochenen Änderungen einfügen müssen. Setze diese mithilfe der Vorlage um.

**Anmerkung:** Nicht alle 8 Fällen brauchen verschiedenen Code. Diese können zusammengefasst werden, jedoch starten wir konzeptionell mit 8. Verwende wenn du zusammenfasst, die Fälle ``rechts && flach``, ``links && flach``, ``unten && steil`` und ``oben && steil``. Diese haben den selben Code ein den ``Bedingungen`.`

### Testfälle und erwartete Ergebnisse:

a-h + ``neu 💫`` i-l): ✅ 
i) horizontale rechts
```
Wähle die Figur... [x y]: 15 15
... und wähle das Ziel [x y]: 30 15
```

j) horizontale links
```
Wähle die Figur... [x y]: 15 15
... und wähle das Ziel [x y]: 15 0
```

k) vertikale oben
```
Wähle die Figur... [x y]: 15 15
... und wähle das Ziel [x y]: 15 0
```

l) vertikale unten
```
Wähle die Figur... [x y]: 15 15
... und wähle das Ziel [x y]: 15 30
```

```
Größe des Spielfields eingeben: 31
        ... Brett in Angabe aus Platzgründen nicht dargestellt ...
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲⛳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔸🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔸🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔸🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔸🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳⛳🔳🔸🔳⛳🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔸🔲🔸🔲🔸🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔸🔳🔸🔳🔸🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔸🔸🔸🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔸🔸🔸🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔸🔸🔸🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔸🔸🔸🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔸🔸🔸🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳⛳🔸🔸🔳🔲🔳🔲🔳🔲🔳🔸🔳🔲🔳🔲🔳🔲🔳🔸🔸⛳🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔸🔸🔸🔸🔸🔳🔲🔸🔲🔳🔸🔸🔸🔸🔸🔳🔲🔳🔲🔳🔲🔳🔲
⛳🔸🔸🔸🔸🔸🔸🔸🔸🔸🔸🔸🔸🔸🔸🏌🏻🔸🔸🔸🔸🔸🔸🔸🔸🔸🔸🔸🔸🔸🔸⛳
🔲🔳🔲🔳🔲🔳🔲🔳🔸🔸🔸🔸🔸🔳🔲🔸🔲🔳🔸🔸🔸🔸🔸🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳⛳🔸🔸🔳🔲🔳🔲🔳🔲🔳🔸🔳🔲🔳🔲🔳🔲🔳🔸🔸⛳🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔸🔸🔸🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔸🔸🔸🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔸🔸🔸🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔸🔸🔸🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔸🔸🔸🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔸🔳🔸🔳🔸🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔸🔲🔸🔲🔸🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳⛳🔳🔸🔳⛳🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔸🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔸🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔸🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔸🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳
🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲⛳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲🔳🔲
```

--- 

### **Schritt 3: 💀💀**: Brauchen wir überhaupt eine ``Mehrfachverzweigung``?
Die Antwort hier ist *nein*. Es geht auch mit einem Trick und ein wenig Glück. Es ist aber an sich empfohlen beim Programmieren, klare und nachvollziehbare Pfade zu implementieren, als wie sich auf Tricks zu verlassen. Der Grund ist meistens sind diese Tricks nur unter sehr eingeschränkten Bedingungen möglich ist. Sie sind sehr imposant und "smart", jedoch beim Programmieren *ändern sich die Anforderungen an ein Programm laufend*. Der Trick ist meistens dann nicht mehr nützlich. Einen möglichen Schritt Richtung *Warbarkeit* lernen wir langsam in *Modul 2* kennen, indem wir manche "Buchstaben" der Abkürzung ``S.O.L.I.D`` anschauen. Wichtig werden hier Konzepte aus der ``OOP``, insbesondere ``Interfaces``.

Wir schauen uns dennoch den Trick an. Vieleicht ist er nicht nur ein Spezialfall und wir haben kurzen, verständlicheren und dadurch wartbareren Code.

Der Trick ist folgender:
* Wir gehen eine Dimension nach oben und bewegen uns in der *z-Achse*. Die ``For-Schleife`` ist also nicht mehr zuständig für Bewegungen in der x-Achse und y-Achse. Danach berechnen wir uns x und y wie bisher, nur **gleichzeitg**.

```csharp
// Schritt 2:
for (int i = 1; i < longerDelta; i++)
{
    // entweder:
    int x = i;
    int y = Convert.ToInt32(Math.Round(i * steigung));
    // oder 
    int x = Convert.ToInt32(Math.Round(i * steigung));
    int y = i;
    // oder...
    int x = -i;
    int y = -Convert.ToInt32(Math.Round(i * steigung));
    // oder...
    int x = -Convert.ToInt32(Math.Round(i * steigung));
    int y = -i;
}

// vs.

// Schritt 3:
for (int z = 1; z < longerDelta; z++)
{
    // keine Verzweigungen nötig! Aber wieso geht das... 🤷🏻 wir lassen es dabei (Projektionen, bzw. paramartische Kurven).
    int x = Convert.ToInt32(Math.Round(z * steigungVerkehrt));
    int y = Convert.ToInt32(Math.Round(z * steigung));

    field[yStart + y, xStart + x] = "🔸";
}
```

Wir sind also wieder bei einem sehr ähnlichen Code wie in [Schritt 1](#schritt-1---level----erster-versuch), nur... unverständlich. Bleiben wir bei [Schritt 2](#schritt-2---level----flach-vs-steil-oberhalb-vs-unterhalb-und-rechts-vs-links), dieser ist ohne *Tricks* lösbar.

### Vorlage:
```csharp
using System.Text;

// ################################### Main - Auswahl der Schritte ###################################
Console.OutputEncoding = Encoding.UTF8;
Schritt1();

// Funktionen für einzelne Schritte aus der Angabe 
// ################################### Schritt 1 ###################################
void Schritt1()
{
    bool zufrieden;
    int dimension = HandleUserInputOfSetup();

    Console.Clear();

    // multidimensionales array anlegen.
    string whiteSquare = "🔲";
    string blackSquare = "🔳";
    string startSymbol = "🏌🏻";
    string destSymbol = "⛳"; // dest ist die abküzrung für destination -> das Ziel.
    string lineSymbol = "🔸";

    string[,] field = GenerateSchessBoard(dimension, whiteSquare, blackSquare);

    do
    {
        int[] positions = HandleUserInputDuringGame(); 
        // Wem das nicht gefällt, bitte Tuple anschauen. Wir machen es in Modul 2. Dann geht es in einer Zeile.
        int xStart = positions[0];
        int yStart = positions[1];
        int xDest  = positions[2];
        int yDest  = positions[3];

        field[yStart, xStart] = startSymbol;
        field[yDest, xDest] = destSymbol;

        int deltaX = xDest - xStart;
        int deltaY = yDest - yStart;
        double steigung;

        // TODO: BEGINN der Logik - implementiere hier!

        ...

        // ENDE der Logik

        Print(field, dimension);
        zufrieden = HandleUserInputForRepeatingTheGame();

    } while (zufrieden);
}

// #################### Hilfsfunktionen ####################
int HandleUserInputOfSetup()
{
    string prompt = "Größe des Spielfields eingeben:";
    Console.Write($"{prompt} ");

    int dimension;
    string userinput = Console.ReadLine();
    while (!int.TryParse(userinput, out dimension))
    {
        PrepareConsoleFormatAndPrintErrorPrompt("Bitte eine positive Zahl ohne Komma eingeben.", userinput);
        Console.Write($"{prompt} ");
        userinput = Console.ReadLine();
    }

    return dimension;
}

int[] HandleUserInputDuringGame()
{
    int[] startPos = HandleUserInputOfBoardPositions("Wähle die Figur... [x y]:");
    int[] endPos = HandleUserInputOfBoardPositions("... und wähle das Ziel [x y]:");
    return [startPos[0], startPos[1], endPos[0], endPos[1]];
}

int[] HandleUserInputOfBoardPositions(string prompt)
{
    int x, y; // Abgekürzte Schreibeweise, anstatt zwei Zeilen für Definition zu verwenden.

    Console.Write($"{prompt} ");
    string[] userinput = Console.ReadLine().Split(" ");

    while (!(userinput.Length == 2 &&
        int.TryParse(userinput[0], out x) &&
        int.TryParse(userinput[1], out y)))
    {
        PrepareConsoleFormatAndPrintErrorPrompt("Bitte geben Sie ZWEI ganze Zahlen, getrennt durch ein Leerzeichen, ein.", string.Join(" ", userinput));
        Console.Write($"{prompt} ");
        userinput = Console.ReadLine().Split(" ");
    }

    return [x, y];
}

bool HandleUserInputForRepeatingTheGame()
{
    string prompt = "weiter? [true/false]:";
    Console.Write($"{prompt} ");
    bool choice;
    string userinput = Console.ReadLine();

    while (!bool.TryParse(userinput, out choice))
    {
        PrepareConsoleFormatAndPrintErrorPrompt("Bitte geben Sie das Wort true oder false ein.", userinput);
        Console.Write($"{prompt} ");
        userinput = Console.ReadLine();
    }

    return choice;
}

void PrepareConsoleFormatAndPrintErrorPrompt(string prompt, string erronousInput) {
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Ungültige Eingabe: { string.Join(" ", erronousInput)} - {prompt}");
    Console.ResetColor();
}

string[,] GenerateSchessBoard(int dimension, string whiteSquare, string blackSquare)
{
    string[,] field = new string[dimension, dimension];
    // Erstelle ein Schachbrettmuster beliebiger Größe welche vom User bestimmt wird.
    for (int i = 0; i < dimension; i++)
    {
        for (int j = 0; j < dimension; j++)
        {
            if ((j + i) % 2 == 0)
            {
                field[i, j] = whiteSquare;
            }
            else
            {
                field[i, j] = blackSquare;
            }
        }
    }

    return field;
}

void Print(string[,] field, int dimension)
{
    for (int i = 0; i < dimension; i++)
    {
        for (int j = 0; j < dimension; j++)
        {
            Console.Write(field[i, j]);
        }
        Console.WriteLine();
    }
}
```
