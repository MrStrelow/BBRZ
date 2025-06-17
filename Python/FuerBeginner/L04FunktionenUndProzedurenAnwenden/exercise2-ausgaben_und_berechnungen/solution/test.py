from turtle import *
from math import sqrt

# --- Vorbereitung ---
shape("turtle")
# Wir verwenden mit dem Wert 1 eine sichtbare Geschwindigkeit der Turtle.
speed(1) 
import time
time.sleep(3)

# --- Logik ---
# ------------------------------------------------------------------------
# Wir legen Variablen an welche wir später wiederverwenden können.
winkel = 90
laenge_garten = 314

# --- 1. Usere Turtle geht in die Ecke des Gartens welche links-unten ist. ---
# Die Turtle verwendet eine orange Schnur und einen orangen Sand für den Garten.
color("orange", "orange") 

# Wir starten das Ausmalen des Gartens. Wenn wir später end_fill() verwenden wird die Farbe reingemalen. 
begin_fill() 

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

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# --- 2.2) Wir zeichnen eine vertikale Linie von unten nach oben ---
# Die Turtle drückt den Faden auf den Boden und befestigt diesen.
stamp() 

# Die Turtle bewegt sich 314 Schritte in Blickrichtung nach vorne.
forward(laenge_garten)

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# --- 2.3) Wir zeichnen eine horizontale Linie von rechts nach links ---
# Die Turtle drückt den Faden auf den Boden und befestigt diesen.
stamp()

# Die Turtle bewegt sich 314 Schritte in Blickrichtung nach vorne.
forward(laenge_garten)

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# --- 2.4) Wir zeichnen eine vertikale Linie von oben nach unten ---
# Die Turtle drückt den Faden auf den Boden und befestigt diesen.
stamp()

# Die Turtle bewegt sich 314 Schritte in Blickrichtung nach vorne.
forward(laenge_garten)

# Die Turtle dreht sich um 90° nach links.
left(winkel)

# Der Garten wurde fertig gezeichnet. Wir füllen nun den Sand in den Garten.
end_fill()

# ------------------------------------------------------------------------
# --- 3. Usere Turtle geht zur Ecke des Hauses nun bei der Hälfte der unteren Seite ist. ---
# Die Turtle verwendet eine violette Schnur und violette Farbe für das Haus.
color("purple", "purple")

# Wir starten das Ausmalen des Hauses. Wenn wir später end_fill() verwenden wird die Farbe reingemalen. 
begin_fill() 

# Die Turtle packt den Faden in die Tasche.
penup()

# Die Turtle geht zur Mitte der unteren Gartenlänge.
goto(0, -laenge_garten / 2)

# Die Turtle nimmt den Faden aus der Tasche und legen ihn am Boden, wenn wir uns Bewegen.
pendown()

# ------------------------------------------------------------------------
# --- 4. Wir zeichnen das um 45° verschobene quadratische Haus ---
# --- 4.1) Wir zeichnen die erste Linie des Hauses ---
# Die Turtle bewegt sich auf Position laenge_graten / 2 in x und 0 in y.
goto(laenge_garten / 2, 0)

# --- 4.2) Wir zeichnen die zweite Linie des Hauses ---
# Die Turtle bewegt sich auf Position 0 in x und laenge_graten / 2 in y.
goto(0, laenge_garten / 2)

# --- 4.3) Wir zeichnen die dritte Linie des Hauses ---
# Die Turtle bewegt sich auf Position -laenge_graten / 2 in x und 0 in y.
goto(-laenge_garten / 2, 0)

# --- 4.4) Wir zeichnen die vierte Linie des Hauses ---
# Die Turtle bewegt sich auf Position 0 in x und -laenge_graten / 2 in y.
goto(0, -laenge_garten / 2)

# Das Haus wurde fertig gezeichnet. Wir malen nun das Haus an.
end_fill()

# ------------------------------------------------------------------------
# --- Abschluss ---
# Schließt das Fenster nicht, wenn das Programm beendet ist.
done()