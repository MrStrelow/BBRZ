## Verzweigungen mit Turtle
### Nur auf der rechten Hälfte zeichnen
Wir zoomen hinaus. Die Turtle ist in ihrem sandigen Garten, links davon das Meer, rechts davon die Wüste. Es ist zu heiß und unsere Turtle hat eine Idee. Sich im Sand eingraben und schlafen. Dazu sucht sie einen geeigneten Ort in der Wüste. Bevor sie losgeht drückt diese einen Faden in den Boden um ihr am Haus wiederzufinden. Da sie keine Ahnung hat wohin sie gehen soll, geht sie an einen zufälligen ort. Dort angekommen gräbt diese sich ein. 

Wir setzen die Logik folgendermaßen um:
* Wenn die x-Koordinate in der rechten Bildschirmhälfte liegt (Wüste), bewege die Turtle dorthin und lass diese sich im Sand eingraben. 
* Wenn die x-Koordinate in der linken Bildschirmhälfte liegt, bleibt unsere Turtle stehen. Sie will nicht hinunterfallen. Es soll also nichts passieren. 

**Hinweise:**
Verwende dazu folgende ``Prozeduren``:
* ``pendown()``: Die Turtle legt **einen** Faden am Boden ab. Diese malt dadruch Linien wenn diese sich **später** bewegt.
* ``goto(-100, 200)``: Die Turtle bewegt sich in einer *geraden Linie* zu der angegebenen *Position*. Die *Position* wird in *x* und *y* *Koordinaten* abegeben. Hier ist die Mitte des Fensters *x = 0* und *y = 0* ist.
* ``hideturtle()``: Die Turtle gräbt sich ein und versteckt sich.
* ``stamp()``: Die Turtle drückt sich auf den Boden und kann somit einen Faden befestigen.

Sowie folgende ``Funktionen``:
* ``randint(3, 8)``: Wir ziehen eine zufällige Zahl ohne Kommastellen von z.B. 3 bis 8. Wir wollen hier die Breite und Höhe des Fensters in der sich die Turtle befindet verwenden.
* ``window_width()``: Gibt die breite unseres Fenstes zurück. Merke dir die Antwort mit einer ``Variable``. Das geht so *breite = window_width()*.
* ``window_height()``: Gibt die breite unseres Fenstes zurück. Merke dir die Antwort mit einer ``Variable``. Das geht so *hoehe = window_height()*.

<div style="text-align: left;">
    <img style="" height="240" width="240" src="images/5.1.1-left.png">
    <img style="" height="240" width="240" src="images/5.1.1-right.gif">
</div>

```python
from turtle import *
from random import randint


# --- Vorbereitung ---
shape("turtle")
# Wir verwenden mit dem Wert 1 eine sichtbare Geschwindigkeit der Turtle.
speed(1)

# --- Logik ---
# Wir generierem zufällige Koordinaten innerhalb der Fenstergröße.
# Das Wort Zufall wird im Englischen das Wort random. 
breite = window_width()
hoehe = window_height()

# Die Division ergibt immer eine Kommazahl (float), auch wenn wir 4 / 2 = 2.0 rechnen.
# Wir müssen deshalb das Ergebnis in eine ganze zahl umwandlen. 
halbe_breite_ohne_komma = int(breite / 2) 
halbe_hoehe_ohne_komma = int(hoehe / 2)

# Info: Oder wir verwenden eine Division, wo eine Zahl ohne Komma rauskommt. Die Ganzzahldivision.
# Diese ist unter 5 dividiert durch 2 ist 2, mit 1 Rest bekannt und wird mit Python mit // geschrieben.
# Das 1 Rest wird hier mit // ignorieret.
# halbe_breite_ohne_komma = breite // 2 
# halbe_hoehe_ohne_komma = hoehe // 2

# Da wir zufällige Zahlen ohne Komma wollen, verwenden wir die Funktion randint.
# Der Name ist eine Kombination aus Random und Integer, was Zufall und Zahl ohne Komma bedeutet.
ziel_in_x = randint(-halbe_breite_ohne_komma, halbe_breite_ohne_komma)
ziel_in_y = randint(-halbe_hoehe_ohne_komma, halbe_hoehe_ohne_komma)

# Die Turtle bewegt sich nur zu den Koordinaten, wenn wir auf der rechten Bildschirmhälfte uns befinden.
if 5 > 0:
    # Hier ist die Einrückung wichtig! Drücke die Tabulator Taste dazu, (links neben dem Q).
    # Die Turtle drückt den Faden auf den Boden und machen damit einen Abdruck.
    stamp() 
    
    # Die Turtle holt den Faden aus der Tasche und legt diesen auf den Boden, wenn diese losgeht.
    pendown() 
    
    # Die Turtle geht in einer geraden linie zu den angegebenen Kooridinaten.
    goto(90, 50)

    # Am schluss gräbt sich die Turtle ein um im Sand zu schlafen.
    hideturtle() 
# else:
#     pass
    # Wenn die Turtle nach links gehen würde, dann mache nichts.
    # Wenn wir ansonsten (else) und mache nichts (pass) schreiben würden, können wir else und pass auch weglassen.

# --- Abschluss ---
# Schließt das Fenster nicht, wenn das Programm beendet ist.
done()
```

### Unterschiedliches Symbol pro Seite
Unsere Turtle steht am Rande des Meeres. Links von Ihr ist das Meer und rechts von ihr ist Sand. Die Turtle sich auf eine zufällige Position bewegen. Wenn die Turtle ins Meer geht, schwimmt sie. Ansonsten geht sie am Sand. Wenn die Turtle im Meer schwimmt, stelle sie als Kreis dar. Ansosnten stelle sie als Turtle, wie bisher dar. Am schluss taucht sie ab oder gräbt sich ein.

Verwende dazu folgende ``Prozeduren``:
* ``penup()``: Die Turtle legt **keinen** Faden am Boden ab. Diese malt dadruch **keine** Linien wenn diese sich **später** bewegt.
* ``goto(-100, 200)``: Die Turtle bewegt sich in einer *geraden Linie* zu der angegebenen *Position*. Die *Position* wird in *x* und *y* *Koordinaten* abegeben. Hier ist die Mitte des Fensters *x = 0* und *y = 0* ist.
* ``hideturtle()``: Die Turtle gräbt sich ein und versteckt sich.
* ``stamp()``: Die Turtle drückt sich auf den Boden und hinterlässt einen Abdruck.
* ``shape("turtle")`` oder ``shape("circle")``: Wir lassen unsere Turtle anders aussehen. Wir können folgende Werte übergeben ``"circle"`` und ``"turtle"``. 

Sowie folgende ``Funktionen``:
* ``randint(3, 8)``: Wir ziehen eine zufällige Zahl ohne Kommastellen von z.B. 3 bis 8.
* ``window_width()``: Gibt die breite unseres Fenstes zurück. Merke dir die Antwort mit einer ``Variable``. Das geht so *breite = window_width()*.
* ``window_height()``: Gibt die breite unseres Fenstes zurück. Merke dir die Antwort mit einer ``Variable``. Das geht so *hoehe = window_height()*.

**Hinweise:**
<div style="text-align: left;">
    <img style="" height="240" width="240" src="images/5.2-left.gif">
    <img style="" height="240" width="240" src="images/5.2-right.gif">
</div>

```python
from turtle import *
from random import randint

# --- Vorbereitung ---
title("Übung 5.2: Anderes Symbol")
speed(1) # Wir verwenden mit dem Wert 1 eine sichtbare Geschwindigkeit der Turtle.

# --- Logik ---
# Wir generierem zufällige Koordinaten innerhalb der Fenstergröße.
# Das Wort Zufall wird im Englischen das Wort random. 
# Da wir zufällige Zahlen ohne Komma wollen, verwenden wir die Funktion randint.
# Der Name ist eine Kombination aus Random und Integer, was Zufall und Zahl ohne Komma bedeutet.
# TODO: Lösche dieses Kommetar und schreibe den Programmcode hier!

# Wir bewegen die Turtle und passen an wie diese dargestellt wird (Kreis oder Turtle). 
# TODO: Lösche dieses Kommetar und schreibe den Programmcode hier!

# --- Abschluss ---
exitonclick() # Das Fenster wird geschlossen, wenn wir mit der Maus in das Fenster klicken.
```