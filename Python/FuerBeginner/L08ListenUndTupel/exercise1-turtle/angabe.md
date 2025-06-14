## Userinput auf der Console mit Turtle
### Wiederholte Bewegung mit Userinput - für immer
Unsere Turtle will wieder die Welt erforschen. Dazu mekrt sich unsere Turtle am Anfang wo sie gestartet ist. Das ist auf der Position *x=0* und *y=0*. Sie steht also wieder am Rande des Meeres. Links von ihr ist das Meer und rechts von ihr ist Sand. Nun wiederholt sie folgendes Verhalten **für immer**. Die Turtle bewegt sich auf **ein vom User gewählte Position** und **markiert** diese. Sie *gräbt* sich nicht mehr ein, sondern bewegt sich zu ihrer Markierung in der Mitte zurück. Wenn sie in der Mitte angekommen ist, geht sie zur nächsten **vom User gewählten** Position. Wenn die Turtle ins Meer geht, schwimmt sie. Ansonsten geht sie am Sand. Wenn die Turtle im Meer schwimmt, stelle sie als Kreis dar. Ansonsten stelle sie als Turtle, wie bisher dar. 

Verwende dazu folgende ``Prozeduren``:
* ``penup()``: Die Turtle legt **keinen** Faden am Boden ab. Diese malt dadruch **keine** Linien wenn diese sich **später** bewegt.
* ``goto(-100, 200)``: Die Turtle bewegt sich in einer *geraden Linie* zu der angegebenen *Position*. Die *Position* wird in *x* und *y* *Koordinaten* abegeben. Hier ist die Mitte des Fensters *x = 0* und *y = 0* ist.
* ``hideturtle()``: Die Turtle gräbt sich ein und versteckt sich.
* ``stamp()``: Die Turtle drückt sich auf den Boden und hinterlässt einen Abdruck.
* ``shape("turtle")`` oder ``shape("circle")``: Wir lassen unsere Turtle anders aussehen. Wir können folgende Werte übergeben ``"circle"`` und ``"turtle"``. 

Sowie folgende ``Funktionen``:
* ``input("Gib bitte die neue Position in x ein: ")``: Das Programm wartet bis der user etwas eingegeben hat. Davor schreiben wir *"Gib bitte die neue Position in x und dann y ein: "* auf die Console damit die Benutzer:innen wissen was sie tun soll.

**Hinweise:**
<div style="text-align: left;">
    <img style="" height="240" width="240" src="../images/7.1.gif">
</div>

```python
from turtle import *
from random import randint

# --- Vorbereitung (passiert nur einmal) ---
title("Übung 7.1: Wiederholte Bewegung mit Userinput - für immer")
shape('turtle')
speed(1) # Etwas schneller, da wir mehrere Bewegungen haben
penup() # Wir heben die Turtle nur einmal am Anfang auf.

# --- Logik ---
# Wir drücken die Turtle auf den Boden und machen damit einen Abdruck. Dadruch merkt sie sich wo sie gestartet ist.
stamp() 
penup() # Wir heben die Turtle auf, damit wir keine Linie zeichnen.

while True:
    ziel_in_x = ...
    ziel_in_y = ...

    # Wir bewegen die Turtle und passen an wie diese dargestellt wird (Kreis oder Turtle). 
    if ziel_in_x > 0:
        shape('turtle') # Wir verwenden die Form für die rechte Seite auf 'turtle' setzen
    else:
        shape('circle') # Form für die linke Seite auf 'circle' setzen

    # Wir bewegen uns zur zufällig gewählten Position.
    goto(ziel_in_x, ziel_in_y)
    print("Ziel erreich!🏁 Drehe um.🔁")
    # Wir bewegen uns zur Ausgangsposition zurück.
    goto(0, 0)

# --- Abschluss ---
```