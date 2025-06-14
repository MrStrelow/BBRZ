## Funktionen und Prozeduren aufrufen mit Turtle - Ausgabe und Berechnungen
### Aufgabe 1) - Was ist nun der Umfang von Haus und Garten?
Es liegen nun zwei Fäden nach der [Exercise 1](../../exercise1-werte_und_variablen_als_parameter/angabe.md) am Boden. Einer für den Garten und einer für das Haus. 
* Verwende nun zwei verschiedene Farben für die Fäden. Ein mal einen <span style="color:orange;">orangen Faden</span> für den Garten und einen <span style="color:purple;">violetten Faden</span> für das Haus um die Schnüre besser unterscheiden zu können. 
* Wir messen nun nach jeder Bewegung die Schnüre ab. Berechne den Umfang des Hauses, indem bei jedem Aufruf von ``forward(laenge_hause)`` die ``Variable`` ``umgang_haus`` um die ``laenge_haus`` erhöht wird. Gleiches gilt für den ``umfang_garten``. Wir geben am Schluss des Programmes den Umfang des Gartens und Hauses in der Console ``print``aus.

**Hinweise:**
Verwende nun ``Variablen`` für:
* die Länge des Gartens und des Hauses,
* den Winkel für die Drehung und
* den Umfang des Gartens und des Hauses

Zeichne dazu ein kleines Quadrat mit folgenden ``Prozeduren``.
* ``forward(laenge_garten)``: Die Turtle bewegt sich *laenge_garten* Schritte nach vorne. Vorne ist hier die *Blickrichtung* der Turtle.
* ``left(winkel)``: Die Turtle dreht sich um *winkel* nach links.
* ``stamp()``: Die Turtle drückt sich auf den Boden und hinterlässt einen Abdruck.
* ``hideturtle()``: Die Turtle gräbt sich ein und versteckt sich.
* ``goto(-laenge_garten/2, -laenge_garten/2)``: Die Turtle bewegt sich in einer *geraden Linie* zu der angegebenen *Position*. Die *Position* wird in *x* und *y* *Koordinaten* abegeben. Hier ist die Mitte des Fensters *x = 0* und *y = 0* ist.
* ``penup()``: Die Turtle legt **keinen** Faden am Boden ab. Diese malt dadruch **keine** Linien wenn diese sich **später** bewegt.
* ``pendown()``: Die Turtle legt **einen** Faden am Boden ab. Diese malt dadruch Linien wenn diese sich **später** bewegt.
* ``color("orange")``: Die Turtle malt orange Linien am Bildschirm.
* ``print(umfang_garten, umfang_haus)``: Mit dieser ``Prozedur`` kann eine Variable für den Umfang des Gartens und eine Variable für den Umfang des Hauses auf die Console ausgegeben werden.

<div style="text-align: left;">
    <img style="" height="240" width="240" src="../images/4.2.gif">
</div>

```python
from turtle import *

# --- Vorbereitung ---
shape("turtle")
speed(1) # Wir verwenden mit dem Wert 1 eine sichtbare Geschwindigkeit der Turtle.

# --- Logik ---
# ------------------------------------------------------------------------
# Wir legen Variablen an welche wir später wiederverwenden können.
laenge_garten = 314
winkel = 90
umfang_haus = 0   
umfang_garten = 0 

# --- 1. Usere Turtle geht zur Ecke des Garten welche links-unten ist. ---
# Die Turtle verwendet eine orange Schnur für den Garten.
color("orange")

# Die Turtle packt den Faden in die Tasche.
penup()

# Die Turtle geht in die Ecke welche links-unten ist.
ecke_garten_links_unten_x = -laenge_garten/2
ecke_garten_links_unten_y = -laenge_garten/2
goto(ecke_garten_links_unten_x, ecke_garten_links_unten_y)

# Die Turtle nimmt den Faden aus der Tasche und legen ihn am Boden, wenn wir uns Bewegen.
pendown()

# ------------------------------------------------------------------------
# --- 2. Wir zeichnen den quadratischen Garten ---
# --- 2.1) Wir zeichnen eine horizontale Linie von links nach rechts ---
# Die Turtle drückt den Faden auf den Boden und befestigt diesen
stamp()

# Die Turtle bewegt sich 314 Schritte in Blickrichtung nach vorne.
forward(laenge_garten)

# Wir zählen zu umfang_garten die laenge_garten dazu und merken es wieder in umfang_garten
umfang_garten += laenge_garten

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# --- 2.2) Wir zeichnen eine vertikale Linie von unten nach oben ---
# Die Turtle drückt den Faden auf den Boden und befestigt diesen
stamp() 

# Die Turtle bewegt sich 314 Schritte in Blickrichtung nach vorne.
forward(laenge_garten)

# Wir zählen zu umfang_garten die laenge_garten dazu und merken es wieder in umfang_garten
umfang_garten += laenge_garten

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# --- 2.3) Wir zeichnen eine horizontale Linie von rechts nach links ---
# Die Turtle drückt den Faden auf den Boden und befestigt diesen
stamp()

# Die Turtle bewegt sich 314 Schritte in Blickrichtung nach vorne.
forward(laenge_garten)

# Wir zählen zu umfang_garten die laenge_garten dazu und merken es wieder in umfang_garten
umfang_garten += laenge_garten

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# --- 2.4) Wir zeichnen eine vertikale Linie von oben nach unten ---
# Die Turtle drückt den Faden auf den Boden und befestigt diesen
stamp()

# Die Turtle bewegt sich 314 Schritte in Blickrichtung nach vorne.
forward(laenge_garten)

# Wir zählen zu umfang_garten die laenge_garten dazu und merken es wieder in umfang_garten
umfang_garten += laenge_garten

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# ------------------------------------------------------------------------
# --- 3. Usere Turtle geht zur Ecke des Hauses welche links-unten ist. ---
# Die Turtle verwendet eine violette Schnur für den Garten.
color("purple")

# Die Turtle packt den Faden in die Tasche.
penup()

# Die Turtle geht in die Ecke welche links-unten ist.
laenge_haus = laenge_garten / 2
ecke_haus_links_unten_x = -laenge_haus/2
ecke_haus_links_unten_y = -laenge_haus/2
goto(ecke_haus_links_unten_x, ecke_haus_links_unten_y)

# Die Turtle nimmt den Faden aus der Tasche und legen ihn am Boden, wenn wir uns Bewegen.
pendown()

# ------------------------------------------------------------------------
# --- 4. Wir zeichnen das quadratischen Haus ---
# --- 4.1) Wir zeichnen eine horizontale Linie von links nach rechts ---
# Die Turtle bewegt sich 157 Schritte in Blickrichtung nach vorne.
forward(laenge_haus)

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# Wir zählen zu umfang_haus die laenge_haus dazu und merken es wieder in umfang_haus
umfang_haus += laenge_haus

# --- 4.2) Wir zeichnen eine vertikale Linie von unten nach oben ---
# Die Turtle bewegt sich 157 Schritte in Blickrichtung nach vorne.
forward(laenge_haus)

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# Wir zählen zu umfang_haus die laenge_haus dazu und merken es wieder in umfang_haus
umfang_haus += laenge_haus

# --- 4.3) Wir zeichnen eine horizontale Linie von rechts nach links ---
# Die Turtle bewegt sich 157 Schritte in Blickrichtung nach vorne.
forward(laenge_haus)

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# Wir zählen zu umfang_haus die laenge_haus dazu und merken es wieder in umfang_haus
umfang_haus += laenge_haus

# --- 4.4) Wir zeichnen eine vertikale Linie von oben nach unten ---
# Die Turtle bewegt sich 157 Schritte in Blickrichtung nach vorne.
forward(laenge_haus)

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# Wir zählen zu umfang_haus die laenge_haus dazu und merken es wieder in umfang_haus
umfang_haus += laenge_haus

# --- 5.) Wir geben den Umfang des Gartens und des Hauses auf der Console aus
print("Umfang-Garten: ", umfang_garten, " ~ Umfang-Haus",  umfang_haus)

# ------------------------------------------------------------------------
# --- Abschluss ---
# Schließt das Fenster nicht, wenn das Programm beendet ist.
done()
```

### Aufgabe 2) - Wo bin ich und wohin gehe ich?
Wiederhole das vorherige Beispiel, jedoch will unsere Turtle nicht verloren gehen. Diese schreibt auf den Boden nun die Koordinaten an der sie sich befindet und die Richtung in diese sie schaut. 

**Hinweise:**
Verwende nun ``Variablen`` für:
* die Länge des Gartens und des Hauses,
* den Winkel für die Drehung und
* den Umfang des Gartens und des Hauses

Zeichne dazu ein kleines Quadrat mit folgenden ``Prozeduren``.
* ``forward(laenge_garten)``: Die Turtle bewegt sich *laenge_garten* Schritte nach vorne. Vorne ist hier die *Blickrichtung* der Turtle.
* ``left(winkel)``: Die Turtle dreht sich um *winkel* nach links.
* ``stamp()``: Die Turtle drückt sich auf den Boden und hinterlässt einen Abdruck.
* ``hideturtle()``: Die Turtle gräbt sich ein und versteckt sich.
* ``goto(-laenge_garten/2, -laenge_garten/2)``: Die Turtle bewegt sich in einer *geraden Linie* zu der angegebenen *Position*. Die *Position* wird in *x* und *y* *Koordinaten* abegeben. Hier ist die Mitte des Fensters *x = 0* und *y = 0* ist.
* ``penup()``: Die Turtle legt **keinen** Faden am Boden ab. Diese malt dadruch **keine** Linien wenn diese sich **später** bewegt.
* ``pendown()``: Die Turtle legt **einen** Faden am Boden ab. Diese malt dadruch Linien wenn diese sich **später** bewegt.
* ``color("orange")``: Die Turtle malt orange Linien am Bildschirm.
* ``print(umfang_garten, umfang_haus)``: Mit dieser ``Prozedur`` kann eine Variable für den Umfang des Gartens und eine Variable für den Umfang des Hauses auf die Console ausgegeben werden.

Finde mit folgenden ``Funktionen`` heraus in welche Richtung unsere Turtle schaut und an welcher Position sie sich befindet.
* ``position()``: Gibt dir die aktuelle Position der Turtle zurück.
* ``heading()``: Gibt dir die Richtung in die unsere Turtle schaut zurück.

Zeichne ein kleines Quadrat zentriert in einem größeren Quadrat mit folgenden ``Prozeduren``.
* ``penup()``: Die Turtle legt **keinen** Faden am Boden ab. Diese malt dadruch **keine** Linien wenn diese sich **später** bewegt.
* ``pendown()``: Die Turtle legt **einen** Faden am Boden ab. Diese malt dadruch Linien wenn diese sich **später** bewegt.
* ``forward(200)``: Die Turtle bewegt sich 200 Schritte nach vorne. Vorne ist hier die *Blickrichtung* der Turtle.
* ``left(90)``: Die Turtle dreht sich um 90° nach links.
* ``goto(-100, 200)``: Die Turtle bewegt sich in einer *geraden Linie* zu der angegebenen *Position*. Die *Position* wird in *x* und *y* *Koordinaten* abegeben. Hier ist die Mitte des Fensters *x = 0* und *y = 0* ist.
* ``hideturtle()``: Die Turtle gräbt sich ein und versteckt sich.
* ``color("orange")``: Die Turtle malt orange Linien am Bildschirm.
* ``print(umfang_garten, umfang_haus)``: Mit dieser ``Prozedur`` kann eine Variable für den Umfang des Gartens und eine Variable für den Umfang des Hauses auf die Console ausgegeben werden.

**Hinweise:**
<div style="text-align: left;">
    <img style="" height="240" width="240" src="../images/4.3.gif">
</div>

```python
from turtle import *

# --- Vorbereitung ---
title("Übung 1.3: Verschachtelte Quadrate - Wo bin ich und wohin gehe ich?")
shape("turtle")
speed(1) # Wir verwenden mit dem Wert 1 eine sichtbare Geschwindigkeit der Turtle.

# --- Logik ---
# --- Äußeres Quadrat zeichnen (z.B. 200x200) ---
# Wir verwenden die orange Schnur für den Garten.
color("orange")
so_weit_gehe_ich = 200
so_viel_drehe_ich_mich = 90

penup()
neuer_ort = -so_weit_gehe_ich/2
goto(neuer_ort, neuer_ort)
pendown()

# Erste Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)
write("Pos: " + str(position()) + "\n" + "Richtung: " + str(heading()))

# Zweite Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)
write("Pos: " + str(position()) + "\n" + "Richtung: " + str(heading()))

# Dritte Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)
write("Pos: " + str(position()) + "\n" + "Richtung: " + str(heading()))

# Vierte Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)
write("Pos: " + str(position()) + "\n" + "Richtung: " + str(heading()))


# --- Inneres Quadrat zeichnen (z.B. 100x100) ---
penup()
neuer_ort = -so_weit_gehe_ich/4
goto(neuer_ort, neuer_ort)

pendown()
# Wir verwenden die violette Schnur für das Haus.
color("purple")
so_weit_gehe_ich = so_weit_gehe_ich / 2
# so_weit_gehe_ich /= 2 # Wir können es kürzer mithilfe des gemischten Operators /= schreiben. Diese ist eine division und Zuweisung  in einer Zeile.

# Erste Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
# wir erhöhen die variable umfang_haus
left(so_viel_drehe_ich_mich)
write("Pos: " + str(position()) + "\n" + "Richtung: " + str(heading()))

# Zweite Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)
write("Pos: " + str(position()) + "\n" + "Richtung: " + str(heading()))

# Dritte Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)
write("Pos: " + str(position()) + "\n" + "Richtung: " + str(heading()))

# Vierte Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)
write("Pos: " + str(position()) + "\n" + "Richtung: " + str(heading()))

hideturtle()

# --- Abschluss ---
done() # Schließt das Fenster nicht, wenn das Programm beendet ist.
```

### Renovierung des Hauses
Nach der Abmessung des Hauses und des Gartens kommt der Turtle eine Idee. Sie will ihr Haus drehen und ein wenig vergrößern. Auch sollen die weiße Wand verschwinden und <span style="color:purple;">violett</span> eingefärbt werden. Im Garten sollen zudem Sand gestreut werden, welcher den Garten <span style="color:orange;">orange</span> färbt. 

Wiederhole vorheriges Programm jedoch drehe das innere Quadrat um 45 Grad. Die Eckpunkte des inneren Quadrats liegen auf den Mittelpunkten der äußeren Seiten.
Die Fläche des inneren Quadrats soll soll <span style="color:purple;">violett</span> gefüllt werden und die des außeren <span style="color:orange;">orange</span>.

Verwende folgende ``Prozeduren``:
* ``penup()``: Die Turtle legt **keinen** Faden am Boden ab. Diese malt dadruch **keine** Linien wenn diese sich **später** bewegt.
* ``pendown()``: Die Turtle legt **einen** Faden am Boden ab. Diese malt dadruch Linien wenn diese sich **später** bewegt.
* ``forward(200)``: Die Turtle bewegt sich 200 Schritte nach vorne. Vorne ist hier die *Blickrichtung* der Turtle.
* ``left(90)``: Die Turtle dreht sich um 90° nach links.
* ``goto(-100, 200)``: Die Turtle bewegt sich in einer *geraden Linie* zu der angegebenen *Position*. Die *Position* wird in *x* und *y* *Koordinaten* abegeben. Hier ist die Mitte des Fensters *x = 0* und *y = 0* ist.
* ``hideturtle()``: Die Turtle gräbt sich ein und versteckt sich.
* ``color("purple", "purple")``: Die Turtle wird violett und malt violette Linien am Bildschirm. Dazu wird die Turtle violett ausgemalen. Rufe ``begin_fill()`` auf um den *Füllmodus* zu starten und ``end_fill()`` um diesen zu beenden.

**Hinweise:**
<div style="text-align: left;">
    <img style="" height="240" width="240" src="../images/4.4.gif">
</div>

```python
from turtle import *
from math import sqrt

# --- Vorbereitung ---
title("Übung 1.3: Renoviertes Haus")
shape('turtle')
speed(1)

# --- Äußeres Quadrat ---
so_weit_gehe_ich = 200
so_viel_drehe_ich_mich = 90

penup()
neuer_ort = -so_weit_gehe_ich/2
goto(neuer_ort, neuer_ort)
pendown()

# Es wird die Farbe der Linien für das äußere Quadrat festgelegt.
color("orange", "orange") # Linienfarbe orange, Füllfarbe orange
begin_fill() # Wir starten das Ausmalen der Form. Wenn wir später end_fill() verwenden wird die Farbe reingemalen. 

# Erste Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)

# Zweite Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)

# Dritte Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)

# Vierte Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)

end_fill()
# --- Inneres gedrehtes Quadrat ---
# Die Eckpunkte des inneren Quadrats liegen auf den Mittelpunkten der äußeren Seiten.
# Pythagoras: Hypothenuse^2 = Ankathete^2 + Gegenkathete^2
# Wir wollen die Hypothenuse ohne Quadrat. Wir ziehen deshalb die Wurzel links und rechts vom =. 
# Hypothenuse = wurzel(Ankathete^2 + Gegenkathete^2)
# Die Wurzel heißt auf Englisch square root (Abkürzung sqrt).
# Diese Funktion können wir verwenden, wenn wir ganz oben from math import sqrt schreiben.
ankathete = so_weit_gehe_ich / 2
gegenkathete = so_weit_gehe_ich / 2
laenge_des_inneren_quadrats = sqrt(ankathete**2 + gegenkathete**2) # Quadrieren wird in Python mit dem Operator ** umgesetzt.

penup()
goto(0, -so_weit_gehe_ich / 2) # Zum Mittelpunkt der unteren Seite gehen
left(so_viel_drehe_ich_mich / 2) # 45 Grad drehen, um das innere Quadrat zu beginnen
pendown()

color("purple", "purple") # Linienfarbe violett, Füllfarbe violett
begin_fill() # Wir starten das Ausmalen der Form. Wenn wir später end_fill() verwenden wird die Farbe reingemalen. 

# Erste Vorwärtsbewegung mit der Schnur
forward(laenge_des_inneren_quadrats)
left(so_viel_drehe_ich_mich)

# Zweite Vorwärtsbewegung mit der Schnur
forward(laenge_des_inneren_quadrats)
left(so_viel_drehe_ich_mich)

# Dritte Vorwärtsbewegung mit der Schnur
forward(laenge_des_inneren_quadrats)
left(so_viel_drehe_ich_mich)

# Vierte Vorwärtsbewegung mit der Schnur
forward(laenge_des_inneren_quadrats)
left(so_viel_drehe_ich_mich)

end_fill()
hideturtle()

# --- Abschluss ---
exitonclick() # Schließt das Fenster nicht, wenn das Programm beendet ist.
```