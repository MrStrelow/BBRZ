# 1.) benutzereingabe von zahlen 0-100

# 2.) 5 Leben, bei fehler soll eins abgezogen werden.

# 3.) info ob größer oder kleiner.

# 4.) falls gewonnen soll dies ausgegeben werden, falls verloren ebenso.

# 5.) willst du nochmal spielen? (reset von leben, und neue zahl ziehen)

''' 
Notizen:
 - gameloop -> while ganz außen
 - guessloop -> while für zahlen raten
 - können beide loops zusammenfassen.

 - verzweigung:
    -> genug leben?
    -> guess zu hoch oder zu niedrig?
    -> weiterspielen?

 - funktionsaufruf 
    -> zufallszahl erzeugen
    -> userinput
'''

# import random
from random import randint
# from random import randint as r

leben = 5
geheimzahl = randint(0, 100)

# guesloop
while leben > 0:
    guess = int(input("Gib ein [0-100]: "))
    
    leben = leben - 1

    # Zusändigkeit: Logik des Ratens
    # Zustand gewonnen
    if guess == geheimzahl:
        print("gewonnen.", end="")
        leben = 0

    elif guess > geheimzahl:
        print("zahl ist kleiner.")

    elif guess < geheimzahl:
        print("zahl ist großer.")

    # Zusändigkeit: Logik des Ratens
    # Zustand verloren
    if leben == 0 and guess != geheimzahl:
        print("verloren.", end="")

    # Zuständigkeit: Logik des Neustarts
    if leben == 0:
        play_again = input("möchtest du nochmals spielen? [+/-]")

        if play_again == "+":
            geheimzahl = randint(0, 100)
            leben = 5


