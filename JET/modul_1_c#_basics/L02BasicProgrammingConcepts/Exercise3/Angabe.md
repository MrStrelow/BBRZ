Wir üben folgende Konzepte der Programmiersprache:
* Schleifen
* Verzweigungen
* 2D-Arrays
* User-Input
* Operatoren (besonders logische)

Welches Konzept üben wir hier?
* Wie gehe ich mit einer Mathematischen Funktion um (lineare Funktion, Steigung)?

## 3. Schachbrett und Linien.
* Erstelle ein Schachbrett mit den Dimensionen welche der User eingibt. Verwende dazu `Console.ReadLine` und wandle diesen String in eine Zahl um.
Ein Schachbrett soll als 2D-Array auf der Console dargestellt werden. Die Uni-Codes für schwarze und weiße Symbole sind `\u2591` und `\u2588`.
* Der User soll nun 2 Paare von `y` und `x` Koordinaten wählen, welche miteinander verbunden werden sollen. Markiere die Start- und Endpunkte mit einem `o` und `x`. Verwende für die Verbindung dieser Punkte den Zusammenhang $y=k\cdot x+d$ und $\frac{\Delta y}{\Delta x}=k$. Verwende für jede Zelle, welche als Teil der Linie von den oben genannten Zusammenhängen ausgewählt wird, das Symbol `~`.
Beginne mit folgenden Fall:
    * Start 0 0 zu 3 5: hier ist die längere Seite die horizontale Seite (x). Bedeutet wir wollen diese mit einer Schleife abtasten. Die Koordinaten der längeren (y) Richtung wird dann verwendet um die Koordinaten der kürzeren (x) Richtung auszurechnen ($y=k\cdot x+d$)
    * Start 0 0 zu 5 3: hier ist die längere Seite die vertikale Seite (y). Achtung! Was dreht sich nun alles um? ($y=k\cdot x+d$ oder $x=k\cdot y+d$? bzw. $\frac{\Delta y}{\Delta x}=k$ oder $\frac{\Delta x}{\Delta y}=k$?)
    * Start 3 5 zu 0 0 bzw. 5 3 zu 0 0: Hier ist nun das Problem, dass wir in der For-Schleife von rechts nach links gehen. Bis jetzt war es links nach rechts. Passe den Code dementsprechend an.
    * horizontale und vertikale Linien: Stelle sicher, dass horizontale und vertikale Linien funktionieren.
* ``Optional``: Versuche wenn die Linie nach rechts oben bzw. links unten geht das Symbol `/`, links oben bzw. rechts unten, `\`, wenn diese "sehr steil" ist `|` und "sehr flach" `-` (oder such in der erweiterten ASCII Tabelle nach Symbolen). 

### Testfälle
- 0 5 und 7 7
- 5 0 und 7 7
- 5 7 und 7 0
- 0 7 und 7 5
- 7 7 und 0 5
- 7 7 und 5 0
- 5 7 und 0 7
- 0 7 und 5 7
- 0 5 und 7 7
- 0 0 und 0 7
- 0 7 und 0 0

### Erwartete Ausgabe für den Fall 1 2 zu 5 5:
```Größe des Spielbretts eingeben: 6
Größe des Spielbretts eingeben: 6
Wähle die Figur... [x y]: 1 2
... und wähle das Ziel [x y]: 5 5
█░█░█░
░█░█░█
█o█░█░
░█.█░█
█░█..░
░█░█░x
```