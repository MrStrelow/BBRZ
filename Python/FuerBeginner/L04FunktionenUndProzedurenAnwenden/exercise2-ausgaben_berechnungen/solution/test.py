from turtle import *

# --- Vorbereitung ---
shape("turtle")
# Wir verwenden mit dem Wert 1 eine sichtbare Geschwindigkeit der Turtle.
speed(1) 

# --- Logik ---
# ------------------------------------------------------------------------
# Wir legen Variablen an welche wir später wiederverwenden können.
winkel = 90

laenge_garten = 314
laenge_haus = laenge_garten / 2

# --- 1. Usere Turtle geht in die Ecke des Gartens welche links-unten ist. ---
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
# Die Turtle drückt den Faden auf den Boden und befestigt diesen.
stamp()

# Die Turtle bewegt sich 314 Schritte in Blickrichtung nach vorne.
forward(laenge_garten)

# Die Turtle schreibt auf den Boden wie weit sie bereits gegangen ist.
write("Pos: " + str(position()) + "\n" + "Richtung: " + str(heading()))

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# --- 2.2) Wir zeichnen eine vertikale Linie von unten nach oben ---
# Die Turtle drückt den Faden auf den Boden und befestigt diesen.
stamp() 

# Die Turtle bewegt sich 314 Schritte in Blickrichtung nach vorne.
forward(laenge_garten)

# Die Turtle schreibt auf den Boden wie weit sie bereits gegangen ist.
write("Pos: " + str(position()) + "\n" + "Richtung: " + str(heading()))

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# --- 2.3) Wir zeichnen eine horizontale Linie von rechts nach links ---
# Die Turtle drückt den Faden auf den Boden und befestigt diesen.
stamp()

# Die Turtle bewegt sich 314 Schritte in Blickrichtung nach vorne.
forward(laenge_garten)

# Die Turtle schreibt auf den Boden wie weit sie bereits gegangen ist.
write("Pos: " + str(position()) + "\n" + "Richtung: " + str(heading()))

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# --- 2.4) Wir zeichnen eine vertikale Linie von oben nach unten ---
# Die Turtle drückt den Faden auf den Boden und befestigt diesen.
stamp()

# Die Turtle bewegt sich 314 Schritte in Blickrichtung nach vorne.
forward(laenge_garten)

# Die Turtle schreibt auf den Boden wie weit sie bereits gegangen ist.
write("Pos: " + str(position()) + "\n" + "Richtung: " + str(heading()))

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# ------------------------------------------------------------------------
# --- 3. Usere Turtle geht zur Ecke des Hauses welche links-unten ist. ---
# Die Turtle verwendet eine violette Schnur für den Garten.
color("purple")

# Die Turtle packt den Faden in die Tasche.
penup()

# Die Turtle geht in die Ecke welche links-unten ist.
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

# Die Turtle schreibt auf den Boden wie weit sie bereits gegangen ist.
write("Pos: " + str(position()) + "\n" + "Richtung: " + str(heading()))

# --- 4.2) Wir zeichnen eine vertikale Linie von unten nach oben ---
# Die Turtle bewegt sich 157 Schritte in Blickrichtung nach vorne.
forward(laenge_haus)

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# Die Turtle schreibt auf den Boden wie weit sie bereits gegangen ist.
write("Pos: " + str(position()) + "\n" + "Richtung: " + str(heading()))

# --- 4.3) Wir zeichnen eine horizontale Linie von rechts nach links ---
# Die Turtle bewegt sich 157 Schritte in Blickrichtung nach vorne.
forward(laenge_haus)

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# Die Turtle schreibt auf den Boden wie weit sie bereits gegangen ist.
write("Pos: " + str(position()) + "\n" + "Richtung: " + str(heading()))

# --- 4.4) Wir zeichnen eine vertikale Linie von oben nach unten ---
# Die Turtle bewegt sich 157 Schritte in Blickrichtung nach vorne.
forward(laenge_haus)

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# Die Turtle schreibt auf den Boden wie weit sie bereits gegangen ist.
write("Pos: " + str(position()) + "\n" + "Richtung: " + str(heading()))

# ------------------------------------------------------------------------
# --- Abschluss ---
# Schließt das Fenster nicht, wenn das Programm beendet ist.
done()