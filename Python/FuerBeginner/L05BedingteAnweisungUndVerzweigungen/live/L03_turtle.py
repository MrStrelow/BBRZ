from turtle import *
from random import randint

# --- Vorbereitung ---
# Die Variablen für die Geschwindigkeit.
geschwindigkeit_am_land = 1
geschwindigkeit_am_land_hungrig = 2 * geschwindigkeit_am_land
geschwindigkeit_im_wasser = 50 * geschwindigkeit_am_land

# Die Variablen für die Form.
form_am_land = "turtle"
form_am_land_hungrig = "arrow"
form_im_wasser = "circle"

shape(form_am_land) 
speed(geschwindigkeit_am_land)

# --- Logik ---
# Wir generierem zufällige Koordinaten innerhalb der Fenstergröße.
# Das Wort Zufall wird im Englischen das Wort random. 
breite = window_width()
hoehe = window_height()

# Die Bildschrimbreite geht von z.B. 0 bis 100. Für unsre Turtle ist jedoch die Mitte dieser Breite der 0-Punkt.
# Dadurch ändert sich 0 bis 100 zu -50 bis 50.
# Um die Turtle zufällig zu navigieren, müssen wir eine Zahl zwischen -50 und 50 ziehen. 
# Das gleiche gilt für die Hoehe.

# Die Ganzzahldivision.
# Diese ist unter 5 dividiert durch 2 ist 2, mit 1 Rest bekannt und wird mit Python mit // geschrieben.
# Das 1 Rest wird hier mit // ignorieret.
halbe_breite_ohne_komma = breite // 2 
halbe_hoehe_ohne_komma = hoehe // 2

# Da wir zufällige Zahlen ohne Komma wollen, verwenden wir die Funktion randint.
# Diese benötigt zwei zahlen, zwischen denen sie zufällig eine Wählt. 
# randint(3, 8) gibt eine Zahl welche 3 sein kann, 8 sein kann und alles dazwischen. Alles dazwischen ist 4, 5, 6 und 7.
# Der Name ist eine Kombination aus Random und Integer, was Zufall und Zahl ohne Komma bedeutet.
ziel_in_x = randint(-halbe_breite_ohne_komma, halbe_breite_ohne_komma)
ziel_in_y = randint(-halbe_hoehe_ohne_komma, halbe_hoehe_ohne_komma)

# Die Turtle nimmt den Faden aus der Tasche und legt ihn am Boden wenn sie losgeht.
pendown()

# Die Turtle drückt den Faden in den boden, fixiert diesen und macht einen Abdruck von sich selbst.
stamp()

# Wir bewegen die Turtle und passen an mit einer Mehrfachverzweigung an wie diese dargestellt wird (Kreis oder Turtle) und wie schnell diese ist. 
im_wasser = ziel_in_x < 0
am_land = ziel_in_x >= 0

norden = ziel_in_y > 0
sueden = ziel_in_y <= 0

schnell_im_wasser = im_wasser and sueden
langsam_im_wasser = im_wasser and norden

bewegt_sich_rueckwaerts_am_land = am_land and sueden
bewegt_sich_vorwärts_am_land = am_land and norden

import time
time.sleep(3)

if schnell_im_wasser:
    # Setze die Geschwindigkeit auf die Wassergeschwindigkeit. 
    speed(geschwindigkeit_im_wasser)

    # Die Turtle schwimmt und es ist nur der Panzer sichtbar. Quasi nur ein Kreis.
    # Das englische Wort für Kreis ist circle.
    shape(form_im_wasser) 

    # Wir bewegen uns zur zufällig gewählten Position.
    goto(ziel_in_x, ziel_in_y)

    # Am schluss taucht die Turtle im Wasser unter.
    hideturtle()

elif langsam_im_wasser:
    # Setze die Geschwindigkeit auf die hungrige Landgeschwindigkeit.
    speed(geschwindigkeit_am_land_hungrig)

    # Die Turtle schwimmt und es ist nur der Panzer sichtbar. Quasi nur ein Kreis.
    # Das englische Wort für Kreis ist circle.
    shape(form_im_wasser) 

    # Wir bewegen uns zur zufällig gewählten Position.
    goto(ziel_in_x, ziel_in_y)

    # Am schluss taucht die Turtle im Wasser unter.
    hideturtle()

elif bewegt_sich_rueckwaerts_am_land:
    # Setze die Geschwindigkeit auf die hungrige Landgeschwindigkeit.
    speed(geschwindigkeit_am_land)

    # Die Turtle geht und ist als Turtle sichtbar.
    shape(form_am_land_hungrig) 
    
    # Die Turtle dreht sich nach Westen um nicht geblendet zu werden.
    left(180)

    # Wir bewegen uns zur zufällig gewählten Position.
    goto(ziel_in_x, ziel_in_y)

elif bewegt_sich_vorwärts_am_land:
    # Setze die Geschwindigkeit auf die hungrige Landgeschwindigkeit.
    speed(geschwindigkeit_am_land_hungrig)

    # Die Turtle geht und ist als Turtle sichtbar.
    shape(form_am_land_hungrig) 

    # Wir bewegen uns zur zufällig gewählten Position.
    goto(ziel_in_x, ziel_in_y)

else:
    # Hier sollten wir nie herkommen! Jedoch kann es passieren, wenn wir Fehler machen.
    # Wir geben deshalb aus, dass wir hier nie herkommen sollten
    fehler = "DAS SOLLTE NIE PASSIEREN!"
    write(fehler)
    print(fehler)

# --- Abschluss ---
# Schließt das Fenster nicht, wenn das Programm beendet ist.
done()