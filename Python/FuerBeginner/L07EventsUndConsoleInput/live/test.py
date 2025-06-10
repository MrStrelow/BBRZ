from turtle import *

# --- Vorbereitung # ---
screen = Screen()
screen.title("Übung 7.6: Farbige Punkte - Mehrfachverzweigung")
screen_width = screen.window_width()
screen_height = screen.window_height()
hideturtle()
speed("fastest")

# Vertikale Streifen zeichnen
# Für 5 Streifen brauchen wir 4 Trennlinien.
# Jede Linie ist bei einem Fünftel der Breite verschoben.
# Die Koordinaten gehen von -breite/2 bis +breite/2.
# Positionen der Linien: -3/10, -1/10, +1/10, +3/10 der Breite
linie1_x = -screen_width * 0.3
linie2_x = -screen_width * 0.1
linie3_x = screen_width * 0.1
linie4_x = screen_width * 0.3
    
penup()

# --- Logik # ---
groesse_des_punktes = 40

def zeichne_bunten_punkt(x, y):
    penup() 
    goto(x, y)

    # Farbe basierend auf expliziter Bereichslogik bestimmen
    
    # Streifen 1 (ganz links)
    if x <= linie1_x:
        dot(groesse_des_punktes, "green")
        
    # Streifen 2 (links)
    elif linie1_x < x and x <= linie2_x:
        dot(groesse_des_punktes, "violet")
        
    # Streifen 3 (Mitte)
    elif linie2_x < x and x <= linie3_x:
        dot(groesse_des_punktes, "orange")
        
    # Streifen 4 (rechts)
    elif linie3_x < x and x <= linie4_x:
        dot(groesse_des_punktes, "blue")
        
    # Streifen 5 (ganz rechts)
    elif linie4_x < x:
        dot(groesse_des_punktes, "red")

# Auf Klicks lauschen
screen.onclick(zeichne_bunten_punkt)

# --- Abschluss # ---
screen.mainloop()