Welche ``Konzepte`` der Programmiersprache üben wir hier?
* Operatoren anwenden
* Konkretes mit logischen Operatoren modellieren 

Welche ``Denkweisen`` üben wir hier?
* Was kann mit logischen Operatoren modelliert werden?

Bei Unklarheiten hier nachlesen: 
* [Wie verwende ich Operatoren?](../Skripten/L02.1Operatoren.md)

## Logische Operatoren

### Schachbrett
Überlege eine logische ``Formel`` welche folgendes Muster beschreibt:
```
             x
       0 1  2 3  4 5
    0 ⬜⬛⬜⬛⬜⬛
    1 ⬛⬜⬛⬜⬛⬜
  y 2 ⬜⬛⬜⬛⬜⬛
    3 ⬛⬜⬛⬜⬛⬜
    4 ⬜⬛⬜⬛⬜⬛
    5 ⬛⬜⬛⬜⬛⬜
```

#### 1) Was sind meine Variablen?
Um eine ``Formel`` schreiben zu können müssen wir die ``Variablen/Atome`` der ``Formel`` wissen.

Überlege: 
* Was erlaubt mir ein Feld von einem anderen Feld zu unterscheiden? 
* Was für einen ``Typ` hat diese Variable? 

#### 2) Beginne mit einem einfacheren Problem und ...
Versuche die logische Formel für folgendes Muster zu finden.
```
             x
       0 1  2 3  4 5
    0 ⬜⬛⬜⬛⬜⬛
    1 ⬜⬛⬜⬛⬜⬛
  y 2 ⬜⬛⬜⬛⬜⬛
    3 ⬜⬛⬜⬛⬜⬛
    4 ⬜⬛⬜⬛⬜⬛
    5 ⬜⬛⬜⬛⬜⬛
```

Überlege: 
* Was ist die ``Formel`` für ein *weißes* Feld? 
* Was ist die ``Formel`` für ein *schwarzes* Feld?

Hinweis:
* Ist y hier relevant? Wenn ja muss es in der ``Formel`` vorkommen. Wenn nein, nicht.
* Wie frage ich ab ob eine Zahl gerade oder ungerade ist?

#### 3) ... erweitere dieses 
Versuche die logische Formel für folgendes Muster zu finden.
```
             x
       0 1  2 3  4 5
    0 ⬜⬛⬜⬛⬜⬛
    1 ⬛⬜⬛⬜⬛⬜
  y 2 ⬜⬛⬜⬛⬜⬛
    3 ⬛⬜⬛⬜⬛⬜
    4 ⬜⬛⬜⬛⬜⬛
    5 ⬛⬜⬛⬜⬛⬜
```

Überlege: 
* Was ist die ``Formel`` für ein *weißes* Feld? 
* Was ist die ``Formel`` für ein *schwarzes* Feld?

Hinweis:
* Welcher Operator nimmt ``Atome`` von logischen ``Formeln`` als Input und erzeugt ein neues ``Atom``?

#### 4) ... und erweitere nochmals 
Versuche die logische Formel für folgendes Muster zu finden.
```
             x
       0 1  2 3  4 5
    0 🔺⬛⬜🔺⬜⬛
    1 ⬛⬜🔺⬜⬛🔺
  y 2 ⬜🔺⬜⬛🔺⬛
    3 🔺⬜⬛🔺⬛⬜
    4 ⬜⬛🔺⬛⬜🔺
    5 ⬛🔺⬛⬜🔺⬜
```

Überlege: 
* Was ist die ``Formel`` für ein *weißes* Feld?
* Was ist die ``Formel`` für ein *schwarzes* Feld?
* Was ist die ``Formel`` für ein *rotes* Feld?

#### 5) Versuchen wir es nocheinmal 
Wenn wir nun die 🔺 Symbole mit einer Summe von Zeile ```y`` und Spalte ``x`` beschreiben können, haben wir eine Formel für eine (Gegen-) ``Diagonale``!
Versuche nun eine *einfachere* ``Formel`` für das ursprüngliche Problem zu finden, wenn wir eine (Gegen-) ``Diagonale`` mit ``x+y`` beschreiben können.

Hinweis: Was war die Formel für 2)? Schaut das Müster aus 1) ähnlich jenem aus 3) aus wenn du den Kopf um ``45°`` neigst und nochmal hinschaust?
```
             x
       0 1  2 3  4 5
    0 ⬜⬛⬜⬛⬜⬛
    1 ⬛⬜⬛⬜⬛⬜
  y 2 ⬜⬛⬜⬛⬜⬛
    3 ⬛⬜⬛⬜⬛⬜
    4 ⬜⬛⬜⬛⬜⬛
    5 ⬛⬜⬛⬜⬛⬜
```

Überlege: 
* Was ist die ``Formel`` für ein *weißes* Feld? 
* Was ist die ``Formel`` für ein *schwarzes* Feld?

#### 6) Ein anderes Muster
Es soll nur der Rand ⬛ sein, jedoch alles andere, egal wie groß das Viereck ist ⬜.
```
             x
       0 1  2 3  4 5  6
    0 ⬛⬛⬛⬛⬛⬛⬛
    1 ⬛⬜⬜⬜⬜⬜⬛
  y 2 ⬛⬜⬜⬜⬜⬜⬛
    3 ⬛⬜⬜⬜⬜⬜⬛
    4 ⬛⬜⬜⬜⬜⬜⬛
    5 ⬛⬜⬜⬜⬜⬜⬛
    6 ⬛⬛⬛⬛⬛⬛⬛
```

Überlege: 
* Was ist die ``Formel`` für ein *schwarzes* Feld?
* Was ist die ``Formel`` für ein *weißes* Feld? 
* Was wenn wir verschiedene Größen des Brettes erlauben?

#### 7) Ein anderes Muster
Nun sollen die Ränder abwechselnd ⬛ und ⬜ sein.
```
             x
       0 1  2 3  4 5  6
    0 ⬛⬛⬛⬛⬛⬛⬛
    1 ⬛⬜⬜⬜⬜⬜⬛
  y 2 ⬛⬜⬛⬛⬛⬜⬛
    3 ⬛⬜⬛⬜⬛⬜⬛
    4 ⬛⬜⬛⬛⬛⬜⬛
    5 ⬛⬜⬜⬜⬜⬜⬛
    6 ⬛⬛⬛⬛⬛⬛⬛
```

Überlege: 
* Was ist die ``Formel`` für ein *schwarzes* Feld?
* Was ist die ``Formel`` für ein *weißes* Feld? 