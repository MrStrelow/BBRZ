import turtle
import random

# # --- Vorbereitung # ---
screen = turtle.Screen()
screen.title("Übung 2.1: Zeichnen rechte Hälfte")
screen_width = screen.window_width()
t = turtle.Turtle()
t.shape('turtle')

# --- Logik # ---
# Generiere zufällige Koordinaten innerhalb der Fenstergröße
random_x = random.randint(-screen_width // 2, screen_width // 2)
random_y = random.randint(-screen.window_height() // 2, screen.window_height() // 2)

# Prüfen, ob die x-Koordinate in der rechten Hälfte liegt
# Das Zentrum ist (0,0), also ist die rechte Hälfte bei x > 0
if random_x > 0:
    t.penup()
    t.goto(random_x, random_y)
    t.stamp() # Hinterlässt einen Abdruck der Turtle
else:
    # Wenn nicht rechts, nichts tun. Das Programm wartet nur auf das Schließen.
    t.hideturtle()

# --- Abschluss # ---
screen.exitonclick()