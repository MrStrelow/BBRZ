## Userinput als Events mit Turtle
### Mausgesteuerte Bewegung
Wir legen unserer Turtle mit der Maus Seegras irgendwo am Bildschirm hin. Wir drücken dazu mit der Linken Maustaste auf einen Ort am Bildschirm.
Die Turtle bewegt sich anschließend dorthin und macht einen Abdruck von sich selbst um sich zu merken wo einmal ein Seegras hingelegt worden ist. Wenn wir auf einen anderen Ort klicken, bewegt sich die Turtle auch dorthin und macht weider einen Abdruck. Dieses verhalten wiederholt sich bis wir das Fenster rechts oben beim X schließen.

Verwende dazu folgende ``Prozeduren``:
* ``penup()``: Hebe die Turtle in die Luft. Diese malt dadruch **keine** Linien wenn diese sich später bewegt.
* ``goto(-100, 200)``: Die Turtle bewegt sich in einer *geraden Linie* zu der angegebenen *Position*. Die *Position* wird in *x* und *y* *Koordinaten* abegeben, wobei die Mitte des Fensters *x = 0* und *y = 0* ist.
* ``hideturtle()``: Die Turtle gräbt sich ein und versteckt sich.
* ``stamp()``: Die Turtle drückt sich auf den Boden und hinterlässt einen Abdruck.

Sowie folgende ``Funktionen``:
* * ``onclick(meine_funktion)``: *meine_funktion* ist eine eigens geschriebene ``Funktion`` welche ausgeführt wird, wenn wir auf den Bildschirm drücken. Sperre zudem den Bildschirm mit ``screen.onclick(None)``, damit kein Mausclick mehr akzeptiert wird.

**Hinweise:**
<div style="text-align: left;">
    <img style="" height="240" width="240" src="../images/7.4.gif">
</div>

```python
from turtle import *

# --- Vorbereitung # ---
screen = Screen()
screen.title("Übung 7.4: Maussteuerung")
shape('turtle')
speed(3)

# --- Eigene Funktionen # ---
# Diese Funktion wird aufgerufen, wenn der Benutzer auf den Bildschirm klickt
def bewege_turtle(x, y):
    goto(x, y) # Bewege die Turtle zu den geklickten Koordinaten
    stamp() # Wir drücken die Turtle auf den Boden und machen damit einen Abdruck.

# --- Logik # ---
penup()

# Diese Funktion ist eine komplizierte. Wir behandeln dies nur weil es im Lehrplan steht.
# Diese horch auf einen Klick mit der Maus. Wir nennen das ein Event. Wenn dieses Event passiert, führen wir den Code in der eigens geschriebenen Funktion bewege_turtle aus. Wir erreichen das, wenn wir den Namen der Funktion übergeben. Wir verwenden die Funktion damit als Variable. Der Aufruf der Funktion passiert dann innerhalb von onclick und ist nicht mehr für uns ersichtlich.
# Zudem lebt diese ``Funktion`` bei der ``Variable`` screen. Wir können dies deshalb nur aufrufen wenn wir davor screen mit einem Punkt danach schreiben.
screen.onclick(bewege_turtle)

# --- Abschluss # ---
# Das hier ist eine Art Schleife. Wir lassen das Programm laufen und wenn ein Event passiert, dann führen wir dieses aus.
screen.mainloop()
```


### Farbige Punkte - Mehrfachverzweigung
Verwende dazu folgende ``Prozeduren``:
* ``penup()``: Hebe die Turtle in die Luft. Diese malt dadruch **keine** Linien wenn diese sich später bewegt.
* ``goto(-100, 200)``: Die Turtle bewegt sich in einer *geraden Linie* zu der angegebenen *Position*. Die *Position* wird in *x* und *y* *Koordinaten* abegeben, wobei die Mitte des Fensters *x = 0* und *y = 0* ist.
* ``hideturtle()``: Die Turtle gräbt sich ein und versteckt sich.
* ``dot(...)``: TODO

Sowie folgende ``Funktionen``:
* * ``onclick(meine_funktion)``: *meine_funktion* ist eine eigens geschriebene ``Funktion`` welche ausgeführt wird, wenn wir auf den Bildschirm drücken. Sperre zudem den Bildschirm mit ``screen.onclick(None)``, damit kein Mausclick mehr akzeptiert wird.
Unsere Turtle fängt an zu graben. Was sich unter dem Sand verbrigt weiß sie noch nicht. Hilf den Ort mit der Maus zu zeigen wo sie Graben soll.

#### Fenster Form
Wenn der Benutzer klickt, erscheint ein großer Punkt (ca. 1 cm Durchmesser). Die Farbe des Punktes hängt vom Quadranten des Klicks ab: 
* oben links ist rot, 
* oben rechts blau,
* unten links grün und 
* unten rechts gelb.

```python
from turtle import *

# --- Vorbereitung # ---
screen = Screen()
screen.title("Übung 7.5: Farbige Punkte - Mehrfachverzweigung")
hideturtle()
speed("fastest")
penup()

# --- Logik # ---
DOT_DIAMETER = 80

def draw_colored_dot(x, y):
    goto(x, y)

    # Farbe basierend auf dem Quadranten bestimmen
    if x < 0 and y > 0: # Oben Links
        dot(DOT_DIAMETER, "red")
    elif x > 0 and y > 0: # Oben Rechts
        dot(DOT_DIAMETER, "blue")
    elif x < 0 and y < 0: # Unten Links
        dot(DOT_DIAMETER, "green")
    else: # Unten Rechts
        dot(DOT_DIAMETER, "yellow")

# Auf Klicks lauschen
screen.onclick(draw_colored_dot)

# --- Abschluss # ---
screen.mainloop()
```

#### Streifen
Zeichne Steifen von oben nach unten. Wenn der Benutzer klickt, erscheint ein großer Punkt (40 Pixel an Durchmesser). Die Farbe hängt ab in welchen Steifen wir graben: 
1. Steifen ganz links ist grün.
2. Steifen links ist violett.
3. Steifen in der Mitte ist orange.
4. Steifen rechts ist blau.
5. Steifen ganz rechts ist rot.

```python
from turtle import *

# --- Vorbereitung # ---
screen = Screen()
title("Übung 7.6: Farbige Punkte - Mehrfachverzweigung")
breite = window_width()
hideturtle()
speed("fastest")

# Vertikale Streifen zeichnen
# Für 5 Streifen brauchen wir 4 Trennlinien.
# Jede Linie ist bei einem Fünftel der Breite verschoben.
# Die Koordinaten gehen von -breite/2 bis +breite/2.
# Positionen der Linien: -3/10, -1/10, +1/10, +3/10 der Breite
linie1_x = -breite * 0.3
linie2_x = -breite * 0.1
linie3_x = breite * 0.1
linie4_x = breite * 0.3
    
penup()

# --- Logik # ---
groesse_des_punktes = 40

def zeichne_bunten_punkt(x, y):
    penup() 
    goto(x, y)

    # Farbe basierend auf expliziter Bereichslogik bestimmen
    
    # Streifen 1 (ganz links)
    if x <= linie1_x:
        dot(groesse_des_punktes, "green")
        
    # Streifen 2 (links)
    elif linie1_x < x and x <= linie2_x:
        dot(groesse_des_punktes, "violet")
        
    # Streifen 3 (Mitte)
    elif linie2_x < x and x <= linie3_x:
        dot(groesse_des_punktes, "orange")
        
    # Streifen 4 (rechts)
    elif linie3_x < x and x <= linie4_x:
        dot(groesse_des_punktes, "blue")
        
    # Streifen 5 (ganz rechts)
    elif linie4_x < x:
        dot(groesse_des_punktes, "red")

# Auf Klicks lauschen
screen.onclick(zeichne_bunten_punkt)

# --- Abschluss # ---
screen.mainloop()
```

### Bewegen mit der Tastatur
Wir wollen nun die Turtle mit der Tastatur steuern.

Verwende dazu folgende ``Prozeduren``:
* ``penup()``: Hebe die Turtle in die Luft. Diese malt dadruch **keine** Linien wenn diese sich später bewegt.
* ``goto(-100, 200)``: Die Turtle bewegt sich in einer *geraden Linie* zu der angegebenen *Position*. Die *Position* wird in *x* und *y* *Koordinaten* abegeben, wobei die Mitte des Fensters *x = 0* und *y = 0* ist.
* ``hideturtle()``: Die Turtle gräbt sich ein und versteckt sich.
* ``dot(...)``: TODO

Sowie folgende ``Funktionen``:
* * ``onclick(meine_funktion)``: *meine_funktion* ist eine eigens geschriebene ``Funktion`` welche ausgeführt wird, wenn wir auf den Bildschirm drücken. Sperre zudem den Bildschirm mit ``screen.onclick(None)``, damit kein Mausclick mehr akzeptiert wird.
Unsere Turtle fängt an zu graben. Was sich unter dem Sand verbrigt weiß sie noch nicht. Hilf den Ort mit der Maus zu zeigen wo sie Graben soll


```python
from turtle import *

# --- Vorbereitung # ---
bildschirm = Screen()
bildschirm.title("Steuere die Turtle mit den Pfeiltasten")

# Erstellen unserer Helden-Turtle
held = Turtle()
held.shape("turtle")
held.shapesize(2)
held.color("darkgreen")
held.penup()

# --- Logik # ---
# Wir definieren, wie weit die Turtle bei jedem Tastendruck gehen soll.
SCHRITTWEITE = 20

# Wir brauchen vier separate Funktionen, eine für jede Pfeiltaste.

def gehe_hoch():
    """Setzt die Ausrichtung nach oben (90 Grad) und geht einen Schritt."""
    held.setheading(90)
    held.forward(SCHRITTWEITE)

def gehe_runter():
    """Setzt die Ausrichtung nach unten (270 Grad) und geht einen Schritt."""
    held.setheading(270)
    held.forward(SCHRITTWEITE)

def gehe_links():
    """Setzt die Ausrichtung nach links (180 Grad) und geht einen Schritt."""
    held.setheading(180)
    held.forward(SCHRITTWEITE)

def gehe_rechts():
    """Setzt die Ausrichtung nach rechts (0 Grad) und geht einen Schritt."""
    held.setheading(0)
    held.forward(SCHRITTWEITE)


# --- Ereignis-Verknüpfung (Event Binding) ---
# Damit Tastendrücke erkannt werden, müssen wir zwei Dinge tun:
# 1. Dem Bildschirm sagen, dass er "zuhören" soll.
bildschirm.listen()

# 2. Jede Taste mit der Funktion verknüpfen, die sie auslösen soll.
# Die Namen für die Pfeiltasten sind: "Up", "Down", "Left", "Right"
bildschirm.onkey(gehe_hoch, "Up")
bildschirm.onkey(gehe_runter, "Down")
bildschirm.onkey(gehe_links, "Left")
bildschirm.onkey(gehe_rechts, "Right")


# --- Abschluss # ---
# Hält das Fenster offen und wartet auf Tastendrücke.
bildschirm.mainloop()
```