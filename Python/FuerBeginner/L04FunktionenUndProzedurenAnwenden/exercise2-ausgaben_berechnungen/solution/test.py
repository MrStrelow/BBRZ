from turtle import *

# --- Vorbereitung ---
shape("turtle")
# Wir verwenden mit dem Wert 1 eine sichtbare Geschwindigkeit der Turtle.
speed(1) 
screen = Screen()
# Wir laden ein ein Bild mit Haus als Hintergrund
screen.bgpic("C://Users//c4321116//Documents//GitHub//BBRZ//Python//FuerBeginner//L04FunktionenUndProzedurenAnwenden//exercise2-ausgaben_berechnungen//images//4.2.gif")
update()

# Wir legen Variablen an welche wir später wiederverwenden können.
laenge_garten = 314
winkel = 90

# --- Logik ---
# ------------------------------------------------------------------------
# --- 1. Usere Turtle geht zur Ecke des Garten welche links-unten ist. ---
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

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# --- 2.2) Wir zeichnen eine vertikale Linie von unten nach oben ---
# Die Turtle drückt den Faden auf den Boden und befestigt diesen
stamp()

# Die Turtle bewegt sich 314 Schritte in Blickrichtung nach vorne.
forward(laenge_garten)

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# --- 2.3) Wir zeichnen eine horizontale Linie von rechts nach links ---
# Die Turtle drückt den Faden auf den Boden und befestigt diesen
stamp()

# Die Turtle bewegt sich 314 Schritte in Blickrichtung nach vorne.
forward(laenge_garten)

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# --- 2.4) Wir zeichnen eine vertikale Linie von oben nach unten ---
# Die Turtle drückt den Faden auf den Boden und befestigt diesen
stamp()

# Die Turtle bewegt sich 314 Schritte in Blickrichtung nach vorne.
forward(laenge_garten)

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# ------------------------------------------------------------------------
# --- 3. Usere Turtle geht zur Ecke des Hauses welche links-unten ist. ---
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

# --- 4.2) Wir zeichnen eine vertikale Linie von unten nach oben ---
# Die Turtle bewegt sich 157 Schritte in Blickrichtung nach vorne.
forward(laenge_haus)

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# --- 4.3) Wir zeichnen eine horizontale Linie von rechts nach links ---
# Die Turtle bewegt sich 157 Schritte in Blickrichtung nach vorne.
forward(laenge_haus)

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# --- 4.4) Wir zeichnen eine vertikale Linie von oben nach unten ---
# Die Turtle bewegt sich 157 Schritte in Blickrichtung nach vorne.
forward(laenge_haus)

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# ------------------------------------------------------------------------
# --- Abschluss ---
# Schließt das Fenster nicht, wenn das Programm beendet ist.
done() 