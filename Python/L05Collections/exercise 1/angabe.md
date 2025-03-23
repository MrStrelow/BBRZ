Diese Übung erweitert [Übung 2 aus den Kontrollstrukturen](https://github.com/MrStrelow/BBRZ/blob/main/Python/L03Kontrollstrukturen/exercise2-linien-am-schachbrett/angabe.md). Die Lösung dazu ist [hier](https://github.com/MrStrelow/BBRZ/blob/main/Python/L03Kontrollstrukturen/exercise2/solution/schachbrett_fall_4.py) zu finden.

---

Welche ``Konzepte`` der Programmiersprache üben wir hier?
* List-Comprehentions
* Dictionary als Objekt ohne Klasse
* Funktionen
* Import von externen Libraries und installation derer durch pip
* Abfrage von Tastatur-Events mittels der ``keyboard`` library.
* Anhalten eines ``Threads`` mittels der ``time`` library

Welche ``Denkweisen`` üben wir hier?
* Wann brauche ich eine ``Klasse`` welche mir den Zustand und Verhalten eines ``Objektes`` vorgibt?
* Wann kann ich ein ein ``dictionary`` oder ``Named-Tuple`` als *simples* ``Objekt`` ohne Klassenvorschrift verwenden (à la Javascript)?

Bei Unklarheiten hier nachlesen:
* [Kontrollstrukturen](https://github.com/MrStrelow/BBRZ/blob/main/Python/L03Kontrollstrukturen/L03Kontrollstrukturen.md)
* [Collections](https://github.com/MrStrelow/BBRZ/blob/main/Python/L05Collections/collections.md)

## Schachbrett und Linien - Teil 2
Für eine grafische Betrachtung der Angabe siehe [hier](#erwartete-ausgabe).

Wir erlauben nun durch Abfrage von Tastaturinputs (``w``, ``a``, ``s``, ``d`` und ``f``) eine Steuerung von ``Figuren``. Es soll nun möglich sein, durch z.B. die Taste ``w``/``a``/``s``/``d`` ein Feld nach ``oben``/``links``/``unten``/``rechts`` in einer Vorauswahl zu gehen. Es soll möglich sein beliebig oft ``w``, ``a``, ``s``, ``d`` zu drücken um ein beliebiges Feld mit der Vorauswahl anzupeilen. Während dieser Vorauswahl ist die alte Position der ``Figur`` 🔵 und die Vorauswahl ❌ mit einer Linie zu verbinden. Mit der Taste ``f`` soll es möglich sein diese Vorauwahl zu bestätigen und die ``Figur`` dorthinzu bewegen. Die ``Figur`` soll für den 1. Spieler durch 🔵 und für den 2. Spieler durch 🟢 dargestellt werden. Nach drücken der ``f`` Taste wechseln wir von Spieler 1 zu Spieler 2.

Verwende für ``Variablen`` welche den *Spieler* betreffen ``Dictionaries`` um diese zu ``"Objekten"`` zu kapseln. Diese sind z.B. die Darstellung ``players_darstellung = {"A" : "🔵", "B" : "🟢"}`` und die Positionen ``player_positions = {"A" : {"x" : 1, "y" : 1}, "B" : {"x" : dimension - 2, "y" : dimension - 2}}``. Weiters verwende auch für Variablen welche für alle Spieler gleich sind folgende ``Dictionaries``, ``markers = {"end" : "❌", "line" : "🔸"}`` und ``field_properties = {"black" : "⬛", "white" : "⬜"}``. Wobei letzteres ein die Darstellung des Schachbretts ist.

Versuche in diesem Beispiel basierend auf den ``Objekt`` *player_positions* welches die "Logik" speichert, das ``Objekt`` der Darstellungen wie ``players_darstellung`` und das Spielfeld ``field`` korrekt mit den ``Linien`` und ``Figuren`` zu besetzen. Verwende nicht direkt die Darstellungen um Entscheidungen zu treffen!

Zu verwendende folgende ``Funktionen``:
* ``create_board()``: Erstelle mittels einer ``List-Comprehention`` ein Schachbrett.
* ``draw_board(board)``: Zeichne die aktuellen Symbole welche sich in der 2D-``Liste`` befinden auf die ``Console``.
* ``draw_line(start, end)``: Zeichne eine Linie zwischen
* ``move_piece(player)``: Kümmert sich um die Abfrage der Tastatur, die Bewegung der ``Vorauswahl`` und die Positionierung der ``Figuren``.

## Hilfestellung
Folgendes Programm stellt den Programmstart dar. Die oben erwähnten ``Funktionen`` sowie ``Variablen``/``Objekte`` sind darüber zu implementieren.
```python
os.system('cls' if os.name == 'nt' else 'clear') # löschen alles was noch von der alten console übrig ist.
board = create_board()

# Setze die Figuren auf das Spielfeld
for player, pos in player_positions.items():
    board[pos["y"]][pos["x"]] = players_darstellung[player]

draw_board(board)

while True:
    for player in player_positions.keys():
        move_piece(player)
```

Weiters ist die zentrale Funktion hier skizziert:

```python
def move_piece(player):
    x = ...
    y = ...
    
    while True:
        event = keyboard.read_event()

        if event.event_type == keyboard.KEY_DOWN:
            if ...

            elif ...

            elif ...

            elif ...

            elif ...
            
        time.sleep(0.01)

        # leeres brett erzeugen
        global board # um eine Variable außerhalb der Funktion zu überschreiben muss global verwendet werden
        ...

        # ziel einzeichnen
        ...

        # rufe draw line auf und
        ...

        #... zeichne spieler symbole
        ...
        
    # Endposition aktualisieren - verändere den zustand des spielers
    # player_positions[player]["x"], player_positions[player]["y"] = x, y
    ...
    
    # bewege figure auf das ziel
    ...
```

Um das Schachbrett immer an die gleiche stele zu "printen" verwende folgende Funktion:
```python
def draw_board(board):
    # os.system('cls' if os.name == 'nt' else 'clear') # flackert - die gesamte console wir gelöscht und neu erzeugt.

    # flacker nicht / weniger: warum? wir setzen die cursor-position auf 0/0 und zeichnen von dort - "bereits verwendeter speicher wird im hintergrund verwendet"
    sys.stdout.write("\u001B[H")  # setze cursor auf (0,0)
    sys.stdout.flush() # zwingt sofortige bewegung auf position 0/0 egal ob buffer voll ist.

    for row in board:
        print("".join(row))
```

### Testfälle
Drücke ``w``, ``a``, ``s``, ``d`` um auf eine neue Position zu gehen und ``f`` um diese zu bestätigen. Verwende dazu das modul ``keyboard``

### Erwartete Ausgabe:
![alt](https://raw.githubusercontent.com/MrStrelow/BBRZ/refs/heads/main/Python/L05Collections/exercise%202/figures/sample_output.gif)
