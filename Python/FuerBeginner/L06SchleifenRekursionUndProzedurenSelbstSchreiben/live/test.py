from turtle import *
from random import randint

# --- Vorbereitung ---
# Die Variablen für die Geschwindigkeit.
geschwindigkeit_am_land = 1
geschwindigkeit_im_wasser = 50 * geschwindigkeit_am_land

# Die Variablen für die Form.
form_am_land = "turtle"
form_im_wasser = "circle"

shape(form_am_land) 
speed(geschwindigkeit_am_land)

# --- Logik ---
# Die Turtle nimmt den Faden aus der Tasche und legt ihn am Boden wenn sie losgeht.
pendown()

# Die Turtle drückt den Faden in den boden, fixiert diesen und macht einen Abdruck von sich selbst.
stamp()

breite = window_width()
hoehe = window_height()

halbe_breite_ohne_komma = breite // 2 
halbe_hoehe_ohne_komma = hoehe // 2

# Wir erstellen eine neue Prozedur. Das wird Definition einer Funktion genannt und wird mit dem Keyword def gemacht.
# Achtung! Wir enden mit einem Doppelpunkt, denn danach kommt eine Einrückung.
def ich_rufe_mich_selbst_auf():
    # Wir schreiben alles was zuerst in der While-Schleife war, in die Prozedur rein.
    ziel_in_x = randint(-halbe_breite_ohne_komma, halbe_breite_ohne_komma)
    ziel_in_y = randint(-halbe_hoehe_ohne_komma, halbe_hoehe_ohne_komma)

    # Wir bewegen die Turtle und passen an wie diese dargestellt wird (Kreis oder Turtle). 
    if ziel_in_x > 0:
        # Wir verwenden die Form für die rechte Seite. Diese ist 'turtle'.
        shape(form_am_land) 
        speed(geschwindigkeit_am_land)
    else:
        # Wir verwenden die Form für die rechte Seite. Diese ist 'circle'.
        shape(form_im_wasser) 
        speed(geschwindigkeit_im_wasser)

    # Die Turtle nimmt den Faden aus der Tasche und legt ihn am Boden wenn sie losgeht.
    pendown()

    # Die Turtle bewegt sich an einen zufällig gewählten Ort.
    goto(ziel_in_x, ziel_in_y)

    # Die Turtle markier diesen Ort mit einem roten Punkt.
    dot(25, "red")

    # Die Turtle schneidet den Faden ab und gibt die Rolle mit dem Faden wieder in die Tasche. Sie legt ihn nicht mehr auf den Boden wenn sie losgeht.
    penup()

    # Die Turtle bewegt sich zur Ausgangsposition zurück.
    goto(0, 0)

    # Wichtig! Wir müssen uns am Ende der Prozedur selbst aufrufen! 
    # Damit ist ein Aufruf von ich_rufe_mich_selbst_auf gemeint.
    # Wir rufen eine Prozedur ohne Parameter auf, indem wir () hinter den Namen der Prozedur schreiben.
    ich_rufe_mich_selbst_auf()


# Der start der Rekursion welche niemals abbrechen soll.
# Wir haben nun ich_rufe_mich_selbst_auf erstellt (definiert), jedoch noch nicht aufgerufen. 
# Um das zu tun schreiben wir ich_rufe_mich_selbst_auf() nochmals hin.
ich_rufe_mich_selbst_auf()

# --- Abschluss ---
# Hier steht nichts mehr... denn wir sind für immer oben gefangen.