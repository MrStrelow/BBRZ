# --- Vorbereitung ---
from turtle import *

title("Übung 4.2: Verschachtelte Quadrate - Farben und Umfang")
shape("turtle")
speed(1) # Wir verwenden mit dem Wert 1 eine sichtbare Geschwindigkeit der Turtle.

# --- Logik ---
umfang_haus = 0   # Wir merken uns den Umfang des Hauses  in dieser Variable - wir setzten es am Anfang auf 0.
umfang_garten = 0 # Wir merken uns den Umfang des Gartens in dieser Variable - wir setzten es am Anfang auf 0.

# --- Äußeres Quadrat zeichnen (z.B. 200x200) ---
# Wir verwenden die orange Schnur für den Garten.
color("orange")
so_weit_gehe_ich = 200
so_viel_drehe_ich_mich = 90

penup()
neuer_ort = -so_weit_gehe_ich/2
goto(neuer_ort, neuer_ort)
pendown()

# Erste Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
# wir erhöhen die variable umfang_haus
# umfang_garten = umfang_garten + so_weit_gehe_ich
umfang_garten += so_weit_gehe_ich # oder krüzer mit +=
left(so_viel_drehe_ich_mich)

# Zweite Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
umfang_garten += so_weit_gehe_ich
left(so_viel_drehe_ich_mich)

# Dritte Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
umfang_garten += so_weit_gehe_ich
left(so_viel_drehe_ich_mich)

# Vierte Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
umfang_garten += so_weit_gehe_ich
left(so_viel_drehe_ich_mich)


# --- Inneres Quadrat zeichnen (z.B. 100x100) ---
penup()
neuer_ort = -so_weit_gehe_ich/4
goto(neuer_ort, neuer_ort)
pendown()

# Wir verwenden die violette Schnur für das Haus.
color("purple")
# so_weit_gehe_ich = so_weit_gehe_ich / 2
so_weit_gehe_ich /= 2 # Wir können es kürzer mithilfe des gemischten Operators /= schreiben. Diese ist eine division und Zuweisung  in einer Zeile.

# Erste Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)

# wir erhöhen die variable umfang_haus
# umfang_haus = umfang_haus + so_weit_gehe_ich
umfang_haus += so_weit_gehe_ich # oder krüzer mit +=
left(so_viel_drehe_ich_mich)

# Zweite Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
umfang_haus += so_weit_gehe_ich
left(so_viel_drehe_ich_mich)

# Dritte Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
umfang_haus += so_weit_gehe_ich
left(so_viel_drehe_ich_mich)

# Vierte Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
umfang_haus += so_weit_gehe_ich
left(so_viel_drehe_ich_mich)

hideturtle()

# Ausgabe auf der Console.
print("Umfang des Gartens: ", umfang_garten, " - Umfang des Hauses: ", umfang_haus)

# --- Abschluss ---
done() Schließt das Fenster nicht, wenn das Programm beendet ist.