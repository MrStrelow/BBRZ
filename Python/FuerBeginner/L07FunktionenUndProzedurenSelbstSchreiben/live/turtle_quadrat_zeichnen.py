from turtle import *

# # --- Vorbereitung ---
screen = Screen()
screen.title("Übung 1.1: Verschachtelte Quadrate")

shape("turtle")
speed(1) # Eine sichtbare Geschwindigkeit verwenden

# --- Äußeres Quadrat zeichnen (z.B. 200x200) ---
so_weit_gehe_ich = 100
so_viel_drehe_ich_mich = 90

# das ist das große quadrat
penup()
goto(x=-so_weit_gehe_ich/2, y=-so_weit_gehe_ich/2)
pendown()

forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)
forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)
forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)
forward(so_weit_gehe_ich)

# das ist das kleine quadrat
penup()
goto(x=-so_weit_gehe_ich/4, y=-so_weit_gehe_ich/4)
pendown()

left(90)
# so_weit_gehe_ich = so_weit_gehe_ich / 2   # das ist das gleiche wie
so_weit_gehe_ich /= 2                       # das ist das gleiche wie

forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)
forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)
forward(so_weit_gehe_ich)
left(so_viel_drehe_ich_mich)
forward(so_weit_gehe_ich)


# --- Abschluss ---
heid_dördl = hideturtle
heid_dördl()
screen.exitonclick() # Warten, bis das Fenster per Klick geschlossen wird