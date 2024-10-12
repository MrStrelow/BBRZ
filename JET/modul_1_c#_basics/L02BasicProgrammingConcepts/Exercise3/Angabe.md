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
Ein Schachbrett soll als 2D-Array auf der Console dargestellt werden. Die Uni-Codes für schwarze und weiße Symbole sind `d` und `d`.
* Der User soll nun 2 Paare von `x` und `y` Koordinaten wählen, welche miteinander verbunden werden sollen. Markiere die Start- und Endpunkte mit einem `o` und `x`. Verwende für die Verbindung dieser Punkte den Zusammenhang $y=k\cdot x+d$ und $\frac{\Delta y}{\Delta x}=k$. Verwende für jede Zelle, welche als Teil der Linie von den oben genannten Zusammenhängen ausgewählt wird, das Symbol `-`.
* ``Optional``: Versuche wenn die Linie nach rechts oben bzw. links unten geht das Symbol `/`, links oben bzw. rechts unten, `\`, wenn diese "sehr steil" ist `|` und "sehr flach" `-` (oder such in der erweiterten ASCII Tabelle nach Symbolen). 

### Erwartete Ausgabe:
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