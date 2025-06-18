from turtle import *

# --- Vorbereitung ---
screen = Screen()

# Erstellen unserer Helden-Turtle
shape("turtle")
shapesize(2)
color("darkgreen")
penup()

# --- Logik ---
# Wir definieren, wie weit die Turtle bei jedem Tastendruck gehen soll.
SCHRITTWEITE = 20

# Wir brauchen vier separate Funktionen, eine für jede Pfeiltaste.

def gehe_hoch():
    """Setzt die Ausrichtung nach oben (90 Grad) und geht einen Schritt."""
    setheading(90)
    forward(SCHRITTWEITE)

def gehe_runter():
    """Setzt die Ausrichtung nach unten (270 Grad) und geht einen Schritt."""
    setheading(270)
    forward(SCHRITTWEITE)

def gehe_links():
    """Setzt die Ausrichtung nach links (180 Grad) und geht einen Schritt."""
    setheading(180)
    forward(SCHRITTWEITE)

def gehe_rechts():
    """Setzt die Ausrichtung nach rechts (0 Grad) und geht einen Schritt."""
    setheading(0)
    forward(SCHRITTWEITE)


# --- Ereignis-Verknüpfung (Event Binding) ---
# Damit Tastendrücke erkannt werden, müssen wir zwei Dinge tun:
# 1. Dem screen sagen, dass er "zuhören" soll.
screen.listen()

# 2. Jede Taste mit der Funktion verknüpfen, die sie auslösen soll.
# Die Namen für die Pfeiltasten sind: "Up", "Down", "Left", "Right"
screen.onkey(gehe_hoch, "Up")
screen.onkey(gehe_runter, "Down")
screen.onkey(gehe_links, "Left")
screen.onkey(gehe_rechts, "Right")


# --- Abschluss ---
# Hält das Fenster offen und wartet auf Tastendrücke.
screen.mainloop()