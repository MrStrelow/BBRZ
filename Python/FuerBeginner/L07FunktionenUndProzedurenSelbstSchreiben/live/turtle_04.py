from turtle import *
from math import sqrt

# --- Vorbereitung ---
title("Übung 1.4: Renoviertes Haus")
shape('turtle')
speed(1)

# --- Äußeres Quadrat ---
so_weit_gehe_ich = 200
so_viel_drehe_ich_mich = 90

penup()
neuer_ort = -so_weit_gehe_ich/2
goto(neuer_ort, neuer_ort)
pendown()

# Es wird die Farbe der Linien für das äußere Quadrat festgelegt.
color("orange", "orange") # Linienfarbe orange, Füllfarbe orange
begin_fill() # Wir starten das Ausmalen der Form. Wenn wir später end_fill() verwenden wird die Farbe reingemalen. 

# Erste Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)

# Zweite Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)

# Dritte Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)

# Vierte Vorwärtsbewegung mit der Schnur
forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)

end_fill()
# --- Inneres gedrehtes Quadrat ---
# Die Eckpunkte des inneren Quadrats liegen auf den Mittelpunkten der äußeren Seiten.
# laenge_des_inneren_quadrats = sqrt(2)*so_weit_gehe_ich/2

penup()
forward(so_weit_gehe_ich / 2) # Zum Mittelpunkt der unteren Seite gehen
left(so_viel_drehe_ich_mich / 2) # 45 Grad drehen, um das innere Quadrat zu beginnen
pendown()

color("purple", "purple") # Linienfarbe violett, Füllfarbe violett
begin_fill() # Wir starten das Ausmalen der Form. Wenn wir später end_fill() verwenden wird die Farbe reingemalen. 

# Erste Vorwärtsbewegung mit der Schnur
goto(so_weit_gehe_ich/2, 0)
left(so_viel_drehe_ich_mich)

# Zweite Vorwärtsbewegung mit der Schnur
goto(0, so_weit_gehe_ich/2)
left(so_viel_drehe_ich_mich)

# Dritte Vorwärtsbewegung mit der Schnur
goto(-so_weit_gehe_ich/2, 0)
left(so_viel_drehe_ich_mich)

# Vierte Vorwärtsbewegung mit der Schnur
goto(0, -so_weit_gehe_ich/2)
left(so_viel_drehe_ich_mich)

end_fill()

hideturtle()

# --- Abschluss ---
exitonclick() # Das Fenster wird geschlossen, wenn wir mit der Maus in das Fenster klicken.