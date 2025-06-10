from turtle import *

# --- Vorbereitung # ---
title("Übung 1.3: Verschachtelte Quadrate - Wo bin ich und wohin gehe ich?")
shape("turtle")
speed(1) # Wir verwenden mit dem Wert 1 eine sichtbare Geschwindigkeit der Turtle.

# --- Logik # ---
# --- Äußeres Quadrat zeichnen (z.B. 200x200) # ---
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
left(so_viel_drehe_ich_mich)
write("Pos: " + str(position()) + "\n" + "Richtung: " + str(heading()))

# Zweite Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)
write("Pos: " + str(position()) + "\n" + "Richtung: " + str(heading()))

# Dritte Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)
write("Pos: " + str(position()) + "\n" + "Richtung: " + str(heading()))

# Vierte Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)
write("Pos: " + str(position()) + "\n" + "Richtung: " + str(heading()))


# --- Inneres Quadrat zeichnen (z.B. 100x100) # ---
penup()
neuer_ort = -so_weit_gehe_ich/4
goto(neuer_ort, neuer_ort)

pendown()
# Wir verwenden die violette Schnur für das Haus.
color("purple")
so_weit_gehe_ich = so_weit_gehe_ich / 2
# so_weit_gehe_ich /= 2 # Wir können es kürzer mithilfe des gemischten Operators /= schreiben. Diese ist eine division und Zuweisung  in einer Zeile.

# Erste Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
# wir erhöhen die variable umfang_haus
left(so_viel_drehe_ich_mich)
write("Pos: " + str(position()) + "\n" + "Richtung: " + str(heading()))

# Zweite Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)
write("Pos: " + str(position()) + "\n" + "Richtung: " + str(heading()))

# Dritte Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)
write("Pos: " + str(position()) + "\n" + "Richtung: " + str(heading()))

# Vierte Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)
write("Pos: " + str(position()) + "\n" + "Richtung: " + str(heading()))

hideturtle()

# --- Abschluss # ---
exitonclick() # Warten, bis das Fenster per Klick geschlossen wird.