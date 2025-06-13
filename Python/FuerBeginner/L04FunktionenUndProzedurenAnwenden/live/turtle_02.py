# --- Vorbereitung # ---
from turtle import *

title("Übung 4.2: Verschachtelte Quadrate - Farben und Umfang")
shape("turtle")
speed(1) # Wir verwenden mit dem Wert 1 eine sichtbare Geschwindigkeit der Turtle.

# --- Logik # ---
umfang_haus = 0   # Wir merken uns den Umfang des Hauses  in dieser Variable - wir setzten es am Anfang auf 0.
umfang_garten = 0 # Wir merken uns den Umfang des Gartens in dieser Variable - wir setzten es am Anfang auf 0.

# --- Äußeres Quadrat zeichnen (z.B. 200x200) # ---
# Wir verwenden die orange Schnur für den Garten.
color(...)

# TODO: Lösche dieses Kommetar und schreibe den Programmcode hier!

# Erste Vorwärtsbewegung mit der Schnur
# TODO: Lösche dieses Kommetar und schreibe den Programmcode hier!
# wir erhöhen die variable umfang_haus
umfang_garten = ... 

# Zweite Vorwärtsbewegung mit der Schnur
# TODO: Lösche dieses Kommetar und schreibe den Programmcode hier!
# wir erhöhen die variable umfang_garten
umfang_garten = ...

# Dritte Vorwärtsbewegung mit der Schnur
# TODO: Lösche dieses Kommetar und schreibe den Programmcode hier!
# wir erhöhen die variable umfang_garten
umfang_garten = ... 

# Vierte Vorwärtsbewegung mit der Schnur
# TODO: Lösche dieses Kommetar und schreibe den Programmcode hier!
# wir erhöhen die variable umfang_garten
umfang_garten = ... 

# --- Inneres Quadrat zeichnen (z.B. 100x100) # ---
# Wir verwenden die violette Schnur für das Haus.
# Wir verwenden die orange Schnur für den Garten.
color(...)

# TODO: Lösche dieses Kommetar und schreibe den Programmcode hier!

# Erste Vorwärtsbewegung mit der Schnur
# TODO: Lösche dieses Kommetar und schreibe den Programmcode hier!
# wir erhöhen die variable umfang_haus
umfang_haus = ... 

# Zweite Vorwärtsbewegung mit der Schnur
# TODO: Lösche dieses Kommetar und schreibe den Programmcode hier!
# wir erhöhen die variable umfang_haus
umfang_haus = ... 

# Dritte Vorwärtsbewegung mit der Schnur
# TODO: Lösche dieses Kommetar und schreibe den Programmcode hier!
# wir erhöhen die variable umfang_haus
umfang_haus = ... 

# Vierte Vorwärtsbewegung mit der Schnur
# TODO: Lösche dieses Kommetar und schreibe den Programmcode hier!
# wir erhöhen die variable umfang_haus
umfang_haus = ... 

hideturtle()

# Ausgabe auf der Console.
print("Umfang des Gartens: ", umfang_garten, " - Umfang des Hauses: ", umfang_haus)

# --- Abschluss # ---
exitonclick() # Warten, bis das Fenster per Klick geschlossen wird.