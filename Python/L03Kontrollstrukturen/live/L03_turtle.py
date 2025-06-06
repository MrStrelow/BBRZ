from turtle import *

# # --- Vorbereitung # ---
screen = Screen()
screen.title("Übung 1.1: Verschachtelte Quadrate")
t = Turtle()
t.shape("turtle")
t.speed(3) # Eine sichtbare Geschwindigkeit verwenden

# --- Äußeres Quadrat zeichnen (z.B. 200x200) # ---
so_weit_gehe_ich = 200
so_viel_drehe_ich_mich = 90

t.penup()
t.goto(x=-100, y=-100)
t.pendown()
t.forward(so_weit_gehe_ich)
t.left(so_viel_drehe_ich_mich)
t.forward(so_weit_gehe_ich)
t.left(so_viel_drehe_ich_mich)
t.forward(so_weit_gehe_ich)
t.left(so_viel_drehe_ich_mich)
t.forward(so_weit_gehe_ich)

# --- Inneres Quadrat zeichnen (z.B. 100x100) # ---
# TODO: implement me

# --- Abschluss # ---
# t.hideturtle()
screen.exitonclick() # Warten, bis das Fenster per Klick geschlossen wird