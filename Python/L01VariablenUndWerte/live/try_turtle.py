# (Schon im Mausklick-Beispiel oben verwendet)
import random
from turtle import *


pixel = Turtle()
# Zufällige Farbe
farben_liste = ["red", "green", "blue", "yellow", "purple",
"pink", "brown"]
zufalls_farbe = random.choice(farben_liste) # Wähle eine
# zufällige Farbe aus der Liste
pixel.pencolor(zufalls_farbe)
pixel.pensize(random.randint(1, 10)) # Zufällige Stiftdicke
# zwischen 1 und 10
# Zufällige Position
zufalls_x = random.randint(-150, 150) # Zufällige Ganzzahl
# zwischen -150 und 150
zufalls_y = random.randint(-150, 150)
pixel.penup()
pixel.goto(zufalls_x, zufalls_y)
pixel.pendown()
pixel.dot(random.randint(10, 30), zufalls_farbe) # Zeichne
# einen zufälligen Punkt
pixel.write(f" Ich bin an einem zufälligen Ort!({zufalls_x},{zufalls_y}) 🎲", font=("Arial", 10, "normal"))

exitonclick()