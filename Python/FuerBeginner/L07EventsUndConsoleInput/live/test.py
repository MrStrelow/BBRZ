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

#TODO beispiel mit keyboards.