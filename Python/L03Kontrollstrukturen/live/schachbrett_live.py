# 1.) userinput: 
#   - die größe des spielbretts soll angegeben werden.
#   - TODO: welche position soll als start gewählt werden, welche als ziel.

# i.) user informieren was er/sie eingeben soll
dimension = int(input("Größe des Spielbretts eingeben: "))
# print(type(dimension))

# 2.) schachbrett generieren
black_square = "⬛" # windows + .
white_square = "⬜" # oder "\u2B1B"

print(dimension)


# 3.) linien auf den schachbrett von start zu ende zeichnen (achtung ein wenig mathe)