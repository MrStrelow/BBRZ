from turtle import *
from random import randint

# --- Vorbereitung (passiert nur einmal) ---
shape('turtle')
speed(1)
# --- Logik ---
# Wir drücken die Turtle auf den Boden und machen damit einen Abdruck. Dadruch merkt sie sich wo sie gestartet ist.
stamp() 
penup()

while True:
    # Führer war hier der zufällig gewählte Ort. Jetzt ist es der User, der diesen angibt.
    # Achte auf die Typen! Kommt eine Zahl oder ein Text von der Funktion input zurück?
    eingabe = input("Gib bitte die neue Position in x ein: ")

    # Wir hören nun auf wenn wir "bye" bei der Variable eingabe eingeben.
    # Wir können mit == Vergleiche anstellen. Das bedeutet ist links von == das gleiche wie rechts?
    # Wir fragen also ist "bye" == "bye und dort würde als Antwort True rauskommen.
    # Ersetze nun ein "bye" mit der richtigen Variable, welche beliebige Werte haben kann.
    if eingabe == "bye":
        break
    else:
        # Wenn wir nicht bye eingeben, erwarten wir eine Zahl. 
        # Wir müssen aus dem Text eine nun eine Zahl ohne Kommastellen machen.
        ziel_in_x = int(eingabe)

    eingabe = input("Gib bitte die neue Position in y ein: ")

    # Wir hören nun auf wenn wir "bye" bei der Variable  eingabe eingeben.
    # Wir können mit == Vergleiche anstellen. Das bedeutet ist links von == das gleiche wie rechts?
    # Wir fragen also ist "bye" == "bye und dort würde als Antwort True rauskommen.
    # Ersetze nun ein "bye" mit der richtigen Variable, welche beliebige Werte haben kann.
    if eingabe == "bye":
        break
    else:
        # Wenn wir nicht bye eingeben, erwarten wir eine Zahl. 
        # Wir müssen aus dem Text eine nun eine Zahl ohne Kommastellen machen.
        ziel_in_y = int(eingabe)

    # Wir bewegen die Turtle und passen an wie diese dargestellt wird (Kreis oder Turtle). 
    if ziel_in_x > 0:
        shape('turtle') # Wir verwenden die Form für die rechte Seite auf 'turtle' setzen
    else:
        shape('circle') # Form für die linke Seite auf 'circle' setzen

    # Wir bewegen uns zur zufällig gewählten Position.
    goto(ziel_in_x, ziel_in_y)
    print("Ziel erreich!🏁 Drehe um.🔁")
    
    # Wir bewegen uns zur Ausgangsposition zurück.
    goto(0, 0)

# --- Abschluss ---