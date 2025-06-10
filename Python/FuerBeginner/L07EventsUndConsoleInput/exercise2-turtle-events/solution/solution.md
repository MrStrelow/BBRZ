## Events mit Turtle
### Mausgesteuerte Bewegung
Wir legen unserer Turtle mit der Maus Seegras irgendwo am Bildschirm hin. Wir drücken dazu mit der Linken Maustaste auf einen Ort am Bildschirm.
Die Turtle bewegt sich anschließend dorthin und macht einen Abdruck von sich selbst um sich zu merken wo einmal ein Seegras hingelegt worden ist. Wenn wir auf einen anderen Ort klicken, bewegt sich die Turtle auch dorthin und macht weider einen Abdruck. Dieses verhalten wiederholt sich bis wir das Fenster rechts oben beim X schließen.

Verwende dazu folgende ``Funktionen``:
* ``xcor()``: 
* ``onclick(meine_funktion)``: *meine_funktion* ist eine eigens geschriebene ``Funktion`` welche ausgeführt wird, wenn wir auf den Bildschirm drücken. Sperre zudem den Bildschirm mit ``screen.onclick(None)``, damit kein Mausclick mehr akzeptiert wird.
* ``penup()``: Hebe die Turtle in die Luft. Diese malt dadruch **keine** Linien wenn diese sich später bewegt.
* ``goto(-100, 200)``: Die Turtle bewegt sich in einer *geraden Linie* zu der angegebenen *Position*. Die *Position* wird in *x* und *y* *Koordinaten* abegeben, wobei die Mitte des Fensters *x = 0* und *y = 0* ist.
* ``hideturtle()``: Die Turtle gräbt sich ein und versteckt sich.
* ``randint(3, 8)``: Wir ziehen eine zufällige Zahl ohne Kommastellen von z.B. 3 bis 8.
* ``stamp()``: Die Turtle drückt sich auf den Boden und hinterlässt einen Abdruck.
* ``window_width()``: Gibt die breite unseres Fenstes zurück. Merke dir die Antwort mit einer ``Variable``. Das geht so *breite = window_width()*.
* ``window_height()``: Gibt die breite unseres Fenstes zurück. Merke dir die Antwort mit einer ``Variable``. Das geht so *hoehe = window_height()*.

**Hinweise:**
<div style="text-align: left;">
    <img style="" height="240" width="240" src="images/2.1-left.png">
    <img style="" height="240" width="240" src="images/2.1-right.gif">
</div>

#### Vatiante 2

```python
from turtle import *

# --- Vorbereitung # ---
screen = Screen()
screen.title("Übung 3.1: Maussteuerung")
shape('turtle')
speed(8)

# --- Eigene Funktionen # ---
# Diese Funktion wird aufgerufen, wenn der Benutzer auf den Bildschirm klickt
def bewege_turtle(x, y):
    goto(x, y) # Bewege die Turtle zu den geklickten Koordinaten
    stamp() # Wir drücken die Turtle auf den Boden und machen damit einen Abdruck.

# --- Logik # ---
penup()
# Dem Bildschirm sagen, dass er die Funktion move_turtle bei jedem Klick aufrufen soll
screen.onclick(bewege_turtle)

# --- Abschluss # ---
# Hält die Hauptprogrammschleife am Laufen, um auf Ereignisse zu warten
screen.mainloop()
```


### Farbige Punkte pro Quadrant bei Klick
Zeichne ein Fadenkreuz. Wenn der Benutzer klickt, erscheint ein großer Punkt (ca. 1 cm Durchmesser). Die Farbe des Punktes hängt vom Quadranten des Klicks ab: 
* oben links ist rot, 
* oben rechts blau,
* unten links grün und 
* unten rechts gelb.

```python
import turtle

# # --- Vorbereitung # ---
screen = turtle.Screen()
screen.title("Übung 3.2: Quadranten-Punkte")
screen_width = screen.window_width()
screen_height = screen.window_height()
t = turtle.Turtle()
t.hideturtle()
t.speed(0)

# --- Fadenkreuz zeichnen # ---
t.penup()
t.goto(-screen_width/2, 0)
t.pendown()
t.goto(screen_width/2, 0)
t.penup()
t.goto(0, -screen_height/2)
t.pendown()
t.goto(0, screen_height/2)

Eine Turtle zum Zeichnen der Punkte erstellen
dot_drawer = turtle.Turtle()
dot_drawer.shape('turtle')
dot_drawer.penup()

# --- Logik # ---
Ungefähr 38 Pixel pro cm auf den meisten Bildschirmen
DOT_DIAMETER = 38

def draw_colored_dot(x, y):
dot_drawer.goto(x, y)

# Farbe basierend auf dem Quadranten bestimmen
if x < 0 and y > 0: # Oben Links
    dot_drawer.dot(DOT_DIAMETER, "red")
elif x > 0 and y > 0: # Oben Rechts
    dot_drawer.dot(DOT_DIAMETER, "blue")
elif x < 0 and y < 0: # Unten Links
    dot_drawer.dot(DOT_DIAMETER, "green")
else: # Unten Rechts
    dot_drawer.dot(DOT_DIAMETER, "yellow")
Auf Klicks lauschen
screen.onclick(draw_colored_dot)

# --- Abschluss # ---
screen.mainloop()
```