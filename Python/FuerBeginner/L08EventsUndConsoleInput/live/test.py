from turtle import *

# --- Vorbereitung ---
screen = Screen()
breite = window_width()

# Erstellen unserer Helden-Turtle
shape("turtle")
shapesize(2)
penup()

# --- Logik ---
# Vertikale Streifen zeichnen
# Für 4 Streifen brauchen wir 3 Trennlinien.
# Die eine Trennlinie geht durch das Haus bei 0 in der x-Position.
# die eine andere Trennlinie halbiert das Meer und
# die eine andere Trennlinie halbiert die Wüste.
linie_haus = 0
linie_meer = -breite / 2
linie_wueste = breite / 2

# Wir definieren, wie weit die Turtle bei jedem Tastendruck gehen soll.
# Wir brauchen vier separate Prozeduren, eine für jede Pfeiltaste.
def gehe_hoch():
    """Setzt die Ausrichtung nach oben (90 Grad) und geht einen Schritt."""
    setheading(90)
    forward(40)

    # Wir bekommen leider nicht wie beim Maus-Event die Koordinaten von außen herein.
    # Wir müssen es selbst bestimmen. Wir verwenden dazu xcor() und ycor().
    # Eine Funktion kann direkt verwendet werden um zeichne_bunten_punkt die x-Position und y-Position zu übergeben.
    # Eine Funktion erzeugt einen Wert, wir brauchen deshalb keine extra Variable dazu.
    # Das funktioniert nicht mit einer Prozedur! Denn diese gibt nichts zurück und erzeugt damit nichts!

    # Rufe hier das zeichnen des farbigen Punktes auf und übergebe xcor() und ycor().
    zeichne_bunten_punkt(xcor(), ycor())

def gehe_runter():
    """Setzt die Ausrichtung nach unten (270 Grad) und geht einen Schritt."""
    setheading(270)
    forward(40)

    # Rufe hier das zeichnen des farbigen Punktes auf und übergebe xcor() und ycor().
    zeichne_bunten_punkt(xcor(), ycor())

def gehe_links():
    """Setzt die Ausrichtung nach links (180 Grad) und geht einen Schritt."""
    setheading(180)
    forward(40)

    # Rufe hier das zeichnen des farbigen Punktes auf und übergebe xcor() und ycor().
    zeichne_bunten_punkt(xcor(), ycor())

def gehe_rechts():
    """Setzt die Ausrichtung nach rechts (0 Grad) und geht einen Schritt."""
    setheading(0)
    forward(40)

    # Rufe hier das zeichnen des farbigen Punktes auf und übergebe xcor() und ycor().
    zeichne_bunten_punkt(xcor(), ycor())

# Wir brauchen auch die Prozedur welche für die Farben zuständig ist. Dabei ist keine Änderung notwendig.
def zeichne_bunten_punkt(x, y):
    groesse_des_punktes = 80

    penup() 
    goto(x, y)
    
    # Streifen ganz links
    if -breite < x and x <= linie_meer:
        dot(groesse_des_punktes, "orange")
        
    # Streifen links
    elif linie_meer < x and x <= linie_haus:
        dot(groesse_des_punktes, "violet")
        
    # Streifen rechts
    elif linie_haus < x and x <= linie_wueste:
        dot(groesse_des_punktes, "blue")
        
    # Streifen ganz rechts
    elif linie_wueste < x and x <= breite:
        dot(groesse_des_punktes, "yellow")

    else:
        ohje = "Das sollte gar nie passieren"
        print(ohje)
        write(ohje)

# --- Ereignis-Verknüpfung ---
# Damit Tastendrücke erkannt werden, müssen wir zwei Dinge tun:
# 1. Dem screen sagen, dass er "zuhören" soll.
screen.listen()

# 2. Eine Prozedur dem Event übergeben welche ausgeführt wird.
# Die Namen für die Pfeiltasten sind: "Up", "Down", "Left", "Right"
# Bewegen
screen.onkey(gehe_hoch, "Up")
screen.onkey(gehe_runter, "Down")
screen.onkey(gehe_links, "Left")
screen.onkey(gehe_rechts, "Right")

# --- Abschluss ---
screen.mainloop()